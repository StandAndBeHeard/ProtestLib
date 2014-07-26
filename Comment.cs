using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ProtestLib
{
    public partial class Comment
    {
        private string _email = "";
        private string _userName = "";
        private Comments _children = null;

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

        public Comments Children
        {
            get { return _children; }
            set { _children = value; }
        }

        internal static Comment GetExtended(DataRow row)
        {
            Comment result = GetComment(row);
            if (row.Table.Columns.Contains("Email") && !Convert.IsDBNull(row["Email"])) result._email = Convert.ToString(row["Email"]);
            if (row.Table.Columns.Contains("UserName") && !Convert.IsDBNull(row["UserName"])) result._userName = Convert.ToString(row["UserName"]);
            return result;
        }

    }
}
