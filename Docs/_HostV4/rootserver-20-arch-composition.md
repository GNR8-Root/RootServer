# Composition

---

## Plugin Composition Model

### Current Implementation

Plugins register during startup:
```csharp
// Program.cs
AirtableConfig.Initialize(builder.Configuration);
```

### Limitations

- Compile-time composition
- No dynamic loading
- Host coupled to plugin initialization

---

## Module Wiring (Planned)

**Infrastructure exists** in `Shared/_Modules/` but minimal implementation.

**Intended Pattern:**
```
Host → Modules (shared services) → Plugins
```

Where modules provide cross-cutting concerns consumed by multiple plugins.

---

## Extension Points

### Service Injection

Plugins can inject host services:
```csharp
@inject Pointer_Service Pointer
@inject EditorView_Service EditorView
```

### Base Class Extension

Plugins extend base classes:
```csharp
public partial class P_MyPointer : PointerBase
{
    // Plugin-specific pointer
}
```

### Layer Subset Implementation

Plugins implement only needed layers:
- Airtable: 03, 04, 06, 09
- Future plugins may use different subsets

---

## Node System (Planned)

**05_Nodes folder exists** but minimal implementation.

**Vision:** Plugin-to-plugin communication via node graph
```
Plugin A → Node → Plugin B
```

Enables:
- Event-driven integration
- Decoupled plugin communication
- Workflow composition

---

[← Back to Architecture Index](rootserver-12-arch-index.md)

---
