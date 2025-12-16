# Navigation & Information Architecture

---

## Route Map (Suggested)

DocsGen navigation is centered on runs.

```text
/docsgen
/docsgen/runs
/docsgen/runs/new
/docsgen/runs/run_2025_12_14_0001
/docsgen/runs/run_2025_12_14_0001/phase/3
/docsgen/runs/run_2025_12_14_0001/artifacts
/docsgen/runs/run_2025_12_14_0001/artifact?path=run_2025_12_14_0001/phase3/docsgen-13-arch.md
```

The exact route prefix can match the host’s conventions.

---

## Breadcrumb Model

Breadcrumbs should reflect the user’s location:

- DocsGen
- Runs
- Run ID
- Phase / Artifact (optional)

Example breadcrumb:

```text
DocsGen › Runs › run_2025_12_14_0001 › Phase 3
```

---

## Navigation Principles

- The run dashboard is the “home” for a run.
- Reports and artifacts are reachable without losing the run context.
- Deep links must work (open a report directly via URL).

---

## Global Actions Placement

Recommended global actions:

- **New Run** (primary action on /docsgen/runs)
- **Download Bundle** (primary action on a completed run dashboard)
- **Cancel Run** (secondary action, but visible on running runs)
- **Approve & Continue** (primary action when awaiting approval)

---

---

[← DocsGen](docsgen.md)
1. **[Base](docsgen-00-base-index.md)** – conceptual foundations, terminology, and canonical schemas
2. **[Architecture](docsgen-12-arch-index.md)** – orchestration, agents, validators, storage, and hosting boundaries
3. **[UI](docsgen-26-ui-index.md)** – user workflows, screens, components, and interaction rules
4. **[Appendix](docsgen-39-appendix-index.md)** – folder mapping, task references, and implementation checklist
5. **[Diagrams](docsgen-43-diagrams.md)** – architecture, state machines, and end-to-end sequences

---
