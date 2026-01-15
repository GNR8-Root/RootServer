# Architecture Overview

---

## Purpose

RootServer implements a **layered, metadata-driven architecture** where UI components are assembled dynamically from `Airtable` data structures. This approach eliminates hardcoded layouts and enables rapid iteration on UI composition.

The architecture follows three core principles:

- **Separation of Concerns** – Clear boundaries between `Core`, `Editor`, and `Sites` layers
- **Schema-Driven Generation** – UI metadata stored in `Airtable` drives component instantiation
- **Plugin Extensibility** – Self-contained plugins extend functionality through a numbered hierarchy

---

## Architectural Layers

### Core Layer (`Shared/_Core`)
Foundation classes providing base component patterns, event systems, and core services. All other layers build upon these primitives.

Key responsibilities:
- Base component classes (`BasePage`, `SectionBase`)
- Event system (`PointerEventManager`, custom events)
- Core services (`Pointer_Service`, `LogCatcher_Service`)
- Shared enums and data structures

### Editor Layer (`Shared/_Editor`)
Internal development tooling for inspecting tables, rows, fields, and managing `Airtable` synchronization.

Key responsibilities:
- Table/row inspection UI
- JSON sync utilities
- Workspace management
- Development-time diagnostics

### Sites Layer (`Shared/_Sites`)
Public-facing website UI assembled from reusable sections. Each section (`Welcome`, `About`, `Contact`, etc.) follows the wrapper + base pattern.

Key responsibilities:
- Page routing and navigation
- Section composition
- Background components
- Public layouts

### Plugin Layer (`Shared/Plugins/Airtable`)
Specialized components for `Airtable` data operations, following the same numbered hierarchy as `Core`.

Key responsibilities:
- Airtable-specific displays, fields, pointers
- Data synchronization actions
- Table/row management UI
- Plugin-specific panels

---

## Numbered Hierarchy Model

RootServer organizes components in a **micro-to-macro hierarchy** numbered `00_Core` through `09_Panels`:

```text
00_Core       → System classes, events, base types
01_Displays   → Read-only output (text, images, media)
02_Fields     → Read/write inputs (form fields, editors)
03_Pointers   → Interaction helpers (buttons, selectors)
04_Actions    → User/system actions and control logic
05_Nodes      → Node graph definitions (planned)
06_Components → Composed layouts (displays + fields + pointers)
07_Widgets    → Container layouts (multiple views)
08_View       → Layout definitions (single/multiple views)
09_Panels     → High-level groupings (multiple views)
```

This hierarchy appears in:
- `Shared/_Core`
- `Shared/_Editor`
- `Shared/Plugins/Airtable`

Each folder builds on the primitives from lower numbers, creating a predictable dependency chain.

---

## Component Prefix System

Components use **naming prefixes** to identify their role:

- `D_` – Displays (read-only output)
- `F_` – Fields (read/write inputs)
- `P_` – Pointers (interaction triggers)
- `A_` – Actions (operations)
- `N_` – Nodes (graph nodes, planned)
- `C_` – Components (composed layouts)
- `W_` – Widgets (layout containers)
- `V_` – Views (view definitions)
- `PNL_` – Panels (high-level groupings)

Example: `P_Table` is a pointer in the `03_Pointers` folder that triggers table selection.

---

## Data Flow Overview

```text
Airtable API
    ↓
JSON Cache (local)
    ↓
AirtableConfig (initialization)
    ↓
Services (Pointer_Service, EditorView_Service)
    ↓
Components (subscribe to events)
    ↓
UI Rendering (Blazor Server)
```

The data flows from `Airtable` through local `JSON` caches, then into services that manage state and events. Components subscribe to these events and re-render when data changes.

---

## Key Design Patterns

### Wrapper + Base Pattern
Many components follow a two-part structure:
- **Wrapper** – Handles layout, styling, conditional rendering
- **Base** – Contains core logic, state management

Example: `CW_Section.razor` (wrapper) + `SectionBase.razor.cs` (base)

### Event-Driven State
State changes propagate through custom events rather than direct method calls, enabling loose coupling between components.

### Service-Based DI
Services registered in `Program.cs` provide centralized state management and are injected into components via dependency injection.

### Schema Metadata
UI structure is defined in `Airtable` tables (`pages.json`, `sections.json`) and instantiated at runtime, not in code.

---

## Dependency Boundaries

### Allowed References
- **Plugin → Module** – Plugins can reference all modules
- **Plugin → Host** – Plugins know about the Host
- **Module → Module** – Direct references between modules

### Restricted References
- **Host → Plugin** – Host should not depend on plugins
- **Plugin → Plugin** – Planned via Node system (not yet implemented)

---

## Technology Stack

- `Blazor Server` (`.NET 10.0`)
- `Airtable API` (v1.4.0)
- `Blazorise` (v1.8.7) with `Tailwind` + `FontAwesome`
- Event-driven architecture
- Local `JSON` caching for offline capability

---

---

**Navigation**

- **[← Home](rootserver.md)**
- **[Getting Started →](rootserver-02-getting-started.md)**
- **[UI Index →](rootserver-26-ui-index.md)**

---
