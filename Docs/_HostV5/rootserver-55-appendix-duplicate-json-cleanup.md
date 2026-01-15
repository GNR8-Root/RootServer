# Duplicate JSON Cleanup

---

## The Duplicate JSON Problem

### Affected Files
- `gallery.json` vs `galleryJson.json`
- `text.json` vs `textJson.json`

### Root Cause
Likely dual export pipelines or transition compatibility during development.

---

## Impact

### Confusion
Developers unsure which file is canonical.

### Maintenance
Must keep both files in sync manually.

### Risk of Drift
Changes to one file might not reflect in the other.

---

## Cleanup Plan

### Step 1: Identify Canonical Files
Decision: Use simple `*.json` format (`gallery.json`, `text.json`)

### Step 2: Update Code References
```csharp
// Find all references
grep -r "galleryJson" .
grep -r "textJson" .

// Update to canonical names
// gallery.json
// text.json
```

### Step 3: Remove Duplicates
```bash
rm Json/galleryJson.json
rm Json/textJson.json
```

### Step 4: Add CI Check
```yaml
# Add to CI pipeline
- name: Check for duplicate JSON files
  run: |
    if [ -f Json/*Json.json ]; then
      echo "Error: Duplicate JSON files found"
      exit 1
    fi
```

---

## Timeline
- Week 1: Code reference audit
- Week 2: Update all references
- Week 3: Remove duplicate files
- Week 4: Deploy CI check

---

---

**Navigation**

- **[← Source Mapping](rootserver-54-appendix-source-to-docs-mapping.md)**
- **[ADRs →](rootserver-56-appendix-adrs.md)**
- **[Home](rootserver.md)**

---
