using Pstoh.OA.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pstoh.OA.UI.Portal.Controllers
{
    public class UserInfoController : Controller
    {
		public IUserInfoService UserInfoService { get; set; }
        // GET: UserInfo
        public ActionResult Index()
        {
			ViewData.Model = UserInfoService.GetEntities(u => u.Id > 0).ToList();

            return View();
        }
    }
}