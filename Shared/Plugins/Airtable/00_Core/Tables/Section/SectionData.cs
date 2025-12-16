using System;
using AirtableApiClient;



namespace RootServer.Shared.Airtable
{
	public class SectionData
    {
		public string? Name { get; set; }
        public string[]? Pages { get; set; }
        public string[]? TextButton { get; set; }
        public string[]? TextHeader { get; set; }
        public string[]? TextBody { get; set; }
        public string? Icon { get; set; }
        public List<AirtableAttachment>? ImageThumbnail { get; set; }
        public List<AirtableAttachment>? ImagePoster { get; set; }
        public string[]? Background { get; set; }
        public string[]? TextReference { get; set; }
    }
}