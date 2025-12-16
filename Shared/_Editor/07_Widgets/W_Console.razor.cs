using System;
using Blazorise;
using Microsoft.AspNetCore.Components;



namespace RootServer.Shared._Editor
{
	public partial class W_Console
    {
		private string? logMessage = "logMessage";
        private string? logDescription = "logDescription";
        private Color logColor = Color.Success;



        [Parameter]
        public string? LogMessage { get { return logMessage; } set { logMessage = value; } }

        [Parameter]
        public string? LogDescription { get { return logDescription; } set { logDescription = value; } }

        [Parameter]
        public Color LogColor { get { return logColor; } set { logColor = value; } }
	}
}

