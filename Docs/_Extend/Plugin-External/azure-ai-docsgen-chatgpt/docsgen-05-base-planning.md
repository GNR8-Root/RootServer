# Base Planning

---

## Why Planning Exists

DocsGen treats the planned file list as the **link authority** for the entire run.

Without planning, generation tends to drift:
- index files link to non-existent targets
- optional files are referenced even when excluded
- file naming diverges between phases

Planning solves this by forcing an explicit list before content generation begins.

---

## Docset Structure (43 Core Files)

DocsGen uses a fixed 43-file deliverable structure:

- Root entry file: `docsgen.md`
- Base index and base files: `docsgen-00` through `docsgen-11`
- Architecture index and architecture files: `docsgen-12` through `docsgen-25`
- UI index and UI files: `docsgen-26` through `docsgen-38`
- Appendix index and appendix files: `docsgen-39` through `docsgen-42`
- Diagrams: `docsgen-43`

The numbering is stable so that:
- validators can be phase-aware by file ranges
- humans can navigate consistently across plugins
- partial regeneration can target predictable regions

---

## Planned File List (Link Authority)

A planned file list is a generation artifact produced at Phase 1 and treated as authoritative for link validation.

Example (DocsGen full docset):

```json
{
  "version": "1.0",
  "slug": "docsgen",
  "core_files": [
    "docsgen.md",
    "docsgen-00-base-index.md",
    "docsgen-01-base-vision.md",
    "docsgen-02-base-concepts.md",
    "docsgen-03-base-models.md",
    "docsgen-04-base-phase-types.md",
    "docsgen-05-base-planning.md",
    "docsgen-06-base-execution.md",
    "docsgen-07-base-gate-protocol.md",
    "docsgen-08-base-integrations.md",
    "docsgen-09-base-examples.md",
    "docsgen-10-base-sync.md",
    "docsgen-11-base-schema.md",
    "docsgen-12-arch-index.md",
    "docsgen-13-arch.md",
    "docsgen-14-arch-blazor.md",
    "docsgen-15-arch-data.md",
    "docsgen-16-arch-json.md",
    "docsgen-17-arch-js.md",
    "docsgen-18-arch-visual.md",
    "docsgen-19-arch-updates.md",
    "docsgen-20-arch-macro.md",
    "docsgen-21-arch-validation.md",
    "docsgen-22-arch-performance.md",
    "docsgen-23-arch-testing.md",
    "docsgen-24-arch-deployment.md",
    "docsgen-25-arch-resources.md",
    "docsgen-26-ui-index.md",
    "docsgen-27-ui-spec.md",
    "docsgen-28-ui-uxd.md",
    "docsgen-29-ui-design.md",
    "docsgen-30-ui-layout.md",
    "docsgen-31-ui-navigation.md",
    "docsgen-32-ui-components.md",
    "docsgen-33-ui-interactions.md",
    "docsgen-34-ui-motion.md",
    "docsgen-35-ui-validation.md",
    "docsgen-36-ui-sync.md",
    "docsgen-37-ui-accessibility.md",
    "docsgen-38-ui-examples.md",
    "docsgen-39-appendix-index.md",
    "docsgen-40-appendix-ui.md",
    "docsgen-41-appendix-plugin-structure.md",
    "docsgen-42-appendix-task-reference.md",
    "docsgen-43-diagrams.md"
  ],
  "optional_files": [],
  "excluded_files": [],
  "notes": {
    "link_authority": "All internal links must target files listed in core_files.",
    "numbering_invariant": "Number blocks remain stable across profiles; files may be optional but numbering must not be renumbered.",
    "docset_profile": "DocsGen uses the full 43-file structure in strict mode."
  }
}
```

---

## Link Rules (Deterministic)

- Internal links must use **relative paths**.
- A link target must exist in the planned list.
- Links must not point to generation artifacts (planned file list, validation reports) unless the docset profile explicitly includes them.

DocsGen’s convention is that core documentation files link only to other core documentation files.

---

## Docset Profiles (Full vs Minimal)

Docset profiles allow the same numbering system to support different deliverables without special-casing prompts.

### Full Strict Profile
- All 43 files required
- Diagrams required
- High completeness threshold
- All validators enforced

### Lenient Profile
- Diagrams may be optional
- Completeness threshold may be reduced
- Some missing “operational details” can be warnings, but core rules still apply:
  - no placeholders
  - no broken links
  - terminology consistency
  - schema consistency

---

## Regeneration and Planning

Planning is stable across a run.

If a regeneration action updates the planned list, it must be:
- recorded as an explicit artifact change
- validated against existing links
- treated as a controlled migration, not an automatic rewrite

---

---

[← DocsGen](docsgen.md)
1. **[Base](docsgen-00-base-index.md)** – conceptual foundations, terminology, and canonical schemas
2. **[Architecture](docsgen-12-arch-index.md)** – orchestration, agents, validators, storage, and hosting boundaries
3. **[UI](docsgen-26-ui-index.md)** – user workflows, screens, components, and interaction rules
4. **[Appendix](docsgen-39-appendix-index.md)** – folder mapping, task references, and implementation checklist
5. **[Diagrams](docsgen-43-diagrams.md)** – architecture, state machines, and end-to-end sequences

---
