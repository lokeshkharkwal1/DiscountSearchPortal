using DSP.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace DSP.ViewModel
{
    public class LoginViewModel
    {
        private string _loginEmpId;        

        [DSPRange(DspPage.Login)]        
        public string EmpId
        {
            get {
                return _loginEmpId;
            }
            set{
                _loginEmpId = value.PadLeft(ApplicationVariable.Config.LoginPage.Range.MaxValue.ToString().Length, '0');
            }
        }

        public string FirstName { get; set; }
    }
}