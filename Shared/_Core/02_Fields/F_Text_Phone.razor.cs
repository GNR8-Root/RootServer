using System;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using AirtableApiClient;
using Blazorise;
using Microsoft.AspNetCore.Components;
using RootServer.Shared._Core;



namespace RootServer.Shared._Core
{
    public partial class F_Text_Phone
	{

        public F_Text_Phone()
        {
            BadgeColor = Color.Info;
        }



        public override void ValidateInput(ValidatorEventArgs e)
        {
            var phone = Convert.ToString(e.Value);

            e.Status = string.IsNullOrEmpty(phone) ? ValidationStatus.None :
                IsPhoneNumber(phone) ? ValidationStatus.Success : ValidationStatus.Error;
        }



        public static bool IsPhoneNumber(string number)
        {
            return Regex.Match(number, @"\+(9[976]\d|8[987530]\d|6[987]\d|5[90]\d|42\d|3[875]\d|
                                            2[98654321]\d|9[8543210]|8[6421]|6[6543210]|5[87654321]|
                                            4[987654310]|3[9643210]|2[70]|7|1)\d{1,14}$").Success;
        }
    }
}