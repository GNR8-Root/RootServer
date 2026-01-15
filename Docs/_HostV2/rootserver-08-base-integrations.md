# Base Integrations

What the host integrates with, and what safety/failure policies are (or are not) enforced.

---
## Integrations inventory

- Airtable integration discovered under `Shared/Plugins/Airtable/`.

Evidence:
- `Shared/Plugins/Airtable/`
- `README.md`


## Failure policies

Timeout/retry/backoff/circuit-breaker policies are **not consistently discoverable** in this scan.

Investigation steps:
- Search Airtable client calls for retry wrappers.
- Check for `HttpClientFactory` usage and configured timeouts.


## Data ownership

- Airtable data model follows Base → Table → Row → Field.
- Schema-driven UI suggests that schema/metadata is treated as data that drives UI composition.


---
- **[Back to rootserver.md](rootserver.md)**
- **[Back to Base index](rootserver-00-base-index.md)**

---
