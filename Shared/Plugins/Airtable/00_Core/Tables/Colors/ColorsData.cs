using System;
using AirtableApiClient;



namespace RootServer.Shared.Airtable
{
	public class ColorsData
    {
		public string? Name { get; set; }
        public string? Hex { get; set; }
        public int? R { get; set; }
        public int? G { get; set; }
        public int? B { get; set; }
        public float? A { get; set; }
    }
}