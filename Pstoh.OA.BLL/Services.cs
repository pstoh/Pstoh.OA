 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pstoh.OA.DALFactory;
//using Pstoh.OA.EFDAL;
using Pstoh.OA.IBLL;
using Pstoh.OA.IDAL;
using Pstoh.OA.Model;
//using Pstoh.OA.NHDAL;

namespace Pstoh.OA.BLL
{
	
	public partial class OrderInfoService:ABaseService<OrderInfo>,IOrderInfoService //crud
    {
		protected override void SetCurrentDal()
        {
            CurrentDal = DbSession.OrderInfoDal;
        } 
	}
	
	public partial class UserInfoService:ABaseService<UserInfo>,IUserInfoService //crud
    {
		protected override void SetCurrentDal()
        {
            CurrentDal = DbSession.UserInfoDal;
        } 
	}
}