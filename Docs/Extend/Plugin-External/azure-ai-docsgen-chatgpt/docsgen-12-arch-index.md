# Architecture Layer

This section defines **how DocsGen is implemented and hosted**.
It describes the orchestrator, state machine, agent integration, deterministic validators,
artifact storage, and the boundary rules that prevent drift and silent regeneration.

---

- **[Architecture Overview](docsgen-13-arch.md)**  
  System decomposition into planes and the high-level responsibilities of each.

- **[Architecture – Blazor UI](docsgen-14-arch-blazor.md)**  
  Experience plane implementation: pages, components, and UI-to-API contracts.

- **[Architecture – Data & Storage](docsgen-15-arch-data.md)**  
  Artifact store, manifests, hashing, immutability enforcement, and bundle creation.

- **[Architecture – JSON Contracts](docsgen-16-arch-json.md)**  
  Input and output JSON shapes, schema enforcement, and source-of-truth precedence.

- **[Architecture – JavaScript](docsgen-17-arch-js.md)**  
  Optional JS interop and how to keep the system functional without it.

- **[Architecture – Visual System](docsgen-18-arch-visual.md)**  
  How progress, issues, and artifacts are visualized (timeline, reports, browsing).

- **[Architecture – Updates & Events](docsgen-19-arch-updates.md)**  
  Run event streaming, real-time progress updates, and UI synchronization.

- **[Architecture – Macro Execution](docsgen-20-arch-macro.md)**  
  Chunking strategy, partial regeneration, and file-by-file generation loops.

- **[Architecture – Validation](docsgen-21-arch-validation.md)**  
  Deterministic validators, gate composition, and structured issue output.

- **[Architecture – Performance](docsgen-22-arch-performance.md)**  
  Timeouts, throttling, caching, concurrency, and run budgeting.

- **[Architecture – Testing](docsgen-23-arch-testing.md)**  
  Unit tests, integration tests, golden docsets, and regression strategy.

- **[Architecture – Deployment](docsgen-24-arch-deployment.md)**  
  Hosting inside RootServer, configuration, secrets, and operational controls.

- **[Architecture – Resources](docsgen-25-arch-resources.md)**  
  Reference tables: endpoints, configuration keys, rule IDs, and event types.

---

[← DocsGen](docsgen.md)
1. **[Base](docsgen-00-base-index.md)** – conceptual foundations, terminology, and canonical schemas
2. **Architecture** – orchestration, agents, validators, storage, and hosting boundaries
3. **[UI](docsgen-26-ui-index.md)** – user workflows, screens, components, and interaction rules
4. **[Appendix](docsgen-39-appendix-index.md)** – folder mapping, task references, and implementation checklist
5. **[Diagrams](docsgen-43-diagrams.md)** – architecture, state machines, and end-to-end sequences

---
