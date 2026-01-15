# Base Synchronization

---

## What “Sync” Means in DocsGen

DocsGen treats documentation as a set of immutable artifacts that can be:

- generated
- validated
- approved
- compared across runs

Synchronization is not collaborative editing; it is the controlled evolution of artifacts across run executions.

---

## Immutability Rules (Canonical)

### Core Rule
Once a core documentation file has been produced in a phase that passed validation, the orchestrator must treat it as immutable.

### Practical Meaning
- Agents cannot overwrite approved core files.
- A new artifact version must use a new logical path (or explicit version suffix).
- Overwrite attempts are rejected unless a regeneration mode is explicitly enabled.

---

## Versioning Strategy

Artifacts are versioned by:
- run ID
- phase number
- optional execution version

Example logical paths:

```text
run_2025_12_14_0001/phase2/docsgen-02-base-concepts.md
run_2025_12_14_0001/phase2_v2/docsgen-02-base-concepts.md
```

The manifest records which artifact version is “active” for the run’s latest successful gate.

---

## Regeneration Policy (Canonical)

DocsGen supports three explicit regeneration patterns:

1. **Manual Edit + Revalidate**
   - user edits files externally
   - orchestrator re-runs validators
   - no LLM involved

2. **Regenerate Failed Phase Only**
   - orchestrator loads prior successful artifacts
   - regenerates only targeted phase files
   - re-runs gates

3. **Full Regeneration**
   - user explicitly requests a full rebuild
   - a new run is created, prior run remains archived

---

## Diffing and Auditing

The manifest store enables:
- showing what changed between phase executions
- diffing two runs for the same plugin slug
- answering “why did this gate fail” using structured issue history

---

## Conflict Handling

DocsGen expects a single orchestrator authority, but it still must handle:

- two UI clients looking at the same run
- multiple approvals attempted for the same gate
- cancel during generation

The orchestrator resolves these by:
- run-level locks
- idempotent approval actions
- event replay for UI clients

---

---

[← DocsGen](docsgen.md)
1. **[Base](docsgen-00-base-index.md)** – conceptual foundations, terminology, and canonical schemas
2. **[Architecture](docsgen-12-arch-index.md)** – orchestration, agents, validators, storage, and hosting boundaries
3. **[UI](docsgen-26-ui-index.md)** – user workflows, screens, components, and interaction rules
4. **[Appendix](docsgen-39-appendix-index.md)** – folder mapping, task references, and implementation checklist
5. **[Diagrams](docsgen-43-diagrams.md)** – architecture, state machines, and end-to-end sequences

---
