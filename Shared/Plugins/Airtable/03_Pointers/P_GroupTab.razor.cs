using System;
using System.Net.NetworkInformation;
using Blazorise;
using Microsoft.AspNetCore.Components;



namespace RootServer.Shared.Airtable
{
	public partial class P_GroupTab
    {
        public override async Task OnInvoke()
        {
            LogDescription = "group is selected";
            await base.OnInvoke();
        }
    }
}