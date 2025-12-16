# Deterministic Plane (Tools, Validators, Storage)

---

##  Owns
 - Artifact storage (Blob/local) and manifest
 - Link checking, placeholder scanning, schema checks
 - Terminology index extraction/enforcement
 - Completeness scoring
 - Zip bundling
 
---

##  Core services
 ```csharp
 public interface IArtifactStore
 {
     Task WriteTextAsync(string path, string text, ArtifactMeta meta);
     Task<string> ReadTextAsync(string path);
     Task WriteBinaryAsync(string path, Stream data, ArtifactMeta meta);
     Task<IReadOnlyList<ArtifactIndexEntry>> ListAsync(string prefix);
 }
 
 public interface IValidator
 {
     Task<IReadOnlyList<ValidationIssue>> ValidateAsync(IEnumerable<ArtifactRef> artifacts, Strictness strictness);
 }
 
 public sealed class ForbiddenStringScanner : IValidator { /* scans for braces, TODO, TBD */ }
 public sealed class MarkdownLinkValidator : IValidator { /* relative paths and anchors */ }
 public sealed class TerminologyValidator : IValidator { /* loads 02-terminology-index.json */ }
 public sealed class SchemaValidator : IValidator { /* requirements schema & coverage */ }
 public sealed class CompletenessScorer : IValidator { /* computes ratio */ }
 ```

---
 
##  **Rules**
 - Always enforce placeholder ban and link integrity
 - In lenient mode, downgrade some errors to warnings but never placeholders/links
 
---

 **Related**
 - [09-validation-and-completeness.md](09-validation-and-completeness.md)
 - [11-artifacts-and-manifest.md](11-artifacts-and-manifest.md)

---

**Back to index:**
- [root](root.md)
- [foundation](00-foundation-index.md)
- [architecture](10-architecture-index.md)
- [operations](20-operations-index.md)
- [appendix](39-appendix-index.md)

---
