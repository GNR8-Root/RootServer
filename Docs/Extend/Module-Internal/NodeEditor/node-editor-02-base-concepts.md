# CONCEPTS

---

## Mental Model

---

The Node Editor operates as a **directed graph**:

- **Nodes** represent atomic units of intent (data, logic, AI action, layout, or structure generation).
- **Connections** represent flow, dependency, or data transfer.
- **Graphs** define deterministic or AI-assisted execution paths.

Each graph acts as a **blueprint**, not imperative code, allowing runtime generation of UI, content, logic, and AI flows from structured definitions.

---

## Execution Graph

---

An execution graph is the fully resolved version of a node graph:

- All inputs resolved
- All dependencies ordered
- All AI context prepared

Execution graphs are transient and exist only at runtime.

---

# Nodes vs Connections

---

Nodes define **capabilities**.  
Connections define **meaningful relationships**.

- Nodes without connections do nothing
- Connections without nodes are invalid
- Behavior emerges from composition, not individual nodes

---

[← Node-Editor](node-editor.md)
1. **[Base](node-editor-00-base-index.md)** – what the editor is and how it works conceptually
2. **[Architecture](node-editor-12-arch-index.md)** – how the system is structured and implemented
3. **[UI](node-editor-26-ui-index.md)** – how users interact with the editor
4. **[Appendix](node-editor-39-appendix-index.md)** – technical details and references
5. **[Diagrams](node-editor-43-diagrams.md)** – flowcharts and other visual representations

---