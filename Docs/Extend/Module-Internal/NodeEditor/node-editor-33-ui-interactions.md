
# Interaction Patterns

---

## 1. Canvas Interactions

### Pan (Camera)

**Trigger**: Middle mouse drag OR Space + drag

**Feedback**: Cursor changes to grab/grabbing; node interactions disabled while panning

**Motion**: Slight momentum decay (optional), must stop quickly

### Zoom

**Trigger**: Wheel or pinch

**Rules**:
- Zoom around cursor position
- Clamp: 0.25x → 4x
- Short smoothing (~100ms)
- Grid scales with zoom

**Zoom presets**:
- Fit All
- 100%
- 200%

### Selection

- **Click node body**: Select node
- **Click empty**: Clear selection
- **ESC**: Clear selection / cancel linking
- **Edge selection**: Click near curve midpoint (hit radius 8–12px)

---

## 2. Node Interactions

### Drag Node (Header-Only)

```
Hover header → cursor move
Mouse down → 4px threshold
Drag start:
  - opacity 0.9
  - scale 1.02
  - increase damping
  - stiffen connected constraints slightly
Drag end:
  - restore physics params
  - debounce 300ms
  - emit onNodeMoveEnd (save trigger)
```

**"Feel" Requirements**:
- Dragged node must remain under cursor (no lag)
- Connected nodes should "follow" subtly, not slingshot
- Layout should settle within ~1s after release

### Create Link (Port Drag)

```
Hover port → glow
Mouse down → linking state
Drag → temporary wire to cursor
Hover target:
  - compatible: green + magnet
  - incompatible: red + blocked
Release:
  - valid: connect + small "snap" animation
  - invalid/empty: wire retracts (elastic)
```

**Compatibility**:
- FlowOut → FlowIn ✅
- DataOut → DataIn ✅
- Others ❌

---

## 3. Inspector Interactions

### Edit Node Properties

- Selecting a node opens inspector (slide in ~300ms)
- Editing a value:
    - Saves on blur or Enter
    - Validates locally before writing
    - Shows inline errors without destroying focus

**Example inline error**:
```
⚠ Timeout must be a number ≥ 0
```

### Delete Node / Edge

- **Delete key** removes selected
- If node has children/edges: confirm modal
- Edge deletion: no modal (unless you want safety toggle)

**Confirmation copy**:
```
Delete "Attack Sequence" and 3 connected edges?
[Cancel] [Delete]
```

---

[← Node-Editor](node-editor.md)
1. **[Base](node-editor-00-base-index.md)** – what the editor is and how it works conceptually
2. **[Architecture](node-editor-12-arch-index.md)** – how the system is structured and implemented
3. **[UI](node-editor-26-ui-index.md)** – how users interact with the editor
4. **[Appendix](node-editor-39-appendix-index.md)** – technical details and references
5. **[Diagrams](node-editor-43-diagrams.md)** – flowcharts and other visual representations

---
