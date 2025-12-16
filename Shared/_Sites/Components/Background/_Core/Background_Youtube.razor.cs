using System;
using AirtableApiClient;
using Microsoft.AspNetCore.Components;
using RootServer.Shared.Airtable;



namespace RootServer.Shared._Sites
{
	public partial class Background_Youtube
    {
		[Parameter]
		public string? Id { get; set; }

		[Parameter]
		public string? Class { get; set; }

        [Parameter]
        public AirtableRecord<MediaYoutubeData> Record { get; set; } = new();



        private string BackgroundColor()
        {
            string r = "";

            if (Record != null && Record.Fields.BackgroundColor != null)
            {
                string id = Record.Fields.BackgroundColor[0];
                string bgColor = Air.Table.colors.CssBackgroundColor(id);

                if (bgColor != null && bgColor != "")
                    r = bgColor;
            }

            return r;
        }



        public string GetAutoPlay()
		{
			string r = "0";

			if (Record != null && Record.Fields.AutoPlay == true)
				r = "1";

			return r;
		}



        public string GetMute()
        {
            string r = "0";

            if (Record != null && Record.Fields.StartMute == true)
                r = "1";

            return r;
        }



        public string GetFullScreen()
        {
            string r = "0";

            if (Record != null && Record.Fields.AllowFullScreen == true)
                r = "1";

            return r;
        }



        public string GetStart()
        {
            string r = "0";

            if(Record!= null && Record.Fields.StartTime != null)
                r = Record.Fields.StartTime.ToString();

            return r;
        }
	}
}

