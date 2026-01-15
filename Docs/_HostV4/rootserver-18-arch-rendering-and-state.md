# Rendering and State

---

## Component Rendering

### Blazor Rendering Model

1. **Initial Render:** Component tree rendered on server
2. **DOM Diff:** Changes calculated
3. **SignalR Push:** Updates sent to browser
4. **Client DOM Update:** Browser applies changes

---

## State Containers

### Scoped Services as State

RootServer uses scoped services as state containers:

**Pointer_Service:**
```csharp
public class Pointer_Service
{
    public Workspace CurrentWorkspace { get; private set; }
    public Table CurrentTable { get; private set; }
    public Row CurrentRow { get; private set; }
    public Field CurrentField { get; private set; }
    
    public event Action OnSelectionChanged;
    
    public void SelectTable(Table table)
    {
        CurrentTable = table;
        OnSelectionChanged?.Invoke();
    }
}
```

**Benefits:**
- Centralized state
- Event-driven updates
- Loose coupling

---

## Re-render Triggers

Components re-render when:
1. **Parameters change:** Parent passes new parameter values
2. **StateHasChanged() called:** Manual trigger
3. **Service event:** Subscribed service raises event

---

## Async Patterns

```csharp
protected override async Task OnInitializedAsync()
{
    await LoadDataAsync();
}

private async Task LoadDataAsync()
{
    // Async data loading
}
```

---

[← Back to Architecture Index](rootserver-12-arch-index.md)

---
