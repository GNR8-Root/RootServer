using System;
using AirtableApiClient;
using Blazorise;
using Microsoft.AspNetCore.Components;



namespace RootServer.Shared.Airtable
{
	public partial class C_TableAir
    {
        [Parameter]
        public EventCallback<string> SetAccordion { get; set; }

        [Parameter]
        public string? Label { get; set; }

        [Parameter]
        public string? IdMenuItem { get; set; }

        [Parameter]
        public string? IdParentMenu { get; set; }

        [Parameter]
        public bool AccVisible { get; set; }
    }
}