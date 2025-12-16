using System;
using System.Net.NetworkInformation;
using Blazorise;
using Microsoft.AspNetCore.Components;



namespace RootServer.Shared._Sites
{
	public partial class PAGE_Home
    {
        public PAGE_Home()
        {
            PagesStatic.pages.TryAdd("home", this);
        }



        public override void ChangeState()
        {
            System.Console.WriteLine("PAGE_Home: changedblabla");
            InvokeAsync(StateHasChanged);
        }
    }
}