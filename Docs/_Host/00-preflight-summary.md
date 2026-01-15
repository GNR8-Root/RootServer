# RootServer — Preflight Summary (Host Documentation)

This preflight confirms inputs, conventions, and boundaries for generating a strict Host documentation set.

---

## Inputs (Confirmed)
- project_name: RootServer
- project_type: host
- project_source: /Users/znzr/Documents/Dropbox/gits-_root/RootServer
- save_output_to: Docs/Host
- example_docs_source (style): Docs/Extend/Plugin-External/azure-ai-docsgen-chatgpt
- validation_strictness: strict
- review_mode: interactive

---

## Style & Formatting (Applied)
- Headings: #, ##, ###
- Section dividers: `---`
- Lists: hyphen `-` (nested also hyphens)
- Numbered lists: only for short navigational steps
- Emphasis: bold for link labels in indices
- Links: relative within Docs/Host
- Bottom navigation: present on each page (1–5 items)

---

## Architectural Conventions (Host)
- UI hierarchy source: `Shared/_Sites`
- Cross-layer numbered hierarchy (micro → macro):
  - 00_Core → system classes
  - 01_Displays → read/output
  - 02_Fields → read & write inputs
  - 03_Pointers → interaction helpers
  - 04_Actions → user & system actions / control logic
  - 05_Components → layout composed of displays, fields, pointers, actions
  - 06_Widgets → containers combining multiple views
  - 07_View → single or multi-view definitions
  - 08_Panels → higher-level grouping
- Airtable vertical: Base → Table → Row → Field
- Component prefixes: D_, F_, P_, A_, C_, W_, V_, PNL_

---

## Dependency Boundaries (Allowed References)
- Module ↔ Module: allowed (assumed always active within Host)
- Plugin ↔ Module: allowed (plugins can reference all modules)
- Plugin ↔ Host: allowed (plugins know about Host)
- Host → Plugin: avoid direct dependencies
- Plugin ↔ Plugin: planned via Node system (experimental)

---

## Security & Safety
- Do not include secrets, keys, tokens, or sensitive values in docs
- If potential exposure is detected during generation: report file path and nature of risk; do not reproduce values

---

## Preflight Checks
- Paths detected: OK (source, output, style reference present)
- Conventions provided: OK
- Boundaries defined: OK
- Strict mode: enabled (requires diagrams and performance targets; any gaps will be called out and resolved during later phases)

---

## Next Steps
- Phase 1 (Foundation): generate entry and indices
- Phase 2+: fill Host-focused content (reduced sets) with strict validation, diagrams, and observability targets

---

**Back navigation:** **[Root Index](./RootServer.md)**

---