using System;



namespace RootServer.Shared.Airtable
{
	public class AppsData
    {
		public string? Name { get; set; }
        public string[]? Workspaces { get; set; }
        public string? Icon { get; set; }
        public string? Notes { get; set; }
    }
}