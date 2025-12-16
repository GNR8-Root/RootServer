 # .NET Solution Layout

---

##  Recommended projects
 - DocsGen.Web (Blazor UI)
 - DocsGen.Api (ASP.NET Core: orchestration + tool endpoints)
 - DocsGen.Orchestration (phase state machine, policies, run engine)
 - DocsGen.Foundry (Azure AI Foundry SDK adapter, agent runner)
 - DocsGen.Validation (validators: links/placeholders/terminology/schema)
 - DocsGen.Artifacts (artifact store abstraction + implementations)
 - DocsGen.Contracts (DTOs shared between UI and API)
 
---

##  Directory example
 ```text
 /src
   DocsGen.Web/
   DocsGen.Api/
   DocsGen.Orchestration/
   DocsGen.Foundry/
   DocsGen.Validation/
   DocsGen.Artifacts/
   DocsGen.Contracts/
 ```
---

##  Why this works
 - Orchestration flow in DocsGen.Orchestration
 - Agent definitions and prompt templates in DocsGen.Foundry
 - Gates implemented in DocsGen.Validation and executed by orchestrator
 - Artifacts stored via DocsGen.Artifacts with immutability
 
---

 **Related**
 - [06-orchestration-engine.md](06-orchestration-engine.md)
 - [07-foundry-agents.md](07-foundry-agents.md)

---

**Back to index:**
- [root](root.md)
- [foundation](00-foundation-index.md)
- [architecture](10-architecture-index.md)
- [operations](20-operations-index.md)
- [appendix](39-appendix-index.md)

---