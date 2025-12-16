using System;
using System.Net.NetworkInformation;
using Blazorise;
using Microsoft.AspNetCore.Components;



namespace RootServer.Shared._Core
{
	public partial class BasePionter
    {
        /*
        public bool IsActive { get; private set; }
        public bool IsFocused { get; private set; }
        public bool HasChildren { get; private set; }
        public string IDGUI_self { get; private set; } = "";
        public string IDAIRTABLE_self { get; private set; } = "";
        public string IDGUI_parent { get; private set; } = "";
        public string IDAIRTABLE_parent { get; private set; } = "";

        public BasePionter? ActiveChild { get; private set; }

        [Parameter]
        public BasePionter? Parent { get; set; }

        [Parameter]
        public BasePionter? Self { get; set; }

        

        

        */
        [Parameter]
        public string IdMenuItem { get; set; } = "none";

        [Parameter]
        public string IdParentMenu { get; set; } = "none";

        [Parameter]
        public string Label { get; set; } = "label";

        [Parameter]
        public string ToolTip { get; set; } = "label";

        [Parameter]
        public TextColor ColorIcon { get; set; } = TextColor.Default;

        [Parameter]
        public IconName NameIcon { get; set; }

        [Parameter]
        public string NameIconStr { get; set; } = "";

        [Parameter]
        public Background ColorBackground { get; set; } = Background.Default;

        [Parameter]
        public TextColor ColorText { get; set; } = TextColor.Default;

        protected string LogDescription { get; set; } = "label";
        protected Color LogColor { get; set; } = Color.Dark;


        protected override async Task OnInitializedAsync()
        {
            //IDGUI_self = Guid.NewGuid().ToString("N");
            //Self = this;
            //CheckRoot();
            StateHasChanged();
            await Task.CompletedTask;
        }



        public virtual async Task OnInvoke()
        {
            await Task.CompletedTask;
        }



        public virtual async Task PointerAction()
        {
            await Task.CompletedTask;
        }



        public void SetFocused(bool _state)
        {
        }



        public void SetActive(bool _state)
        {
        }



        public void SetActiveChild(BasePionter _child)
        {
        }



        private void CheckRoot()
        {
        }
    }
}