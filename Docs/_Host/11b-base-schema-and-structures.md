# Base Schema & Structures — RootServer Host

Structures the Host coordinates or expects. This is Host-focused; detailed plugin or module internals belong in their own docs.

---

## Project Structure (Selected)
- `Shared/_Core` — UI and logic building blocks (00..08 layers)
- `Shared/_Sites` — UI hierarchy source (views, panels, sections)
- `Shared/Plugins` — plugin implementations (Host should not depend on these)
- `Docs/Extend` — reference materials (e.g., Node system research)
- `wwwroot` — static assets

---

## Data & Configuration
- Runtime configuration: `appsettings.json` + environment overrides
- Secrets handling: use environment/user secrets; do not embed secrets in docs or code samples
- Feature flags: host-level toggles for modules/plugins (naming and scope to be enumerated during Architecture phase)

---

## UI Structures (Conceptual)
- Views and Panels map to routes and major areas
- Widgets compose multiple components/views
- Components assemble Displays/Fields/Pointers/Actions into reusable blocks

---

## Airtable Vertical (Host Perspective)
- Base → Table → Row → Field
- Host coordinates integrations and error handling strategy; implementation specifics in module/plugin docs

---

**Back navigation:** **[Base Index](./docsgen-00-base-index.md)** · **[Root Index](./RootServer.md)**

---



