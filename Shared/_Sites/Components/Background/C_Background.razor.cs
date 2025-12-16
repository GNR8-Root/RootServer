using System;
using Microsoft.AspNetCore.Components;
using RootServer.Shared.Airtable;



namespace RootServer.Shared._Sites
{
	public partial class C_Background
    {
		[Parameter]
		public string Id { get; set; } = "";

		[Parameter]
		public string Class { get; set; } = "";

		[Parameter]
		public string BackgroundId { get; set; } = "";

        public MediaCollectionWebsiteData Record {
			get
            {
                if (BackgroundId != "" && Air.Table.mediaCollectionWebsite != null)
                    if (Air.Table.mediaCollectionWebsite.RowById(BackgroundId).Fields != null)
                        return Air.Table.mediaCollectionWebsite.RowById(BackgroundId).Fields;
                    else
                        return new();

                else
                    return new();
            }
		}
    }
}