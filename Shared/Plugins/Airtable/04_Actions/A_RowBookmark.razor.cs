using System;
using System.Net.NetworkInformation;
using Blazorise;
using Microsoft.AspNetCore.Components;



namespace RootServer.Shared.Airtable
{
	public partial class A_RowBookmark
    {
        public override async Task OnInvoke()
        {
            IconColor = Color.Light;
            IconColorBookMarked = Color.Success;
            IconColorNotBookMarked = Color.Light;
            LogDescription = "row is bookmarked";
            TypeBookmark = SelectionType.row;
            await base.OnInvoke();
        }
    }
}