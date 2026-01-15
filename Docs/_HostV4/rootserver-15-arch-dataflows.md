# Data Flows

---

## Primary Data Flow: Airtable → JSON → UI

```
Airtable API → A_AirtableSync → JSON Cache → Schema Parser → Component Tree → Rendered UI
```

### Steps

1. **Sync Action:** User triggers `A_AirtableSync` in editor
2. **API Call:** Airtable API fetched for schemas/data
3. **JSON Write:** Response written to Json/ folder
4. **Cache Read:** Components read from JSON cache
5. **Schema Parse:** JSON deserialized to strongly-typed models
6. **UI Generation:** Components instantiated based on schema
7. **Render:** Blazor renders component tree

---

## State Propagation Flow

```
User Interaction → Component Event → Service Update → Service Event Raised →
Subscribed Components Notified → StateHasChanged() → Re-render
```

### Example: Table Selection

```
1. User clicks table in P_Table pointer
2. P_Table calls Pointer.SelectTable(table)
3. Pointer_Service updates CurrentTable property
4. Pointer_Service raises OnSelectionChanged event
5. All subscribed components receive notification
6. Components call StateHasChanged()
7. Blazor re-renders affected components
```

---

## Caching Strategy

**Local JSON Cache:**
- Enables offline development
- Reduces API calls
- Fast local reads

**No runtime caching:** Components read JSON on-demand; no in-memory cache layer.

**Recommendation:** Implement memory cache for frequently accessed schemas.

---

[← Back to Architecture Index](rootserver-12-arch-index.md)

---
