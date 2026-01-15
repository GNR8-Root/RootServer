# Diagrams

## System Architecture Diagram
```text
┌─────────────────────────────────────────────────────────────────┐
│                      RootServer Host                            │
│                                                                 │
│  ┌──────────────┐      ┌─────────────────┐      ┌────────────┐  │
│  │ Program.cs   │─────>│ Scoped Services │─────>│   _Core    │  │
│  │ Bootstrap &  │      │ Pointer, Editor │      │Foundation  │  │
│  │     DI       │      │   LogCatcher    │      │00-09 Layers│  │
│  └──────────────┘      └─────────────────┘      └──────┬─────┘  │
│                                                        │        │
└────────────────────────────────────────────────────────┼────────┘
                                                         │
                        ┌────────────────────────────────┼────────────────┐
                        │                                │                │
                        ▼                                ▼                ▼
         ┌──────────────────────┐          ┌──────────────────┐  ┌─────────────┐
         │   Airtable Plugin    │          │     _Editor      │  │   _Sites    │
         │  03,04,06,09 Layers  │          │  00-09 Layers    │  │ Section-    │
         └──────────┬───────────┘          └──────────────────┘  │   based     │
                    │                                            └─────────────┘
                    │
         ┌──────────┴─────────────┐
         │                        │
         ▼                        ▼
  ┌─────────────┐          ┌─────────────┐
  │ Airtable API│          │ JSON Cache  │
  │  (External) │          │  (Local)    │
  └─────────────┘          └─────────────┘
```

**Key Relationships:**
- Program.cs → Services → Core Foundation
- Core Foundation feeds into: Airtable Plugin, Editor, and Sites
- Airtable Plugin integrates with: Airtable API and JSON Cache

---

## Data Flow Diagram
```text
┌──────┐
│ User │
└───┬──┘
    │ 1. Click Sync
    ▼
┌────────┐
│ Editor │
└───┬────┘
    │ 2. Execute Sync
    ▼
┌────────────────┐
│ AirtableSync   │
│   Component    │
└───┬────────────┘
    │ 3. Fetch Schemas
    ▼
┌────────────────┐
│  Airtable API  │
└───┬────────────┘
    │ 4. Return Data
    ▼
┌────────────────┐
│ AirtableSync   │
└───┬────────────┘
    │ 5. Write JSON Files
    ▼
┌────────────────┐
│  JSON Cache    │
└───┬────────────┘
    │ 6. Read Cached Data
    ▼
┌────────────────┐
│  UI Components │
└───┬────────────┘
    │ 7. Render Components
    ▼
┌──────┐
│ User │
└──────┘
```

**Flow Summary:**
1. User triggers sync in Editor
2. A_AirtableSync component executes
3. Fetches data from Airtable API
4. Writes to local JSON cache
5. UI components read from cache
6. Rendered UI displayed to user

---

## UI Layer Hierarchy
```text
                        ┌──────────────────────┐
                        │    09_Panels         │
                        │  (Editor Panels)     │
                        └──────────┬───────────┘
                                   │
                   ┌───────────────┴───────────────┐
                   │                               │
                   ▼                               ▼
          ┌────────────────┐            ┌──────────────────┐
          │   08_View      │            │   07_Widgets     │
          │ (View Layouts) │            │ (Containers)     │
          └────────┬───────┘            └────────┬─────────┘
                   │                             │
                   └──────────┬──────────────────┘
                              │
                              ▼
                   ┌────────────────────┐
                   │   06_Components    │
                   │ (Composed Layouts) │
                   └──────────┬─────────┘
                              │
        ┌─────────────────────┼─────────────────────┐
        │         │           │           │         │
        ▼         ▼           ▼           ▼         ▼
    ┌────────┐ ┌───────┐  ┌───────┐  ┌───────┐  ┌───────┐
    │05_Nodes│ │04_Act.│  │03_Ptr.│  │02_Fld.│  │01_Dis.│
    │(Node   │ │(User  │  │(Selec.│  │(Form  │  │(Read- │
    │Graphs) │ │Action)│  │)      │  │Input) │  │only)  │
    └───┬────┘ └───┬───┘  └───┬───┘  └───┬───┘  └───┬───┘
        │          │          │          │          │
        └──────────┴──────────┴──────────┴──────────┘
                              │
                              ▼
                   ┌────────────────────┐
                   │     00_Core        │
                   │ Services & Base    │
                   │      Classes       │
                   └────────────────────┘
```

**Layer Progression (Micro → Macro):**
- **00_Core** - Foundation (services, base classes, events)
- **01-04** - Atomic elements (displays, fields, pointers, actions)
- **05-06** - Composition (nodes, components)
- **07-09** - Containers (widgets, views, panels)

---

## Deployment Context
```text
┌──────────────────┐                    ┌──────────────────┐
│   Developer      │                    │    CI/CD         │
│    Machine       │                    │    Pipeline      │
└────────┬─────────┘                    └────────┬─────────┘
         │                                       │
         │ dotnet run                            │ publish
         │                                       │
         ▼                                       ▼
┌──────────────────┐                    ┌──────────────────┐
│  Local Blazor    │                    │  Azure App       │
│     Server       │                    │    Service       │
└────────┬─────────┘                    └────────┬─────────┘
         │                                       │
         │                                       ├─────────────┐
         ▼                                       │             │
┌──────────────────┐                             │             │
│  Local JSON      │                             ▼             ▼
│     Cache        │                    ┌──────────┐  ┌──────────────┐
└──────────────────┘                    │Azure Blob│  │ Application  │
                                        │ Storage  │  │   Insights   │
         │                              └──────────┘  └──────────────┘
         │                                       │
         │                                       │
         └───────────────────┬───────────────────┘
                             │
                             ▼
                    ┌──────────────────┐
                    │  Airtable API    │
                    └──────────────────┘
```

**Deployment Paths:**
- **Local Development:** Developer machine → Local Blazor Server → Local JSON Cache
- **Production:** CI/CD Pipeline → Azure App Service → Azure Blob Storage
- **Data Source:** Both environments connect to Airtable API

---

[← Back to RootServer](rootserver.md)

1. **[Base](rootserver-00-base-index.md)** – conceptual foundations
2. **[Architecture](rootserver-12-arch-index.md)** – system design
3. **[UI](rootserver-26-ui-index.md)** – UI layers and patterns
4. **[Appendix](rootserver-39-appendix-index.md)** – risks and mappings
5. **Diagrams** – visual architecture

---