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
	public class GalleryItemService : AirtableTableService<GalleryItemData>
	{
        public GalleryItemService()
        {
            TABLE_ID = "tblztnZRqfVTl8DgN";
            offset = "";
            fields = new() { "Name", "Notes", "MediaContent", "Button", "Header", "Body", "ReferenceGallery", "ReferenceGalleryThumb"};
            filterByFormula = "";
            maxRecords = 1000;
            pageSize = 1;
            //sort;
        }
    }
}