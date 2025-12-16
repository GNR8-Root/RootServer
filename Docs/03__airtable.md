[← Project Overview](../README.md)

---

# Airtable Overview

---

1. **What Airtable Is**  
   A hybrid between a spreadsheet and a relationaldatabase. Easy for non-technical users, powerful enough for developers via its REST API and metadata structure.
---
2. **Base**  
   A top-level container (like a database). Holds tables, automations, views, extensions. Each base has an ID like `appXXXXXXXXXXXX`.
---
3. **Tables**  
   Equivalent to DB tables or sheets. Each table contains fields (columns) and records (rows). Tables define the schema and relationships.
---
4. **Fields**  
   Typed columns. Common types: text, long text, number, select, linked record, attachment, rollup, lookup, formula, checkbox, date, URL. Field config is crucial for schema-driven UI.
---
5. **Records**  
   Rows inside a table. Each record has an ID (`recXXXX`) and field/value pairs. Attachments and linked records are arrays. Records come back via the API as `{ id, fields }`.
---
6. **Views**  
   Saved configurations for filtering, sorting, and grouping. API queries can target a view to only return filtered records: `?view=MyView`.
---
7. **Relationships**  
   Done with *Linked Record* fields. These create relationships like one-to-many or many-to-many, enabling reference graphs similar to relational DBs.
---
8. **Automations**  
   Event-driven workflows. Trigger types: record created/updated, condition match, schedule, webhook. Actions: update/create record, send requests, run JavaScript, branch logic.
---
9. **API**  
   Simple REST API:  
   - `GET /v0/{baseId}/{table}` – list records  
   - `POST /v0/{baseId}/{table}` – create  
   - `PATCH /v0/{baseId}/{table}/{id}` – update  
   Uses Bearer tokens. Batch writes allow up to 10 records per request.

---

10. **SDKs (Node.js & C#)**  
    Airtable provides official JS tooling and the community uses Airtable.NET for C#.

    **Node.js SDK:**
    ```js
    const Airtable = require('airtable');
    const base = new Airtable({ apiKey }).base('appXXXX');
    base('Pages').select().eachPage((records, next) => next());
    ```

    **C# SDK (Airtable.NET):**  
    [Airtable.NET GitHub](https://github.com/ngocnicholas/airtable.net)
    ```csharp
    var client = new AirtableBase("YOUR_API_KEY", "appXXXX");
    var response = await client.ListRecords("Pages");
    ```

---

more info: [airtable.com](https://airtable.com)

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

