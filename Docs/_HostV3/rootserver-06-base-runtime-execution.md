# Base Runtime Execution

---

## Program.cs Bootstrap

RootServer follows standard Blazor Server startup pattern with service registration and middleware configuration.

### Startup Sequence

```csharp
// 1. Create builder
var builder = WebApplication.CreateBuilder(args);

// 2. Add Blazor services
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// 3. Register app services
builder.Services.AddScoped<Pointer_Service>();
builder.Services.AddScoped<LogCatcher_Service>();
builder.Services.AddScoped<EditorView_Service>();
builder.Services.AddScoped<EditorVisibility_Service>();

// 4. Add Blazorise + Tailwind
builder.Services
    .AddBlazorise(options => { options.Immediate = true; })
    .AddTailwindProviders()
    .AddFontAwesomeIcons();

// 5. Build app
var app = builder.Build();

// 6. Configure middleware pipeline
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();

// 7. Initialize Airtable
AirtableConfig.Initialize(builder.Configuration);

// 8. Configure routing
app.UseStaticFiles();
app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

// 9. Run
app.Run();
```

---

## Service Lifetime Patterns

All app services use **Scoped** lifetime:

| Service | Lifetime | Rationale |
|---------|----------|-----------|
| Pointer_Service | Scoped | Per-user selection state |
| LogCatcher_Service | Scoped | Per-user log capture |
| EditorView_Service | Scoped | Per-user editor state |
| EditorVisibility_Service | Scoped | Per-user visibility state |

**Why Scoped?** Blazor Server uses one SignalR connection per user. Scoped services are created per circuit, providing isolated state per user session.

---

## Blazor Server Rendering Model

- **Server-side rendering:** Components render on server, DOM updates sent via SignalR
- **Circuit:** One SignalR connection per user session
- **State management:** Scoped services persist for circuit lifetime
- **Component lifecycle:** OnInitialized → OnParametersSet → Render → Dispose

---

[← Back to Base Index](rootserver-00-base-index.md)

---
