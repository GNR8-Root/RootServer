# Glossary and Terminology

## Purpose
- Canonical definitions used across Azure AI DocGen docs. Terms align with `Docs/Extend/document-plugin-module.md` and the internal manual in this folder.

---

## Conventions
- Lowercase kebab case for files (`{slug}-NN-name.md`).
- JSON overrides prose when conflicts exist (source‑of‑truth precedence).

---

## Core concepts
- **Run**: A single end‑to‑end documentation generation execution. Identified by `RunId`.


- **Phase**: One of the ordered stages 0→5. Each phase has its own inputs, outputs, and validation gate.


- **Gate**: Deterministic validation checkpoint at the end of a phase. In interactive mode, the gate requires user approval to continue.


- **ReviewMode**: `interactive` or `batch`. Interactive pauses after each phase for approval.


- **Strictness**: `strict` or `lenient`. Strict enforces all mandatory rules; lenient keeps core guarantees but downgrades some failures to warnings.


- **Profile**: A named policy preset controlling required files/phases and validator enforcement (e.g., `Full43Strict`, `Minimal13`).


- **Core** Docs: The 43 (or profile‑selected subset of) numbered `.md` deliverables comprising the documentation bundle.


- **Generation** **Artifacts**: Non‑deliverable files aiding validation and review (e.g., `01-planned-files.json`, `02-terminology-index.json`, `XX-phaseY-validation.md`).


- **Planned** **Files**: The authoritative list of files expected for this run and profile. Used for link validation and completeness checks.


- **Source‑of‑Truth Precedence**: Conflict resolution order: `plugin-requirements.json` → host architecture docs → reference docset → natural language brief.


- **Immutability**: Once a phase passes, its Core Docs cannot be overwritten unless the run is placed in an explicit “regenerate failed phase” mode.


- **Regeneration Policy**: Targeted regeneration must limit changes to affected files and re‑validate the impacted phase without silently altering previously approved outputs.


- **Artifact**: Any persisted file for a run, including inputs, core docs, and artifacts. Tracked with metadata (hash, size, classification, createdBy, timestamps).


- **ArtifactIndex**: The per‑run index of all artifacts with paths organized by phase and classification.


- **Manifest**: The durable record (DB/table/document) that indexes runs, phases, artifacts, and validation issues for audit and introspection.


- **Completeness Score**: Ratio of documented requirements to total requirements derived from `plugin-requirements.json`. Thresholds vary by strictness/profile.


- **Validators**: Deterministic checks (no LLM judgment) including: forbidden string scanner, link validation, terminology consistency, schema consistency, error message matching, completeness scoring.


- **Foundry Agent**: An Azure AI Foundry Persistent Agent that generates content or reports; called via `.NET Azure.AI.Projects` and optionally uses OpenAPI tools.


- **PersistentAgentsClient**: SDK client surface to manage agent threads, messages, and runs.


- **OpenAPI Tool**: A Tool API surface callable by agents, exposing deterministic operations (artifact write/read, validate, bundle).


- **Tool API**: The API face accessed by agents through OpenAPI tools (operationIds are mandatory).


- **UI API**: The API face accessed by the Blazor UI for run lifecycle and downloads.


- **Thread/Run (Foundry)**: Foundry’s unit of conversation/execution. The orchestrator uses a thread per phase and creates runs to execute tool‑enabled steps.


- **Chunk**: A small, bounded unit of generation (commonly a single file) to avoid long tool‑calling sessions and timeouts.


- **Bundle**: The final zip exported after Phase 5 validation, containing only Core Docs (and indices) for delivery.


- **Inputs**: Files provided to start a run: `plugin-requirements.json`, host bundle or path, reference docset (optional), and documentation formula.


- **Terminology Index**: JSON produced in Phase 2 that defines domain terms and enforces consistent usage across Core Docs.


- **Acceptance Criteria**: Explicit per‑file success rules embedded in prompts and validated deterministically at gates.

---

## Abbreviations and acronyms
- **SoT**: Source of Truth.
- **MI**: Managed Identity.
- **DTO**: Data Transfer Object.
- **SSE**: Server‑Sent Events.
- **RBAC**/**ABAC**: Role‑Based / Attribute‑Based Access Control.

---

**Related**
- [00-foundation-index.md](00-foundation-index.md)
- [09-validation-and-completeness.md](09-validation-and-completeness.md)
- [11-artifacts-and-manifest.md](11-artifacts-and-manifest.md)
- [12-phase-execution-pattern.md](12-phase-execution-pattern.md)

---

**Back to index:**
- [root](root.md)
- [foundation](00-foundation-index.md)
- [architecture](10-architecture-index.md)
- [operations](20-operations-index.md)
- [appendix](39-appendix-index.md)

---