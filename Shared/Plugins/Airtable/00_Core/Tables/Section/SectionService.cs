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
	public class SectionService : AirtableTableService<SectionData>
	{
        public SectionService()
        {
            TABLE_ID = "tbl3iy5HalnVy6uzh";
            offset = "";
            fields = new() { "Name", "Pages", "TextButton", "TextHeader", "TextBody", "Icon", "ImageThumbnail", "ImagePoster", "Background", "TextReference"};
            filterByFormula = "";
            maxRecords = 1000;
            pageSize = 1;
            //sort;
        }
    }
}