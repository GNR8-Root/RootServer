
# Performance Optimization

---

## **Rendering Optimizations**

**Viewport Culling:**
```javascript
draw() {
  const viewport = this.getViewport();
  const visibleNodes = this.getNodesInViewport(viewport);
  
  // Only draw visible nodes and their edges
  visibleNodes.forEach(node => {
    this.drawNode(node);
    this.drawNodePorts(node);
  });
  
  const visibleEdges = this.getEdgesForNodes(visibleNodes);
  visibleEdges.forEach(edge => this.drawEdge(edge));
}

getViewport() {
  return {
    x: this.camera.x - width / 2,
    y: this.camera.y - height / 2,
    w: width,
    h: height
  };
}
```

**Dirty Region Tracking:**
```javascript
class DirtyRegionTracker {
  constructor() {
    this.regions = [];
  }
  
  markDirty(x, y, w, h) {
    this.regions.push({ x, y, w, h });
  }
  
  clear() {
    this.regions = [];
  }
  
  needsRedraw(nodeBox) {
    return this.regions.some(r => boxesIntersect(r, nodeBox));
  }
}
```

**Physics Sleeping:**
```javascript
// In PhysicsWorld
updateNodeStates() {
  this.bodies.forEach((body, nodeId) => {
    const velocity = Matter.Body.getVelocity(body);
    const speed = Math.sqrt(velocity.x ** 2 + velocity.y ** 2);
    
    if (speed < 0.01) {
      Matter.Sleeping.set(body, true);
    }
  });
}
```

---

## **Data Loading Optimizations**

**Progressive Loading:**
```csharp
public async Task<GraphSnapshot> BuildSnapshotProgressiveAsync(
    string graphId, 
    IProgress<LoadingProgress> progress)
{
    progress.Report(new LoadingProgress { Stage = "Loading graph metadata", Percent = 10 });
    var graph = await _airtable.GetGraphAsync(graphId);
    
    progress.Report(new LoadingProgress { Stage = "Loading nodes", Percent = 30 });
    var nodes = await _airtable.GetNodesAsync(graphId);
    
    progress.Report(new LoadingProgress { Stage = "Loading edges", Percent = 60 });
    var edges = await _airtable.GetEdgesAsync(graphId);
    
    progress.Report(new LoadingProgress { Stage = "Building snapshot", Percent = 80 });
    var snapshot = BuildSnapshot(graph, nodes, edges);
    
    progress.Report(new LoadingProgress { Stage = "Complete", Percent = 100 });
    return snapshot;
}
```

**Caching Strategy:**
```csharp
public class GraphCache
{
    private readonly MemoryCache _cache;
    private readonly TimeSpan _expiration = TimeSpan.FromMinutes(5);
    
    public async Task<GraphSnapshot> GetOrLoadAsync(
        string graphId, 
        Func<Task<GraphSnapshot>> loader)
    {
        if (_cache.TryGetValue(graphId, out GraphSnapshot cached))
        {
            return cached;
        }
        
        var snapshot = await loader();
        _cache.Set(graphId, snapshot, _expiration);
        return snapshot;
    }
    
    public void Invalidate(string graphId)
    {
        _cache.Remove(graphId);
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
