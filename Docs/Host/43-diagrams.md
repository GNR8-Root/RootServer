# Diagrams — RootServer Host (Strict)

ASCII diagrams describing system architecture, plugin lifecycle, boundaries, UI hierarchy, and an Airtable integration flow. Keep sensitive details out of diagrams.

---

## System Architecture
+-------------------------+ |         Client          | +------------+------------+ | v +------------+------------+ |   Blazor UI (Views /    | |        Panels)          | +------------+------------+ | v +------------+------------+ | Widgets & Components    | | (compose micro elements)| +------------+------------+ | v +------------+------------+ | Displays / Fields /     | | Pointers / Actions      | +------------+------------+ | v +------------+------------+ | Host Services / DI      | +-----+------+-----+------+ |            | v            v +-----+----+   +---+------------------+ | Modules |   |      Plugins          | | (always |   | (optional, discovered | | active) |   |   and activated)      | +-----+----+   +----------+-----------+ |                    | +---------+----------+ | v +---------------+---------------+ | External Integrations         | | (e.g., Airtable)              | +-------------------------------+

---

## Plugin Lifecycle (Sequence)
Startup ├─ Load configuration ├─ Build DI container ├─ Initialize Modules (always active) ├─ [Optional] Discover Plugins │     ├─ Validate contracts │     └─ Activate Plugins └─ Initialize Routes / Views
Shutdown ├─ Deactivate Plugins ├─ Dispose Modules / Host Services └─ Flush Telemetry (logs/metrics/traces)

---

## Dependency Boundaries
Allowed: Host  → Modules Modules ↔ Modules Plugins → Host Plugins → Modules
Avoid: Host  → Plugins
Planned (experimental via Node system): Plugins ↔ Plugins

---

## UI Hierarchy (Micro → Macro)
Numbered Folders (source: Shared/_Sites)
00_Core ├─ 01_Displays  (prefix D_) ├─ 02_Fields    (prefix F_) ├─ 03_Pointers  (prefix P_) ├─ 04_Actions   (prefix A_) ├─ 05_Components(prefix C_) ├─ 06_Widgets   (prefix W_) ├─ 07_View      (prefix V_) └─ 08_Panels    (prefix PNL_)
Composition Flow: D_/F_/P_/A_ → C_ → W_ → V_ → PNL_

---

## Airtable Integration Flow (Conceptual)
[V/PNL] View or Panel | v [Host Service] | v [Module Client] --HTTP--> [Airtable API]
Policies (strict):
•
Timeouts (per call)
•
Retries (bounded) with backoff
•
Circuit breaker for persistent failures
Observability:
•
Logs with correlation IDs
•
Metrics: latency, errors, cache hits
•
Traces across Host → Module → Airtable

---

**Back navigation:** **[Architecture Index](./docsgen-12-arch-index.md)** · **[Appendix Index](./docsgen-39-appendix-index.md)** · **[Root Index](./RootServer.md)**

---


