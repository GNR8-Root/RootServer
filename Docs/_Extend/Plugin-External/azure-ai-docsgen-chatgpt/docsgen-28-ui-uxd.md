# UI UX Design

---

## Mental Model for Users

DocsGen should feel like a “build pipeline” with checkpoints:

- upload inputs
- run phases
- pass gates
- approve gates (optional)
- download deliverable

Users should never wonder whether a file changed after approval.

---

## Primary User Journey (Interactive Strict)

1. Create run (wizard)
2. Phase 0 preflight passes
3. Phase 1 completes → user reviews indices → approves
4. Phase 2 completes → user reviews base concepts → approves
5. Phase 3 completes → user reviews architecture → approves
6. Phase 4 completes → user reviews UI/appendix → approves
7. Phase 5 completes → final validation → download bundle

At every step, the UI must show:
- latest gate result
- report link
- artifacts produced

---

## Failure Journey

When a gate fails:

- show a failure banner at top of dashboard
- show a short “failure summary” (issue counts by rule type)
- link to issues report
- show structured issues table immediately
- expose next actions:
  - download artifacts so far
  - regenerate phase (explicit)
  - cancel run

Avoid auto-retry or hidden regeneration.

---

## Approval UX (Interactive Mode)

Approval should be explicit and safe:

- show what was validated
- show counts (links ok, placeholders ok, terminology ok)
- show the report before enabling approval
- require a confirmation click (single click is fine; no modal needed if risk is low)

Approval creates an audit event and advances the run.

---

## Batch UX

In batch mode:
- the dashboard should still show phase-by-phase results
- approvals are not requested
- validation failures still stop the run

Batch mode is for speed, not for ignoring correctness.

---

## “Artifacts So Far” UX

Users should be able to download:
- single files
- current phase artifacts
- all artifacts produced so far (optional)

This is valuable even on failure.

---

---

[← DocsGen](docsgen.md)
1. **[Base](docsgen-00-base-index.md)** – conceptual foundations, terminology, and canonical schemas
2. **[Architecture](docsgen-12-arch-index.md)** – orchestration, agents, validators, storage, and hosting boundaries
3. **[UI](docsgen-26-ui-index.md)** – user workflows, screens, components, and interaction rules
4. **[Appendix](docsgen-39-appendix-index.md)** – folder mapping, task references, and implementation checklist
5. **[Diagrams](docsgen-43-diagrams.md)** – architecture, state machines, and end-to-end sequences

---
