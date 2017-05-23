using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DSP.UI
{    
    public class DSPRangeAttribute : RangeAttribute
    {        
        public DSPRangeAttribute()
            :base(ApplicationVariable.Config.MinRange, ApplicationVariable.Config.MaxRange)            
        {
            this.ErrorMessage = ApplicationVariable.Config.ErrorMessage;
        }


        public override bool IsValid(object value)
        {
            return value!= null && base.IsValid(value);
        }
    }
}