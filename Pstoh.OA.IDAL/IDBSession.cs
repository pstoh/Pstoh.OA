using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pstoh.OA.IDAL
{
	public partial interface IDbSession
	{
		//IUserInfoDal UserInfoDal { get; }

		//IOrderInfoDal OrderInfoDal { get; }
		/// <summary>
		/// 拿到当前上下文,进行一次整体提交.
		/// </summary>
		/// <returns></returns>
		int SaveChange();
	}
}
