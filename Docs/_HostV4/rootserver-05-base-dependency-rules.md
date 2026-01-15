# Base Dependency Rules

---

## Dependency Graph

RootServer follows a layered dependency model where higher-level components depend on lower-level services and base classes.

### Allowed References

- **`Plugins`** → Host services, Module services, _Core base classes
- **`Modules`** → Host services, _Core base classes  
- **_`Editor`** → _Core services and base classes
- **_`Sites`** → _Core base classes
- **`All layers`** → .NET BCL, Blazorise, external packages

### Forbidden References

- **`Host`** → Plugin internals (Host should not know about specific plugins)
- **`Lower layers`** → Higher layers (00_Core should not reference 09_Panels)
- **`Plugins`** → Other plugins directly (use shared services or future node system)

---

## Current Dependency Patterns

### Program.cs Dependencies

```csharp
// Host references services
builder.Services.AddScoped<Pointer_Service>();
builder.Services.AddScoped<LogCatcher_Service>();
builder.Services.AddScoped<EditorView_Service>();
builder.Services.AddScoped<EditorVisibility_Service>();

// Blazorise registration
builder.Services.AddBlazorise(...).AddTailwindProviders().AddFontAwesomeIcons();

// Plugin initialization (configuration, not type dependency)
AirtableConfig.Initialize(builder.Configuration);
```

---

## Plugin Isolation Principle

**Goal:** Host should provide extension points without coupling to plugin implementations.

**Current State:** Partial compliance. `AirtableConfig.Initialize()` is a configuration method but represents a coupling point.

**Recommended:** Use plugin discovery pattern:
```csharp
// Future approach
var pluginLoader = new PluginLoader();
pluginLoader.DiscoverPlugins();
pluginLoader.InitializeAll(builder.Services, builder.Configuration);
```

---

[← Back to Base Index](rootserver-00-base-index.md)

---
