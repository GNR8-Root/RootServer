# Integration

---

## Azure Foundry AI + Airtable Integration Concept

### Integration Philosophy

Airtable provides **structure and truth**.  
Azure Foundry AI provides **reasoning and generation**.

The Node Editor is the orchestrator that binds them together.

---

### Airtable’s Role

Airtable acts as:
- Schema source
- Content store
- Configuration layer
- Editorial interface

Key concepts:
- Bases define domains
- Tables define entity types
- Fields define structure
- Entries define content

---

### Azure Foundry AI’s Role

Azure Foundry AI provides:
- Content generation
- Classification and enrichment
- Decision making
- Structure suggestion

AI is never opaque - it is always invoked through defined nodes.

---

### Integration Flow

Typical flow:
1. Airtable schema defines structure
2. Airtable entries provide content
3. AI nodes enrich or transform data
4. Structure generators assemble output
5. Runtime executes validated result

---

### Safety and Control

- AI nodes require explicit configuration
- Inputs and outputs are structured
- Validation occurs before execution
- AI output never bypasses schema rules

---

### Benefits of This Model

- Editors work in Airtable
- Developers work on runtime engines
- AI augments instead of replaces logic
- System remains auditable and debuggable

---

### Strategic Outcome

This integration enables:
- Schema-driven applications
- AI-augmented content systems
- Low-code composition with high control
- Future-proof AI integration

---

## Azure Foundry AI Integration

---

Azure Foundry AI is integrated as a **graph-native capability**.

- AI nodes are treated like any other node type
- Prompts, context, and outputs are structured
- AI decisions can influence:
    - Layout generation
    - Content selection
    - Control flow
    - Data transformation

AI execution is observable, repeatable, and auditable through graph definitions.

---

[← Node-Editor](node-editor.md)
1. **[Base](node-editor-00-base-index.md)** – what the editor is and how it works conceptually
2. **[Architecture](node-editor-12-arch-index.md)** – how the system is structured and implemented
3. **[UI](node-editor-26-ui-index.md)** – how users interact with the editor
4. **[Appendix](node-editor-39-appendix-index.md)** – technical details and references
5. **[Diagrams](node-editor-43-diagrams.md)** – flowcharts and other visual representations

---