 # Appendix A6 — CI/CD Automation for DocGen

---

##  Purpose
 - Provide pipeline patterns to run DocGen in batch, publish artifacts, and promote approved bundles.
 
##  Scenarios
 - Nightly batch generation with lenient strictness for preview bundles.
 - On-demand run for a specific plugin/profile.
 - Promotion to “golden” after manual approval.
 
---

##  Pipeline outline (GitHub Actions sketch)
 ```yaml
 name: docgen
 on:
   workflow_dispatch:
     inputs:
       profile:
         description: Docset profile (Full43Strict|Lenient42|Minimal13)
         default: Full43Strict
       review_mode:
         description: interactive or batch
         default: batch
 jobs:
   run:
     runs-on: ubuntu-latest
     steps:
       - uses: actions/checkout@v4
       - name: Setup .NET
         uses: actions/setup-dotnet@v4
         with:
           dotnet-version: '10.0.x'
       - name: Build orchestrator
         run: dotnet build RootServer.sln -c Release
       - name: Run DocGen (batch)
         run: |
           dotnet run --project src/DocsGen.Api \
             -- review_mode=${{ inputs.review_mode }} \
             -- strictness=strict \
             -- profile=${{ inputs.profile }}
       - name: Upload bundle artifact
         uses: actions/upload-artifact@v4
         with:
           name: docset-bundle
           path: Docs/Extend/Plugin-External/docgen/artifacts/**/*-documentation-bundle.zip
 ```

---
 
##  Promotion step (manual)
 - Require human approval to promote the bundle to `releases/` and update an index page.
 - Verify signature/hash before publishing.
 
---

##  Compliance checks
 - Run validators again on the bundle prior to release.
 - Ensure no external links and no placeholders across all 43 files (or selected profile).
 
---

##  Environment variables
 - Tool API base URL, auth audience/tenant, storage connection (or managed identity).
 - Foundry project identifiers for the generator/reporters.
 
---

##  Tips
 - Keep runs idempotent: new runId per execution; do not overwrite previous runs.
 - Store validation reports alongside bundles for audit.
 
---

 **Related**
 - [39-appendix-index.md](39-appendix-index.md)
 - [12-phase-execution-pattern.md](12-phase-execution-pattern.md)
 - [11-artifacts-and-manifest.md](11-artifacts-and-manifest.md)

---

**Back to index:**
- [root](root.md)
- [foundation](00-foundation-index.md)
- [architecture](10-architecture-index.md)
- [operations](20-operations-index.md)
- [appendix](39-appendix-index.md)

---
