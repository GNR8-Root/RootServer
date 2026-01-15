# Diagrams Collection (Architecture, Flows, and Models)

This page consolidates key visuals for Azure AI DocGen: end‑to‑end architecture, phase state machine, execution sequencing, artifact authority relationships, UI review flow, Foundry agent topologies, and core .NET solution structure.

Contents
- System overview (end‑to‑end)
- Phase state machine
- Phase execution (chunk loop)
- Artifact authority and immutability
- UI review experience timeline
- Foundry agent topologies (6‑agent vs dual‑agent)
- Solution layout and dependencies
- Validation modules class model

Related reading
- [06-orchestration-engine.md](06-orchestration-engine.md)
- [07-foundry-agents.md](07-foundry-agents.md)
- [09-validation-and-completeness.md](09-validation-and-completeness.md)
- [11-artifacts-and-manifest.md](11-artifacts-and-manifest.md)
- [12-phase-execution-pattern.md](12-phase-execution-pattern.md)

Diagram legend (rendered as plain text)
- [ ] boxes denote services/processes
- ( ) denote storage
- <>  denotes gates/decisions
- --- dashed lines are optional/secondary

System overview (end‑to‑end)
```text
 [Blazor UI: DocsGen.Web]
           |
           | REST/SignalR
           v
 [DocsGen.API: Orchestrator & Tool API]
     |                 \
     | Run/Thread       \ OpenAPI tool calls
     v                   \
 [Phase Orchestrator]    [Tool API: Artifacts + Validators] ---> (Artifact Store: Blob)
     |                         |                                   \
     |                         | writes/reads                        (Manifest DB)
     v                         v
 [Azure AI Foundry: Persistent Agents]    <--- validators --->  [Deterministic Validators]

 Notes:
 - Orchestrator is the single source of truth for phase/gates.
 - Tool API provides deterministic operations; agents do content only.
```

Phase state machine (0→5)
```text
  [Start]
     |
     v
  (Phase 0: Preflight) --fail--> [Failed]
             |
             '----pass---->
                             (Phase 1: Foundation) --gateFail--> [Failed]
                                          |
                              +-----------+-----------+
                              |                       |
                        [interactive]           [batch]
                              |                       |
                      [Awaiting Approval]             v
                              | approved               (Phase 2)
                              v                        |
                             (Phase 2) --gateFail--> [Failed]
                                          |
                                         (Phase 3) --gateFail--> [Failed]
                                          |
                                         (Phase 4) --gateFail--> [Failed]
                                          |
                                         (Phase 5) --gateFail--> [Failed]
                                          |
                                          '----pass----> [Complete]
```

Phase execution (chunked generation pattern)
```text
 UI              Orchestrator API        Foundry Agent        Tool API          Artifact Store
 |  Start Run  ->|                       |                    |                  |
 |               | Plan Phase N -------->|                    |                  |
 |               |<----- Planned files --|                    |                  |
 |               | For each file:        |                    |                  |
 |               |  Generate {name}.md ->|                    |                  |
 |               |                       | WriteArtifactText ->|----------------->| (persist)
 |               | Quick checks -------->|                    |                  |
 |               | Run validators ------>|--------------------|----------------->| (read/check)
 |<- Gate result-|                       |                    |                  |
 | Approve/regen |                       |                    |                  |
 |  (interactive)|                       |                    |                  |
```

Artifact authority and immutability
```text
  Sources of Truth                         Core Docs                 Storage/Index
  ------------------                       ---------                 -------------
  [plugin-requirements.json]  --->
  [Host architecture docs]     --->         [01-planned-files.json]  ---> [Core Docs (43)] ---> (Artifact Store) ---> (Manifest DB)
  [Reference docset zip]       --->
  [Natural language brief]     --->

  Rules:
  - JSON > Host > Reference > Brief (precedence when conflicts exist)
  - Core Docs are immutable once a phase passes, unless explicitly regenerating a failed phase
```

UI review experience timeline
```text
  [Start Run]
       |
       v
  (Phase 0: Preflight) -- pass? --> No --> [Stop with questions]
                             |
                             Yes
                             v
  (Phase 1: Foundation) -- gate pass? --> No --> [Regenerate affected files] --\
                             |                                           ^     \
                             Yes                                         |      \
                             v                                           |       \
                      [Interactive?] -- Yes --> [User approves] ---------+        \
                             | No                                                    v
                             v                                                     (Phase 2) -> (Phase 3) -> (Phase 4) -> (Phase 5) -> [Bundle + Complete]
```

Foundry agent topologies
```text
 Option 1: Six Agents (closest to spec)
   - preflight_validator
   - foundation_generator
   - base_layer_generator
   - architecture_layer_generator
   - ui_appendix_generator
   - diagram_final_validator

 Option 2: Dual Agents (operationally robust)
   - phase_generator  --- produces files
   - phase_reporter   --- produces phaseX-validation.md
```

.NET solution layout and dependencies
```text
  DocsGen.Web (Blazor) --> DocsGen.Api
  DocsGen.Api -> DocsGen.Orchestration
  DocsGen.Api -> DocsGen.Foundry
  DocsGen.Api -> DocsGen.Validation
  DocsGen.Api -> DocsGen.Artifacts
  DocsGen.Web -> DocsGen.Contracts
  DocsGen.Api -> DocsGen.Contracts
  DocsGen.Orchestration -> DocsGen.Contracts
  DocsGen.Foundry -> DocsGen.Contracts
  DocsGen.Validation -> DocsGen.Contracts
  DocsGen.Artifacts -> DocsGen.Contracts
```

Validation modules (class model excerpt)
```text
  +-----------------------+
  |       IValidator      |  ValidateAsync(RunId, Phase): ValidationResult
  +-----------------------+
           ^        ^        ^         ^
           |        |        |         |
  +----------------+  +----------------------+  +--------------------+  +------------------+
  | ForbiddenString|  | MarkdownLinkValidator|  | TerminologyValidator|  | SchemaValidator |
  |  Scanner       |  | ValidateAsync(...)   |  | ValidateAsync(...)  |  | ValidateAsync() |
  +----------------+  +----------------------+  +--------------------+  +------------------+

  CompletenessScorer --used by gates--> IValidator (composes results)
```

Project structure (high-level folders)
```text
 RootServer/
 ├─ Docs/
 │  └─ Extend/
 │     └─ Module-Internal/NodeEditor/azure-ai-docgen/
 ├─ Shared/
 │  ├─ _Core/
 │  ├─ _Editor/
 │  └─ Plugins/
 ├─ Json/
 ├─ Pages/
 ├─ wwwroot/
 └─ Docs/Extend/Plugin-External/docgen/
```

Notes
- Diagrams reflect the behavior and rules described in the architecture pages and in `Docs/Extend/document-plugin-module.md` (source‑of‑truth precedence, validation gates, immutability, regeneration policy).
- Use these visuals as quick references when implementing or reviewing the system.

Orchestration domain types (class inheritance sketch)
```text
  +-------------------+         +------------------+
  |       Run         |<>------>|   PhaseExecution |
  +-------------------+         +------------------+
  | RunId             |         | PhaseNumber      |
  | ReviewMode        |         | AgentId          |
  | Strictness        |         | Inputs[]         |
  | CurrentPhase      |         | Outputs[]        |
  | Status            |         | ValidationResult |
  | ManifestId        |         | UserApproval     |
  +-------------------+         +------------------+
           |                                 
           | has many                        
           v                                 
  +-------------------+         +------------------+
  |   ArtifactIndex   |<>------>|   Artifact       |
  +-------------------+         +------------------+
  | RunId             |         | Path             |
  | PhaseNumber       |         | Hash / Size      |
  | Classification    |         | Classification   |
  +-------------------+         | CreatedBy        |
                                 +------------------+
```

API endpoint matrix (UI API vs Tool API)
```text
 UI API (for Blazor UI)
  - GET  /api/runs/{runId}
  - POST /api/runs                    [start]
  - POST /api/runs/{runId}/approve    [gate]
  - POST /api/runs/{runId}/cancel
  - GET  /api/runs/{runId}/download   [bundle]

 Tool API (for Foundry agents via OpenAPI tools)
  - POST /tool/artifacts/write-text           (operationId: WriteArtifactText)
  - POST /tool/artifacts/write-binary         (operationId: WriteArtifactBinary)
  - GET  /tool/artifacts/list                 (operationId: ListArtifacts)
  - GET  /tool/artifacts/read-text            (operationId: ReadArtifactText)
  - GET  /tool/planned-files/get              (operationId: GetPlannedFiles)
  - POST /tool/planned-files/set              (operationId: SetPlannedFiles)
  - POST /tool/validate/links                 (operationId: ValidateLinks)
  - POST /tool/validate/placeholders          (operationId: ValidateNoPlaceholders)
  - POST /tool/validate/terminology           (operationId: ValidateTerminology)
  - POST /tool/validate/schema                (operationId: ValidateSchemaConsistency)
  - POST /tool/score/completeness             (operationId: ComputeCompletenessScore)
  - POST /tool/bundle/zip                     (operationId: BundleZip)
```

---

**Back to index:**
- [root](root.md)
- [foundation](00-foundation-index.md)
- [architecture](10-architecture-index.md)
- [operations](20-operations-index.md)
- [appendix](39-appendix-index.md)

---