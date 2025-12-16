 # Appendix A3 — Troubleshooting Guide
 
 Purpose
 - Resolve common failures across phases 0–5 for Azure AI DocGen.
 - Provide actionable steps, not just causes. No placeholders.
 
 How to use
 - Identify the failing phase and error. Follow the checklist. If regeneration is needed, prefer partial regeneration for affected files only.
 
 Phase 0 (Preflight) failures
 - Symptom: Missing `plugin.slug` or `plugin.name`.
   - Fix: Update `plugin-requirements.json` → `plugin.slug` must be lowercase-hyphenated.
   - Re-run: Start a new run; preflight must pass before generation.
 - Symptom: No `users_and_flows.primary_flows`.
   - Fix: Add at least one primary flow with steps.
 - Symptom: Host integration contract missing.
   - Fix: Provide runtime UI framework and model in `host_integration_contract`.
 
 Phase 1 (Foundation) gate fails
 - Symptom: Placeholder strings found.
   - Fix: Search for `TODO`, `TBD`, `{}` patterns and remove.
   - Prevention: In prompts, include “No placeholders” constraint.
 - Symptom: Broken internal links.
   - Fix: Ensure links target files listed in `01-planned-files.json`.
   - Regenerate: Only the files with broken links, then re-run Phase 1 gate.
 
 Phase 2 (Base Layer) gate fails
 - Symptom: Terminology inconsistency.
   - Fix: Generate or update `02-terminology-index.json`; align terms in docs.
 - Symptom: Schema coverage incomplete.
   - Fix: Ensure every entity from JSON appears in `-11-base-schema.md` with fields.
 
 Phase 3 (Architecture) gate fails
 - Symptom: Architecture doc cites features not in host reference.
   - Fix: Apply source-of-truth precedence; remove unsupported claims.
 - Symptom: Link errors to Phase 2 files.
   - Fix: Verify file names and anchors; keep relative links.
 
 Phase 4 (UI & Appendix) gate fails
 - Symptom: UI validation strings mismatch.
   - Fix: Copy exact strings from `plugin-requirements.json` error definitions.
 - Symptom: Missing appendix links.
   - Fix: Add or adjust `39-appendix-index.md`; ensure appendix files exist.
 
 Phase 5 (Diagrams & Final) gate fails
 - Symptom: Diagram file missing or contains Mermaid.
   - Fix: Provide plain text diagrams within ```text blocks.
 - Symptom: Completeness below threshold.
   - Fix: Address missing coverage per validator report, then re-run gate.
 
 Foundry agent run/timeouts
 - Symptom: Run expires (~10 minutes) during long tool loops.
   - Fix: Reduce per-run scope to one file; use chunked phase execution.
 - Symptom: Tool API call fails (401/403).
   - Fix: Verify identity (local dev token vs managed identity in cloud) and API permissions.
 
 OpenAPI tool errors
 - Symptom: operationId not found.
   - Fix: Ensure the OpenAPI spec published by Tool API defines the exact `operationId`.
 - Symptom: Schema mismatch.
   - Fix: Align request body/parameters with the server contract.
 
 Regeneration strategy (safe)
 - Prefer targeted regeneration: only the files reported as failed.
 - Never overwrite immutable artifacts from completed phases unless explicitly entering “regenerate failed phase” mode in the orchestrator.
 
 Related
 - [09-validation-and-completeness.md](09-validation-and-completeness.md)
 - [12-phase-execution-pattern.md](12-phase-execution-pattern.md)
 - [11-artifacts-and-manifest.md](11-artifacts-and-manifest.md)

---

**Back to index:**
- [root](root.md)
- [foundation](00-foundation-index.md)
- [architecture](10-architecture-index.md)
- [operations](20-operations-index.md)
- [appendix](39-appendix-index.md)

---
