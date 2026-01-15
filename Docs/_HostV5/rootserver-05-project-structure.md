# Project Structure

---

## Root Structure

```text
RootServer/
├── Pages/                   # Blazor pages (routing endpoints)
├── Shared/                  # Component hierarchy (main codebase)
│   ├── _Core/              # Foundation layer
│   ├── _Editor/            # Development tools layer
│   ├── _Sites/             # Public UI layer
│   ├── _Projects/          # Project-specific implementations
│   ├── _Modules/           # Planned: shared services
│   └── Plugins/            # Plugin implementations
├── Json/                    # Airtable data cache
├── wwwroot/                 # Static assets
├── Design/                  # Design utilities
├── Properties/              # Application properties
├── Program.cs              # Application startup
├── App.razor               # Blazor root component
├── _Imports.razor          # Global Razor imports
├── appsettings.json        # Configuration
└── RootServer.csproj       # Project file
```

---

## Pages Directory

### Purpose
Blazor routing endpoints that serve as application entry points.

### Contents
- `Index.razor` / `Index.razor.cs` – Public homepage
- `Editor.razor` / `Editor.razor.cs` – Internal development interface
- `TestPage.razor` / `TestPage.razor.cs` – Component testing page
- `Error.cshtml` / `Error.cshtml.cs` – Error handling page

---

## Shared Directory

### _Core Layer (`Shared/_Core`)

Foundation components used across all layers.

```text
_Core/
├── 00_Core/                 # System primitives
│   ├── Events/             # Custom event definitions
│   ├── Enums/              # Shared enumerations
│   └── BehaviourTree/      # Behavior tree system (planned)
├── 01_Displays/            # Read-only output components
├── 02_Fields/              # Input components
│   ├── _Core/             # Base field implementations
│   └── _Help/             # Field helper utilities
├── 03_Pointers/            # Interaction triggers
│   ├── _Core/             # Base pointer implementations
│   └── _Help/             # Pointer utilities
├── 04_Actions/             # Core actions
│   └── _Core/             # Base action implementations
├── 05_Nodes/               # Node graph (planned)
├── 06_Components/          # Composed layouts
│   └── Test/              # Test components
├── 07_Widgets/             # Container layouts
│   └── SurveyPrompt/      # Survey widget
├── 08_View/                # View definitions
└── 09_Panels/              # High-level panels
```

**File Count**: ~40 components across all layers

---

### _Editor Layer (`Shared/_Editor`)

Internal development tooling.

```text
_Editor/
├── 00_Core/                 # Editor system classes
│   ├── Data/               # Editor data models
│   └── Events/             # Editor-specific events
├── 01_Displays/            # Editor displays
├── 02_Fields/              # Editor input fields
├── 02_Properties/          # Property editors
├── 03_Pointers/            # Editor UI triggers
├── 04_Actions/             # Editor actions
├── 05_Nodes/               # Editor nodes (planned)
├── 06_Components/          # Editor composite components
├── 07_Widgets/             # Editor layout containers
├── 08_View/                # Editor view definitions
│   └── _Core/             # Base view implementations
└── 09_Panels/              # Editor panel groupings
    └── _Core/             # Base panel implementations
```

**File Count**: ~35 components

---

### _Sites Layer (`Shared/_Sites`)

Public-facing website UI.

```text
_Sites/
├── Components/              # Site-specific components
│   └── Background/         # Background components
│       └── _Core/         # Background types (Image, Video, Lottie, etc.)
├── Layouts/                # Page layout definitions
├── Nav/                    # Navigation components
│   ├── MainPages/         # Main navigation
│   └── Section/           # Section navigation
├── Pages/                  # Page components
│   └── _Core/             # Base page implementations
│       ├── Base/          # BasePage class
│       └── Static/        # Static utilities
└── Sections/               # Reusable sections
    ├── About/             # About section
    ├── Agenda/            # Agenda section
    ├── Contact/           # Contact section
    ├── Dish/              # Dish section
    ├── Gallery/           # Gallery section
    ├── Welcome/           # Welcome section
    ├── Widgets/           # Section widgets
    └── _Core/             # Base section implementations
        ├── Base/          # SectionBase class
        └── Wrappers/      # Section wrapper components
```

**File Count**: ~30 components

---

### Plugins Directory (`Shared/Plugins`)

Plugin implementations following host hierarchy.

```text
Plugins/
└── Airtable/                # Airtable plugin
    ├── 00_Core/            # Airtable system classes
    │   ├── Tables/        # Table model definitions
    │   ├── Enums/         # Airtable enums
    │   └── Static/        # Static utilities
    ├── 01_Displays/        # Airtable displays
    ├── 02_Fields/          # Airtable fields
    ├── 03_Pointers/        # Airtable pointers
    ├── 04_Actions/         # Airtable actions
    │   └── _Core/         # Base action implementations
    ├── 05_Nodes/           # Airtable nodes (planned)
    ├── 06_Components/      # Airtable components
    ├── 07_Widgets/         # Airtable widgets
    ├── 08_View/            # Airtable views
    └── 09_Panels/          # Airtable panels
```

**File Count**: ~50 components (Airtable plugin)

---

## Json Directory

Local cache of Airtable data.

### Key Files
- `pages.json` – Page definitions and routing
- `sections.json` – Section configurations
- `tables.json` – Airtable table metadata
- `agenda.json`, `gallery.json`, `text.json`, etc. – Table data caches

### Duplicate Files (To Be Cleaned)
- `galleryJson.json` vs `gallery.json`
- `textJson.json` vs `text.json`

See **[Duplicate JSON Cleanup](rootserver-55-appendix-duplicate-json-cleanup.md)** for remediation plan.

---

## wwwroot Directory

Static assets served directly to clients.

```text
wwwroot/
├── css/                     # Stylesheets
│   ├── blazorise/          # Blazorise styles
│   └── webflow/            # Webflow integration styles
├── js/                      # JavaScript files
│   └── webflow/            # Webflow scripts
├── gfx/                     # Graphics and images
├── lottie/                  # Lottie animation files
├── spline/                  # Spline 3D assets
├── svg/                     # SVG graphics
└── unity/                   # Unity3D build outputs (future)
```

---

## Configuration Files

### Program.cs
Application entry point and service registration.

Key responsibilities:
- Service DI registration
- Middleware pipeline configuration
- `Blazorise` initialization
- `AirtableConfig` setup

### appsettings.json / appsettings.Development.json
Application configuration including:
- `Airtable API` credentials
- Logging configuration
- Environment-specific settings

### _Imports.razor
Global Razor imports for all components.

---

## File Statistics

Based on project scan:
- **Total .cs files**: 206
- **Total .razor files**: 126
- **Total directories**: 114
- **JSON cache files**: ~25

---

---

**Navigation**

- **[← Technology Stack](rootserver-04-tech-stack.md)**
- **[Component Model →](rootserver-06-component-model.md)**
- **[Home](rootserver.md)**

---
