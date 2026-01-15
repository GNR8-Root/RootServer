 # Appendix A2 — Sample Prompts (Per Phase) and Tool Calls
 
 Purpose
 - Provide copy-pasteable prompt scaffolds for Azure AI Foundry persistent agents.
 - Align with source-of-truth precedence and phase gates from document-plugin-module.md.
 - Keep runs short: generate one file per run where possible.
 
 Conventions
 - Inputs assumed: `plugin-requirements.json`, host reference, reference docset, and `01-planned-files.json` (if available).
 - Do not ask the agent to validate; validators run in the deterministic plane.
 - Always specify: exact filename, acceptance criteria, and link constraints.
 
 Phase 0 — Preflight reporter (optional)
 ```text
 System/Instruction
 You are the preflight_reporter agent. Read the provided plugin-requirements.json and host structure summary. Produce a concise preflight summary, listing blocking and non-blocking items per the Preflight checklist. Do not invent data. If a required field is missing, emit a question.
 
 Acceptance
 - Output: Markdown sectioned as Blocking / Warnings / Inputs Confirmed
 - No placeholders, no external links
 - Reference facts using JSON keys where possible
 ```
 
 Phase 1 — Foundation index files
 ```text
 User
 Generate file {slug}-00-base-index.md.
 
 Constraints
 - Follow source-of-truth precedence: JSON > Host > Reference > Brief
 - Include relative links only to files that exist in 01-planned-files.json
 - No placeholders like TODO/TBD/{}
 - Define acronyms on first use within the file
 
 Acceptance criteria
 - Sections: Overview, Contents, Conventions, Next Steps
 - Links resolve to Phase 2/3 placeholders by name only (no external URLs)
 ```
 
 Phase 2 — Base layer conceptual docs
 ```text
 User
 Generate file {slug}-11-base-schema.md.
 
 Context
 - Entities and fields must reflect plugin-requirements.json exactly
 - Include ID strategies and validation notes per entity
 
 Acceptance criteria
 - Every entity listed; each has id, fields (>=3), and validation notes
 - Terminology consistent with terminology index (Phase 2 artifact)
 - No redefinitions of established terms within this file
 ```
 
 Phase 3 — Architecture docs
 ```text
 User
 Generate file {slug}-18-architecture-dataflow.md.
 
 Context
 - Use host integration constraints from host reference
 - Map flows from users_and_flows.primary_flows to components
 
 Acceptance criteria
 - Include a high-level ASCII diagram (```text block) of data flow
 - All internal links relative and resolve against planned files
 - No code that cannot compile; pseudocode is allowed inside fenced blocks
 ```
 
 Phase 4 — UI & Appendix docs
 ```text
 User
 Generate file {slug}-35-ui-validation.md.
 
 Context
 - Error message strings MUST match plugin-requirements.json definitions exactly
 
 Acceptance criteria
 - Table of validations with exact messages
 - Cross-links to UI index and relevant base/arch docs
 - No placeholders; anchors must exist
 ```
 
 Phase 5 — Diagrams & cross-validation
 ```text
 User
 Generate file {slug}-43-diagrams.md.
 
 Constraints
 - Use plain text diagrams in ```text code blocks
 - Include: system overview, phase state, execution sequence, artifact authority
 
 Acceptance criteria
 - Each diagram self-contained; cross-links to relevant chapters
 - No external links
 ```
 
 OpenAPI tool call examples (agent → Tool API)
 ```json
 {
   "operationId": "WriteArtifactText",
   "parameters": { "path": "{runId}/2/{slug}-11-base-schema.md" },
   "requestBody": { "text": "# {slug} Base Schema..." }
 }
 ```
 ```json
 {
   "operationId": "ValidateNoPlaceholders",
   "parameters": { "runId": "{runId}", "phase": 2 }
 }
 ```
 
 Do/Don’t
 - Do: name the exact file and acceptance criteria up front
 - Do: cite JSON keys verbatim when asserting facts
 - Don’t: invent entities/fields; don’t include external links
 
 Related
 - [12-phase-execution-pattern.md](12-phase-execution-pattern.md)
 - [08-tool-surface-openapi.md](08-tool-surface-openapi.md)
 - [09-validation-and-completeness.md](09-validation-and-completeness.md)

---

**Back to index:**
- [root](root.md)
- [foundation](00-foundation-index.md)
- [architecture](10-architecture-index.md)
- [operations](20-operations-index.md)
- [appendix](39-appendix-index.md)

---