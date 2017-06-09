using DSP.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DSP.ViewModel
{
    public class SearchViewModel
    {
        private string _searchEmpId;        

        [DSPRange(DspPage.Search)]        
        public string EmpId
        {
            get
            {
                return _searchEmpId;
            }
            set
            {
                _searchEmpId = value.PadLeft(ApplicationVariable.GetBrandConfig().SearchPage.Range.MaxValue.ToString().Length, '0');
            }
        }


        public SearchResult Result { get; set; }
    }
}