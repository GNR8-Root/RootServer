# Glossary

---

## Terms

### Airtable
Cloud-based relational database with spreadsheet interface. External schema store for RootServer.

### Blazor Server
Microsoft's server-side web framework. Renders UI on server, communicates via SignalR.

### Component
Reusable UI element. Implemented as `.razor` file with optional `.razor.cs` code-behind.

### DI (Dependency Injection)
Design pattern where dependencies are provided (injected) rather than created by the component.

### Host
Main application that coordinates modules, plugins, and layers (RootServer itself).

### JSON Cache
Local storage of Airtable data in `Json/` folder. Enables offline capability.

### Module
Shared service library (planned feature, not yet implemented).

### Numbered Hierarchy
Folder structure `00_Core` through `09_Panels` organizing components by complexity.

### Plugin
Self-contained feature extension (e.g., Airtable plugin).

### Pointer
UI interaction trigger component (buttons, selectors, tabs).

### Schema-Driven UI
UI structure defined in metadata (Airtable) rather than code.

### Scoped Service
Service instance created per user session in Blazor Server.

### SignalR
Real-time communication library using WebSockets.

### Wrapper + Base
Pattern splitting components into layout (wrapper) and logic (base) files.

---

## Acronyms

- **ADR**: Architecture Decision Record
- **API**: Application Programming Interface
- **CI/CD**: Continuous Integration / Continuous Deployment
- **DI**: Dependency Injection
- **DRY**: Don't Repeat Yourself
- **E2E**: End-to-End
- **JSON**: JavaScript Object Notation
- **POCO**: Plain Old CLR Object
- **PR**: Pull Request
- **REST**: Representational State Transfer
- **SDK**: Software Development Kit
- **UI**: User Interface
- **YAGNI**: You Aren't Gonna Need It

---

## Component Prefixes

- `D_`: Display (read-only output)
- `F_`: Field (input component)
- `P_`: Pointer (interaction trigger)
- `A_`: Action (operation)
- `N_`: Node (graph node)
- `C_`: Component (composed layout)
- `W_`: Widget (container layout)
- `V_`: View (view definition)
- `PNL_`: Panel (high-level grouping)

---

---

**Navigation**

- **[← ADRs](rootserver-56-appendix-adrs.md)**
- **[Home](rootserver.md)**

---
