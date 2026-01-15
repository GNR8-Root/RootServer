# Appendix — Duplicate JSON Data (Cleanup Task)

Identify and eliminate duplicate JSON files (e.g., `pages.json` vs `pagesJson.json`) to reduce drift and confusion.

---

## Problem & Causes
- Duplicate variants arise from multiple export pipelines or legacy compatibility
- Leads to stale reads, confusion, and maintenance overhead

---

## Action Plan
- Choose canonical names (prefer simple `*.json`)
- Update code references to canonical files
- Deprecate `*Json.json` variants with a short timeline
- Add a CI check to block future duplicates
- Optional: publish checksum report for safe cleanup

---

**Back navigation:** **[Appendix Index](./docsgen-39-appendix-index.md)** · **[Root Index](./RootServer.md)**

---





