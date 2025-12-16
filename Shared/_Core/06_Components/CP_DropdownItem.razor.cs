using System;
using System.Threading;
using AirtableApiClient;
using Blazorise;
using Microsoft.AspNetCore.Components;



namespace RootServer.Shared._Core
{
	public partial class CP_DropdownItem
    {
        [Parameter]
        public string Label { get; set; } = "-";

        [Parameter]
        public IconName NameIcon { get; set; } = IconName.Alert;

        [Parameter]
        public string NameIconStr { get; set; } = "";

        [Parameter]
        public EventCallback<IconLabelSet> Callback { get; set; }

        [Parameter]
        public bool ShowIconItem { get; set; }

        [Parameter]
        public string AirtableId { get; set; } = "-";

        [Parameter]
        public string AirtableParentId { get; set; } = "-";



        public class IconLabelSet
        {
            public string Label { get; set; } = "";

            public IconName NameIcon { get; set; } = IconName.Alert;

            public string NameIconStr { get; set; } = "";
        }



        public async Task OnInvoke()
        {
            System.Console.WriteLine($"CP_DropdownItem: {AirtableParentId} / {AirtableId} / {Label}");

            IconLabelSet ils = new()
            {
                Label = Label,
                NameIcon = NameIcon,
                NameIconStr = NameIconStr
            };

            await Callback.InvokeAsync(ils);
        }
    }
}