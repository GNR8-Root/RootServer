using System;
using AirtableApiClient;
using Microsoft.AspNetCore.Components;
using RootServer.Shared._Editor;



namespace RootServer.Shared.Airtable
{
	public partial class W_Tables
    {
        [Parameter]
        public Dictionary<string, bool> Visible { get; set; } = new();

        [Parameter]
        public string IdParentMenu { get; set; } = "";



        protected void ToggleAccordion(string item)
        {
            System.Console.WriteLine($"W_Tables.ToggleAccordion({item})");
            if (DataEditor.AccordionSingle == true)
                foreach (KeyValuePair<string, bool> entry in Visible)
                    Visible[entry.Key] = false;

            Visible[item] = true;
        }
    }
}