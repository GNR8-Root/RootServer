# Base Schemas

What schemas/assets exist, how they should evolve, and how to avoid drift and duplication.

---
## Schema inventory

JSON files exist across configuration and documentation. Key examples:
- `appsettings.json`
- `appsettings.Development.json`

If additional schema assets exist (e.g., exported Airtable schemas), they will be enumerated in a deeper pass.


## Versioning / evolution

No explicit schema versioning system was discovered in this scan.

Investigation steps:
- Search for schema version fields (e.g., `schemaVersion`, `version`).
- Identify canonical schema folders (often under `Shared/` or `Docs/`).


## Validation strategy

- Runtime validation rules may exist in Field/Action components.
- See `rootserver-21-arch-validation-rules.md` for where validation is expected to live.

### Duplicate JSON detection hook

- See appendix 42 for a cleanup plan and a CI guardrail idea.


---
- **[Back to rootserver.md](rootserver.md)**
- **[Back to Base index](rootserver-00-base-index.md)**

---
