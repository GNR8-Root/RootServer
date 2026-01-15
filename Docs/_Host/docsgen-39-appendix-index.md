# Appendix Index — Structure, Risks, Cleanup Tasks

Appendix for Host docs: structure reference, risks/vulnerabilities, and duplicate JSON cleanup task.

---

## Project Structure (Host-Focused)
- Source root: `/Users/znzr/Documents/Dropbox/gits-_root/RootServer`
- Key folders (host scope):
    - `Shared/_Core` (00..09 layers)
    - `Shared/_Sites` (UI hierarchy)
    - `Shared/Plugins` (plugin implementations; Host should not depend on these)
    - `Docs/Extend` (reference materials, planned Node system research)
    - `wwwroot` (static assets)

---

## Risks & Vulnerabilities (to monitor during generation)
- Secret exposure: guard `appsettings*.json`, environment variables, and connection strings
- Integration failure policies: ensure timeouts/retries/backoff documented
- Boundary violations: audit for Host → Plugin references
- Performance hotspots: rendering, async contention, caching effectiveness

---

## Duplicate JSON Data — Cleanup Task
- Problem: duplicated JSON variants (e.g., `pages.json` vs `pagesJson.json`) cause drift
- Causes: dual export pipelines, transition compatibility, legacy consumers
- Impact: confusion, stale reads, higher maintenance
- Action plan:
    - Choose canonical names (prefer `*.json`)
    - Update code references to canonical files
    - Deprecate `*Json.json` variants with a short timeline
    - Add CI check to block future duplicates
    - Optional: publish checksum report to guide safe cleanup

---

**Back navigation:** **[Root Index](./RootServer.md)** · **[Base Index](./docsgen-00-base-index.md)** · **[Architecture Index](./docsgen-12-arch-index.md)** · **[UI Index](./docsgen-26-ui-index.md)**

---


