using System;
using AirtableApiClient;
using Blazorise;
using Microsoft.AspNetCore.Components;



namespace RootServer.Shared._Core
{
	public partial class TabSimpleIcon
    {
        bool showIcon = true;
        public IconName iconsName = IconName.Alert;

        [Parameter]
        public string? TabName { get; set; }

        [Parameter]
        public string? TabLabel { get; set; }

        [Parameter]
        public string? Tooltip { get; set; }

        [Parameter]
        public IconName IconsName { get { return iconsName; } set { iconsName = value; } }

        [Parameter]
        public TextColor? IconColor { get; set; }

        [Parameter]
        public bool ShowLabel { get; set; }

        [Parameter]
        public bool ShowLabelOnActive { get; set; }

        [Parameter]
        public bool ShowIcon { get { return showIcon; } set { showIcon = value; } }

        [Parameter]
        public Background BackgroundColor { get; set; } = Background.Default;

        [Parameter]
        public EventCallback TabClicked { get; set; }


        public async Task OnInvoke()
        {
            await Task.CompletedTask;
        }
    }
}