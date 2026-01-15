# Architecture Decision Records

---

## ADR-001: Schema-Driven UI

**Date**: 2023-Q1  
**Status**: Accepted

### Context
Need flexible UI that can change without code deployments.

### Decision
Store UI structure in Airtable, cache as JSON, render at runtime.

### Consequences
- ✅ Rapid UI iteration
- ✅ Non-technical content updates
- ❌ No compile-time safety for UI structure
- ❌ Manual sync required

---

## ADR-002: Numbered Hierarchy

**Date**: 2023-Q2  
**Status**: Accepted

### Context
Need predictable component organization across layers.

### Decision
Use numbered folders (00-09) for micro-to-macro hierarchy.

### Consequences
- ✅ Clear dependency chain
- ✅ Consistent across Core, Editor, Plugins
- ❌ Learning curve for new developers
- ❌ Folder renumbering if hierarchy changes

---

## ADR-003: Wrapper + Base Pattern

**Date**: 2023-Q3  
**Status**: Accepted

### Context
Complex components need separation of layout and logic.

### Decision
Split into Wrapper (.razor) and Base (.cs) files.

### Consequences
- ✅ Clean separation of concerns
- ✅ Testable logic layer
- ❌ Two files per component
- ❌ More navigation required

---

## ADR-004: Cache-First Data Strategy

**Date**: 2023-Q4  
**Status**: Accepted

### Context
Airtable API has rate limits and latency.

### Decision
Cache all data locally as JSON, load at startup.

### Consequences
- ✅ Fast load times
- ✅ Offline capability
- ❌ Stale data risk
- ❌ Manual sync required

---

## ADR-005: Event-Driven Architecture

**Date**: 2024-Q1  
**Status**: Accepted

### Context
Components need loose coupling for maintainability.

### Decision
Use service-based event system for state changes.

### Consequences
- ✅ Loose coupling
- ✅ Testable components
- ❌ Event subscription management
- ❌ Potential memory leaks if not disposed

---

## ADR-006: No Numeric Quality Thresholds

**Date**: 2024-Q4  
**Status**: Accepted

### Context
Numeric quality metrics can be gamed or misleading.

### Decision
Use human review and qualitative signals for code quality.

### Consequences
- ✅ Focus on real quality
- ✅ Developer judgment valued
- ❌ Less objective measurement
- ❌ Requires experienced reviewers

---

_Total ADRs: 6_

---

---

**Navigation**

- **[← Duplicate JSON Cleanup](rootserver-55-appendix-duplicate-json-cleanup.md)**
- **[Glossary →](rootserver-57-appendix-glossary.md)**
- **[Home](rootserver.md)**

---
