# System Architecture

---

## Overview

RootServer implements a three-tier architecture:

1. **Presentation Layer** - Blazor Server components (schema-driven UI)
2. **Service Layer** - Scoped services for state management
3. **Data Layer** - Airtable API + JSON cache

---

## Boundary Diagram

```text
                         +--------------------------------------+
                         |        RootServer Host (Host)        |
                         |--------------------------------------|
                         |  +-------------------------------+   |
                         |  | Program.cs                    |   |
                         |  | Bootstrap & DI                |   |
                         |  +-------------------------------+   |
                         |                |                     |
                         |                v                     |
                         |  +-------------------------------+   |
                         |  | Scoped Services               |   |
                         |  | Pointer, Editor, LogCatcher   |   |
                         |  +-------------------------------+   |
                         |                |                     |
                         |                v                     |
                         |  +-------------------------------+   |
                         |  | _Core Foundation              |   |
                         |  | 00-09 Layers                  |   |
                         |  +-------------------------------+   |
                         +----------------+---+------------------+
                                          |   |
              ----------------------------+   +---------------------------- 
              |                               |                            |
              v                               v                            v
+-------------------------------+   +-------------------------------+   +----------------------+
|            Plugins            |   |       Editor Environment      |   |      Public Site     |
|-------------------------------|   |-------------------------------|   |----------------------|
| +---------------------------+ |   | +---------------------------+ |   | +------------------+ |
| | Airtable Plugin           | |   | | _Editor                   | |   | | _Sites           | |
| | 03,04,06,09 Layers        | |   | | 00-09 Layers              | |   | | Section-based    | |
| +---------------------------+ |   | +---------------------------+ |   | +------------------+ |
+---------------+---------------+   +-------------------------------+   +----------------------+
|
v
+-----------------------------+
|       External Systems      |
|-----------------------------|
| +-------------------------+ |
| | Airtable API            | |
| +-------------------------+ |
| +-------------------------+ |
| | JSON Cache              | |
| +-------------------------+ |
+-----------------------------+


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
