 # Profiles and Strictness
 
 Profiles
 - Full43Strict — all phases, all 43 core files, strict gates
 - Lenient42 — diagrams optional, lower completeness threshold (85%)
 - Minimal13 — foundation + essentials for early ideation
 
 Strictness
 - Strict: enforce performance targets, integration failure policies, and audit config
 - Lenient: warn on the above; never relax placeholder/link/terminology rules
 
 Configuration
 ```json
 {
   "review_mode": "interactive",
   "validation_strictness": "strict",
   "profile": "Full43Strict"
 }
 ```
 
 Enforcement points
 - Orchestrator: decides which phases/files are required per profile
 - Validators: toggle blocking vs warning semantics per strictness
 
 Related
 - [09-validation-and-completeness.md](09-validation-and-completeness.md)
 - [12-phase-execution-pattern.md](12-phase-execution-pattern.md)

---

**Back to index:**
- [root](root.md)
- [foundation](00-foundation-index.md)
- [architecture](10-architecture-index.md)
- [operations](20-operations-index.md)
- [appendix](39-appendix-index.md)

---