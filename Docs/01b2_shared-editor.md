[← Project Overview](../README.md)

[← Detailed Documentation](01__detailed.md)

---

## Shared/_Editor: Editor Framework

`Shared/_Editor` is the editor framework layer built on top of `_Core`.

---

### 00_Core/Events/

**LogCatcher_Service.cs**

* Service that stores message/description/color
* Raises `LogCatched` event
* Used to display logs to the user (e.g., during Airtable sync operations)

**EditorView_Service.cs**

* Maintains current `EditorSplitView` state
* Manages `APreBase_EditorView` toggles
* Raises `EditorViewToggled` event for UI coordination

### 07_View/_Core/

**BaseView.razor + BaseView.razor.cs**

Base component for editor views with parameters:

* Label
* IsTabContent
* ChildContent
* IdMenuItem

Used as foundation for specific views like `V_Workspace` in the Airtable layer.

### Component Conventions

Editor components use consistent prefixes:

* `APreBase_...` - Abstract/pre-base view models and templates
* Editor-specific UI panels, tabs, and controls

The Editor page (`Pages/Editor.razor.cs`) leverages these services and base components to manage layout and UI behavior dynamically.

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