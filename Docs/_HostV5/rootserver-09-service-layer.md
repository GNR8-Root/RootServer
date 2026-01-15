# Service Layer

---

## Overview

Services provide **centralized state management** and **cross-component coordination**. They are registered in `Program.cs` and injected into components via dependency injection.

---

## Core Services

### Pointer_Service

Manages UI pointer state and selection events.

**Responsibilities:**
- Track current table, row, field selections
- Broadcast selection change events
- Maintain UI state across components

**Implementation:**

```csharp
public class Pointer_Service
{
    // State
    private string _currentTableId;
    private string _currentRowId;
    private string _currentFieldId;
    
    // Events
    public event Action<string> OnTableChanged;
    public event Action<string> OnRowChanged;
    public event Action<string> OnFieldChanged;
    
    // Methods
    public void SelectTable(string tableId)
    {
        _currentTableId = tableId;
        OnTableChanged?.Invoke(tableId);
    }
    
    public string GetCurrentTable() => _currentTableId;
}
```

---

### LogCatcher_Service

Centralized logging and diagnostics.

**Responsibilities:**
- Capture application logs
- Provide log history
- Support log filtering and search
- Export logs for debugging

**Implementation:**

```csharp
public class LogCatcher_Service
{
    private readonly List<LogEntry> _logs = new();
    
    public event Action<LogEntry> OnLogAdded;
    
    public void Log(string message, LogLevel level = LogLevel.Information)
    {
        var entry = new LogEntry
        {
            Timestamp = DateTime.UtcNow,
            Message = message,
            Level = level
        };
        
        _logs.Add(entry);
        OnLogAdded?.Invoke(entry);
    }
    
    public IReadOnlyList<LogEntry> GetLogs() => _logs.AsReadOnly();
}
```

---

### EditorView_Service

Manages editor workspace state.

**Responsibilities:**
- Track active editor view
- Manage view transitions
- Store view-specific settings

**Implementation:**

```csharp
public class EditorView_Service
{
    private string _activeView = "workspace";
    
    public event Action OnViewChanged;
    
    public void SwitchView(string viewName)
    {
        _activeView = viewName;
        OnViewChanged?.Invoke();
    }
    
    public string GetActiveView() => _activeView;
}
```

---

### EditorVisibility_Service

Controls editor UI visibility.

**Responsibilities:**
- Toggle editor panels
- Manage workspace layout
- Store visibility preferences

**Implementation:**

```csharp
public class EditorVisibility_Service
{
    private readonly Dictionary<string, bool> _visibility = new();
    
    public event Action OnVisibilityChanged;
    
    public void Toggle(string panelId)
    {
        if (_visibility.ContainsKey(panelId))
            _visibility[panelId] = !_visibility[panelId];
        else
            _visibility[panelId] = true;
            
        OnVisibilityChanged?.Invoke();
    }
    
    public bool IsVisible(string panelId) => 
        _visibility.TryGetValue(panelId, out var visible) && visible;
}
```

---

## Service Registration

Services are registered in `Program.cs`:

```csharp
// Scoped services (per-user session)
builder.Services.AddScoped<Pointer_Service>();
builder.Services.AddScoped<LogCatcher_Service>();
builder.Services.AddScoped<EditorView_Service>();
builder.Services.AddScoped<EditorVisibility_Service>();
```

### Service Lifetimes

- **Scoped** – One instance per user session (default for RootServer)
- **Singleton** – One instance for entire application (not used currently)
- **Transient** – New instance for each injection (not used currently)

---

## Service Injection

### Property Injection

```csharp
@inject Pointer_Service PointerService
@inject LogCatcher_Service Logger

// Or in code-behind:
[Inject] private Pointer_Service PointerService { get; set; }
```

### Constructor Injection

```csharp
public class MyComponent : ComponentBase
{
    private readonly Pointer_Service _pointerService;
    
    public MyComponent(Pointer_Service pointerService)
    {
        _pointerService = pointerService;
    }
}
```

---

## Service Communication Patterns

### Pub/Sub Pattern

```csharp
// Publisher (Service)
public class DataService
{
    public event Action<Data> OnDataUpdated;
    
    public void UpdateData(Data data)
    {
        // Process data
        OnDataUpdated?.Invoke(data);
    }
}

// Subscriber (Component)
protected override void OnInitialized()
{
    dataService.OnDataUpdated += HandleDataUpdate;
}

private void HandleDataUpdate(Data data)
{
    // React to update
    StateHasChanged();
}
```

### Request/Response Pattern

```csharp
// Service
public class QueryService
{
    public async Task<Result> ExecuteQueryAsync(string query)
    {
        // Execute query
        return result;
    }
}

// Component
private async Task HandleSearch(string query)
{
    var result = await queryService.ExecuteQueryAsync(query);
    // Update UI with result
}
```

---

## Service Best Practices

### State Management
- Keep service state minimal
- Use events for state change notifications
- Avoid storing UI-specific state in services

### Thread Safety
- Blazor Server is single-threaded per circuit
- No locking needed for typical scenarios
- Use `async/await` for long-running operations

### Memory Management
- Unsubscribe from events in `Dispose()`
- Clear large collections when appropriate
- Avoid circular references

---

## Future Service Enhancements

### Planned Services
- **AuthService** – User authentication and authorization
- **CacheService** – Intelligent caching layer
- **SyncService** – Background data synchronization
- **ThemeService** – Dynamic theme management
- **NavigationService** – Programmatic navigation

---

---

**Navigation**

- **[← Event System](rootserver-08-event-system.md)**
- **[Configuration →](rootserver-10-configuration.md)**
- **[Home](rootserver.md)**

---
