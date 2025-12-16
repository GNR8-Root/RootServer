using System;



namespace RootServer.Shared.Airtable
{
	public class MediaYoutubeData
    {
		public string? Name { get; set; }
        public string? Title { get; set; }
        public bool? AutoPlay { get; set; }
        public bool? StartMute { get; set; }
        public bool? AllowFullScreen { get; set; }
        public string? Src { get; set; }
        public int? StartTime { get; set; } = 0;
        public string[]? BackgroundColor { get; set; }
        public string[]? Ref_MediaCollectionWebsite { get; set; }
        public string[]? Ref_MediaCollectionContent { get; set; }
    }
}