using System;
using AirtableApiClient;
using Blazorise;
using Microsoft.AspNetCore.Components;
using RootServer.Shared._Core;



namespace RootServer.Shared._Core
{
    public abstract partial class FieldBase_Date
    {
        [Parameter]
        public DateTime? Val { get; set; }
    }
}

