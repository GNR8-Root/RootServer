 # Appendix A4 — Security and Identity
 
 Purpose
 - Define identity and authorization between the UI, Orchestrator API, Foundry agents, and Tool API.
 - Provide practical setups for local development and cloud deployment.
 
 Threat model highlights
 - Only the Orchestrator decides truth (phase/state/gates). Agents generate content only.
 - Tool API performs deterministic operations; protect it with managed identity or trusted tokens.
 - Artifacts are immutable after phase completion; prevent overwrite attacks.
 
 Identity models
 - Local development
   - UI → API: developer login (cookie/JWT) with role `DocGen.Runner`.
   - Agent → Tool API: local token (static dev secret) with limited scope.
 - Cloud
   - UI → API: App Service Auth / Entra ID; roles `DocGen.Runner`, `DocGen.Approver`, `DocGen.Admin`.
   - Foundry → Tool API: Managed Identity (MI) on the Foundry resource calling Tool API with audience validation.
 
 Authorization rules (minimum)
 - Orchestrator endpoints
   - POST /api/runs — Runner
   - POST /api/runs/{id}/approve — Approver
   - GET /api/runs/{id} — Runner or Approver
   - GET /api/runs/{id}/download — Runner or Approver
 - Tool API operations
   - ReadArtifact* — Generator, Reporter, Orchestrator
   - WriteArtifact* — Generator/Reporter when phase open; Orchestrator always
   - Validate* — Orchestrator
 
 Storage permissions
 - Blob Container: container-level role `Storage Blob Data Contributor` for the API; read-only for validation jobs if separated.
 - Manifest DB: app role restricted to partition by Tenant/Project/Run.
 
 Audit & compliance
 - Log every artifact write: who/what/when/hash.
 - Retain validation reports and approvals.
 - Emit structured events (RunStarted, PhaseCompleted, GateFailed, Approved).
 
 Secrets management
 - Local: user secrets or .env (development only).
 - Cloud: Key Vault; rotate regularly; prefer MI over client secrets.
 
 Example: ASP.NET authentication (sketch)
 ```csharp
 services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
   .AddJwtBearer("aad", o =>
   {
       o.Authority = builder.Configuration["Auth:AAD:Authority"];
       o.Audience = builder.Configuration["Auth:AAD:Audience"];
   });
 services.AddAuthorization(o =>
 {
   o.AddPolicy("Runner", p => p.RequireRole("DocGen.Runner"));
   o.AddPolicy("Approver", p => p.RequireRole("DocGen.Approver"));
 });
 ```
 
 Related
 - [11-artifacts-and-manifest.md](11-artifacts-and-manifest.md)
 - [06-orchestration-engine.md](06-orchestration-engine.md)
 - [08-tool-surface-openapi.md](08-tool-surface-openapi.md)

---

**Back to index:**
- [root](root.md)
- [foundation](00-foundation-index.md)
- [architecture](10-architecture-index.md)
- [operations](20-operations-index.md)
- [appendix](39-appendix-index.md)

---
