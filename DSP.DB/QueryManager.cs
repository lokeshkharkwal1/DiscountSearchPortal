using DSP.Helper;
using DSP.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSP.DB
{
    public class QueryManager
    {
        DSPConnection conFac;
        public QueryManager()
        {
            conFac = new DSPConnection();
        }

        public LoginStatus AllowedToLogin(LoginViewModel vm)
        {
            using (var con = conFac.GetConnection())
            {
                using (var cmd = QueryConst.GetLoginCommand(con, vm.EmpId))
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (!dr.HasRows)
                    {
                        return LoginStatus.NotFound;
                    }

                    dr.Read();
                    vm.FirstName = dr.GetFieldValue<string>(0).Trim();
                    bool isActive = dr.GetFieldValue<bool>(1);
                    string jobCode = dr.GetFieldValue<string>(2).Trim();

                    if (isActive && ApplicationVariable.JobCodeAllowedToLogin.Any(c => string.Equals(c, jobCode, StringComparison.InvariantCultureIgnoreCase)))
                    {
                        return LoginStatus.Successful;
                    }
                    else
                    {
                        return LoginStatus.NotAllowed;
                    }
                }
            }
        }

        public SearchStatus DiscountLookup(SearchViewModel vm)
        {
            using (var con = conFac.GetConnection())
            {
                using (var cmd = QueryConst.GetSearchCommand(con, vm.EmpId))
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (!dr.HasRows)
                    {
                        return SearchStatus.NotFound;
                    }

                    dr.Read();
                    vm.Result = new SearchResult
                    {
                        PrefName = dr.GetFieldValue<string>(0).Trim(),
                        Location = dr.GetFieldValue<string>(1).Trim(),
                        Discount = dr.GetFieldValue<bool>(2),
                        FirstName = dr.GetFieldValue<string>(3).Trim(),
                        LastName = dr.GetFieldValue<string>(4).Trim()

                    };

                    if (vm.Result.Discount)
                    {
                        return SearchStatus.DiscountAllowed;
                    }
                    else
                    {
                        return SearchStatus.DiscountNotAllowed;
                    }
                }
            }
        }
    }
}
