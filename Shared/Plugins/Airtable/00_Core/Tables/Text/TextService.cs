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
	public class TextService : AirtableTableService<TextData>
	{
        public TextService()
        {
            TABLE_ID = "tbl8fwOsk1gm71mbA";
            offset = "";
            fields = new() { "Name", "En", "Notes", "Section" };
            filterByFormula = "";
            maxRecords = 1000;
            pageSize = 1;
            //sort;
        }
    }
}