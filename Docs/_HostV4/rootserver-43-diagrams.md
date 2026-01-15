# Diagrams

**Comprehensive Visual Documentation**  
This page contains extensive text-based ASCII diagrams covering all aspects of RootServer's architecture, dependencies, data flows, and component relationships.

---

## Diagram Index

1. [System Architecture Overview](#1-system-architecture-overview)
2. [Core Class Hierarchy](#2-core-class-hierarchy)
3. [UI Component Inheritance Tree](#3-ui-component-inheritance-tree)
4. [Service Class Hierarchy](#4-service-class-hierarchy)
5. [Top-Down Layer Dependencies](#5-top-down-layer-dependencies)
6. [Module and Plugin Dependencies](#6-module-and-plugin-dependencies)
7. [Airtable Sync Data Flow](#7-airtable-sync-data-flow)
8. [UI Rendering Pipeline](#8-ui-rendering-pipeline)
9. [State Update Flow](#9-state-update-flow)
10. [Service Dependency Graph](#10-service-dependency-graph)
11. [Component Composition Pattern](#11-component-composition-pattern)
12. [User Action Sequence](#12-user-action-sequence)
13. [System Initialization Sequence](#13-system-initialization-sequence)
14. [Layer Structure (00-09)](#14-layer-structure-00-09)
15. [Physical Folder Structure](#15-physical-folder-structure)
16. [Deployment Topology](#16-deployment-topology)
17. [Prefix System Map](#17-prefix-system-map)
18. [JSON Cache Architecture](#18-json-cache-architecture)

---

## 1. System Architecture Overview

Overall system showing Host, Plugins, Editor, Sites, and external integrations.

```text
┌─────────────────────────────────────────────────────────────────┐
│                      RootServer Host                            │
│                                                                 │
│  ┌──────────────┐      ┌─────────────────┐      ┌────────────┐  │
│  │ Program.cs   │─────>│ Scoped Services │─────>│   _Core    │  │
│  │ Bootstrap &  │      │ Pointer, Editor │      │Foundation  │  │
│  │     DI       │      │   LogCatcher    │      │00-09 Layers│  │
│  └──────────────┘      └─────────────────┘      └──────┬─────┘  │
│                                                        │        │
└────────────────────────────────────────────────────────┼────────┘
                                                         │
                        ┌────────────────────────────────┼────────────────┐
                        │                                │                │
                        ▼                                ▼                ▼
         ┌──────────────────────┐          ┌──────────────────┐  ┌─────────────┐
         │   Airtable Plugin    │          │     _Editor      │  │   _Sites    │
         │  03,04,06,09 Layers  │          │  00-09 Layers    │  │ Section-    │
         └──────────┬───────────┘          └──────────────────┘  │   based     │
                    │                                            └─────────────┘
                    │
         ┌──────────┴─────────────┐
         │                        │
         ▼                        ▼
  ┌─────────────┐          ┌─────────────┐
  │ Airtable API│          │ JSON Cache  │
  │  (External) │          │  (Local)    │
  └─────────────┘          └─────────────┘
```

**Key Relationships:**
- `Program.cs` bootstraps DI container and initializes services
- Scoped services (`Pointer`, `Editor`, `LogCatcher`) provide state management
- _`Core` foundation provides base classes for all other contexts
- `Airtable` plugin integrates with external API and local JSON cache
- `Editor` and `Sites` build on top of _`Core` foundation

---

## 2. Core Class Hierarchy

Inheritance tree for foundational base classes in `Shared/_Core/`.

```text
                    ┌─────────────────┐
                    │  ComponentBase  │
                    │   (Blazor BCL)  │
                    └────────┬────────┘
                             │
              ┌──────────────┴──────────────┐
              │                             │
              ▼                             ▼
     ┌────────────────┐           ┌────────────────┐
     │   FieldBase    │           │    ABase       │
     │ (02_Fields)    │           │ (04_Actions)   │
     └────────┬───────┘           └────────┬───────┘
              │                            │
       ┌──────┴──────┐            ┌────────┴────────┐
       │             │            │                 │
       ▼             ▼            ▼                 ▼
┌──────────┐  ┌──────────┐  ┌──────────┐    ┌──────────┐
│FieldBase │  │FieldBase │  │APreBase  │    │APostBase │
│ _String  │  │ _Numeric │  │          │    │          │
└────┬─────┘  └────┬─────┘  └──────────┘    └────┬─────┘
     │             │                              │
     ▼             ▼                              ▼
┌─────────┐   ┌─────────┐               ┌────────────────┐
│ BaseF_  │   │FieldBase│               │ APostBase_     │
│  Text   │   │  _Date  │               │  LogCatcher    │
└─────────┘   └─────────┘               └────────────────┘
```

**Legend:**
- Solid lines: inheritance relationships
- Classes shown with their layer location
- Base classes provide common functionality for derived components

---

## 3. UI Component Inheritance Tree

Component hierarchy showing how UI elements inherit from base classes.

```text
                        ┌────────────────┐
                        │  ComponentBase │
                        └────────┬───────┘
                                 │
                    ┌────────────┴──────────┐
                    │                       │
                    ▼                       ▼
            ┌───────────────┐        ┌──────────────┐
            │   FieldBase   │        │ PointerBase  │
            │  (02_Fields)  │        │(03_Pointers) │
            └───────┬───────┘        └──────┬───────┘
                    │                       │
         ┌──────────┼──────────┐            │
         │          │          │            │
         ▼          ▼          ▼            ▼
   ┌─────────┐ ┌────────┐ ┌────────┐  ┌─────────┐
   │F_Text_  │ │F_Color │ │F_Toggle│  │P_Table  │
   │  Email  │ │        │ │ Switch │  │         │
   └─────────┘ └────────┘ └────────┘  └────┬────┘
                                           │
                                      ┌────┴────┐
                                      │         │
                                      ▼         ▼
                                 ┌────────┐ ┌────────┐
                                 │P_Row   │ │P_Field │
                                 └────────┘ └────────┘
```

**Component Pattern:**
- All UI components ultimately derive from Blazor's ComponentBase
- Field components extend FieldBase with type-specific implementations
- Pointer components extend PointerBase for selection management

---

## 4. Service Class Hierarchy

Scoped service relationships and dependencies.

```text
┌─────────────────┐
│   IServiceBase  │  (Conceptual Interface)
└────────┬────────┘
         │
    ┌────┴─────────────────────────────┐
    │                                  │
    ▼                                  ▼
┌────────────────────┐      ┌────────────────────────┐
│ Pointer_Service    │      │ EditorView_Service     │
│ (Selection State)  │      │ (Editor State)         │
└────────────────────┘      └────────────────────────┘
         │                           │
         │ Used by                   │ Used by
         ▼                           ▼
┌────────────────────┐      ┌────────────────────────┐
│ P_* Components     │      │ _Editor Components     │
│ (Pointers)         │      │                        │
└────────────────────┘      └────────────────────────┘

┌────────────────────────┐  ┌─────────────────────────┐
│ LogCatcher_Service     │  │EditorVisibility_Service │
│ (Log Capture)          │  │(Visibility Control)     │
└────────────────────────┘  └─────────────────────────┘
         │                           │
         │ Used by                   │ Used by
         ▼                           ▼
┌────────────────────────┐  ┌─────────────────────────┐
│ APostBase_LogCatcher   │  │ Editor UI Components    │
│ (Action Post-Hook)     │  │                         │
└────────────────────────┘  └─────────────────────────┘
```

**Service Lifetime:** All services are scoped (per SignalR circuit)

---

## 5. Top-Down Layer Dependencies

Vertical dependency flow showing how layers depend on each other.

```text
┌──────────────────────────────────────────────┐
│             09_Panels (Top)                  │
│          Editor Panels, Layout               │
└───────────────────┬──────────────────────────┘
                    │ depends on
                    ▼
┌──────────────────────────────────────────────┐
│        08_View / 07_Widgets                  │
│      View Layouts, Widget Containers         │
└───────────────────┬──────────────────────────┘
                    │ depends on
                    ▼
┌──────────────────────────────────────────────┐
│            06_Components                     │
│        Composed UI Components                │
└───────────────────┬──────────────────────────┘
                    │ depends on
                    ▼
┌──────────────────────────────────────────────┐
│ 05_Nodes / 04_Actions / 03_Pointers /        │
│        02_Fields / 01_Displays               │
│           Atomic UI Elements                 │
└───────────────────┬──────────────────────────┘
                    │ depends on
                    ▼
┌──────────────────────────────────────────────┐
│              00_Core (Bottom)                │
│    Services, Base Classes, Events            │
└──────────────────────────────────────────────┘
```

**Dependency Rule:** Higher layers depend on lower layers; reverse is forbidden.

---

## 6. Module and Plugin Dependencies

Horizontal dependency relationships between modules and plugins.

```text
┌────────────┐              ┌────────────┐
│    Host    │              │  _Modules  │
│  (Program  │◄─────────────│ (Planned)  │
│   .cs)     │  Provides    │            │
└─────┬──────┘  Services    └────────────┘
      │
      │ Provides Extension Points
      │
      ├──────────────────────┬───────────────────┐
      │                      │                   │
      ▼                      ▼                   ▼
┌──────────────┐      ┌──────────────┐   ┌──────────────┐
│   _Core      │      │   _Editor    │   │   _Sites     │
│ Foundation   │      │ Environment  │   │ Public UI    │
└──────┬───────┘      └──────┬───────┘   └──────────────┘
       │                     │
       │ Consumed by         │ Consumed by
       │                     │
       ▼                     ▼
┌──────────────────────────────────────┐
│        Airtable Plugin               │
│  (Implements: 03, 04, 06, 09)        │
└──────────────────────────────────────┘
```

**Dependency Policy:**
- `Host` → _`Core`, _`Editor`, _`Sites` (allowed)
- `Plugin` → `Host services`, `_Core` (allowed)
- `Host` → `Plugin` (forbidden - maintains decoupling)

---

## 7. Airtable Sync Data Flow

Step-by-step data flow from `Airtable API` to rendered UI.

```text
┌──────┐
│ User │
└───┬──┘
    │ 1. Click Sync Button
    ▼
┌────────────────┐
│ Editor Panel   │
└───┬────────────┘
    │ 2. Invoke A_AirtableSync
    ▼
┌────────────────────┐
│ A_AirtableSync     │
│   (Action)         │
└───┬────────────────┘
    │ 3. HTTP Request
    ▼
┌────────────────────┐
│  Airtable API      │
│  (External)        │
└───┬────────────────┘
    │ 4. Return JSON (Schemas, Data)
    ▼
┌────────────────────┐
│ A_AirtableSync     │
│ (Parse Response)   │
└───┬────────────────┘
    │ 5. Write to Disk
    ▼
┌────────────────────┐
│ Json/ Folder       │
│ (Local Cache)      │
└───┬────────────────┘
    │ 6. Read Cached Files
    ▼
┌────────────────────┐
│ Schema Parser      │
│ (Deserialize)      │
└───┬────────────────┘
    │ 7. Create Component Tree
    ▼
┌────────────────────┐
│ UI Components      │
│ (F_, P_, C_)       │
└───┬────────────────┘
    │ 8. Render via Blazor
    ▼
┌────────────────────┐
│ Browser DOM        │
│ (SignalR Updates)  │
└───┬────────────────┘
    │ 9. Display to User
    ▼
┌──────┐
│ User │
└──────┘
```

**Key Observation:** `JSON cache` enables offline development and fast iteration.

---

## 8. UI Rendering Pipeline

How `Blazor` components render from state to browser.

```text
┌────────────────────┐
│ Service State      │
│ (Pointer, Editor)  │
└─────────┬──────────┘
          │ State Change Event
          ▼
┌────────────────────┐
│ Component          │
│ StateHasChanged()  │
└─────────┬──────────┘
          │ Trigger Re-render
          ▼
┌────────────────────┐
│ Blazor Render      │
│ Engine (Server)    │
└─────────┬──────────┘
          │ Calculate DOM Diff
          ▼
┌────────────────────┐
│ SignalR Hub        │
│ (Server → Client)  │
└─────────┬──────────┘
          │ Send Update Commands
          ▼
┌────────────────────┐
│ Browser SignalR    │
│ Client             │
└─────────┬──────────┘
          │ Apply DOM Changes
          ▼
┌────────────────────┐
│ Browser DOM        │
│ (Updated UI)       │
└────────────────────┘
```

**Performance Note:** Only `DOM` diffs are sent over `SignalR`, not full re-renders.

---

## 9. State Update Flow

How user actions propagate through services to update UI state.

```text
User Clicks          Component Handles       Service Updates
   Button               Event                   State

┌────────┐           ┌───────────┐          ┌──────────────┐
│ Click  │──────────>│ @onclick  │─────────>│ Service.     │
│ P_Table│           │  Handler  │          │ SelectTable()│
└────────┘           └───────────┘          └───────┬──────┘
                                                    │
                                            Update Internal State
                                                    │
                                                    ▼
                                          ┌──────────────────┐
                                          │ OnSelectionChange│
                                          │  Event Raised    │
                                          └─────────┬────────┘
                                                    │
                          ┌─────────────────────────┼─────────────────────┐
                          │                         │                     │
                          ▼                         ▼                     ▼
                   ┌──────────────┐         ┌──────────────┐      ┌──────────────┐
                   │ Subscribed   │         │ Subscribed   │      │ Subscribed   │
                   │ Component A  │         │ Component B  │      │ Component C  │
                   └──────┬───────┘         └──────┬───────┘      └──────┬───────┘
                          │                        │                     │
                    StateHasChanged()        StateHasChanged()     StateHasChanged()
                          │                        │                     │
                          └────────────────────────┴─────────────────────┘
                                                   │
                                                   ▼
                                          ┌──────────────────┐
                                          │ Blazor Re-render │
                                          │  All Subscribers │
                                          └──────────────────┘
```

---

## 10. Service Dependency Graph

How scoped services depend on each other.

```text
Program.cs
    │
    │ Registers in DI Container
    │
    ├──────────────────┬────────────────────┬───────────────────┐
    │                  │                    │                   │
    ▼                  ▼                    ▼                   ▼
┌─────────────┐  ┌──────────────┐  ┌──────────────┐  ┌─────────────────┐
│  Pointer_   │  │ LogCatcher_  │  │ EditorView_  │  │EditorVisibility_│
│  Service    │  │  Service     │  │  Service     │  │   Service       │
└─────┬───────┘  └──────┬───────┘  └──────┬───────┘  └────────┬────────┘
      │                 │                 │                   │
      │ Injected into   │ Injected into   │ Injected into     │ Injected into
      │                 │                 │                   │
      ▼                 ▼                 ▼                   ▼
┌──────────────────────────────────────────────────────────────────┐
│                    UI Components                                 │
│     P_Table, P_Row, P_Field, C_TableAir, PNL_Structure, etc.     │
└──────────────────────────────────────────────────────────────────┘
```

**Pattern:** Services registered as Scoped (per-circuit), injected via @inject directive.

---

## 11. Component Composition Pattern

How atomic components compose into larger UI structures.

```text
                    ┌────────────────────────┐
                    │   PNL_Structure        │
                    │  (09_Panels)           │
                    └───────────┬────────────┘
                                │ Contains
                    ┌───────────┴────────────┐
                    │                        │
                    ▼                        ▼
          ┌──────────────────┐     ┌──────────────────┐
          │  C_TableAir      │     │  C_Rows          │
          │  (06_Components) │     │  (06_Components) │
          └─────────┬────────┘     └─────────┬────────┘
                    │                        │
        ┌───────────┴────────┐               │ Contains
        │                    │               │
        ▼                    ▼               ▼
┌──────────────┐    ┌──────────────┐  ┌───────────────┐
│  P_Table     │    │  A_TableVars │  │ C_RowSingle   │
│(03_Pointers) │    │ (04_Actions) │  │(06_Components)│
└──────────────┘    └──────────────┘  └───────┬───────┘
                                              │ Contains
                                  ┌───────────┴────────┐
                                  │                    │
                                  ▼                    ▼
                           ┌──────────────┐    ┌──────────────┐
                           │  F_Text_*    │    │  P_Field     │
                           │ (02_Fields)  │    │(03_Pointers) │
                           └──────────────┘    └──────────────┘
```

**Composition Pattern:** Higher layers compose lower layers to build complex UI.

---

## 12. User Action Sequence

Step-by-step sequence for a typical user interaction.

```text
  User          UI (P_Table)    Pointer_Service    Backend    UI (C_TableAir)
   │                │                 │              │              │
   │                │                 │              │              │
   │ Click Table    │                 │              │              │
   │───────────────>│                 │              │              │
   │                │                 │              │              │
   │                │ SelectTable()   │              │              │
   │                │────────────────>│              │              │
   │                │                 │              │              │
   │                │                 │ Update State │              │
   │                │                 │──────────┐   │              │
   │                │                 │          │   │              │
   │                │                 │<─────────┘   │              │
   │                │                 │              │              │
   │                │                 │ Raise Event  │              │
   │                │                 │──────────────┼─────────────>│
   │                │                 │              │              │
   │                │                 │              │ StateHasChanged()
   │                │                 │              │              │
   │                │                 │              │ Re-render    │
   │                │                 │              │◄─────────────│
   │                │                 │              │              │
   │                │                 │ Update DOM via SignalR      │
   │<────────────────────────────────────────────────────────────────
   │                │                 │              │              │
   │ See Updated UI │                 │              │              │
```

**Key Steps:**
1. User interaction captured by `component`
2. `Component` calls `service method`
3. `Service` updates `internal state`
4. `Service` raises `event`
5. Subscribers receive `notification and re-render`
6. `Blazor` sends `DOM` updates via `SignalR`

---

## 13. System Initialization Sequence

Application startup and dependency injection sequence.

```text
Main()
  │
  │ 1. Create WebApplicationBuilder
  ▼
builder = WebApplication.CreateBuilder(args)
  │
  │ 2. Register Blazor Services
  ▼
builder.Services.AddRazorPages()
builder.Services.AddServerSideBlazor()
  │
  │ 3. Register Application Services (Scoped)
  ▼
builder.Services.AddScoped<Pointer_Service>()
builder.Services.AddScoped<LogCatcher_Service>()
builder.Services.AddScoped<EditorView_Service>()
builder.Services.AddScoped<EditorVisibility_Service>()
  │
  │ 4. Register Blazorise + Tailwind
  ▼
builder.Services.AddBlazorise(...)
                .AddTailwindProviders()
                .AddFontAwesomeIcons()
  │
  │ 5. Build Application
  ▼
app = builder.Build()
  │
  │ 6. Configure Middleware Pipeline
  ▼
app.UseHttpsRedirection()
app.UseStaticFiles()
app.UseRouting()
  │
  │ 7. Initialize Airtable Configuration
  ▼
AirtableConfig.Initialize(builder.Configuration)
  │
  │ 8. Map Blazor Endpoints
  ▼
app.MapBlazorHub()
app.MapFallbackToPage("/_Host")
  │
  │ 9. Run Application
  ▼
app.Run()
  │
  │ 10. User Connects → SignalR Circuit Created
  │     → Scoped Services Instantiated
  ▼
[Application Running]
```

---

## 14. Layer Structure (00-09)

The cross-layer hierarchy showing `micro` to `macro` progression.

```text
                    Macro (High-Level)
                            ▲
                            │
┌───────────────────────────┼───────────────────────────┐
│                           │                           │
│   ┌───────────────────────┴──────────────────────┐    │
│   │         09_Panels (Highest)                  │    │
│   │      Editor Panels, Navigation Shells        │    │
│   └────────────────────┬─────────────────────────┘    │
│                        │                              │
│   ┌────────────────────┴─────────────────────────┐    │
│   │      08_View / 07_Widgets                    │    │
│   │    View Layouts, Widget Containers           │    │
│   └────────────────────┬─────────────────────────┘    │
│                        │                              │
│   ┌────────────────────┴─────────────────────────┐    │
│   │          06_Components                       │    │
│   │      Composed Layouts & Patterns             │    │
│   └────────────────────┬─────────────────────────┘    │
│                        │                              │
│   ┌────────────────────┴─────────────────────────┐    │
│   │  05_Nodes / 04_Actions / 03_Pointers         │    │
│   │     02_Fields / 01_Displays                  │    │
│   │        Atomic UI Elements                    │    │
│   └────────────────────┬─────────────────────────┘    │
│                        │                              │
│   ┌────────────────────┴─────────────────────────┐    │
│   │          00_Core (Lowest)                    │    │
│   │   Services, Base Classes, Events, Enums      │    │
│   └──────────────────────────────────────────────┘    │
│                                                       │
└───────────────────────────────────────────────────────┘
                            │
                            ▼
                    Micro (Low-Level)
```

**Design Principle:** Each layer depends only on layers below it.

---

## 15. Physical Folder Structure

Physical organization of `files` and `folders` in the repository.

```text
RootServer/
├── Program.cs
├── App.razor
├── Pages/
│   ├── Editor.razor
│   ├── Index.razor
│   ├── TestPage.razor
│   └── _Host.cshtml
├── Shared/
│   ├── _Core/
│   │   ├── 00_Core/
│   │   │   ├── Enums/
│   │   │   └── Events/
│   │   ├── 01_Displays/     [empty]
│   │   ├── 02_Fields/
│   │   │   ├── _Core/
│   │   │   │   ├── Base/
│   │   │   │   └── Wrappers/
│   │   │   ├── F_Text_*.razor
│   │   │   ├── F_Color.razor
│   │   │   └── F_Toggle_Switch.razor
│   │   ├── 03_Pointers/
│   │   ├── 04_Actions/
│   │   ├── 05_Nodes/        [empty]
│   │   ├── 06_Components/
│   │   ├── 07_Widgets/
│   │   ├── 08_View/         [empty]
│   │   └── 09_Panels/       [empty]
│   ├── _Editor/
│   │   └── 00-09 layers
│   ├── _Sites/
│   │   ├── Components/
│   │   ├── Layouts/
│   │   ├── Nav/
│   │   ├── Pages/
│   │   └── Sections/
│   ├── _Modules/            [minimal]
│   ├── _Projects/
│   │   └── FoodEscape/
│   └── Plugins/
│       └── Airtable/
│           ├── 03_Pointers/
│           ├── 04_Actions/
│           ├── 06_Components/
│           └── 09_Panels/
├── Json/
│   ├── pages.json
│   ├── pagesJson.json       [DUPLICATE]
│   ├── tables.json
│   ├── tablesJson.json      [DUPLICATE]
│   └── ...
├── wwwroot/
│   ├── css/
│   ├── js/
│   ├── gfx/
│   └── ...
├── appsettings.json
└── RootServer.csproj
```

---

## 16. Deployment Topology

How the application deploys across different environments.

```text
┌─────────────────────────────────────────────────────────────────┐
│                     LOCAL DEVELOPMENT                           │
│                                                                 │
│  ┌──────────────┐                                               │
│  │  Developer   │                                               │
│  │   Machine    │                                               │
│  └──────┬───────┘                                               │
│         │ dotnet run                                            │
│         ▼                                                       │
│  ┌─────────────────────┐        ┌──────────────────┐            │
│  │  Local Blazor Server│───────>│  Local JSON      │            │
│  │  (localhost:5001)   │        │  Cache (Json/)   │            │
│  └──────────┬──────────┘        └──────────────────┘            │
│             │                                                   │
│             │ HTTPS Requests                                    │
│             ▼                                                   │
└─────────────┼───────────────────────────────────────────────────┘
              │
              │
┌─────────────┼───────────────────────────────────────────────────┐
│             │              CLOUD (Azure)                        │
│             │                                                   │
│  ┌──────────┴───────────┐                                       │
│  │   CI/CD Pipeline     │                                       │
│  │ (GitHub Actions /    │                                       │
│  │  Azure DevOps)       │                                       │
│  └──────────┬───────────┘                                       │
│             │ dotnet publish                                    │
│             ▼                                                   │
│  ┌───────────────────────┐       ┌────────────────┐             │
│  │  Azure App Service    │──────>│  Azure Blob    │             │
│  │  (Production)         │       │  Storage       │             │
│  └──────────┬────────────┘       │  (JSON Cache)  │             │
│             │                    └────────────────┘             │
│             │                                                   │
│             ├───────────────────>┌────────────────┐             │
│             │                    │ Application    │             │
│             │                    │   Insights     │             │
│             │                    │ (Monitoring)   │             │
│             │                    └────────────────┘             │
│             │                                                   │
└─────────────┼───────────────────────────────────────────────────┘
              │
              │ HTTPS Requests
              ▼
      ┌──────────────────┐
      │  Airtable API    │
      │   (External)     │
      └──────────────────┘
```

**Environments:**
- **Local:** Developer machine with local JSON cache
- **Production:** Azure App Service with Blob Storage and Application Insights

---

## 17. Prefix System Map

How component prefixes map to layers and roles.

```text
Prefix      Layer           Role              Examples
──────────────────────────────────────────────────────────────────
F_          02_Fields       Form Inputs       F_Text_Email
                                              F_Color
                                              F_Toggle_Switch

FW_         02_Fields       Field Wrappers    FW_Group
            _Core                             FW_Main

HP_         03_Pointers     Help Pointers     HP_CurrentItem
            _Help                             HP_Structure

P_          03_Pointers     Pointers          P_Table
                                              P_Row
                                              P_Field

A_          04_Actions      Actions           A_AirtableSync
                                              A_RowNew

ABase       04_Actions      Action Base       ABase
            _Core           Classes           APreBase
                                              APostBase

C_          06_Components   Components        C_TableAir
                                              C_RowSingle

CP_         06_Components   Component         CP_Dropdown
                           Patterns           CP_HeadContent

PNL_        09_Panels       Panels            PNL_Structure
                                              PNL_Selection

┌────────────────────────────────────────────────────────────┐
│  Pattern: {Prefix}_{ComponentName}                         │
│  Example: P_Table, F_Text_Email, C_TableAir                │
└────────────────────────────────────────────────────────────┘
```

---

## 18. JSON Cache Architecture

How `JSON caching` enables offline development and fast iteration.

```text
┌─────────────────────────────────────────────────────────────┐
│                     Airtable API (External)                 │
│  Tables: Workspaces, Tables, Pages, Sections, Settings      │
└──────────────────────┬──────────────────────────────────────┘
                       │
                       │ A_AirtableSync Action (Manual Trigger)
                       │
                       ▼
            ┌──────────────────────┐
            │   JSON Serializer    │
            └──────────┬───────────┘
                       │
                       │ Write to Disk
                       ▼
┌─────────────────────────────────────────────────────────────┐
│                    Json/ Folder (Local)                     │
│                                                             │
│  workspaces.json / workspacesJson.json  [DUPLICATE]         │
│  tables.json / tablesJson.json          [DUPLICATE]         │
│  pages.json / pagesJson.json            [DUPLICATE]         │
│  sections.json / sectionsJson.json      [DUPLICATE]         │
│  apps.json / appsJson.json              [DUPLICATE]         │
│  settings.json / settingsJson.json      [DUPLICATE]         │
│  ...                                                        │
└──────────────────────┬──────────────────────────────────────┘
                       │
                       │ Read on Component Initialization
                       │
                       ▼
            ┌──────────────────────┐
            │  JSON Deserializer   │
            └──────────┬───────────┘
                       │
                       │ Create Typed Models
                       ▼
            ┌──────────────────────┐
            │   UI Components      │
            │  (Schema-Driven)     │
            └──────────────────────┘

┌────────────────────────────────────────────────────────────────┐
│  Benefits:                                                     │
│  - Offline development (no API calls during local dev)         │
│  - Fast iteration (read from disk, not network)                │
│  - Consistent state (cached snapshot)                          │
│                                                                │
│  Risks:                                                        │
│  - Stale data if sync not triggered                            │
│  - Duplicate files (see Appendix 42 for cleanup plan)          │
│  - No atomic writes (potential corruption)                     │
└────────────────────────────────────────────────────────────────┘
```

---

[← Back to RootServer](rootserver.md)

1. **[Base](rootserver-00-base-index.md)** – conceptual foundations
2. **[Architecture](rootserver-12-arch-index.md)** – system design
3. **[UI](rootserver-26-ui-index.md)** – UI layers and patterns
4. **[Appendix](rootserver-39-appendix-index.md)** – risks and mappings
5. **Diagrams** – 18 comprehensive visual documentation diagrams

---
