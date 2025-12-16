# DI Contracts — RootServer Host

Dependency Injection contracts at the Host boundary and across Modules/Plugins.

---

## Registration Patterns
- Singleton: shared stateless services (e.g., configuration readers, caches)
- Scoped: per-request/services with contextual state
- Transient: lightweight, stateless objects

---

## Composition Root (Illustrative)
// Program.cs (illustrative) // builder.Services.AddSingleton<IClock, SystemClock>(); // builder.Services.AddScoped<IUserContext, UserContext>(); // builder.Services.AddTransient<IValidator<T>, Validator<T>>();

---

## Contracts at Boundaries
- Host exposes interfaces consumed by Modules and Plugins
- Plugins implement optional extension interfaces
- Avoid Host depending on plugin implementations

---

## Configuration Binding
- Options pattern for `appsettings*.json` sections
- Environment-specific settings via `IOptionsSnapshot` when applicable

---

**Back navigation:** **[Architecture Index](./docsgen-12-arch-index.md)** · **[Base Index](./docsgen-00-base-index.md)**

---
