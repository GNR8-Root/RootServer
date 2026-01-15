# Base Boundaries

---

## Dependency Boundary Rules

RootServer follows strict dependency boundaries to maintain modularity and enable independent development of plugins.

---

## Host ↔ Module ↔ Plugin Architecture

### Allowed Dependencies

```
Plugin → Module (allowed)
Plugin → Host (allowed)
Module → Host (allowed)
Module ↔ Module (allowed)
```

### Forbidden Dependencies

```
Host → Plugin (forbidden)
Host should not know about plugin internals
```

---

## Rationale

### Host Independence

The host provides extension points and shared services but must not couple to specific plugin implementations. This enables:
- Adding/removing plugins without host changes
- Independent plugin versioning
- Plugin marketplace potential

### Plugin Flexibility

Plugins can reference host services and other modules, enabling them to leverage shared infrastructure while maintaining their own implementation details.

---

## Current Implementation

### RootServer (Host)

**Can reference:**
- .NET BCL
- Blazorise
- Shared/_Core
- Shared/_Editor
- Shared/_Sites

**Cannot reference:**
- Shared/Plugins/Airtable (directly)
- Plugin-specific types in Program.cs

**Exception:** `AirtableConfig.Initialize()` is called during startup, but this is a configuration method, not a direct dependency on plugin types.

---

### Airtable Plugin

**Can reference:**
- Host services (Pointer_Service, EditorView_Service)
- Shared/_Core base classes
- .NET BCL
- Blazorise

**Should not:**
- Assume host internal implementation details
- Directly manipulate host state outside service boundaries

---

## Dependency Verification

Currently no automated boundary checks exist. Recommended approach:

1. **NDepend or similar tool** to enforce architectural rules
2. **Unit tests** verifying no Host → Plugin references
3. **CI checks** failing on forbidden dependencies

---

## Module System Status

The `Shared/_Modules/` folder exists but contains minimal implementation. The intended module system would add an intermediate layer:

```
Host → Modules → Plugins
```

Where modules provide shared functionality consumed by multiple plugins.

**Current State:** Infrastructure only; no active modules implemented.

---

## Planned Enhancements

### Node System (05_Nodes)

The node system will provide plugin-to-plugin communication via a node graph:

```
Plugin A → Node Graph → Plugin B
```

This enables:
- Cross-plugin workflows
- Event-driven integration
- Decoupled plugin communication

**Status:** Folder structure exists; implementation planned.

---

[← Back to Base Index](rootserver-00-base-index.md)

---
