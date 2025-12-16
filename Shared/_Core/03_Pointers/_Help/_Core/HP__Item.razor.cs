using System;
using System.Net.NetworkInformation;
using Blazorise;
using Microsoft.AspNetCore.Components;


namespace RootServer.Shared._Editor
{
	public partial class HP__Item
    {
        [Parameter]
        public Pointer_Service.Pointer Pointer { get; set; } = new();
    }
}