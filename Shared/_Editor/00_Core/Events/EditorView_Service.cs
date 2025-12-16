using System;
using Blazorise;
using Microsoft.AspNetCore.Components;
using static RootServer.Pages.Editor;
using RootServer.Shared._Core;

//!!!!!! IMPLEMENT IN PROGRAM.CS -> builder.Services.AddScoped<EditorView_Service>();

namespace RootServer.Shared._Editor
{
	public class EditorView_Service
	{
        public EditorSplitView EditorView { get; set; }

        public APreBase_EditorView EditorViewToggle { get; set; } = new();

        public event Action? EditorViewToggled;



		public void ToggleEditorView(EditorSplitView _editorView, APreBase_EditorView _editorViewToggle)
        {
            EditorView = _editorView;
            EditorViewToggle = _editorViewToggle;

            EditorViewToggled?.Invoke();
        }
    }
}