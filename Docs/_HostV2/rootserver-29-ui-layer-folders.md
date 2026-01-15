# UI Layer Folders

What the 00..09 folders mean in practice, and what deviations were discovered.

---
## 00..09 layer roles

Discovered layers (shared convention in `Shared/_Core` and `Shared/_Editor`):
- `00_Core` — base types/utilities
- `01_Displays` — output-only view pieces
- `02_Fields` — interactive input components
- `03_Pointers` — navigation/selection helpers
- `04_Actions` — control logic / triggers
- `05_Nodes` — node/graph-related units
- `06_Components` — composed building blocks
- `07_Widgets` — higher-level containers
- `08_View` — view layouts
- `09_Panels` — top-level UI shells


## Discovered deviations

- `Shared/_Editor/02_Properties` exists, in addition to `02_Fields`.

Evidence:
- `Shared/_Editor/02_Properties/`


## Practical mapping

- Prefer placing reusable UI primitives in `Shared/_Core`.
- Place editor-only or authoring-oriented UI in `Shared/_Editor`.
- When adding a new layer, update this docset and `01-inventory-index.json` to keep discovery and docs aligned.


---
- **[Back to rootserver.md](rootserver.md)**
- **[Back to UI index](rootserver-26-ui-index.md)**

---
