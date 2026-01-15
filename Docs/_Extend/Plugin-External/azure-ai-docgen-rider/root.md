 # Azure AI DocGen - Internal Manual
 
 This manual documents the 4-plane architecture and .NET solution for phased documentation generation using Azure AI Foundry agents with deterministic validators.

Contents
---

- [root](root.md)
- [foundation](00-foundation-index.md)
- [architecture](10-architecture-index.md)
- [operations](20-operations-index.md)
- [appendix](39-appendix-index.md)

---
 
##  Principles
 - Source-of-truth precedence: requirements JSON > host architecture > reference docset > prose
 - Deterministic code decides truth; LLMs generate content only
 - Immutability: no silent regeneration; explicit runs, phases, artifacts
 - Small, composable phases; regenerate only affected files
 
---

##  Inputs/Artifacts
 - Host bundle: rootServer.zip
 - Reference docset example: MODULE-node-editor.zip
 
---

##  Quick Start
 1) Implement control plane spine: Preflight -> Phase 1 (foundation)
 2) Register planned files; enforce link/placeholder rules
 3) Run Foundry agent per file; store artifacts immutably
 4) Validate gates; require approval in interactive mode
 5) Iterate phases until final bundle