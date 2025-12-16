using System;
using System.Net.NetworkInformation;
using Blazorise;
using Microsoft.AspNetCore.Components;



namespace RootServer.Shared.Airtable
{
	public partial class A_RowDelete
    {
        [Parameter]
        public string Id { get; set; } = "logID";


        bool ReadyToDelete { get; set; }



        public async Task OnInvoke()
        {
            ReadyToDelete = true;
            logCatcher_Service.CatchLog(Id, "sure to deleted?", Color.Warning);
            await Task.CompletedTask;
        }

        public async Task OnCancel()
        {
            ReadyToDelete = false;
            logCatcher_Service.CatchLog(Id, "delete canceled");
            await Task.CompletedTask;
        }

        public async Task OnDelete()
        {
            ReadyToDelete = false;
            await DeleteRow();
            logCatcher_Service.CatchLog(Id, "row is deleted", Color.Danger);
            await Task.CompletedTask;
        }



        public Task DeleteRow()
        {
            return Task.CompletedTask;
        }
    }
}