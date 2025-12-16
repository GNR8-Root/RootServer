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
	public class MediaCollectionContentService : AirtableTableService<MediaCollectionContentData>
	{
        public MediaCollectionContentService()
        {
            TABLE_ID = "tblOsYqNgfzOHsqjn";
            offset = "";
            fields = new() { "Name", "Notes", "MediaType", "Color", "Image", "Video", "Youtube", "Lottie", "Spline", "Ref_GalleryItem", "Ref_Agenda" };
            filterByFormula = "";
            maxRecords = 1000;
            pageSize = 1;
            //sort;
        }
    }
}