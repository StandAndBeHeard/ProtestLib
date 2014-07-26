using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ProtestLib
{
    public partial class Participant
    {

        private string _email = "";
        private string _userName = "";

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        internal static Participant GetExtended(DataRow row)
        {
            Participant result = GetParticipant(row);
            if (row.Table.Columns.Contains("Email") && !Convert.IsDBNull(row["Email"])) result._email = Convert.ToString(row["Email"]);
            if (row.Table.Columns.Contains("UserName") && !Convert.IsDBNull(row["UserName"])) result._userName = Convert.ToString(row["UserName"]);
            return result;
        }



        public static Participant Load(int userId, int protestId)
        {
            Participants parts = Participants.LoadParticipants("SELECT * FROM Participants WHERE UserId=@UserId and ProtestId=@ProtestId", CommandType.Text, new SqlParameter[] { new SqlParameter("@UserId", userId), new SqlParameter("@ProtestId", protestId) });
            return (parts.Count > 0) ? parts[0] : null;
        }

        public static void Join (int userId, Protest protest)
        {
            Participant participant = new ProtestLib.Participant();
            participant.ProtestId = protest.Id;
            participant.UserId = userId;
            participant.DateJoined = DateTime.UtcNow;
            participant.Save();
            protest.UpdateParticipantCount();
        }

    }
}
