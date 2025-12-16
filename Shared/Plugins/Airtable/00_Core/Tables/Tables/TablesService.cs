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
	public class TablesService : AirtableTableService<TablesData>
	{
        public TablesService()
        {
            TABLE_ID = "tblAUqyvFeH3d12mD";
            offset = "";
            fields = new() { "Name", "Workspace", "Icon", "Max_Rows", "Allow_Add", "Allow_Delete", "Bookmarked", "Bookmark_AddNewRow", "Bookmark_AllowRemoveFrom", "TableID", "TableURL" };
            filterByFormula = "";
            maxRecords = 100;
            pageSize = 1;
            //sort;
        }
    }
}