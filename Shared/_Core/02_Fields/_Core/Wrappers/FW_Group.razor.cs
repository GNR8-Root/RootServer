using System;
using AirtableApiClient;
using Blazorise;
using Microsoft.AspNetCore.Components;



namespace RootServer.Shared._Core
{
    public partial class FW_Group
    {
        [Parameter]
        public string HeaderLabel { get; set; } = "lbl";

        [Parameter]
        public string RowLabel { get; set; } = "lbl";

        [Parameter]
        public Color BadgeColor { get; set; } = Color.Dark;

        [Parameter]
        public string ToolTipText { get; set; } = "tltp";

        [Parameter]
        public RenderFragment? ChildContent { get; set; }
    }
}

