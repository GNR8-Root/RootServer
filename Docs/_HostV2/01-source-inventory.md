# RootServer — Source Inventory

This file is a factual snapshot of what was discovered in the `RootServer` source tree. It is the evidence base for the generated documentation set.

---

## Tree summary

- Project root: `RootServer/`
- Solution: `RootServer.sln`
- Project: `RootServer.csproj`
- Entry point: `Program.cs`
- Key folders present:
- `Shared/_Sites/`
- `Shared/_Core/`
- `Shared/_Editor/`
- `Shared/Plugins/`
- `Docs/`
- `wwwroot/`

---

## Host ↔ Modules ↔ Plugins (discovery notes)

- `Shared/Plugins/` exists (plugin-style code is present inside the host repo).
- `Docs/` exists (handwritten / legacy documentation is present).

Evidence:
- `Shared/Plugins/`
- `Docs/`

---

## UI hierarchy findings (`Shared/_Sites`)

- `Shared/_Sites/` exists and contains UI hierarchy folders:
  - `Pages/`, `Layouts/`, `Components/`, `Sections/`, `Nav/` (discovered)

Evidence:
- `Shared/_Sites/Pages/`
- `Shared/_Sites/Layouts/`
- `Shared/_Sites/Components/`
- `Shared/_Sites/Sections/`
- `Shared/_Sites/Nav/`

---

## Numbered layer folders (00..09) findings

Discovered layer sets (examples):

- `Shared/_Core/00_Core` .. `Shared/_Core/09_Panels`
- `Shared/_Editor/00_Core` .. `Shared/_Editor/09_Panels`

Also discovered an extra layer folder:
- `02_Properties` (in `Shared/_Editor/`)

Evidence (sample paths):
- `Shared/_Core/00_Core/`
- `Shared/_Core/02_Fields/`
- `Shared/_Core/05_Nodes/`
- `Shared/_Editor/02_Properties/`

---

## Prefix system findings (from `.razor` filenames)

Detected prefixes (counts are discovered, not assumed):

- `W_`: 2 (example: `Shared/_Editor/07_Widgets/W_Console.razor`)
- `A_`: 15 (example: `Shared/_Editor/04_Actions/A_SplitViewCenter.razor`)
- `C_`: 17 (example: `Shared/_Editor/06_Components/C_DividerSticky.razor`)
- `PNL_`: 3 (example: `Shared/_Editor/09_Panels/PNL_Website.razor`)
- `V_`: 2 (example: `Shared/_Editor/08_View/V_Console.razor`)
- `P_`: 12 (example: `Shared/_Editor/03_Pointers/P_LogCatcher.razor`)
- `F_`: 18 (example: `Shared/_Core/02_Fields/F_Text_Url.razor`)
- `N_`: 2 (example: `Shared/_Sites/Nav/Section/N_Section.razor`)

Not observed as `.razor` filename prefixes in this scan:
- `D_` (Displays)

---

## Integrations found

- Airtable integration is present (see `Shared/Plugins/Airtable/`).

Evidence:
- `Shared/Plugins/Airtable/`
- `README.md` (describes Airtable abstractions and sync)

---

## Config and deployment files found

- App settings files:
- `appsettings.json`
- `appsettings.Development.json`

- Static assets:
  - `wwwroot/` present

---

## Tests and QA presence

- No dedicated `*.Tests.csproj` discovered in this scan.
- Test-related files/paths (if any) are listed in `01-inventory-index.json`.

If a test strategy exists, it is not obvious from solution/project structure alone and will be treated as **unknown** unless discovered in code.

---

## Secret-scan summary (locations only, no values)

Potential secret-like terms were detected in these files (values are **not** reproduced):

- `Docs/02__data-drives-ui.md` (terms: secret)
- `Docs/03__airtable.md` (terms: api_key, apikey, bearer, token)
- `Docs/Extend/Module-Internal/NodeEditor/node-editor-14-arch-blazor.md` (terms: apikey, sas)
- `Docs/Extend/Module-Internal/NodeEditor/node-editor-22-arch-performance.md` (terms: sas)
- `Docs/Extend/Module-Internal/NodeEditor/node-editor-23-arch-testing.md` (terms: sas)
- `Docs/Extend/Module-Internal/NodeEditor/node-editor-29-ui-design.md` (terms: token)
- `Docs/Extend/Module-Internal/NodeEditor/node-editor-43-diagrams.md` (terms: apikey, sas, token)
- `Docs/Extend/Plugin-External/azure-ai-docgen-rider/03-intelligence-plane.md` (terms: sas)
- `Docs/Extend/Plugin-External/azure-ai-docgen-rider/07-foundry-agents.md` (terms: sas)
- `Docs/Extend/Plugin-External/azure-ai-docgen-rider/A3-troubleshooting.md` (terms: token)
- `Docs/Extend/Plugin-External/azure-ai-docgen-rider/A4-security-identity.md` (terms: bearer, secret, token)
- `Docs/Extend/Plugin-External/azure-ai-docgen-rider/A8-cli-outline.md` (terms: bearer, token)
- `Docs/Extend/Plugin-External/azure-ai-docsgen-chatgpt/docsgen-02-base-concepts.md` (terms: token)
- `Docs/Extend/Plugin-External/azure-ai-docsgen-chatgpt/docsgen-03-base-models.md` (terms: token)
- `Docs/Extend/Plugin-External/azure-ai-docsgen-chatgpt/docsgen-08-base-integrations.md` (terms: secret, token)
- `Docs/Extend/Plugin-External/azure-ai-docsgen-chatgpt/docsgen-12-arch-index.md` (terms: secret)
- `Docs/Extend/Plugin-External/azure-ai-docsgen-chatgpt/docsgen-15-arch-data.md` (terms: token)
- `Docs/Extend/Plugin-External/azure-ai-docsgen-chatgpt/docsgen-21-arch-validation.md` (terms: token)
- `Docs/Extend/Plugin-External/azure-ai-docsgen-chatgpt/docsgen-24-arch-deployment.md` (terms: secret)
- `Docs/Extend/Plugin-External/azure-ai-docsgen-chatgpt/docsgen-29-ui-design.md` (terms: token)
- `Docs/Extend/generate-code-from-documentation-md.json` (terms: secret)
- `Docs/Host/00-preflight-summary.md` (terms: secret, token)
- `Docs/Host/05-final-validation-report.md` (terms: secret)
- `Docs/Host/11b-base-schema-and-structures.md` (terms: secret)
- `Docs/Host/11d-examples-and-usage.md` (terms: secret)
- `Docs/Host/12-architecture-overview.md` (terms: secret)
- `Docs/Host/13-arch-host-architecture.md` (terms: secret)
- `Docs/Host/19-arch-deployment-and-configuration.md` (terms: secret)
- `Docs/Host/42-appendix-risks-and-vulnerabilities.md` (terms: secret)
- `Docs/Host/_LLM/_generate-documentation-additional-info.md` (terms: secret, token)
- ... plus 11 more files (see raw scan via inventory tooling).

Notes:
- This report intentionally omits any secret values, tokens, or keys.
- Follow-up remediation guidance is provided in `rootserver-40-appendix-risks-and-vulnerabilities.md`.

---

## Next artifacts

- `01-inventory-index.json` — machine-readable index used for coverage/link mapping.

---
- **[Back to rootserver.md](rootserver.md)**
- **[Back to Base index](rootserver-00-base-index.md)**

---
