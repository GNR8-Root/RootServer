# Performance Architecture

---

## Overview

DocsGen performance is defined by three constraints:

1. Agent runtime limits (LLM runs may expire quickly)
2. Validator runtime (must be deterministic and fast)
3. Storage and bundling throughput (must handle many files per run)

DocsGen optimizes for predictability over maximum throughput.

---

## Time Budgeting

Recommended budgeting strategy:

- Phase work is chunked into bounded file generation calls.
- Each file generation call has a strict time budget.
- Validators run in a predictable time window per phase.

Example budgets (guidance):
- per file generation: 30–90 seconds
- per phase validator gate: < 10 seconds for link + placeholder scanning on typical docsets
- final validation: < 60 seconds (full link scan + scoring)

Actual budgets depend on hosting and storage.

---

## Concurrency

DocsGen can support concurrency at two levels:

1. **Across runs**
   - multiple runs can execute concurrently if storage and agent quotas allow

2. **Within a run**
   - validators can run in parallel (safe)
   - generation should remain ordered unless you can guarantee deterministic ordering and stable naming

The orchestrator should always enforce per-run locking so that:
- phase progression is linear
- approvals are idempotent

---

## Caching

Caching is appropriate only for deterministic operations:

- cached reading of large input zips
- cached parsing of planned file list
- cached parsing of headings for anchor validation (if used)

Agent outputs should not be cached across runs unless explicitly enabled, because they are non-deterministic.

---

## Storage Throughput

Bundle creation requires reading all 43 core files and writing a zip.

Recommendations:
- stream reads/writes instead of loading everything into memory
- include a manifest file list in the zip for sanity verification (optional)
- record content hashes in the final validation report

---

## UI Responsiveness

The UI should receive frequent progress events:

- phase started
- file written
- validation started
- validation completed

This avoids the “nothing is happening” effect during long phases.

---

---

[← DocsGen](docsgen.md)
1. **[Base](docsgen-00-base-index.md)** – conceptual foundations, terminology, and canonical schemas
2. **[Architecture](docsgen-12-arch-index.md)** – orchestration, agents, validators, storage, and hosting boundaries
3. **[UI](docsgen-26-ui-index.md)** – user workflows, screens, components, and interaction rules
4. **[Appendix](docsgen-39-appendix-index.md)** – folder mapping, task references, and implementation checklist
5. **[Diagrams](docsgen-43-diagrams.md)** – architecture, state machines, and end-to-end sequences

---
