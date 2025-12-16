# UI Overview & Hierarchy — RootServer Host

UI layer overview using the numbered hierarchy in `Shared/_Sites` and component prefixes.

---

## Source of Truth
- UI hierarchy root: `Shared/_Sites`
- Cross-layer folders (micro → macro):
    - 00_Core → system classes
    - 01_Displays → read/output
    - 02_Fields → input/edit
    - 03_Pointers → interaction helpers
    - 04_Actions → control logic
    - 05_Components → composed layouts
    - 06_Widgets → multi-view containers
    - 07_View → view definitions
    - 08_Panels → higher-level groupings

---

## Prefix Conventions
- `D_` Displays, `F_` Fields, `P_` Pointers, `A_` Actions
- `C_` Components, `W_` Widgets, `V_` Views, `PNL_` Panels

---

## Page Composition (Conceptual)
- Panels group major areas
- Views are routed surfaces built from Widgets and Components
- Components assemble Displays/Fields/Pointers/Actions

---

**Back navigation:** **[UI Index](./docsgen-26-ui-index.md)** · **[Architecture Index](./docsgen-12-arch-index.md)**

---
