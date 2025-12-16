 # Azure AI DocGen — Execution Plan

---

 **Scope & objectives**
 - Target: Generate comprehensive plugin documentation using the 6‑phase system defined in `Docs/Extend/document-plugin-module.md`.
 - Output location: `Docs/Extend/Plugin-External/docgen/` (workspace for inputs, runs, artifacts).
 - Review mode: `interactive` (default; configurable via `generation-config.json`).
 - Validation strictness: `strict` (default; configurable).

---

 **1) Inputs & configuration**
 - Validate presence of:
   - `inputs/plugin-requirements.json` (authoritative spec)
   - Host project bundle: `inputs/host/rootServer.zip` or `host-path.txt`
   - Reference docset (optional but recommended): `inputs/reference/MODULE-node-editor.zip`
   - `generation-config.json` with `review_mode`, `validation_strictness`, and `profile`
 - Output: `runs/{runId}/phase0/00-preflight-summary.md` or `00-preflight-questions.md`

---

 **2) Phase 0 — Preflight**
 - Checks: plugin identity, entities/flows, host integration contract, validation policy, audit config, performance targets (per strictness rules).
 - Gate behavior:
   - On any blocking failure → emit `00-preflight-questions.md`, stop.
   - On pass → emit `00-preflight-summary.md`; proceed automatically in batch, or await approval in interactive.

---

 **3) Phase 1 — Foundation**
 - Actions:
   - Generate root + section indices; confirm `01-planned-files.json` as link authority.
   - Register artifacts (immutable once phase passes).
 - Validators (gate): no placeholders, link integrity (relative + resolvable), required sections, baseline terminology.
 - Artifacts: core docs (root/indices) + `01-phase1-validation.md`.
 - Interactive: require approval to advance.

---

 **4) Phase 2 — Base layer (Conceptual truth)**
 - Actions: generate conceptual files per `01-planned-files.json`; emit `02-terminology-index.json`.
 - Validators: terminology enforcement, schema coverage vs requirements, link integrity, placeholder ban.
 - Artifacts: base layer docs + `02-phase2-validation.md`.

---

 **5) Phase 3 — Architecture layer (Implementation)**
 - Actions: generate docs for orchestrator, agents, validators, artifacts, execution pattern, and OpenAPI tool surface.
 - Validators: cross‑refs vs base layer, link integrity, placeholder ban, schema consistency.
 - Artifacts: architecture docs + `03-phase3-validation.md`.

---

 **6) Phase 4 — UI & Appendix**
 - Actions: generate UI review experience, profiles/strictness, and appendices per profile.
 - Validators: exact‑match checks (where specified), link integrity, terminology consistency.
 - Artifacts: UI/appendix docs + `04-phase4-validation.md`.

---

 **7) Phase 5 — Diagrams & Cross‑validation**
 - Actions: produce consolidated diagrams (plain text blocks) and run cross‑doc validations; compute completeness score.
 - Validators: all validators + completeness threshold; assemble deliverable bundle.
 - Artifacts: `05-final-validation-report.md` + `{slug}-documentation-bundle.zip`.

---

 **8) Regeneration policy**
 - Only regenerate affected files within the current phase when a gate fails.
 - Passed phases’ core docs are immutable unless an explicit “regenerate failed phase” mode is initiated.

---

 **9) Planes & responsibilities (mapping)**
 - Experience plane (Blazor UI): uploads, config, run UI, approvals, downloads.
 - Control plane (Orchestrator API): state machine, agent runs, validator orchestration, eventing (SignalR/SSE), artifact registry as source‑of‑truth.
 - Intelligence plane (Foundry agents): content generation and optional human‑readable reports; use OpenAPI tools.
 - Deterministic plane (Tools/Validators/Storage): artifact store, validators (links/placeholder/terminology/schema), completeness scoring, bundling.

---

 **10) .NET solution layout (recommended)**
 - Projects:
   - `DocsGen.Web` (Blazor UI)
   - `DocsGen.Api` (orchestration + tool endpoints)
   - `DocsGen.Orchestration` (state machine, policies, run engine)
   - `DocsGen.Foundry` (Foundry SDK adapter, agent runner)
   - `DocsGen.Validation` (validators)
   - `DocsGen.Artifacts` (artifact store abstractions)
   - `DocsGen.Contracts` (DTOs shared across layers)

---

 **11) Tool surface (OpenAPI) — operationIds**
 - UI API: `GET/POST /api/runs`, `POST /api/runs/{runId}/approve`, `POST /api/runs/{runId}/cancel`, `GET /api/runs/{runId}/download`.
 - Tool API (for agents): `WriteArtifactText`, `WriteArtifactBinary`, `ListArtifacts`, `ReadArtifactText`, `GetPlannedFiles`, `SetPlannedFiles`, `ValidateLinks`, `ValidateNoPlaceholders`, `ValidateTerminology`, `ValidateSchemaConsistency`, `ComputeCompletenessScore`, `BundleZip`.
 - Orchestrator treats validator results as authoritative.

---

 **12) Execution pattern (timeout‑safe)**
 - For each phase: Plan → Generate each file (chunked) → Stage → Validate → Approve/Advance.
 - Run per‑file generations to avoid tool‑calling expiration windows.

---

 **13) Outputs & handoff**
 - Deliver `{slug}-documentation-bundle.zip` with `05-final-validation-report.md` after Phase 5.
 - Persist manifest and artifact index for audit and diff across runs.

---

 **14) Quality rules (always enforced)**
 - No placeholders; no broken links; terminology consistency; schema alignment; source‑of‑truth precedence.

---

 **Related**
 - [root.md](root.md)
 - [00-foundation-index.md](00-foundation-index.md)
 - [10-architecture-index.md](10-architecture-index.md)
 - [20-operations-index.md](20-operations-index.md)
 - [30-diagrams.md](30-diagrams.md)
 - [39-appendix-index.md](39-appendix-index.md)

---

**Back to index:**
- [root](root.md)
- [foundation](00-foundation-index.md)
- [architecture](10-architecture-index.md)
- [operations](20-operations-index.md)
- [appendix](39-appendix-index.md)

---