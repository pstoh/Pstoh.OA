﻿using Pstoh.OA.IBLL;
using Pstoh.OA.Model;
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
			user.ModifyOn = DateTime.Now;
			UserInfoService.Add(user);
			return Content("Ok");
		}
		#endregion
	}
}