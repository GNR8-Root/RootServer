# CONCEPTS

---

## Mental Model

DocsGen produces plugin documentation by running a **phase-gated pipeline**.

- A **Run** is the unit of work.
- Each run advances through **Phases** (Preflight + 1–5).
- Each phase outputs immutable **Artifacts**.
- Each phase ends with a deterministic **Gate**.
- A gate produces a report and either passes, fails, or awaits approval.

DocsGen is intentionally designed so that *progress is explicit* and *truth is deterministic*.

---

## Core Terms (Canonical)

### Run
A run is an execution instance that produces artifacts. A run has:
- configuration (review mode, strictness)
- a current phase
- a lifecycle status (running, awaiting approval, failed, complete)

Runs are not overwritten; they are archived and diffable.

---

### Phase
A phase is a bounded generation step that:
- has known inputs
- produces explicit outputs
- can be re-run without regenerating unrelated artifacts

Phases exist to prevent drift and to make validation manageable.

---

### Gate
A gate is a deterministic evaluation executed after a phase finishes generation.

A gate produces:
- a structured issue list (file, rule, message)
- a human-readable report
- a pass/fail decision

---

### Artifact
An artifact is a stored file with metadata:
- logical path (run + phase + filename)
- content hash
- type classification (core doc, report, input, bundle)
- provenance (agent, tool, user)

Artifacts are immutable under the default policy.

---

### Core Documentation File
A core documentation file is one of the 43 numbered Markdown files defined by the docset structure. These are the deliverable files bundled at the end of the run.

---

### Generation Artifact
A generation artifact is a support file produced during the run (planned file list, terminology index, validation reports). These are useful for review and auditing, but are not part of the deliverable bundle.

---

## Source-of-Truth Precedence

When inputs conflict, follow this precedence:

1. Plugin requirements JSON (canonical truth)
2. Host architecture constraints (runtime truth)
3. Reference docset conventions (structure truth)
4. Natural language instructions (context only)

This is a rule enforced by the orchestrator and validators, not by “best effort” prompting.

---

## Global Content Rules

### No Placeholders
Final outputs must not include placeholder tokens, ambiguous “fill this later” content, or unresolved template language.

### Link Integrity
All internal links must point to existing core documentation files and use relative paths.

### Terminology Consistency
Terms defined in Base Concepts remain canonical and must not be redefined differently elsewhere.

---

---

[← DocsGen](docsgen.md)
1. **[Base](docsgen-00-base-index.md)** – conceptual foundations, terminology, and canonical schemas
2. **[Architecture](docsgen-12-arch-index.md)** – orchestration, agents, validators, storage, and hosting boundaries
3. **[UI](docsgen-26-ui-index.md)** – user workflows, screens, components, and interaction rules
4. **[Appendix](docsgen-39-appendix-index.md)** – folder mapping, task references, and implementation checklist
5. **[Diagrams](docsgen-43-diagrams.md)** – architecture, state machines, and end-to-end sequences

---
