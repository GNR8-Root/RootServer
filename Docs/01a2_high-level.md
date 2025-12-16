[← Project Overview](../README.md)

[← Detailed Documentation](01__detailed.md)

---

## High-Level Summary

---

### Overall Concept

This is a Blazor Server application that serves two purposes:

1. Renders a public-facing websites composed of reusable "sections" (Welcome, Agenda, Gallery, etc. Dynamicly generated from Airtable content)
2. Provides an Editor UI for exploring and manipulating Airtable-backed content (tables, rows, bookmarks (not fully implemented))

The system uses a custom internal design framework split into four component libraries:

* `_Core` - Generic framework building blocks
* `_Editor` - Editor-specific components and services
* `Airtable` - Airtable integration layer
* `_Site` - Public website implementation

Architecture flow:

```
Pages (Index, Editor)
    -> Shared._Site (renders public site)
        -> Shared.Airtable + Json (content sources)
            -> Shared._Editor + services (editor state management)
```

---

## Project Structure

### Root-Level Files

**Program.cs**

Standard ASP.NET Core / Blazor Server bootstrapping that:

* Creates the WebApplication builder
* Registers Blazorise (Bootstrap5 + FontAwesome)
* Registers application-specific services:
    * MainNavMenuService
    * EditorView_Service
    * EditorVisibility_Service
    * Pointer_Service
    * LogCatcher_Service
    * AirtableTableService, SettingsService, etc.
* Configures middleware (UseStaticFiles, routing, BlazorHub, _Host fallback)

**App.razor**

Standard Blazor app shell containing Router, CascadingAuthenticationState, Layout components.

**Project Files**

* `web-test-blazer-server.csproj` and `.sln` - Single Blazor Server project with no separate test project

### Main Directories

* `Pages/` - Razor pages that are navigable routes
* `Shared/` - The bulk of the codebase: reusable components and services
* `Data/` - Basic data classes and navigation data
* `Json/` - Serialized Airtable data stored as JSON
* `Design/` - Simple utilities (icon handling)
* `wwwroot/` - Static assets (CSS, JS, etc.)

---

## Pages: Navigable Routes

### Index.razor

* Route: `/`
* Uses `<PNL_Website />` (from Shared._Core / _Site) to render the main site
* Contains a button linking to `/editor`

### Editor.razor + Editor.razor.cs

* Route: `/editor`
* Injected dependencies:
    * EditorView_Service
    * EditorVisibility_Service
    * IJSRuntime
    * NavigationManager

Key functionality:

* Defines `EditorSplitView` enum for managing top/center/bottom views
* Logic to manage split panes, toggle visibility, and adjust heights (editorUpperSplitViewTop/Center/Bottom)
* In `OnInitializedAsync`:
    * Deserializes Airtable tables via `Air.DeSerializeTables()`
    * Subscribes to view/visibility events from services
* `OnAfterRenderAsync`:
    * Imports JavaScript (`../js/webflow/webflow.js`)
    * Updates on navigation changes

### Template Pages

* `Counter.razor`, `FetchData.razor`, `TestPage.razor` and their `.cs` code-behind files
* Mostly template/demo pages demonstrating standard Blazor patterns

### Standard Pages

* `_Host.cshtml` - Standard Blazor host page
* `Error.cshtml` - Error handling page



## Design System Utilities

### Design/Icons.cs

Minimal design system utility for icon handling:

```csharp
enum Icons { home, plus, volume_high, command }

static class Icon {
    Convert(string icon) -> "oi-" + icon.Replace('_','-')
}
```

Maps strongly-typed enums to CSS icon class names. This is a lightweight utility that could be expanded into a more comprehensive design system.

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