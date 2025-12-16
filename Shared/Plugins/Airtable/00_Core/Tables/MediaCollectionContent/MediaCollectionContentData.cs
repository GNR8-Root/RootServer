using System;



namespace RootServer.Shared.Airtable
{
	public class MediaCollectionContentData
    {
		public string? Name { get; set; }
        public string? Notes { get; set; }
        public string? MediaType { get; set; }
        public string[]? Color { get; set; }
        public string[]? Image { get; set; }
        public string[]? Video { get; set; }
        public string[]? Youtube { get; set; }
        public string[]? Lottie { get; set; }
        public string[]? Spline { get; set; }
        public string[]? Ref_GalleryItem { get; set; }
        public string[]? Ref_Agenda { get; set; }
    }
}