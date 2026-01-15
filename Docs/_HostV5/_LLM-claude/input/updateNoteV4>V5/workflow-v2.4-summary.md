# Workflow v2.4 Summary

**Enhanced Documentation System with Developer Operations & Standards**

---

## What's New in v2.4

### 1. Expanded Page Count: 45 → 58 Pages

**New Structure:**
- **Total Pages:** 58 (root + 00-57)
- **New DevOps Index:** Page 45
- **New DevOps Layer:** Pages 46-52 (7 pages)
- **Reorganized Appendices:** Pages 40-44, 53-57

---

## New Content Areas

### Developer Operations Layer (Pages 46-52)

**46: Onboarding** (`{doc_slug}-46-devops-onboarding.md`)
- Step-by-step setup guide (< 30 minutes)
- Rider User Secrets configuration
- First run verification
- Common first-day issues

**47: Quick Start** (`{doc_slug}-47-devops-quick-start.md`)
- One-liner commands for common tasks
- Hot reload / watch mode optimization
- Keyboard shortcuts
- Performance tips

**48: Debugging** (`{doc_slug}-48-devops-debugging.md`)
- Rider debugging techniques
- VS Code debugging
- Browser DevTools for Blazor
- SignalR debugging
- Logging strategies

**49: Troubleshooting** (`{doc_slug}-49-devops-troubleshooting.md`)
- Problem → Cause → Solution format
- Build failures
- Runtime errors
- SignalR connection issues
- JSON file errors
- Airtable API errors
- Performance problems

**50: Contribution** (`{doc_slug}-50-devops-contribution.md`)
- CONTRIBUTING.md equivalent
- Code style guidelines
- Commit message format
- Branch naming conventions
- Pull request process
- Code review expectations

**51: Secrets Management** (`{doc_slug}-51-devops-secrets.md`)
- Rider User Secrets (step-by-step with screenshots description)
- .NET User Secrets CLI
- Azure Key Vault for production
- What never to commit
- Secret scanning tools
- Secret rotation

**52: Development Workflow** (`{doc_slug}-52-devops-development-workflow.md`)
- Feature development flow
- Testing before commit
- Local pre-commit checks
- CI/CD pipeline overview
- Deployment process
- Hotfix process

---

### Standards & Policy Layer (Pages 40-42)

**40: Coding Standards** (`{doc_slug}-40-appendix-coding-standards.md`)
- Naming conventions (prefix system)
- File organization rules
- Code structure guidelines
- XML documentation requirements
- EditorConfig settings (actual file contents)

**41: Code Quality Policy** (`{doc_slug}-41-appendix-code-quality-policy.md`)
- Philosophy: **Human review over numeric metrics**
- Why no cyclomatic complexity thresholds
- Roslyn analyzers vs SonarQube decision
- Tool recommendations with ADR
- Consequences and tradeoffs

**42: PR Review Checklist** (`{doc_slug}-42-appendix-pr-review-checklist.md`)
- Readability signals
- Boundary compliance
- Error handling patterns
- Testing coverage
- Refactoring opportunities
- When to request changes vs suggest improvements

---

### Enhanced Appendices (Pages 56-57)

**56: Architecture Decision Records** (`{doc_slug}-56-appendix-adrs.md`)
- ADR template
- ADR index
- Example ADRs:
  - ADR-001: Blazor Server over WebAssembly
  - ADR-002: 00-09 Layer System
  - ADR-003: Service-Based State Management
  - ADR-004: Schema-Driven UI
  - ADR-005: Human Review over Numeric Metrics

**57: Glossary** (`{doc_slug}-57-appendix-glossary.md`)
- Comprehensive alphabetical glossary
- All technical terms with definitions
- Cross-referenced with backtick formatting
- Auto-generated from terminology index + manual additions

---

## Enhanced Formatting Rules

### Technical Term Backtick Formatting

**All technical terms must be in backticks:**

```markdown
✓ Correct:
- `Host` → `_Core`, `_Editor`, `_Sites` (allowed)
- `Plugin` → `Host` services, `_Core` (allowed)
- `Host` → `Plugin` (forbidden)
- The `Pointer_Service` tracks current selection
- Located in `Shared/_Core/00_Core/Events/`
- Uses `Blazor Server` with `SignalR`
- Deserialize `pages.json` file

✗ Incorrect:
- Host → _Core, _Editor, _Sites (allowed)
- The Pointer_Service tracks current selection
- Located in Shared/_Core/00_Core/Events/
- Uses Blazor Server with SignalR
```

**What Gets Backticks:**
- Class names: `ComponentBase`, `FieldBase`, `Pointer_Service`
- Method/property names: `SelectTable()`, `OnSelectionChanged`
- Folder names: `Shared/_Core/`, `02_Fields/`, `Plugins/Airtable/`
- File names: `Program.cs`, `appsettings.json`, `pages.json`
- Technologies: `Blazor Server`, `SignalR`, `.NET 8`, `Airtable API`
- Patterns: `dependency injection`, `service-based state`
- Components: `F_Text_Email`, `P_Table`, `C_TableAir`

**Exceptions:**
- Inside code blocks (already formatted)
- Common words like "page", "folder" unless part of specific name

---

## Secrets Management (Your Specific Need)

### Rider Project Settings Approach

**Where Secrets Are Stored:**
- Rider stores User Secrets in user profile directory (not in project)
- Location: `%APPDATA%\Microsoft\UserSecrets\{user-secrets-id}\secrets.json`
- **Never committed to git** (outside project folder)

**How to Configure in Rider:**

1. Right-click project → **Tools** → **Manage User Secrets**
2. Rider opens `secrets.json` in editor
3. Add JSON configuration:
   ```json
   {
     "Airtable": {
       "ApiKey": "keyXXXXXXXXXXXXXX",
       "BaseId": "appXXXXXXXXXXXXXX"
     }
   }
   ```
4. Save and close
5. Access in code via `IConfiguration`:
   ```csharp
   var apiKey = builder.Configuration["Airtable:ApiKey"];
   ```

**Alternative CLI Approach:**
```bash
dotnet user-secrets init
dotnet user-secrets set "Airtable:ApiKey" "keyXXX..."
dotnet user-secrets set "Airtable:BaseId" "appXXX..."
```

**Documentation Page:** Page 51 will have step-by-step guide with screenshots description

---

## Code Quality: Human Review over Metrics

### Philosophy

**Why no numeric thresholds?**

Traditional metrics have problems:
- **Cyclomatic complexity:** Encourages artificial extraction; misses real complexity
- **Lines per method:** Can be gamed; doesn't measure clarity
- **Code coverage %:** High coverage ≠ good tests

**Instead, focus on:**
- **Readability:** Can a new developer understand this?
- **Maintainability:** Can this be changed safely?
- **Testability:** Can this be tested easily?
- **Boundaries:** Does this respect architecture?

### PR Review Checklist (Page 42)

**Readability Signals:**
- [ ] Names clearly express intent
- [ ] Single responsibility principle
- [ ] Complex logic has explanatory comments
- [ ] No magic numbers/strings

**Refactoring Signals:**
- Method too long? → Extract smaller methods
- Too many parameters? → Parameter object
- Deeply nested conditions? → Guard clauses
- Repeated code? → Shared method

### Tools (Page 41)

**Baseline (Required):**
- Roslyn analyzers (built-in)
- EditorConfig (formatting consistency)

**Optional (Team Choice):**
- SonarQube (deeper analysis)
- NDepend (architecture enforcement)

**ADR:** Document why baseline approach chosen over heavy tooling

---

## Page Reorganization

### Old Structure (v2.3)
```
00-44: Base, Arch, UI, Appendix (improvements), Diagrams
Appendices: 40-42 (risks, mapping, JSON cleanup)
```

### New Structure (v2.4)
```
00-11: Base Layer
12-25: Architecture Layer
26-38: UI Layer
39: Appendix Index
40-44: Standards & Policy + Diagrams + Improvements
45: DevOps Index
46-52: Developer Operations
53-57: Final Appendices (risks, mapping, JSON, ADRs, glossary)
```

**Rationale:**
- Standards/policy near front (developers need early)
- DevOps layer separate from appendices (not supplementary, essential)
- ADRs and glossary at end (reference material)

---

## File Plan Summary

| Range | Content | Count |
|-------|---------|-------|
| Root | Entry point | 1 |
| 00, 12, 26, 39, 45 | Indices | 5 |
| 01-11 | Base Layer | 11 |
| 13-25 | Architecture Layer | 13 |
| 27-38 | UI Layer | 12 |
| 40-44 | Standards + Diagrams + Improvements | 5 |
| 46-52 | Developer Operations | 7 |
| 53-57 | Final Appendices | 5 |
| **Total** | | **58** |

---

## New Validation Requirements

### Technical Term Formatting Validation
- All class names in backticks: ✓/✗
- All folder/file names in backticks: ✓/✗
- All technologies in backticks: ✓/✗
- Consistency across pages: ✓/✗

### DevOps Pages Validation
- All 7 pages exist: ✓/✗
- Onboarding has time estimate: ✓/✗
- Quick-start has runnable commands: ✓/✗
- Secrets page has Rider instructions: ✓/✗

### ADR Validation
- ADR page exists: ✓/✗
- At least 3 ADRs present: ✓/✗
- ADRs follow template: ✓/✗
- Code quality ADR exists: ✓/✗

---

## New Artifacts

### Generated Files
- `08-technical-terms-index.json` — tracks all terms for backtick formatting
- Enhanced `02-terminology-index.json` — includes term types
- `05-final-validation-report.md` — includes new validators

### Per-Page Artifacts
- Each DevOps page includes practical, runnable examples
- Each standard page includes rationale and ADR references
- Glossary auto-generates from terminology + technical terms indices

---

## Implementation Priority

If regenerating incrementally:

**Phase 1 (High Value):**
1. Page 51 (Secrets) — critical for local dev
2. Page 46 (Onboarding) — critical for new developers
3. Page 47 (Quick Start) — high usage
4. Pages 40-42 (Standards/Policy/Checklist) — sets expectations

**Phase 2 (Medium Value):**
5. Page 48 (Debugging)
6. Page 49 (Troubleshooting)
7. Page 50 (Contribution)
8. Page 52 (Workflow)

**Phase 3 (Reference):**
9. Page 56 (ADRs)
10. Page 57 (Glossary)
11. Apply backtick formatting to all existing pages

---

## Migration from v2.3 to v2.4

**Structural Changes:**
- Renumber old appendices 40-42 → 53-55 (risks, mapping, JSON)
- Old page 44 (improvements) stays at 44
- Insert new pages 40-42, 45-52, 56-57
- Update all internal links

**Content Changes:**
- Add backticks to all technical terms across all pages
- Update dependency diagrams with backtick formatting
- Add devops index navigation

**Validation:**
- Run technical term validator
- Verify all 58 pages present
- Check all navigation links updated

---

## Questions Answered

### Q: How do secrets work?
**A:** Rider User Secrets (page 51)
- Stored in user profile (not project)
- Configured via right-click → Manage User Secrets
- Accessed via `IConfiguration` in code

### Q: What about code quality metrics?
**A:** Human review over metrics (pages 41-42)
- Rationale documented in ADR
- Roslyn + EditorConfig baseline
- PR checklist focuses on readability/maintainability

### Q: How to onboard new developers?
**A:** Page 46 with < 30 min setup
- Prerequisites, clone, build, secrets, run
- Common issues with solutions

### Q: Where are the ADRs?
**A:** Page 56 with at least 5 examples
- Including ADR on code quality tooling choice

---

## Workflow JSON Location

**File:** `workflow-v2.4.json`
**Lines:** 711
**Key Sections:**
- `changelog_from_2_3` — what changed
- `technical_term_formatting` — backtick rules
- `code_quality_policy` — human review philosophy
- `secrets_management` — Rider + CLI approaches
- `architecture_decision_records` — ADR system
- `file_plan` — 58-page structure
- `page_content_contracts` — requirements per page

---

**Ready to generate RootServer v2.4 documentation with developer operations and standards!**
