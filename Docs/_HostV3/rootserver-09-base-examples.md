# Base Examples

---

## Common Workflows

### 1. Adding a New Field Component

```csharp
// 1. Create field component in Shared/_Core/02_Fields/
public partial class F_Text_NewType : FieldBase_String
{
    // Implementation
}

// 2. Add to field registry (if dynamic instantiation used)
// 3. Use in schema-driven rendering
```

### 2. Creating a New Plugin

```
1. Create folder: Shared/Plugins/MyPlugin/
2. Implement needed layers (03_Pointers, 04_Actions, etc.)
3. Add initialization in Program.cs
4. Register services if needed
```

### 3. Extending the Editor

```
1. Add components in Shared/_Editor/
2. Wire to EditorView_Service for state
3. Add to editor layout
```

---

## Extension Patterns

### Service-Based State
```csharp
@inject Pointer_Service Pointer

// Read state
var currentTable = Pointer.CurrentTable;

// Update state (triggers subscribers)
Pointer.SelectTable(newTable);
```

### Layer-Based Components
```csharp
// Lower layers (02_Fields)
public partial class F_MyField : FieldBase { }

// Compose in higher layers (06_Components)
<C_MyComponent>
    <F_MyField />
</C_MyComponent>
```

---

## Common Pitfalls

1. **Host → Plugin coupling:** Avoid direct dependencies in Program.cs
2. **Layer violations:** Don't reference higher layers from lower layers
3. **State synchronization:** Use services, not component parameters
4. **Missing base classes:** Extend appropriate base class for layer
5. **Duplicate JSON files:** Be aware of camelCase/PascalCase naming issue

---

[← Back to Base Index](rootserver-00-base-index.md)

---
