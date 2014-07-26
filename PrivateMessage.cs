using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtestLib
{
    public partial class PrivateMessage
    {
        public void GenerateNotification(Comment c, User u)
        {
            Notification n = new Notification();
            if (this.ToId != c.UserId) n.UserId = this.ToId;
            else if (this.FromId != c.UserId) n.UserId = this.FromId;
            else return;

            n.Body = this.Title + "\n\n" + c.Body;
            n.CreationDate = DateTime.UtcNow;
            n.Link = System.Configuration.ConfigurationManager.AppSettings["BaseUrl"] + "/cp/pm.aspx?id=" + this.Id;
            n.Title = u.UserName + " sent you a private message.";
            n.Save();
        }

    }
}
