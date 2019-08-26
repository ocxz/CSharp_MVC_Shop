//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sunny.ShopCNM.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Bill
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bill()
        {
            this.DelFlag = false;
        }
    
        public int Id { get; set; }
        public string BName { get; set; }
        public string ProductUnit { get; set; }
        public Nullable<int> ProductCount { get; set; }
        public decimal TotalMoney { get; set; }
        public bool IsPaid { get; set; }
        public int ProviderId { get; set; }
        public int UserInfoId { get; set; }
        public bool DelFlag { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
    
        public virtual Provider Provider { get; set; }
        public virtual UserInfo UserInfo { get; set; }
    }
}
