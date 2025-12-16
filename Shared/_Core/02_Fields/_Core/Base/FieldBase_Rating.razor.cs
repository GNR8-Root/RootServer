using System;
using AirtableApiClient;
using Blazorise;
using Microsoft.AspNetCore.Components;
using RootServer.Shared._Core;



namespace RootServer.Shared._Core
{
    public abstract partial class FieldBase_Rating
    {
        public int Val { get; set; }

        [Parameter]
        public int InitVal { get; set; }



        protected override Task OnInitializedAsync()
        {
            Val = InitVal;
            return base.OnInitializedAsync();
        }
    }   
}

