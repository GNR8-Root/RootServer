using System;
using Blazorise;
using Microsoft.AspNetCore.Components;



namespace RootServer.Shared._Editor
{
	public partial class LogCatcher_Listener
    {
        [Parameter]
        public EventCallback<string> SelectedTabChanged { get; set; }

        [Parameter]
        public string Label { get; set; } = "console";



        protected override async Task OnInitializedAsync()
        {
            logCatcher_Service.LogCatched += StateHasChanged;
            await  Task.CompletedTask;
        }



        public void Dispose()
        {
            logCatcher_Service.LogCatched -= StateHasChanged;
        }



        public Task OnClickLog()
        {
            SelectedTabChanged.InvokeAsync(Label);
            return Task.CompletedTask;
        }
    }
}

