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
	public class TableColors : AirtableTable<ColorsData, ColorsService>
    {
        public TableColors()
        {
            fileName = "color";
            tableService = new();
            rows = new();
            Air.tables.TryAdd(fileName, this);
        }



        public override async Task GetTable()
        {
            await base.GetTable();

            /*
            Console.WriteLine(Table.colors[0].Fields.Name);
            Console.WriteLine(Table.colors[0].Fields.Hex);
            Console.WriteLine(Table.colors[0].Fields.R);
            Console.WriteLine(Table.colors[0].Fields.G);
            Console.WriteLine(Table.colors[0].Fields.B);
            Console.WriteLine(Table.colors[0].Fields.ImageIngredient);
            */
        }



        public string CssColor(ColorsData _colorData)
        {
            return "color: " + HexOrRgb(_colorData);
        }



        public string CssBackgroundColor(ColorsData _colorData)
        {
            return "background-color: " + HexOrRgb(_colorData);
        }



        public string CssColor(string _recordId)
        {
            return "color: " + HexOrRgb(RowById(_recordId).Fields);
        }



        public string CssBackgroundColor(string _recordId)
        {
            return "background-color: " + HexOrRgb(RowById(_recordId).Fields);
        }



        private string HexOrRgb(ColorsData _data)
        {
            string r = "";

            if (_data.R != null && _data.G != null && _data.B != null)
                if (_data.A != null)
                    r = $"rgba({_data.R},{_data.G},{_data.B},{_data.A});";
                else
                    r = $"rgb({_data.R},{_data.G},{_data.B});";

            else if (_data.Hex != null || _data.Hex != "")
                r = _data.Hex + ";";

            return r;
        }



        public string Get(string textField)
        {
            return Get(textField, "Hex");
        }



        public string Get(string textField, string field)
        {
            string result = "null";

            if (rows != null)
            {
                var p = rows.SingleOrDefault(t => t.Fields.Name == textField);

                if (p != null && field != null && p.Fields.GetProperty(field) != null)
                {
                    var s = p.Fields.GetProperty(field);
                    if (s != null)
                        result = (string)s;
                }
            }

            return result;
        }
    }
}