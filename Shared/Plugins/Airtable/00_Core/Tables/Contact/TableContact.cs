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
	public class TableContact : AirtableTable<ContactData, ContactService>
    {
        public TableContact()
        {
            fileName = "contact";
            tableService = new();
            rows = new();
            Air.tables.TryAdd(fileName, this);
        }



        public override async Task GetTable()
        {
            await base.GetTable();

            /*
            Console.WriteLine(Table.contact[0].Fields.Name);
            Console.WriteLine(Table.contact[0].Fields.Phone);
            Console.WriteLine(Table.contact[0].Fields.PhoneIcon);
            Console.WriteLine(Table.contact[0].Fields.Email);
            Console.WriteLine(Table.contact[0].Fields.EmailIcon);
            Console.WriteLine(Table.contact[0].Fields.Fb);
            Console.WriteLine(Table.contact[0].Fields.FbIcon);
            Console.WriteLine(Table.contact[0].Fields.Insta);
            Console.WriteLine(Table.contact[0].Fields.InstaIcon);
            */
        }
    }
}