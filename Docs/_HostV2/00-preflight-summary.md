# Preflight summary — RootServer

This run is configured to generate a strict, navigable documentation set for the `RootServer` host codebase.

---

## Resolved inputs

- project_name: `RootServer`
- doc_slug: `rootserver`
- project_type: `host`
- project_source: `/mnt/data/RootServer.zip`
- example_docs_source: `/mnt/data/MODULE-docsgen.zip`
- save_output_to: `/mnt/data/rootserver-docs-out-run`

---

## Modes

- validation_strictness: `strict`
- review_mode: `interactive`
- external_links_allowed: `false` (default)
- depth: `balanced` (default)

---

## Scope rules applied

Excluded by default (inventory + docs evidence scanning):

- `bin/`, `obj/`, `.git/`, `.vs/`, `node_modules/`, `dist/`

Included / emphasized:

- `Shared/_Sites/`
- `Shared/_Core/` and `Shared/_Editor/`
- `Shared/Plugins/`
- `Docs/`
- `Program.cs`, `*.csproj`, `appsettings*.json`

---

## Assumptions used

- External links are disallowed except if explicitly enabled (not enabled in this run).
- Where runtime targets (performance budgets, SLAs, etc.) are not discoverable in code, the docs will state **unknown** and record investigation steps.

---

## Artifact references

- Inventory: `01-source-inventory.md`
- Planned files: `01-planned-files.json`

---

---
- **[Back to rootserver.md](rootserver.md)**
- **[Back to rootserver.md](rootserver.md)**

---
