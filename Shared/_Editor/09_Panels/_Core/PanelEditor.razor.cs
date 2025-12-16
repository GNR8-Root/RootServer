using System;
using AirtableApiClient;
using Blazorise;
using Microsoft.AspNetCore.Components;



namespace RootServer.Shared._Editor
{
	public partial class PanelEditor
    {
        [Parameter]
        public EventCallback<string> SelectedTabChanged { get; set; }

        [Parameter]
        public string PanelTabsId { get; set; } = "panelTabsId";

        [Parameter]
        public string SelectedTab { get; set; } = "content";


        [Parameter]
        public RenderFragment? HeadLeft { get; set; }

        [Parameter]
        public RenderFragment? HeadCenter { get; set; }

        [Parameter]
        public RenderFragment? HeadRight { get; set; }


        [Parameter]
        public RenderFragment? ContentPre { get; set; }

        [Parameter]
        public RenderFragment? Content { get; set; }

        [Parameter]
        public RenderFragment? ContentPost { get; set; }


        [Parameter]
        public RenderFragment? FootRight { get; set; }

        [Parameter]
        public RenderFragment? FootCenter { get; set; }

        [Parameter]
        public RenderFragment? FootLeft { get; set; }



        private Task OnSelectedTabChanged(string name)
        {
            //doesnt work
            System.Console.WriteLine($"PanelEditor.OnSelectedTabChanged({name})");

            SelectedTab = name;

            return Task.CompletedTask;
        }
    }
}