# Diagrams

---

## System Architecture Diagram

```text
┌─────────────────────────────────────────────────────────┐
│                    RootServer Host                       │
│                                                          │
│  ┌────────────┐  ┌────────────┐  ┌──────────────────┐  │
│  │   _Core    │  │  _Editor   │  │     _Sites       │  │
│  │            │  │            │  │                  │  │
│  │  Base      │  │  Dev       │  │  Public UI       │  │
│  │  Components│  │  Tools     │  │  Sections        │  │
│  └────────────┘  └────────────┘  └──────────────────┘  │
│                                                          │
│  ┌──────────────────────────────────────────────────┐   │
│  │        Plugins/Airtable                          │   │
│  │  00-09 Hierarchy (Displays, Fields, Actions...)  │   │
│  └──────────────────────────────────────────────────┘   │
│                                                          │
│  ┌──────────────────────────────────────────────────┐   │
│  │        Services (DI Container)                   │   │
│  │  Pointer_Service, LogCatcher_Service, etc.       │   │
│  └──────────────────────────────────────────────────┘   │
└─────────────────────────────────────────────────────────┘
          │                               │
          ↓                               ↓
   Blazor Server Runtime            Airtable API
   SignalR WebSocket                 JSON Cache
```

---

## Component Hierarchy Diagram

```text
09_Panels (PNL_)
    └── 08_View (V_)
        └── 07_Widgets (W_)
            └── 06_Components (C_)
                ├── 04_Actions (A_)
                ├── 03_Pointers (P_)
                ├── 02_Fields (F_)
                └── 01_Displays (D_)
                    └── 00_Core (Base Classes)
```

---

## Data Flow Diagram

```text
Airtable API
    │
    ↓ (HTTP Request)
JSON Response
    │
    ↓ (Serialize)
Json/tables.json
    │
    ↓ (Load at Startup)
AirtableConfig
    │
    ↓ (Initialize)
Services
    │
    ├──→ Pointer_Service
    ├──→ LogCatcher_Service
    └──→ EditorView_Service
    │
    ↓ (Inject)
Components
    │
    ↓ (Render)
User Interface
```

---

## Event Flow Diagram

```text
User Action (Click)
    │
    ↓
P_Table Component
    │
    ↓ (Call Method)
Pointer_Service.SelectTable()
    │
    ↓ (Raise Event)
OnTableChanged Event
    │
    ├──→ W_Tables (Update List)
    ├──→ PNL_Structure (Update Panel)
    └──→ C_Rows (Load Rows)
    │
    ↓ (StateHasChanged)
Blazor Re-render
```

---

## Deployment Diagram

```text
┌──────────────────────────────────────┐
│      Production Environment          │
│                                      │
│  ┌────────────────────────────────┐  │
│  │  Azure App Service             │  │
│  │  - Blazor Server Runtime       │  │
│  │  - SignalR WebSocket           │  │
│  └────────────────────────────────┘  │
│              │                       │
│              ↓                       │
│  ┌────────────────────────────────┐  │
│  │  Azure Key Vault               │  │
│  │  - Airtable API Key            │  │
│  │  - Connection Strings          │  │
│  └────────────────────────────────┘  │
│              │                       │
│              ↓                       │
│  ┌────────────────────────────────┐  │
│  │  Application Insights          │  │
│  │  - Telemetry                   │  │
│  │  - Performance Monitoring      │  │
│  └────────────────────────────────┘  │
└──────────────────────────────────────┘
              │
              ↓ (HTTPS)
    Airtable Cloud API
```

---

## Sequence Diagram: Table Selection

```text
User        P_Table     Pointer_Service    W_Tables    C_Rows
 │             │              │               │          │
 │──Click──→   │              │               │          │
 │             │──SelectTable()──→           │          │
 │             │              │               │          │
 │             │          ┌───┴─Raise Event──┐          │
 │             │          │   OnTableChanged │          │
 │             │          └───┬──────────────┘          │
 │             │              │               │          │
 │             │              ├───Subscribe──→│          │
 │             │              │               │──Update  │
 │             │              │               │          │
 │             │              ├───Subscribe──────────→   │
 │             │              │               │      LoadRows()
 │             │              │               │          │
 │             │          StateHasChanged() ←────────────┘
 │             │              │               │          │
 │←────────────────────────Re-render UI──────────────────┘
```

---

## Plugin Architecture Diagram

```text
┌─────────────────────────────────────────┐
│           RootServer Host               │
│                                         │
│  ┌───────────────────────────────────┐  │
│  │     Plugin Interface              │  │
│  │  - IPlugin.Configure()            │  │
│  │  - IPlugin.Initialize()           │  │
│  └───────────────────────────────────┘  │
│              │                          │
│              ↓                          │
│  ┌───────────────────────────────────┐  │
│  │   Airtable Plugin                 │  │
│  │  00_Core  → System Classes        │  │
│  │  01-04    → UI Components         │  │
│  │  05-09    → Composed Layers       │  │
│  └───────────────────────────────────┘  │
│              │                          │
│              ↓                          │
│  ┌───────────────────────────────────┐  │
│  │   Future Plugins (Planned)        │  │
│  │  - CosmosDB Plugin                │  │
│  │  - Azure Admin Plugin             │  │
│  │  - AI Foundry Plugin              │  │
│  └───────────────────────────────────┘  │
└─────────────────────────────────────────┘
```

---

## State Management Diagram

```text
┌──────────────────────────────────────────────┐
│            Application State                 │
│                                              │
│  ┌────────────────────────────────────────┐  │
│  │  Scoped Services (Per User Session)   │  │
│  │                                        │  │
│  │  Pointer_Service                       │  │
│  │  ├─ CurrentTable: string               │  │
│  │  ├─ CurrentRow: string                 │  │
│  │  └─ Events: OnTableChanged, etc.       │  │
│  │                                        │  │
│  │  EditorView_Service                    │  │
│  │  ├─ ActiveView: string                 │  │
│  │  └─ Events: OnViewChanged              │  │
│  └────────────────────────────────────────┘  │
│              ↕ (Inject/Subscribe)            │
│  ┌────────────────────────────────────────┐  │
│  │        Blazor Components               │  │
│  │  - Subscribe to service events         │  │
│  │  - Update local state                  │  │
│  │  - Call StateHasChanged()              │  │
│  └────────────────────────────────────────┘  │
└──────────────────────────────────────────────┘
```

---

_Total Diagrams: 8_

---

---

**Navigation**

- **[← PR Review Checklist](rootserver-42-appendix-pr-review-checklist.md)**
- **[Improvements Roadmap →](rootserver-44-appendix-improvements.md)**
- **[Home](rootserver.md)**

---
