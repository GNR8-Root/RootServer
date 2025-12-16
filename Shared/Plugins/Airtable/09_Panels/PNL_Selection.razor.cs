using System;
using System.Net.NetworkInformation;
using Blazorise;
using Microsoft.AspNetCore.Components;



namespace RootServer.Shared.Airtable
{
	public partial class PNL_Selection
    {
        public PNL_Selection()
        {
            SelectedTab = "variables";
            PanelName = "selection";
        }

        protected Task OnSelectedTabChanged(string name)
        {
            SelectedTab = name;

            return Task.CompletedTask;
        }
    }
}