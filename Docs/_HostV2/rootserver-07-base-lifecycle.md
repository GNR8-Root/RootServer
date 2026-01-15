# Base Lifecycle

What “lifecycle” means here: activation, state ownership, and teardown considerations.

---
## Activation

- Host activation begins at `Program.cs`.
- UI activation is driven by routing and the `Shared/_Sites` page hierarchy.


## Deactivation / unload

A formal plugin unload mechanism is **unknown** from this inventory pass.

Investigation steps:
- Search for custom plugin loader/discovery patterns under `Shared/Plugins/`.
- Search for events like `Dispose`, `IAsyncDisposable`, or host-managed scopes.


## State ownership

- Shared UI state typically lives in services registered in DI (Host-owned).
- Per-view state is expected inside components in `Shared/_Sites` and composed layer folders.


---
- **[Back to rootserver.md](rootserver.md)**
- **[Back to Base index](rootserver-00-base-index.md)**

---
