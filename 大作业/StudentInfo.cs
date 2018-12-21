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
    
    public partial class StudentInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StudentInfo()
        {
            this.ChangeDorm = new HashSet<ChangeDorm>();
            this.DormInfo = new HashSet<DormInfo>();
            this.GuestInfo = new HashSet<GuestInfo>();
            this.LeaveInfo = new HashSet<LeaveInfo>();
        }
    
        public int Id { get; set; }
        public int houseparentID { get; set; }
        public string name { get; set; }
        public string sex { get; set; }
        public int studentNum { get; set; }
        public string department { get; set; }
        public string profession { get; set; }
        public int phoneNum { get; set; }
        public int dormNum { get; set; }
        public int buildingNum { get; set; }
        public string teacherName { get; set; }
        public byte isDormMaster { get; set; }
        public string boardTime { get; set; }
        public int schoolYearSystem { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChangeDorm> ChangeDorm { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DormInfo> DormInfo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GuestInfo> GuestInfo { get; set; }
        public virtual Houseparent Houseparent { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LeaveInfo> LeaveInfo { get; set; }
    }
}
