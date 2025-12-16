using System;
using AirtableApiClient;
using Blazorise;
using Microsoft.AspNetCore.Components;
using RootServer.Shared.Airtable;



namespace RootServer.Shared._Sites
{
	public partial class C_AgendaItem
    {
        [Parameter]
        public AgendaData Record { get; set; } = new();

        /*
        [Parameter]
        public string? Type { get; set; }

        [Parameter]
        public string? NameFestival { get; set; }

        [Parameter]
        public string? Location { get; set; }

        [Parameter]
        public string? Date { get; set; }

        [Parameter]
        public string? Organizer { get; set; }

        [Parameter]
        public string? Link { get; set; }
        */
    }
}

