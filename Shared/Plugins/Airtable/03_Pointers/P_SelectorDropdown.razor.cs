using System;
using AirtableApiClient;
using Blazorise;
using Microsoft.AspNetCore.Components;
using static RootServer.Shared._Core.CP_DropdownItem;



namespace RootServer.Shared.Airtable
{
	public partial class P_SelectorDropdown
    {
        public override async Task NewItemSelected(IconLabelSet _item)
        {
            await base.NewItemSelected(_item);

            await Task.CompletedTask;
        }
    }
}