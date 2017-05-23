using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DSP.UI
{

    public class AllConfigSection
    {        
        public int MinRange { get; set; }
        public int MaxRange { get; set; }
        public string ErrorMessage { get; set; }

        public void LoadDummy()
        {
            MinRange = 1;
            MaxRange = 999999;
            ErrorMessage = string.Format("Value should be greater than {0} and less than {1}", MinRange, MaxRange);
        }
    }


    public static class ApplicationVariable
    {
        public static void LoadAll()
        {
            Config = new AllConfigSection();
            Config.LoadDummy();
        }
        public static AllConfigSection Config { get; set; }
    }
}