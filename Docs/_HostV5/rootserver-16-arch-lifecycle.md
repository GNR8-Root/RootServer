# Lifecycle Management

---

## Application Lifecycle

```text
Program.cs startup
    ↓
Service registration
    ↓
AirtableConfig.Initialize()
    ↓
Middleware pipeline
    ↓
Blazor circuit creation
    ↓
Component initialization
    ↓
User interactions
    ↓
Circuit disposal
```

---

## Component Lifecycle

Standard Blazor lifecycle:

- `OnInitialized` / `OnInitializedAsync`
- `OnParametersSet` / `OnParametersSetAsync`
- `OnAfterRender` / `OnAfterRenderAsync`
- `Dispose` (via `IDisposable`)

---

## Service Lifecycle

Scoped services:
- Created per user session
- Disposed when circuit closes
- Event subscriptions must be cleaned up

---

---

**Navigation**

- **[← Dependency Injection](rootserver-15-arch-di.md)**
- **[Integration Patterns →](rootserver-17-arch-integration.md)**
- **[Home](rootserver.md)**

---
