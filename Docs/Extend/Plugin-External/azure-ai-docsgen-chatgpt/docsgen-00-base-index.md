# Base Layer

This section defines the **conceptual foundation** of DocsGen.
It explains terminology, core abstractions, invariants, and canonical schemas
without assuming a specific hosting runtime or cloud provider implementation.

---

- **[Base Vision](docsgen-01-base-vision.md)**  
  Why DocsGen exists, what it optimizes for, and what it deliberately avoids.

- **[Base Concepts](docsgen-02-base-concepts.md)**  
  Canonical terminology: runs, phases, gates, artifacts, strictness, review mode, and source-of-truth rules.

- **[Base Models](docsgen-03-base-models.md)**  
  The domain model: Run, PhaseExecution, Artifact, ValidationResult, Approval, and policy objects.

- **[Base Phase Types](docsgen-04-base-phase-types.md)**  
  The six phases (Preflight + 1–5) and what each phase must produce.

- **[Base Planning](docsgen-05-base-planning.md)**  
  Planned file lists, docset profiles, numbering invariants, and link authority rules.

- **[Base Execution Model](docsgen-06-base-execution.md)**  
  The state machine and how deterministic gates control progression.

- **[Base Gate Protocol](docsgen-07-base-gate-protocol.md)**  
  The canonical gate algorithm: generate → validate → report → stop/approve.

- **[Base Integrations](docsgen-08-base-integrations.md)**  
  Conceptual integration points: Foundry agents, tool APIs, artifact storage, and host boundaries.

- **[Base Examples](docsgen-09-base-examples.md)**  
  Example runs (interactive vs batch), partial regeneration, and typical outputs.

- **[Base Synchronization](docsgen-10-base-sync.md)**  
  Immutability, versioning rules, audit trails, and regeneration policies.

- **[Base Schema](docsgen-11-base-schema.md)**  
  Canonical JSON schemas for runs, artifacts, issues, and gate reports.

---

[← DocsGen](docsgen.md)
1. **Base** – conceptual foundations, terminology, and canonical schemas
2. **[Architecture](docsgen-12-arch-index.md)** – orchestration, agents, validators, storage, and hosting boundaries
3. **[UI](docsgen-26-ui-index.md)** – user workflows, screens, components, and interaction rules
4. **[Appendix](docsgen-39-appendix-index.md)** – folder mapping, task references, and implementation checklist
5. **[Diagrams](docsgen-43-diagrams.md)** – architecture, state machines, and end-to-end sequences

---
