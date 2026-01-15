# Streaming Updates

---

## **Polling Strategy**

**Configuration:**
```csharp
public class StreamingConfig
{
    public int PollingIntervalSeconds { get; set; } = 5;
    public bool AutoApplyWhenClean { get; set; } = true;
    public bool ShowBannerWhenDirty { get; set; } = true;
}
```

**Implementation:**
```csharp
private Timer? _pollingTimer;
private string? _lastKnownETag;
private bool _hasLocalChanges;

private void StartStreamingUpdates()
{
    _pollingTimer = new Timer(async _ => await CheckForUpdates(), 
        null, 
        TimeSpan.FromSeconds(5), 
        TimeSpan.FromSeconds(5));
}

private async Task CheckForUpdates()
{
    try
    {
        var response = await GraphService.GetGraphVersionAsync(
            _graphStack.Peek(), 
            ifNoneMatch: _lastKnownETag);
        
        if (response.NotModified)
        {
            return; // No changes
        }
        
        _lastKnownETag = response.ETag;
        
        // Decide whether to auto-apply
        if (_hasLocalChanges)
        {
            _hasRemoteChanges = true;
            await InvokeAsync(StateHasChanged);
        }
        else
        {
            await ApplyRemoteChanges();
        }
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Streaming update check failed");
    }
}

private async Task ApplyRemoteChanges()
{
    var snapshot = await GraphService.BuildSnapshotAsync(_graphStack.Peek());
    
    // Compute diff (optional optimization)
    var currentLayout = await JSRuntime.ExportLayoutAsync();
    var patch = ComputePatch(snapshot, currentLayout);
    
    if (patch.IsFullReload)
    {
        await JSRuntime.LoadGraphAsync(snapshot);
    }
    else
    {
        await JSRuntime.ApplyPatchAsync(patch);
    }
    
    _hasRemoteChanges = false;
    StateHasChanged();
}
```

---

## **Patch Format (Incremental Updates)**

```typescript
interface GraphPatch {
  graphId: string;
  version: number;
  
  addedNodes?: SnapshotNode[];
  updatedNodes?: Partial<SnapshotNode>[]; // Only changed fields
  removedNodes?: string[];
  
  addedEdges?: SnapshotEdge[];
  updatedEdges?: Partial<SnapshotEdge>[];
  removedEdges?: string[];
  
  preserveLayout?: string[]; // Node IDs to keep positions
}
```

**JS Handler:**
```javascript
applyPatch(patch) {
  // Remove deleted nodes/edges first
  patch.removedEdges?.forEach(id => this.removeEdge(id));
  patch.removedNodes?.forEach(id => this.removeNode(id));
  
  // Add new nodes/edges
  patch.addedNodes?.forEach(node => this.addNode(node));
  patch.addedEdges?.forEach(edge => this.addEdge(edge));
  
  // Update existing (merge properties)
  patch.updatedNodes?.forEach(update => {
    const node = this.nodes.get(update.id);
    Object.assign(node, update);
    
    // Update physics body if position changed
    if (update.x !== undefined || update.y !== undefined) {
      const body = this.bodies.get(update.id);
      Matter.Body.setPosition(body, { 
        x: update.x ?? node.x, 
        y: update.y ?? node.y 
      });
    }
  });
  
  // Rebuild affected constraints
  this.rebuildConstraints(patch.addedEdges, patch.updatedEdges);
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

