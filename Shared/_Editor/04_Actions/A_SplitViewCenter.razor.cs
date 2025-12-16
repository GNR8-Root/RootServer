using System;
using System.Net.NetworkInformation;
using Blazorise;
using Microsoft.AspNetCore.Components;



namespace RootServer.Shared._Editor
{
	public partial class A_SplitViewCenter
    {
        public async Task OnInvoke()
        {
            await EditorViewHandle(Pages.Editor.EditorSplitView.center, this);
            logCatcher_Service.CatchLog("EDITOR", "focus center");
            await Task.CompletedTask;
        }
    }
}