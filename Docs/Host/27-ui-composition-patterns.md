# UI Composition Patterns — RootServer Host

Composition guidance for building UIs from micro to macro layers.

---

## Micro → Macro Pattern
- Micro: Displays/Fields/Pointers/Actions
- Meso: Components (assembled micro units)
- Macro: Widgets (combine views), Views (concrete layouts), Panels (top-level grouping)

---

## Reusability & Naming
- Reuse via Components/Widgets; keep names aligned with prefixes and roles
- Prefer clear, intent-revealing component names

---

## State & Data Flow
- Prefer unidirectional data flow at view/panel level
- Keep cross-component communication explicit via parameters or events

---

**Back navigation:** **[UI Index](./docsgen-26-ui-index.md)** · **[Root Index](./RootServer.md)**

---
