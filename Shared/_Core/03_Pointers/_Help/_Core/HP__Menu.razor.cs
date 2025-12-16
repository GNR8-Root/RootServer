using System;
using System.Net.NetworkInformation;
using Blazorise;
using Microsoft.AspNetCore.Components;



namespace RootServer.Shared._Editor
{
	public partial class HP__Menu
    {
        [Parameter]
        public Dictionary<string, Pointer_Service.Pointer> SubPointersEntry { get; set; } = new();

        [Parameter]
        public string PointerId { get; set; } = "";

        [Parameter]
        public RenderFragment? ChildContent { get; set; }
    }
}