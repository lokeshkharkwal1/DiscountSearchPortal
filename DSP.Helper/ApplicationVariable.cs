using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace DSP.Helper
{
    public static class ApplicationVariable
    {
        public static void LoadAll()
        {
            Config = ConfigurationManager.GetSection("DSP") as DspVariableResolve ;
            if(Config != null)
            {
                JobCodeAllowedToLogin = Config.LoginPage.JobCodesAllowedToLogin.Value
                                        .Split(',', ';')
                                        .Select(c => c.Trim())
                                        .ToList();
            }
        }

        public static DspVariableResolve Config { get; set; }
        public static List<string> JobCodeAllowedToLogin { get; set; }
    }
}