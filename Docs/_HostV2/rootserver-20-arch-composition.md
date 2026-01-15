# Composition

How the host composes UI and integrations, and where extension points live.

---
## Composition model

Composition occurs at three levels:
- `Shared/_Sites` (Pages/Layouts)
- Layer folders (Components/Wigdets/Views/Panels)
- Plugin-style integrations (`Shared/Plugins`)


## Module/plugin wiring

Plugin-style wiring is visible via folder structure, but explicit discovery/lifecycle code must be located and documented.

Evidence:
- `Shared/Plugins/`


## Extension points

- Add new UI building blocks under `Shared/_Core` and `Shared/_Editor`.
- Keep extensions within layer folder roles.

### Boundary reminder

Avoid Host → Plugin compile-time dependencies.


---
- **[Back to rootserver.md](rootserver.md)**
- **[Back to Architecture index](rootserver-12-arch-index.md)**

---
