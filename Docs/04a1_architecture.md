[← Project Overview](../README.md)

[← Vision](04__vision.md)

---

## System Architecture: Future State

---

### Detailed Architecture Flow
```
┌─────────────────────────────────────────────────────────────────────┐
│                          Azure Cloud                                │
│                                                                     │
│  ┌───────────────────────────────────────────────────────────────┐  │
│  │              Azure AI Search (Code Index)                     │  │
│  │  - Entire Blazor DSL / Components                             │  │
│  │  - Airtable/Cosmos Doc Schemas                                │  │
│  │  - Manuals, API Specs, Patterns                               │  │
│  │  - AI uses this for self-awareness                            │  │
│  └───────────────────────────────────────────────────────────────┘  │
└─────────────────────────────────────────────────────────────────────┘
                                |
                                | indexed knowledge
                                v
┌─────────────────────────────────────────────────────────────────────┐
│                      AI Reasoning Layer                             │
│─────────────────────────────────────────────────────────────────────│
│  - AI Foundry: structured JSON generation                           │
│  - Per-field AI augmentation                                        │
│  - Governance policies                                              │
│  - Automated layout & schema suggestions                            │
│  - Schema generation, UX rules, CI/CD orchestration                 │
└─────────────────────────────────────────────────────────────────────┘
                                |
                                | reads/writes schema
                                v
┌─────────────────────────────────────────────────────────────────────┐
│                    Dynamic Metadata Layer                           │
│─────────────────────────────────────────────────────────────────────│
│  Current: Airtable (Meta) API (phase-out planned)                   │
│  Future:  CosmosDB                                                  │
│                                                                     │
│  Schema Definitions:                                                │
│  - Dynamic JSON schema definitions                                  │
│  - Field-level config: type, UI rule, AI rule, governance           │
│  - View-level config: layout, structure, user roles                 │
│  - Table relationships & references                                 │
│  - CI/CD rules, loading, rendering configuration                    │
│                                                                     │
│  Result: JSON schema -> UI + rules + relationships                  │
└─────────────────────────────────────────────────────────────────────┘
                                |
                                | generates fully dynamic UI
                                v
┌─────────────────────────────────────────────────────────────────────┐
│                     Blazor Plugin System                            │
│─────────────────────────────────────────────────────────────────────│
│  Modular .DLL Components:                                           │
│  - Widgets, views, fields, smart inputs, validators                 │
│  - Editor components auto-generated from schema                     │
│  - Views, Panels, Widgets, Inputs generated programmatically        │
│  - No hardcoded UI; everything parsed from metadata                 │
│  - Tailwind CSS theming per project                                 │
│                                                                     │
│  Framework Principle:                                               │
│  - "Umbrella" framework: child projects = zero code                 │
│  - Only JSON config + theme required                                │
└─────────────────────────────────────────────────────────────────────┘
                                |
                                | serves UI
                                v
┌─────────────────────────────────────────────────────────────────────┐
│            Secure Local & Cloud Admin UIs (Blazor)                  │
│─────────────────────────────────────────────────────────────────────│
│  Local Admin (High Security):                                       │
│  - Azure API Auth                                                   │
│  - Schema editing / tooling                                         │
│  - Infrastructure management                                        │
│  - Secure schema and deployment management                          │
│                                                                     │
│  Cloud Admin (Online):                                              │
│  - Project-specific configuration                                   │
│  - Domain linking                                                   │
│  - Web app/container creation                                       │
│  - CI/CD automation                                                 │
└─────────────────────────────────────────────────────────────────────┘
                                |
                                | publishes static output / runtime assets
                                v
┌─────────────────────────────────────────────────────────────────────┐
│                  CDN + Static Delivery Layer                        │
│─────────────────────────────────────────────────────────────────────│
│  - Static CSS (Tailwind theme per project)                          │
│  - Pre-rendered JSON structure caches                               │
│  - Static JSON, media, styles, themes                               │
│  - Media assets                                                     │
│  - Edge hosting for speed                                           │
└─────────────────────────────────────────────────────────────────────┘
                                |
                                | consumed by minimal child projects
                                v
┌─────────────────────────────────────────────────────────────────────┐
│                   Child Projects (Zero-Code)                        │
│─────────────────────────────────────────────────────────────────────│
│  Project Structure:                                                 │
│  - Provide JSON schemas + Airtable/Cosmos data                      │
│  - Optional Tailwind theme overrides                                │
│  - Framework generates entire UI automatically                      │
│  - No local logic - only metadata                                   │
│                                                                     │
│  Result: Zero code, zero duplication                                │
└─────────────────────────────────────────────────────────────────────┘
```

### Simplified Architecture View
```
Azure Cloud
    |
    v
Azure AI Search Layer
(Framework code, plugins, schemas, documentation)
    |
    v
AI Reasoning Layer
(Schema generation, UX rules, CI/CD, governance)
    |
    v
Dynamic Metadata Layer (Cosmos)
(JSON schema -> UI + rules + relationships)
    |
    v
Blazor Plugin System
(Widgets, views, fields, smart inputs, validators)
    |
    v
Admin UIs (Local and Cloud)
(Secure schema and deployment management)
    |
    v
CDN Delivery Layer
(Static JSON, media, styles, themes)
    |
    v
Child Projects (Zero-Code)
(Only schema + theme configuration)
```

### Key Architecture Principles

**Top-Down Flow:**
1. Azure AI Search provides comprehensive knowledge base
2. AI Reasoning generates and validates schemas
3. Dynamic Metadata defines all UI and business logic
4. Plugin System renders everything programmatically
5. Admin UIs manage configuration and deployment
6. CDN delivers static assets efficiently
7. Child Projects contain only configuration

**Zero-Code Child Projects:**
- No compiled code
- Only JSON schema + Tailwind theme
- Everything else auto-generated
- Framework handles all UI rendering
- Consistent behavior across projects

**Migration Path:**
- Current: Airtable for metadata
- Future: CosmosDB for metadata
- Existing codebase validates the architecture
- Clean extraction path to plugin system
- Curent: blazorize for UI elements
- Future: tailwindcss for UI theming

Key architectural characteristics:

* Azure AI Search provides comprehensive indexing of all framework artifacts
* AI reasoning layer handles schema generation, governance, and deployment orchestration
* Dynamic metadata in CosmosDB drives all UI and business logic
* Plugin system provides extensibility without core framework modification
* Secure admin interfaces for schema and deployment management
* CDN layer for static asset delivery and performance

Child projects contain only schema and theme configuration. Everything else is generated.

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