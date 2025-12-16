using System;
using Blazorise;
using Microsoft.AspNetCore.Components;
using static RootServer.Pages.Editor;
using RootServer.Shared._Core;

//!!!!!! IMPLEMENT IN PROGRAM.CS -> builder.Services.AddScoped<EditorVisibility_Service>();

namespace RootServer.Shared._Editor
{
	public class EditorVisibility_Service
    {
        public bool ShowEditor { get; set; } = true;

        public event Action? EditorVisibilityToggled;



		public void ToggleEditorVisibility(bool _showEditor)
        {
            ShowEditor = _showEditor;

            EditorVisibilityToggled?.Invoke();
        }
    }
}