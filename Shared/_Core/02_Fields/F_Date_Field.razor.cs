using System;
using System.Net.NetworkInformation;
using AirtableApiClient;
using Blazorise;
using Microsoft.AspNetCore.Components;
using RootServer.Shared._Core;



namespace RootServer.Shared._Core
{
    public partial class F_Date_Field
	{
        void OnDateChanged(DateTime? value)
        {
            Val = value;
        }
    }
}