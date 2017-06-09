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
            Config = ConfigurationManager.GetSection("DSP") as DspConfiguration ;                       
        }

        private static DspConfiguration Config;

        public static BrandConfiguration GetBrandConfig()
        {
            string brandName = (HttpContext.Current.Session["Brand"] ?? Config.DefaultBrandName).ToString();
            var brandConfig = Config.AllBrands.Cast<BrandConfiguration>().FirstOrDefault(c=>string.Equals(c.BrandName, brandName, StringComparison.InvariantCultureIgnoreCase));
            if(brandConfig == null)
            {
                brandConfig =  Config.AllBrands.Cast<BrandConfiguration>().FirstOrDefault(c=>string.Equals(c.BrandName, Config.DefaultBrandName, StringComparison.InvariantCultureIgnoreCase));
            }

            return brandConfig;
        }
        public static List<string> JobCodeAllowedToLogin()
        {
            return GetBrandConfig().LoginPage.JobCodesAllowedToLogin.Value
                                        .Split(',', ';')
                                        .Select(c => c.Trim())
                                        .ToList();
        }
    }
}