# Airtable Integration

---

## Integration Overview

Airtable serves as the external schema store and data source.

---

## Data Flow

```text
Airtable API
    ↓
HTTP Request (via Airtable SDK)
    ↓
JSON Response
    ↓
Transform to C# Models
    ↓
Serialize to JSON Files
    ↓
Cache in Json/ Folder
    ↓
Load at Runtime
    ↓
Render UI
```

---

## Table Models

Located in `Shared/Plugins/Airtable/00_Core/Tables/`:

### Example: MediaImage Table

```csharp
public class MediaImageRecord
{
    public string Id { get; set; }
    public string Name { get; set; }
    public List<Attachment> Image { get; set; }
    public string AltText { get; set; }
}

public class Attachment
{
    public string Id { get; set; }
    public string Url { get; set; }
    public string Filename { get; set; }
    public long Size { get; set; }
    public string Type { get; set; }
}
```

---

## Sync Process

### Editor Sync Action

User triggers sync via `A_AirtableSync` component in Editor interface.

### Steps:
1. Initialize Airtable client with API key
2. Fetch tables from base
3. For each table, fetch all records
4. Transform records to C# models
5. Serialize to JSON
6. Write to `Json/` folder
7. Log sync completion

---

## Field Type Mapping

| Airtable Type | C# Type |
|---------------|---------|
| Text | `string` |
| Number | `int` / `double` |
| Checkbox | `bool` |
| Select | `string` |
| Multiple Select | `List<string>` |
| Linked Records | `List<string>` (IDs) |
| Attachments | `List<Attachment>` |
| Date | `DateTime` |

---

## Caching Strategy

### Cache-First Approach
- Application never queries Airtable API at runtime
- Always reads from local JSON cache
- Manual sync required to update cache

### Benefits:
- Fast load times
- Offline capability
- Reduced API costs
- Predictable performance

### Trade-offs:
- Manual sync requirement
- Potential stale data
- No real-time updates

---

## Future Enhancements

### Planned Features:
- **Bidirectional Sync**: Write changes back to Airtable
- **Real-time Updates**: SignalR for live data
- **Schema Introspection**: Auto-generate C# models from Airtable schema
- **Conflict Resolution**: Handle concurrent edits
- **Delta Sync**: Only fetch changed records

---

---

**Navigation**

- **[← Integration Patterns](rootserver-17-arch-integration.md)**
- **[Caching Strategy →](rootserver-19-arch-caching.md)**
- **[Home](rootserver.md)**

---
