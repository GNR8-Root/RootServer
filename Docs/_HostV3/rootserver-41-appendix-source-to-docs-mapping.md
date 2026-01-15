# Source-to-Docs Mapping

## Folder → Page Mapping

| Source Folder | Documentation Pages |
|---------------|---------------------|
| Program.cs | 06-base-runtime-execution, 07-base-lifecycle |
| Shared/_Core/ | 04-base-folder-system, 29-ui-layer-folders, 32-38 (UI layers) |
| Shared/_Core/00_Core/ | 02-base-concepts, 11-base-contracts |
| Shared/_Core/02_Fields/ | 32-ui-fields |
| Shared/_Core/03_Pointers/ | 33-ui-pointers |
| Shared/_Core/04_Actions/ | 34-ui-actions |
| Shared/_Core/06_Components/ | 36-ui-components |
| Shared/_Editor/ | 27-ui-overview, 38-ui-panels |
| Shared/_Sites/ | 28-ui-hierarchy-model |
| Shared/Plugins/Airtable/ | 08-base-integrations, 19-arch-update-and-sync, 20-arch-composition |
| Json/ | 10-base-schemas, 16-arch-json-and-assets, 42-appendix-duplicate-json-cleanup |
| README.md | 01-base-vision |

## Key File → Page Mapping

| File | Documentation Page |
|------|-------------------|
| Program.cs | 06-base-runtime-execution |
| Shared/_Core/00_Core/Events/Pointer_Service.cs | 33-ui-pointers, 18-arch-rendering-and-state |
| Shared/_Core/02_Fields/_Core/Base/FieldBase.cs | 32-ui-fields, 11-base-contracts |
| Shared/_Core/04_Actions/_Core/ABase.razor | 34-ui-actions, 11-base-contracts |
| Shared/Plugins/Airtable/04_Actions/A_AirtableSync.razor | 19-arch-update-and-sync |
| appsettings.json | 24-arch-deployment-and-config |

## New Contributor Guide

### Where to Start

1. **Understand Vision:** Read 01-base-vision, README.md
2. **Learn Structure:** Read 04-base-folder-system, 29-ui-layer-folders
3. **Study Patterns:** Read 30-ui-prefix-system, 02-base-concepts
4. **Explore Code:**
   - Start with Program.cs
   - Then Shared/_Core/00_Core/ for services
   - Then Shared/_Core/02_Fields/ for component examples
   - Then Shared/Plugins/Airtable/ for plugin patterns

### Common Tasks

**Adding Field Component:**
- Source: Shared/_Core/02_Fields/
- Docs: 32-ui-fields, 11-base-contracts

**Creating Plugin:**
- Source: Shared/Plugins/
- Docs: 03-base-boundaries, 20-arch-composition, 08-base-integrations

**Modifying Editor:**
- Source: Shared/_Editor/
- Docs: 27-ui-overview, 38-ui-panels

[← Back to Appendix Index](rootserver-39-appendix-index.md)

---
