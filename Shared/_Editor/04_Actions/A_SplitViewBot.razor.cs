using System;
using System.Net.NetworkInformation;
using Blazorise;
using Microsoft.AspNetCore.Components;



namespace RootServer.Shared._Editor
{ 
    public partial class A_SplitViewBot
    {
        public async Task OnInvoke()
        {
            await EditorViewHandle(Pages.Editor.EditorSplitView.bottomShow, this);
            logCatcher_Service.CatchLog("EDITOR", "focus bot");
            await Task.CompletedTask;
        }
    }
}