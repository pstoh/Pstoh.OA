﻿ 
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
   
		
	public partial class ActionInfoDal:BaseDal<ActionInfo>,IActionInfoDal
    {
	}
		
	public partial class FileInfoDal:BaseDal<FileInfo>,IFileInfoDal
    {
	}
		
	public partial class MenuInfoDal:BaseDal<MenuInfo>,IMenuInfoDal
    {
	}
		
	public partial class OrderInfoDal:BaseDal<OrderInfo>,IOrderInfoDal
    {
	}
		
	public partial class R_UserInfo_ActionInfoDal:BaseDal<R_UserInfo_ActionInfo>,IR_UserInfo_ActionInfoDal
    {
	}
		
	public partial class RoleInfoDal:BaseDal<RoleInfo>,IRoleInfoDal
    {
	}
		
	public partial class UserInfoDal:BaseDal<UserInfo>,IUserInfoDal
    {
	}
		
	public partial class UserInfoExtDal:BaseDal<UserInfoExt>,IUserInfoExtDal
    {
	}
		
	public partial class WF_InstanceDal:BaseDal<WF_Instance>,IWF_InstanceDal
    {
	}
		
	public partial class WF_StepDal:BaseDal<WF_Step>,IWF_StepDal
    {
	}
		
	public partial class WF_TempDal:BaseDal<WF_Temp>,IWF_TempDal
    {
	}


}