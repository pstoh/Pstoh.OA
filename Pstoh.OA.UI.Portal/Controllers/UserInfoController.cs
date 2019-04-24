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

		#region 修改
		public ActionResult Edit(int id)
		{
			ViewData.Model = UserInfoService.GetEntities(u => u.ID == id).FirstOrDefault();
			return View();
		}

		[HttpPost]
		public ActionResult Edit(UserInfo user)
		{
			UserInfoService.Update(user);
			return Content("OK");
		}
		#endregion

		#region 删除
		[HttpPost]
		public ActionResult Delete(String uid)
		{
			if (String.IsNullOrEmpty(uid))
			{
				return Content("请选择要删除的条目!");
			}

			String[] strIds = uid.Split(',');
			List<int> idList = new List<int>();
			foreach (var item in strIds)
			{
				idList.Add(int.Parse(item));
			}

			UserInfoService.DeleteListByIds(idList);
			return Content("OK");
		}
		#endregion

		#region 给用户设置角色
		public ActionResult SetRole(int id)
		{
			//1.找到要设置角色的用户
			var user = UserInfoService.GetEntities(u => u.ID == id).FirstOrDefault();
			//2.将所有角色发送到前台
			int normal = (int)OA.Model.Enum.DelFlagEnum.Normal;
			ViewBag.AllRoles = RoleInfoService.GetEntities(r => r.DelFlag == normal).ToList();
			//用户关联的权限
			ViewBag.ExitsRoles = (from r in user.RoleInfo
								  select r.ID).ToList();
				return View(user);
		}
		//给用户设置权限
		public ActionResult ProcessSetRole(int uid)
		{
			List<int> roleIds = new List<int>();
			foreach (var key in Request.Form.AllKeys)
			{
				if (key.StartsWith("ckb_"))
				{
					roleIds.Add(int.Parse(key.Replace("ckb_","")));
				}
			}
			UserInfoService.SetRole(uid, roleIds);
			return Content("OK");
		}
		#endregion

		#region 设置特殊权限
		public ActionResult  SetAction(int uid)
		{
			ViewBag.User = UserInfoService.GetEntities(u => u.ID == uid).FirstOrDefault();
			int normal = (int)OA.Model.Enum.DelFlagEnum.Normal;ViewData.Model = ActionInfoService.GetEntities(a => a.DelFlag == normal).ToList();
			return View();
		}

		public ActionResult  DeleteUserAction(int uid,int actionId)
		{
			var rUser = R_UserInfo_ActionInfoService.GetEntities(r => r.ActionInfoID == actionId &&
			  r.UserInfoID == uid).FirstOrDefault();

			if (rUser!=null)
			{
				R_UserInfo_ActionInfoService.Delete(rUser.ID);
			}

			return Content("OK");
		}
		//当前用户设置特殊权限
		public ActionResult SetUserAction(int uid,int aid,int value)
		{
			int normal = (int)OA.Model.Enum.DelFlagEnum.Normal;
			var rUser = R_UserInfo_ActionInfoService.GetEntities(r => r.UserInfoID == uid &&
			  r.ActionInfoID == aid &&
			  r.DelFlag == normal).FirstOrDefault();

			if (rUser != null)
			{
				rUser.HasPermission = value == 0 ? true : false;
				R_UserInfo_ActionInfoService.Update(rUser);
			}
			else
			{
				R_UserInfo_ActionInfo tmp = new R_UserInfo_ActionInfo();
				tmp.UserInfoID = uid;
				tmp.ActionInfoID = aid;
				tmp.HasPermission = value == 0 ? true : false;
				R_UserInfo_ActionInfoService.Add(tmp);
			}
			return Content("OK");
		}
		#endregion
	}
}