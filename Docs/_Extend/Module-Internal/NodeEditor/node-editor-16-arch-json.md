# **Normalized JSON Contract**

---

Blazor produces this canonical format for JS consumption:

```json
{
  "graphId": "graph_abc123",
  "version": 42,
  "name": "Main Behavior Tree",
  "metadata": {
    "camera": { "x": 0, "y": 0, "zoom": 1.0 }
  },
  "nodes": [
    {
      "id": "node_1",
      "type": "Root",
      "name": "Root",
      "x": 400,
      "y": 100,
      "w": 220,
      "h": 80,
      "data": {},
      "ui": { "color": "#4A90E2" },
      "ports": {
        "flowOut": { "side": "bottom", "datatype": "flow" }
      },
      "macroGraphId": null
    },
    {
      "id": "node_2",
      "type": "Sequence",
      "name": "Attack Sequence",
      "x": 400,
      "y": 250,
      "w": 220,
      "h": 120,
      "data": {},
      "ui": {},
      "ports": {
        "flowIn": { "side": "top", "datatype": "flow" },
        "flowOut": { "side": "bottom", "datatype": "flow" },
        "dataIn_target": { "side": "left", "datatype": "object", "index": 0 }
      },
      "macroGraphId": null
    }
  ],
  "edges": [
    {
      "id": "edge_1",
      "kind": "Flow",
      "from": "node_1",
      "fromPort": "flowOut",
      "to": "node_2",
      "toPort": "flowIn",
      "style": {}
    }
  ]
}
```

---

[← Node-Editor](node-editor.md)
1. **[Base](node-editor-00-base-index.md)** – what the editor is and how it works conceptually
2. **[Architecture](node-editor-12-arch-index.md)** – how the system is structured and implemented
3. **[UI](node-editor-26-ui-index.md)** – how users interact with the editor
4. **[Appendix](node-editor-39-appendix-index.md)** – technical details and references
5. **[Diagrams](node-editor-43-diagrams.md)** – flowcharts and other visual representations

---
