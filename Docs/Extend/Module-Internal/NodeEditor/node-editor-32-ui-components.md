
# Component Library

---

## 1. Node Component

### Node States (Visual + Behavior)

| State | Visual | Behavior |
|-------|--------|----------|
| **Default** | Ring: subtle, Shadow: medium | Header: type color |
| **Hover** | Ring: brighter, Cursor: move (header) | Ports glow on proximity |
| **Selected** | Ring: blue 2px, Shadow: blue glow | Inspector opens |
| **Dragging** | Opacity: 0.9, Scale: 1.02 | Stronger shadow |
| **Error** | Ring: red, Badge: ⚠ top right | Listed in validation panel |

### Node Type Visual Identity

| Node Type | Header Color | Icon | Description |
|-----------|--------------|------|-------------|
| Root | Blue | 🎯 | Single entry point |
| Sequence | Green | → | Runs children in order |
| Selector | Orange | ⚡ | Finds first success |
| Action | Purple | ⚙️ | Executes a behavior |
| Condition | Cyan | ? | Boolean check |
| Decorator | Pink | ✦ | Wraps/modifies child |
| Macro | Indigo | 📁 | Opens nested graph |

### Node Anatomy (Detailed Measurements)

```
┌───────────────────────────────────┐
│ HEADER (32px)  [icon] Name   [⋯]  │  ← draggable
│  - icon 16px (left 8px)           │
│  - text baseline centered         │
│  - kebab button 20px (right 6px)  │
├───────────────────────────────────┤
│ ○ FlowIn (top center, y -6)       │
├───────────────────────────────────┤
│ BODY (padding 12px)               │
│ label (12–13px)                   │
│ ● param: value                ◐   │  ← data ports per row
│ (8px gap)                         │
│ ● param: value                ◐   │
├───────────────────────────────────┤
│ ○ FlowOut (bottom center, y +6)   │
└───────────────────────────────────┘
```

**Dimensions**:
- Default width: 240px
- Min height: 100px (dynamic)
- Row height: 24px
- Port diameter: 12px
- Port edge offset: 6px

### Example Node (Content Model)

```json
{
  "type": "Action",
  "name": "MoveTo",
  "data": {
    "target": "Player",
    "speed": 5,
    "timeout": 10
  },
  "ui": {
    "color": "#9B59B6",
    "collapsed": false
  }
}
```

---

## 2. Port Component

### Port Appearance

**Flow (execution)**:
- Filled circle, strong outline, "authoritative"
- Hover expands slightly, shows tooltip "Flow Out"

**Data**:
- Outline circle, fill appears on hover
- When connected: remains filled to indicate occupancy

**Port tooltip example**:
```
Target (Object) - Data Input
```

### Port States & Feedback

| State | Visual | Behavior |
|-------|--------|----------|
| Idle | Default shape | No hint |
| Hover | Scale + glow | Tooltip after 500ms |
| Link Source | Pulsing | Drag wire preview |
| Valid Target | Green glow | "snap" magnet radius |
| Invalid Target | Red glow | Blocked cursor / tiny shake |
| Connected | Filled | Indicates active connection |

---

## 3. Edge (Wire) Component

### Edge Styles

**Flow edge (Top → Bottom)**:
- Blue, solid, 3px, arrowhead
- Strong vertical curve (keeps tree readable)

**Data edge (Left → Right)**:
- Orange, dashed, 2px
- Horizontal curve (signals data direction)

### Edge States

| State | Appearance | Animation |
|-------|------------|-----------|
| Default | Base style | None |
| Hover | +1px, brighter | Soft glow pulse |
| Selected | +2px + glow | Traveling dots (optional) |
| Invalid | Red dashed | Shake + tooltip reason |
| Creating | Semi-transparent | Dash offset anim |

---

## 4. Button & Chip Components (UI Chrome)

### Button Variants

- **Primary**: "Reload", "Validate", "Apply Updates"
- **Secondary**: Outline / subtle
- **Icon**: 32px square for toolbar actions

### Example Button Copy

- "Reload from Airtable"
- "Apply remote updates"
- "Open Macro"
- "Fit to view"

---

[← Node-Editor](node-editor.md)
1. **[Base](node-editor-00-base-index.md)** – what the editor is and how it works conceptually
2. **[Architecture](node-editor-12-arch-index.md)** – how the system is structured and implemented
3. **[UI](node-editor-26-ui-index.md)** – how users interact with the editor
4. **[Appendix](node-editor-39-appendix-index.md)** – technical details and references
5. **[Diagrams](node-editor-43-diagrams.md)** – flowcharts and other visual representations

---
