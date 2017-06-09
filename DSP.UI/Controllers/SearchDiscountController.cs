using DSP.DB;
using DSP.Helper;
using DSP.ViewModel;
using System.Web.Mvc;
using System.Web.Security;

namespace DSP.UI.Controllers
{


    [SetBrandName]    
    public class SearchDiscountController : Controller
    {

        QueryManager qMgr = null;
        public SearchDiscountController()
        {
            qMgr = new QueryManager();
        }
        // GET: SearchDiscount        
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Search");
            }
            return RedirectToAction ("Login");
        }

        
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Search");
            }
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel loginModel)
        {
            if (ModelState.IsValid)
            {                
                LoginStatus rslt = qMgr.AllowedToLogin(loginModel);
                var msg = string.Empty;
                switch (rslt)
                {
                    case LoginStatus.NotFound:
                        msg = ApplicationVariable.GetBrandConfig().LoginPage.ErrorMessageIfUserNotFound.Value;
                        break;
                    case LoginStatus.NotAllowed:
                        msg = ApplicationVariable.GetBrandConfig().LoginPage.ErrorMessageIfUserNotAllowedToLogin.Value;
                        break;
                    case LoginStatus.Successful:
                        FormsAuthentication.SetAuthCookie(loginModel.FirstName, false);
                        return RedirectToAction("Search");
                        break;                    
                }

                ModelState.AddModelError("EmpId", msg);                
            }            
            return View(loginModel);            
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
            if (ModelState.IsValid)
            {
                SearchStatus rslt = qMgr.DiscountLookup(view);
                if(rslt == SearchStatus.NotFound)
                {
                    ModelState.AddModelError("EmpId", ApplicationVariable.GetBrandConfig().SearchPage.NoResultFound.Value);                
                }
            }            
            return View(view);
        }

        public ActionResult Error(string externalError) 
        {
            return View(model:externalError);
        }

    }
}