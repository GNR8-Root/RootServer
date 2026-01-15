# Dependency Injection

---

## Service Registration

Services registered in `Program.cs`:

```csharp
builder.Services.AddScoped<Pointer_Service>();
builder.Services.AddScoped<LogCatcher_Service>();
builder.Services.AddScoped<EditorView_Service>();
builder.Services.AddScoped<EditorVisibility_Service>();
```

---

## Injection Methods

### Property Injection (Razor)
```razor
@inject Pointer_Service PointerService
```

### Constructor Injection (C#)
```csharp
public MyService(Pointer_Service pointerService)
{
    _pointerService = pointerService;
}
```

---

## Service Lifetimes

- **Scoped**: One per user session (current approach)
- **Singleton**: One per application (not used)
- **Transient**: New per injection (not used)

---

---

**Navigation**

- **[← Plugin Architecture](rootserver-14-arch-plugins.md)**
- **[Lifecycle Management →](rootserver-16-arch-lifecycle.md)**
- **[Home](rootserver.md)**

---
