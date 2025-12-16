using System;
using AirtableApiClient;



namespace RootServer.Shared.Airtable
{
	public class GalleryData
    {
		public string? Name { get; set; }
        public bool? Publish { get; set; }
        public string? Notes { get; set; }
        public string? Button { get; set; }
        public string? Header { get; set; }
        public string? Body { get; set; }
        public string[]? Thumbnail { get; set; }
        public string[]? Items { get; set; }
        public string? Icon { get; set; }
        public string[]? Filter { get; set; }
    }
}