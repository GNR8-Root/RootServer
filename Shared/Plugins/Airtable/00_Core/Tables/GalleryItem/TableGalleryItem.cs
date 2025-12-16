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
	public class TableGalleryItem : AirtableTable<GalleryItemData, GalleryItemService>
    {
        public TableGalleryItem()
        {
            fileName = "galleryItem";
            tableService = new();
            rows = new();
            Air.tables.TryAdd(fileName, this);
        }



        public override async Task GetTable()
        {
            await base.GetTable();

            /*
           Console.WriteLine("GALLERYITEM.Name " + Table.galleryItem[0].Fields.Name);
           Console.WriteLine("GALLERYITEM.Notes " + Table.galleryItem[0].Fields.Notes);
           Console.WriteLine("GALLERYITEM.Button " + Table.galleryItem[0].Fields.Button);
           Console.WriteLine("GALLERYITEM.Header " + Table.galleryItem[0].Fields.Header);
           Console.WriteLine("GALLERYITEM.Body " + Table.galleryItem[0].Fields.Body);

           if (Table.galleryItem[0].Fields.Item != null)
               Console.WriteLine("GALLERYITEM.Item " + Table.galleryItem[0].Fields.Item[0].Filename);

           if (Table.galleryItem[0].Fields.ReferenceGallery != null)
               Console.WriteLine("GALLERYITEM.ReferenceGallery 0 length " + Table.galleryItem[0].Fields.ReferenceGallery.Length);

           if (Table.galleryItem[0].Fields.ReferenceGalleryThumb != null)
               Console.WriteLine("GALLERYITEM.ReferenceGalleryThumb 0 length " + Table.galleryItem[0].Fields.ReferenceGalleryThumb.Length);
           */


        }
    }
}