using System;
using System.Net.NetworkInformation;
using Blazorise;
using Microsoft.AspNetCore.Components;



namespace RootServer.Shared.Airtable
{
	public partial class PNL_Structure
    {
        public PNL_Structure()
        {
            SelectedTab = "content";
            PanelName = "structure";
        }


        protected override void ServiceReceived()
        {
            SelectedTab = pointer_Service.CurrentPointer.Self.Label;
            base.ServiceReceived();
        }


        protected Task OnSelectedTabChanged(string name)
        {
            SelectedTab = name;

            return Task.CompletedTask;
        }
    }
}