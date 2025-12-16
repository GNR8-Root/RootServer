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
	public class WorkspacesService : AirtableTableService<WorkspacesData>
	{
        public WorkspacesService()
        {
            TABLE_ID = "tbld5U0GZdb25NYvD";
            offset = "";
            fields = new() { "Name", "Apps", "Tables", "Icon", "Notes" };
            filterByFormula = "";
            maxRecords = 1000;
            pageSize = 1;
            //sort;
        }
    }
}