using System;
using System.Net.NetworkInformation;
using Blazorise;
using Microsoft.AspNetCore.Components;



namespace RootServer.Shared._Editor
{ 
    public partial class A_SplitViewTop
    {
        public async Task OnInvoke()
        {
            await EditorViewHandle(Pages.Editor.EditorSplitView.topShow, this);
            logCatcher_Service.CatchLog("EDITOR", "focus top");
            await Task.CompletedTask;
        }
    }
}