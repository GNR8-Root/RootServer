# Examples & Usage — RootServer Host

Working conventions and small examples to illustrate Host coordination patterns. Replace with project-specific snippets as the Architecture phase surfaces them.

---

## DI Composition (Illustrative)
// Program.cs (illustrative pattern) // builder.Services.AddSingleton<IModuleX, ModuleX>(); // builder.Services.AddScoped<IRequestHandler, RequestHandler>();

- Register host-level services in `Program.cs` or composition roots
- Keep plugin registrations in plugin assemblies; Host should not depend on plugin types

---

## UI Routing (Illustrative)
// App.razor (illustrative) // <Router AppAssembly="typeof(Program).Assembly"> //   <Found Context="routeData"> //     <RouteView RouteData="routeData" DefaultLayout="typeof(MainLayout)" /> //   </Found> // </Router>

- Views and Panels are defined under `Shared/_Sites`; compose Widgets/Components as needed

---

## Configuration
- Prefer environment-specific overrides via `appsettings.Development.json` etc.
- Do not commit secrets; use Secret Manager or environment variables

---

**Back navigation:** **[Base Index](./docsgen-00-base-index.md)** · **[Architecture Index](./docsgen-12-arch-index.md)**

---
