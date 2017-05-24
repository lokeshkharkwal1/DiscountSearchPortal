﻿using System;
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

        private DSPRangeAttribute(Tuple<int, int, string> minMaxMsg)
            : base(minMaxMsg.Item1, minMaxMsg.Item2)
        {
            this.ErrorMessage = minMaxMsg.Item3;
        }


        public static Tuple<int, int, string> ConfigureFor(DspPage pageType)
        {
            var config = GetConfig(pageType);
            return GetMinMaxMsg(config, pageType);            
        }

        private static dynamic GetConfig(DspPage page)
        {
            switch (page)
            {
                case DspPage.Login:
                    return ApplicationVariable.Config.LoginPage;
                case DspPage.Search:
                    return ApplicationVariable.Config.SearchPage;
            }
            return null;
        }

        private static Tuple<int, int, string> GetMinMaxMsg(dynamic config, DspPage pg)
        {
            int min = config.Range.MinValue;
            int max = config.Range.MaxValue;
            string msg = string.Empty;
            msg = string.Format(config.Range.ErrorMessage,
//                                pg == DspPage.Login ? config.LoginFieldLabel.Value : config.SearchFieldLabel.Value,
                                min,
                                max);

            return Tuple.Create(min, max, msg);
        }
        
        public override bool IsValid(object value)
        {
            return value!= null && base.IsValid(value);
        }
    }

}