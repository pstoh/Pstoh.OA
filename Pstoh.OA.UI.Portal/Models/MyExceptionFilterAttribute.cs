using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pstoh.OA.UI.Portal.Models
{
	public class MyExceptionFilterAttribute:HandleErrorAttribute
	{
		public override void OnException(ExceptionContext filterContext)
		{
			base.OnException(filterContext);
			Commons.LogHelper.WriteLog(filterContext.Exception.ToString());
		}
	}
}