[← Project Overview](../README.md)

[← Detailed Documentation](01__detailed.md)

---

## Shared/Airtable: Integration Layer

This is one of the most architecturally significant parts of the system.

---

### Core Classes

Located in `Shared/Airtable/00_Core/_Core`:

**Airtable.cs**

Static `Air` class serving as central Airtable coordinator:

* Holds hard-coded `BASE_ID` and API key
* Maintains `Dictionary<string, AirtableTableBase> tables`
* Nested static `Table` class with table objects:
    * TableApps
    * TableWorkspaces
    * TableTables
    * TableMediaCollectionContent
    * etc.

**AirtableTableBase.cs / AirtableTable.cs**

Abstractions around an Airtable table providing:

* `GetTable()` - Read data from Airtable via `AirtableApiClient`
* `SerializeTable()` / `DeSerializeTable()` - Handle saving/loading data to/from `Json/` folder

**AirtableVarAsStringExtention.cs**

Helper methods to convert Airtable values to strings and other common transformations.

**AirtableTableService.cs**

Service layer for interacting with Airtable tables, providing a clean interface to the rest of the application.

### Strongly-Typed Table Definitions

Located in `Tables/`:

* `TableSettings.cs`, `SettingsService.cs`
* Each table has its own strongly-typed representation
* Services provide typed access to table data

### UI Layer Components

**01_Displays, 02_Fields, 03_Pointers**

Components representing Airtable entities:

* `P_Table` - Table pointer/selector
* `P_Row` - Row pointer/selector
* `P_Field` - Field pointer/selector

**04_Actions**

**A_AirtableSync.razor + A_AirtableSync.razor.cs**

Handles "Sync Airtable" action with upload and download:

* Uses `LogCatcher_Service` to show progress:
    * "Uploading"
    * "Downloading"
    * "[current/total] {fileName}"
    * "done!"
* Iterates through `Air.tables` and calls:
    * `GetTable()` - Fetch from Airtable
    * `SerializeTable()` - Save to JSON
* Uses `PagesStatic.ChangeState()` to trigger UI refresh

Other actions include:

* New row
* Duplicate row
* Delete row
* Bookmark row/table
* Search functionality

**06_Widgets**

**W_Tables.razor + W_Tables.razor.cs**

Widget for listing and selecting tables in the editor.

**07_View**

**V_Workspace.razor + V_Workspace.razor.cs**

* Inherits from `BaseView`
* Composes tables widget in a tab panel
* Primary workspace view in the editor

**08_Panels**

* `PNL_Selection` - Shows current selection details
* `PNL_Structure` - Displays structure information

### Summary

The Airtable layer functions as a small Airtable client framework built on top of `AirtableApiClient`, providing:

* Blazor UI for browsing and editing tables
* Local JSON caching for offline and performance
* Strongly-typed access to table data
* Synchronization utilities

---

[← Project Overview](../README.md)
* [Detailed Documentation](01__detailed.md) (01__detailed.md)
  * [Review](01a0_review.md) (01a0_review.md)
  * [Architecture](01a1_architecture.md) (01a1_architecture.md)
  * [High-Level](01a2_high-level.md) (01a2_high-level.md)
  * [Shared/_Core](01b1_shared-core.md) (01b1_shared-core)
  * [Shared/_Editor](01b2_shared-editor.md) (01b2_shared-editor.md)
  * [Shared/_Sites](01b3_shared-sites.md) (01b3_shared-sites.md)
  * [Shared/Airtable](01b4_shared-airtable.md) (01b4_shared-airtable.md)
  * [Json](01b5_json.md) (01b5_json.md)
  * [Patterns](01c1_patterns.md) (01c1_patterns.md)
  * [Decisions](01c2_decisions.md) (01c2_decisions.md)
  * [Workflow](01c3_workflow.md) (01c3_workflow.md)
  * [Evolution](01c4_evolution.md) (01c4_evolution.md)
* [Data Drives UI](02__data-drives-ui.md) (02__data-drives-ui.md)
* [Airtable](03__airtable.md) (03__airtable.md)
* [Future Vision](04__vision.md) (04__vision.md)
  * [Architecture](04a1_architecture.md) (04a1_architecture.md)
  * [AI Integration](04a2_ai-integration.md) (04a2_ai-integration.md)
  * [Plugins](04a3_plugins.md) (04a3_plugins.md)
  * [Dynamic UI](04a4_dynamic-ui.md) (04a4_dynamic-ui.md)
  * [Automation](04a5_automation.md) (04a5_automation.md)
  * [Positioning](04b1_positioning.md) (04b1_positioning.md)
  * [Value](04b2_value.md) (04b2_value.md)
  * [Tech Specs](04c1_tech-specs.md) (04c1_tech-specs.md)
  * [Migration](04d1_migration.md) (04d1_migration.md)
* [AI Generated Code Review](05__review.md) (05__review.md)

---

to test the current state of the project: please request a key at:

**[arnold@znzr.io](mailto:arnold@znzr.io)**

---