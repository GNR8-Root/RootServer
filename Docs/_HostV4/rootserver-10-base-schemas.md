# Base Schemas

---

## JSON Schema Inventory

RootServer caches Airtable schemas in the `Json/` folder for offline development.

### Schema Types

| Schema | Purpose | Files |
|--------|---------|-------|
| Workspaces | Workspace definitions | workspaces.json, workspacesJson.json |
| Tables | Table metadata | tables.json, tablesJson.json |
| Pages | Page layouts | pages.json, pagesJson.json |
| Sections | Section configs | sections.json, sectionsJson.json |
| Apps | App configs | apps.json, appsJson.json |
| Gallery | Gallery items/filters | gallery*.json |
| Text | Text content | text.json, textJson.json |
| Colors | Color schemes | colors.json, colorsJson.json |
| Settings | Settings | settings.json, settingsJson.json |
| Media | Media collections | media*.json |

---

## Duplicate File Detection

**Issue:** Multiple JSON files exist with inconsistent naming:
- `pages.json` vs `pagesJson.json`
- `tables.json` vs `tablesJson.json`
- Pattern: `lowercase.json` vs `camelCaseJson.json`

**Impact:**
- Risk of data drift
- Maintenance overhead
- Potential for stale reads

**Remediation:** See Appendix 42 for cleanup plan.

---

## Versioning

**Current State:** No explicit versioning in schemas

**Recommendation:**
- Add `schemaVersion` field to JSON files
- Implement migration strategy
- Document breaking changes

---

[← Back to Base Index](rootserver-00-base-index.md)

---
