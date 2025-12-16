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
	public class TableText : AirtableTable<TextData, TextService>
    {
        public TableText()
        {
            standartField = "En";
            fileName = "text";
            tableService = new();
            rows = new();
            Air.tables.TryAdd(fileName, this);
        }



        public override async Task GetTable()
        {
            await base.GetTable();
        }



        public override string Get(string _nameField, string _resultField)
        {
            string result = "null";

            if (rows != null)
            {
                var p = rows.SingleOrDefault(t => t.Fields.Name == _nameField);

                if (p != null && _resultField != null && p.Fields.GetProperty(_resultField) != null)
                {
                    var s = p.Fields.GetProperty(_resultField);
                    if (s != null)
                        result = (string)s;
                }
            }

            return result;
        }
    }
}