using System;
using System.Net.NetworkInformation;
using Blazorise;
using Microsoft.AspNetCore.Components;



namespace RootServer.Shared._Editor
{
	public partial class HelpPointers
    {
        protected override async Task OnInitializedAsync()
        {
            pointerS.ServiceAction += StateHasChanged;
            await Task.CompletedTask;
        }



        public void Dispose()
        {
            pointerS.ServiceAction -= StateHasChanged;
        }
    }
}