# Base Gate Protocol

---

## What a Gate Is

A gate is the deterministic “truth checkpoint” between phases.

A gate exists to answer one question:

> Are the artifacts produced in this phase safe to treat as stable inputs for later phases?

If the answer is no, the run stops.

---

## Canonical Gate Steps

1. **Collect Inputs**
   - phase outputs
   - planned file list (link authority)
   - terminology index (if already generated)
   - base schema (if already generated)

2. **Run Validators**
   - placeholder scan
   - internal link resolution
   - schema consistency checks
   - terminology enforcement
   - phase-specific checks (e.g., UI error messages must match canonical rules)

3. **Generate Reports**
   - If passing: `NN-phaseN-validation.md`
   - If failing: `NN-phaseN-issues.md`

4. **Stop or Await Approval**
   - interactive: await approval after pass
   - batch: continue after pass
   - any mode: stop immediately on fail

---

## Pass vs Fail vs Awaiting Approval

### Pass
- Zero error-severity issues
- Warnings may exist depending on strictness mode

### Fail
- At least one error-severity issue
- Run status becomes Failed
- Orchestrator refuses to overwrite prior artifacts

### Awaiting Approval
- Only possible after pass in interactive mode
- Approval is a recorded action (who + when)
- Approval advances the state machine

---

## Strict vs Lenient Behavior

Strictness affects only the severity thresholds, never the core guarantees.

### Always Enforced
- no placeholders
- no broken internal links
- terminology consistency
- schema consistency

### Strict Only (Typical)
- diagrams required
- completeness threshold higher
- missing operational policies are errors

### Lenient (Typical)
- diagrams optional
- completeness threshold lower
- missing operational policies are warnings

---

## Issues Report Format (Human-Readable)

A failing gate produces an issues report that is easy to act on.

Example structure:

```md
# Phase 3 Issues

## Summary
- 2 broken links
- 1 terminology violation

## Broken Links
- docsgen-12-arch-index.md: link target does not exist: docsgen-24-arch-deployment.md

## Terminology
- docsgen-27-ui-spec.md: uses “pipeline step” but canonical term is “phase”

## Recommended Fix
- Correct links to planned file targets
- Replace non-canonical terms with canonical terms from Base Concepts

## Next Action
- Fix the affected files manually OR explicitly request regeneration of the affected phase files
```

---

## Immutability Requirement

A gate is also an immutability boundary.

If a core documentation file has been approved in an earlier phase, it must not be overwritten unless:
- the user explicitly triggers a regeneration action, and
- the orchestrator policy allows overwriting in that run mode

---

---

[← DocsGen](docsgen.md)
1. **[Base](docsgen-00-base-index.md)** – conceptual foundations, terminology, and canonical schemas
2. **[Architecture](docsgen-12-arch-index.md)** – orchestration, agents, validators, storage, and hosting boundaries
3. **[UI](docsgen-26-ui-index.md)** – user workflows, screens, components, and interaction rules
4. **[Appendix](docsgen-39-appendix-index.md)** – folder mapping, task references, and implementation checklist
5. **[Diagrams](docsgen-43-diagrams.md)** – architecture, state machines, and end-to-end sequences

---
