# DocsGen Architecture Overview

---

## Executive Summary

DocsGen is a phase-gated documentation generation system built around a single core idea:

> The orchestrator is the single source of truth.

The system is decomposed into four planes to keep responsibilities clean and to prevent correctness from becoming an LLM judgment problem.

---

## Planes (Clean Boundaries)

### Experience Plane (Blazor UI)
Owns user interaction:
- input uploads
- run configuration
- phase progress visualization
- approvals
- downloads

Does not call LLMs and does not generate files.

---

### Control Plane (Orchestrator API)
Owns truth and progression:
- run state machine (phases 0–5)
- stop-on-fail behavior
- user gates and approvals
- validator execution
- artifact registry and immutability
- event emission (SignalR/SSE)

---

### Intelligence Plane (Foundry Agents)
Owns drafting:
- generates Markdown content for phase files
- may generate narrative summaries of validator issues

Does not decide pass/fail and must not overwrite approved artifacts.

---

### Deterministic Plane (Validators + Storage)
Owns enforcement:
- link checking
- placeholder scanning
- schema and terminology enforcement
- completeness scoring
- artifact persistence and bundling

---

## High-Level Architecture Diagram (Containers)

```text
+------------------------------+       +------------------------------+
| Blazor UI (Experience Plane) |       | Artifact Store (Deterministic)|
| - upload inputs              |       | - blobs/files per run/phase  |
| - run dashboard              |       | - content hashing            |
| - validation viewer          |       | - bundle zip creation        |
+--------------+---------------+       +--------------+---------------+
               |                                      ^
               | REST + SSE/SignalR                   |
               v                                      |
+------------------------------+                      |
| Orchestrator API (Control)   |                      |
| - phase state machine        |                      |
| - gate execution             |-------> Validators ---+
| - artifact registry          |         (Deterministic)
| - run event stream           |
+--------------+---------------+
               |
               | agent runs (bounded)
               v
+------------------------------+
| Foundry Agents (Intelligence)|
| - generate markdown drafts   |
| - optional narrative reports |
+------------------------------+
```

---

## Core Rule: Single Source of Truth

DocsGen forbids “distributed truth.”

- The UI is not authoritative.
- Agents are not authoritative.
- Validators do not advance phases.
- Only the orchestrator can advance the state machine.

This makes run behavior predictable and auditable.

---

## Immutability and Regeneration

Artifacts are immutable by default.

Regeneration must be:
- explicit
- scoped (phase and file targets)
- recorded in the manifest

This is the primary guardrail against drift.

---

---

[← DocsGen](docsgen.md)
1. **[Base](docsgen-00-base-index.md)** – conceptual foundations, terminology, and canonical schemas
2. **[Architecture](docsgen-12-arch-index.md)** – orchestration, agents, validators, storage, and hosting boundaries
3. **[UI](docsgen-26-ui-index.md)** – user workflows, screens, components, and interaction rules
4. **[Appendix](docsgen-39-appendix-index.md)** – folder mapping, task references, and implementation checklist
5. **[Diagrams](docsgen-43-diagrams.md)** – architecture, state machines, and end-to-end sequences

---
