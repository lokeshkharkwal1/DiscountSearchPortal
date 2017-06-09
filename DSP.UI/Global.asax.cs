using DSP.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace DSP.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            ApplicationVariable.LoadAll();

        }

        void Session_Start(object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.IsAuthenticated)
            {

                //old authentication, kill it
                FormsAuthentication.SignOut();
                //or use Response.Redirect to go to a different page
                FormsAuthentication.RedirectToLoginPage();
                HttpContext.Current.Response.End();
            }

        }

        public void Application_Error()
        {
            var ex = Server.GetLastError();
            var externalError = LogException(ex);
            var urlFormat = "/SearchDiscount/Error{0}";            
            var placeHolder = string.Empty;
            if (!string.IsNullOrEmpty(externalError))
            {
                placeHolder  ="?externalError="+externalError;
            }
            Response.Redirect(string.Format(urlFormat, placeHolder), true); 
        }

        private string LogException(Exception ex)
        {
            string result = string.Empty;

            var logLocation =  ApplicationVariable.GetBrandConfig().CustomError.ErrorLogLocation.Value.Trim();
            #region Remove "/" OR "\" if we have
            if (logLocation.StartsWith("/") || logLocation.StartsWith("\\"))
            {
                logLocation = logLocation.Substring(1).Trim();
            }
            #endregion

            if (!string.IsNullOrEmpty(logLocation))
            {                
                if(!Path.IsPathRooted(logLocation))
                {
                    logLocation = Server.MapPath(string.Format(@"\{0}",logLocation));
                }

                var fileName = string.Format("Error_{0}.txt", DateTime.Now.ToString("yyyy-MM-dd"));
                var filePath = Path.Combine(logLocation, fileName);

                try
                {
                    if (!Directory.Exists(logLocation))
                    {
                        Directory.CreateDirectory(logLocation);
                    }
                    using (FileStream fs = new FileStream(filePath, FileMode.Append, FileAccess.Write))
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.WriteLine("=======================================================");
                        sw.WriteLine(string.Format("Error Occured at - {0}", DateTime.Now));
                        sw.WriteLine("=======================================================");
                        sw.WriteLine(ex.Message);
                        sw.WriteLine(Environment.NewLine + "Details - ");
                        sw.WriteLine(ex.StackTrace);
                        sw.WriteLine("=======================================================");
                        sw.WriteLine(Environment.NewLine + Environment.NewLine + Environment.NewLine);
                    }
                }
                catch (Exception exc)
                {
                    result = exc.Message;
                }   
            }

            return result;
        }        
    }
}
