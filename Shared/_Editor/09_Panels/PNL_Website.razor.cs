using System;
using System.Net.NetworkInformation;
using Blazorise;
using Microsoft.AspNetCore.Components;



namespace RootServer.Shared._Editor
{
	public partial class PNL_Website
    {
        /*
       protected string CurrentMenuItem
       {
           get
           {
               string label = "null";
               if (pointer_Service.CurrentPointer.Self != null)
                   label = pointer_Service.CurrentPointer.Self.IdMenuItem;

               return label;
           }
       }

       protected string CurrentParentMenu { get { return pointer_Service.CurrentPointer.IdParentMenu; } }


       protected Dictionary<string, Dictionary<string, Pointer_Service.Pointer>> AllPointers { get { return pointer_Service.AllPointers; } }

       protected string AmountMenus { get { return pointer_Service.AmountMenus.ToString(); } }

       protected string AmountPointers { get { return pointer_Service.AmountPointers.ToString(); } }

       protected List<Pointer_Service.Pointer> CurrentPath { get { return pointer_Service.CurrentPath; } }

       protected string PathDepth { get { return pointer_Service.PathDepth.ToString(); } }
       */


        protected override async Task OnInitializedAsync()
        {
            pointer_Service.ServiceAction += StateHasChanged;
            await Task.CompletedTask;
        }



        public void Dispose()
        {
            pointer_Service.ServiceAction -= StateHasChanged;
        }
    }
}