 
using Pstoh.OA.EFDAL;
using Pstoh.OA.IDAL;

namespace Pstoh.OA.DALFactory
{
    public partial class DbSession :IDbSession
    {
   
		
	public IOrderInfoDal OrderInfoDal
    {
        get { return StaticDalFactory.GetOrderInfoDal(); }
    }
		
	public IUserInfoDal UserInfoDal
    {
        get { return StaticDalFactory.GetUserInfoDal(); }
    }
	}
}