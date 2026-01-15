# System Architecture

---

## Overview

RootServer implements a three-tier architecture:

1. **Presentation Layer** - Blazor Server components (schema-driven UI)
2. **Service Layer** - Scoped services for state management
3. **Data Layer** - Airtable API + JSON cache

---

## Boundary Diagram

```mermaid
graph TB
    subgraph Host[RootServer Host]
        Program[Program.cs<br/>Bootstrap & DI]
        Services[Scoped Services<br/>Pointer, Editor, LogCatcher]
        Core[_Core Foundation<br/>00-09 Layers]
    end
    
    subgraph Plugins[Plugins]
        Airtable[Airtable Plugin<br/>03,04,06,09 Layers]
    end
    
    subgraph Editor[Editor Environment]
        EditorUI[_Editor<br/>00-09 Layers]
    end
    
    subgraph Site[Public Site]
        SiteUI[_Sites<br/>Section-based]
    end
    
    subgraph External[External Systems]
        AirtableAPI[Airtable API]
        JSON[JSON Cache]
    end
    
    Program --> Services
    Services --> Core
    Core --> Airtable
    Core --> EditorUI
    Core --> SiteUI
    Airtable --> AirtableAPI
    Airtable --> JSON
    
    style Host fill:#e1f5ff
    style Plugins fill:#fff3e1
    style External fill:#f0f0f0
```

---

## Key Architectural Decisions

### Schema-Driven Rendering
UI generated from JSON metadata rather than hardcoded layouts. Enables rapid iteration and data-driven customization.

### Service-Based State
State managed through scoped services (Pointer_Service, EditorView_Service) rather than component parameters. Provides centralized control and loose coupling.

### Layer-Based Composition
00-09 folder system enforces micro-to-macro architecture. Lower layers provide primitives; higher layers compose them.

### Plugin Isolation
Plugins implement layer subsets without coupling to host. Host provides extension points but doesn't depend on plugin internals.

---

[← Back to Architecture Index](rootserver-12-arch-index.md)

---
