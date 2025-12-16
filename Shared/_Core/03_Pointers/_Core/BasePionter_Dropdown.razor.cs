using System;
using System.Net.NetworkInformation;
using Blazorise;
using Microsoft.AspNetCore.Components;
using static RootServer.Shared._Core.CP_DropdownItem;



namespace RootServer.Shared._Core
{
	public partial class BasePionter_Dropdown
    {
        Dropdown dropdown = new();

        [Parameter]
        public string SelectedItem { get; set; } = "-";

        [Parameter]
        public string SelectedIcon { get; set; } = "-";

        [Parameter]
        public string Group1Label { get; set; } = "-";

        [Parameter]
        public bool DynamicIcon { get; set; }

        [Parameter]
        public bool ShowLabel { get; set; }

        [Parameter]
        public bool ShowIconToggle { get; set; }

        [Parameter]
        public bool ShowIconGroup { get; set; }

        [Parameter]
        public bool ShowIconItem { get; set; }

        [Parameter]
        public Color ColorToggle { get; set; } = Color.Light;



        public virtual async Task NewItemSelected(IconLabelSet _item)
        {
            SelectedItem = _item.Label;
            logCatcher_Service.CatchLog(SelectedItem, "selected");

            if (DynamicIcon)
                NameIconStr = _item.NameIconStr;

            if (ShowLabel)
                Label = SelectedItem;

            await Task.CompletedTask;
        }



        Task ShowMenu()
        {
            return dropdown.Show();
        }
    }
}