using System;
using System.ComponentModel.DataAnnotations;
using AirtableApiClient;
using Blazorise;
using Microsoft.AspNetCore.Components;
using RootServer.Shared._Core;



namespace RootServer.Shared._Core
{
    public partial class BaseF_Text
	{
        [Parameter]
        public Action<ValidatorEventArgs>? Validator { get; set; }



        public BaseF_Text()
        {
            BadgeColor = Color.Info;
        }
    }
}