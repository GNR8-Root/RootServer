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
	public class TableWorkspaces : AirtableTable<WorkspacesData, WorkspacesService>
    {
        public TableWorkspaces()
        {
            fileName = "workspaces";
            tableService = new();
            rows = new();
            Air.tables.TryAdd(fileName, this);
        }



        public override async Task GetTable()
        {
            await base.GetTable();

            /*
            Console.WriteLine("WORKSPACES.Name " + Table.workspaces[0].Fields.Name);
            Console.WriteLine("WORKSPACES.Apps length " + Table.workspaces[0].Fields.Apps.Length);
            
            for (int i = 0; i < Table.workspaces[0].Fields.Apps.Length; i++)
            {
                Console.WriteLine("WORKSPACES.Apps " + Table.workspaces[0].Fields.Apps[i]);
            }

            Console.WriteLine("WORKSPACES.Tables length " + Table.workspaces[0].Fields.Table.Length);

            for (int i = 0; i < Table.workspaces[0].Fields.Table.Length; i++)
            {
                Console.WriteLine("WORKSPACES.Tables " + Table.workspaces[0].Fields.Tables[i]);
            }

            Console.WriteLine("WORKSPACES.Icon " + Table.workspaces[0].Fields.Icon);
            Console.WriteLine("WORKSPACES.Notes " + Table.workspaces[0].Fields.Notes);
            */
        }
    }
}