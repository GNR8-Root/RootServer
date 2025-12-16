# Appendix – Plugin Folder Structure Mapping (Blazor / .NET)

This appendix explains how the Node Editor plugin’s **new Blazor/.NET files** should be placed into the **standard plugin folder structure** used by existing plugins (e.g. `Shared/Airtable`).

---

The goal is to keep responsibilities clean and predictable:
- **_Core** = foundations and contracts
- **Displays / Fields** = UI primitives
- **Pointers / Actions** = navigation + commands
- **Nodes** = graph domain
- **Components / Widgets / View / Panels** = composition layers

Static assets (JS/CSS/images) belong in:
- `wwwroot/` (and can later be served via CDN)

---

## Folder Responsibilities (Standard)

### `00_Core/`
Foundational code used everywhere.
- Base classes, interfaces, records
- Enums, constants, static helpers
- Services (state, validation, persistence abstractions)
- Serialization + schema contracts

### `01_Displays/`
View-only UI (no user input).
- Read-only renderers
- Display-only badges, labels, inspectors
- Visual-only node previews

### `02_Fields/`
Interactive/dynamic UI with user input.
- Inputs, sliders, toggles, dropdowns with binding
- Form elements used in inspectors/editors
- Validation-aware input fields

### `03_Pointers/`
Navigation + selection primitives.
- Buttons, dropdown selectors, breadcrumb links
- “Point to something” behavior (open node, focus macro, select graph, etc.)

### `04_Actions/`
Commands and side effects.
- API calls (Airtable, REST, local persistence)
- Internal command/event handlers
- Sync triggers, patch apply, validation run
- “Do something” actions invoked by UI

### `05_Nodes/`
All node-domain definitions.
- Node records/models
- Port definitions
- Node type registry
- Validation rules per node kind (if kept close to nodes)

### `06_Components/`
Composable UI building blocks.
- Inspector blocks
- Node UI blocks
- Edge list blocks
- Smaller layouts built from Displays/Fields/Actions

### `07_Widgets/`
Medium/large layout compositions.
- Canvas widget
- Inspector widget
- Toolbar widget
- Mini-map widget
  Widgets contain multiple components.

### `08_View/`
Full screen/page-like views.
- Layout that combines multiple widgets into one coherent screen

### `09_Panels/`
“Window panel” containers.
- A docked or overlay panel that hosts a View
- Often used by host app’s editor shell

---

## Node Editor – What to Create and Where It Goes

This section maps Node Editor docs → the types of files you typically create → which folder they belong in.

### Folder Structure Host

```
Shared/
├── _Core          - foundational framework components
├── _Editor        - editor UI implementation
├── NodeEditor     - plugin entry point
└── _Site          - site sections (Welcome, Gallery, Agenda, etc.)
```

### Folder Structure NodeEditor Plugin


| Folder / Module | Description                                                |
|-----------------|------------------------------------------------------------|
| `00_Core`       | System classes                                             |
| `01_Displays`   | Read/output: text, images, Unity3D, etc.                   |
| `02_Fields`     | Read & write inputs (form fields, editors, etc.)           |
| `03_Pointers`   | Interaction helpers: buttons, dropdowns, selectors, etc.   |
| `04_Actions`    | User & system actions / control logic                      |
| `05_Nodes`      | Nodes usable on the graph                                  |
| `06_Components` | Layout composed of displays, fields, pointers, and actions |
| `07_Widgets`    | Layout containers combining multiple views                 |
| `08_View`       | Layout definitions for single or multiple views            |
| `09_Panels`     | Higher-level layout grouping multiple views                |




### Component Prefix legenda
* `D_` : Displays
* `F_` : Field
* `P_` : Pointers
* `A_` : Actions
* `C_` : Components
* `W_` : Widgets
* `V_` : Views
* `PNL_` : Panels

 Naming convention suggestion:
 - `NE_` prefix for NodeEditor-specific items (optional but helps).


---

## Base Layer → Implementation Placement

---

### **[execution-model](node-editor-06-base-execution.md)** 

- `00_Core/_Core/Execution/NodeStatus.cs` (enum: Success/Failure/Running)
- `00_Core/_Core/Execution/TickContext.cs` (context/state passed around)
- `00_Core/_Core/Execution/ExecutionPolicy.cs` (optional policies)

---

### **[flow-type](node-editor-07-base-flow-type.md)**

- `00_Core/_Core/Flow/FlowEdgeType.cs` (enum or record)
- `00_Core/_Core/Flow/PortKind.cs` (FlowIn/FlowOut/DataIn/DataOut)

---

### **[base-schema](node-editor-11-base-schema.md)** & **[json](node-editor-16-arch-json.md)** 

- `00_Core/_Core/Schema/GraphSchema.cs` (contracts)
- `00_Core/_Core/Schema/NodeSchema.cs`
- `00_Core/_Core/Schema/EdgeSchema.cs`
- `00_Core/_Core/Serialization/GraphJson.cs` (DTOs)
- `00_Core/_Core/Serialization/GraphSerializer.cs`

---

### **[sync](node-editor-10-base-sync.md)** & **[updates](node-editor-19-arch-updates.md)**


- `00_Core/_Core/Sync/GraphSnapshot.cs`
- `00_Core/_Core/Sync/GraphPatch.cs`
- `00_Core/_Core/Sync/ConflictModel.cs`
- `04_Actions/A_ApplyPatch.razor` (command UI entry)
- `04_Actions/_Core/SyncService.cs` (apply/merge/poll)

---

## Node Types → Node Folder

---

### **[basenodes](node-editor-03-base-basenodes.md)** & **[nodetypes](node-editor-04-base-nodetypes.md)** 

- `05_Nodes/_Core/NodeBase.cs` (shared)
- `05_Nodes/_Core/PortDefinition.cs`
- `05_Nodes/_Core/NodeRegistry.cs` (register node kinds)
- `05_Nodes/Types/RootNode.cs`
- `05_Nodes/Types/SequenceNode.cs`
- `05_Nodes/Types/SelectorNode.cs`
- `05_Nodes/Types/DecoratorNode.cs`
- `05_Nodes/Types/ActionNode.cs`
- `05_Nodes/Types/ConditionNode.cs`
- `05_Nodes/Types/MacroNode.cs`

Validation placement choice:
- If validation is node-kind specific → keep close:
    - `05_Nodes/Validation/*.cs`
- If validation is system-wide → keep in:
    - `00_Core/_Core/Validation/*.cs`

---

## Architecture Layer → Services, Interop, and Host Integration

---

### **[blazor](node-editor-14-arch-blazor.md)**

- `00_Core/_Core/Services/NodeEditorState.cs` (state container)
- `00_Core/_Core/Services/SelectionService.cs`
- `00_Core/_Core/Services/CommandBus.cs` (optional event system)

---

### **[js-interop](node-editor-17-arch-js.md)**

- `00_Core/_Core/Interop/NodeEditorJsInterop.cs`
- JS file(s):
    - `wwwroot/node-editor/node-editor.js`

---

### **[validation](node-editor-21-arch-validation.md)**

- `00_Core/_Core/Validation/GraphValidator.cs`
- `00_Core/_Core/Validation/ValidationResult.cs`
- `00_Core/_Core/Validation/Rules/*.cs`

---

### **[performance](node-editor-22-arch-performance.md)**

- `00_Core/_Core/Performance/RenderBudget.cs` (optional)
- `00_Core/_Core/Performance/Throttling.cs` (debounce, coalesce updates)

---

### **[deployment](node-editor-24-arch-deployment.md)** 

- `00_Core/_Core/Plugin/NodeEditorPluginManifest.cs` (if you use manifests)
- `00_Core/_Core/Plugin/ServiceRegistration.cs`

---

## UI Layer → Where UI Pieces Belong

---

### **[ui-spec](node-editor-27-ui-spec.md)**

- A top-level entry panel/view that ties everything together:
    - `09_Panels/PNL_NodeEditor.razor`
    - `08_View/V_NodeEditor.razor`

---

### **[layout](node-editor-30-ui-layout.md)**

- `07_Widgets/W_Canvas.razor`
- `07_Widgets/W_Inspector.razor`
- `07_Widgets/W_Toolbar.razor`

---

### **[interactions](node-editor-33-ui-interactions.md)** 

- Input-capable elements:
    - `02_Fields/F_NodePosition.razor` (if node pos editable)
    - `02_Fields/F_PortPicker.razor` (if user picks ports)
- Interaction glue:
    - `06_Components/C_NodeSurface.razor`
    - `06_Components/C_EdgeSurface.razor`

---

### **[ui-validation](node-editor-35-ui-validation.md)**

- Read-only error displays:
    - `01_Displays/D_ValidationBadge.razor`
    - `01_Displays/D_ErrorBanner.razor`
- Optional actions:
    - `04_Actions/A_RunValidation.razor`

---

### **[ui-navigation](node-editor-31-ui-navigation.md)**

- Navigation pointers:
    - `03_Pointers/P_Breadcrumbs.razor`
    - `03_Pointers/P_MacroBack.razor`

---

### **[ui-components](node-editor-32-ui-components.md)** 

- Common UI building blocks:
    - `06_Components/C_NodeCard.razor`
    - `06_Components/C_Port.razor`
    - `06_Components/C_Edge.razor`
    - `06_Components/C_InspectorSection.razor`

---

## Suggested Minimal “First Implementation” File Set

If you want the smallest set to bootstrap a working editor panel:

### Core
- `00_Core/_Core/Services/NodeEditorState.cs`
- `00_Core/_Core/Schema/*.cs`
- `00_Core/_Core/Validation/*.cs`
- `00_Core/_Core/Interop/NodeEditorJsInterop.cs`

### Nodes
- `05_Nodes/_Core/*.cs`
- `05_Nodes/Types/*.cs`

### UI Composition
- `09_Panels/PNL_NodeEditor.razor`
- `08_View/V_NodeEditor.razor`
- `07_Widgets/W_Canvas.razor`
- `07_Widgets/W_Inspector.razor`
- `06_Components/C_NodeSurface.razor`
- `06_Components/C_InspectorSection.razor`

### Assets
- `wwwroot/node-editor/node-editor.js`
- `wwwroot/node-editor/node-editor.css`

---

## Static Assets (JS/CSS)

Place static assets here:
- `wwwroot/node-editor/node-editor.js`
- `wwwroot/node-editor/node-editor.css`
- `wwwroot/node-editor/assets/*`

This keeps the plugin self-contained and makes CDN migration straightforward later.

---


[← Node-Editor](node-editor.md)
1. **[Base](node-editor-00-base-index.md)** – what the editor is and how it works conceptually
2. **[Architecture](node-editor-12-arch-index.md)** – how the system is structured and implemented
3. **[UI](node-editor-26-ui-index.md)** – how users interact with the editor
4. **[Appendix](node-editor-39-appendix-index.md)** – technical details and references
5. **[Diagrams](node-editor-43-diagrams.md)** – flowcharts and other visual representations

---
