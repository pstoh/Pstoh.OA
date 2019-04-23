using Pstoh.OA.IBLL;
using Pstoh.OA.Model;
using Pstoh.OA.Model.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pstoh.OA.UI.Portal.Controllers
{
    public class UserInfoController : Controller  //BaseController
	{
		public IUserInfoService UserInfoService { get; set; }
		public IRoleInfoService RoleInfoService { get; set; }
		public IR_UserInfo_ActionInfoService R_UserInfo_ActionInfoService { get; set; }
		public IActionInfoService ActionInfoService { get; set; }

		// GET: UserInfo
		public ActionResult Index()
        {
			//ViewData.Model = UserInfoService.GetEntities(u => u.ID > 0).ToList();

            return View();
        }

		public ActionResult GetUserInfos()
		{
			int pageSize = int.Parse(Request["rows"] ?? "10");
			int pageIndex= int.Parse(Request["page"] ?? "1");
			int total = 0;
			String sName = Request["sName"];
			String sRemark = Request["sRemark"];

			var queryParam = new UserQueryParam()
			{
				PageIndex = pageIndex,
				PageSize = pageSize,
				Total = total,
				SchName = sName,
				SchRemark = sRemark
			};
			var pageData = UserInfoService.GetPageData(queryParam);
			var tmp = pageData.Select(u => new
			{
				ID = u.ID,
				u.UName,
				u.Remark,
				u.ShowName,
				u.SubTime,
				u.ModfiedOn,
				u.Pwd
			});

			var data = new { total = queryParam.Total, rows = tmp.ToList() };
			return Json(data, JsonRequestBehavior.AllowGet);

		}

		#region 添加用户
		public ActionResult Add()
		{
			return View();
		}
		[HttpPost]
		public ActionResult Add(UserInfo user)
		{
			user.DelFlag = (short)OA.Model.Enum.DelFlagEnum.Normal;
			user.SubTime = DateTime.Now;
			user.ModfiedOn = DateTime.Now;
			UserInfoService.Add(user);
			return Content("Ok");
		}
		#endregion
	}
}