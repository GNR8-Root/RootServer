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
	public class AirtableTableService<TABLE>

    {
        public string TABLE_ID = "";
        protected string offset = "";
        protected List<string> fields = new() {};
        protected string filterByFormula = "";
        protected int? maxRecords = 100;
        protected int? pageSize = 1;
        protected IEnumerable<Sort>? sort;

        readonly string view = "";
        readonly string cellFormat = "json";
        readonly string timeZone = "Europe/Amsterdam";
        readonly string userLocale = "nl";
        readonly bool returnFieldsByFieldId = false;
        readonly bool? includeCommentCount = false;


        public List<AirtableRecord<TABLE>> records = new();



        public async Task<List<AirtableRecord<TABLE>>> GetRecords()
        {
            records = await AllRecordsAsync();
            return records;
        }



        private async Task<List<AirtableRecord<TABLE>>> AllRecordsAsync()
        {
            Sort s = new();
            s.Direction = SortDirection.Asc;
            s.Field = "Date";


            string? errorMessage = null;
            List<AirtableRecord<TABLE>> records = new List<AirtableRecord<TABLE>>();


            using (AirtableBase airtableBase = new AirtableBase(Air.API_KEY, Air.BASE_ID))
            {
               
                
                //
                // Use 'offset' and 'pageSize' to specify the records that you want
                // to retrieve.
                // Only use a 'do while' loop if you want to get multiple pages
                // of records.
                //

                do
                {
                    Task<AirtableListRecordsResponse<TABLE>> task = airtableBase.ListRecords<TABLE>(
                           TABLE_ID,
                           offset,
                           fields,
                           filterByFormula,
                           maxRecords,
                           pageSize,
                           sort,
                           view,
                           cellFormat,
                           timeZone,
                           userLocale,
                           returnFieldsByFieldId,
                           includeCommentCount);

                    AirtableListRecordsResponse<TABLE> response = await task;

                    if (response.Success)
                    {
                        records.AddRange(response.Records.ToList());
                        offset = response.Offset;
                        
                    }
                    else if (response.AirtableApiError is AirtableApiException)
                    {
                        errorMessage = response.AirtableApiError.ErrorMessage;
                        if (response.AirtableApiError is AirtableInvalidRequestException)
                        {
                            errorMessage += "\nDetailed error message: ";
                            errorMessage += response.AirtableApiError.DetailedErrorMessage;
                        }
                        break;
                    }
                    else
                    {
                        errorMessage = "Unknown error";
                        break;
                    }
                } while (offset != null);
            }

            if (!string.IsNullOrEmpty(errorMessage))
            {
                // Error reporting
            }
            else
            {
                // Do something with the retrieved 'records' and the 'offset'
                // for the next page of the record list.
            }

            return records;
        }
    }
}

