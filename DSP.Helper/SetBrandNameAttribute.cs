using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace DSP.Helper
{
    public class SetBrandNameAttribute : ActionFilterAttribute, IActionFilter
    {        
        private string PropName;
        private string QueryStringParamName;
        public SetBrandNameAttribute(string viewBagPropertyName = "Brand", string queryStringParameterName = "brand")
        {
            PropName = viewBagPropertyName;
            QueryStringParamName = queryStringParameterName;
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = filterContext.HttpContext.Session;
            var viewBagDic = filterContext.Controller.ViewData;

            #region Set brand name
            var brand = filterContext.HttpContext.Request.QueryString[QueryStringParamName];

            if (brand != null)
            {
                session.Add(PropName, brand);
            }
            #endregion

            //#region Set viewbag prop
            //viewBagDic[PropName] = session[PropName] as string ?? ApplicationVariable.Config.DefaultBrandName;
            //#endregion


            base.OnActionExecuting(filterContext);
        }        
    }
}
