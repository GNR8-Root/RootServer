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
	public class PagesService : AirtableTableService<PagesData>
	{
        public PagesService()
        {
            TABLE_ID = "tblyNVizfjNFyJjJs";
            offset = "";
            fields = new() { "Name", "Template", "Publish", "IsEditor", "Notes", "Pagename", "Slug", "SeoTitle", "SeoMeta", "OpengraphTitle", "OpengraphTitleIsSeoTitle", "OpengraphDescription", "OpengraphDescriptionIsSeoDescription", "OpengraphImageUrl1200x630", "SearchExclude", "SearchTitle", "SearchTitleIsSeoTitle", "SearchDescription", "SearchDescriptionIsSeoDescription", "SearchImage", "SearchImageIsOpengrapImage", "Sections" };
            filterByFormula = "";
            maxRecords = 1000;
            pageSize = 1;
            //sort;
        }
    }
}