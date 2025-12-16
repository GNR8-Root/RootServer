using System;
using AirtableApiClient;
using Blazorise;
using Microsoft.AspNetCore.Components;
using RootServer.Shared._Core;



namespace RootServer.Shared._Core
{
    public partial class APreBase_EditorView
    {
        [Parameter]
        public IconName NameIcon { get; set; }



        public async Task EditorViewHandle(Pages.Editor.EditorSplitView _editorView, APreBase_EditorView _editorViewToggle)
        {
            editorView_Service.ToggleEditorView(_editorView, _editorViewToggle);

            await Task.CompletedTask;
        }
    }
}

