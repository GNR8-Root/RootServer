using System;
using AirtableApiClient;
using Blazorise;
using Microsoft.AspNetCore.Components;
using RootServer.Shared._Core;



namespace RootServer.Shared._Core
{
    public abstract partial class FieldBase_Toggle
    {
        [Parameter]
        public bool Val { get; set; }
    }
}