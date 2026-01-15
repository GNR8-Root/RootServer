# Base Concepts

A short glossary and the mental model used throughout the rest of the documentation.

---
## Core terms

See `02-terminology-index.json` for canonical definitions.

Key discovered terms:
- Host / Module / Plugin
- `Shared/_Sites`
- Layer folders (00..09)
- Prefix system (e.g., `F_`, `P_`, `A_`)
- Airtable Base → Table → Row → Field


## Key abstractions

- **UI hierarchy**: Pages/Layouts/Components/Sections/Nav under `Shared/_Sites/`.
- **Layer folders**: Micro-to-macro composition under `Shared/_Core/` and `Shared/_Editor/`.
- **Plugin-style integration**: Airtable integration code under `Shared/Plugins/Airtable/`.


## Mental model

- Treat `Shared/_Sites` as *where screens are defined*.
- Treat `Shared/_Core` as *canonical building blocks*.
- Treat `Shared/_Editor` as *authoring/editor experiences* layered on top.


---
- **[Back to rootserver.md](rootserver.md)**
- **[Back to Base index](rootserver-00-base-index.md)**

---
