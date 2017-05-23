using DSP.UI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DSP.UI.Controllers
{

    
    public class SearchDiscountController : Controller
    {
        // GET: SearchDiscount
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Search");
            }
            return RedirectToAction("Login");
        }
        

        public ActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]        
        public ActionResult Login(LoginViewModel loginModel)
        {
            if (ModelState.IsValid)
            {
                #region validation code goes here.
                //todo

                var userCount = "No User";
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["test"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("select count(*) from UserProfile", con);

                    con.Open();
                    var count = cmd.ExecuteScalar();

                    userCount = count.ToString();
                    con.Close();
                }

                #endregion
                
                FormsAuthentication.SetAuthCookie(loginModel.UserId, false);
                return RedirectToAction("Search");
            }
            else
            {
                return View(loginModel);
            }
        }

        
        [HttpGet]
        [Authorize]
        public ActionResult Search()
        {                      
            return View();
        }
        
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Search(SearchViewModel view)
        {
            return View();
        }
    }
}