# UI Framework

How Blazor and the project’s UI hierarchy cooperate at runtime.

---
## UI framework integration

The host uses Blazor (`App.razor` discovered) and a custom UI composition hierarchy under `Shared/_Sites/`.

Evidence:
- `App.razor`
- `Shared/_Sites/`


## Rendering lifecycle

- Render triggered by Blazor component lifecycle.
- State changes flow through component parameters and DI services.


## State model

State ownership is split between:
- Host/DI services (shared state)
- Components under `Shared/_Sites` and layer folders (local state)


---
- **[Back to rootserver.md](rootserver.md)**
- **[Back to Architecture index](rootserver-12-arch-index.md)**

---
