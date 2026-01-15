 # Experience Plane (Blazor UI)
 
---

 ## **Owns**
 - Upload inputs: requirements JSON, host zip/tree, reference docset zip, documentation formula
 - Configure review_mode and validation_strictness
 - Start runs, show phase progress and validation reports
 - Collect approvals at interactive gates, download final bundle

---

## **Does Not Own**
 - No direct LLM calls
 - No generation or validation logic

---

##  **Pages**
 - New Run Wizard: input upload, config selection
 - Run Dashboard: phase timeline, status, approve/continue, download artifacts
 - Validation Report Viewer: render `XX-phaseX-validation.md` and structured issues
 - Artifact Browser: list and preview generated docs

---

## **Example:** Razor snippet to approve a run
 ```razor
 <Button Color="Color.Success" Disabled="@(!CanApprove)" @onclick="ApproveAsync">Approve & Continue</Button>
 
 @code {
     [Parameter] public string RunId { get; set; } = string.Empty;
     bool CanApprove => Status?.Gate == "AwaitingApproval";
     RunStatusDto? Status { get; set; }
 
     async Task ApproveAsync()
     {
         await Http.PostAsync($"/api/runs/{RunId}/approve", null);
         Status = await Http.GetFromJsonAsync<RunStatusDto>($"/api/runs/{RunId}");
     }
 }
 ```
 
 SignalR/SSE for live updates
 ```csharp
 // C#: subscribe to run events
 hubConnection.On<RunEvent>("RunEvent", evt =>
 {
     if (evt.RunId == currentRunId)
     {
         StateHasChanged();
     }
 });
 ```
 
 **Related**
 - [02-control-plane.md](02-control-plane.md)
 - [13-ui-review-experience.md](13-ui-review-experience.md)

---

**Back to index:**
- [root](root.md)
- [foundation](00-foundation-index.md)
- [architecture](10-architecture-index.md)
- [operations](20-operations-index.md)
- [appendix](39-appendix-index.md)

---