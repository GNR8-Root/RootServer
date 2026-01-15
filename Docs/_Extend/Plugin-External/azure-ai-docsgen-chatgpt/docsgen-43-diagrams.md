---

# Diagrams & Flows

This file contains diagrams for the DocsGen system.

---

## 1) Four-Plane System (Boundaries)

```text
+--------------------------------------------------------------+
| Experience Plane (Blazor UI)                                 |
| - uploads, configuration, progress, approvals, downloads      |
+------------------------------+-------------------------------+
                               |
                               | REST + SignalR/SSE
                               v
+--------------------------------------------------------------+
| Control Plane (Orchestrator API)                              |
| - state machine (phases 0–5)                                  |
| - artifact registry + immutability                            |
| - gate execution + stop-on-fail                               |
| - run events                                                   |
+------------------------------+-------------------------------+
                               |
                               | bounded agent calls
                               v
+--------------------------------------------------------------+
| Intelligence Plane (Foundry Agents)                            |
| - generate Markdown drafts                                     |
| - optional narrative summaries                                 |
+------------------------------+-------------------------------+
                               |
                               | tool calls (optional)
                               v
+--------------------------------------------------------------+
| Deterministic Plane (Tools + Validators + Storage)             |
| - artifact persistence                                         |
| - link checking, placeholder scanning                          |
| - terminology enforcement, schema checks                       |
| - completeness scoring, bundling                               |
+--------------------------------------------------------------+
```

---

## 2) Orchestrator State Machine (Run Status)

```text
                 +------------------+
                 |      Running     |
                 +--------+---------+
                          |
                          | gate pass
                          v
                 +------------------+
                 | AwaitingApproval |  (interactive only)
                 +--------+---------+
                          |
                          | approval
                          v
                 +------------------+
                 |      Running     |
                 +------------------+

Gate fail at any time:
    Running -> Failed

Cancel at any time:
    Running/AwaitingApproval -> Canceled

Final pass:
    Running -> Complete
```

---

## 3) Phase Progression (0–5)

```text
Phase 0  Preflight (blocking)
  |
  v
Phase 1  Foundation (root + indices + planned files)
  |
  v
Phase 2  Base Layer (concepts + models + schema)
  |
  v
Phase 3  Architecture Layer (implementation + integration)
  |
  v
Phase 4  UI + Appendix (workflows + mapping)
  |
  v
Phase 5  Diagrams + Cross-Validation + Bundle
```

---

## 4) Sequence – Interactive Strict Run

```text
User                UI                Orchestrator             Validators         Agents
 |                  |                      |                        |               |
 | Upload inputs    |                      |                        |               |
 |----------------->| POST /api/runs       |                        |               |
 |                  |--------------------->| create run             |               |
 |                  |                      | preflight checks       |               |
 |                  |                      |----------------------->| run preflight |
 |                  |                      |<-----------------------| pass/fail     |
 |                  |  events              |                        |               |
 |                  |<---------------------| phase.started(1)        |               |
 |                  |                      | generate Phase 1 files  |               |
 |                  |                      |--------------------------------------->|
 |                  |                      |<---------------------------------------|
 |                  |                      | run gate validators     |               |
 |                  |                      |----------------------->| validate      |
 |                  |                      |<-----------------------| pass          |
 |                  |<---------------------| approval.required       |               |
 | Approve          | POST approve         |                        |               |
 |----------------->|--------------------->| record approval         |               |
 |                  |<---------------------| phase.started(2)        |               |
 |                  |                      | ... repeat ...          |               |
 |                  |                      | final validation + zip  |               |
 |                  |<---------------------| run.completed           |               |
 | Download bundle  | GET download         |                        |               |
 |----------------->|--------------------->| return zip              |               |
```

---

## 5) Sequence – Gate Failure and Stop-on-Fail

```text
Orchestrator              Validators
     |                        |
     | run gate validation    |
     |----------------------->|
     |<-----------------------| fail (errors)
     |
     | write issues report
     | set run status = Failed
     | emit validation.failed event
     v
UI shows failure banner + issues table
(no further phases run)
```

---

## 6) Sequence – Partial Regeneration (Explicit)

```text
User/UI                    Orchestrator                    Agents                Validators
  |                            |                            |                      |
  | Click "Regenerate Phase 3" |                            |                      |
  |--------------------------->| create phase3_v2 execution  |                      |
  |                            | generate targeted files     |                      |
  |                            |---------------------------> |                      |
  |                            |<--------------------------- |                      |
  |                            | run Phase 3 validators      |--------------------->|
  |                            |                             |<---------------------|
  |                            | if pass -> awaiting approval / continue             |
```

---

## 7) Artifact Path Layout

```text
run_2025_12_14_0001/
├── input/
│   ├── plugin-requirements.json
│   └── host-project.zip
├── phase1/
│   ├── docsgen.md
│   ├── docsgen-00-base-index.md
│   ├── docsgen-12-arch-index.md
│   ├── docsgen-26-ui-index.md
│   ├── docsgen-39-appendix-index.md
│   └── 01-planned-files.json
├── phase2/
│   ├── docsgen-01-base-vision.md
│   ├── ...
│   └── 02-terminology-index.json
├── phase3/
│   └── docsgen-13-arch.md ... docsgen-25-arch-resources.md
├── phase4/
│   └── docsgen-27-ui-spec.md ... docsgen-42-appendix-task-reference.md
├── phase5/
│   ├── docsgen-43-diagrams.md
│   ├── 05-final-validation.md
│   └── docsgen-documentation-bundle.zip
```

---

## 8) Validator Pipeline (Conceptual)

```text
Artifacts Produced
   |
   v
Placeholder Scan  -----> Issues (structured)
   |
   v
Link Validation   -----> Issues (structured)
   |
   v
Terminology Check -----> Issues (structured)
   |
   v
Schema Consistency ----> Issues (structured)
   |
   v
Completeness Score ----> Score + threshold decision
   |
   v
Gate Pass/Fail
```

---

## 9) RootServer Plugin Placement (Suggested)

```text
RootServer/
├── Shared/
│   ├── _Editor/
│   └── Plugins/
│       ├── Airtable/
│       └── DocsGen/
│           ├── 00_Core/
│           ├── 01_Displays/
│           ├── 02_Fields/
│           ├── 03_Pointers/
│           ├── 04_Actions/
│           ├── 06_Components/
│           ├── 07_Widgets/
│           └── 08_View/
└── Docs/
    └── Extend/
        └── Module-Internal/
            └── DocsGen/
                └── (43 markdown files)
```

---

[← DocsGen](docsgen.md)
1. **[Base](docsgen-00-base-index.md)** – conceptual foundations, terminology, and canonical schemas
2. **[Architecture](docsgen-12-arch-index.md)** – orchestration, agents, validators, storage, and hosting boundaries
3. **[UI](docsgen-26-ui-index.md)** – user workflows, screens, components, and interaction rules
4. **[Appendix](docsgen-39-appendix-index.md)** – folder mapping, task references, and implementation checklist
5. **Diagrams** – architecture, state machines, and end-to-end sequences

---
