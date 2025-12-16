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
	public class TableSections : AirtableTable<SectionData, SectionService>
    {
        public TableSections()
        {
            fileName = "sections";
            tableService = new();
            rows = new();
            Air.tables.TryAdd(fileName, this);
        }



        public SectionData GetRecord(string _nameField)
        {
            SectionData result = new();

            if (rows != null)
            {
                AirtableRecord<SectionData>? p = rows.SingleOrDefault(t => t.Fields.Name == _nameField);

                if (p != null)
                {
                    result = p.Fields;
                }
            }

            return result;
        }



        public override async Task GetTable()
        {
            await base.GetTable();

            /*
            Console.WriteLine("SECTIONS.Name " + Table.sections[0].Fields.Name);

            if (Table.sections[0].Fields.Pages != null)
                Console.WriteLine("SECTIONS.Pages 0 length " + Table.sections[0].Fields.Pages.Length);

            if (Table.sections[0].Fields.TextButton != null)
                Console.WriteLine("SECTIONS.TextButton 0 length " + Table.sections[0].Fields.TextButton.Length);

            if (Table.sections[0].Fields.TextHeader != null)
                Console.WriteLine("SECTIONS.TextHeader 0 length " + Table.sections[0].Fields.TextHeader.Length);

            if (Table.sections[0].Fields.TextBody != null)
                Console.WriteLine("SECTIONS.TextBody 0 length " + Table.sections[0].Fields.TextBody.Length);

            Console.WriteLine("SECTIONS.TextBody 0 length " + Table.sections[0].Fields.Icon);

            if (Table.sections[0].Fields.ImageThumbnail != null)
                Console.WriteLine("SECTIONS.ImageThumbnail " + Table.sections[0].Fields.ImageThumbnail[0].Filename);

            if (Table.sections[0].Fields.ImagePoster != null)
                Console.WriteLine("SECTIONS.ImagePoster " + Table.sections[0].Fields.ImagePoster[0].Filename);

            if (Table.sections[0].Fields.Video != null)
                Console.WriteLine("SECTIONS.Video " + Table.sections[0].Fields.Video[0].Filename);

            if (Table.sections[0].Fields.TextReference != null)
                Console.WriteLine("SECTIONS.TextReference 0 length " + Table.sections[0].Fields.TextReference.Length);
            */
        }
    }
}