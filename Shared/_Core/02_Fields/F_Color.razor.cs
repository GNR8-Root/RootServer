using System;
using System.Net.NetworkInformation;
using AirtableApiClient;
using Blazorise;
using Microsoft.AspNetCore.Components;
using RootServer.Shared._Core;



namespace RootServer.Shared._Core
{
    public partial class F_Color
	{
        [Parameter]
        public EventCallback<string> OnColorChanged { get; set; }

        [Parameter]
        public string[]? Palette { get; set; }

        [Parameter]
        public bool HideAfterPaletteSelect { get; set; }

        [Parameter]
        public bool ShowHueSlider { get; set; }

        [Parameter]
        public bool ShowCancelButton { get; set; }

        [Parameter]
        public bool ShowClearButton { get; set; }

        [Parameter]
        public bool ShowInputField { get; set; }

        [Parameter]
        public bool ShowOpacitySlider { get; set; }

        [Parameter]
        public bool ShowPalette { get; set; }

        [Parameter]
        public bool ShowBootstrapPalette { get; set; }

        

        private string[] BootstrapPalette { get { return CreateBootstrapPalette(); } }



        public F_Color()
        {
            BadgeColor = Color.Dark;
        }







        private string[] CreateBootstrapPalette ()
        {
            //not working need to set somewhere...
            string[] palette = { "", "", "", "", "", "", "", "", "", ""};
            palette[0] = Color.Danger.ToString();
            palette[1] = Color.Dark.ToString();
            palette[2] = Color.Default.ToString();
            palette[3] = Color.Info.ToString();
            palette[4] = Color.Light.ToString();
            palette[5] = Color.Link.ToString();
            palette[6] = Color.Primary.ToString();
            palette[7] = Color.Secondary.ToString();
            palette[8] = Color.Success.ToString();
            palette[9] = Color.Warning.ToString();

            return palette;
        }



        private static String ToHex(System.Drawing.Color c)
        {
            return $"#{c.R:X2}{c.G:X2}{c.B:X2}";
        }
    }
}