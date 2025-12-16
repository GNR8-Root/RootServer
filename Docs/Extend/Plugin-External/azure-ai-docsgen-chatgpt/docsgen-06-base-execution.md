# Base Execution Model

---

## Summary

DocsGen executes as a deterministic state machine.

- Phases are executed sequentially.
- A phase produces artifacts (core docs and supporting reports).
- A deterministic gate validates those artifacts.
- Depending on configuration, the run either:
  - stops for approval (interactive), or
  - continues automatically (batch)

---

## Run Statuses (Canonical)

- **Running** – a phase is currently executing
- **AwaitingApproval** – a phase completed and passed gate validation, but requires user approval
- **Failed** – a gate failed (errors detected) and the run halted
- **Complete** – final validation passed and a bundle was produced
- **Canceled** – the user canceled the run explicitly

---

## Phase Progression Rules

A run may advance from phase N to phase N+1 only if:

1. Phase N artifacts exist
2. Phase N gate validation produced “pass”
3. If review mode is interactive, phase N is approved by a user action

---

## Canonical Execution Loop (Conceptual)

```text
for phase in [0..5]:
  acquire lock on run
  load inputs and prior approved artifacts
  run agent work (bounded steps)
  write artifacts to store (immutable)
  run deterministic validators
  write validation report artifact
  if validation failed:
     write issues report artifact
     set run status = Failed
     stop
  if review_mode == interactive:
     set run status = AwaitingApproval
     stop until approved
continue
```

---

## Chunked Generation Pattern

DocsGen avoids “one giant generation” per phase.

Instead:

1. The agent produces a plan (files + outlines).
2. The orchestrator generates file-by-file.
3. Basic checks run after each file (placeholder scan, markdown sanity).
4. The full gate runs after all files are generated.

This pattern is essential because agent runtimes and tool-call runs can expire; smaller steps reduce the blast radius of failure.

---

## Deterministic Gate Outputs

Each gate produces:

- **Human-readable report** (pass summary)
- **Issues report** (only on failure)
- **Structured issue list** (for UI filtering and navigation)

The orchestrator stores these as artifacts and emits run events so that the UI can update in real time.

---

## Partial Regeneration

Partial regeneration is allowed only when explicitly requested.

When re-running a phase:
- earlier successful phases remain immutable
- later phases are not silently rewritten
- only targeted files are regenerated
- all validators for the phase and final cross-validation can be re-run

---

---

[← DocsGen](docsgen.md)
1. **[Base](docsgen-00-base-index.md)** – conceptual foundations, terminology, and canonical schemas
2. **[Architecture](docsgen-12-arch-index.md)** – orchestration, agents, validators, storage, and hosting boundaries
3. **[UI](docsgen-26-ui-index.md)** – user workflows, screens, components, and interaction rules
4. **[Appendix](docsgen-39-appendix-index.md)** – folder mapping, task references, and implementation checklist
5. **[Diagrams](docsgen-43-diagrams.md)** – architecture, state machines, and end-to-end sequences

---
