# Macro Execution: Chunking & Partial Regeneration

---

## What “Macro Execution” Means Here

DocsGen uses the term “macro execution” to describe orchestrated work that is larger than a single agent response but still bounded and deterministic.

In practice this means:

- a phase may generate multiple files
- the orchestrator runs generation in a controlled loop
- validators run at the end (and sometimes per file)
- regeneration can target only a subset of files

---

## Phase Execution Pattern (Recommended)

### Step 1 – Plan
Ask the phase agent for:
- list of files to generate in this phase
- per-file outline (headings and intent)
- dependencies (which base terms or schemas must be referenced)

### Step 2 – Generate File-by-File
For each target file:
- call agent to generate the file content
- write artifact (immutable)
- run immediate checks:
  - placeholder scan
  - markdown structure sanity (non-empty, has H1)
  - navigation block present (if required by convention)

### Step 3 – Run Gate Validation
After all files are written:
- run full validators for the phase
- write validation report
- stop or await approval

---

## Why This Pattern Matters

Bounded generation reduces:
- timeout risk
- partial failure blast radius
- drift between files

It also aligns with the regeneration policy:
- regenerate affected files only

---

## Partial Regeneration (File Targets)

DocsGen supports regeneration with explicit targets:

- Phase target: regenerate all files for phase 3
- File target: regenerate only `docsgen-19-arch-updates.md`

Rules:
- prior approved phases are immutable
- regeneration must be explicitly recorded
- revalidation must run after regeneration

---

## Example Regeneration Flow

```text
Phase 3 fails due to broken links
  |
  v
User requests: regenerate docsgen-12-arch-index.md
  |
  v
Orchestrator:
  - loads planned file list and existing artifacts
  - calls phase agent with specific target file
  - writes new artifact version (phase3_v2)
  - runs Phase 3 validators
  - if pass: await approval (interactive) or continue
```

---

## Approval and Regeneration Interactions

If a phase has already been approved:
- regeneration must create a new execution version
- the UI must show that a newer version exists
- approval must be recorded again for the regenerated phase

---

---

[← DocsGen](docsgen.md)
1. **[Base](docsgen-00-base-index.md)** – conceptual foundations, terminology, and canonical schemas
2. **[Architecture](docsgen-12-arch-index.md)** – orchestration, agents, validators, storage, and hosting boundaries
3. **[UI](docsgen-26-ui-index.md)** – user workflows, screens, components, and interaction rules
4. **[Appendix](docsgen-39-appendix-index.md)** – folder mapping, task references, and implementation checklist
5. **[Diagrams](docsgen-43-diagrams.md)** – architecture, state machines, and end-to-end sequences

---
