using System;
using AirtableApiClient;



namespace RootServer.Shared.Airtable
{
	public class MediaImageData : BaseMediaType
    {
        public string? Alt { get; set; }
        public string? Loading { get; set; }
    }
}