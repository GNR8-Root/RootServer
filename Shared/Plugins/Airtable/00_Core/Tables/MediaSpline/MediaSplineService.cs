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
	public class MediaSplineService : AirtableTableService<MediaSplineData>
	{
        public MediaSplineService()
        {
            TABLE_ID = "tbl3VH3c7sKAMulWd";
            offset = "";
            fields = new() { "Name", "Notes", "FileOverride", "Src", "BackgroundColor", "Ref_MediaCollectionWebsite", "Ref_MediaCollectionContent" };
            filterByFormula = "";
            maxRecords = 1000;
            pageSize = 1;
            //sort;
        }
    }
}