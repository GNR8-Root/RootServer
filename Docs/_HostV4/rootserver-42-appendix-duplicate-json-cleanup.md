# Duplicate JSON Cleanup

---

## Problem Statement

The `Json/` folder contains duplicate files with inconsistent naming:

| Canonical (Recommended) | Duplicate | Size Impact |
|-------------------------|-----------|-------------|
| pages.json | pagesJson.json | 3.5KB each |
| tables.json | tablesJson.json | 4KB each |
| apps.json | appsJson.json | 1KB each |
| sections.json | sectionsJson.json | 2.5KB each |
| workspaces.json | workspacesJson.json | 1KB each |
| colors.json | colorsJson.json | Varies |
| text.json | textJson.json | 5KB each |
| gallery.json | galleryJson.json | 1KB each |
| settings.json | settingsJson.json | 2.5KB each |

**Total Redundancy:** ~45KB+ of duplicate data

## Impact Assessment

### Data Drift Risk
If files diverge, application behavior becomes unpredictable. Which file is source of truth?

### Maintenance Burden
Updates must be made to both files or risk inconsistency.

### Developer Confusion
Newcomers don't know which file to modify.

## Root Cause Hypothesis

1. **Dual Export Pipeline:** Two sync mechanisms writing with different naming conventions
2. **Legacy Compatibility:** Old code reads camelCase, new code reads lowercase
3. **Manual Duplication:** Developer copied files during transition

## Cleanup Plan

### Phase 1: Analysis (Day 1)
1. Search codebase for file references: `grep -r "pagesJson.json" .`
2. Identify which files are actively read
3. Document findings

### Phase 2: Consolidation (Day 2-3)
1. Choose canonical names (recommendation: `lowercase.json`)
2. Update all code references to canonical names
3. Test thoroughly in development
4. Backup duplicate files before deletion

### Phase 3: Deletion (Day 4)
1. Delete duplicate `*Json.json` files
2. Verify application still functions
3. Commit changes

### Phase 4: Prevention (Day 5)
1. Add CI check: `find Json/ -name "*Json.json" | wc -l` should = 0
2. Document naming convention in CONTRIBUTING.md
3. Add file naming linter to pre-commit hook

## Recommended Canonical Names

Use **lowercase.json** pattern:
- pages.json ✓
- tables.json ✓
- apps.json ✓
- sections.json ✓
- workspaces.json ✓
- colors.json ✓
- text.json ✓
- gallery.json ✓
- settings.json ✓

Delete **camelCaseJson.json** variants.

## Checksum Verification

Before deletion, verify files are identical:

```bash
md5sum pages.json
md5sum pagesJson.json
# If hashes match, files are identical
```

If hashes differ, manual merge required.

## Rollback Plan

If issues arise post-cleanup:

1. Restore from backup: `cp backup/pagesJson.json Json/`
2. Revert code changes
3. Re-analyze file usage patterns

[← Back to Appendix Index](rootserver-39-appendix-index.md)

---
