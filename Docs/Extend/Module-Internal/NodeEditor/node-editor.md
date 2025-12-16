# Node Editor 

---

## Purpose

The Node Editor is a schema-driven visual system used to design, connect, and orchestrate structured logic flows that integrate **Azure Foundry AI**, **Airtable data (bases, tables, fields, entries)**, and **automatic structure generation** (menus, layouts, JSON schemas, AI workflows) into executable application behavior.

The editor enables non-hardcoded composition of application logic, UI structure, and AI-assisted workflows.

---

 

## Glossary

**Node**  
Atomic unit representing data, logic, AI, or structure.

**Graph**  
A connected set of nodes forming executable intent.

**Structure Generator**  
Node that produces application structures dynamically.

**Execution Plan**  
Resolved order of node execution at runtime.

**Blueprint**  
Immutable graph definition used to generate behavior.

---


## Tech split
- **Blazor (.NET)**: state orchestration, validation, Airtable sync, inspector/panels
- **Matter.js**: physics simulation (positions, constraints, damping, drag)
- **p5.js**: rendering (nodes, ports, wires, hover/selection)

---

## Guiding principle

The “overview” explains *what it is*.  
The “runtime + node contracts” explain *how it behaves*.  
Everything else (UI, schema, sync) becomes consistent once runtime is defined.

---

## Scope Definition (Preparation Phase)

### In Scope
- Visual composition of data, logic, AI, and structure
- Airtable-driven schema and content modeling
- Azure Foundry AI orchestration
- Runtime generation of layouts, menus, JSON, and AI flows

### Out of Scope (for now)
- Low-level UI styling
- Manual code editing inside nodes
- Real-time collaboration
- Full version diffing and merge tooling

---

## Non-Goals

The Node Editor plugin is intentionally scoped to visual graph authoring only.

- The editor **does not execute graphs** or evaluate runtime behavior.
- The editor **does not enforce domain-specific rules** beyond generic graph validity.
- The editor is **backend-agnostic by design** and does not assume any data source,
  execution engine, or persistence layer.

Execution semantics, validation rules, and domain behavior are expected to be
implemented by host applications or separate plugins.

---

## Success Criteria

The Node Editor v1 is considered successful when:

- Complete application structures can be defined without writing code
- Airtable data can drive UI and logic generation
- Azure Foundry AI flows can be composed visually
- Graphs are validatable, reusable, and executable
- Non-developers can understand and modify flows safely

---

## Node Editor – Documentation Index

This document is the **canonical entry point** for the Node Editor documentation.
It provides an overview of all conceptual, architectural, and UI-related documents
that together define the Node Editor as a reusable, backend-agnostic plugin.


1. **[Base](node-editor-00-base-index.md)** – what the editor is and how it works conceptually
2. **[Architecture](node-editor-12-arch-index.md)** – how the system is structured and implemented
3. **[UI](node-editor-26-ui-index.md)** – how users interact with the editor
4. **[Appendix](node-editor-39-appendix-index.md)** – technical details and references
5. **[Diagrams](node-editor-43-diagrams.md)** – flowcharts and other visual representations