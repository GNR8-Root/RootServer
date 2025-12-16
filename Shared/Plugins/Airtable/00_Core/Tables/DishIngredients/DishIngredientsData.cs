using System;
using AirtableApiClient;



namespace RootServer.Shared.Airtable
{
	public class DishIngredientsData
    {
		public string? Name { get; set; }
        public string? Description { get; set; }
        public string[]? Color { get; set; }
    }
}