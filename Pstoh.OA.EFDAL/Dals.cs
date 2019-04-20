 
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Pstoh.OA.IDAL;
using Pstoh.OA.Model;

namespace Pstoh.OA.EFDAL
{
   
		
	public partial class OrderInfoDal:BaseDal<OrderInfo>,IOrderInfoDal
    {
	}
		
	public partial class UserInfoDal:BaseDal<UserInfo>,IUserInfoDal
    {
	}


}