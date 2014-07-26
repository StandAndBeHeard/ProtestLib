using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ProtestLib
{
    public partial class Participants
    {

        public static Participants ConvertFromDTExtended(DataTable dt)
        {
            Participants result = new Participants();
            foreach (DataRow row in dt.Rows) result.Add(Participant.GetExtended(row));
            return result;
        }

        public static Participants LoadParticipantsExtended(string sql, System.Data.CommandType commandType, System.Data.SqlClient.SqlParameter[] parameters)
        {
            return Participants.ConvertFromDTExtended(Utils.ExecuteQuery(sql, commandType, parameters));
        }

        public static Participants LoadForProtest(int protestId)
        {
            return LoadParticipantsExtended("select p.*, u.UserName, u.Email from Participants p inner join Users u on u.Id=p.UserId WHERE ProtestId=@ProtestId order by p.DateJoined desc", CommandType.Text, new SqlParameter[] { new SqlParameter("@ProtestId", protestId) });
        }

        public Participant GetByUserId(int userId)
        {
            foreach (Participant part in this) if (part.UserId == userId) return part;
            return null;
        }

    }
}
