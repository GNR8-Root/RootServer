using System;
using System.Net.NetworkInformation;
using Blazorise;
using Microsoft.AspNetCore.Components;



namespace RootServer.Shared._Editor
{
	public abstract partial class BasePanel
    {
        [Parameter]
        public string PanelName { get; set; } = "pnlName";

        public string SelectedTab { get; set; } = "tabLbl";



        protected virtual void ServiceReceived()
        {
            StateHasChanged();
        }



        protected override async Task OnInitializedAsync()
        {
            pointer_Service.ServiceAction += ServiceReceived;

            await base.OnInitializedAsync();
            await Task.CompletedTask;
        }



        public void Dispose()
        {
            pointer_Service.ServiceAction -= ServiceReceived;
        }
    }
}