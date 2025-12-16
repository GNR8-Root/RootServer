using System;
using AirtableApiClient;



namespace RootServer.Shared.Airtable
{
	public class GalleryItemData
    {
		public string? Name { get; set; }
        public string? Notes { get; set; }
        public string[]? MediaContent { get; set; }
        public string? Button { get; set; }
        public string? Header { get; set; }
        public string? Body { get; set; }
        public string[]? ReferenceGallery { get; set; }
        public string[]? ReferenceGalleryThumb { get; set; }
    }
}