# Architecture Resources (Reference)

---

## Endpoint Reference (UI-Facing)

```text
POST   /api/runs
GET    /api/runs/run_2025_12_14_0001
GET    /api/runs/run_2025_12_14_0001/events
POST   /api/runs/run_2025_12_14_0001/approve
POST   /api/runs/run_2025_12_14_0001/cancel
GET    /api/runs/run_2025_12_14_0001/artifacts
GET    /api/runs/run_2025_12_14_0001/artifact
GET    /api/runs/run_2025_12_14_0001/download
```

---

## Tool API Reference (Agent-Facing)

These operations should be small and deliberate:

```text
ListArtifacts
ReadArtifactText
WriteArtifactText
WriteArtifactBinary
GetPlannedFiles
SetPlannedFiles
ValidateLinks
ValidateNoPlaceholders
ValidateTerminology
ValidateSchemaConsistency
ComputeCompletenessScore
BundleZip
```

---

## Event Type Reference

- run.created
- phase.started
- artifact.written
- validation.started
- validation.passed
- validation.failed
- approval.required
- approval.recorded
- run.completed
- run.failed
- run.canceled

---

## Validator Rule ID Examples

- placeholders.forbidden
- links.internal.resolves
- terminology.forbidden_term
- terminology.undefined_term
- schema.drift
- ui.error_message_mismatch
- completeness.threshold

---

## Phase-to-File Mapping

| Phase | Core File Range |
|---|---|
| Phase 1 | docsgen.md, docsgen-00, docsgen-12, docsgen-26, docsgen-39 |
| Phase 2 | docsgen-01 through docsgen-11 |
| Phase 3 | docsgen-13 through docsgen-25 |
| Phase 4 | docsgen-27 through docsgen-38, docsgen-40 through docsgen-42 |
| Phase 5 | docsgen-43 |

---

---

[← DocsGen](docsgen.md)
1. **[Base](docsgen-00-base-index.md)** – conceptual foundations, terminology, and canonical schemas
2. **[Architecture](docsgen-12-arch-index.md)** – orchestration, agents, validators, storage, and hosting boundaries
3. **[UI](docsgen-26-ui-index.md)** – user workflows, screens, components, and interaction rules
4. **[Appendix](docsgen-39-appendix-index.md)** – folder mapping, task references, and implementation checklist
5. **[Diagrams](docsgen-43-diagrams.md)** – architecture, state machines, and end-to-end sequences

---
