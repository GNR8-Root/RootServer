using System;
using AirtableApiClient;
using Blazorise;
using Microsoft.AspNetCore.Components;
using RootServer.Shared._Core;



namespace RootServer.Shared._Core
{
    public abstract partial class FieldBase_Numeric
	{
        [Parameter]
        public string CurrencySymbol { get; set; } = "";

        [Parameter]
        public CurrencySymbolPlacement CurrencySymbolPlacement { get; set; } = CurrencySymbolPlacement.Prefix;

        [Parameter]
        public int Decimals { get; set; } = 2;

        [Parameter]
        public string DecimalSeparator { get; set; } = ".";

        [Parameter]
        public bool EnableStep { get; set; } = true;

        [Parameter]
        public NumericMinMaxLimitsOverride MinMaxLimitsOverride { get; set; } = NumericMinMaxLimitsOverride.DoNotOverride;

        [Parameter]
        public bool ModifyValueOnWheel { get; set; } = true;

        [Parameter]
        public NumericWheelOn WheelOn { get; set; } = NumericWheelOn.Focus;

        [Parameter]
        public NumericRoundingMethod RoundingMethod { get; set; } = NumericRoundingMethod.HalfUpSymmetric;

        [Parameter]
        public bool SelectAllOnFocus { get; set; } = true;

        [Parameter]
        public bool ShowStepButtons { get; set; } = true;

        [Parameter]
        public bool ShowSlider { get; set; } = true;

        [Parameter]
        public bool ShowStepSelector { get; set; } = true;
    }
}

