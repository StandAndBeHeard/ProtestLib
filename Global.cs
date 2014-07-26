using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ProtestLib
{
    public class Global
    {
        private static string _connectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];

        public static string ConnectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }

        public static SqlConnection Connection
        {
            get { return new SqlConnection(_connectionString); }
        }
    }
}
