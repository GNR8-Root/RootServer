using System;
using AirtableApiClient;
using Blazorise;
using Microsoft.AspNetCore.Components;
using RootServer.Shared._Core;



namespace RootServer.Shared._Core
{
    public partial class APreBase_EditorVisibility
    {
        [Parameter]
        public IconName NameIcon { get; set; }



        public async Task EditorViewHandle(bool _showEditor)
        {
            editorVisibility_Service.ToggleEditorVisibility(_showEditor);

            await Task.CompletedTask;
        }
    }
}

