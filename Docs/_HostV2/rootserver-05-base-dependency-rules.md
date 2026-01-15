# Base Dependency Rules

How references should flow and what rules keep the architecture maintainable.

---
## Dependency graph summary

- Runtime composition begins in `Program.cs`.
- UI composition follows `Shared/_Sites` and the 00..09 layer folders.
- Plugins/integrations are organized under `Shared/Plugins/`.


## Reference rules

- Prefer dependencies that point inward (UI Pages → Layouts/Components → Core layers).
- Keep host surfaces stable; avoid host knowing about optional plugin specifics.


## Planned/future rules

- Plugin ↔ Plugin collaboration is described as a planned capability (node system). Current implementation status must be confirmed by discovery in `Shared/_Core/05_Nodes` and `Shared/_Editor/05_Nodes`.


---
- **[Back to rootserver.md](rootserver.md)**
- **[Back to Base index](rootserver-00-base-index.md)**

---
