using Pstoh.OA.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pstoh.OA.UI.Portal.Controllers
{
    public class OrderInfoController : Controller
    {
		public IOrderInfoService OrderInfoService { get; set; }
        // GET: OrderInfo
        public ActionResult Index()
        {
            return View();
        }
    }
}