using System;
using Microsoft.AspNetCore.Components;
using RootServer.Shared.Airtable;

namespace RootServer.Shared._Sites
{
	public partial class SectionBase
    {
        [Parameter]
		public string? Id { get; set; } = "agenda";

		[Parameter]
		public string? Class { get; set; } = "section-agenda";

        [Parameter]
        public SectionData Section { get; set; } = new();

	}
}

