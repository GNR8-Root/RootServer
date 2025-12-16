 # Tool Surface (OpenAPI)
 
 Foundry agent tool API (excerpt)
 ```yaml
 openapi: 3.0.3
 info:
   title: DocGen Tool API
   version: 1.0.0
 paths:
   /api/tool/artifacts:
     get:
       operationId: ListArtifacts
       responses: { '200': { description: OK } }
   /api/tool/artifacts/text:
     post:
       operationId: WriteArtifactText
       requestBody: { required: true, content: { application/json: { schema: { type: object } } } }
       responses: { '200': { description: OK } }
   /api/tool/artifacts/binary:
     post:
       operationId: WriteArtifactBinary
       requestBody: { required: true, content: { application/octet-stream: { schema: { type: string, format: binary } } } }
       responses: { '200': { description: OK } }
   /api/tool/planned-files:
     get:
       operationId: GetPlannedFiles
       responses: { '200': { description: OK } }
     post:
       operationId: SetPlannedFiles
       responses: { '200': { description: OK } }
   /api/tool/validate/links:
     post:
       operationId: ValidateLinks
       responses: { '200': { description: OK } }
   /api/tool/validate/placeholders:
     post:
       operationId: ValidateNoPlaceholders
       responses: { '200': { description: OK } }
 ```
 
 Notes
 - Provide operationId for each path; Foundry requires it
 - Prefer managed identity auth in production
 
 Related
 - [04-deterministic-plane.md](04-deterministic-plane.md)

---

**Back to index:**
- [root](root.md)
- [foundation](00-foundation-index.md)
- [architecture](10-architecture-index.md)
- [operations](20-operations-index.md)
- [appendix](39-appendix-index.md)

---
