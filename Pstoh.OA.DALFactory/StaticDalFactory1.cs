﻿ 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Pstoh.OA.EFDAL;
using Pstoh.OA.IDAL;
using Pstoh.OA.NHDAL;

namespace Pstoh.OA.DALFactory
{
    /// <summary>
    /// 由简单工厂转变成了抽象工厂。
    /// 抽象工厂  VS  简单工厂
    /// 
    /// </summary>
    public partial class StaticDalFactory
    {
   
	
		public static IC__MigrationHistoryDal GetC__MigrationHistoryDal()
		{
			return Assembly.Load(assemblyName).CreateInstance(assemblyName + ".C__MigrationHistoryDal")
				as IC__MigrationHistoryDal;
		}
	
		public static IOrderInfoDal GetOrderInfoDal()
		{
			return Assembly.Load(assemblyName).CreateInstance(assemblyName + ".OrderInfoDal")
				as IOrderInfoDal;
		}
	
		public static IOrderInfoesDal GetOrderInfoesDal()
		{
			return Assembly.Load(assemblyName).CreateInstance(assemblyName + ".OrderInfoesDal")
				as IOrderInfoesDal;
		}
	
		public static IUserInfoDal GetUserInfoDal()
		{
			return Assembly.Load(assemblyName).CreateInstance(assemblyName + ".UserInfoDal")
				as IUserInfoDal;
		}
	
		public static IUserInfoesDal GetUserInfoesDal()
		{
			return Assembly.Load(assemblyName).CreateInstance(assemblyName + ".UserInfoesDal")
				as IUserInfoesDal;
		}
	}
}