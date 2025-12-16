using System;
using System.Net.NetworkInformation;
using Blazorise;
using Microsoft.AspNetCore.Components;
using RootServer.Shared._Core;



namespace RootServer.Shared._Editor
{
	public partial class A_ToggleEditorVisibility
    {
        StateVisibility buttonVariant;
        IconName NameIconOpenEditor = IconName.ArrowLeft;
        IconName NameIconCloseEditor = IconName.ArrowRight;

        //public StateVisibility State { get; set; } = StateVisibility.SetVisible;

        [Parameter]
        public StateVisibility ButtonVariant
        {
            get
            {
                return buttonVariant;
            }
            set
            {
                buttonVariant = value;
                SetIcon(buttonVariant);
            }
        }



        public void SetIcon(StateVisibility _buttonVariant)
        {
            if (_buttonVariant == StateVisibility.SetVisible)
                NameIcon = NameIconOpenEditor;
            else
                NameIcon = NameIconCloseEditor;
        }




        async Task EditorOpen()
        {
            await EditorViewHandle(true);
            logCatcher_Service.CatchLog("EDITOR", "welcome");
            await Task.CompletedTask;
        }



        async Task EditorClose()
        {
            await EditorViewHandle(false);
            logCatcher_Service.CatchLog("EDITOR", "closed");
            await Task.CompletedTask;
        }



        public async Task OnInvoke()
        {
            if(ButtonVariant == StateVisibility.SetVisible)
                await EditorOpen();
            else
                await EditorClose();
        }
    }
}