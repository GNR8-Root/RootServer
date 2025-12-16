using System;
using System.Net.NetworkInformation;
using Blazorise;
using Microsoft.AspNetCore.Components;


namespace RootServer.Shared._Editor
{
	public partial class HP_CurrentPath
    {
        [Parameter]
        public List<Pointer_Service.Pointer> CurrentPath { get; set; } = new();

        [Parameter]
        public string PathDepth { get; set; } = "";
    }
}