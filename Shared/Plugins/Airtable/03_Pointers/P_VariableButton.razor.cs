using System;
using System.Net.NetworkInformation;
using Blazorise;
using Microsoft.AspNetCore.Components;



namespace RootServer.Shared.Airtable
{
	public partial class P_VariableButton
    {
        public override async Task OnInvoke()
        {
            LogDescription = "variable is selected";
            await base.OnInvoke();
        }
    }
}