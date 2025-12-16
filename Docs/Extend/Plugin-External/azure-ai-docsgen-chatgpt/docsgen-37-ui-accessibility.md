# Accessibility

---

## Accessibility Goals

DocsGen UI should be usable with:

- keyboard-only navigation
- screen readers
- reduced motion preferences
- high contrast needs

Accessibility is not optional; it is required for review workflows.

---

## Keyboard Navigation

- All interactive controls must be reachable by tab.
- Timeline rows should be keyboard navigable.
- Issue table rows should support keyboard selection and “open preview” action.

---

## Screen Reader Support

- Status badges must have text labels, not color-only meaning.
- Phase timeline should expose phase number and state in accessible text.
- Validation issues should be readable as a table with proper headers.

---

## Color and Contrast

- Do not rely only on color for status (use icons and text labels).
- Ensure contrast on banners (failed vs warning vs success).
- Provide a consistent focus ring style.

---

## Markdown Preview Accessibility

- Headings should render as semantic headings.
- Code blocks should be scrollable without trapping focus.
- Links must be keyboard accessible.

---

## Reduced Motion

If reduced motion is enabled:
- disable pulses and shakes
- avoid animated spinners if possible (replace with “Running” text)

---

---

[← DocsGen](docsgen.md)
1. **[Base](docsgen-00-base-index.md)** – conceptual foundations, terminology, and canonical schemas
2. **[Architecture](docsgen-12-arch-index.md)** – orchestration, agents, validators, storage, and hosting boundaries
3. **[UI](docsgen-26-ui-index.md)** – user workflows, screens, components, and interaction rules
4. **[Appendix](docsgen-39-appendix-index.md)** – folder mapping, task references, and implementation checklist
5. **[Diagrams](docsgen-43-diagrams.md)** – architecture, state machines, and end-to-end sequences

---
