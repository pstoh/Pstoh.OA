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
    
    public partial class FileInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FileInfo()
        {
            this.DelFlag = 0;
            this.WF_Instance = new HashSet<WF_Instance>();
        }
    
        public int ID { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public string FilePath { get; set; }
        public string FileSize { get; set; }
        public string Remark { get; set; }
        public short DelFlag { get; set; }
        public System.DateTime SubTime { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WF_Instance> WF_Instance { get; set; }
    }
}
