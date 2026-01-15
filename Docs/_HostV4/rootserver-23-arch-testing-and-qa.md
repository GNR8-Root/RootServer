# Testing and QA

---

## Current State

**Test Projects:** None found in repository

**CI/CD:** No evidence of automated testing or deployment pipelines `.github not fed to the llm`

---

## Recommended Testing Strategy

### Unit Testing

**Target:** Service logic, base classes, utility methods

```csharp
[Fact]
public void Pointer_Service_Should_Update_Selection()
{
    var service = new Pointer_Service();
    var table = new Table { Id = "tbl123" };
    
    service.SelectTable(table);
    
    Assert.Equal("tbl123", service.CurrentTable.Id);
}
```

**Tools:** xUnit, NUnit, or MSTest

---

### Component Testing

**Target:** Blazor components

```csharp
[Fact]
public void F_Text_Email_Should_Validate_Email()
{
    using var ctx = new TestContext();
    var component = ctx.RenderComponent<F_Text_Email>();
    
    component.Instance.Value = "invalid";
    Assert.False(component.Instance.IsValid);
    
    component.Instance.Value = "test@example.com";
    Assert.True(component.Instance.IsValid);
}
```

**Tools:** bUnit (Blazor component testing library)

---

### Integration Testing

**Target:** Airtable sync, JSON file operations

```csharp
[Fact]
public async Task Airtable_Sync_Should_Update_JSON()
{
    var sync = new A_AirtableSync();
    await sync.ExecuteAsync();
    
    var jsonPath = Path.Combine("Json", "tables.json");
    Assert.True(File.Exists(jsonPath));
}
```

---

### End-to-End Testing

**Target:** Full user workflows

**Tools:** Playwright, Selenium

```csharp
[Fact]
public async Task User_Can_Select_Table()
{
    await Page.GotoAsync("http://localhost:5000/editor");
    await Page.ClickAsync("text=Tables");
    await Page.ClickAsync("text=MyTable");
    
    var selected = await Page.TextContentAsync(".selected-table");
    Assert.Equal("MyTable", selected);
}
```

---

## Quality Gates

### Recommended CI/CD Pipeline

```yaml
steps:
  - checkout
  - restore dependencies
  - build
  - run unit tests
  - run component tests
  - run integration tests
  - publish artifacts
```

---

## Test Coverage Goals

- **Unit tests:** 70%+ coverage
- **Component tests:** All public components
- **Integration tests:** Critical paths (sync, selection)
- **E2E tests:** Main user workflows

---

[← Back to Architecture Index](rootserver-12-arch-index.md)

---
