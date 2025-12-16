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
	public class MediaLottieService : AirtableTableService<MediaLottieData>
	{
        public MediaLottieService()
        {
            TABLE_ID = "tblGox7blgU8MzzB1";
            offset = "";
            fields = new() { "Name", "Notes", "FileOverride", "Src", "Loop", "PlayDirectionForward", "Autoplay", "Renderer", "DefaultDuration", "OverrideDuration", "BackgroundColor", "Ref_MediaCollectionWebsite", "Ref_MediaCollectionContent" };
            filterByFormula = "";
            maxRecords = 1000;
            pageSize = 1;
            //sort;
        }
    }
}