# Appendix A1 — Sample Configurations

Purpose
- Concrete configuration samples for running Azure AI DocGen in different modes and environments.
- Copy–paste friendly, with comments explaining trade‑offs.

Contents
- `generation-config.json` variants
- `plugin-requirements.json` minimal and extended examples
- Environment overrides (dev vs CI)

generation-config.json — interactive + strict (default)
```json
{
  "review_mode": "interactive",
  "validation_strictness": "strict",
  "profile": "Full43Strict"
}
```

generation-config.json — batch + lenient (ideation)
```json
{
  "review_mode": "batch",
  "validation_strictness": "lenient",
  "profile": "Lenient42"
}
```

generation-config.json — minimal profile (Phase 0–1 only)
```json
{
  "review_mode": "interactive",
  "validation_strictness": "strict",
  "profile": "Minimal13"
}
```

plugin-requirements.json — minimal viable example
```json
{
  "plugin": {
    "name": "Sample Catalog",
    "slug": "sample-catalog",
    "summary": "A small catalog plugin with items and categories."
  },
  "entities": [
    {
      "name": "Item",
      "id_strategy": "uuid",
      "fields": [
        { "name": "id", "type": "string", "required": true },
        { "name": "name", "type": "string", "required": true },
        { "name": "categoryId", "type": "string", "required": true }
      ],
      "validation": [
        { "rule": "notEmpty", "field": "name" }
      ]
    }
  ],
  "users_and_flows": {
    "primary_flows": [
      { "name": "Create Item", "steps": ["Open form", "Enter fields", "Save"] }
    ]
  },
  "host_integration_contract": {
    "runtime": { "ui_framework": "Blazor", "blazor_model": "Server" },
    "plugin_structure_reference": "MODULE-node-editor.zip"
  },
  "policies": {
    "permissions_model": "rbac"
  }
}
```

plugin-requirements.json — extended fields and constraints
```json
{
  "plugin": { "name": "Sample Catalog", "slug": "sample-catalog", "summary": "Extended example" },
  "entities": [
    {
      "name": "Item",
      "id_strategy": "uuid",
      "fields": [
        { "name": "id", "type": "string", "required": true },
        { "name": "name", "type": "string", "required": true, "minLength": 3 },
        { "name": "sku", "type": "string", "pattern": "^[A-Z0-9-]{5,}$" },
        { "name": "price", "type": "number", "minimum": 0 }
      ],
      "validation": [
        { "rule": "notEmpty", "field": "name" },
        { "rule": "regex", "field": "sku", "pattern": "^[A-Z0-9-]{5,}$" }
      ]
    },
    { "name": "Category", "id_strategy": "uuid", "fields": [ { "name":"id","type":"string","required":true }, { "name":"title","type":"string","required":true } ] }
  ],
  "users_and_flows": {
    "primary_flows": [ { "name":"Create Item", "steps":["Open","Edit","Save"] } ],
    "secondary_flows": [ { "name":"Bulk Import", "steps":["Upload CSV","Map","Import"] } ]
  },
  "performance_targets": { "p95_generation_ms": 5000 },
  "integration_failure_policies": { "tool_timeout": "retry-3-then-fail" },
  "audit": { "enabled": true, "retention_days": 30 },
  "host_integration_contract": { "runtime": { "ui_framework": "Blazor", "blazor_model": "Server" }, "plugin_structure_reference": "MODULE-node-editor.zip" },
  "policies": { "permissions_model": "rbac" }
}
```

Environment overrides (dev vs CI)
```text
 DEV: review_mode=interactive, strictness=lenient (early iteration)
 CI:  review_mode=batch,       strictness=strict  (release candidates)
```

Related
- [14-profiles-and-strictness.md](14-profiles-and-strictness.md)
- [11-artifacts-and-manifest.md](11-artifacts-and-manifest.md)

---

**Back to index:**
- [root](root.md)
- [foundation](00-foundation-index.md)
- [architecture](10-architecture-index.md)
- [operations](20-operations-index.md)
- [appendix](39-appendix-index.md)

---