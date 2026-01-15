# Appendix: Risks and Vulnerabilities

A non-exhaustive list of risks discovered during inventory scanning, without exposing sensitive values.

---
## Potential secrets

This codebase contains config and code references that look like secrets. Values are **not** reproduced here.

Key locations (sample):
- `appsettings.Development.json` (signals: apikey)
- `Shared/Plugins/Airtable/00_Core/_Core/Airtable.cs` (signals: api_key, apikey)
- `Shared/Plugins/Airtable/00_Core/_Core/AirtableConfig.cs` (signals: apikey)
- `Docs/03__airtable.md` (signals: api_key, apikey, bearer, token)
- `Docs/Extend/Module-Internal/NodeEditor/node-editor-43-diagrams.md` (signals: apikey, sas, token)
- `Docs/Extend/Module-Internal/NodeEditor/node-editor-14-arch-blazor.md` (signals: apikey, sas)
- `Docs/HostV2/_LLM/generate-documentation-md-existing-codebase.json` (signals: api_key, apikey, bearer, client_secret, connection_string, connectionstring, privatekey, sas, secret, token)
- `Properties/launchSettings.json` (signals: apikey)
- `Shared/Plugins/Airtable/00_Core/_Core/AirtableTableService.cs` (signals: api_key, sas)
- `Docs/Extend/Plugin-External/azure-ai-docgen-rider/A3-troubleshooting.md` (signals: token)
- `Docs/Extend/Plugin-External/azure-ai-docgen-rider/A8-cli-outline.md` (signals: bearer, token)
- `Docs/Extend/Plugin-External/azure-ai-docgen-rider/A4-security-identity.md` (signals: bearer, secret, token)
- `Docs/Extend/Plugin-External/azure-ai-docsgen-chatgpt/docsgen-21-arch-validation.md` (signals: token)
- `Docs/Extend/Plugin-External/azure-ai-docsgen-chatgpt/docsgen-15-arch-data.md` (signals: token)
- `Docs/Extend/Plugin-External/azure-ai-docsgen-chatgpt/docsgen-02-base-concepts.md` (signals: token)
- `Docs/Extend/Plugin-External/azure-ai-docsgen-chatgpt/docsgen-03-base-models.md` (signals: token)
- `Docs/Extend/Plugin-External/azure-ai-docsgen-chatgpt/docsgen-08-base-integrations.md` (signals: secret, token)
- `Docs/Extend/Plugin-External/azure-ai-docsgen-chatgpt/docsgen-29-ui-design.md` (signals: token)
- `Docs/Extend/Module-Internal/NodeEditor/node-editor-29-ui-design.md` (signals: token)
- `Docs/Host/00-preflight-summary.md` (signals: secret, token)

Rule reminder: never paste keys/tokens into docs, issues, or commits.


## Boundary violations

No boundary violations were proven in this documentation run. A deeper dependency graph check should be performed as a follow-up.

Remediation plan:
- Add a build-time check that prevents Host projects from referencing plugin assemblies.


## Perf/memory risks

Potential hotspots (needs measurement):
- Large render trees composed from `Shared/_Sites`
- Schema-driven UI transforms
- Frequent Airtable fetch and JSON processing


## Remediation plan

- Move all secrets into environment variables or a secret store.
- Add configuration validation at startup (fail fast in dev).
- Add retries/timeouts for integration calls with user-visible error handling.


---
- **[Back to rootserver.md](rootserver.md)**
- **[Back to Appendix index](rootserver-39-appendix-index.md)**

---
