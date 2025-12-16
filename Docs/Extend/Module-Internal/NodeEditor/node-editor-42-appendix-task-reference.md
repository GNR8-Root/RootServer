# Appendix – Deployment Checklist & Documentation Map

This appendix provides a **practical implementation roadmap** for realizing the
Node Editor project. Each deployment phase references the **relevant documentation**
that should be consulted or completed during that step.

This checklist is intended as a **guide**, not a strict requirement order.

---

## Phase 1: MVP (Week 1–2)

Goal: Establish a minimal, functional editor with persistent data and basic interaction.

- **Airtable schema created**  
  → **[Base Schema](node-editor-11-base-schema.md)**  
  → **[Base Foundry / Airtable Integration](node-editor-08-base-foundry-airtable.md)**

- **Blazor data layer complete**  
  → **[Architecture – Data Layer](node-editor-15-arch-data.md)**  
  → **[Architecture – Blazor](node-editor-14-arch-blazor.md)**

- **Matter.js physics working**  
  → **[Architecture – Visual Layer](node-editor-18-arch-visual.md)**  
  → **[Architecture – JavaScript](node-editor-17-arch-js.md)**

- **p5.js basic rendering**  
  → **[Architecture – Visual Layer](node-editor-18-arch-visual.md)**  
  → **[UI Visual Design](node-editor-29-ui-design.md)**

- **Node dragging functional**  
  → **[UI Interactions](node-editor-33-ui-interactions.md)**  
  → **[UI Components](node-editor-32-ui-components.md)**

- **Manual reload button**  
  → **[UI Components](node-editor-32-ui-components.md)**  
  → **[Architecture – Updates & Patching](node-editor-19-arch-updates.md)**

---

## Phase 2: Core Features (Week 3–4)

Goal: Enable full graph authoring with validation and persistence.

- **Port hit testing**  
  → **[Base Node Types](node-editor-04-base-nodetypes.md)**  
  → **[UI Interactions](node-editor-33-ui-interactions.md)**

- **Link creation UI**  
  → **[Base Flow Types](node-editor-07-base-flow-type.md)**  
  → **[UI Interactions](node-editor-33-ui-interactions.md)**

- **Edge persistence**  
  → **[Base Schema](node-editor-11-base-schema.md)**  
  → **[Architecture – JSON Model](node-editor-16-arch-json.md)**

- **Layout auto-save**  
  → **[Architecture – Updates & Patching](node-editor-19-arch-updates.md)**  
  → **[Base Synchronization](node-editor-10-base-sync.md)**

- **Validation rules**  
  → **[Base Node Types](node-editor-04-base-nodetypes.md)**  
  → **[Architecture – Validation](node-editor-21-arch-validation.md)**

- **Error display**  
  → **[UI Validation](node-editor-35-ui-validation.md)**  
  → **[UI Visual Design](node-editor-29-ui-design.md)**

---

## Phase 3: Macro Support (Week 5)

Goal: Support hierarchical graphs and reusable sub-structures.

- **Macro node type**  
  → **[Base Node Types](node-editor-04-base-nodetypes.md)**  
  → **[Architecture – Macro System](node-editor-20-arch-macro.md)**

- **Navigation stack**  
  → **[UI Navigation](node-editor-31-ui-navigation.md)**  
  → **[Architecture – Updates & Patching](node-editor-19-arch-updates.md)**

- **Breadcrumbs component**  
  → **[UI Components](node-editor-32-ui-components.md)**  
  → **[UI Navigation](node-editor-31-ui-navigation.md)**

- **Layout preservation**  
  → **[Architecture – Updates & Patching](node-editor-19-arch-updates.md)**  
  → **[Base Synchronization](node-editor-10-base-sync.md)**

---

## Phase 4: Streaming & Sync (Week 6)

Goal: Enable real-time or near-real-time updates and conflict handling.

- **Polling implementation**  
  → **[Base Synchronization](node-editor-10-base-sync.md)**  
  → **[Architecture – Updates & Patching](node-editor-19-arch-updates.md)**

- **ETag support**  
  → **[Architecture – Data Layer](node-editor-15-arch-data.md)**  
  → **[Architecture – JSON Model](node-editor-16-arch-json.md)**

- **Conflict detection**  
  → **[Base Synchronization](node-editor-10-base-sync.md)**  
  → **[Architecture – Validation](node-editor-21-arch-validation.md)**

- **Update banner UI**  
  → **[UI Components](node-editor-32-ui-components.md)**  
  → **[UI Synchronization](node-editor-36-ui-sync.md)**

- **Patch algorithm**  
  → **[Architecture – Updates & Patching](node-editor-19-arch-updates.md)**  
  → **[Architecture – JSON Model](node-editor-16-arch-json.md)**

---

## Phase 5: Polish & Hardening (Week 7–8)

Goal: Improve quality, performance, and usability.

- **Physics tuning**  
  → **[Architecture – Performance](node-editor-22-arch-performance.md)**  
  → **[Architecture – Visual Layer](node-editor-18-arch-visual.md)**

- **Visual effects**  
  → **[UI Motion](node-editor-34-ui-motion.md)**  
  → **[UI Visual Design](node-editor-29-ui-design.md)**

- **Performance optimization**  
  → **[Architecture – Performance](node-editor-22-arch-performance.md)**

- **Error handling**  
  → **[Architecture – Validation](node-editor-21-arch-validation.md)**  
  → **[UI Validation](node-editor-35-ui-validation.md)**

- **User testing feedback**  
  → **[UI UX Design](node-editor-28-ui-uxd.md)**  
  → **[UI Examples](node-editor-38-ui-examples.md)**

---


[← Node-Editor](node-editor.md)
1. **[Base](node-editor-00-base-index.md)** – what the editor is and how it works conceptually
2. **[Architecture](node-editor-12-arch-index.md)** – how the system is structured and implemented
3. **[UI](node-editor-26-ui-index.md)** – how users interact with the editor
4. **[Appendix](node-editor-39-appendix-index.md)** – technical details and references
5. **[Diagrams](node-editor-43-diagrams.md)** – flowcharts and other visual representations

---
