using System;
using Blazorise;
using Microsoft.AspNetCore.Components;
using RootServer.Shared.Airtable;

namespace RootServer.Shared._Sites
{
	public partial class CW_Section
	{

        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        [Parameter]
		public string? Id { get; set; } = "";

		[Parameter]
		public string? Class { get; set; } = "";

        [Parameter]
        public SectionData Section { get; set; }

        public string SectionBackground
        {
            get
            {
                if (Section != null&& Section.Background != null)
                    return Section.Background[0];
                else
                    return "";
            }
        }
    }
}

