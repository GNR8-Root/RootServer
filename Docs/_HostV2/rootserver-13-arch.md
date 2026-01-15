# Architecture Overview

A boundary-first view of the system, grounded in discovered folders and entry points.

---
## System architecture

The host is organized around a Blazor UI hierarchy (`Shared/_Sites`) and layered building blocks (`Shared/_Core`, `Shared/_Editor`). Integrations live under `Shared/Plugins/` (e.g., Airtable).

Evidence:
- `Program.cs`
- `Shared/_Sites/`
- `Shared/_Core/`
- `Shared/_Editor/`
- `Shared/Plugins/Airtable/`


## Boundaries

- Host owns boot + DI (`Program.cs`).
- UI hierarchy composes layer folders.
- Integrations are treated as plugin-style packages but live in-repo.


## Key flows

```mermaid
flowchart LR
  subgraph Host[RootServer Host]
    Boot[Program.cs / DI]
    UI[Shared/_Sites UI hierarchy]
    Core[Shared/_Core (00..09)]
    Editor[Shared/_Editor (00..09 + 02_Properties)]
  end

  subgraph Plugins[Plugin-style Integrations]
    Airtable[Shared/Plugins/Airtable]
  end

  Boot --> UI
  UI --> Core
  UI --> Editor
  Boot --> Airtable
  Airtable --> Core
```

---
- **[Back to rootserver.md](rootserver.md)**
- **[Back to Architecture index](rootserver-12-arch-index.md)**

---
