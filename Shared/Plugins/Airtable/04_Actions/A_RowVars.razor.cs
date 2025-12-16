using System;
using System.Net.NetworkInformation;
using Blazorise;
using Microsoft.AspNetCore.Components;



namespace RootServer.Shared.Airtable
{
	public partial class A_RowVars
    {
        [Parameter]
        public string Id { get; set; } = "logID";



        public async Task OnInvoke()
        {
            logCatcher_Service.CatchLog(Id, "row vars generated");
            await Task.CompletedTask;
        }
    }
}