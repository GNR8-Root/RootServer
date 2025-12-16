using System;
using AirtableApiClient;
using Blazorise;
using Microsoft.AspNetCore.Components;
using RootServer.Shared.Airtable;



namespace RootServer.Shared._Sites
{
	public partial class C_AgendaSection
    {
        [Parameter]
        public TableAgenda Records { get; set; } = new();

        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        public C_AgendaSection()
        {
            Class = "section-agenda";
        }
    }
}

