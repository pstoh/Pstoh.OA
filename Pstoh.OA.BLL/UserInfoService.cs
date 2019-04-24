using Pstoh.OA.IBLL;
using Pstoh.OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pstoh.OA.Model.Param;

namespace Pstoh.OA.BLL
{
	public partial class UserInfoService : ABaseService<UserInfo>, IUserInfoService
	{

		//protected override void SetCurrentDal()
		//{
		//CurrentDal = DbSession.UserInfoDal;
		//}
		//分页获取数据
		public IQueryable<UserInfo> GetPageData(UserQueryParam queryParam)
		{
			int normalFlag = (int)OA.Model.Enum.DelFlagEnum.Normal;
			var tmp = DbSession.UserInfoDal.GetEntities(u => u.DelFlag == normalFlag);

			if (!String.IsNullOrEmpty(queryParam.SchName))
			{
				tmp = tmp.Where(u => u.UName.Contains(queryParam.SchName));
			}

			if (!String.IsNullOrEmpty(queryParam.SchRemark))
			{
				tmp = tmp.Where(u => u.Remark.Contains(queryParam.SchRemark));
			}

			//分页
			queryParam.Total = tmp.Count();
			return tmp.OrderBy(u=>u.ID)
				.Skip(queryParam.PageSize * (queryParam.PageIndex - 1)).
				Take(queryParam.PageSize).AsQueryable();
		}

		public bool SetRole(int uid, List<int> roleIds)
		{
			var user = CurrentDal.GetEntities(u => u.ID == uid).FirstOrDefault();
			user.RoleInfo.Clear();
			var roles = DbSession.RoleInfoDal.GetEntities(r => roleIds.Contains(r.ID));
			foreach (var item in roles)
			{
				user.RoleInfo.Add(item);
			}
			return DbSession.SaveChange() > 0;
		}
	}
}
