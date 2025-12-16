using System;
using AirtableApiClient;
using Blazorise;
using Microsoft.AspNetCore.Components;
using RootServer.Shared._Sites;
using RootServer.Shared.Airtable;



namespace RootServer.Shared._Sites
{
	public partial class C_Gallery
    {
        [Parameter]
        public GalleryData Record { get; set; } = new();

        [Parameter]
        public RenderFragment? ChildContent { get; set; }
    }
}