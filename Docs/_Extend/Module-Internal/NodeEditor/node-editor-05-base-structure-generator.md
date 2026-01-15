# Structure Generator – Deep Dive

---

## Overview

Structure Generators are specialized nodes that transform data and intent into **concrete application structures**.

They do not render UI directly.
They produce structured outputs consumed by runtime systems.

Structure Generator nodes are responsible for producing **application structures** dynamically.

They may generate:
- Menu hierarchies
- Page layouts
- UI section trees
- JSON schemas
- AI execution flows

Generators can use:
- Airtable schemas and entries
- AI-generated suggestions
- Static configuration
- Hybrid deterministic + AI logic

Generated structures are treated as **first-class artifacts**, not temporary outputs.

---

## Types of Structures

### Menu Structures
- Hierarchical navigation trees
- Visibility and access rules
- Data-driven ordering
- AI-assisted grouping

### Layout Structures
- Page and section composition
- Component placement
- Responsive structure definitions
- Content-slot mapping

### JSON Structures
- Configuration schemas
- API payload definitions
- Runtime configuration objects
- Inter-system contracts

### AI Flow Structures
- Prompt chains
- Context assembly
- Decision trees
- Multi-step AI workflows

---

## Inputs

Structure Generators may consume:
- Airtable schemas and entries
- User-defined constraints
- Static configuration
- AI-generated suggestions
- Other structure outputs

---

## Outputs

Outputs are:
- Deterministic where required
- Serializable
- Versionable
- Executable by runtime systems

Generated structures are first-class artifacts, not temporary results.

---

## Deterministic vs AI-Assisted Generation

- Deterministic generators guarantee predictable output
- AI-assisted generators enhance or suggest structure
- Final structure must always pass validation

---

## Role in the System

Structure Generators decouple:
- Content from layout
- Logic from execution
- AI creativity from system safety

---

[← Node-Editor](node-editor.md)
1. **[Base](node-editor-00-base-index.md)** – what the editor is and how it works conceptually
2. **[Architecture](node-editor-12-arch-index.md)** – how the system is structured and implemented
3. **[UI](node-editor-26-ui-index.md)** – how users interact with the editor
4. **[Appendix](node-editor-39-appendix-index.md)** – technical details and references
5. **[Diagrams](node-editor-43-diagrams.md)** – flowcharts and other visual representations

---
