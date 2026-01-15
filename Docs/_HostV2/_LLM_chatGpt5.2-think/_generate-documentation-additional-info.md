# RootServer Host Documentation — Workflow Prompt

Produce a **strict, navigable Host documentation set** for the `RootServer` codebase, aligned to the reference formatting style and the project’s architectural conventions.

---

## Inputs

- **project_name:** `RootServer`
- **doc_slug**: equal to `project_name`
- **project_type:** `host`
- **project_source:** `user should point llm to path/zip`
- **save_output_to:** `user should point llm to output, create results, or zip or write on hd, then give path`
- Target folder for generated Host documentation.
- **example_docs_source:** `user should point llm to path/zip`
- Use as the formatting/style reference.

---

## Modes and Defaults

- **validation_strictness:** `strict`
- If set to `lenient`, still flag gaps, but don’t block generation.
- **review_mode:** `interactive`
- Can switch to `batch` later (generate everything, then review).

---

## Before You Begin

- **Ask for confirmation OR proceed immediately** if these are already correct:
- The `project_source` path is accessible and current.
- `save_output_to` is the intended Host docs output.
- `example_docs_source` is the intended template example.
- `validation_strictness = strict` is desired for this run.
- If anything looks inconsistent, **pause and request a correction before writing files**.

---

## Architectural Conventions

### UI hierarchy source folders

- Source of UI hierarchy: `Shared/_Sites`
- Hierarchical components that build up UIs.

### Cross-layer numbered folder hierarchy (micro → macro)

- `00_Core` → system classes
- `01_Displays` → read/output (text, images, Unity3D, etc.)
- `02_Fields` → read & write inputs (form fields, editors, etc.)
- `03_Pointers` → interaction helpers (buttons, dropdowns, selectors, etc.)
- `04_Actions` → user & system actions / control logic
- `05_Nodes` → node graph definitions
- `06_Components` → layout composed of displays, fields, pointers, actions
- `07_Widgets` → layout containers combining multiple views
- `08_View` → layout definitions for single or multiple views
- `09_Panels` → higher-level layout grouping multiple views
- these 10 items are an example, check if there are changes, might have new, might change numbering, might some be deleted, might not be implemented yet...

### Airtable vertical structure

- `Base → Table → Row → Field`

### Component prefix system and roles

- `D_` : Displays
- `F_` : Fields
- `P_` : Pointers
- `A_` : Actions
- `N_` : Nodes
- `C_` : Components
- `W_` : Widgets
- `V_` : Views
- `PNL_` : Panels
- these 9 items are an example, check if there are changes, might have new, might change numbering, might some be deleted, might not be implemented yet...

---

## Documentation Scope (Strict)

Baseline **~30–45+** to capture:

- Architecture overview and boundaries (**Host ↔ Modules ↔ Plugins**; present + planned Node system)
- Module and plugin system design
- Lifecycles, activation, unloading, discovery
- DI contracts
- Entities and data flows relevant to Host coordination
- Integrations (e.g., Airtable) at Host level and failure policies
- Performance targets and hotspots
- Caching, async patterns, rendering
- Error handling and error-code catalog
- Testing strategy and coverage
- Deployment/runtime configuration and feature flags
- UI scaffolding via `Shared/_Sites` hierarchies (00..08) and prefix conventions
- Diagrams
- System, deployment, sequence, boundary, hierarchy

---

## Dependency Boundaries and Allowed References

- **Module ↔ Module**
- Allowed: direct references
- Assumption: all modules are always active within the Host
- **Plugin ↔ Module**
- Allowed: plugins can reference all modules
- **Plugin ↔ Host**
- Allowed: plugins know about the Host
- Avoid: Host → Plugin dependencies (Host shouldn’t depend on plugins)
- **Plugin ↔ Plugin**
- Planned: via upcoming Node system
- Research: `Docs/Extend/Module-Internal/NodeEditor`
- For now: treat as experimental / planned capability (not a current baseline dependency)

---

## Formatting and Style Guide

Follow these conventions across generated docs:

- Headings: `#` (H1), `##` (H2), `###` (H3) — deeper headings rarely used
- Section dividers: `---` used frequently to separate major sections
- Lists: hyphen `-` bullets (nested lists also use hyphens)
- Use numbered lists only for short navigation sequences
- Emphasis: bold for link labels in index sections (e.g., **[UI](...)**); minimal italics
- Links: relative links between docs (e.g., `docsgen-26-ui-index.md`)
- Include a bottom “back-navigation” block with 1–5 items
- Code blocks: use triple backticks when needed; keep them minimal
- Tables: prefer lists instead (avoid tables unless unavoidable)
- Page layout pattern:
- Title
- Short intro
- `---`
- Section list / main content
- `---`
- Bottom nav index
- Trailing `---`

---

## Security and Safety

- Do **not** include keys, secrets, tokens, or sensitive values in outputs.
- If potential vulnerabilities or exposed secrets are found during analysis:
- Report them clearly (location + nature of risk)
- Do not reproduce sensitive values in the documentation

---

## Dedicated Sections to Add When Warranted

### Risks and Vulnerabilities (Appendix)

- Secret exposure checks, unsafe configs, insecure defaults
- Integration failure risks (timeouts, retries, backoff, circuit breakers)
- Boundary rule violations or high-risk dependencies
- Performance hotspots and memory/CPU pressure areas
- Concrete remediation steps and owners (if identifiable)

### Duplicate JSON Data (Appendix — Cleanup Task)

Document duplicate JSON files as an avoidable process mistake:

- Explain duplication pattern (e.g., `pages.json` vs `pagesJson.json`)
- Potential causes
- Dual export pipelines, transition compatibility, legacy consumers
- Impact/risk
- Confusion, drift, stale reads, higher maintenance
- Action plan
- Choose canonical names (prefer simple `*.json`)
- Update code references to canonical files
- Deprecate `*Json.json` variants with a short timeline
- Add a CI check to block future duplicates
- Optional: publish a checksum report for safe cleanup

Title suggestion:
- “Appendix — Duplicate JSON Data (Cleanup Task)”
- Optional playful subheading allowed, but keep overall tone constructive.

---

## Deliverable Categories (Target Pages)

Generate focused docs (as analysis reveals), including:

- Host Integration Architecture (Core/Arch)
- UI Hierarchy Model (UI)
- Performance Targets and Observability (Arch)
- Error Handling and Error Codes (Arch/UI)
- Testing and QA Strategy (Arch)
- Deployment and Configuration (Arch)

If new themes surface (schema evolution/versioning, data lineage, accessibility), add dedicated sections.

---
