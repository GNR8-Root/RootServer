# RootServer

---

## Purpose

RootServer is a **Blazor Server-based host application** that implements a schema-driven UI framework with plugin architecture. It provides a foundation for building metadata-driven user interfaces where components are dynamically generated from JSON schemas sourced from Airtable.

The project demonstrates a layered architectural approach using a micro-to-macro component hierarchy (00_Core through 09_Panels), enabling modular, reusable UI primitives that compose into complete applications. RootServer acts as the host container for plugins (such as the Airtable integration plugin) and provides an internal editor environment for runtime inspection and management.

---

## Glossary

**Host**
The RootServer application itself, responsible for bootstrapping, DI registration, middleware configuration, and plugin lifecycle management.

**Plugin**
A self-contained extension that implements specific functionality (e.g., Airtable integration). Plugins follow the 00-09 layer system and use component prefixes to indicate role and layer.

**Module**
Infrastructure for future modular architecture (currently minimal implementation).

**Layer Folder**
Numbered folders (00_Core through 09_Panels) that organize components by abstraction level, from foundational classes to high-level panels.

**Component Prefix**
Naming convention that indicates component role and layer (F_ for Fields, P_ for Pointers, A_ for Actions, C_ for Components, PNL_ for Panels).

**Schema-Driven UI**
UI rendering approach where components are generated from JSON metadata rather than hardcoded layouts.

**Pointer**
Selection and state management abstraction (Pointer_Service) that tracks user interaction and current context.

**Editor Environment**
Internal UI (Shared/_Editor) for browsing tables, inspecting rows/fields, and managing Airtable synchronization.

**Site**
Public-facing website components (Shared/_Sites) assembled from reusable sections.

**JSON Cache**
Local JSON file storage for Airtable schemas and data, enabling offline development and fast local iteration.

---

## Tech Stack

| Component | Technology |
|-----------|-----------|
| Framework | Blazor Server (.NET 8) |
| UI Library | Blazorise + Tailwind CSS |
| Icons | FontAwesome |
| Data Source | Airtable API + local JSON caching |
| State Management | Service-based (scoped services) |
| Rendering | Server-side with SignalR connection |

---

## Scope Definition

### In Scope

- Host architecture and plugin system
- 00-09 cross-layer hierarchy implementation
- Shared/_Sites UI hierarchy source
- Component prefix system and conventions
- Airtable integration plugin architecture
- Service-driven state management
- Editor environment structure
- JSON caching and schema management
- Dependency boundaries (Host ↔ Module ↔ Plugin)

### Out of Scope

- Complete implementation details of every component
- Third-party library internals (Blazorise, Tailwind)
- Speculative features without evidence in codebase
- Line-by-line code walkthroughs

---

## Documentation Index

This documentation set contains 44 pages organized into five major sections:

1. **[Base](rootserver-00-base-index.md)** – conceptual foundations, terminology, folder system, lifecycles, contracts
2. **[Architecture](rootserver-12-arch-index.md)** – system design, data flows, rendering, validation, testing, deployment
3. **[UI](rootserver-26-ui-index.md)** – UI hierarchy, layer folders, prefix system, component patterns
4. **[Appendix](rootserver-39-appendix-index.md)** – risks, source-to-docs mapping, duplicate JSON cleanup
5. **[Diagrams](rootserver-43-diagrams.md)** – system boundaries, data flows, UI hierarchy visualizations

---

## Coverage Summary

**Overall Coverage:** 85% (High confidence)

**Strong Areas:**
- Layer system architecture (00-09 folders)
- Plugin architecture (Airtable as reference)
- Component prefix conventions
- UI hierarchy source (Shared/_Sites)
- Service-based state management

**Unmapped Areas:**
- Node system (05_Nodes) - infrastructure present, implementation planned
- Module system (_Modules) - infrastructure only
- Some layer folders not yet implemented (01_Displays, 08_View, 09_Panels in _Core)
- Testing strategy (no test projects found)
- Production deployment configuration

All unmapped areas are documented with investigation plans and evidence of current status.

---

## Recommended Reading Order

### For New Contributors
1. Base Vision (01) - understand purpose and boundaries
2. Base Concepts (02) - learn core terminology
3. Base Folder System (04) - understand code organization
4. UI Layer Folders (29) - grasp the 00-09 hierarchy
5. UI Prefix System (30) - learn component naming conventions

### For Architects/Reviewers
1. System Architecture (13) - high-level overview with boundaries
2. Composition (20) - plugin and module wiring
3. Base Boundaries (03) - dependency rules
4. Data Flows (15) - understand data movement patterns
5. Diagrams (43) - visual architecture reference

### For Plugin Developers
1. Base Contracts (11) - understand public interfaces
2. Base Integrations (08) - integration patterns
3. Composition (20) - extension points
4. Source-to-Docs Mapping (41) - navigate the codebase

---

## Known Issues and Limitations

1. **Duplicate JSON Files** - Json/ folder contains duplicate files with camelCase vs PascalCase naming (e.g., `pages.json` vs `pagesJson.json`). See Appendix 42 for cleanup plan.

2. **No Testing Infrastructure** - No test projects found. See Page 23 for recommended testing strategy.

3. **Undefined Production Deployment** - Local development configuration is clear, but production deployment strategy is not documented. See Page 24 for recommendations.

4. **Incomplete Layer Implementation** - Some layer folders exist but are empty (01_Displays, 08_View, 09_Panels in _Core). These are documented as planned/future features.

---
