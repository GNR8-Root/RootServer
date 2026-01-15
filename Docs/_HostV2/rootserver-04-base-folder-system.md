# Base Folder System

How the codebase is laid out on disk, and the conventions discovered from the real tree.

---
## Top-level layout

Discovered top-level folders (non-exhaustive):
- `Shared/`
- `Docs/`
- `wwwroot/`

Evidence:
- `RootServer.csproj`
- `Shared/`


## Key folders

- `Shared/_Sites/` — UI hierarchy (Pages/Layouts/Components/Sections/Nav)
- `Shared/_Core/` — layered building blocks (00..09)
- `Shared/_Editor/` — editor-oriented layered building blocks (00..09 + `02_Properties`)
- `Shared/Plugins/` — integration/plugin-style code (e.g., Airtable)


## Discovered numbered layers

In `Shared/_Core/` and `Shared/_Editor/`, the following numbered layer folders exist:

- `00_Core`
- `01_Displays`
- `02_Fields`
- `03_Pointers`
- `04_Actions`
- `05_Nodes`
- `06_Components`
- `07_Widgets`
- `08_View`
- `09_Panels`

Additional discovered folder:
- `02_Properties` (in `Shared/_Editor/`)


---
- **[Back to rootserver.md](rootserver.md)**
- **[Back to Base index](rootserver-00-base-index.md)**

---
