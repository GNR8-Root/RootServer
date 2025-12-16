using System;
using AirtableApiClient;



namespace RootServer.Shared.Airtable
{
	public class PagesData
    {
		public string? Name { get; set; }
        public string? Template { get; set; }
        public bool? Publish { get; set; }
        public bool? IsEditor { get; set; }
        public string? Notes { get; set; }
        public string? Pagename { get; set; }
        public string? Slug { get; set; }
        public string? SeoTitle { get; set; }
        public string? SeoMeta { get; set; }
        public string? OpengraphTitle { get; set; }
        public bool? OpengraphTitleIsSeoTitle { get; set; }
        public string? OpengraphDescription { get; set; }
        public bool? OpengraphDescriptionIsSeoDescription { get; set; }
        public List<AirtableAttachment>? OpengraphImageUrl1200x630 { get; set; }
        public bool? SearchExclude { get; set; }
        public string? SearchTitle { get; set; }
        public bool? SearchTitleIsSeoTitle { get; set; }
        public string? SearchDescription { get; set; }
        public bool? SearchDescriptionIsSeoDescription { get; set; }
        public List<AirtableAttachment>? SearchImage { get; set; }
        public bool? SearchImageIsOpengrapImage { get; set; }
        public string[]? Sections { get; set; }
    }
}