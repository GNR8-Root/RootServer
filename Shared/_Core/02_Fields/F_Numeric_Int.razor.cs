using System;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;
using AirtableApiClient;
using Blazorise;
using Microsoft.AspNetCore.Components;
using RootServer.Shared._Core;



namespace RootServer.Shared._Core
{
    public partial class F_Numeric_Int
    {
        [Parameter]
        public EventCallback<int> ValueChanged { get; set; }

        private int? valOld;
        private int? val;

        [Parameter]
        public int? Val { get { return IntChanged(); } set { val = value; } }

        [Parameter]
        public int? Min { get; set; }

        [Parameter]
        public int? Max { get; set; }

        [Parameter]
        public int? Step { get; set; } = 1;

        static int[] Steps = { 1000, 100, 10, 1 };
        static IEnumerable<StepModel> IndexedSteps = Enumerable.Range(1, Steps.Length).Select(x => new StepModel { Name = Steps[x - 1], Id = x });

        int selectedListValue = 4;
        int SelectedListValue
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
            public int Name { get; set; }
        }



        public F_Numeric_Int()
        {
            StepSetter();
            BadgeColor = Color.Primary;
        }



        public int? IntChanged()
        {
            if(valOld != val)
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
        }



        public void OnSetStep(int _step)
        {
            if (_step == 1)
                Step = 1000;
            else if (_step == 2)
                Step = 100;
            else if (_step == 3)
                Step = 10;
            else if (_step == 4)
                Step = 1;
        }
    }
}