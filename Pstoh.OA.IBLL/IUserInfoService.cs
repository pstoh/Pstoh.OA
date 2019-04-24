using Pstoh.OA.Model;
using Pstoh.OA.Model.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pstoh.OA.IBLL
{
	public partial interface IUserInfoService:IBaseService<UserInfo>
	{
		/// <summary>
		/// 分页获取数据
		/// </summary>
		/// <param name="queryParam"></param>
		/// <returns></returns>
		IQueryable<UserInfo> GetPageData(UserQueryParam queryParam);
		/// <summary>
		/// 给用户设置权限
		/// </summary>
		/// <param name="uid"></param>
		/// <param name="roleIds"></param>
		bool  SetRole(int uid, List<int> roleIds);

	}
}
