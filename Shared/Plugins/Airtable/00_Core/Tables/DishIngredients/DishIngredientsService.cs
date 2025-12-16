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
	public class DishIngredientsService : AirtableTableService<DishIngredientsData>
	{
        public DishIngredientsService()
        {
            TABLE_ID = "tblWKoXwbfrpOW4Kq";
            offset = "";
            fields = new() { "Name", "Description", "Color"};
            filterByFormula = "";
            maxRecords = 1000;
            pageSize = 1;
            //sort;
        }
    }
}