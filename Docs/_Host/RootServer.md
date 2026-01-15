# RootServer — Host Documentation

High-level documentation for the RootServer Host, aligned to project conventions and strict validation. Use the indices below to navigate Architecture, UI, and Appendix.

---

## Sections
- **[Base Index](./docsgen-00-base-index.md)** — Core concepts, conventions, terminology (Host scope)
- **[Architecture Index](./docsgen-12-arch-index.md)** — Host architecture, module/plugin system, performance, testing, deployment
- **[UI Index](./docsgen-26-ui-index.md)** — UI hierarchy model (Shared/_Sites), folder roles, prefixes, patterns
- **[Appendix Index](./docsgen-39-appendix-index.md)** — Project structure, risks and vulnerabilities, duplicate JSON cleanup task

---

## Scope & Boundaries (Host)
- Coordinates Modules and Plugins; Host should not depend on Plugins
- Module ↔ Module direct references allowed; Plugins may reference Modules
- Planned Plugin ↔ Plugin interaction via Node system (experimental)

---

**Back navigation:** **[Preflight Summary](./00-preflight-summary.md)**

---

Docs/Host/docsgen-00-base-index.md
# Base Index — Concepts & Conventions (Host)

Foundation materials for understanding RootServer at a conceptual level. This set is Host-focused and framework-agnostic where possible.

---

## Core Concepts (Host)
- Host role: lifecycle coordination, configuration, DI composition, routing, UI scaffolding
- Modules: always active within Host; provide services, data access, utilities
- Plugins: extend Host; discoverable/activatable; avoid Host → Plugin dependency
- Airtable integration (Host level): vertical domain mapping (Base → Table → Row → Field)

---

## Architectural Conventions
- Numbered cross-layer folders (00_Core…08_Panels) define micro → macro composition
- UI hierarchy source of truth: `Shared/_Sites`
- Component prefixes: `D_`, `F_`, `P_`, `A_`, `C_`, `W_`, `V_`, `PNL_`

---

## Terminology
- “Display” = read/output components
- “Field” = input/edit components
- “Pointer” = choice/selection helpers
- “Action” = user/system command trigger and control logic
- “Component” = layout unit composed of D/F/P/A
- “Widget” = container combining multiple views
- “View” = concrete layout(s) for screen/route
- “Panel” = higher-level grouping of views

---

## Reading Order
1. **[Root Index](./RootServer.md)**
2. **[Architecture Index](./docsgen-12-arch-index.md)**
3. **[UI Index](./docsgen-26-ui-index.md)**
4. **[Appendix Index](./docsgen-39-appendix-index.md)**

---

**Back navigation:** **[Root Index](./RootServer.md)** · **[Preflight](./00-preflight-summary.md)**

---
