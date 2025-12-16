# Behavior Tree Validation

---

## **Validation Rules**

```csharp
public class GraphValidator
{
    public ValidationResult Validate(GraphSnapshot graph)
    {
        var errors = new List<ValidationError>();
        
        // Rule 1: Exactly one Root node
        var roots = graph.Nodes.Where(n => n.Type == NodeType.Root).ToList();
        if (roots.Count == 0)
            errors.Add(new ValidationError("MISSING_ROOT", "Graph must have exactly one Root node"));
        else if (roots.Count > 1)
            errors.Add(new ValidationError("MULTIPLE_ROOTS", $"Graph has {roots.Count} Root nodes"));
        
        // Rule 2: All nodes except Root must have FlowIn
        foreach (var node in graph.Nodes.Where(n => n.Type != NodeType.Root))
        {
            if (!node.Ports.ContainsKey("flowIn"))
                errors.Add(new ValidationError("MISSING_FLOW_IN", 
                    $"Node {node.Name} ({node.Type}) is missing FlowIn port", node.Id));
        }
        
        // Rule 3: Composites must have at least one child
        foreach (var composite in graph.Nodes.Where(n => 
            n.Type == NodeType.Sequence || n.Type == NodeType.Selector))
        {
            var children = graph.Edges.Count(e => 
                e.From == composite.Id && e.Kind == EdgeKind.Flow);
            
            if (children == 0)
                errors.Add(new ValidationError("EMPTY_COMPOSITE", 
                    $"Composite node {composite.Name} has no children", composite.Id));
        }
        
        // Rule 4: No cycles in flow graph
        if (HasCycles(graph, EdgeKind.Flow))
            errors.Add(new ValidationError("FLOW_CYCLE", "Flow edges contain a cycle"));
        
        // Rule 5: Data ports must match types
        foreach (var edge in graph.Edges.Where(e => e.Kind == EdgeKind.Data))
        {
            var fromNode = graph.Nodes.First(n => n.Id == edge.From);
            var toNode = graph.Nodes.First(n => n.Id == edge.To);
            
            var fromPort = fromNode.Ports[edge.FromPort];
            var toPort = toNode.Ports[edge.ToPort];
            
            if (!AreTypesCompatible(fromPort.Datatype, toPort.Datatype))
                errors.Add(new ValidationError("TYPE_MISMATCH", 
                    $"Cannot connect {fromPort.Datatype} to {toPort.Datatype}", edge.Id));
        }
        
        return new ValidationResult { Errors = errors, IsValid = errors.Count == 0 };
    }
    
    private bool HasCycles(GraphSnapshot graph, EdgeKind kind)
    {
        var edges = graph.Edges.Where(e => e.Kind == kind).ToList();
        var visited = new HashSet<string>();
        var recursionStack = new HashSet<string>();
        
        foreach (var node in graph.Nodes)
        {
            if (HasCycleDFS(node.Id, edges, visited, recursionStack))
                return true;
        }
        
        return false;
    }
}
```

**Visual Feedback:**
```javascript
// In Renderer.js
drawValidationErrors(errors) {
  errors.forEach(error => {
    if (error.nodeId) {
      const node = this.nodes.get(error.nodeId);
      const body = this.bodies.get(error.nodeId);
      
      // Red outline
      push();
      translate(body.position.x, body.position.y);
      stroke(255, 0, 0);
      strokeWeight(3);
      noFill();
      rect(-node.w/2, -node.h/2, node.w, node.h, 8);
      
      // Error icon
      fill(255, 0, 0);
      text('⚠', node.w/2 - 20, -node.h/2 + 16);
      pop();
    }
  });
  
  // Error panel
  if (errors.length > 0) {
    this.drawErrorPanel(errors);
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
