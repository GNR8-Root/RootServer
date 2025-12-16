[← Back to Project Overview](../README.md)

---

# Detailed Project Documentation

Technical Documentation and Project Context

---

### Overview

The existing system is a Blazor Server application with two primary components:

1. Content-driven public websites built from Airtable or JSON data sources (already reads from the json)
2. An internal editor that enables browsing and editing of Airtable schema and data (all elements created, but not connected to the json loop)

### Code Organization

The codebase follows a layered architecture:

```
Shared/
├── _Core          - foundational framework components
├── _Editor        - editor UI implementation
├── Airtable       - Airtable integration and JSON caching layer
└── _Site          - site sections (Welcome, Gallery, Agenda, etc.)
```

I write clean, maintainable code. For personal projects I sometimes use custom naming conventions (documented here) to speed up development. In team environments, I happily follow the agreed-upon coding standards.

### Key Technical Concepts

The system implements several core patterns:

* Components organized by a consistent numbering convention (00_Core through 08_Panels)
* Pointer-based state management for efficient data handling
* Three-stage sync pipeline: Airtable to JSON cache to UI
* Section structure using SectionBase with CW_Section wrapper components
* Editor UI generated dynamically from Airtable metadata

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