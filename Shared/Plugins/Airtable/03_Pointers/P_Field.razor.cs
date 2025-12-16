using System;
using System.Net.NetworkInformation;
using Blazorise;
using Microsoft.AspNetCore.Components;



namespace RootServer.Shared.Airtable
{
	public partial class P_Field
    {
        [Parameter]
        public string Id { get; set; } = "logID";

        [Parameter]
        public Color ColorSelector { get; set; } = Color.Light;



        public override async Task OnInvoke()
        {
            LogDescription = "field is selected";
            await base.OnInvoke();
        }
    }
}