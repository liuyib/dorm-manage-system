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
    
    public partial class ChangeDorm
    {
        public int Id { get; set; }
        public int studentID { get; set; }
        public string name { get; set; }
        public string sex { get; set; }
        public int oldDorm { get; set; }
        public int newDorm { get; set; }
        public string changeTime { get; set; }
        public string changeReason { get; set; }
    
        public virtual StudentInfo StudentInfo { get; set; }
    }
}
