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
	public class MediaImageService : AirtableTableService<MediaImageData>
	{
        public MediaImageService()
        {
            TABLE_ID = "tblgHercdmSBEtPSM";
            offset = "";
            fields = new() { "Name", "Notes", "FileOverride", "Src", "Alt", "Loading", "BackgroundColor", "Ref_MediaCollectionContent", "Ref_MediaCollectionWebsite" };
            filterByFormula = "";
            maxRecords = 1000;
            pageSize = 1;
            //sort;
        }
    }
}