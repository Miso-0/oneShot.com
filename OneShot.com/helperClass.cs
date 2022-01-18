using OneShot.com.ServiceReference1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace OneShot.com
{
    public class helperClass
    {
        static List<Item>   FilteredList = new List<Item>();
        static List<string> FiltersSelected = new List<string>();
        static bool emailSent = false;
        public static int numberToShow=16;
        public static string order = "all";
        OneShotServiceClient client = new OneShotServiceClient();
        public static void AddOnList(Item item)
        {
            if (!FilteredList.Exists(i => i.ItemCode.Equals(item.ItemCode)))
            {
                FilteredList.Add(item);
            }
        }

        public static void RemoveItemsFilltered(Item item)
        {
            if (FilteredList.Exists(i => i.ItemCode.Equals(item.ItemCode)))
            {
                FilteredList.Remove(item);
            }
        }

        public static List<string> getFilters()
        {
            return FiltersSelected;
        }

        public static void Addfilter(string name)
        {
            if (!FiltersSelected.Contains(name))
            {
                FiltersSelected.Add(name);
            }
        }
        public static void RemoveListF(string name)
        {
            if (FiltersSelected.Contains(name))
            {
                FiltersSelected.Remove(name);
            }
        }

        public static List<Item> getFilteredList()
        {
            return FilteredList;
        }
        ///Forwards an email to the user
        public static void SendEmail(string toEmail,string CustomerName,string subject,string emailbody)
        {
       
            SmtpClient client = new SmtpClient()
            {
                Host = "smt",
                Port = Port,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential()
                {
                    UserName="email-address",
                    Password= "password"
                }
            };
            MailAddress fromEmail = new MailAddress("email-address", "OneShot.com");
            MailAddress ToEmail = new MailAddress(toEmail,CustomerName);
            MailMessage message = new MailMessage()
            {
                From = fromEmail,
                Subject = subject,
                Body = emailbody
            };
            message.To.Add(ToEmail);
            try
            {
                client.Send(message);
            }catch(Exception e)
            {
                e.GetBaseException();
            }
        }
    }
}
