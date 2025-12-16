using System;
using AirtableApiClient;
using Blazorise;
using Microsoft.AspNetCore.Components;
using RootServer.Shared.Airtable;



namespace RootServer.Shared._Sites
{
	public partial class C_DishIngredient
    {
        [Parameter]
        public DishIngredientsData Record { get; set; } = new();
    }
}

