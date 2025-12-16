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
	public class MediaYoutubeService : AirtableTableService<MediaYoutubeData>
	{
        public MediaYoutubeService()
        {
            TABLE_ID = "tblRY2w8SLSGKXDNr";
            offset = "";
            fields = new() { "Name", "Title", "AutoPlay", "StartMute", "AllowFullScreen", "Src", "StartTime", "BackgroundColor", "Ref_MediaCollectionWebsite", "Ref_MediaCollectionContent" };
            filterByFormula = "";
            maxRecords = 1000;
            pageSize = 1;
            //sort;
        }
    }
}