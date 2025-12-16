# Base Examples

---

## Example 1 – Interactive Strict Run (Typical)

**Goal**: Generate full documentation for a plugin in a reviewable way.

### Configuration
```json
{
  "review_mode": "interactive",
  "validation_strictness": "strict"
}
```

### Expected Behavior
- The run stops after each phase.
- A validation report is produced at each gate.
- The user must approve before continuing.
- If a gate fails, an issues report is produced and the run stops.

### Typical Output Artifacts
- Phase 1: root + indices + planned file list
- Phase 2: base layer + terminology index
- Phase 3: architecture layer
- Phase 4: UI + appendix
- Phase 5: diagrams + final validation report + bundle zip

---

## Example 2 – Batch Lenient Run (Exploration)

**Goal**: Generate documentation quickly for early iteration.

### Configuration
```json
{
  "review_mode": "batch",
  "validation_strictness": "lenient"
}
```

### Expected Behavior
- The run executes all phases sequentially.
- Validation reports are written but the system does not pause for approval.
- Core guarantees still apply:
  - no placeholders
  - no broken internal links
  - consistent terminology and schema

---

## Example 3 – Partial Regeneration After a Failed Gate

**Scenario**: Phase 3 fails due to broken links introduced in an architecture file.

### Correct Behavior
1. DocsGen produces `03-phase3-issues.md` describing broken links.
2. The run status becomes Failed.
3. Previously approved Phase 1 and Phase 2 artifacts remain immutable.
4. The user either:
   - manually edits the affected architecture files and re-runs validation, or
   - explicitly requests regeneration of Phase 3 only.

### Incorrect Behavior (Forbidden)
- silently rewriting Phase 1 or Phase 2 outputs to “fix” Phase 3

---

## Example Issue (Broken Link)

A typical issues report includes actionable locations:

- File: `docsgen-12-arch-index.md`
- Rule: `links.internal.resolves`
- Message: “Link target does not exist: docsgen-24-arch-deployment.md”
- Action: correct the link or regenerate the file

---

---

[← DocsGen](docsgen.md)
1. **[Base](docsgen-00-base-index.md)** – conceptual foundations, terminology, and canonical schemas
2. **[Architecture](docsgen-12-arch-index.md)** – orchestration, agents, validators, storage, and hosting boundaries
3. **[UI](docsgen-26-ui-index.md)** – user workflows, screens, components, and interaction rules
4. **[Appendix](docsgen-39-appendix-index.md)** – folder mapping, task references, and implementation checklist
5. **[Diagrams](docsgen-43-diagrams.md)** – architecture, state machines, and end-to-end sequences

---
