[← Project Overview](../README.md)

[← Detailed Documentation](01__detailed.md)

---

## Architectural Rationale

---

### Original Design Goals

When I started this project, I had several objectives:

* Learn Blazor deeply through practical implementation
* Find an architecture that would allow me to easely expand with already made Unity3d classes
* Build genuinely reusable primitives rather than one-off components
* Enable dynamic content rendering without hardcoded layouts
* Create both a public site and an admin editor sharing a single framework
* Establish modular structure ready for future expansion
* Have AIRTABLE working as a plugin inside a bigger system

### Achieved Results

The current implementation delivers on these goals:

* Editor components are fully reusable across different contexts
* Site and Editor share the same foundation code
* Airtable schema directly drives UI generation
* JSON caching layer provides offline capability and performance
* Clear separation between data layer, UI layer, and rendering logic
* Unity3d code can be used as well, with some minor tweaking as Blazor doesnt use Monobehaviours

This architecture proved the viability of schema-driven UI generation and became the foundation for a larger vision.

---

## Technical Lessons and Evolution

### Implementation Insights

Several technical patterns emerged as particularly effective:

* The static Air class serves its purpose but would benefit from proper dependency injection in a production refactor
* Editor and UI components can be dynamically generated from metadata alone
* Schema-driven rendering provides both power and maintainability
* The codebase structure naturally supports modularization into plugin DLLs

### Architectural Insights

The project validated several architectural principles:

* A clear component numbering pattern (00_Core through 08_Panels) scales well as complexity grows
* Metadata-driven systems dramatically reduce code duplication
* This type of system architecture benefits significantly from AI integration
* The line between "configuration" and "code" can be productively blurred

---



## System Architecture Diagram
```
Program.cs (Startup)
  |
  | - Configure AirtableSettings
  | - Register services
  | - Blazor Server setup
  |
  v
Pages
  |
  | - Index (renders website)
  | - Editor (renders editor UI)
  | - Test/demo pages (optional)
  |
  v
Shared/_Core
  |
  | - Pointer_Service
  | - Base classes, enums, events
  | - Display/Field/Action patterns
  | - Used by Editor + Site
  |
  +---> Shared/_Editor              +---> Shared/_Site
        |                                 |
        | Editor UI & Tools Layer         | Public Website Layer
        |                                 |
        | - EditorView_Service            | - SectionBase
        | - EditorVisibility_Service      | - Section wrappers
        | - LogCatcher_Service            | - Page assemblies
        | - Displays/Fields/Actions       | - Airtable content
        | - Panels/Views/Widgets          | - Welcome, Gallery, etc.
        |                                 |
        +----------------+----------------+
                         |
                         v
                  Shared/Airtable
                         |
                         | - Air (tables + config)
                         | - AirtableTableBase/Table
                         | - Table models (Settings, etc.)
                         | - Sync Actions (A_AirtableSync)
                         | - JSON serialization
                         |
                         v
                  Airtable API
                         |
                         | (sync, fetch, serialize)
```

---
## Modularity

The architecture implements orthogonal concerns across a layered foundation, where capabilities like governance, AI augmentation, and data generation can be independently applied to any layer without coupling

**ARCHITECTURE** (vertical micro -> macro)

| Folder / Module   | Description                                                        |
|-------------------|--------------------------------------------------------------------|
| `00_Core`         | System classes                                                     |
| `01_Displays`     | Read/output: text, images, Unity3D, etc.                           |
| `02_Fields`       | Read & write inputs (form fields, editors, etc.)                   |
| `03_Pointers`     | Interaction helpers: buttons, dropdowns, selectors, etc.           |
| `04_Actions`      | User & system actions / control logic                              |
| `05_Components`   | Layout composed of displays, fields, pointers, and actions         |
| `06_Widgets`      | Layout containers combining multiple views                         |
| `07_View`         | Layout definitions for single or multiple views                    |
| `08_Panels`       | Higher-level layout grouping multiple views                        |


**AIRTABLE STRUCTURE** (vertical)

| Layer             | Description                                                        |
|-------------------|--------------------------------------------------------------------|
| `Base`            | Project-level container                                            |
| `Table`           | Dataset made of rows & fields                                      |
| `Row`             | Individual record (instance)                                       |
| `Field`           | Typed value inside a row                                           |


**CONCERNS** (horizontal)
* `Governance policies`
* `AI augmentation`
* `Validation rules`
* `Governance policies`
* `Security policies`
* `CI/CD automation`
* `Data generation rules`
* `Etc...`

---

[← Project Overview](../README.md)
* [Detailed Documentation](01__detailed.md) (01__detailed.md)
  * [Review](01a0_review.md) (01a0_review.md)
  * [Architecture](01a1_architecture.md) (01a1_architecture.md)
  * [High-Level](01a2_high-level.md) (01a2_high-level.md)
  * [Shared/_Core](01b1_shared-core.md) (01b1_shared-core)
  * [Shared/_Editor](01b2_shared-editor.md) (01b2_shared-editor.md)
  * [Shared/_Sites](01b3_shared-sites.md) (01b3_shared-sites.md)
  * [Shared/Airtable](01b4_shared-airtable.md) (01b4_shared-airtable.md)
  * [Json](01b5_json.md) (01b5_json.md)
  * [Patterns](01c1_patterns.md) (01c1_patterns.md)
  * [Decisions](01c2_decisions.md) (01c2_decisions.md)
  * [Workflow](01c3_workflow.md) (01c3_workflow.md)
  * [Evolution](01c4_evolution.md) (01c4_evolution.md)
* [Data Drives UI](02__data-drives-ui.md) (02__data-drives-ui.md)
* [Airtable](03__airtable.md) (03__airtable.md)
* [Future Vision](04__vision.md) (04__vision.md)
  * [Architecture](04a1_architecture.md) (04a1_architecture.md)
  * [AI Integration](04a2_ai-integration.md) (04a2_ai-integration.md)
  * [Plugins](04a3_plugins.md) (04a3_plugins.md)
  * [Dynamic UI](04a4_dynamic-ui.md) (04a4_dynamic-ui.md)
  * [Automation](04a5_automation.md) (04a5_automation.md)
  * [Positioning](04b1_positioning.md) (04b1_positioning.md)
  * [Value](04b2_value.md) (04b2_value.md)
  * [Tech Specs](04c1_tech-specs.md) (04c1_tech-specs.md)
  * [Migration](04d1_migration.md) (04d1_migration.md)
* [AI Generated Code Review](05__review.md) (05__review.md)

---

to test the current state of the project: please request a key at:

**[arnold@znzr.io](mailto:arnold@znzr.io)**

---