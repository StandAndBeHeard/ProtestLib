using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ProtestLib
{
    public partial class Protests
    {
        public static void UpdateStatus()
        {
            foreach (Protest p in Protests.Load("SELECT * FROM Protests WHERE Status='Open' and CutoffDate < @CutoffDate", CommandType.Text, new SqlParameter[]{new SqlParameter("@CutoffDate", DateTime.UtcNow)}))
            {
                p.Status = ProtestStatus.Failed;
                p.Save();
                ProtestUpdate pu = new ProtestUpdate();
                pu.Body = "Unfortunately, this demonstration did not gain the support it needed to proceed and will not be held.";
                pu.PostedDate = DateTime.UtcNow;
                pu.ProtestId = p.Id;
                pu.Save();
                pu.CreateNotifications(p);
            }
        }

        public static Protests LoadActive()
        {
            return Protests.Load("SELECT * FROM Protests WHERE Status IN ('" + ProtestStatus.Open + "', '" + ProtestStatus.Success + "') ORDER BY ProtestDate", CommandType.Text, null);
        }
    }
}
