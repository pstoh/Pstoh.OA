//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pstoh.OA.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class ActionInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ActionInfo()
        {
            this.DelFlag = 0;
            this.RoleInfo = new HashSet<RoleInfo>();
            this.R_UserInfo_ActionInfo = new HashSet<R_UserInfo_ActionInfo>();
        }
    
        public int ID { get; set; }
        public System.DateTime SubTime { get; set; }
        public System.DateTime ModfiedOn { get; set; }
        public string Remark { get; set; }
        public short DelFlag { get; set; }
        public string Url { get; set; }
        public string HttpMethd { get; set; }
        public string ActionName { get; set; }
        public bool IsMenu { get; set; }
        public string MenuIcon { get; set; }
        public int Sort { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RoleInfo> RoleInfo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<R_UserInfo_ActionInfo> R_UserInfo_ActionInfo { get; set; }
    }
}
