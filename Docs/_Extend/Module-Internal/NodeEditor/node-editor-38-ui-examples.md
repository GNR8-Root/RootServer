
# 🧪 Examples (Concrete UI Scenarios)

---

## Example A - Creating a Flow Connection

1. User drags from `Root.flowOut`
2. All FlowIn ports glow green
3. User releases on `Sequence.flowIn`
4. Wire snaps in, arrow appears
5. Toast: "Flow connection created"

---

## Example B - Type Mismatch (Data Edge)

1. User drags from `DataOut(object)`
2. Hovers `DataIn(number)` → turns red + tooltip:
   ```
   Type mismatch: object → number
   ```
3. Release cancels with elastic retract
4. No edge created

---

## Example C - Entering a Macro Node

1. User double-clicks macro node
2. Fade out 200ms + loading spinner
3. Breadcrumb updates: `Root › AI Controller › Attack Behavior`
4. Fade in 200ms
5. Camera animates to child root

---

[← Node-Editor](node-editor.md)
1. **[Base](node-editor-00-base-index.md)** – what the editor is and how it works conceptually
2. **[Architecture](node-editor-12-arch-index.md)** – how the system is structured and implemented
3. **[UI](node-editor-26-ui-index.md)** – how users interact with the editor
4. **[Appendix](node-editor-39-appendix-index.md)** – technical details and references
5. **[Diagrams](node-editor-43-diagrams.md)** – flowcharts and other visual representations

---
