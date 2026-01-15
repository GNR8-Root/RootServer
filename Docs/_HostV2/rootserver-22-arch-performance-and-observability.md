# Performance and Observability

Targets, hotspots, and how to observe the system in production.

---
## Targets

Explicit performance targets were **not discovered** in this scan.

Investigation plan:
- Identify hot paths: Airtable fetch, schema-to-UI transform, large render trees.
- Define measurable budgets (TTFB, render time, memory) per top scenario.


## Hotspots

Likely hotspots (needs verification):
- Large component trees under `Shared/_Sites`
- Repeated schema/data fetch from Airtable
- JSON serialization/deserialization


## Observability / logging

Logging patterns are **unknown** from this scan.

Investigation steps:
- Search for `ILogger` usage.
- Identify where failures are surfaced to the UI.


---
- **[Back to rootserver.md](rootserver.md)**
- **[Back to Architecture index](rootserver-12-arch-index.md)**

---
