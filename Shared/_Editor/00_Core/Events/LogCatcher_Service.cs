using System;
using Blazorise;
using Microsoft.AspNetCore.Components;

//!!!!!! IMPLEMENT IN PROGRAM.CS -> builder.Services.AddScoped<LogCatcher_Service>();

namespace RootServer.Shared._Editor
{
	public class LogCatcher_Service
	{
        public string? LogMessage { get; set; } = "logMessage";

        public string? LogDescription { get; set; } = "logDescription";

        public Color LogColor { get; set; } = Color.Dark;

        public event Action? LogCatched;



		public void CatchLog(string _logMessage, string _logDescription, Color _logColor)
		{
            LogMessage = _logMessage.ToUpper();
            LogDescription = _logDescription;
            LogColor = _logColor;

            LogCatched?.Invoke();
        }



        public void CatchLog(string _logMessage, string _logDescription)
        {
            LogMessage = _logMessage.ToUpper();
            LogDescription = _logDescription;
            LogColor = Color.Dark;

            LogCatched?.Invoke();
        }
    }
}