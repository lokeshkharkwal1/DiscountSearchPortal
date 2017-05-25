using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSP.DB
{
    internal class QueryConst
    {
        private const string LoginQuery = @"SELECT
                                                NameFirst,
                                                ActiveFlag,
                                                JobCode
                                            FROM vw_EmployeeDiscSearch
                                            WHERE EmployeeId=@EmpId";

        private const string DiscountLookupQuery = @"SELECT
                                                        NamePreferred,
                                                        Dept_Desc,
                                                        ActiveFlag,
                                                        NameLast,
                                                        NameFirst
                                                    FROM vw_EmployeeDiscSearch
                                                    WHERE EmployeeId=@SearchId";

        public static SqlCommand GetLoginCommand(SqlConnection con, string empId)
        {

            var cmd = new SqlCommand(LoginQuery, con);
            cmd.Parameters.AddWithValue("@EmpId", empId);
            return cmd;
        }

        public static SqlCommand GetSearchCommand(SqlConnection con, string empId)
        {
            var cmd = new SqlCommand(DiscountLookupQuery, con);
            cmd.Parameters.AddWithValue("@SearchId", empId);
            return cmd;
        }
    }
}
