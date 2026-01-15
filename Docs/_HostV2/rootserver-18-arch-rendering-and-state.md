# Rendering and State

How rendering is triggered and how state should be structured for predictable UI updates.

---
## State containers

- Blazor component state in `Shared/_Sites` and layer folders.
- Shared state expected via DI services (see `Program.cs`).


## Re-render triggers

- Parameter changes
- State changes in DI services
- Async completion events


## Async patterns

Async usage must be reviewed by scanning for `async`/`await` in UI and integration code.

Investigation steps:
- Search `Shared/_Sites` and `Shared/Plugins/Airtable` for async flows that can re-enter rendering.


---
- **[Back to rootserver.md](rootserver.md)**
- **[Back to Architecture index](rootserver-12-arch-index.md)**

---
