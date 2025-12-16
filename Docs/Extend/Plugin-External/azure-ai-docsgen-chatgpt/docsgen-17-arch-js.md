# JavaScript Architecture (Optional)

---

## Why JavaScript Exists Here

DocsGen does not require JavaScript to function, but optional JS can improve UX:

- richer Markdown preview (syntax highlighting)
- diff viewing (side-by-side or inline)
- large file rendering performance
- drag-and-drop upload UX improvements

DocsGen must remain fully functional without JS enhancements.

---

## Hard Boundary

JavaScript must not:
- call Foundry agents directly
- write artifacts directly to storage
- decide validation outcomes
- advance phases

If JS is used, it must act as a view-layer enhancement only.

---

## Optional JS Modules (Examples)

### Markdown Preview Enhancements
- client-side rendering improvements
- code block formatting
- anchor navigation

### Diff Viewer
- compare current artifact vs previous artifact version
- highlight changed lines
- expose “download old version” action

### Upload UX
- progress indicators for large zip uploads
- chunked uploads (if required by host limits)

---

## JS Interop Contract (Conceptual)

If used, JS should expose small, testable functions:

```text
docsgen.preview.renderMarkdown(markdownText) -> html
docsgen.diff.compute(oldText, newText) -> diffModel
docsgen.upload.getClientFileStats(file) -> stats
```

All actual data persistence still occurs through the orchestrator API.

---

## Failure Behavior

If JS fails or is unavailable:
- fall back to plain Markdown rendering
- fall back to server-generated diffs (optional)
- keep run control actions fully functional

---

---

[← DocsGen](docsgen.md)
1. **[Base](docsgen-00-base-index.md)** – conceptual foundations, terminology, and canonical schemas
2. **[Architecture](docsgen-12-arch-index.md)** – orchestration, agents, validators, storage, and hosting boundaries
3. **[UI](docsgen-26-ui-index.md)** – user workflows, screens, components, and interaction rules
4. **[Appendix](docsgen-39-appendix-index.md)** – folder mapping, task references, and implementation checklist
5. **[Diagrams](docsgen-43-diagrams.md)** – architecture, state machines, and end-to-end sequences

---
