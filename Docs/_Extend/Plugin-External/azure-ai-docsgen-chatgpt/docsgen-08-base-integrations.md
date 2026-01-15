# Base Integrations

---

## Overview

DocsGen integrates four major systems:

1. The host application (RootServer)
2. Azure AI Foundry agents (content generation)
3. Deterministic tools and validators (truth enforcement)
4. Artifact storage and manifests (audit and bundling)

This file describes the integration surfaces conceptually.

---

## Host Integration (RootServer)

DocsGen is designed to run as a plugin inside RootServer’s Blazor application model.

Host responsibilities include:
- providing UI shell and navigation
- providing configuration and secrets (Foundry credentials, storage connection)
- hosting the orchestrator API and event stream

DocsGen does not require a special hosting model beyond standard server-side Blazor + ASP.NET endpoints.

---

## Azure AI Foundry Agents (Intelligence Plane)

Agents are used only to generate Markdown content.

Key integration properties:
- agents are invoked per phase
- phase work is chunked to avoid timeouts
- agent outputs are treated as drafts until gates pass

DocsGen assumes:
- an agent can write content
- deterministic code decides whether the content is acceptable

---

## Tool API (Deterministic Surface for Agents)

DocsGen can expose a small OpenAPI tool surface so that agents can:
- read existing artifacts
- write file drafts under orchestrator control
- request deterministic validation execution (optional)

The orchestrator remains authoritative, even if tools are agent-invoked.

---

## Artifact Storage

DocsGen requires an artifact store implementation.

Common options:
- local disk (development)
- blob/object storage (production)

Artifact storage must support:
- content hashing
- immutability guarantees
- listing by run and phase
- bundle creation (zip)

---

## Manifest Storage

A manifest store records:
- runs
- phase executions
- artifact indexes
- validation issues

Manifests enable:
- diffable runs
- audit trails for approvals and overrides
- troubleshooting and reproducibility

---

## Security Model (Conceptual)

DocsGen assumes:
- the UI calls the orchestrator API as an authenticated user
- agents call tool APIs via a service identity (preferred) or restricted token

Key boundary:
- agents must not have the ability to overwrite approved core documentation artifacts
- the orchestrator must enforce this even if an agent attempts it

---

---

[← DocsGen](docsgen.md)
1. **[Base](docsgen-00-base-index.md)** – conceptual foundations, terminology, and canonical schemas
2. **[Architecture](docsgen-12-arch-index.md)** – orchestration, agents, validators, storage, and hosting boundaries
3. **[UI](docsgen-26-ui-index.md)** – user workflows, screens, components, and interaction rules
4. **[Appendix](docsgen-39-appendix-index.md)** – folder mapping, task references, and implementation checklist
5. **[Diagrams](docsgen-43-diagrams.md)** – architecture, state machines, and end-to-end sequences

---
