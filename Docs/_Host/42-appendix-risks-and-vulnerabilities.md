# Appendix — Risks and Vulnerabilities (Host)

Security and reliability risks to monitor and remediate. Do not include secret values.

---

## Potential Risks
- Secret exposure in configs or logs (`appsettings*.json`, environment)
- Weak failure policies for integrations (missing timeouts/retries/backoff)
- Boundary violations (Host referencing plugin types)
- Performance hotspots (rendering, blocking sync calls, chatty integrations)

---

## Remediation Steps
- Externalize secrets; rotate and audit access
- Enforce timeouts/retries/backoff/circuit breakers in integration clients
- Validate boundaries with static checks; isolate plugin contracts
- Add metrics/traces; set budgets and dashboards

---

**Back navigation:** **[Appendix Index](./docsgen-39-appendix-index.md)** · **[Architecture Index](./docsgen-12-arch-index.md)**

---
