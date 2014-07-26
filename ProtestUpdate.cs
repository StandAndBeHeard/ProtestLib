using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtestLib
{
    public partial class ProtestUpdate
    {
        public void CreateNotifications(Protest protest)
        {
            foreach (Participant part in Participants.LoadParticipantsByProtestId(this.ProtestId))
            {
                Notification n = new Notification();
                n.Body = this.Body;
                n.CreationDate = DateTime.UtcNow;
                n.Link = System.Configuration.ConfigurationManager.AppSettings["BaseUrl"] + "/demonstrations/" + protest.Url;
                n.Title = "An Update Has Been Posted to '" + protest.Title + "'";
                n.UserId = part.UserId;
                n.Save();
            }
        }
    }
}
