 
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
	
	public partial class ActionInfoService:ABaseService<ActionInfo>,IActionInfoService //crud
    {
		protected override void SetCurrentDal()
        {
            CurrentDal = DbSession.ActionInfoDal;
        } 
	}
	
	public partial class FileInfoService:ABaseService<FileInfo>,IFileInfoService //crud
    {
		protected override void SetCurrentDal()
        {
            CurrentDal = DbSession.FileInfoDal;
        } 
	}
	
	public partial class MenuInfoService:ABaseService<MenuInfo>,IMenuInfoService //crud
    {
		protected override void SetCurrentDal()
        {
            CurrentDal = DbSession.MenuInfoDal;
        } 
	}
	
	public partial class OrderInfoService:ABaseService<OrderInfo>,IOrderInfoService //crud
    {
		protected override void SetCurrentDal()
        {
            CurrentDal = DbSession.OrderInfoDal;
        } 
	}
	
	public partial class R_UserInfo_ActionInfoService:ABaseService<R_UserInfo_ActionInfo>,IR_UserInfo_ActionInfoService //crud
    {
		protected override void SetCurrentDal()
        {
            CurrentDal = DbSession.R_UserInfo_ActionInfoDal;
        } 
	}
	
	public partial class RoleInfoService:ABaseService<RoleInfo>,IRoleInfoService //crud
    {
		protected override void SetCurrentDal()
        {
            CurrentDal = DbSession.RoleInfoDal;
        } 
	}
	
	public partial class UserInfoService:ABaseService<UserInfo>,IUserInfoService //crud
    {
		protected override void SetCurrentDal()
        {
            CurrentDal = DbSession.UserInfoDal;
        } 
	}
	
	public partial class UserInfoExtService:ABaseService<UserInfoExt>,IUserInfoExtService //crud
    {
		protected override void SetCurrentDal()
        {
            CurrentDal = DbSession.UserInfoExtDal;
        } 
	}
	
	public partial class WF_InstanceService:ABaseService<WF_Instance>,IWF_InstanceService //crud
    {
		protected override void SetCurrentDal()
        {
            CurrentDal = DbSession.WF_InstanceDal;
        } 
	}
	
	public partial class WF_StepService:ABaseService<WF_Step>,IWF_StepService //crud
    {
		protected override void SetCurrentDal()
        {
            CurrentDal = DbSession.WF_StepDal;
        } 
	}
	
	public partial class WF_TempService:ABaseService<WF_Temp>,IWF_TempService //crud
    {
		protected override void SetCurrentDal()
        {
            CurrentDal = DbSession.WF_TempDal;
        } 
	}
}