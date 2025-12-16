using System;



namespace RootServer.Shared.Airtable
{
	public class GalleryFilterData
    {
		public string? Name { get; set; }
        public string? Notes { get; set; }
        public string? Icon { get; set; }
        public string[]? Gallery { get; set; }
    }
}