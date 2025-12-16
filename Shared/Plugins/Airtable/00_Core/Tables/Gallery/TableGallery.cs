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
	public class TableGallery : AirtableTable<GalleryData, GalleryService>
    {
        public TableGallery()
        {
            fileName = "gallery";
            tableService = new();
            rows = new();
            Air.tables.TryAdd(fileName, this);
        }



        public override async Task GetTable()
        {
            await base.GetTable();

            /*
            Console.WriteLine("GALLERY.Name " + Table.gallery[0].Fields.Name);
            Console.WriteLine("GALLERY.Publish " + Table.gallery[0].Fields.Publish);
            Console.WriteLine("GALLERY.Notes " + Table.gallery[0].Fields.Notes);
            Console.WriteLine("GALLERY.Button " + Table.gallery[0].Fields.Button);
            Console.WriteLine("GALLERY.Header " + Table.gallery[0].Fields.Header);
            Console.WriteLine("GALLERY.Body " + Table.gallery[0].Fields.Body);
            Console.WriteLine("GALLERY.Icon " + Table.gallery[0].Fields.Icon);


            if (Table.gallery[0].Fields.Thumbnail != null)
                Console.WriteLine("GALLERY.Thumbnail 0 length " + Table.gallery[0].Fields.Thumbnail.Length);

            if (Table.gallery[0].Fields.Items != null)
                Console.WriteLine("GALLERY.Items 0 length " + Table.gallery[0].Fields.Items.Length);

            if (Table.gallery[0].Fields.Filter != null)
                Console.WriteLine("GALLERY.Filter 0 length " + Table.gallery[0].Fields.Filter.Length);
            */
        }
    }
}