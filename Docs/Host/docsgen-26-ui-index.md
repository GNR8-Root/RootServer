# UI Index — UI Hierarchy Model (Shared/_Sites)

UI system overview for RootServer using the numbered folder hierarchy and component prefixes.

---

## Source of Truth
- UI hierarchy folders: `Shared/_Sites`
- Cross-layer numbered hierarchy:
    - 00_Core → system classes
    - 01_Displays → read/output
    - 02_Fields → read & write inputs
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

## Composition Patterns
- Micro (Fields/Displays) → Macro (Panels) composition
- Reuse via Components/Widgets; Views define concrete layouts; Panels group major areas

---

**Back navigation:** **[Root Index](./RootServer.md)** · **[Architecture Index](./docsgen-12-arch-index.md)**

---


