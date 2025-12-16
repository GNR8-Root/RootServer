namespace RootServer.Shared.Airtable
{
	public static class Air
	{
        public static readonly string BASE_ID = "appw7gx55EkqWeWrs";
        //#### REQUEST API KEY FROM ARNOLD@ZNZR.IO
        public static string API_KEY = AirtableConfig.ApiKey;

        public static Dictionary<string, AirtableTableBase> tables = new();


        public static class Table
        {
            public static TableApps apps = new();
            public static TableWorkspaces workspaces = new();
            public static TableTables tables = new();

            public static TableMediaCollectionContent mediaCollectionContent = new();
            public static TableMediaCollectionWebsite mediaCollectionWebsite = new();
            public static TableMediaYoutube mediaYoutube = new();
            public static TableMediaImage mediaImage = new();
            public static TableMediaVideo mediaVideo = new();
            public static TableMediaSpline mediaSpline = new();
            public static TableMediaLottie mediaLottie = new();

            public static TableText text = new();
            public static TableSettings settings = new();
            public static TablePages pages = new();
            public static TableSections sections = new();
            public static TableGallery gallery = new();
            public static TableGalleryItem galleryItem = new();
            public static TableGalleryFilter galleryFilter = new();
            public static TableAgenda agenda = new();
            public static TableContact contact = new();
            public static TableColors colors = new();
            public static TableDishIngredients dishIngredients = new();



            public static string PageElement(string page, string element)
            {
                string result = "null";
                var p = pages.rows.SingleOrDefault(t => t.Fields.Name == page);

                if (p != null && element != null)
                    result = (string)p.Fields.GetProperty(element);
                    
                return result;
            }



            public static string PageImage(string page, string element)
            {
                var t = pages.rows.SingleOrDefault(t => t.Fields.Name == page);

                return "aa";
            }
        }



        public static async Task SerializeTables()
        {
            foreach (KeyValuePair<string, AirtableTableBase> t in tables)
                await t.Value.SerializeTable();
        }



        public static async Task DeSerializeTables()
        {
            foreach (KeyValuePair<string, AirtableTableBase> t in tables)
                await t.Value.DeSerializeTable();
        }



        public static async Task GetTables()
        {
            foreach (KeyValuePair<string, AirtableTableBase> t in tables)
                await t.Value.GetTable();
        }



        public static async Task SetAirtable()
        {
            //SET ALL TABLES + RECORDS TO AIRTABLE
            //status writing tables

            await GetTables();
        }
    }
}