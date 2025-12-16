using System;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;
using AirtableApiClient;
using Blazorise;
using Microsoft.AspNetCore.Components;
using RootServer.Shared._Core;



namespace RootServer.Shared._Core
{
    public partial class F_Text_Long
    {
        [Parameter]
        public int Rows { get; set; }

        [Parameter]
        public bool ReplaceTab { get; set; }

        [Parameter]
        public int TabSize { get; set; }

        [Parameter]
        public bool AutoSize { get; set; }



        public F_Text_Long()
        {
            BadgeColor = Color.Info;
        }
    }
}