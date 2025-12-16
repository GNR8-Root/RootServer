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
	public class TableGalleryFilter : AirtableTable<GalleryFilterData, GalleryFilterService>
    {
        public TableGalleryFilter()
        {
            fileName = "galleryFilter";
            tableService = new();
            rows = new();
            Air.tables.TryAdd(fileName, this);
        }



        public override async Task GetTable()
        {
            await base.GetTable();

            /*
            Console.WriteLine("GALLERYFILTER.Name " + Table.galleryFilter[0].Fields.Name);
            Console.WriteLine("GALLERYFILTER.Notes " + Table.galleryFilter[0].Fields.Notes);
            Console.WriteLine("GALLERYFILTER.Icon " + Table.galleryFilter[0].Fields.Icon);

            if (Table.galleryFilter[0].Fields.Gallery != null)
                Console.WriteLine("GALLERYFILTER.Gallery 0 length " + Table.galleryFilter[0].Fields.Gallery.Length);
            */
        }
    }
}