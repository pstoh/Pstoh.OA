using Pstoh.OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pstoh.OA.UI.Portal.Controllers
{
    public class BaseController : Controller
    {
		public bool IsCheckUserLogin = true;
		public UserInfo LoginUser { get; set; }

		protected override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			base.OnActionExecuting(filterContext);
			//校验用户是否已登录
			if (IsCheckUserLogin)
			{
				if (filterContext.HttpContext.Request.Cookies["userLoginId"] == null)
				{
					filterContext.HttpContext.Response.Redirect("/UserLogin/index");
					return;
				}

				String loginId = filterContext.HttpContext.Request.Cookies["userLoginId"].Value;
				UserInfo user = Commons.Cache.CacheHelper.GetCache(loginId) as UserInfo;
				if (user == null)
				{
					filterContext.HttpContext.Response.Redirect("/UserLogin/index");
					return;
				}

				LoginUser = user;
				Commons.Cache.CacheHelper.SetCache(loginId, user, DateTime.Now.AddMinutes(3));
		}
			}
    }
}