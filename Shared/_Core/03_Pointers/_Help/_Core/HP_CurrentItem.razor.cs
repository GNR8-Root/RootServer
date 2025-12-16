using System;
using System.Net.NetworkInformation;
using Blazorise;
using Microsoft.AspNetCore.Components;


namespace RootServer.Shared._Editor
{
	public partial class HP_CurrentItem
    {
        [Parameter]
        public string CurrentMenuItem { get; set; } = "";

        [Parameter]
        public string CurrentParentMenu { get; set; } = "";
    }
}