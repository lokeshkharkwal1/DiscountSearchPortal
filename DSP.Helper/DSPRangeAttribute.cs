using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DSP.Helper
{    
    public class DSPRangeAttribute : RangeAttribute
    {
        public DSPRangeAttribute(DspPage page)
            : this(ConfigureFor(page))            
        {
            this.ErrorMessage = ConfigureFor(page).Item3;
        }

        private DSPRangeAttribute(Tuple<Int64, Int64, string> minMaxMsg)
            : base(minMaxMsg.Item1, minMaxMsg.Item2)
        {
            this.ErrorMessage = minMaxMsg.Item3;
        }


        public static Tuple<Int64, Int64, string> ConfigureFor(DspPage pageType)
        {
            var config = GetConfig(pageType);
            return GetMinMaxMsg(config, pageType);            
        }

        private static dynamic GetConfig(DspPage page)
        {
            switch (page)
            {
                case DspPage.Login:
                    return ApplicationVariable.GetBrandConfig().LoginPage;
                case DspPage.Search:
                    return ApplicationVariable.GetBrandConfig().SearchPage;
            }
            return null;
        }

        private static Tuple<Int64, Int64, string> GetMinMaxMsg(dynamic config, DspPage pg)
        {
            Int64 min = config.Range.MinValue;
            Int64 max = config.Range.MaxValue;
            string msg = string.Empty;

            msg = string.Format(config.Range.ErrorMessage, min, max);

            return Tuple.Create(min, max, msg);
        }
        
        public override bool IsValid(object value)
        {
            return value!= null && base.IsValid(value);
        }
    }

}