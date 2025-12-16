# Animation & Motion

---

## Timeline Motion

- **Phase status change**: icon cross-fade (150–200ms)
- **Active phase highlight**: subtle pulse or background tint
- **Gate pass**: check icon pop-in (150ms)
- **Gate fail**: brief shake on failure banner (avoid excessive motion)

Motion exists to communicate state changes, not to decorate.

---

## Report Viewer Motion

- **Navigate to report**: content fade-in (150ms)
- **Issue row selection**: highlight transition (100ms)

---

## Toast Notifications (Optional)

Use toasts for:
- “Run created”
- “Approval recorded”
- “Download started”

Avoid using toasts for validation failures; failures should be persistent and visible until resolved.

---

## Accessibility Rule

All motion should respect reduced-motion settings.
If reduced motion is enabled:
- disable shakes and pulses
- use instant state changes

---

---

[← DocsGen](docsgen.md)
1. **[Base](docsgen-00-base-index.md)** – conceptual foundations, terminology, and canonical schemas
2. **[Architecture](docsgen-12-arch-index.md)** – orchestration, agents, validators, storage, and hosting boundaries
3. **[UI](docsgen-26-ui-index.md)** – user workflows, screens, components, and interaction rules
4. **[Appendix](docsgen-39-appendix-index.md)** – folder mapping, task references, and implementation checklist
5. **[Diagrams](docsgen-43-diagrams.md)** – architecture, state machines, and end-to-end sequences

---
