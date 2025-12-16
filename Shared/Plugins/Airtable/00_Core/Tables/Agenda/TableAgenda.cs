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
	public class TableAgenda : AirtableTable<AgendaData, AgendaService>
    {
        public TableAgenda()
        {
            fileName = "agenda";
            tableService = new();
            rows = new();
            Air.tables.TryAdd(fileName, this);
        }



        public override async Task GetTable()
        {
            await base.GetTable();

            /*
           Console.WriteLine(Table.agenda[1].Fields.Name);
           Console.WriteLine(Table.agenda[1].Fields.Publish);
           Console.WriteLine(Table.agenda[1].Fields.Location);
           Console.WriteLine(Table.agenda[1].Fields.DateFrom);
           Console.WriteLine(Table.agenda[1].Fields.DateTill);
           Console.WriteLine(Table.agenda[1].Fields.Location);
           Console.WriteLine(Table.agenda[1].Fields.Type);
           Console.WriteLine(Table.agenda[1].Fields.Notes);
           */
        }
    }
}