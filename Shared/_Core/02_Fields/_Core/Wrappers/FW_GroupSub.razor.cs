using System;
using AirtableApiClient;
using Blazorise;
using Microsoft.AspNetCore.Components;



namespace RootServer.Shared._Core
{
    public partial class FW_GroupSub
    {
        [Parameter]
        public RenderFragment? ChildContent { get; set; }
    }
}

