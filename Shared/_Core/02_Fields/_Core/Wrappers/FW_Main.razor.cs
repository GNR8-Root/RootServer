using System;
using AirtableApiClient;
using Blazorise;
using Microsoft.AspNetCore.Components;



namespace RootServer.Shared._Core
{
    public partial class FW_Main
    {
        [Parameter]
        public string BadgeLabel { get; set; } = "lbl";

        [Parameter]
        public Color BadgeColor { get; set; } = Color.Dark;

        [Parameter]
        public string ToolTipText { get; set; } = "tltp";

        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        [Parameter]
        public IconName NameIcon { get; set; } = IconName.Add;
    }
}

