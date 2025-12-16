using System;
using System.Net.NetworkInformation;
using Blazorise;
using Microsoft.AspNetCore.Components;



namespace RootServer.Shared._Editor
{
	public partial class HP_Collection
    {
        [Parameter]
        public Dictionary<string, Dictionary<string, Pointer_Service.Pointer>> AllPointers { get; set; } = new();
    }
}