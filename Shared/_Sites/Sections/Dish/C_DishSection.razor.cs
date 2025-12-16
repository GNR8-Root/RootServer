using System;
using AirtableApiClient;
using Blazorise;
using Microsoft.AspNetCore.Components;
using RootServer.Shared._Sites;
using RootServer.Shared.Airtable;



namespace RootServer.Shared._Sites
{
	public partial class C_DishSection
    {
        [Parameter]
        public TableDishIngredients Records { get; set; } = new();

        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        public C_DishSection()
        {
            Class = "section-dish";
        }
    }
}

