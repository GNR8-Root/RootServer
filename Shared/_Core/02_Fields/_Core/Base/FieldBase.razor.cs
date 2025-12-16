using System;
using AirtableApiClient;
using Blazorise;
using Microsoft.AspNetCore.Components;



namespace RootServer.Shared._Core
{
    public abstract partial class FieldBase
    {
        [Parameter]
        public string Placeholder { get; set; } = "";

        [Parameter]
        public string BadgeLabel { get; set; } = "";

        public Color BadgeColor { get; set; } = Color.Dark;

        [Parameter]
        public string ToolTipText { get; set; } = "";

        [Parameter]
        public bool ReadOnly { get; set; }

        [Parameter]
        public bool Disabled { get; set; }
    }
}