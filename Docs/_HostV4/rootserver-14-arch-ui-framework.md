# UI Framework Architecture

---

## Blazor Server

RootServer uses **Blazor Server** rendering model:

- **Server-side rendering:** Components render on server
- **SignalR connection:** DOM updates sent over WebSocket
- **Circuit per user:** One connection per user session
- **Scoped services:** Per-circuit state isolation

---

## Rendering Lifecycle

```
+------------------+   +-------------------------+    +-------------------------------+
|   User Request   |-->|  SignalR Circuit Created |-->|  Scoped Services Instantiated |
+------------------+   +-------------------------+    |  (DI scope for the circuit)   |
                                                      +-------------------------------+
                                                                  |
                                                                  v
+------------------------------+   +-------------------------+   +---------------------------------+
|     Component Tree Rendered  |-->|   Initial HTML Sent     |-->|  SignalR Connection Established |
+------------------------------+   +-------------------------+   +---------------------------------+
                                                                  |
                                                                  v
+--------------------------------------------------------------------+
|                     Interactive Updates via                        |
|                     SignalR (events, renders)                      |
+--------------------------------------------------------------------+
               |
               v
+------------------+   +--------------------+   +---------------------------+
| User Disconnects |-->| Circuit Terminated |-->| Services Disposed (scope) |
+------------------+   +--------------------+   +---------------------------+

```

---

## Component Patterns

### Service Injection
```csharp
@inject Pointer_Service Pointer
@inject EditorView_Service EditorView

// Use in code-behind
protected override void OnInitialized()
{
    Pointer.OnSelectionChanged += HandleSelectionChange;
}
```

### Event-Driven Updates
```csharp
// Service raises event
public event Action OnSelectionChanged;

// Components subscribe
Pointer.OnSelectionChanged += StateHasChanged;
```

---

## Performance Characteristics

**Pros:**
- No JavaScript framework weight
- Server-side state management
- Strong typing throughout

**Cons:**
- Requires persistent connection
- Network latency for interactions
- Server memory per user

---

[← Back to Architecture Index](rootserver-12-arch-index.md)

---
