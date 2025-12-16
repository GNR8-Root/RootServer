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
	public class ColorsService : AirtableTableService<ColorsData>
	{
        public ColorsService()
        {
            TABLE_ID = "tblFecrp8wM3vrLhG";
            offset = "";
            fields = new() { "Name", "Notes", "Hex", "R", "G", "B", "A" };
            filterByFormula = "";
            maxRecords = 1000;
            pageSize = 1;
            //sort;
        }
    }
}