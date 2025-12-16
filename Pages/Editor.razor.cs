using RootServer.Shared._Core;
using Blazorise;
using RootServer.Shared.Airtable;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace RootServer.Pages
{
    public partial class Editor
    {
        bool ShowEditor { get; set; } = true;
        double editorUpperSplitViewTop = 68;
        double editorUpperSplitViewCenter = 50;
        double editorUpperSplitViewBottom = 24.2;
        EditorSplitView currentView = EditorSplitView.center;
        APreBase_EditorView? viewTop;
        APreBase_EditorView? viewBot;
        string _previousLocation = "";

        protected string editorUpperSplit = "";
        protected string editorDownSplit = "";

        public enum EditorSplitView
        {
            topHide,
            topShow,
            center,
            bottomShow,
            bottomHide
        }



        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JS.InvokeAsync<IJSObjectReference>("import", "../js/webflow/webflow.js");
            }
            else if (_previousLocation != navManager.Uri)
            {
                await JS.InvokeVoidAsync("Refresh");
            }

            _previousLocation = navManager.Uri;
        }



        string BaseSplit(double val)
        {
            return $"height: calc({val.ToString()}% - 5px);";
        } 

        

        protected override async Task OnInitializedAsync()
        {
            await Air.DeSerializeTables();
            editorView_Service.EditorViewToggled += Toggler;
            editorVisibility_Service.EditorVisibilityToggled += StateHasChanged;
            await Task.CompletedTask;
        }



        void Toggler()
        {
            {
                SetEditorAirtableSplit(editorView_Service.EditorView, editorView_Service.EditorViewToggle);
                //refresh ui
                StateHasChanged();
            };
        }



        public void Dispose()
        {
            editorView_Service.EditorViewToggled -= Toggler;
            editorVisibility_Service.EditorVisibilityToggled -= StateHasChanged;
        }



        void SetEditorAirtableSplit(EditorSplitView view, APreBase_EditorView viewToggle)
        {
            if (view == EditorSplitView.topShow)
                ShowTop(view, viewToggle);

            else if (view == EditorSplitView.center)
                ShowCenter(view, viewToggle);

            else if (view == EditorSplitView.bottomShow)
                ShowBot(view, viewToggle);
        }



        void ShowTop(EditorSplitView view, APreBase_EditorView viewToggle)
        {
            viewTop = viewToggle;

            if (currentView == EditorSplitView.bottomHide)
            {
                ShowCenter(view, viewToggle);
            }

            else if (currentView == EditorSplitView.topShow)
            {
                viewTop.NameIcon = IconName.SortUp;
                currentView = EditorSplitView.bottomHide;
                editorUpperSplit = BaseSplit(100);
                editorDownSplit = BaseSplit(0);
            }

            else
            {
                currentView = EditorSplitView.topShow;
                editorUpperSplit = BaseSplit(editorUpperSplitViewTop);
                editorDownSplit = BaseSplit(100 - editorUpperSplitViewTop);
            }
        }



        void ShowCenter(EditorSplitView view, APreBase_EditorView viewToggle)
        {
            currentView = EditorSplitView.center;

            editorUpperSplit = BaseSplit(editorUpperSplitViewCenter);
            editorDownSplit = BaseSplit(100 - editorUpperSplitViewCenter);

            System.Console.WriteLine(editorUpperSplit + " ----- " + editorDownSplit);

            if (viewTop != null)
                viewTop.NameIcon = IconName.SortDown;

            if (viewBot != null)
                viewBot.NameIcon = IconName.SortUp;
        }



        void ShowBot(EditorSplitView view, APreBase_EditorView viewToggle)
        {
            viewBot = viewToggle;

            if (currentView == EditorSplitView.topHide)
            {
                ShowCenter(view, viewToggle);
            }

            else if (currentView == EditorSplitView.bottomShow)
            {
                viewBot.NameIcon = IconName.SortDown;
                currentView = EditorSplitView.topHide;
                editorUpperSplit = BaseSplit(0);
                editorDownSplit = BaseSplit(100);
            }

            else
            {
                currentView = view;
                editorUpperSplit = BaseSplit(editorUpperSplitViewBottom);
                editorDownSplit = BaseSplit(100 - editorUpperSplitViewBottom);
            }
        }
    }
}