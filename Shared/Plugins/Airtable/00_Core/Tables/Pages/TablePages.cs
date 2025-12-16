using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using AirtableApiClient;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System.Buffers.Text;



namespace RootServer.Shared.Airtable
{
	public class TablePages : AirtableTable<PagesData, PagesService>
    {
        public TablePages()
        {
            fileName = "pages";
            tableService = new();
            rows = new();
            Air.tables.TryAdd(fileName, this);
        }



        public override async Task GetTable()
        {
            await base.GetTable();

            /*
            Console.WriteLine("PAGES.Name " + Table.pages[1].Fields.Name);
            Console.WriteLine("PAGES.Template " + Table.pages[1].Fields.Template);
            Console.WriteLine("PAGES.Publish " + Table.pages[1].Fields.Publish);
            Console.WriteLine("PAGES.IsEditor " + Table.pages[1].Fields.IsEditor);
            Console.WriteLine("PAGES.Notes " + Table.pages[1].Fields.Notes);
            Console.WriteLine("PAGES.Pagename " + Table.pages[1].Fields.Pagename);
            Console.WriteLine("PAGES.Slug " + Table.pages[1].Fields.Slug);
            Console.WriteLine("PAGES.SeoTitle " + Table.pages[1].Fields.SeoTitle);
            Console.WriteLine("PAGES.SeoMeta " + Table.pages[1].Fields.SeoMeta);
            Console.WriteLine("PAGES.OpengraphTitle " + Table.pages[1].Fields.OpengraphTitle);
            Console.WriteLine("PAGES.OpengraphTitleIsSeoTitle " + Table.pages[1].Fields.OpengraphTitleIsSeoTitle);
            Console.WriteLine("PAGES.OpengraphDescription " + Table.pages[1].Fields.OpengraphDescription);
            Console.WriteLine("PAGES.OpengraphDescriptionIsSeoDescription " + Table.pages[1].Fields.OpengraphDescriptionIsSeoDescription);
            Console.WriteLine("PAGES.SearchExclude " + Table.pages[1].Fields.SearchExclude);
            Console.WriteLine("PAGES.SearchTitle " + Table.pages[1].Fields.SearchTitle);
            Console.WriteLine("PAGES.SearchDescription " + Table.pages[1].Fields.SearchDescription);
            Console.WriteLine("PAGES.SearchDescriptionIsSeoDescription " + Table.pages[1].Fields.SearchDescriptionIsSeoDescription);
            Console.WriteLine("PAGES.SearchImageIsOpengrapImage " + Table.pages[1].Fields.SearchImageIsOpengrapImage);

            Console.WriteLine("PAGES.SearchImage " + Table.pages[1].Fields.SearchImage[0].Filename);
            Console.WriteLine("PAGES.SearchImage " + Table.pages[1].Fields.SearchImage[0].Id);
            Console.WriteLine("PAGES.SearchImage " + Table.pages[1].Fields.SearchImage[0].Size);
            Console.WriteLine("PAGES.SearchImage " + Table.pages[1].Fields.SearchImage[0].Thumbnails);
            Console.WriteLine("PAGES.SearchImage " + Table.pages[1].Fields.SearchImage[0].Type);
            Console.WriteLine("PAGES.SearchImage " + Table.pages[1].Fields.SearchImage[0].Url);

            Console.WriteLine("PAGES.OpengraphImageUrl1200x630 " + Table.pages[1].Fields.OpengraphImageUrl1200x630.Count);

            Console.WriteLine("PAGES.Sections length " + Table.pages.Count);

            if(Table.pages[0].Fields.Sections != null)
                Console.WriteLine("PAGES.Sections 0 length " + Table.pages[0].Fields.Sections.Length);

            if (Table.pages[1].Fields.Sections != null)
                Console.WriteLine("PAGES.Sections 1 length " + Table.pages[1].Fields.Sections.Length);
            */


            //Console.WriteLine("PAGES.Name " + Table.pages.Where(n => n.Fields.Name == "page").Select());
        }
    }
}