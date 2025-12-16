# Component Library

---

## 1) Run Wizard Components

### RunWizard (Page / View)
**Purpose**: Collect inputs and configuration to create a run.

**Sections**
- Plugin requirements upload
- Host project reference upload
- Example docset upload
- Documentation formula upload
- Mode selection (review mode, strictness)
- Start button

**Primary States**

| State | Visual | Behavior |
|------|--------|----------|
| Empty | guidance text + disabled Start | Start disabled until required inputs present |
| Ready | Start enabled | POST to create run |
| Uploading | progress indicator | prevent duplicate submits |
| Error | error banner | show API error details |

---

### FileDropZone
**Purpose**: Drag/drop + browse upload control.

**Rules**
- Must show accepted file types
- Must show file size and name after selection
- Must support replace/remove

**Suggested UI**
```text
+------------------------------+
| Drop file here or Browse     |
| - shows file name + size     |
| - Replace / Remove actions   |
+------------------------------+
```

---

## 2) Run Dashboard Components

### RunHeader
**Purpose**: Make the run state obvious.

Content:
- run ID
- plugin slug
- status badge
- mode badges
- key actions (download, cancel)

---

### PhaseTimeline
**Purpose**: Visualize phase progression.

**Timeline Row Content**
- phase number + label
- status icon
- report link (if exists)
- issue counts (if failed)

**Phase Row States**

| Phase State | Icon | Meaning |
|------------|------|---------|
| Not Started | circle | phase has not run yet |
| Running | spinner | generation or validation in progress |
| Passed | check | gate passed |
| Awaiting Approval | pause | gate passed but approval required |
| Failed | x | gate failed, run halted |

---

### ApprovalPanel
**Purpose**: Provide safe continuation in interactive mode.

**Content**
- “Awaiting Approval” message
- link to validation report
- “Approve & Continue” button
- approval audit metadata once approved

---

### EventLogPanel (Optional)
**Purpose**: Show ordered run events.

Should support:
- newest-first toggle
- filter by phase
- copy event payload

---

## 3) Validation Components

### ValidationReportViewer
**Purpose**: Render the Markdown report for a phase.

**Rules**
- display report exactly as stored
- do not paraphrase or reword

---

### IssuesTable
**Purpose**: Make structured issues actionable.

Columns:
- severity
- rule ID
- file
- message
- location (line/col)
- open preview action

Filters:
- severity filter
- file filter
- rule filter
- search by message text

---

## 4) Artifact Components

### ArtifactBrowser
**Purpose**: Explore artifacts produced by the run.

Grouping:
- by phase
- by type

Actions:
- preview
- download

---

### MarkdownPreview
**Purpose**: View Markdown artifacts.

**Features**
- renders headings clearly
- supports code block scrolling
- optional table styling

---

### DownloadPanel
**Purpose**: Provide output downloads.

Should support:
- “Download bundle” when complete
- “Download artifacts so far” on failure (optional)
- per-file download

---

---

[← DocsGen](docsgen.md)
1. **[Base](docsgen-00-base-index.md)** – conceptual foundations, terminology, and canonical schemas
2. **[Architecture](docsgen-12-arch-index.md)** – orchestration, agents, validators, storage, and hosting boundaries
3. **[UI](docsgen-26-ui-index.md)** – user workflows, screens, components, and interaction rules
4. **[Appendix](docsgen-39-appendix-index.md)** – folder mapping, task references, and implementation checklist
5. **[Diagrams](docsgen-43-diagrams.md)** – architecture, state machines, and end-to-end sequences

---
