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
	public class MediaVideoService : AirtableTableService<MediaVideoData>
	{
        public MediaVideoService()
        {
            TABLE_ID = "tblFSBcw3ZqJbP1QY";
            offset = "";
            fields = new() { "Name", "Notes", "FileOverride", "Src", "BackgroundColor", "Ref_MediaCollectionWebsite", "Ref_MediaCollectionContent" };
            filterByFormula = "";
            maxRecords = 1000;
            pageSize = 1;
            //sort;
        }
    }
}