﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Model1Container : DbContext
    {
        public Model1Container()
            : base("name=Model1Container")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AdminTable> AdminTable { get; set; }
        public virtual DbSet<ChangeDorm> ChangeDorm { get; set; }
        public virtual DbSet<DormInfo> DormInfo { get; set; }
        public virtual DbSet<GuestInfo> GuestInfo { get; set; }
        public virtual DbSet<LeaveInfo> LeaveInfo { get; set; }
        public virtual DbSet<OutInInfo> OutInInfo { get; set; }
        public virtual DbSet<RepairInfo> RepairInfo { get; set; }
        public virtual DbSet<StudentInfo> StudentInfo { get; set; }
        public virtual DbSet<ViolateInfo> ViolateInfo { get; set; }
    }
}
