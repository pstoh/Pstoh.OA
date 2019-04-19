using Pstoh.OA.EFDAL;
using Pstoh.OA.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pstoh.OA.DALFactory
{
	public  partial class DbSession : IDbSession
	{
		/*
		public IOrderInfoDal OrderInfoDal
		{
			get
			{
				return StaticDalFactory.GetOrderInfoDal();
			}
		}

		public IUserInfoDal UserInfoDal
		{
			get
			{
				return StaticDalFactory.GetUserInfoDal();
			}
		}
		*/
		/// <summary>
		/// 获取当前上下文,进行一次整体提交.
		/// </summary>
		/// <returns></returns>
		public int SaveChange()
		{
			return DbContextFactory.GetCurrentDbContext().SaveChanges();
		}
	}
}
