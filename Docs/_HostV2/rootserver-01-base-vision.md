# Base Vision

Why this codebase exists, who it is for, and what it explicitly does not try to do.

---
## Purpose

`RootServer` is a Blazor-based host application intended to serve as a schema-driven UI framework with an Airtable-backed data model and a host↔module↔plugin architecture.

Evidence:
- `README.md`
- `Shared/Plugins/`


## Audience

- New contributors onboarding into the host architecture
- Internal maintainers extending UI layers and plugins
- Reviewers evaluating boundaries and quality signals


## Non-goals

- This docset does not reverse-engineer every feature implementation.
- It avoids reproducing secret values (API keys/tokens), even if present in configuration.


## High-level map

- Host boot + DI: `Program.cs`
- UI hierarchy: `Shared/_Sites/`
- Layered UI building blocks: `Shared/_Core/00_Core..09_Panels` and `Shared/_Editor/00_Core..09_Panels`
- Integrations/plugins: `Shared/Plugins/`


---
- **[Back to rootserver.md](rootserver.md)**
- **[Back to Base index](rootserver-00-base-index.md)**

---
