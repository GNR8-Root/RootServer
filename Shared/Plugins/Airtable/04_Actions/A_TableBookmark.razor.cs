using System;
using System.Net.NetworkInformation;
using Blazorise;
using Microsoft.AspNetCore.Components;



namespace RootServer.Shared.Airtable
{
	public partial class A_TableBookmark
    {
        public override async Task OnInvoke()
        {
            IconColor = Color.Light;
            IconColorBookMarked = Color.Primary;
            IconColorNotBookMarked = Color.Light;
            LogDescription = "table is bookmarked";
            TypeBookmark = SelectionType.table;
            await base.OnInvoke();
        }
    }
}