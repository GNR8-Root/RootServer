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
    public abstract class AirtableTable<TDATA, TSERVICE> : AirtableTableBase
        where TSERVICE : AirtableTableService<TDATA>
    {
        public TSERVICE? tableService;
        public List<AirtableRecord<TDATA>>? rows;
        protected string standartField = "";



        public List<AirtableRecord<TDATA>> RowsById(string[] ids)
        {
            List<AirtableRecord<TDATA>> r = new();

            foreach (string id in ids)
            {
                AirtableRecord<TDATA> t = rows.SingleOrDefault(t => t.Id == id);
                if(t != null)
                    r.Add(t);
            }
                
            return r;
        }



        public AirtableRecord<TDATA> RowById(string id)
        {
            AirtableRecord<TDATA> r = rows.SingleOrDefault(t => t.Id == id);

            System.Console.WriteLine($"AirtableTable.cs rows {rows} = {rows.Count} : {id}");

            return r;
        }




        public string Get(string _nameField)
        {
            return Get(_nameField, standartField);
        }



        public virtual string Get(string _nameField, string _resultField)
        {
            string result = "null";

            return result;
        }





        public override async Task SerializeTable()
        {
            json = JsonSerializer.Serialize(rows);
            File.WriteAllText($"Json/{fileName}.json", json);

            await Task.CompletedTask;
        }



        public override async Task DeSerializeTable()
        {
            if (File.Exists($"Json/{fileName}.json"))
            {
                json = File.ReadAllText($"Json/{fileName}.json");
                rows = JsonSerializer.Deserialize<List<AirtableRecord<TDATA>>>(json);
            }

            await Task.CompletedTask;
        }



        public override async Task GetTable()
        {
            if(tableService != null)
                rows = await tableService.GetRecords();
        }
    }
}