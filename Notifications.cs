using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ProtestLib
{
    
    public partial class Notifications
    {

        public static Notifications LoadPending()
        {
            return Notifications.Load("SELECT * FROM Notifications WHERE NotificationDate IS NULL", CommandType.Text, null);
        }

        public static void SendPending()
        {
            foreach (Notification notification in Notifications.LoadPending())
            {
                notification.NotificationDate = DateTime.UtcNow;
                try
                {
                    User u = User.Load(notification.UserId);
                    if (u.ContactDemonstrations) notification.Send(u);
                }
                catch { }
                notification.Save();
            }

        }

    }

}
