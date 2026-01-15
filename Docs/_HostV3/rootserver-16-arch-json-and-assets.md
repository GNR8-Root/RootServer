# JSON and Assets

---

## JSON Cache System

**Location:** `Json/` folder

**Purpose:**
- Local development without API calls
- Offline capability
- Fast iteration

---

## Duplicate File Issue

**Pattern Discovered:** Many JSON files exist in duplicate with inconsistent naming:

| Canonical | Duplicate | Risk |
|-----------|-----------|------|
| pages.json | pagesJson.json | High |
| tables.json | tablesJson.json | High |
| apps.json | appsJson.json | Medium |
| sections.json | sectionsJson.json | Medium |
| workspaces.json | workspacesJson.json | Medium |
| colors.json | colorsJson.json | Low |
| text.json | textJson.json | Medium |
| gallery.json | galleryJson.json | Low |
| settings.json | settingsJson.json | Medium |

**Impact:**
- Data drift if files diverge
- Maintenance overhead
- Confusion about canonical source
- Potential for stale reads

**Root Cause:** Likely dual export pipelines or naming inconsistency during sync.

---

## Asset Management

**Static Assets:** `wwwroot/`
- css/ - Stylesheets
- js/ - JavaScript files
- gfx/ - Graphics
- lottie/ - Lottie animations
- spline/ - Spline 3D files
- svg/ - SVG graphics
- unity/ - Unity WebGL builds (if any)
- favicon.ico

**No CDN:** All assets served locally.

---

## Remediation Plan

See **[Appendix 42 - Duplicate JSON Cleanup](rootserver-42-appendix-duplicate-json-cleanup.md)** for detailed cleanup plan.

---

[← Back to Architecture Index](rootserver-12-arch-index.md)

---
