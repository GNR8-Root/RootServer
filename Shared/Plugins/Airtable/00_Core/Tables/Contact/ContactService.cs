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
	public class ContactService : AirtableTableService<ContactData>
	{
        public ContactService()
        {
            TABLE_ID = "tblHFLqA2sCi4mKYD";
            offset = "";
            fields = new() { "Name", "Phone", "PhoneIcon", "Email", "EmailIcon", "Fb", "FbIcon", "Insta", "InstaIcon" };
            filterByFormula = "";
            maxRecords = 1000;
            pageSize = 1;
            //sort;
        }
    }
}