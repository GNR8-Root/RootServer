using System;
using System.Net.NetworkInformation;
using Blazorise;
using Microsoft.AspNetCore.Components;
using RootServer.Shared._Sites;

namespace RootServer.Shared.Airtable
{
	public partial class A_AirtableSync
    {
        protected IconName iconActive = IconName.Cloud;
        protected IconName iconRest = IconName.Cloud;
        protected IconName iconDownload = IconName.Star;
        protected IconName iconUpload = IconName.CloudUploadAlt;
            
        protected string LogDescriptionUploading { get; set; } = "uploading...";
        protected string LogDescriptionSyncing { get; set; } = "logDescription";
        protected string LogDescriptionSuccesUpload { get; set; } = "fully UPLOADED";
        protected string LogDescriptionDownloading { get; set; } = "downloading... ";
        protected string LogDescriptionSuccesDownload { get; set; } = "fully DOWNLOADED";
        protected string Id { get; set; } = "AIRTABLE";



        public async Task OnSyncAirtable()
        {
            logCatcher_Service.CatchLog(Id, LogDescriptionSyncing);
            await UpdateAirtable();
        }



        public async Task UpdateAirtable()
        {
            iconActive = iconUpload;
            logCatcher_Service.CatchLog(Id, LogDescriptionUploading);
            await Task.Delay(1000);
            logCatcher_Service.CatchLog(Id, LogDescriptionSuccesUpload, Color.Success);
            await ReloadAirtable();
        }



        public async Task ReloadAirtable()
        {
            iconActive = iconRest;
            int total = Air.tables.Count;
            int current = 1;

            foreach(KeyValuePair<string, AirtableTableBase> t in Air.tables)
            {
                logCatcher_Service.CatchLog(Id, $"[{current}/{total}] {t.Value.fileName}");
                current++;
                await t.Value.GetTable();
                await t.Value.SerializeTable();
            }

            logCatcher_Service.CatchLog(Id, "done!", Color.Success);
            iconActive = iconRest;
            PagesStatic.ChangeState();
        }
    }
}