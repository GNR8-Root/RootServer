using System;
using AirtableApiClient;
using Microsoft.AspNetCore.Components;



namespace RootServer.Shared._Core
{
	public partial class CP_HeadContentWebflow
    {
		[Parameter]
		public string Page { get; set; } = "";
	}
}

