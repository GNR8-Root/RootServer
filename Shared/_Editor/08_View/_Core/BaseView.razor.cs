using System;
using System.Net.NetworkInformation;
using Blazorise;
using Microsoft.AspNetCore.Components;



namespace RootServer.Shared._Editor
{
    
	public partial class BaseView
    {
        [Parameter]
        public string Label { get; set; } = "-";

        [Parameter]
        public bool IsTabContent { get; set; }

        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        [Parameter]
        public string IdMenuItem { get; set; } = "";
    }
}