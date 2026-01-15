-No formal architecture decision records (ADRs)

-No code quality metrics (cyclomatic complexity, etc.) {
A policy page: what you mean by “no code quality metrics,” scope (C#/JS), and why.

An ADR: decision + alternatives (Sonar/NDepend/ESLint complexity rules) + consequences.

A PR review checklist that replaces metrics with human-review signals:

readability, naming, boundaries, error handling

tests for tricky logic

“extract method / simplify flow” guidance (but not a numeric threshold)
}

-coding standards document

-Secrets management{ what you need, as the secrets will be in rider project settings so hidden for users}

-API documentation (OpenAPI)

-developer onboarding guide

-troubleshooting guide

-contribution guidelines

-developer  quick-start guide

-developer debugging tips or common issues guide

-developer feedback loops (watch mode optimizations documented)
