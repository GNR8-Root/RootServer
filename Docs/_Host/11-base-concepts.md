# Base Concepts — RootServer Host

Conceptual foundations for the RootServer Host. Host coordinates modules and plugins, manages lifecycles, and provides UI scaffolding.

---

## Host Role & Responsibilities
- Composition root: DI container configuration, environment selection, feature flags
- Lifecycle coordination: startup, module initialization, plugin discovery and activation
- Boundaries: Host ↔ Modules ↔ Plugins (Host should not depend on Plugins)
- UI scaffolding: routes/views/panels and shared UI infrastructure in `Shared/_Sites`

---

## Entities & Flows (Host-Relevant)
- Configuration entity: runtime settings from `appsettings*.json` and environment
- Module services: domain services exposed to Host and Plugins
- Plugin descriptors: metadata for discovery/activation (conceptual; implementation varies)
- High-level flows: application start → DI build → module boot → optional plugin discovery → UI route initialization

---

## Numbered Folder Hierarchy (Micro → Macro)
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

**Back navigation:** **[Root Index](./RootServer.md)** · **[Base Index](./docsgen-00-base-index.md)**

---


