using System;
using AirtableApiClient;
using Microsoft.AspNetCore.Components;
using RootServer.Shared.Airtable;



namespace RootServer.Shared._Sites
{
	public class BaseBackground<TYPE> :  ComponentBase
        where TYPE : BaseMediaType
    {
        [Parameter]
        public string? Id { get; set; }

        [Parameter]
        public string? Class { get; set; }

        [Parameter]
        public AirtableRecord<TYPE> Record { get; set; } = new();



        protected string BackgroundColor()
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



        public string Src()
        {
            string r = "";

            if (Record != null)
            {
                if (Record.Fields.FileOverride != null || Record.Fields.FileOverride != default)
                    r = Record.Fields.FileOverride[0].Url;

                else if (Record.Fields.Src != null)
                    r = Record.Fields.Src;
            }
            return r;
        }
    }
}

