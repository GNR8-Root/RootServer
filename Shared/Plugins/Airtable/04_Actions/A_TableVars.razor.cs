using System;
using System.Net.NetworkInformation;
using Blazorise;
using Microsoft.AspNetCore.Components;



namespace RootServer.Shared.Airtable
{
	public partial class A_TableVars
    {
        [Parameter]
        public string Id { get; set; } = "logID";



        public async Task OnInvoke()
        {
            logCatcher_Service.CatchLog(Id, "table vars generated");
            await Task.CompletedTask;
        }
    }
}