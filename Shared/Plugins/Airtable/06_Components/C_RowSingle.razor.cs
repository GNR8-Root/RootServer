using System;
using AirtableApiClient;
using Microsoft.AspNetCore.Components;



namespace RootServer.Shared.Airtable
{
	public partial class C_RowSingle
    {

        [Parameter]
        public string? Name { get; set; }

        [Parameter]
        public string IdParentMenu { get; set; } = "";

        [Parameter]
        public string IdMenuItem { get; set; } = "";
    }
}