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
	public class TableApps : AirtableTable<AppsData, AppsService>
    {
        public TableApps()
        {
            fileName = "apps";
            tableService = new();
            rows = new();
            Air.tables.TryAdd(fileName, this);
        }



        public override async Task GetTable()
        {
            await base.GetTable();

            /*
             Console.WriteLine("APPS.Name " + Table.apps[0].Fields.Name);

             for(int i = 0; i < Table.apps[0].Fields.Workspaces.Length; i++)
             {
                 Console.WriteLine("APPS.Workspaces " + Table.apps[0].Fields.Workspaces[i]);
             }

             Console.WriteLine("APPS.Icon " + Table.apps[0].Fields.Icon);
             Console.WriteLine("APPS.Notes " + Table.apps[0].Fields.Notes);
             */
        }
    }
}