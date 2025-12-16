using System;



namespace RootServer.Shared.Airtable
{
	public class WorkspacesData
    {
		public string? Name { get; set; }
        public string[]? Apps { get; set; }
        public string[]? Tables { get; set; }
        public string? Icon { get; set; }
        public string? Notes { get; set; }
    }
}