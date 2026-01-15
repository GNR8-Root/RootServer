# RootServer Documentation Bundle

This page defines the **strict Host documentation bundle contents** and the **packaging/validation checklist** for distribution as a ZIP.

---

## Bundle contents

### Core index files
- `Docs/Host/RootServer.md`
- `Docs/Host/00-preflight-summary.md`

### Foundation and base
- `docsgen-00-base-index.md`
- `Docs/Host/11-base-concepts.md`
- `Docs/Host/11b-base-schema-and-structures.md`
- `Docs/Host/11c-integrations-overview.md`
- `Docs/Host/11d-examples-and-usage.md`

### Architecture
- `Docs/Host/docsgen-12-arch-index.md`
- `Docs/Host/12-architecture-overview.md`
- `Docs/Host/13-arch-host-architecture.md`
- `Docs/Host/14-arch-module-and-plugin-system.md`
- `Docs/Host/15-arch-di-contracts.md`
- `Docs/Host/16-arch-performance-and-observability.md`
- `Docs/Host/17-arch-error-handling-and-codes.md`
- `Docs/Host/18-arch-testing-and-qa.md`
- `Docs/Host/19-arch-deployment-and-configuration.md`

### UI
- `Docs/Host/docsgen-26-ui-index.md`
- `Docs/Host/26-ui-overview-and-hierarchy.md`
- `Docs/Host/27-ui-composition-patterns.md`
- `Docs/Host/37-ui-accessibility-and-ux.md`

### Appendices
- `Docs/Host/docsgen-39-appendix-index.md`
- `Docs/Host/41-appendix-project-structure.md`
- `Docs/Host/42-appendix-risks-and-vulnerabilities.md`
- `Docs/Host/43-appendix-duplicate-json-cleanup.md`

### Diagrams and final reports
- `Docs/Host/43-diagrams.md` (ASCII)
- `Docs/Host/05-final-validation-report.md`

---

## Optional: include for traceability

Include these in the ZIP **only if you want provenance/context shipped with the bundle**:

- `Docs/Extend/Plugin-External/azure-ai-docsgen-chatgpt` (style reference)
- `Docs/generate-documentation-md-existing-codebase.json` (prompt reference)

---

## Packaging instructions

### ZIP name
- Create ZIP: `{slug}-documentation-bundle.zip`
- For RootServer: `rootserver-documentation-bundle.zip`

### ZIP contents
- Include **all files listed in “Bundle contents”**
- Add a top-level `README.md` that
