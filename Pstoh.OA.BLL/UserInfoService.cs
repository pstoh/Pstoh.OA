using Pstoh.OA.IBLL;
using Pstoh.OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pstoh.OA.BLL
{
	public partial class UserInfoService : ABaseService<UserInfo>, IUserInfoService
	{
		//protected override void SetCurrentDal()
		//{
			//CurrentDal = DbSession.UserInfoDal;
		//}
	}
}
