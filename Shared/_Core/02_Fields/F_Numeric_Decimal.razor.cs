using System;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;
using AirtableApiClient;
using Blazorise;
using Microsoft.AspNetCore.Components;
using RootServer.Shared._Core;



namespace RootServer.Shared._Core
{
    public partial class F_Numeric_Decimal
    {
        [Parameter]
        public EventCallback<decimal> ValueChanged { get; set; }

        private decimal? valOld;
        private decimal? val;

        [Parameter]
        public decimal? Val { get { return IntChanged(); } set { val = value; } }

        [Parameter]
        public decimal? Min { get; set; }

        [Parameter]
        public decimal? Max { get; set; }

        [Parameter]
        public decimal Step { get; set; } = (decimal)1;

        static string[] Steps = { "1000", "100", "10", "1", ".1", ".01", ".001" };
        static IEnumerable<StepModel> IndexedSteps = Enumerable.Range(1, Steps.Length).Select(x => new StepModel { Name = Steps[x - 1], Id = x });

        decimal selectedListValue;
        decimal SelectedListValue
        {
            get
            {
                OnSetStep(selectedListValue);
                return selectedListValue;
            }
            set
            {
                selectedListValue = value;
                OnSetStep(selectedListValue);
            }
        }



        public class StepModel
        {
            public int Id { get; set; }
            public string Name { get; set; } = "";
        }

        public F_Numeric_Decimal()
        {
            StepSetter();
            BadgeColor = Color.Primary;
        }



        public decimal? IntChanged()
        {
            if (valOld != val)
            {
                //System.Console.WriteLine("changed" + val);
                valOld = val;
                ValueChanged.InvokeAsync();
            }
            return val;
        }


        public void StepSetter()
        {
            if (Step == (decimal)1000)
                SelectedListValue = 1;
            else if (Step == (decimal)100)
                SelectedListValue = 2;
            else if (Step == (decimal)10)
                SelectedListValue = 3;
            else if (Step == (decimal)1)
                SelectedListValue = 4;
            else if (Step == (decimal).1)
                SelectedListValue = 5;
            else if (Step == (decimal).01)
                SelectedListValue = 6;
            else if (Step == (decimal).001)
                SelectedListValue = 7;
        }


        public void OnSetStep(decimal _step)
        {
            if (_step == 1)
                Step = (decimal)1000;
            else if (_step == 2)
                Step = (decimal)100;
            else if (_step == 3)
                Step = (decimal)10;
            else if (_step == 4)
                Step = (decimal)1;
            else if (_step == 5)
                Step = (decimal).1;
            else if (_step == 6)
                Step = (decimal).01;
            else if (_step == 7)
                Step = (decimal).001;
        }
    }
}