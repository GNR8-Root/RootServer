# Sync Model - Snapshot, Patches, Conflicts

---

## Principles
- Airtable stores **design-time** graph state (nodes/edges/layout)
- Runtime state (Running statuses, timers) is **not** stored in Airtable
- Avoid writing every frame; use debounced commits

---

## Read model (load)
Blazor loads:
1. Graph record
2. Nodes where `graph_id == X`
3. Edges where `graph_id == X`
4. Ports (optional)

Then builds normalized snapshot:
- validate invariants
- call `loadGraph(snapshot)` into JS

---

## Write model (save)
Write triggers:
- Node drag end → update `Nodes.x/y`
- Edge created → create edge record
- Edge deleted → delete edge record
- Inspector param change → update `Nodes.data` / `Nodes.ui`

Debounce suggestion:
- layout saves: 250–500ms after last move end
- inspector edits: save on blur or 300ms debounce

---

## Optimistic concurrency
Recommended:
- `Graphs.version` increments on any write affecting the graph set
- Each write includes `expectedVersion`

On conflict:
- re-read latest snapshot
- attempt reapply local pending operations
- show conflict UI (Reload / Keep Local / Merge) if reapply fails

---

## Patch format
Use a small op list:
```json
{
  "graphId": "graph_abc123",
  "baseVersion": 42,
  "ops": [
    { "op": "node.move", "id": "node_2", "x": 400, "y": 250 },
    { "op": "edge.add", "edge": { "id": "edge_9", "kind": "Flow", "from": "...", "to": "..." } },
    { "op": "edge.remove", "id": "edge_3" },
    { "op": "node.update", "id": "node_7", "data": { "threshold": 0.7 } }
  ]
}

```

JS patch application rules:

Add/remove nodes/edges without full reload

Rebuild physics constraints only for touched edges/nodes

Keep selection if possible; clear if selected element was removed

---

## Event spam control

JS → Blazor:

onNodeMoved can fire frequently for UI updates (do not persist)

onNodeMoveEnd should be the persistence trigger

---

[← Node-Editor](node-editor.md)
1. **[Base](node-editor-00-base-index.md)** – what the editor is and how it works conceptually
2. **[Architecture](node-editor-12-arch-index.md)** – how the system is structured and implemented
3. **[UI](node-editor-26-ui-index.md)** – how users interact with the editor
4. **[Appendix](node-editor-39-appendix-index.md)** – technical details and references
5. **[Diagrams](node-editor-43-diagrams.md)** – flowcharts and other visual representations

---