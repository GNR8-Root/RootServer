using System;
using System.Net.NetworkInformation;
using Blazorise;
using Microsoft.AspNetCore.Components;



namespace RootServer.Shared.Airtable
{
	public partial class A_RowNew
    {
        public async Task OnInvoke()
        {
            logCatcher_Service.CatchLog("NEW", "row is added", Color.Success);
            await Task.CompletedTask;
        }
    }
}