using Pstoh.OA.IBLL;
using Pstoh.OA.Model;
using Pstoh.OA.UI.Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pstoh.OA.UI.Portal.Controllers
{
	[LoginCheckFilter(IsCheck =false)]
    public class UserLoginController : Controller
    {
		public IUserInfoService UserInfoService { get; set; }
		// GET: UserLogin
		public ActionResult Index()
        {
            return View();
        }

		#region 验证码
		public ActionResult ShowVCodee()
		{
			Commons.ValidateCode validateCode = new Commons.ValidateCode();
			String vc = validateCode.CreateValidateCode(4);
			Session["vCode"] = vc;
			Console.WriteLine(vc);Session["vCode"] = vc; 
			byte[] img = validateCode.CreateValidateGraphic(vc);
			return File(img, @"image/jpeg");
		}
		#endregion

		#region 处理登陆
		public ActionResult ProcessLogin()
		{
			//1.校验验证码
			String validateCode = Request["vCode"];
			String sessionCode = Session["vCode"] as String;
			Session["vCode"] = null;
			if (String.IsNullOrEmpty(sessionCode)||
				validateCode != sessionCode)
			{
				//return Content("验证码错误!");
			}

			//2.校验用户名密码
			String name = Request["loginName"];
			String pwd= Request["loginPwd"];
			short delNormal = (short)OA.Model.Enum.DelFlagEnum.Normal;
			UserInfo user = UserInfoService.GetEntities(u => u.Name == name &&
			  u.Pwd == pwd &&
			  u.DelFlag == delNormal).FirstOrDefault();
			if (user == null)
			{
				return Content("用户名密码错误!");
			}

			//3.保存cookie
			String userLoginId = Guid.NewGuid().ToString();
			Commons.Cache.CacheHelper.AddCache(userLoginId, user, DateTime.Now.AddDays(7));
			Response.Cookies["userLoginId"].Value = userLoginId;

			return Content("Ok");
		}
		#endregion
	}
}