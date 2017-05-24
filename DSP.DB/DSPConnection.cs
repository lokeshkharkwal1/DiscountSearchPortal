using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSP.DB
{
    internal class DSPConnection
    {
        public SqlConnection GetConnection()
        {
            var connString = ConfigurationManager.ConnectionStrings["DspConnectionString"].ConnectionString;
            return new SqlConnection(connString);
        }        
    }
}
