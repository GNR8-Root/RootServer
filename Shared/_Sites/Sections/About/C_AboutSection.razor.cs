using System;
using AirtableApiClient;
using Blazorise;
using Microsoft.AspNetCore.Components;
using RootServer.Shared.Airtable;



namespace RootServer.Shared._Site
{
	public partial class C_AboutSection
    {

        public C_AboutSection()
        {
            System.Console.WriteLine("C_AboutSection : " + Section);

            Class = "section-about";
        }
    }
}

