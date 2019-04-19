 
namespace Pstoh.OA.IDAL
{
    public partial interface IDbSession
    {
   
	 
		IC__MigrationHistoryDal C__MigrationHistoryDal { get;}
	 
		IOrderInfoDal OrderInfoDal { get;}
	 
		IOrderInfoesDal OrderInfoesDal { get;}
	 
		IUserInfoDal UserInfoDal { get;}
	 
		IUserInfoesDal UserInfoesDal { get;}
	}

}