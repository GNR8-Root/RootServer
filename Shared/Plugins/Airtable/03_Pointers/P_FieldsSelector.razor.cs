using System;
using AirtableApiClient;
using Blazorise;
using Microsoft.AspNetCore.Components;



namespace RootServer.Shared.Airtable
{
	public partial class P_FieldsSelector
    {
        Dropdown dropdown = new();

        Task ShowMenu()
        {
            return dropdown.Show();
        }
    }
}