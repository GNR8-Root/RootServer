using System;
using AirtableApiClient;
using Blazorise;
using Microsoft.AspNetCore.Components;
using RootServer.Shared.Airtable;



namespace RootServer.Shared._Sites
{
	public partial class C_GalleryItem
    {
        [Parameter]
        public AirtableRecord<GalleryItemData> Record { get; set; } = new();
    }
}

