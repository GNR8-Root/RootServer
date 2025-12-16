 # UI Review Experience
 
 Timeline
 - Preflight -> Foundation -> Base -> Architecture -> UI/Appendix -> Diagrams
 
 Actions
 - Approve & Continue (interactive mode)
 - Download artifacts so far (even on failure)
 - Filter issues by file/rule
 
 Components
 - Run Timeline: shows current phase, gate status, and links to artifacts
 - Validation Report Viewer: renders `XX-phaseX-validation.md` with issue table
 - Artifact Browser: lists files by classification (CoreDoc, Artifact, Report)
 
 Razor: Validation issues table
 ```razor
 <Table>
   <thead>
     <tr><th>File</th><th>Rule</th><th>Message</th><th>Line</th></tr>
   </thead>
   <tbody>
   @foreach (var issue in Issues)
   {
     <tr>
       <td>@issue.File</td>
       <td>@issue.Rule</td>
       <td>@issue.Message</td>
       <td>@issue.Line</td>
     </tr>
   }
   </tbody>
 </Table>
 ```
 
 API integration
 - `GET /api/runs/{runId}` — status and current gate
 - `GET /api/runs/{runId}/artifacts?phase=X` — list artifacts for a phase
 - `GET /api/runs/{runId}/artifact?path=...` — fetch file content for preview
 
 Accessibility
 - Announce phase transitions via ARIA live regions
 - Ensure keyboard navigation for approvals and downloads
 
 Related
 - [01-experience-plane.md](01-experience-plane.md)

---

**Back to index:**
- [root](root.md)
- [foundation](00-foundation-index.md)
- [architecture](10-architecture-index.md)
- [operations](20-operations-index.md)
- [appendix](39-appendix-index.md)

---