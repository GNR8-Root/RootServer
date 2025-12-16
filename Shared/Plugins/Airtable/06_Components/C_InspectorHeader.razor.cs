using System;
using AirtableApiClient;
using Microsoft.AspNetCore.Components;



namespace RootServer.Shared.Airtable
{
	public partial class C_InspectorHeader
    {
        [Parameter]
        public string Id { get; set; } = "ID";

        [Parameter]
        public string Label { get; set; } = "label";

    }
}