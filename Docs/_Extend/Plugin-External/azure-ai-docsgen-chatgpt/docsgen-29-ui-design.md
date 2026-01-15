# Design System

---

> Tailwind-first approach: describe tokens using Tailwind-like utility mapping.
> DocsGen UI is primarily dashboards, lists, and report viewers.

## Color Palette

### Semantic Status Colors

| Status | Suggested Color | Usage |
|-------|------------------|------|
| Running | Blue | Active phase, in-progress indicators |
| Passed | Green | Gate pass badges, success banners |
| Failed | Red | Gate fail badges, error banners |
| Awaiting Approval | Amber | Approval-required state, action prompts |
| Canceled | Gray | Canceled run state |

### Background & Surface

| Token | Guidance | Usage |
|------|----------|------|
| App background | `bg-zinc-950` or host equivalent | Page background |
| Surface | `bg-white/5` | Cards, panels |
| Surface elevated | `bg-white/10` | Hover, selected rows |
| Border | `border-white/10` | Card and table boundaries |

### Text

| Token | Guidance | Usage |
|------|----------|------|
| Primary | `text-zinc-100` | Headings and main content |
| Secondary | `text-zinc-400` | Descriptions, metadata |
| Muted | `text-zinc-500` | Disabled states, captions |

---

## Typography

DocsGen benefits from clear information hierarchy.

| Use | Tailwind Guidance |
|-----|-------------------|
| H1 | `text-2xl font-semibold` |
| H2 | `text-xl font-semibold` |
| Section label | `text-sm font-semibold text-zinc-300` |
| Body | `text-sm leading-6` |
| Code | `font-mono text-xs leading-6` |

---

## Components as Visual Language

### Badges
Use small badges for:
- phase number
- status
- strictness and review mode

### Tables
Structured issues and artifact lists should be tables with:
- sticky header (optional)
- row hover
- severity column with icon + text (do not rely on color alone)

### Markdown Viewer
Markdown previews should use:
- readable line length
- code blocks with scroll
- heading anchors for navigation (optional)

---

## Iconography

RootServer already uses FontAwesome via Blazorise.
DocsGen can use icons consistently:

- play/start run
- pause/await approval
- check/pass
- x/fail
- download
- file/text
- warning

---

## Empty States

DocsGen should provide explicit empty states:
- no artifacts yet
- no issues for this phase
- waiting for first event

An empty screen without explanation is treated as a UX bug.

---

---

[← DocsGen](docsgen.md)
1. **[Base](docsgen-00-base-index.md)** – conceptual foundations, terminology, and canonical schemas
2. **[Architecture](docsgen-12-arch-index.md)** – orchestration, agents, validators, storage, and hosting boundaries
3. **[UI](docsgen-26-ui-index.md)** – user workflows, screens, components, and interaction rules
4. **[Appendix](docsgen-39-appendix-index.md)** – folder mapping, task references, and implementation checklist
5. **[Diagrams](docsgen-43-diagrams.md)** – architecture, state machines, and end-to-end sequences

---
