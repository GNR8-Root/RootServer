using System;



namespace RootServer.Shared.Airtable
{
	public class AgendaData
	{
        public bool Publish { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? Organizer { get; set; }
        public string? DateFrom { get; set; }
        public string? DateTill { get; set; }
        public string? Location { get; set; }
        public string? Notes { get; set; }
        public string? Link { get; set; }
    }
}