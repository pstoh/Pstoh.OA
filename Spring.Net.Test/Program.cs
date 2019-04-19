using Spring.Context;
using Spring.Context.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spring.Net.Test
{
	class Program
	{
		static void Main(string[] args)
		{
				IApplicationContext ac = ContextRegistry.GetContext();
			//IUserInfoDal dall = ac.GetObject("UserInfoDal") as IUserInfoDal;
			IUserInfoDal dall2 = ac.GetObject("UserInfoDal1") as IUserInfoDal;
			dall2.Show();

			UserInfoServce dal3 = ac.GetObject("UserInfoServce") as UserInfoServce;
			dal3.Show();
			Console.ReadLine();
		}
	}
}
