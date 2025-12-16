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
    public abstract class AirtableTableBase
    {
        public string fileName = "";
        public string json = "";



        public virtual async Task SerializeTable()
        {
            await Task.CompletedTask;
        }



        public virtual async Task DeSerializeTable()
        {
            await Task.CompletedTask;
        }



        public virtual async Task GetTable()
        {
            await Task.CompletedTask;
        }
    }
}