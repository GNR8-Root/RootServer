# Macro Nodes & Navigation

---

## **Macro Node Behavior**

**Visual Indicators:**
- Special icon (e.g., folder or nested squares)
- Badge showing child graph name
- Double-click hint tooltip
- Different header color gradient

**Data Requirements:**
```csharp
public class MacroNode : Node
{
    public string MacroGraphId { get; set; }
    public string? MacroGraphName { get; set; } // Cached for display
    public int? ChildNodeCount { get; set; } // Optional badge info
}
```

---

## **Navigation Stack Management**

```csharp
public class GraphNavigationService
{
    private Stack<GraphStackFrame> _stack = new();
    
    public async Task EnterMacro(string macroNodeId, string macroGraphId)
    {
        // Save current layout
        var layout = await _jsRuntime.ExportLayoutAsync();
        
        _stack.Push(new GraphStackFrame
        {
            GraphId = _currentGraphId,
            Layout = layout,
            ScrollPosition = await _jsRuntime.GetScrollPositionAsync()
        });
        
        // Load child graph
        await LoadGraphAsync(macroGraphId);
    }
    
    public async Task ExitMacro()
    {
        if (_stack.Count == 0) return;
        
        var frame = _stack.Pop();
        
        // Restore parent graph
        await LoadGraphAsync(frame.GraphId);
        await _jsRuntime.RestoreLayoutAsync(frame.Layout);
        await _jsRuntime.SetScrollPositionAsync(frame.ScrollPosition);
    }
    
    public async Task NavigateToLevel(int level)
    {
        while (_stack.Count > level)
        {
            await ExitMacro();
        }
    }
}

public class GraphStackFrame
{
    public string GraphId { get; set; }
    public Dictionary<string, Position> Layout { get; set; }
    public Position ScrollPosition { get; set; }
}
```

**Breadcrumb Component:**
```razor
<nav class="breadcrumbs">
    @for (int i = 0; i < Path.Count; i++)
    {
        var level = i;
        var item = Path[i];
        
        <span class="breadcrumb-item @(i == Path.Count - 1 ? "active" : "")"
              @onclick="() => OnNavigate.InvokeAsync(level)">
            @item.Name
        </span>
        
        @if (i < Path.Count - 1)
        {
            <span class="separator">›</span>
        }
    }
</nav>

<style>
.breadcrumbs {
    display: flex;
    align-items: center;
    gap: 8px;
    padding: 12px;
    background: #1a1a1a;
    border-bottom: 1px solid #333;
}

.breadcrumb-item {
    cursor: pointer;
    color: #888;
    transition: color 0.2s;
}

.breadcrumb-item:hover {
    color: #4A90E2;
}

.breadcrumb-item.active {
    color: #fff;
    font-weight: 600;
    cursor: default;
}
</style>
```

---

[← Node-Editor](node-editor.md)
1. **[Base](node-editor-00-base-index.md)** – what the editor is and how it works conceptually
2. **[Architecture](node-editor-12-arch-index.md)** – how the system is structured and implemented
3. **[UI](node-editor-26-ui-index.md)** – how users interact with the editor
4. **[Appendix](node-editor-39-appendix-index.md)** – technical details and references
5. **[Diagrams](node-editor-43-diagrams.md)** – flowcharts and other visual representations

---
