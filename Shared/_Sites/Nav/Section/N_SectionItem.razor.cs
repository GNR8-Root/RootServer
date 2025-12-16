using System;
using AirtableApiClient;
using Blazorise;
using Microsoft.AspNetCore.Components;
using RootServer.Shared.Airtable;



namespace RootServer.Shared._Sites
{
	public partial class N_SectionItem
    {
        [Parameter]
        public SectionData Record { get; set; } = new();
    }
}

