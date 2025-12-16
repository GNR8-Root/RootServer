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
	public class GalleryFilterService : AirtableTableService<GalleryFilterData>
	{
        public GalleryFilterService()
        {
            TABLE_ID = "tblyySG9k6waVjlcF";
            offset = "";
            fields = new() { "Name", "Notes", "Icon", "Gallery" };
            filterByFormula = "";
            maxRecords = 1000;
            pageSize = 1;
            //sort;
        }
    }
}