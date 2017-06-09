using System.Configuration;
using System.Data.SqlClient;

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
