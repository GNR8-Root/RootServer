# Module and Plugin System — RootServer Host

Design of Modules and Plugins within the Host, including lifecycle and discovery.

---

## Modules
- Always-on components that the Host depends on
- Provide services (data access, domain operations, utilities)
- Registered in DI at startup; exposed to Host and Plugins

---

## Plugins
- Optional extensions that reference Host and Modules
- Discovery & activation handled by Host (implementation-specific)
- Host avoids compile-time dependencies on plugin assemblies

---

## Lifecycle
- Activation: plugins discovered (by configuration, scanning, or registry) → validated against Host contracts → activated
- Unloading: plugins deactivated gracefully; resources disposed

---

## Contracts & Versioning
- Contracts defined at Host boundary; semantic versioning recommended
- Backwards-compatibility considered for non-breaking updates

---

**Back navigation:** **[Architecture Index](./docsgen-12-arch-index.md)** · **[Root Index](./RootServer.md)**

---
