using System;
using AirtableApiClient;



namespace RootServer.Shared.Airtable
{
	public class MediaLottieData : BaseMediaType
    {
        public bool? Loop { get; set; }
        public bool? PlayDirectionForward { get; set; }
        public bool? Autoplay { get; set; }
        public string? Renderer { get; set; }
        public float? DefaultDuration { get; set; }
        public float? OverrideDuration { get; set; }
    }
}