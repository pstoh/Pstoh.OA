using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pstoh.OA.EFDAL;
using Pstoh.OA.IDAL;
using Pstoh.OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pstoh.OA.EFDAL.Tests
{
	[TestClass()]
	public class BaseDalTests
	{
			IUserInfoDal dal = new UserInfoDal();
		[TestMethod()]
		public void AddTest()
		{

			UserInfo user = new UserInfo();
			user.Name = "月下一棵松";
			bool tag = dal.Add(user);
			Assert.AreEqual(true, tag == true);
		}

		[TestMethod()]
		public void GetPageEntitiesTest()
		{
			var tmp = dal.GetEntities(u=>u.Id>0);
			Assert.AreEqual(true, tmp.Count() >= 2);
		}
	}
}