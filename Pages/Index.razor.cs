using System;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;
using RootServer.Shared.Airtable;



namespace RootServer.Pages
{
	public partial class Index
	{
        string _previousLocation = "";



        private async void Start()
        {
            // await Air.DeSerializeTable();
            //if (Air.Table.agenda == null || Air.Table.agenda.Count < 1)
            //    await Air.GetAirtable();

            await Task.CompletedTask;
        }



        protected override async Task OnInitializedAsync()
        {
            await Air.DeSerializeTables();
            
            await Task.CompletedTask;
        }



        public Index()
		{
            //Start();
        }



        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            System.Console.WriteLine("index: " + navManager.Uri);

            if (firstRender)
            {
                await JS.InvokeAsync<IJSObjectReference>("import", "../js/webflow/webflow.js");
            }
            else if (_previousLocation != navManager.Uri)
            {
                await JS.InvokeVoidAsync("Refresh");
            }

            _previousLocation = navManager.Uri;
        }
    }
}

