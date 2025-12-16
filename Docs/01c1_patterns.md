[← Project Overview](../README.md)

[← Detailed Documentation](01__detailed.md)

---

## Key Architectural Patterns

---

### Layered Separation

The four-layer structure (`_Core`, `_Editor`, `_Site`, `Airtable`) provides:

* Clear boundaries between concerns
* Reusability of components across contexts
* Independent testing and development of layers
* Clean migration path for future changes
* Starting with _ (`_Core`, `_Editor`, `_Site`) system
* Without _ (`Airtable`) plugin(s)

### Numbered Folder Convention

The 00-08 folder pattern creates:

* Self-documenting file organization
* Predictable component locations
* Clear dependency hierarchy (lower numbers have fewer dependencies)
* Consistent structure across all layers

### Component Prefix System

Prefixes (`A_`, `C_`, `W_`, `V_`, `PNL_`, `P_`) provide:

* Instant recognition of component role
* Clear mental model of component hierarchy
* Easy navigation through the codebase
* Consistent naming across the application

### Component Prefix legenda
* `D_` : Displays
* `F_` : Field
* `P_` : Pointers
* `A_` : Actions
* `C_` : Components
* `W_` : Widgets
* `V_` : Views
* `PNL_` : Panels

### Section-Based Website

The section pattern enables:

* Reusable, modular content blocks
* Data-driven page composition
* Consistent styling via wrappers
* Easy addition/removal of content sections

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