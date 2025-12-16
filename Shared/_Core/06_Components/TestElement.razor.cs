using System;
using AirtableApiClient;
using Microsoft.AspNetCore.Components;



namespace RootServer.Shared._Core
{
	public partial class TestElement
	{
        private string? UpMsg { get; set; }

        private string upMsg = "SendingUp";
        [Parameter]
        public string? Name { get; set; }

		[Parameter]
		public EventCallback<string> SendUp { get; set; }
	}
}

