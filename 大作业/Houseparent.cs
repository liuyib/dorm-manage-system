//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfzDemos
{
    using System;
    using System.Collections.Generic;
    
    public partial class Houseparent
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Houseparent()
        {
            this.StudentInfo = new HashSet<StudentInfo>();
        }
    
        public int Id { get; set; }
        public int adminID { get; set; }
        public string name { get; set; }
        public string sex { get; set; }
        public int buildingNum { get; set; }
        public int phoneNum { get; set; }
    
        public virtual AdminTable AdminTable { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentInfo> StudentInfo { get; set; }
    }
}
