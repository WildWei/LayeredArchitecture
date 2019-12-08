using CakeMyBlog.Platform.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication.Controllers.Base
{
    public class BaseController : Controller
    {
        /// <summary>
        /// 執行Action之前
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var userName = filterContext.HttpContext.Session.GetString(MySession.SessionUserName);
            if (userName == null)
            {
                filterContext.HttpContext.Response.Redirect("./Auth/Index");
            }
        }
    }
}
