# Deployment & Hosting

---

## Hosting Model

RootServer is a server-side Blazor application with dependency injection and static file hosting.

DocsGen can be hosted in two common ways:

1. **In-Process Plugin**
   - DocsGen UI + orchestrator endpoints live inside the RootServer project
   - simplest for local development

2. **Separated Services**
   - DocsGen UI in RootServer
   - orchestrator API hosted as a sibling ASP.NET service
   - better for scaling and isolating credentials

Both models preserve the same plane boundaries.

---

## Configuration Inputs

DocsGen requires configuration for:

- Foundry agent access (project/endpoint/credentials)
- artifact storage (local path or blob)
- manifest storage (database or file-based store)
- validation profile defaults (strictness, thresholds)

Configuration should be injected via standard RootServer configuration providers.

---

## Secrets Handling

Credentials should never be embedded in documentation files or checked into source control.

Typical secrets:
- Foundry credentials
- storage connection strings
- any tool API authentication material

---

## Operational Controls

Recommended operational controls:

- max concurrent runs
- max upload sizes
- max artifact size per file
- per-run cancellation
- deterministic validator timeouts

---

## Security Boundaries

Key security rules:

- UI actions require authenticated user context
- approval actions must be audited (who + when)
- agent tool calls must be authenticated as a service identity
- agents must not have direct access to overwrite approved artifacts

---

## Deployment Outputs

In strict mode, the final output of a successful run includes:

- a final validation report (generation artifact)
- a documentation bundle zip containing 43 core Markdown files

---

---

[← DocsGen](docsgen.md)
1. **[Base](docsgen-00-base-index.md)** – conceptual foundations, terminology, and canonical schemas
2. **[Architecture](docsgen-12-arch-index.md)** – orchestration, agents, validators, storage, and hosting boundaries
3. **[UI](docsgen-26-ui-index.md)** – user workflows, screens, components, and interaction rules
4. **[Appendix](docsgen-39-appendix-index.md)** – folder mapping, task references, and implementation checklist
5. **[Diagrams](docsgen-43-diagrams.md)** – architecture, state machines, and end-to-end sequences

---
