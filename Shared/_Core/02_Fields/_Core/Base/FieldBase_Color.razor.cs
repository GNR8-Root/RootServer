using System;
using AirtableApiClient;
using Blazorise;
using Microsoft.AspNetCore.Components;
using RootServer.Shared._Core;



namespace RootServer.Shared._Core
{
    public abstract partial class FieldBase_Color
	{
        [Parameter]
        public string Val { get; set; } = "#ff0000";

        [Parameter]
        public string InitVal { get; set; } = "";



        protected override Task OnInitializedAsync()
        {
            Val = InitVal;
            return base.OnInitializedAsync();
        }
    }
}