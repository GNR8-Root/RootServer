using System;
using AirtableApiClient;

namespace RootServer.Shared.Airtable
{
	public class BaseMediaType
	{
        public string? Name { get; set; }
        public string? Notes { get; set; }
        public string? Src { get; set; }
        public List<AirtableAttachment>? FileOverride { get; set; }
        public string[]? BackgroundColor { get; set; }
        public string[]? Ref_MediaCollectionContent { get; set; }
        public string[]? Ref_MediaCollectionWebsite { get; set; }
    }
}

