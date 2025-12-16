# Data Model & Airtable Schema

---

## **Table: Graphs**

| Field | Type | Description |
|-------|------|-------------|
| `graph_id` | Primary Key (Formula) | Unique identifier |
| `name` | Single Line Text | Display name |
| `version` | Number | Increments on each write (optimistic locking) |
| `updated_at` | Last Modified Time | Auto-tracked timestamp |
| `root_node` | Link to Nodes | Entry point for execution |
| `metadata` | Long Text (JSON) | Camera position, zoom, UI state |

**Indexes:** `graph_id`, `updated_at` (for streaming queries)

---

## **Table: Nodes**

| Field | Type | Description |
|-------|------|-------------|
| `node_id` | Primary Key | Unique identifier |
| `graph_id` | Link to Graphs | Parent graph |
| `type` | Single Select | Root, Sequence, Selector, Action, Condition, Macro, Decorator |
| `name` | Single Line Text | User-facing label |
| `x` | Number (Float) | Canvas X position |
| `y` | Number (Float) | Canvas Y position |
| `w` | Number (Float) | Width (optional, can be type-based default) |
| `h` | Number (Float) | Height (computed from content) |
| `data` | Long Text (JSON) | Node-specific properties/parameters |
| `macro_graph_id` | Link to Graphs | Child graph reference (Macro nodes only) |
| `ui` | Long Text (JSON) | `{collapsed, color, minimized, notes}` |
| `updated_at` | Last Modified Time | Change tracking |

**Indexes:** `graph_id + node_id`, `macro_graph_id` (for macro lookup)

**Example `data` JSON:**
```json
{
  "action": "MoveTo",
  "target": "Player",
  "speed": 5.0,
  "timeout": 10
}
```

---

## **Table: Edges**

| Field | Type | Description |
|-------|------|-------------|
| `edge_id` | Primary Key | Unique identifier |
| `graph_id` | Link to Graphs | Parent graph |
| `kind` | Single Select | Flow, Data |
| `from_node` | Link to Nodes | Source node |
| `from_port` | Single Line Text | Port identifier (e.g., "out", "result") |
| `to_node` | Link to Nodes | Target node |
| `to_port` | Single Line Text | Port identifier (e.g., "in", "value") |
| `style` | Long Text (JSON) | `{color, thickness, animated}` (optional) |
| `updated_at` | Last Modified Time | Change tracking |

**Validation Rules:**
- Flow edges: `from_port` must be FlowOut, `to_port` must be FlowIn
- Data edges: `from_port` must be DataOut, `to_port` must be DataIn
- No duplicate edges (same from_node/from_port → to_node/to_port)

---

## **Table: Ports** *(Optional but Recommended)*

| Field | Type | Description |
|-------|------|-------------|
| `port_id` | Primary Key | Unique identifier |
| `node_id` | Link to Nodes | Parent node |
| `side` | Single Select | Top, Bottom, Left, Right |
| `name` | Single Line Text | Port identifier |
| `datatype` | Single Line Text | string, number, boolean, object, any |
| `index` | Number | Ordering (0-based) |
| `kind` | Single Select | FlowIn, FlowOut, DataIn, DataOut |

**Why Optional:** For simple behavior trees, ports can be inferred from node type. Include this table for:
- Dynamic port creation
- Complex data type validation
- Visual port customization

---

[← Node-Editor](node-editor.md)
1. **[Base](node-editor-00-base-index.md)** – what the editor is and how it works conceptually
2. **[Architecture](node-editor-12-arch-index.md)** – how the system is structured and implemented
3. **[UI](node-editor-26-ui-index.md)** – how users interact with the editor
4. **[Appendix](node-editor-39-appendix-index.md)** – technical details and references
5. **[Diagrams](node-editor-43-diagrams.md)** – flowcharts and other visual representations

---