using System;
using System.Net.NetworkInformation;
using Blazorise;
using Microsoft.AspNetCore.Components;



namespace RootServer.Shared.Airtable
{
	public partial class P_Workspace
    {
        public override async Task OnInvoke()
        {
            LogDescription = "workspace is selected";
            await base.OnInvoke();
        }
    }
}