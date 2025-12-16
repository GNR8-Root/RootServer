using System;
using AirtableApiClient;
using Blazorise;
using Microsoft.AspNetCore.Components;
using RootServer.Shared._Core;



namespace RootServer.Shared._Core
{
    public abstract partial class FieldBase_String
	{
        [Parameter]
        public string? Val { get; set; }

        [Parameter]
        public int? MaxLength { get; set; }

        [Parameter]
        public TextRole Role { get; set; }



        public virtual void ValidateInput(ValidatorEventArgs e)
        {

        }
    }
}

