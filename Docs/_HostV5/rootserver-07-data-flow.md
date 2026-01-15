# Data Flow

---

## Data Flow Overview

```text
Airtable API (External Source)
    ↓
JSON Cache (Json/ folder)
    ↓
AirtableConfig (Initialization)
    ↓
Table Models (C# POCOs)
    ↓
Services (State Management)
    ↓
Components (UI Rendering)
    ↓
User Interactions
    ↓
Events → Services → Components (Loop)
```

---

## Airtable to Application

### Step 1: Data Fetch
Editor triggers sync via `A_AirtableSync` action:

```csharp
// Simplified sync process
public async Task SyncFromAirtable()
{
    var tables = await airtableClient.GetTablesAsync();
    
    foreach (var table in tables)
    {
        var records = await table.GetRecordsAsync();
        var json = SerializeRecords(records);
        await File.WriteAllTextAsync($"Json/{table.Name}.json", json);
    }
}
```

### Step 2: JSON Caching
Data saved to `Json/` folder as individual table files:
- `pages.json`
- `sections.json`
- `agenda.json`
- etc.

### Step 3: Application Initialization
On startup, `AirtableConfig.Initialize()` loads cached data:

```csharp
public static void Initialize(IConfiguration configuration)
{
    // Load API credentials
    ApiKey = configuration["Airtable:ApiKey"];
    BaseId = configuration["Airtable:BaseId"];
    
    // Load cached JSON data
    LoadCachedTables();
}
```

---

## Data Transformation

### JSON to C# Models

```csharp
// Example: Gallery table model
public class GalleryRecord
{
    public string Id { get; set; }
    public string Title { get; set; }
    public List<string> Images { get; set; }
    public string Filter { get; set; }
}

// Deserialization
var json = File.ReadAllText("Json/gallery.json");
var galleries = JsonSerializer.Deserialize<List<GalleryRecord>>(json);
```

### Type Mapping
`Airtable` field types map to C# types:
- Text → `string`
- Number → `int` / `double`
- Checkbox → `bool`
- Multiple select → `List<string>`
- Linked records → `List<string>` (record IDs)
- Attachments → `List<Attachment>`

---

## Service-Driven State

Services manage application state and broadcast changes:

### Pointer_Service
Manages UI state (selected table, row, field):

```csharp
public class Pointer_Service
{
    public event Action<string> OnTableChanged;
    public event Action<string> OnRowChanged;
    
    private string currentTable;
    
    public void SelectTable(string tableId)
    {
        currentTable = tableId;
        OnTableChanged?.Invoke(tableId);
    }
}
```

### EditorView_Service
Manages editor workspace state:

```csharp
public class EditorView_Service
{
    public event Action OnViewChanged;
    
    private string activeView;
    
    public void SwitchView(string viewName)
    {
        activeView = viewName;
        OnViewChanged?.Invoke();
    }
}
```

---

## Component Data Binding

### One-Way Binding (Service → Component)

```csharp
@inject Pointer_Service PointerService

private string currentTable;

protected override void OnInitialized()
{
    PointerService.OnTableChanged += (tableId) => {
        currentTable = tableId;
        StateHasChanged();
    };
}
```

### Two-Way Binding (Component ↔ Service)

```csharp
// Component reads and writes to service
private void HandleTableSelect(string tableId)
{
    PointerService.SelectTable(tableId); // Writes to service
    // Service broadcasts change
    // Other components receive update
}
```

---

## Event Propagation

### Event Flow Example

```text
User clicks P_Table button
    ↓
P_Table.OnClick() fires
    ↓
PointerService.SelectTable(tableId) called
    ↓
OnTableChanged event raised
    ↓
W_Tables receives event
    ↓
W_Tables.StateHasChanged() triggers re-render
    ↓
UI updates to show selected table
```

### Custom Events

```csharp
// Define custom event
public event Action<TableSelectedEventArgs> OnTableSelected;

// Raise event
OnTableSelected?.Invoke(new TableSelectedEventArgs { TableId = id });

// Subscribe to event
service.OnTableSelected += (args) => {
    // Handle event
};
```

---

## Data Mutation

### Read Operations
Most operations are read-only from cached JSON:

```csharp
var pages = LoadPages(); // Read from Json/pages.json
var sections = LoadSections(); // Read from Json/sections.json
```

### Write Operations (Planned)
Future support for writing back to `Airtable`:

```csharp
// Not yet implemented
public async Task UpdateRecord(string tableId, string recordId, object fields)
{
    await airtableClient.UpdateAsync(tableId, recordId, fields);
    await SyncFromAirtable(); // Re-sync cache
}
```

---

## Caching Strategy

### Cache-First Approach
Application always reads from local JSON cache, never directly from `Airtable API` at runtime.

Benefits:
- Fast load times
- Offline capability
- Reduced API calls
- Predictable performance

Trade-offs:
- Manual sync required
- Potential for stale data
- No real-time updates

---

## Schema Evolution

### Adding New Fields

1. Update `Airtable` schema (add field to table)
2. Sync data in Editor (fetches updated schema)
3. Update C# model (add property to class)
4. Update UI components (reference new field)
5. Deploy changes

### Removing Fields

1. Update C# model (remove property)
2. Update UI components (remove references)
3. Deploy changes
4. Remove field from `Airtable` (optional)

---

## Future Data Flow Enhancements

### Planned Improvements
- Real-time sync via `SignalR`
- Bidirectional updates (write to `Airtable`)
- Schema auto-generation from `Airtable` metadata
- Conflict resolution for concurrent edits
- `CosmosDB` backing store for schema definitions

---

---

**Navigation**

- **[← Component Model](rootserver-06-component-model.md)**
- **[Event System →](rootserver-08-event-system.md)**
- **[Home](rootserver.md)**

---
