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
	public class TableTables : AirtableTable<TablesData, TablesService>
    {
        public TableTables()
        {
            fileName = "tables";
            tableService = new();
            rows = new();
            Air.tables.TryAdd(fileName, this);
        }



        public override async Task GetTable()
        {
            await base.GetTable();

            /*
            Console.WriteLine("Table.Name " + Table.tables[3].Fields.Name);

            Console.WriteLine("Table.Workspace length " + Table.tables[3].Fields.Workspace.Length);

            for (int i = 0; i < Table.tables[0].Fields.Workspace.Length; i++)
            {
                Console.WriteLine("Table.Workspace " + Table.tables[3].Fields.Workspace[i]);
            }

            Console.WriteLine("Table.Icon " + Table.tables[3].Fields.Icon);
            Console.WriteLine("Table.MaxRows " + Table.tables[3].Fields.Max_Rows);
            Console.WriteLine("Table.AllowAd " + Table.tables[3].Fields.Allow_Add);
            Console.WriteLine("Table.AllowDelete " + Table.tables[3].Fields.Allow_Delete);
            Console.WriteLine("Table.Bookmarked " + Table.tables[3].Fields.Bookmarked);
            Console.WriteLine("Table.BookmarkAddNewRow " + Table.tables[3].Fields.Bookmark_AddNewRow);
            Console.WriteLine("Table.BookmarkAllowRemoveFrom " + Table.tables[3].Fields.Bookmark_AllowRemoveFrom);
            Console.WriteLine("Table.TableID " + Table.tables[3].Fields.TableID);
            Console.WriteLine("Table.TableUrl " + Table.tables[3].Fields.TableURL);
            */
        }
    }
}