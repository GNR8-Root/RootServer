# Base Vision

---

## What RootServer Is

RootServer is a Blazor Server application designed as a host for schema-driven UI plugins. It optimizes for:

- **Metadata-driven rendering** where UI is generated from JSON schemas
- **Modular architecture** with clear separation between host, modules, and plugins
- **Layered component hierarchy** (00_Core through 09_Panels) enabling micro-to-macro composition
- **Offline-first development** with local JSON caching of Airtable data
- **Runtime inspection** via integrated editor environment

RootServer demonstrates how to build reusable UI primitives that compose into complete applications without hardcoding layouts.

---

## The Problem It Solves

Traditional Blazor applications often suffer from:
- **Hardcoded UI layouts** that resist rapid iteration
- **Tight coupling** between data sources and UI components
- **Limited reusability** of UI patterns across projects
- **Lack of runtime inspection** tools for debugging and testing

RootServer addresses these by introducing a schema-driven approach where:
- Components are defined once and instantiated from metadata
- Data flows through well-defined service boundaries
- UI patterns are layer-based and reusable
- An integrated editor provides runtime visibility

---

## Design Philosophy

### Schema as Source of Truth

JSON schemas from Airtable drive UI generation. The codebase reads these schemas and dynamically renders appropriate components, reducing boilerplate and enabling rapid prototyping.

### Layered Composition

The 00-09 folder system enforces a micro-to-macro architecture:
- 00_Core provides foundational services and base classes
- 01-04 handle atomic UI elements (displays, fields, pointers, actions)
- 05-06 compose these into reusable patterns (nodes, components)
- 07-09 build high-level containers (widgets, views, panels)

### Plugin Isolation

Plugins (like Airtable) implement their own layer subsets without coupling to the host. The host provides extension points but doesn't depend on plugin internals.

### Service-Driven State

State management happens through scoped services (Pointer_Service, EditorView_Service) rather than component props, enabling loose coupling and centralized control.

---

## Boundaries (What RootServer Must Not Become)

RootServer is not:
- **A generic CMS** - it's specialized for schema-driven UI generation
- **A monolithic application** - it's deliberately modular with plugin boundaries
- **A replacement for traditional Blazor** - it's an architectural pattern for metadata-driven scenarios
- **Production-ready infrastructure** - it's a proof-of-concept demonstrating architectural principles

---

## Success Definition

RootServer succeeds when it:
- Generates UI from JSON schemas without hardcoded layouts
- Maintains clear boundaries between host, modules, and plugins
- Provides reusable component patterns through the layer system
- Enables rapid prototyping via local JSON caching
- Offers runtime inspection through the editor environment

---

[← Back to Base Index](rootserver-00-base-index.md)

---
