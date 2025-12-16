# Node Types - Contracts, Ports, and Validation

---

### Universal node contract
Each node has:
- `id`, `graphId`
- `type` (Root/Sequence/Selector/Action/Condition/Decorator/Parallel/Macro…)
- `name`
- `x`, `y`, `w`, `h`
- `data` (JSON parameters)
- `ui` (JSON: collapsed/color/notes)
- Ports (either explicit or inferred)

Return type (runtime): `Success | Failure | Running`

### Port kinds
- **FlowIn**: execution enters node
- **FlowOut**: execution continues to children
- **DataIn**: typed inputs (optional)
- **DataOut**: typed outputs (optional)

Compatibility matrix:
- FlowOut → FlowIn ✅
- DataOut → DataIn ✅
- everything else ❌

### Child ordering (critical)
If multiple flow children exist, ordering must be deterministic.

Supported approaches:
1. Explicit child ports: `child_0`, `child_1`, …
2. Edge field: `index` stored with edge (recommended)
3. Spatial ordering: by Y then X (not recommended as the only rule)

---

### Node type specs

---

### ROOT
| Category     | Description |
|--------------|-------------|
| **Type**     | Structural / Root Node |
| **Rule – Uniqueness** | Must be **exactly one per graph** (or exactly one designated as root) |
| **Rule – Children** | Must have **exactly 1** flow child |
| **FlowOut Port** | Single `FlowOut` port (child entry point) |
| **Validation – Outgoing** | Must have **exactly 1** outgoing flow edge |
| **Validation – Graph** | Graph must contain **one and only one** root node |

---

### SEQUENCE
| Category     | Description |
|--------------|-------------|
| **Type**     | Control / Composite Node (Sequence) |
| **Execution Order** | Tick child nodes **in defined order** |
| **Failure Rule** | On first child returning **Failure** → return **Failure** |
| **Running Rule** | On first child returning **Running** → return **Running** |
| **Success Rule** | If **all children return Success** → return **Success** |
| **FlowIn Port** | Single `FlowIn` port |
| **FlowOut Ports** | `N` ordered child `FlowOut` ports (or multiple outgoing edges with explicit ordering) |
| **Validation – Outgoing** | Must have **≥ 1** outgoing flow edge |
| **Validation – Cycles** | Must **not connect to itself** (no flow cycles allowed) |
---

### SELECTER (Fallback)
| Category     | Description |
|--------------|-------------|
| **Type**     | Control / Composite Node (Selector) |
| **Execution Order** | Tick child nodes **in defined order** |
| **Success Rule** | On first child returning **Success** → return **Success** |
| **Running Rule** | On first child returning **Running** → return **Running** |
| **Failure Rule** | If **all children return Failure** → return **Failure** |
| **FlowIn Port** | Single `FlowIn` port |
| **FlowOut Ports** | `N` ordered child `FlowOut` ports (or multiple outgoing edges with explicit ordering) |
| **Validation – Outgoing** | Must have **≥ 1** outgoing flow edge |
| **Validation – Cycles** | Must **not connect to itself** (no flow cycles allowed) |

---

### DECORATOR
| Category     | Description |
|--------------|-------------|
| **Type**     | Control / Decorator Node |
| **Rule**     | Must have **exactly one child** |
| **Behavior** | Modifies the child’s returned status according to the decorator kind |
| **FlowIn Port** | Single `FlowIn` port |
| **FlowOut Port** | Single `FlowOut` port (child) |
| **Validation – Outgoing** | Must have **exactly 1** outgoing flow edge |

---

### ACTION (leaf)
| Category     | Description |
|--------------|-------------|
| **Type**     | Leaf Node (Action) |
| **Behavior** | Performs an action; may return `Running` until completion |
| **FlowIn Port** | Single `FlowIn` port |
| **DataIn Ports** | Optional `DataIn` port(s) |
| **DataOut Ports** | Optional `DataOut` port(s) |
| **Validation – Outgoing** | Must have **0** outgoing flow edges |


---

### CONDITION (leaf)
| Category     | Description |
|--------------|-------------|
| **Type**     | Leaf Node (Condition) |
| **Behavior** | Instant evaluation returning `Success` or `Failure` |
| **FlowIn Port** | Single `FlowIn` port |
| **DataIn Ports** | Optional `DataIn` port(s) |
| **Validation – Outgoing** | Must have **0** outgoing flow edges |


---

### PARALLEL (optional)
| Category     | Description |
|--------------|-------------|
| **Type**     | Control / Composite Node (Parallel) |
| **Behavior** | Ticks **all children** according to defined policy |
| **Success Rule** | Success threshold defined in `data` |
| **Failure Rule** | Failure threshold defined in `data` |
| **FlowIn Port** | Single `FlowIn` port |
| **FlowOut Ports** | `N` child `FlowOut` ports |
| **Validation – Outgoing** | Must have **≥ 2** outgoing flow edges |
| **Validation – Policy** | Must define execution policy fields in `data` |


---

### MACRO
| Category     | Description |
|--------------|-------------|
| **Type**     | Structural / Macro Node |
| **Behavior** | Represents a nested behavior graph |
| **Runtime Mode** | Inlines child graph root **or** executes as a subtree |
| **FlowIn Port** | Single `FlowIn` port |
| **FlowOut Port** | Single `FlowOut` port (macro entry) |
| **Data Ports** | Optional `DataIn` / `DataOut` mapping ports |
| **Validation – Reference** | Must reference a valid `macro_graph_id` |
| **Validation – Cycles** | Must **not reference itself** (directly or indirectly) |

---

[← Node-Editor](node-editor.md)
1. **[Base](node-editor-00-base-index.md)** – what the editor is and how it works conceptually
2. **[Architecture](node-editor-12-arch-index.md)** – how the system is structured and implemented
3. **[UI](node-editor-26-ui-index.md)** – how users interact with the editor
4. **[Appendix](node-editor-39-appendix-index.md)** – technical details and references
5. **[Diagrams](node-editor-43-diagrams.md)** – flowcharts and other visual representations

---