# UI Interactions

---

## Principle

Every interaction in the UI maps to an explicit orchestrator action.
The UI does not “guess” the next phase or decide validity.

---

## Start Run

### User Action
Click “Start Run” in the Run Wizard.

### UI Behavior
- validate required files are selected
- POST to create run
- navigate to run dashboard

### Orchestrator Behavior
- stores input artifacts
- runs Preflight
- emits run events

---

## Approve & Continue (Interactive Mode)

### User Action
Click “Approve & Continue” when the run is awaiting approval.

### UI Behavior
- call approval endpoint
- disable the button until response
- update timeline on events

### Orchestrator Behavior
- records approval (who + when)
- advances to next phase
- emits approval recorded event and next phase started event

---

## Cancel Run

### User Action
Click “Cancel Run”.

### UI Behavior
- confirm intent (inline prompt or modal)
- call cancel endpoint
- lock UI controls afterward

### Orchestrator Behavior
- stops execution loop
- emits run canceled event
- preserves artifacts produced so far

---

## View Validation Report

### User Action
Click a report link on the timeline.

### UI Behavior
- navigate to report viewer route
- fetch report Markdown artifact
- fetch structured issue list for the phase

---

## Download Bundle

### User Action
Click “Download bundle” on a completed run.

### UI Behavior
- request download
- show file name and size

### Orchestrator Behavior
- ensures final validation passed
- returns bundle artifact

---

## Regenerate Phase (Explicit)

Regeneration must be explicit; if supported in the UI:

### User Action
Click “Regenerate Phase 3” (only available when failed or explicitly enabled).

### UI Behavior
- show explanation: regeneration creates a new execution version
- call orchestrator regenerate endpoint (if implemented)

### Orchestrator Behavior
- creates a new phase execution version
- regenerates targeted files only
- reruns gate validation
- emits events and returns to awaiting approval (interactive)

---

---

[← DocsGen](docsgen.md)
1. **[Base](docsgen-00-base-index.md)** – conceptual foundations, terminology, and canonical schemas
2. **[Architecture](docsgen-12-arch-index.md)** – orchestration, agents, validators, storage, and hosting boundaries
3. **[UI](docsgen-26-ui-index.md)** – user workflows, screens, components, and interaction rules
4. **[Appendix](docsgen-39-appendix-index.md)** – folder mapping, task references, and implementation checklist
5. **[Diagrams](docsgen-43-diagrams.md)** – architecture, state machines, and end-to-end sequences

---
