using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DSP.UI.Models
{
    public class LoginViewModel
    {
        [Display(Name = "Employee Id *")]
        public string UserId { get; set; }        
    }
}