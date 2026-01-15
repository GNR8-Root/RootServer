
# Testing Strategy

---

## **Unit Tests**

```csharp
[Fact]
public void GraphValidator_EmptyGraph_ReturnsError()
{
    var snapshot = new GraphSnapshot { Nodes = new List<Node>(), Edges = new List<Edge>() };
    var validator = new GraphValidator();
    
    var result = validator.Validate(snapshot);
    
    Assert.False(result.IsValid);
    Assert.Contains(result.Errors, e => e.Code == "MISSING_ROOT");
}

[Fact]
public async Task GraphService_BuildSnapshot_NormalizesCorrectly()
{
    var mockAirtable = new Mock<IAirtableService>();
    mockAirtable.Setup(a => a.GetGraphAsync("g1"))
        .ReturnsAsync(new Graph { GraphId = "g1", Name = "Test" });
    
    var service = new GraphService(mockAirtable.Object);
    var snapshot = await service.BuildSnapshotAsync("g1");
    
    Assert.Equal("g1", snapshot.GraphId);
    Assert.NotNull(snapshot.Nodes);
}
```

---

## **Integration Tests**

```csharp
[Fact]
public async Task EndToEnd_LoadGraph_RendersCorrectly()
{
    using var host = await CreateTestHost();
    var page = await host.Page;
    
    await page.GotoAsync("/editor/test-graph");
    await page.WaitForSelectorAsync(".editor-canvas");
    
    var nodeCount = await page.EvalOnSelectorAsync<int>(
        ".editor-canvas", 
        "el => el.querySelectorAll('.node').length"
    );
    
    Assert.Equal(5, nodeCount);
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
