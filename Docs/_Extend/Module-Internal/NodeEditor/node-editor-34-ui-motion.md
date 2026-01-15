
# Animation & Motion

---

## Node Animations

- **Spawn**: Scale 0 → 1 with spring easing (~300ms)
- **Delete**: Shrink + fade (~200ms)
- **Error pulse**: Small scale + red glow (3-step sequence)

---

## UI Transitions

- **Inspector slide**: `translateX(100%) → 0` 300ms
- **Macro navigation**:
  - Fade out 200ms
  - Load
  - Fade in 200ms
  - Camera animate to root 300ms

---

## Toast Notifications

- Appear from bottom-right
- 2–3 seconds
- Use for: "Edge created", "Saved", "Validation failed"

---

[← Node-Editor](node-editor.md)
1. **[Base](node-editor-00-base-index.md)** – what the editor is and how it works conceptually
2. **[Architecture](node-editor-12-arch-index.md)** – how the system is structured and implemented
3. **[UI](node-editor-26-ui-index.md)** – how users interact with the editor
4. **[Appendix](node-editor-39-appendix-index.md)** – technical details and references
5. **[Diagrams](node-editor-43-diagrams.md)** – flowcharts and other visual representations

---
