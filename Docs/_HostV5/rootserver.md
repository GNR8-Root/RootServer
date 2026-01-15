# RootServer

---

## Purpose

RootServer is a **Blazor Server host application** implementing a schema-driven, metadata-powered UI generation framework. It demonstrates a layered architecture where UI components are dynamically assembled from Airtable data structures, enabling rapid application development without hardcoded layouts.

The project serves as a proof-of-concept for building reusable UI primitives, metadata-driven rendering, and an integrated editor + runtime environment within a single `Blazor Server` application.

---

## Core Concepts

**Host**  
The main `Blazor Server` application that coordinates modules, plugins, and the UI hierarchy.

**Plugin**  
Self-contained feature modules (e.g., `Airtable`) that extend host functionality through the numbered folder hierarchy.

**Module**  
Planned extension system for cross-plugin shared services (currently in research phase).

**Schema-Driven UI**  
UI components are generated from metadata stored in `Airtable`, eliminating the need for hardcoded layouts.

**Numbered Hierarchy**  
A micro-to-macro folder structure (`00_Core` → `09_Panels`) organizing components by their role in the UI composition chain.

**Component Prefixes**  
Naming conventions (`D_`, `F_`, `P_`, `A_`, `C_`, `W_`, `V_`, `PNL_`) that identify component roles at a glance.

---

## Architecture Overview

RootServer follows a **three-layer boundary model**:

- **Core** (`Shared/_Core`) – Foundation classes, base components, events, and services
- **Editor** (`Shared/_Editor`) – Internal development tooling for inspecting and managing data
- **Sites** (`Shared/_Sites`) – Public-facing UI assembled from reusable sections

Plugins like `Airtable` integrate at all three layers, providing specialized displays, fields, pointers, actions, and panels for their domain.

---

## Technology Stack

- `Blazor Server` (`.NET 10.0`)
- `Airtable API` integration with local `JSON` caching
- Event-driven UI patterns
- `Blazorise` (`Tailwind` + `FontAwesome`)
- Component architecture with strong abstractions

---

## Documentation Structure

This documentation set covers the complete RootServer architecture across 58 pages:

### Base Layer (Pages 01-11)
- **[01 - Architecture Overview](rootserver-01-arch-overview.md)**
- **[02 - Getting Started](rootserver-02-getting-started.md)**
- **[03 - Core Concepts](rootserver-03-core-concepts.md)**
- **[04 - Technology Stack](rootserver-04-tech-stack.md)**
- **[05 - Project Structure](rootserver-05-project-structure.md)**
- **[06 - Component Model](rootserver-06-component-model.md)**
- **[07 - Data Flow](rootserver-07-data-flow.md)**
- **[08 - Event System](rootserver-08-event-system.md)**
- **[09 - Service Layer](rootserver-09-service-layer.md)**
- **[10 - Configuration](rootserver-10-configuration.md)**
- **[11 - Deployment](rootserver-11-deployment.md)**

### Architecture Layer (Pages 13-25)
- **[13 - Module System](rootserver-13-arch-modules.md)**
- **[14 - Plugin Architecture](rootserver-14-arch-plugins.md)**
- **[15 - Dependency Injection](rootserver-15-arch-di.md)**
- **[16 - Lifecycle Management](rootserver-16-arch-lifecycle.md)**
- **[17 - Integration Patterns](rootserver-17-arch-integration.md)**
- **[18 - Airtable Integration](rootserver-18-arch-airtable.md)**
- **[19 - Caching Strategy](rootserver-19-arch-caching.md)**
- **[20 - Performance](rootserver-20-arch-performance.md)**
- **[21 - Error Handling](rootserver-21-arch-error-handling.md)**
- **[22 - Security](rootserver-22-arch-security.md)**
- **[23 - Testing Strategy](rootserver-23-arch-testing.md)**
- **[24 - Future Architecture](rootserver-24-arch-future.md)**
- **[25 - External Resources](rootserver-25-arch-resources.md)**

### UI Layer (Pages 26-38)
- **[26 - UI Index](rootserver-26-ui-index.md)**
- **[27 - UI Hierarchy](rootserver-27-ui-hierarchy.md)**
- **[28 - Component Prefixes](rootserver-28-ui-prefixes.md)**
- **[29 - Core Components](rootserver-29-ui-core.md)**
- **[30 - Displays](rootserver-30-ui-displays.md)**
- **[31 - Fields](rootserver-31-ui-fields.md)**
- **[32 - Pointers](rootserver-32-ui-pointers.md)**
- **[33 - Actions](rootserver-33-ui-actions.md)**
- **[34 - Components](rootserver-34-ui-components.md)**
- **[35 - Widgets](rootserver-35-ui-widgets.md)**
- **[36 - Views](rootserver-36-ui-views.md)**
- **[37 - Panels](rootserver-37-ui-panels.md)**
- **[38 - Sites Framework](rootserver-38-ui-sites.md)**

### Standards & Policy (Pages 40-42)
- **[40 - Coding Standards](rootserver-40-appendix-coding-standards.md)**
- **[41 - Code Quality Policy](rootserver-41-appendix-code-quality-policy.md)**
- **[42 - PR Review Checklist](rootserver-42-appendix-pr-review-checklist.md)**

### Diagrams & Improvements (Pages 43-44)
- **[43 - Diagrams](rootserver-43-appendix-diagrams.md)**
- **[44 - Improvements Roadmap](rootserver-44-appendix-improvements.md)**

### Developer Operations (Pages 45-52)
- **[45 - DevOps Index](rootserver-45-devops-index.md)**
- **[46 - Onboarding](rootserver-46-devops-onboarding.md)**
- **[47 - Quick Start](rootserver-47-devops-quick-start.md)**
- **[48 - Debugging](rootserver-48-devops-debugging.md)**
- **[49 - Troubleshooting](rootserver-49-devops-troubleshooting.md)**
- **[50 - Contribution Guide](rootserver-50-devops-contribution.md)**
- **[51 - Secrets Management](rootserver-51-devops-secrets.md)**
- **[52 - Development Workflow](rootserver-52-devops-development-workflow.md)**

### Appendices (Pages 53-57)
- **[53 - Risks & Vulnerabilities](rootserver-53-appendix-risks-and-vulnerabilities.md)**
- **[54 - Source to Docs Mapping](rootserver-54-appendix-source-to-docs-mapping.md)**
- **[55 - Duplicate JSON Cleanup](rootserver-55-appendix-duplicate-json-cleanup.md)**
- **[56 - Architecture Decision Records](rootserver-56-appendix-adrs.md)**
- **[57 - Glossary](rootserver-57-appendix-glossary.md)**

---

**Navigation**

- **[Architecture Overview →](rootserver-01-arch-overview.md)**
- **[UI Index →](rootserver-26-ui-index.md)**
- **[DevOps Index →](rootserver-45-devops-index.md)**

---
