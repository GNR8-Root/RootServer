# Diagrams

A consolidated set of diagrams for quick orientation and review.

---
## Diagram index

- System boundaries (flowchart)
- Primary runtime flow (sequence)
- UI hierarchy (flowchart)


## System boundaries

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

## Runtime sequences

```mermaid
sequenceDiagram
  participant U as User
  participant UI as Shared/_Sites UI
  participant S as DI Services
  participant A as Airtable Integration

  U->>UI: Navigate / interact
  UI->>S: Request data / state
  S->>A: Fetch schema/data (if needed)
  A-->>S: Rows/Fields (model)
  S-->>UI: ViewModel / state update
  UI-->>U: Render updated UI
```

## UI hierarchy (if present)

```mermaid
flowchart TB
  Sites[Shared/_Sites]
  Pages[Pages]
  Layouts[Layouts]
  Components[Components]
  Sections[Sections]
  Nav[Nav]

  Sites --> Pages
  Sites --> Layouts
  Sites --> Components
  Sites --> Sections
  Sites --> Nav

  Pages --> UseCore[Uses Shared/_Core layers]
  Pages --> UseEditor[Uses Shared/_Editor layers]
```

---
- **[Back to rootserver.md](rootserver.md)**
- **[Back to Architecture index](rootserver-12-arch-index.md)**

---
