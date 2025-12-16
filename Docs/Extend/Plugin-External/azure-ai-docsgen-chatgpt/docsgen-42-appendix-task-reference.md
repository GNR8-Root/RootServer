# Appendix – Implementation Checklist & Documentation Map

This appendix provides a practical roadmap for building DocsGen.
Each implementation milestone references the documentation that should guide it.

This checklist is a guide, not a strict order.

---

## Milestone 1: The Spine (Phase 0 + Phase 1)

Goal: A run can be created, preflight can pass/fail deterministically, and foundation files exist.

- **Run model + state machine skeleton**  
  → **[Base Execution Model](docsgen-06-base-execution.md)**  
  → **[Base Models](docsgen-03-base-models.md)**

- **Artifact store abstraction + hashing**  
  → **[Architecture – Data & Storage](docsgen-15-arch-data.md)**  
  → **[Base Synchronization](docsgen-10-base-sync.md)**

- **Phase 0 preflight checks**  
  → **[Base Phase Types](docsgen-04-base-phase-types.md)**  
  → **[JSON Contracts](docsgen-16-arch-json.md)**

- **Phase 1 outputs (root + indices + planned files)**  
  → **[Base Planning](docsgen-05-base-planning.md)**  
  → **[Base Gate Protocol](docsgen-07-base-gate-protocol.md)**

---

## Milestone 2: Deterministic Validators (Phase Gates)

Goal: validators run reliably and stop-on-fail is enforced.

- **Placeholder scanning**  
  → **[Architecture – Validation](docsgen-21-arch-validation.md)**  
  → **[UI Validation](docsgen-35-ui-validation.md)**

- **Internal link validation against planned file list**  
  → **[Base Planning](docsgen-05-base-planning.md)**  
  → **[Architecture – Validation](docsgen-21-arch-validation.md)**

- **Terminology index extraction and enforcement**  
  → **[Base Concepts](docsgen-02-base-concepts.md)**  
  → **[Architecture – Validation](docsgen-21-arch-validation.md)**

- **Completeness scoring**  
  → **[Architecture – Validation](docsgen-21-arch-validation.md)**  
  → **[Canonical Schema](docsgen-11-base-schema.md)**

---

## Milestone 3: Foundry Agent Integration (Phase 2–4 Generation)

Goal: agents generate Markdown under orchestrator control without owning truth.

- **Agent runner and bounded file generation loop**  
  → **[Macro Execution](docsgen-20-arch-macro.md)**  
  → **[Base Execution Model](docsgen-06-base-execution.md)**

- **Tool API surface (optional)**  
  → **[Architecture Resources](docsgen-25-arch-resources.md)**  
  → **[Base Integrations](docsgen-08-base-integrations.md)**

---

## Milestone 4: UI (Wizard + Dashboard + Viewer)

Goal: the UI becomes usable end-to-end.

- **New Run Wizard**  
  → **[UI Specification](docsgen-27-ui-spec.md)**  
  → **[UI Components](docsgen-32-ui-components.md)**

- **Run Dashboard and timeline**  
  → **[Visual System](docsgen-18-arch-visual.md)**  
  → **[UI Layout](docsgen-30-ui-layout.md)**

- **Report viewer with issues table**  
  → **[UI Validation](docsgen-35-ui-validation.md)**  
  → **[Updates & Events](docsgen-19-arch-updates.md)**

---

## Milestone 5: Final Validation + Bundle Output (Phase 5)

Goal: full cross-validation passes and a bundle is produced.

- **Final docset validation**  
  → **[Architecture – Validation](docsgen-21-arch-validation.md)**  
  → **[Diagrams](docsgen-43-diagrams.md)**

- **Zip bundling and download**  
  → **[Architecture – Data & Storage](docsgen-15-arch-data.md)**  
  → **[Deployment](docsgen-24-arch-deployment.md)**

---

---

[← DocsGen](docsgen.md)
1. **[Base](docsgen-00-base-index.md)** – conceptual foundations, terminology, and canonical schemas
2. **[Architecture](docsgen-12-arch-index.md)** – orchestration, agents, validators, storage, and hosting boundaries
3. **[UI](docsgen-26-ui-index.md)** – user workflows, screens, components, and interaction rules
4. **[Appendix](docsgen-39-appendix-index.md)** – folder mapping, task references, and implementation checklist
5. **[Diagrams](docsgen-43-diagrams.md)** – architecture, state machines, and end-to-end sequences

---
