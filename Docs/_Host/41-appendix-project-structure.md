# Appendix — Project Structure (Host)

Annotated structure for Host-relevant folders. This is a high-level aid; detailed module/plugin internals live elsewhere.

---

## Key Folders (Host Scope)
- `Shared/_Core` — building blocks (00..08 layers)
- `Shared/_Sites` — UI source of truth
- `Shared/Plugins` — plugin code (Host should not depend on these)
- `Docs/Extend` — reference materials (e.g., Node system research)
- `wwwroot` — static assets

---

## Example Annotations
Shared/_Sites/ 05_Components/      # Reusable UI assemblies 06_Widgets/         # Multi-view containers 07_View/            # Route-level views 08_Panels/          # Top-level groupings across areas

---

**Back navigation:** **[Appendix Index](./docsgen-39-appendix-index.md)** · **[Root Index](./RootServer.md)**

---
