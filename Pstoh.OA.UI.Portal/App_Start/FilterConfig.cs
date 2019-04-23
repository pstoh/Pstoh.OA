using Pstoh.OA.UI.Portal.Models;
using System.Web;
using System.Web.Mvc;

namespace Pstoh.OA.UI.Portal
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			//filters.Add(new HandleErrorAttribute());
			filters.Add(new UI.Portal.Models.MyExceptionFilterAttribute());
			//filters.Add(new LoginCheckFilter() { IsCheck = true });
		}
	}
}
