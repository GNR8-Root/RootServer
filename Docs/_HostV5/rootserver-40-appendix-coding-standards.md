# Coding Standards

---

## Naming Conventions

### Files
- Components: `PascalCase` with prefix (`P_TableSelector.razor`)
- Services: `PascalCase` with `_Service` suffix (`Pointer_Service`)
- Models: `PascalCase` with `Record` suffix (`GalleryRecord`)

### Classes and Methods
- Classes: `PascalCase`
- Methods: `PascalCase`
- Private fields: `_camelCase`
- Parameters: `camelCase`
- Constants: `UPPER_SNAKE_CASE`

---

## Code Organization

### File Structure
```csharp
// 1. Usings
using System;
using Microsoft.AspNetCore.Components;

// 2. Namespace
namespace RootServer.Shared._Core;

// 3. Class definition
public class MyComponent : ComponentBase
{
    // 4. Fields
    private string _data;
    
    // 5. Properties
    [Parameter] public string Title { get; set; }
    
    // 6. Lifecycle methods
    protected override void OnInitialized() { }
    
    // 7. Event handlers
    private void HandleClick() { }
    
    // 8. Helper methods
    private void ProcessData() { }
}
```

---

## Component Patterns

### Wrapper + Base
Use for complex components with distinct layout and logic concerns.

### Code-Behind
Use for components with substantial C# logic.

### Single-File
Use for simple presentation components.

---

## Async/Await

Always use async methods for:
- API calls
- File I/O
- Database operations

```csharp
protected override async Task OnInitializedAsync()
{
    data = await LoadDataAsync();
}
```

---

## Error Handling

Always wrap risky operations:

```csharp
try
{
    await RiskyOperationAsync();
}
catch (Exception ex)
{
    logger.LogError(ex, "Operation failed");
    // Handle gracefully
}
```

---

## Comments

### When to Comment
- Complex algorithms
- Non-obvious business logic
- Public API documentation

### When NOT to Comment
- Obvious code
- Redundant descriptions
- Dead code (delete instead)

---

---

**Navigation**

- **[← Sites Framework](rootserver-38-ui-sites.md)**
- **[Code Quality Policy →](rootserver-41-appendix-code-quality-policy.md)**
- **[Home](rootserver.md)**

---
