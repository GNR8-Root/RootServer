using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Blazorise;
using static RootServer.Pages.Editor;
using RootServer.Shared._Core;
using System.Collections;
using Blazorise.Tailwind.Components;

//!!!!!! IMPLEMENT IN PROGRAM.CS -> builder.Services.AddScoped<Pointer_Service>();

namespace RootServer.Shared._Editor
{
	public class Pointer_Service
    {
        LogCatcher_Service log = new();

        public event Action? ServiceAction;

        public Pointer CurrentPointer { get; set; } = new();

        /*
        public string CurrentMenuItem { get; set; } = "";

        public string CurrentParentMenu { get; set; } = "";

        public List<Pointer> CurrentPath { get; set; } = new();

        public int PathDepth { get { return GetPathDepth(); } }

        public Dictionary<string, Dictionary<string, Pointer>> AllPointers { get; set; } = new();

        public int AmountMenus { get { return GetAmountMenus(); } }

        public int AmountPointers { get { return GetAmountPointers(); } }
        */


        public class Pointer
        {
            public string IdParentMenu { get; set; } = "";

            public BasePionter? Self { get; set; }
        }



        public void PointTowards(BasePionter _self)
        {
            //ServiceAction?.Invoke();
        }

        

        public void RegisterPointer(BasePionter _self)
        {
        }



        private int GetPathDepth()
        {
            int v = 0;//CurrentPath.Count;

            return v;
        }



        private int GetAmountMenus()
        {
            int v = 0; // AllPointers.Count;

            return v;
        }



        private int GetAmountPointers()
        {
            int v = 0;
            return v;
        }



        private void CreatePointer(BasePionter _self)
        {
        }



        private void CreatePath()
        {
        }



        private void GetParents(Pointer p)
        {
        }



        private Pointer SearchParent(string _idParentMenu, Pointer _child)
        {
            Pointer parent = new();
            return parent;
        }



        private void SetAllPointers()
        {
        }



        private void DeactivateAllPointers()
        {
        }
    }
}