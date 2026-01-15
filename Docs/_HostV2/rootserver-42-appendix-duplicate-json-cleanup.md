# Appendix: Duplicate JSON Cleanup

A concrete plan to eliminate `*Json.json` duplication and prevent it from returning.

---
## Duplication pattern

Duplicate JSON files were discovered in the `Json/` folder, where both a canonical name and a `*Json.json` variant exist.

Examples:
- `Json/galleryItemJson.json` ↔ `Json/galleryItem.json`
- `Json/galleryFilterJson.json` ↔ `Json/galleryFilter.json`
- `Json/galleryJson.json` ↔ `Json/gallery.json`
- `Json/sectionsJson.json` ↔ `Json/sections.json`
- `Json/contactJson.json` ↔ `Json/contact.json`
- `Json/appsJson.json` ↔ `Json/apps.json`
- `Json/agendaJson.json` ↔ `Json/agenda.json`
- `Json/textJson.json` ↔ `Json/text.json`
- `Json/pagesJson.json` ↔ `Json/pages.json`
- `Json/settingsJson.json` ↔ `Json/settings.json`
- `Json/tablesJson.json` ↔ `Json/tables.json`
- `Json/workspacesJson.json` ↔ `Json/workspaces.json`


## Impact / risk

- Confusion about canonical source-of-truth
- Drift between variants
- Higher maintenance burden
- Hard-to-debug production mismatches


## Canonical naming plan

- Canonical: prefer simple `*.json` (e.g., `pages.json`).
- Legacy: treat `*Json.json` as deprecated compatibility shims.


## Deprecation timeline

- Week 0: Identify consumers and switch new code to canonical names.
- Week 1–2: Update existing consumers; keep shims.
- Week 3+: Remove shims after verification.


## CI guardrail idea

Add a check that fails the build if both of these exist:
- `X.json`
- `XJson.json`

Optionally also emit a checksum report to support safe cleanup.


---
- **[Back to rootserver.md](rootserver.md)**
- **[Back to Appendix index](rootserver-39-appendix-index.md)**

---
