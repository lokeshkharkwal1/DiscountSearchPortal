using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DSP.UI;

namespace DSP.UI.Models
{
    public class LoginViewModel
    {
        [Display(Name = "Employee Id *")]
        [DSPRange]        
        public string UserId { get; set; }        
    }
}