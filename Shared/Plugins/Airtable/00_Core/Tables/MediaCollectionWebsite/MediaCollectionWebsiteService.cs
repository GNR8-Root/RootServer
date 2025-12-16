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
	public class MediaCollectionWebsiteService : AirtableTableService<MediaCollectionWebsiteData>
	{
        public MediaCollectionWebsiteService()
        {
            TABLE_ID = "tblnfxfNNObFewroh";
            offset = "";
            fields = new() { "Name", "Notes", "MediaType", "Color", "Image", "Video", "Youtube", "Lottie", "Spline", "Ref_Sections", "Ref_Pages" };
            filterByFormula = "";
            maxRecords = 1000;
            pageSize = 1;
            //sort;
        }
    }
}