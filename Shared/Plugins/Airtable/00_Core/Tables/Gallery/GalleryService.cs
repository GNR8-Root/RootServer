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
	public class GalleryService : AirtableTableService<GalleryData>
	{
        public GalleryService()
        {
            TABLE_ID = "tblo0mEoBiFwmegLG";
            offset = "";
            fields = new() { "Name", "Publish", "Notes", "Button", "Header", "Body", "Thumbnail", "Items", "Icon", "Filter"};
            filterByFormula = "";
            maxRecords = 1000;
            pageSize = 1;
            //sort;
        }
    }
}