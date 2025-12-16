using System;
using System.Net.NetworkInformation;
using Blazorise;
using Microsoft.AspNetCore.Components;



namespace RootServer.Shared.Airtable
{
	public partial class A_BookmarkDelete
    {
        [Parameter]
        public bool AllowRemoveBookmark { get; set; }

        [Parameter]
        public string Id { get; set; } = "logID";

        bool ReadyToDelete { get; set; }



        public async Task OnInvoke()
        {
            ReadyToDelete = true;
            await DeleteBookmark();
            logCatcher_Service.CatchLog(Id, "bookmark deleted", Color.Danger);
            await Task.CompletedTask;
        }



        public Task DeleteBookmark()
        {
            return Task.CompletedTask;
        }
    }
}