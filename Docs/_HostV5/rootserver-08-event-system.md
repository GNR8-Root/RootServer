# Event System

---

## Purpose

The event system enables **loose coupling** between components, services, and layers. Instead of direct method calls, components communicate through events, making the architecture flexible and testable.

---

## Core Event Types

### PointerEvent
Base event for UI interactions:

```csharp
public class PointerEvent
{
    public string PointerId { get; set; }
    public string TargetId { get; set; }
    public PointerEventType Type { get; set; }
}

public enum PointerEventType
{
    Click,
    Hover,
    Select,
    Deselect
}
```

### TableChangedEvent
Fired when table selection changes:

```csharp
public class TableChangedEvent
{
    public string TableId { get; set; }
    public string TableName { get; set; }
    public DateTime Timestamp { get; set; }
}
```

### RowChangedEvent
Fired when row selection changes:

```csharp
public class RowChangedEvent
{
    public string RowId { get; set; }
    public string TableId { get; set; }
    public Dictionary<string, object> Fields { get; set; }
}
```

---

## Event Service Pattern

Services act as event brokers:

### Pointer_Service

```csharp
public class Pointer_Service
{
    // Event declarations
    public event Action<string> OnTableChanged;
    public event Action<string> OnRowChanged;
    public event Action<string> OnFieldChanged;
    
    // Event raising methods
    public void NotifyTableChange(string tableId)
    {
        OnTableChanged?.Invoke(tableId);
    }
    
    public void NotifyRowChange(string rowId)
    {
        OnRowChanged?.Invoke(rowId);
    }
}
```

---

## Event Subscription Pattern

Components subscribe in `OnInitialized()`:

```csharp
@inject Pointer_Service PointerService

protected override void OnInitialized()
{
    // Subscribe to events
    PointerService.OnTableChanged += HandleTableChange;
    PointerService.OnRowChanged += HandleRowChange;
}

private void HandleTableChange(string tableId)
{
    // Update component state
    CurrentTableId = tableId;
    StateHasChanged();
}

public void Dispose()
{
    // Unsubscribe to prevent memory leaks
    PointerService.OnTableChanged -= HandleTableChange;
    PointerService.OnRowChanged -= HandleRowChange;
}
```

---

## Event Flow Examples

### Table Selection Flow

```text
User clicks P_Table
    ↓
P_Table calls PointerService.NotifyTableChange(tableId)
    ↓
PointerService raises OnTableChanged event
    ↓
W_Tables receives event → updates table list display
PNL_Structure receives event → updates structure panel
C_Rows receives event → loads rows for selected table
    ↓
All components call StateHasChanged()
    ↓
Blazor re-renders affected components
```

### Row Selection Flow

```text
User clicks P_Row
    ↓
P_Row calls PointerService.NotifyRowChange(rowId)
    ↓
PointerService raises OnRowChanged event
    ↓
C_RowSingle receives event → displays row details
C_InspectorHeader receives event → shows row metadata
A_RowBookmark receives event → updates bookmark status
    ↓
Components re-render with new row data
```

---

## Custom Event Implementation

### Define Event Args

```csharp
public class SectionChangedEventArgs : EventArgs
{
    public string SectionId { get; set; }
    public string SectionName { get; set; }
    public int SectionIndex { get; set; }
}
```

### Declare Event in Service

```csharp
public event EventHandler<SectionChangedEventArgs> OnSectionChanged;
```

### Raise Event

```csharp
protected virtual void RaiseSectionChanged(string sectionId, string name, int index)
{
    OnSectionChanged?.Invoke(this, new SectionChangedEventArgs
    {
        SectionId = sectionId,
        SectionName = name,
        SectionIndex = index
    });
}
```

### Subscribe to Event

```csharp
protected override void OnInitialized()
{
    sectionService.OnSectionChanged += HandleSectionChanged;
}

private void HandleSectionChanged(object sender, SectionChangedEventArgs e)
{
    CurrentSection = e.SectionName;
    StateHasChanged();
}
```

---

## Event Naming Conventions

- Use `On` prefix: `OnTableChanged`, `OnRowSelected`
- Use past tense for completed actions: `OnSyncCompleted`, `OnDataLoaded`
- Use present tense for ongoing actions: `OnSyncing`, `OnLoading`

---

## Error Handling in Events

### Safe Event Invocation

```csharp
public void SafeRaiseEvent(string data)
{
    try
    {
        OnDataChanged?.Invoke(data);
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "Error raising OnDataChanged event");
        // Don't re-throw to prevent one subscriber from breaking others
    }
}
```

### Subscriber Error Handling

```csharp
private void HandleEvent(string data)
{
    try
    {
        // Process event
        ProcessData(data);
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "Error handling event in component");
        // Handle gracefully
    }
}
```

---

## Performance Considerations

### Event Subscription Overhead
- Each subscription adds slight overhead
- Unsubscribe in `Dispose()` to prevent memory leaks
- Consider using weak event patterns for long-lived services

### Event Frequency
- Avoid raising events in tight loops
- Debounce high-frequency events (e.g., text input)
- Batch related changes when possible

---

## Future Event System Enhancements

### Planned Features
- Event aggregator for cross-layer communication
- Event history and replay for debugging
- Event filtering and routing
- Async event handlers
- Priority-based event delivery

---

---

**Navigation**

- **[← Data Flow](rootserver-07-data-flow.md)**
- **[Service Layer →](rootserver-09-service-layer.md)**
- **[Home](rootserver.md)**

---
