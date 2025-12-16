using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using AirtableApiClient;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System.Buffers.Text;



namespace RootServer.Shared.Airtable
{
	public class TableSettings : AirtableTable<SettingsData, SettingsService>
    {
        public TableSettings()
        {
            fileName = "settings";
            tableService = new();
            rows = new();
            Air.tables.TryAdd(fileName, this);
        }



        public override async Task GetTable()
        {
            await base.GetTable();

            /*
            Console.WriteLine("SETTINGS.Name " + Table.settings[0].Fields.Name);
            Console.WriteLine("SETTINGS.Notes " + Table.settings[0].Fields.Notes);
            */
        }
    }
}