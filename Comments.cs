using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ProtestLib
{
    public partial class Comments
    {

        public static Comments ConvertFromDTExtended(DataTable dt)
        {
            Comments result = new Comments();
            foreach (DataRow row in dt.Rows) result.Add(Comment.GetExtended(row));
            
            return result;
        }

        public static Comments LoadExtended(string sql, System.Data.CommandType commandType, System.Data.SqlClient.SqlParameter[] parameters)
        {
            return Comments.ConvertFromDTExtended(Utils.ExecuteQuery(sql, commandType, parameters));
        }

        public static Comments LoadActive(string contentType, int contentId)
        {
            return LoadExtended("SELECT c.*, u.UserName, u.Email FROM Comments c INNER JOIN Users u on u.Id = c.UserId WHERE ContentType=@ContentType AND ContentId=@ContentId and Active=1 ORDER by c.PostedDate", CommandType.Text, new SqlParameter[] { new SqlParameter("@ContentType", contentType), new SqlParameter("@ContentId", contentId) });
        }

        public Comments BuildTree()
        {
            return GetChildren(0, 0);
        }

        private Comments GetChildren(int parentId, int depth)
        {
            Comments result = new Comments();
            foreach (Comment comment in this)
            {
                if (comment.ParentId == parentId)
                {
                    result.Add(comment);
                    Comments children = GetChildren(comment.Id, depth + 1);
                    if (depth < 2) comment.Children = children; else result.AddRange(children);
                }
            }
            return result;
        }


    }
}
