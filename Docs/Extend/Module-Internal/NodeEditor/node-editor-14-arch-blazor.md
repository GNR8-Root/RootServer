# Blazor Data Layer

---

## **Services Architecture**

```
/Services
├── IAirtableService.cs       # Airtable API abstraction
├── AirtableService.cs         # HTTP client implementation
├── IGraphService.cs           # Business logic interface
├── GraphService.cs            # Normalization, caching, validation
├── IJSRuntimeService.cs       # JS interop wrapper
└── JSRuntimeService.cs        # Interop implementation
```

---

## **AirtableService**

*REST API client with retry and rate limiting*

**Configuration:**
```csharp
public class AirtableConfig
{
    public string ApiKey { get; set; }
    public string BaseId { get; set; }
    public string GraphsTable { get; set; } = "Graphs";
    public string NodesTable { get; set; } = "Nodes";
    public string EdgesTable { get; set; } = "Edges";
    public int RateLimitPerSecond { get; set; } = 5;
}
```

**Methods:**
```csharp
Task<AirtableResponse<Graph>> GetGraphsAsync(string? filterFormula = null);
Task<AirtableResponse<Node>> GetNodesAsync(string graphId);
Task<AirtableResponse<Edge>> GetEdgesAsync(string graphId);

Task<Graph> UpdateGraphAsync(string graphId, GraphUpdate update);
Task<Node> UpdateNodeAsync(string nodeId, NodeUpdate update);
Task<Edge> CreateEdgeAsync(EdgeCreate create);
Task DeleteEdgeAsync(string edgeId);

// Batch operations for efficiency
Task<BatchResult> BatchUpdateNodesAsync(IEnumerable<NodeUpdate> updates);
```

**ETag Support:**
```csharp
public class AirtableResponse<T>
{
    public List<T> Records { get; set; }
    public string? ETag { get; set; }
    public bool NotModified { get; set; }
}

// Usage
var response = await airtable.GetNodesAsync(graphId, 
    ifNoneMatch: cachedETag);
if (response.NotModified) {
    return cachedData;
}
```

---

## **GraphService**

*Business logic and normalization*

**Graph Snapshot Generation:**
```csharp
public async Task<GraphSnapshot> BuildSnapshotAsync(string graphId)
{
    // 1. Fetch raw data
    var graph = await _airtable.GetGraphAsync(graphId);
    var nodes = await _airtable.GetNodesAsync(graphId);
    var edges = await _airtable.GetEdgesAsync(graphId);
    
    // 2. Normalize nodes
    var normalizedNodes = nodes.Select(n => new SnapshotNode
    {
        Id = n.NodeId,
        Type = n.Type,
        Name = n.Name,
        X = n.X,
        Y = n.Y,
        W = n.W ?? GetDefaultWidth(n.Type),
        H = ComputeHeight(n),
        Data = JsonSerializer.Deserialize<Dictionary<string, object>>(n.Data),
        Ui = JsonSerializer.Deserialize<NodeUi>(n.Ui) ?? new(),
        Ports = BuildPorts(n),
        MacroGraphId = n.MacroGraphId
    }).ToList();
    
    // 3. Normalize edges
    var normalizedEdges = edges.Select(e => new SnapshotEdge
    {
        Id = e.EdgeId,
        Kind = e.Kind,
        From = e.FromNode,
        FromPort = e.FromPort,
        To = e.ToNode,
        ToPort = e.ToPort,
        Style = JsonSerializer.Deserialize<EdgeStyle>(e.Style) ?? new()
    }).ToList();
    
    // 4. Build snapshot
    return new GraphSnapshot
    {
        GraphId = graphId,
        Version = graph.Version,
        Name = graph.Name,
        Metadata = JsonSerializer.Deserialize<GraphMetadata>(graph.Metadata),
        Nodes = normalizedNodes,
        Edges = normalizedEdges
    };
}
```

**Port Building Logic:**
```csharp
private Dictionary<string, PortDefinition> BuildPorts(Node node)
{
    var ports = new Dictionary<string, PortDefinition>();
    
    // Flow ports based on type
    switch (node.Type)
    {
        case NodeType.Root:
            ports["flowOut"] = new PortDefinition 
            { 
                Side = "bottom", 
                Datatype = "flow",
                Kind = "FlowOut"
            };
            break;
            
        case NodeType.Sequence:
        case NodeType.Selector:
            ports["flowIn"] = new PortDefinition 
            { 
                Side = "top", 
                Datatype = "flow",
                Kind = "FlowIn"
            };
            ports["flowOut"] = new PortDefinition 
            { 
                Side = "bottom", 
                Datatype = "flow",
                Kind = "FlowOut" //single FlowOut, multiple edges with ordering via edge.index
            };
            break;
            
        case NodeType.Action:
        case NodeType.Condition:
            ports["flowIn"] = new PortDefinition 
            { 
                Side = "top", 
                Datatype = "flow",
                Kind = "FlowIn"
            };
            break;
    }
    
    // Data ports from node.Data properties
    if (node.Data != null)
    {
        var data = JsonSerializer.Deserialize<Dictionary<string, object>>(node.Data);
        int index = 0;
        foreach (var kvp in data)
        {
            ports[$"dataIn_{kvp.Key}"] = new PortDefinition
            {
                Side = "left",
                Datatype = InferDatatype(kvp.Value),
                Kind = "DataIn",
                Index = index++
            };
        }
    }
    
    return ports;
}
```

---

## **JSRuntimeService**

*Interop wrapper with error handling*

```csharp
public class JSRuntimeService : IJSRuntimeService
{
    private readonly IJSRuntime _js;
    private readonly ILogger<JSRuntimeService> _logger;
    
    public async Task LoadGraphAsync(GraphSnapshot snapshot)
    {
        try
        {
            await _js.InvokeVoidAsync("graphEditor.loadGraph", snapshot);
        }
        catch (JSException ex)
        {
            _logger.LogError(ex, "Failed to load graph {GraphId}", snapshot.GraphId);
            throw new GraphLoadException("Could not initialize graph editor", ex);
        }
    }
    
    public async Task<LayoutExport> ExportLayoutAsync()
    {
        try
        {
            return await _js.InvokeAsync<LayoutExport>("graphEditor.exportLayout");
        }
        catch (JSException ex)
        {
            _logger.LogError(ex, "Failed to export layout");
            return new LayoutExport { Nodes = new Dictionary<string, Position>() };
        }
    }
    
    // Callback registration
    public async Task RegisterCallbacksAsync(DotNetObjectReference<GraphEditorComponent> dotNetRef)
    {
        await _js.InvokeVoidAsync("graphEditor.setCallbacks", dotNetRef);
    }
}
```

---

## **Blazor Component**

*Main editor component*

```razor
@page "/editor/{GraphId}"
@inject IGraphService GraphService
@inject IJSRuntimeService JSRuntime
@inject NavigationManager Navigation

<div class="editor-container">
    <div class="editor-header">
        <Breadcrumbs Path="@_breadcrumbs" OnNavigate="NavigateToGraph" />
        <button @onclick="ReloadFromAirtable" disabled="@_isLoading">
            <i class="icon-refresh"></i> Reload
        </button>
        @if (_hasRemoteChanges)
        {
            <div class="update-banner">
                Remote changes available 
                <button @onclick="ApplyRemoteChanges">Apply</button>
            </div>
        }
    </div>
    
    <div class="editor-canvas" @ref="_canvasContainer">
        <!-- p5.js canvas injected here -->
    </div>
    
    <div class="editor-sidebar">
        @if (_selectedNode != null)
        {
            <NodeInspector Node="@_selectedNode" OnUpdate="UpdateNode" />
        }
    </div>
</div>

@code {
    [Parameter] public string GraphId { get; set; } = "";
    
    private DotNetObjectReference<GraphEditorComponent>? _dotNetRef;
    private ElementReference _canvasContainer;
    private Stack<string> _graphStack = new();
    private List<BreadcrumbItem> _breadcrumbs = new();
    private bool _isLoading;
    private bool _hasRemoteChanges;
    private string? _cachedETag;
    
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            _dotNetRef = DotNetObjectReference.Create(this);
            await JSRuntime.RegisterCallbacksAsync(_dotNetRef);
            await LoadGraphAsync(GraphId);
            StartStreamingUpdates();
        }
    }
    
    private async Task LoadGraphAsync(string graphId)
    {
        _isLoading = true;
        StateHasChanged();
        
        try
        {
            var snapshot = await GraphService.BuildSnapshotAsync(graphId);
            await JSRuntime.LoadGraphAsync(snapshot);
            
            _graphStack.Push(graphId);
            UpdateBreadcrumbs();
        }
        finally
        {
            _isLoading = false;
            StateHasChanged();
        }
    }
    
    [JSInvokable]
    public async Task OnNodeMoveEnd(string nodeId, double x, double y)
    {
        await GraphService.UpdateNodePositionAsync(nodeId, x, y);
    }
    
    [JSInvokable]
    public async Task OnEdgeCreated(EdgeCreateDto edge)
    {
        await GraphService.CreateEdgeAsync(edge);
    }
    
    [JSInvokable]
    public async Task OnEnterMacro(string nodeId, string macroGraphId)
    {
        await LoadGraphAsync(macroGraphId);
    }
    
    private async Task ReloadFromAirtable()
    {
        // Export current layout first
        var layout = await JSRuntime.ExportLayoutAsync();
        await GraphService.SaveLayoutAsync(_graphStack.Peek(), layout);
        
        // Force reload
        _cachedETag = null;
        await LoadGraphAsync(_graphStack.Peek());
    }
}
```

---

[← Node-Editor](node-editor.md)
1. **[Base](node-editor-00-base-index.md)** – what the editor is and how it works conceptually
2. **[Architecture](node-editor-12-arch-index.md)** – how the system is structured and implemented
3. **[UI](node-editor-26-ui-index.md)** – how users interact with the editor
4. **[Appendix](node-editor-39-appendix-index.md)** – technical details and references
5. **[Diagrams](node-editor-43-diagrams.md)** – flowcharts and other visual representations

---

