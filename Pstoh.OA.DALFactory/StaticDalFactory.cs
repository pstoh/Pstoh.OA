using Pstoh.OA.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Pstoh.OA.DALFactory
{
	public  static partial class StaticDalFactory
	{
		private static readonly String assemblyName = System.Configuration.ConfigurationManager.AppSettings["DalAssemblyName"];
		/*
		/// <summary>
		/// 获取UserInfoDal
		/// </summary>
		/// <returns></returns>
		public static IUserInfoDal GetUserInfoDal()
		{
			return System.Reflection.Assembly.Load(assemblyName).CreateInstance(assemblyName + ".UserInfoDal") as IUserInfoDal;
		}
		/// <summary>
		/// 获取OrderInfoDal
		/// </summary>
		/// <returns></returns>
		public static IOrderInfoDal GetOrderInfoDal()
		{
			return Assembly.Load(assemblyName).CreateInstance(assemblyName + ".OrderInfoDal") as IOrderInfoDal;
		}
		*/
	}
}
