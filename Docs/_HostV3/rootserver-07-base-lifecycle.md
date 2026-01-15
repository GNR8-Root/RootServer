# Base Lifecycle

---

## Service Lifecycle

Services registered in Program.cs follow Blazor Server scoped lifetime:

### Activation

1. User connects to Blazor Server application
2. SignalR circuit established
3. Scoped services instantiated:
   - Pointer_Service
   - LogCatcher_Service
   - EditorView_Service
   - EditorVisibility_Service
4. Services remain active for circuit lifetime

### Deactivation

1. User disconnects or closes browser
2. Circuit terminated
3. Scoped services disposed
4. State cleared

**Note:** No explicit unload mechanism exists in current implementation.

---

## Component Lifecycle

Standard Blazor component lifecycle applies:

```csharp
OnInitialized() → OnParametersSet() → Render → OnAfterRender() → Dispose()
```

Components can inject services:
```csharp
@inject Pointer_Service Pointer
@inject EditorView_Service EditorView
```

---

## Plugin Lifecycle

**Current State:** Plugins initialized during startup via configuration methods (e.g., `AirtableConfig.Initialize()`).

**No dynamic loading:** Plugins are compiled into the host; no runtime load/unload capability.

**Future Enhancement:** Implement plugin discovery and dynamic loading for true plugin architecture.

---

[← Back to Base Index](rootserver-00-base-index.md)

---
