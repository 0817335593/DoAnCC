using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Configuration;

namespace WebQLKhachSan.Models
{
    public static class SMTPHelper
    {
        public static bool SenMail(string MailTo, string contentEmail, string Subject, string MailBCC = null)
        {
            string myEmail = WebConfigurationManager.AppSettings["myEmail"].ToString();
            string myPass = WebConfigurationManager.AppSettings["myPass"].ToString();
            MailMessage msg = new MailMessage()
            {
                From = new MailAddress(myEmail),
                Body = contentEmail,
                IsBodyHtml = true,
                Subject = Subject

            };
            msg.To.Add(MailTo);
            if (!string.IsNullOrWhiteSpace(MailBCC)) msg.Bcc.Add(MailBCC);

            SmtpClient client = new SmtpClient()
            {
                UseDefaultCredentials = true,
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(myEmail, myPass),
                Timeout = 20000
            };
            try
            {
                client.Send(msg);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                msg.Dispose();
            }
        }
    }
}