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
	public class SettingsService : AirtableTableService<SettingsData>
	{
        public SettingsService()
        {
            TABLE_ID = "tblxXBfCgeb0BjGJC";
            offset = "";
            fields = new() { "Name", "Notes" };
            filterByFormula = "";
            maxRecords = 1000;
            pageSize = 1;
            //sort;
        }
    }
}