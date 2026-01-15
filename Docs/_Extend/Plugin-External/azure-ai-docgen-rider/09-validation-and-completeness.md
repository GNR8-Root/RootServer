# Validation Gates and Completeness

Purpose
- Enforce global rules (no placeholders, link integrity, terminology consistency)
- Ensure coverage of JSON requirements and schema consistency
- Provide a measurable completeness score before proceeding

Validators (deterministic)
- ForbiddenStringScanner: blocks `TODO`, `TBD`, `{...}`-style placeholders
- MarkdownLinkValidator: relative links only, targets exist in planned files, anchors resolve
- TerminologyValidator: terms align with `02-terminology-index.json`
- SchemaValidator: schemas match `plugin-requirements.json`, entities covered
- ErrorMessageExactMatchValidator: UI validation messages match JSON exactly
- CompletenessScorer: ratio of documented requirements to total

Strict vs lenient
- Strict: performance targets, integration failure policies, and audit config are mandatory (errors)
- Lenient: those become warnings; global rules remain non-negotiable

Outputs per phase
- `XX-phaseX-validation.md` with table of issues (file, rule, line, message)
- Structured `ValidationResult` for the orchestrator

Completeness scoring
```text
score = documented_requirements / total_requirements_from_json

Thresholds
- Strict: >= 0.95
- Lenient: >= 0.85
```

Gate protocol
1) Run validators on staged artifacts for the phase
2) Publish `XX-phaseX-validation.md` and structured issues
3) Decide pass/fail based on strictness and thresholds
4) Advance to approval (interactive) or continue (batch)

Related
- [06-orchestration-engine.md](06-orchestration-engine.md)
- [11-artifacts-and-manifest.md](11-artifacts-and-manifest.md)
- [12-phase-execution-pattern.md](12-phase-execution-pattern.md)

---

**Back to index:**
- [root](root.md)
- [foundation](00-foundation-index.md)
- [architecture](10-architecture-index.md)
- [operations](20-operations-index.md)
- [appendix](39-appendix-index.md)

---