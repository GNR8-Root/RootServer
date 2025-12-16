using System;
using AirtableApiClient;
using Blazorise;
using Microsoft.AspNetCore.Components;



namespace RootServer.Shared._Core
{
	public partial class CP_DropdownGroup
    {
        private string LabelUpper { get { return SetLabel(); } }

        [Parameter]
        public string Label { get; set; } = "-";

        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        [Parameter]
        public IconName NameIcon { get; set; } = IconName.Alert;

        [Parameter]
        public bool ShowIconGroup { get; set; }



        public string SetLabel()
        {
            Label = Label.ToUpper();

            return Label;
        }



        public async Task OnInvoke()
        {
            await Task.CompletedTask;
        }
    }
}