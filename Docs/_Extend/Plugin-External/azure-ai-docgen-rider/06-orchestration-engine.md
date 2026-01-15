# Orchestration Engine (State Machine + Gates)

---
## Responsibilities
- Drive phases 0→5 with explicit gate checks and user approvals (interactive)
- Enforce immutability and regeneration policy
- Coordinate with Foundry agents and deterministic validators
- Emit structured run events for the UI

---
## Core concepts
- Run: `RunId`, `ReviewMode`, `Strictness`, `CurrentPhase`, `Status`, `ArtifactsManifestId`
- PhaseExecution: `PhaseNumber`, `AgentId`, `Inputs`, `Outputs`, `ValidationResult`, `UserApproval`
- Artifact: `Path`, `Hash`, `Size`, `Type (CoreDoc|GenerationArtifact|Input|Report)`

---
## State machine (phases)
```text
[*]
 |
 v
Preflight
 |-- pass --> Foundation
 |-- fail --> Failed

Foundation
 |-- pass --> Base
 |-- interactive --> AwaitingApproval

AwaitingApproval
 |-- approve --> Base
 |-- cancel --> Cancelled

Base
 |-- pass --> Architecture
 |-- fail --> Failed

Architecture
 |-- pass --> UIAppendix
 |-- fail --> Failed

UIAppendix
 |-- pass --> Diagrams
 |-- fail --> Failed

Diagrams
 |-- pass --> Complete
 |-- fail --> Failed
```

---
## Regeneration policy
- CoreDoc artifacts are immutable once a phase has passed. Overwrite attempts are rejected unless run is in an explicit "regenerate phase X" mode.
- Regeneration affects only impacted files; planned files remain the authority for link checks.

---
## Gate protocol
1) Run agent for the phase (file-by-file for long phases)
2) Persist outputs to artifact store (staging paths)
3) Execute validators; produce `XX-phaseX-validation.md`
4) If `pass` and review mode is interactive → `AwaitingApproval`
5) On approval → materialize artifacts to immutable paths and advance phase

---

**Related**
- [07-foundry-agents.md](07-foundry-agents.md)
- [11-artifacts-and-manifest.md](11-artifacts-and-manifest.md)
- [12-phase-execution-pattern.md](12-phase-execution-pattern.md)
- [09-validation-and-completeness.md](09-validation-and-completeness.md)

---

**Back to index:**
- [root](root.md)
- [foundation](00-foundation-index.md)
- [architecture](10-architecture-index.md)
- [operations](20-operations-index.md)
- [appendix](39-appendix-index.md)

---