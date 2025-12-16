using System;
using AirtableApiClient;
using Blazorise;
using Microsoft.AspNetCore.Components;
using RootServer.Shared.Airtable;



namespace RootServer.Shared._Sites
{
	public partial class N_Section
    {
        [Parameter]
        public RenderFragment? ChildContent { get; set; }
    }
}

