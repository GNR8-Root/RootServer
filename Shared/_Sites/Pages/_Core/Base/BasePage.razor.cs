using System;
using System.Net.NetworkInformation;
using Blazorise;
using Microsoft.AspNetCore.Components;



namespace RootServer.Shared._Sites
{
	public partial class BasePage
    {
        public virtual void ChangeState()
        {
            InvokeAsync(StateHasChanged);
        }
    }
}