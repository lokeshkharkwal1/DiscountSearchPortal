using DSP.UI.Models;
using System;
using System.Collections.Generic;
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
            if(User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Search");
            }
            return View();
        }
        
        
        [HttpPost]
        [ValidateAntiForgeryToken]        
        public ActionResult Login(LoginViewModel loginModel)
        {
            #region validation code goes here. 
            //todo
            #endregion
            
            FormsAuthentication.SetAuthCookie(loginModel.UserId, false);
            return RedirectToAction("Search");
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