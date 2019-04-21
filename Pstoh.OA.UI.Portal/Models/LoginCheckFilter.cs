using Pstoh.OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pstoh.OA.UI.Portal.Models
{
	public class LoginCheckFilter:ActionFilterAttribute
	{
		public bool IsCheck { get; set; }

		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			base.OnActionExecuting(filterContext);
			if (IsCheck)
			{
				String userId = filterContext.HttpContext.Request.Cookies["userLoginId"]==null?null:filterContext.HttpContext.Request.Cookies["userLoginId"].Value;
				if (userId==null ||
					(Commons.Cache.CacheHelper.GetCache(userId) as UserInfo) == null)
				{
					filterContext.HttpContext.Response.Redirect("/UserLogin/index");
				}
			}
		}
	}
}