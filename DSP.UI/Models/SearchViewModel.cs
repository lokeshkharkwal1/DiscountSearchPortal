using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DSP.UI.Models
{
    public class SearchViewModel
    {
        [Display(Name = "ASSOCIATE NUMBER")]
        public string AssociateNumber { get; set; }
    }
}