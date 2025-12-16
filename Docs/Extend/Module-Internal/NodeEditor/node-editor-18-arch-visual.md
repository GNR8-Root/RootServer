#  Visual Specification

---

## **Node Anatomy**

```
┌─────────────────────────┐
│ 🎯 Node Name      [Type]│ ← Header (draggable, colored by type)
├─────────────────────────┤
│ ○ FlowIn (top center)   │
├─────────────────────────┤
│ ● Property A: value  ◐  │ ← Body (DataIn left, DataOut right)
│ ● Property B: value  ◐  │
│ ● Property C: value  ◐  │
├─────────────────────────┤
│ ○ FlowOut (bottom)      │
└─────────────────────────┘
```

**Header:**
- Height: 32px
- Background: type-specific color (Root: blue, Sequence: green, Action: orange)
- Font: 14px semi-bold
- Icon: 16x16 glyph left-aligned

**Body:**
- Padding: 12px
- Background: #2a2a2a (dark theme)
- Min-height: 60px
- Row spacing: 8px per property

**Ports:**
- Size: 12px diameter circles
- FlowIn/Out: filled, bold outline
- DataIn/Out: outlined, fill on hover
- Spacing: 8px margin from edge

---

## **Port Positioning Rules**

| Port Type | Side | Alignment | Offset |
|-----------|------|-----------|--------|
| FlowIn | Top | Center horizontal | Y: -6px from node top |
| FlowOut | Bottom | Center horizontal | Y: +6px from node bottom |
| DataIn | Left | Vertical per property row | X: -6px, Y: row center |
| DataOut | Right | Vertical per property row | X: +6px, Y: row center |

**Calculation Example:**
```javascript
// DataIn port for property at index 2
const headerHeight = 32;
const bodyPadding = 12;
const rowHeight = 24;
const portY = headerHeight + bodyPadding + (rowHeight * index) + (rowHeight / 2);
```

---

## **Edge Visual Styles**

**Flow Edges (Top → Bottom):**
- Color: #4A90E2 (blue)
- Width: 3px
- Bezier curve with vertical bias:
  ```javascript
  bezier(x1, y1, x1, y1 + 60, x2, y2 - 60, x2, y2)
  ```
- Arrow at endpoint

**Data Edges (Left → Right):**
- Color: #E2A04A (orange)
- Width: 2px
- Bezier curve with horizontal bias:
  ```javascript
  bezier(x1, y1, x1 + 80, y1, x2 - 80, y2, x2, y2)
  ```
- Dashed pattern: `setLineDash([5, 5])`

**Hover/Selection:**
- Increase width by 1px
- Add glow effect (shadow blur: 8px)
- Brighten color by 20%

---

## **Interaction Design**

### **Dragging Nodes**
1. **Click zone:** Header area only
2. **Drag initiation:** 4px threshold to distinguish from click
3. **During drag:**
    - Increase `frictionAir` on dragged node to 0.5
    - Apply subtle "pull" force to connected nodes (via constraint stiffness boost)
    - Show distance indicators to nearby nodes (optional)
4. **Drag end:**
    - Restore `frictionAir` to 0.25
    - Emit `onNodeMoveEnd` after 300ms debounce
    - Snap to grid (optional, 10px grid)

### **Creating Links**
1. **Start:** Click and hold on source port
2. **Drag:** Show temporary wire from port to cursor
3. **Validation:** Highlight compatible target ports (green), incompatible (red)
4. **Complete:** Release on valid port → create edge
5. **Cancel:** Release on empty space or incompatible port

**Port Compatibility Matrix:**

| From ↓ / To → | FlowIn | FlowOut | DataIn | DataOut |
|---------------|--------|---------|--------|---------|
| FlowOut | ✅ | ❌ | ❌ | ❌ |
| DataOut | ❌ | ❌ | ✅ | ❌ |

### **Selection**
- **Single select:** Click node body
- **Multi-select:** Shift + click (phase 2)
- **Box select:** Drag on empty canvas (phase 2)
- **Deselect:** Click empty space or press Esc

#### **Macro Navigation**
- **Enter:** Double-click macro node OR click "Open" button in node
- **Breadcrumbs:** Display at top: `Root Graph > AI Controller > Attack Behavior`
- **Exit:** Click breadcrumb level OR "Back" button
- **Auto-save:** Persist layout before navigation

---

[← Node-Editor](node-editor.md)
1. **[Base](node-editor-00-base-index.md)** – what the editor is and how it works conceptually
2. **[Architecture](node-editor-12-arch-index.md)** – how the system is structured and implemented
3. **[UI](node-editor-26-ui-index.md)** – how users interact with the editor
4. **[Appendix](node-editor-39-appendix-index.md)** – technical details and references
5. **[Diagrams](node-editor-43-diagrams.md)** – flowcharts and other visual representations

---
