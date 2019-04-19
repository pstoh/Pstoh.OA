 
using Pstoh.OA.EFDAL;
using Pstoh.OA.IDAL;

namespace Pstoh.OA.DALFactory
{
    public partial class DbSession :IDbSession
    {
   
		
	public IC__MigrationHistoryDal C__MigrationHistoryDal
    {
        get { return StaticDalFactory.GetC__MigrationHistoryDal(); }
    }
		
	public IOrderInfoDal OrderInfoDal
    {
        get { return StaticDalFactory.GetOrderInfoDal(); }
    }
		
	public IOrderInfoesDal OrderInfoesDal
    {
        get { return StaticDalFactory.GetOrderInfoesDal(); }
    }
		
	public IUserInfoDal UserInfoDal
    {
        get { return StaticDalFactory.GetUserInfoDal(); }
    }
		
	public IUserInfoesDal UserInfoesDal
    {
        get { return StaticDalFactory.GetUserInfoesDal(); }
    }
	}
}