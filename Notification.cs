using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace ProtestLib
{
    public partial class Notification
    {
        public void Send(User u)
        {
            MailMessage msg = new MailMessage();
            msg.Body = this.Body.Replace("\n", "<br/>") + "<br/><br/>Click <a href=\"" + this.Link + "\">here</a> to learn more.";
            msg.From = new MailAddress("noreply@standandbeheard.org", "StandAndBeHeard.org");
            msg.IsBodyHtml = true;
            msg.Subject = this.Title;
            msg.To.Add(new MailAddress(u.Email));
            Utils.SendEmail(msg);
        }


    }
}
