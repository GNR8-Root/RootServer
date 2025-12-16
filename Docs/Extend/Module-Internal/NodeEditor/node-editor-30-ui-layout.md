# 🧱 Layout Structure

---

## Main Application Layout

```
┌─────────────────────────────────────────────────────────────┐
│  HEADER BAR (56–64px)                                       │
│  [Logo]  Breadcrumbs: Root › Macro A › Macro B    [Sync ▼]  │
│                                 [Reload] [Validate] [usr]   │
├─────────────────────────────────────────────────────────────┤
│  TOOLBAR (optional, 40–48px)                                │
│  [Select] [Pan] [Add Node ▼] [Grid] [Snap] [Fit] [Zoom 100%]│
├──────────────────────────────────┬──────────────────────────┤
│                                  │                          │
│  CANVAS                          │  INSPECTOR (320–380px)   │
│  (p5 render)                     │  ┌──────────────────┐    │
│                                  │  │ Node Inspector   │    │
│  - Infinite pan/zoom             │  │ Type: Sequence   │    │
│  - Nodes / wires                 │  │ Name: [______]   │    │
│  - Hover + selection             │  │ Properties…      │    │
│                                  │  └──────────────────┘    │
│                                  │  Validation summary      │
├──────────────────────────────────┴──────────────────────────┤
│  STATUS BAR (24–32px)                                       │
│  Nodes: 12 | Selected: 1 | Zoom: 100% | Grid: On | Saved ✓  │
└─────────────────────────────────────────────────────────────┘
```

## Layout Behavior Notes

- **Header**: Always visible (sticky). Anchors navigation and sync confidence.
- **Toolbar**: Optional for novice discoverability; power users rely on hotkeys.
- **Inspector**: Opens when something is selected; otherwise shows "No selection".
- **Status bar**: Small, non-intrusive; shows graph stats + zoom + save state.

---

[← Node-Editor](node-editor.md)
1. **[Base](node-editor-00-base-index.md)** – what the editor is and how it works conceptually
2. **[Architecture](node-editor-12-arch-index.md)** – how the system is structured and implemented
3. **[UI](node-editor-26-ui-index.md)** – how users interact with the editor
4. **[Appendix](node-editor-39-appendix-index.md)** – technical details and references
5. **[Diagrams](node-editor-43-diagrams.md)** – flowcharts and other visual representations

---
