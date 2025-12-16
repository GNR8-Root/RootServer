using System;
using AirtableApiClient;
using Microsoft.AspNetCore.Components;



namespace RootServer.Shared.Airtable
{
	public partial class C_Rows
    {

        [Parameter]
        public string? Name { get; set; }

        [Parameter]
        public string IdParentMenu { get; set; } = "";



        public Task OnSelect()
        {
            return Task.CompletedTask;
        }



        public Task OnDelete()
        {
            return Task.CompletedTask;
        }



        public Task OnDuplicate()
        {
            return Task.CompletedTask;
        }



        public Task OnNewRow()
        {
            return Task.CompletedTask;
        }
    }
}