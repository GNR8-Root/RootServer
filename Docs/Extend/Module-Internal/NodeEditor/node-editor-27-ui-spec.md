# UI/UX Spec - Interaction, Rendering, Layout

---

### Dragging
- Drag handle: node header
- Drag threshold: ~4px
- During drag: physics enabled (damping), constraints maintained
- On drag end:
    - emit `onNodeMoveEnd(nodeId, x, y)`
    - debounced persistence in Blazor

---

### Link creation
1. Pointer down on a port starts a link preview
2. Preview wire follows cursor
3. Compatible ports highlight
4. Release:
    - compatible → create edge event
    - incompatible → cancel

Compatibility:
- FlowOut → FlowIn
- DataOut → DataIn

---

### Selection
- Click selects node/edge
- Esc clears selection
- (Optional phase 2) Shift multi-select and box select

---

### Macro navigation
- Double-click Macro node OR click Open
- Breadcrumb stack
- Leaving graph triggers layout save
- Entering macro loads child graph snapshot

---

## Visual layout

### Node anatomy
- Header: 32px height
- Body padding: 12px
- Row spacing: 8px
- Ports: 12px diameter

Port placements:
- FlowIn: top center
- FlowOut: bottom center
- DataIn: left per-row
- DataOut: right per-row

---

### Edge styles
- Flow edges: thicker, vertical bias bezier
- Data edges: thinner, horizontal bias bezier, dashed

Hover/selection:
- Increase stroke width slightly
- Glow or outline
- Show port labels on hover (optional)

---

### Panels
- Left: Graph explorer / macros / search
- Right: Inspector (node params, ports, validation)
- Bottom (optional): log + validation results + runtime trace

---

[← Node-Editor](node-editor.md)
1. **[Base](node-editor-00-base-index.md)** – what the editor is and how it works conceptually
2. **[Architecture](node-editor-12-arch-index.md)** – how the system is structured and implemented
3. **[UI](node-editor-26-ui-index.md)** – how users interact with the editor
4. **[Appendix](node-editor-39-appendix-index.md)** – technical details and references
5. **[Diagrams](node-editor-43-diagrams.md)** – flowcharts and other visual representations

---