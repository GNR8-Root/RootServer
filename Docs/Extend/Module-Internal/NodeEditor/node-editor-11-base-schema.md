# Airtable Schema - Graphs, Nodes, Edges, Ports (Optional)

---

## Table: Graphs
Fields:
- `graph_id` (PK)
- `name`
- `version` (number)
- `updated_at`
- `root_node` (link to Nodes)
- `metadata` (json: camera, zoom, editor UI state)

Invariants:
- `graph_id` unique
- exactly one root per graph (by `root_node` or `Root` node type)

---

## Table: Nodes
Fields:
- `node_id` (PK)
- `graph_id` (link to Graphs)
- `type`
- `name`
- `x`, `y`, `w`, `h`
- `data` (json)
- `ui` (json)
- `macro_graph_id` (link to Graphs; Macro nodes only)
- `updated_at`

Invariants:
- `node_id` unique
- node belongs to exactly one graph
- if `type == Macro` then `macro_graph_id` is required

---

## Table: Edges
Fields:
- `edge_id` (PK)
- `graph_id`
- `kind` (`Flow` | `Data`)
- `from_node`, `from_port`
- `to_node`, `to_port`
- `index` (number, optional but recommended for flow ordering)
- `style` (json)
- `updated_at`

Invariants:
- endpoints exist
- kind/ports compatible (FlowOut→FlowIn, DataOut→DataIn)
- no duplicates for same from/to ports
- no cycles in Flow graph (Behavior Tree should be DAG)

---

## Table: Ports (Optional)
Use if ports are dynamic/typed per node.

Fields:
- `port_id` (PK)
- `node_id`
- `name`
- `kind` (FlowIn/FlowOut/DataIn/DataOut)
- `dataType` (string)
- `index` (for ordering)
- `ui` (json: label/hidden)

If Ports table is not used:
- ports are inferred from node type via a `NodeTypeRegistry`.

---

[← Node-Editor](node-editor.md)
1. **[Base](node-editor-00-base-index.md)** – what the editor is and how it works conceptually
2. **[Architecture](node-editor-12-arch-index.md)** – how the system is structured and implemented
3. **[UI](node-editor-26-ui-index.md)** – how users interact with the editor
4. **[Appendix](node-editor-39-appendix-index.md)** – technical details and references
5. **[Diagrams](node-editor-43-diagrams.md)** – flowcharts and other visual representations

---