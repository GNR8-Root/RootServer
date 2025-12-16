using System;
using AirtableApiClient;
using Blazorise;
using Microsoft.AspNetCore.Components;



namespace RootServer.Shared._Core
{
	public partial class CP_Dropdown
    {
        Dropdown dropdown = new();

        [Parameter]
        public string? SelectedItem { get; set; }

        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        [Parameter]
        public IconName NameIcon { get; set; } = IconName.Alert;

        [Parameter]
        public TextColor? ColorIcon { get; set; }

        [Parameter]
        public Color? ColorToggle { get; set; } = Color.Light;

        [Parameter]
        public string Label { get; set; } = "-";

        [Parameter]
        public bool ShowLabel { get; set; }

        [Parameter]
        public bool ShowIconToggle { get; set; }



        public async Task OnInvoke()
        {
            await Task.CompletedTask;
        }



        Task ShowMenu()
        {
            return dropdown.Show();
        }
    }
}