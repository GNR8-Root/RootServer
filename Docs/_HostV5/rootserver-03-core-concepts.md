# Core Concepts

---

## Host Application

RootServer is the **host application** that coordinates all modules, plugins, and UI layers. It provides the runtime environment for `Blazor Server` and manages dependency injection, configuration, and lifecycle.

The host is responsible for:
- Application startup and configuration (`Program.cs`)
- Service registration (DI container)
- Routing and middleware pipeline
- Plugin coordination (when plugin system is implemented)

---

## Schema-Driven UI

The core innovation of RootServer is **schema-driven UI generation**. Instead of hardcoding component hierarchies, the UI structure is defined in metadata stored in `Airtable` and cached as `JSON`.

### How It Works

1. **Define Schema** – Create tables in `Airtable` for pages, sections, components
2. **Sync to JSON** – Editor tool fetches data and saves to `Json/` folder
3. **Runtime Assembly** – Application reads JSON and instantiates components
4. **Dynamic Rendering** – `Blazor` renders UI based on metadata

Example page structure from `pages.json`:

```json
{
  "id": "rec123",
  "fields": {
    "Title": "Home",
    "Slug": "home",
    "Sections": ["recWelcome", "recAbout", "recContact"]
  }
}
```

This drives the creation of a page with three sections, assembled at runtime.

---

## Numbered Hierarchy

The **numbered folder hierarchy** (`00_Core` → `09_Panels`) organizes components from micro (system primitives) to macro (high-level panels).

### Why Numbered Folders?

- **Predictable Dependencies** – Lower numbers depend only on themselves; higher numbers can use all below
- **Clear Composition** – Visual indication of component complexity
- **Consistent Patterns** – Same structure across `Core`, `Editor`, and plugins

### Hierarchy Levels

- `00_Core` – System classes, events, base types, enums
- `01_Displays` – Read-only output components
- `02_Fields` – Input components with two-way binding
- `03_Pointers` – UI triggers (buttons, selectors, tabs)
- `04_Actions` – Operations triggered by pointers
- `05_Nodes` – Node graph system (planned, not yet implemented)
- `06_Components` – Composed layouts combining displays, fields, pointers
- `07_Widgets` – Container layouts with multiple sub-components
- `08_View` – View definitions for single or multiple layouts
- `09_Panels` – High-level groupings of views

---

## Component Prefixes

Each component name uses a **prefix** to identify its role in the hierarchy:

- `D_` – Display component (e.g., `D_TextField`)
- `F_` – Field component (e.g., `F_InputText`)
- `P_` – Pointer component (e.g., `P_Button`)
- `A_` – Action component (e.g., `A_TableSync`)
- `N_` – Node component (e.g., `N_BehaviorTree`)
- `C_` – Component (composed layout, e.g., `C_Gallery`)
- `W_` – Widget (container, e.g., `W_Tables`)
- `V_` – View (layout definition, e.g., `V_Workspace`)
- `PNL_` – Panel (high-level grouping, e.g., `PNL_Selection`)

This naming convention makes it immediately clear what role a component plays.

---

## Wrapper + Base Pattern

Many components follow a **two-file pattern**:

### Wrapper File (`.razor`)
- Handles layout and styling
- Manages conditional rendering
- Provides markup structure
- Example: `CW_Section.razor`

### Base File (`.razor.cs` or separate `.cs`)
- Contains core logic
- Manages state and lifecycle
- Handles events and data operations
- Example: `SectionBase.razor.cs`

This separation keeps presentation concerns distinct from business logic.

---

## Event-Driven Architecture

State changes propagate through **custom events** rather than direct method calls. This enables loose coupling and makes components reusable across contexts.

### Event Flow Example

```text
User clicks P_Table
    ↓
P_Table raises TableSelected event
    ↓
Pointer_Service broadcasts event
    ↓
W_Tables listens and updates UI
    ↓
Blazor re-renders affected components
```

Key events:
- `PointerEvent` – User interactions
- `TableChangedEvent` – Table selection changes
- `RowChangedEvent` – Row selection changes
- `SyncCompleteEvent` – Data synchronization done

---

## Service Layer

Services registered in `Program.cs` provide **centralized state management** and are injected into components via dependency injection.

### Core Services

- `Pointer_Service` – Manages UI state and pointer events
- `LogCatcher_Service` – Centralized logging and diagnostics
- `EditorView_Service` – Editor workspace state
- `EditorVisibility_Service` – Editor UI visibility toggles

Services are scoped to the user's session (`AddScoped`), ensuring each connected client has isolated state.

---

## Airtable Integration

`Airtable` serves as the **external schema store** and data source. The integration layer:

1. **Fetches Data** – Uses `Airtable API` to retrieve tables, rows, fields
2. **Caches Locally** – Saves to `Json/` folder for offline capability
3. **Transforms Models** – Converts Airtable records to C# POCOs
4. **Drives UI** – Metadata from cache instantiates components

This approach enables rapid iteration: change Airtable schema, sync, and the UI updates automatically.

---

## Plugin Architecture (Planned)

The plugin system is under development. Key concepts:

### Current State
- `Airtable` plugin exists in `Shared/Plugins/Airtable/`
- Follows same numbered hierarchy as `Core`
- Self-contained with own displays, fields, pointers, actions, panels

### Planned Features
- **Hot-loading** – Load/unload plugins without restart
- **Dependency Declaration** – Plugins declare required modules
- **Discovery** – Automatic plugin detection at startup
- **Node-Based Integration** – Plugins communicate via node graph

---

## Module System (Planned)

Modules are shared service libraries that plugins can depend on. The module system is in research phase.

### Planned Structure
- **Core Modules** – Authentication, logging, data access
- **Shared Services** – Cross-plugin utilities
- **Version Management** – Module versioning and compatibility

Currently, all "modules" are implemented as services in `Program.cs`.

---

---

**Navigation**

- **[← Getting Started](rootserver-02-getting-started.md)**
- **[Technology Stack →](rootserver-04-tech-stack.md)**
- **[Home](rootserver.md)**

---
