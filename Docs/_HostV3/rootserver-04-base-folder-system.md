# Base Folder System

---

## Top-Level Layout

RootServer follows a structured folder organization that separates concerns and enables modular development.

```
RootServer/
├── Program.cs                    # Host entry point
├── App.razor                     # Root Blazor component
├── Pages/                        # Blazor pages
│   ├── Editor.razor             # Main editor UI
│   ├── Index.razor              # Landing page
│   ├── TestPage.razor           # Test/development page
│   └── _Host.cshtml             # Blazor Server host page
├── Shared/                       # Component library (main architecture)
│   ├── _Core/                   # Foundation layer
│   ├── _Editor/                 # Editor environment
│   ├── _Modules/                # Module infrastructure
│   ├── _Projects/               # Project-specific implementations
│   ├── _Sites/                  # Public website components
│   └── Plugins/                 # Plugin implementations
│       └── Airtable/            # Airtable integration plugin
├── Json/                        # Cached JSON schemas
├── wwwroot/                     # Static assets
├── Design/                      # Design resources
└── Properties/                  # Launch settings
```

---

## Shared/ Folder Structure

The `Shared/` folder contains the core architecture, organized by purpose:

### _Core (Foundation)

**Purpose:** Foundational services, base classes, and core UI patterns

**Structure:** Implements full 00-09 layer system

```
Shared/_Core/
├── 00_Core/         # Enums, Events, Services
│   ├── Enums/       # StateVisibility and others
│   └── Events/      # Pointer_Service
├── 01_Displays/     # [Not yet implemented]
├── 02_Fields/       # Form inputs (F_* components)
│   ├── _Core/       # Base classes and wrappers
│   └── F_*.razor    # Field components
├── 03_Pointers/     # Interaction helpers (HP_* components)
├── 04_Actions/      # User/system actions
│   ├── _Core/       # ABase, APreBase, APostBase
│   └── A_*.razor    # Action components
├── 05_Nodes/        # [Not yet implemented]
├── 06_Components/   # Composed layouts (CP_* components)
├── 07_Widgets/      # Widget containers
├── 08_View/         # [Not yet implemented]
└── 09_Panels/       # [Not yet implemented]
```

---

### _Editor (Editor Environment)

**Purpose:** Internal editor UI for runtime inspection

**Structure:** Mirrors 00-09 layer system

```
Shared/_Editor/
├── 00_Core/         # Editor services
│   ├── EditorView_Service
│   ├── EditorVisibility_Service
│   └── LogCatcher_Service
├── 01_Displays/     # Editor-specific displays
├── 02_Fields/       # Editor fields
├── 02_Properties/   # Property editors (additional layer)
├── 03_Pointers/     # Editor pointers and selectors
├── 04_Actions/      # Editor actions
├── 05_Nodes/        # [Planned - Node editor]
├── 06_Components/   # Editor components
├── 07_Widgets/      # Editor widgets
├── 08_View/         # Editor views
└── 09_Panels/       # Editor panels
```

---

### _Sites (Public Website)

**Purpose:** Public-facing website with section-based composition

**Structure:**
```
Shared/_Sites/
├── Components/      # Reusable components
│   └── Background/  # Background components
├── Layouts/         # Page layout definitions
├── Nav/             # Navigation components
│   ├── MainPages/   # Main navigation
│   └── Section/     # Section navigation
├── Pages/           # Page definitions
│   └── _Core/       # Page base classes
└── Sections/        # Content sections
    ├── About/
    ├── Agenda/
    ├── Contact/
    ├── Dish/
    ├── Gallery/
    ├── Welcome/
    ├── Widgets/
    └── _Core/       # Section base classes
```

---

### Plugins/ (Plugin Implementations)

**Purpose:** Self-contained plugin implementations

**Structure:** Plugins implement subsets of 00-09 layers as needed

```
Shared/Plugins/
└── Airtable/        # Airtable integration plugin
    ├── 03_Pointers/ # P_* components (selection)
    ├── 04_Actions/  # A_* components (sync, create)
    ├── 06_Components/  # C_* components (display)
    └── 09_Panels/   # PNL_* components (editor panels)
```

**Note:** Plugins don't need all layers. Airtable implements only 03, 04, 06, 09.

---

### _Modules/ (Module Infrastructure)

**Purpose:** Module system infrastructure (planned)

**Current Status:** Minimal implementation; folder exists for future development

---

### _Projects/ (Project-Specific)

**Purpose:** Project-specific implementations

**Example:** `FoodEscape/` - specific project implementation

---

## Discovered 00-09 Layer System

The layer system appears in **three contexts** within RootServer:

1. **Shared/_Core** - Foundation layer (some layers empty)
2. **Shared/_Editor** - Editor environment (most layers present)
3. **Shared/Plugins/Airtable** - Plugin implementation (selective layers)

### Layer Implementation Status

| Layer | _Core | _Editor | Airtable Plugin |
|-------|-------|---------|-----------------|
| 00_Core | ✓ Implemented | ✓ Implemented | ✗ Not needed |
| 01_Displays | ✗ Empty | ? Unknown | ✗ Not needed |
| 02_Fields | ✓ Implemented | ? Unknown | ✗ Not needed |
| 03_Pointers | ⚠ Partial | ? Unknown | ✓ Implemented |
| 04_Actions | ✓ Implemented | ? Unknown | ✓ Implemented |
| 05_Nodes | ✗ Empty | ⚠ Planned | ✗ Not needed |
| 06_Components | ✓ Implemented | ? Unknown | ✓ Implemented |
| 07_Widgets | ⚠ Minimal | ? Unknown | ✗ Not needed |
| 08_View | ✗ Empty | ? Unknown | ✗ Not needed |
| 09_Panels | ✗ Empty | ? Unknown | ✓ Implemented |

**Legend:**
- ✓ Implemented with components
- ⚠ Partial/minimal implementation
- ✗ Empty or not present
- ? Unknown (requires deeper inspection)

---

## Folder Naming Conventions

### Underscore Prefix

Framework folders use underscore prefix: `_Core`, `_Editor`, `_Modules`, `_Sites`, `_Projects`

**Rationale:** Visual distinction from application-level folders and plugins.

### Numbered Layers

Layer folders use `00_` through `09_` prefix for ordering:
- `00_Core` sorts first
- `09_Panels` sorts last
- Enforces visual hierarchy

### Nested _Core Folders

Many layers contain their own `_Core/` subfolder for:
- Base classes
- Shared infrastructure
- Wrapper components

**Example:** `02_Fields/_Core/` contains `FieldBase`, `FW_Group`, `FW_Main`

---

## Key Conventions Discovered

1. **Layer selectivity:** Not all contexts need all layers (Airtable uses only 4 of 10)
2. **Base class centralization:** Each layer's `_Core/` subfolder contains foundational types
3. **Naming consistency:** Prefixes indicate layer (F_, P_, A_, C_, PNL_)
4. **Nested organization:** `_Help/` subfolders for utility components

---

[← Back to Base Index](rootserver-00-base-index.md)

---
