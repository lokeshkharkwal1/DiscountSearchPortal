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
            LogException(ex);
            Response.Redirect("/SearchDiscount/Error", true);
        }

        private void LogException(Exception ex)
        {
            var logLocation =  ApplicationVariable.GetBrandConfig().CustomError.ErrorLogLocation.Value;

            if (!string.IsNullOrEmpty(logLocation))
            {
                var rootPath = Server.MapPath(logLocation);

                var fileName = string.Format("Error_{0}.txt", DateTime.Now.ToString("yyyy-MM-dd"));
                var filePath = Path.Combine(rootPath, fileName);

                if (!Directory.Exists(rootPath))
                {
                    Directory.CreateDirectory(rootPath);                    
                }
                using (FileStream fs = new FileStream(filePath, FileMode.Append, FileAccess.Write))
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.Write(ex.Message);
                    sw.WriteLine();
                    sw.WriteLine(ex.StackTrace);
                    sw.WriteLine();
                }
            }          
        }

    }
}
