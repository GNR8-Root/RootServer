using System;
using System.Net.NetworkInformation;
using AirtableApiClient;
using Blazorise;
using Microsoft.AspNetCore.Components;
using RootServer.Shared._Core;



namespace RootServer.Shared._Core
{
    public partial class F_Rating
	{
        [Parameter]
        public Color ColorRating { get; set; } = Color.Primary;

        [Parameter]
        public IconName EmptyIcon { get; set; } = IconName.Star;

        [Parameter]
        public IconStyle EmptyIconStyle { get; set; } = IconStyle.Regular;

        [Parameter]
        public IconName FullIcon { get; set; } = IconName.Star;

        [Parameter]
        public IconStyle FullIconStyle { get; set; } = IconStyle.Solid;

        [Parameter]
        public int MaxValue { get; set; } = 10;

        [Parameter]
        public bool ToolTip_Show { get; set; }

        [Parameter]
        public TooltipPlacement Tooltip_Placement { get; set; } = TooltipPlacement.Top;

        [Parameter]
        public bool Tooltip_MultiLine { get; set; }

        [Parameter]
        public bool Tooltip_ShowArrow { get; set; } = true;

        [Parameter]
        public string[] ToolTip_Text { get; set; } =  {
            "Very bad",
            "Very bad",
            "Bad",
            "Bad",
            "Fair",
            "Fair",
            "Good",
            "Good",
            "Very good",
            "Very good"
        };



        public F_Rating()
        {
            BadgeColor = Color.Warning;
        }



        public virtual RatingTooltip GetTooltip(int value)
        {
            if(ToolTip_Show)
                return new RatingTooltip(ToolTip_Text[value - 1], Tooltip_Placement, Tooltip_MultiLine, Tooltip_ShowArrow);

            return null;
        }
    }
}