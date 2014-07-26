using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ProtestLib
{
    public sealed class ProtestStatus
    {
        public const String Open = "Open";
        public const String Cancelled = "Cancelled";
        public const String Completed = "Completed";
        public const String Failed = "Failed";
        public const String Success = "Success";
    }

    public partial class Protest
    {

        public static Protest Load(string url)
        {
            Protests result = Protests.LoadProtests("SELECT * FROM Protests WHERE Url=@Url", CommandType.Text, new SqlParameter[] { new SqlParameter("@Url", url) });
            return (result.Count>0) ? result[0] : null;
        }

        public void UpdateParticipantCount()
        {
            string previousStatus = this.Status;
            this.CurrentParticipants = Convert.ToInt32(Utils.ExecuteScalar("SELECT COUNT(*) FROM Participants WHERE ProtestId=@ProtestId", CommandType.Text, new SqlParameter[] { new SqlParameter("@ProtestId", this.Id) }));
            if (this.Status == ProtestStatus.Success) {
                if (this.CurrentParticipants < MinParticipants) this.CurrentParticipants = this.MinParticipants;
                if (previousStatus!=ProtestStatus.Success)
                {
                    ProtestLib.ProtestUpdate update = new ProtestLib.ProtestUpdate();
                    update.Body = "Demonstration created.";
                    update.ProtestId = this.Id;
                    update.Save();
                    update.CreateNotifications(this);
                }
            }
            this.Save();
        }


    }
}
