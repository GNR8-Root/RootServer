using System;
using System.Net.NetworkInformation;
using Blazorise;
using Microsoft.AspNetCore.Components;



namespace RootServer.Shared._Editor
{
	public partial class A_ExpandToggleAccordion
    {
        string msg = "single";


        public async Task OnInvoke()
        {
            DataEditor.AccordionSingle = !DataEditor.AccordionSingle;

            if (DataEditor.AccordionSingle == true)
                msg = "single";
            else
                msg = "multi";

            logCatcher_Service.CatchLog("TABLE", $"open {msg}");
            await Task.CompletedTask;
        }
    }
}