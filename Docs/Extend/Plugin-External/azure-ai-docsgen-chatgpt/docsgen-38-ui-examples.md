# 🧪 Examples (Concrete UI Scenarios)

---

## Example A – Starting a Run

1. User opens `New Run`
2. Uploads plugin requirements JSON, host zip, example docset zip, and documentation formula
3. Selects:
   - Review mode: interactive
   - Strictness: strict
4. Clicks “Start Run”
5. UI navigates to run dashboard and shows Phase 0 running

---

## Example B – Approval Gate

1. Phase 1 completes and passes validation
2. Timeline shows Phase 1: “Awaiting Approval”
3. Approval panel shows:
   - link to `01-phase1-validation.md`
   - “Approve & Continue”
4. User clicks approve
5. Timeline updates to Phase 2 running

---

## Example C – Gate Failure

1. Phase 3 fails validation
2. UI shows failure banner:
   - “Phase 3 gate failed: 2 broken links”
3. Timeline marks Phase 3 as failed
4. Clicking the report opens issues viewer
5. Issues table shows rows with:
   - file
   - rule ID
   - message
   - line number
6. User downloads “artifacts so far” and fixes the file externally

---

## Example D – Download Final Bundle

1. Phase 5 completes and passes final validation
2. Run status becomes Complete
3. Download panel shows “Download bundle”
4. User downloads a zip containing exactly 43 Markdown files

---

## Example E – Regenerate a Failed Phase (Explicit)

1. Phase 4 fails due to a UI validation mismatch
2. User clicks “Regenerate Phase 4” (explicit action)
3. UI shows a warning:
   - regeneration creates a new phase execution version
4. Orchestrator regenerates only Phase 4 files
5. Gate runs again and the UI returns to awaiting approval

---

---

[← DocsGen](docsgen.md)
1. **[Base](docsgen-00-base-index.md)** – conceptual foundations, terminology, and canonical schemas
2. **[Architecture](docsgen-12-arch-index.md)** – orchestration, agents, validators, storage, and hosting boundaries
3. **[UI](docsgen-26-ui-index.md)** – user workflows, screens, components, and interaction rules
4. **[Appendix](docsgen-39-appendix-index.md)** – folder mapping, task references, and implementation checklist
5. **[Diagrams](docsgen-43-diagrams.md)** – architecture, state machines, and end-to-end sequences

---
