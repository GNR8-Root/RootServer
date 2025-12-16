using System;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;
using AirtableApiClient;
using Blazorise;
using Microsoft.AspNetCore.Components;
using RootServer.Shared._Core;



namespace RootServer.Shared._Core
{
    public partial class F_Text_Email
	{

        public F_Text_Email()
        {
            BadgeColor = Color.Info;
        }



        public override void ValidateInput(ValidatorEventArgs e)
        {
            var email = Convert.ToString(e.Value);

            e.Status = string.IsNullOrEmpty(email) ? ValidationStatus.None :
                PingHost(email) ? ValidationStatus.Success : ValidationStatus.Error;
        }



        public static bool PingHost(string email)
        {
            bool pingable = false;
            Ping pinger = null;

            if (!string.IsNullOrEmpty(email) && new EmailAddressAttribute().IsValid(email))
            {
                string[] parts = email.Split('@');
                string url = parts[parts.Length - 1];

                try
                {
                    pinger = new Ping();
                    PingReply reply = pinger.Send(url);
                    pingable = reply.Status == IPStatus.Success;
                }
                catch (PingException)
                {
                    // Discard PingExceptions and return false;
                }
                finally
                {
                    if (pinger != null)
                    {
                        pinger.Dispose();
                    }
                }
            }
                
            return pingable;
        }
    }
}