using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Services;


namespace WSForPortfolio
{
    /// <summary>
    /// Summary description for SmtpWs
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class SmtpWs : System.Web.Services.WebService
    {

        [WebMethod]
        public void SendMail(string name,string ccemailId, string subject, string message)
        {
            MailMessage mail = new MailMessage();
            mail.To.Add("aliraja.hemani@yahoo.com");
            mail.From = new MailAddress("aliraja.arjh@gmail.com");

            SmtpClient client = new SmtpClient();

            client.Port = 587;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("aliraja.arjh", "allahisgreat786110");
            mail.CC.Add(ccemailId);
            mail.Subject = subject;
            string content = name + " is trying to contact us with the request: " + subject + ". <br/> Please contact back on their email id:" + ccemailId+"<br/> Thanks and Regards, <br/> Client Services";
            mail.Body = "Hi, <br/> "+content;
            mail.IsBodyHtml = true;
            client.Send(mail);
        }
    }
}
