//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sunny.Mvc.ShopCNM.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Provider
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Provider()
        {
            this.DelFlag = true;
            this.Bill = new HashSet<Bill>();
        }
    
        public int Id { get; set; }
        public string PName { get; set; }
        public string LinkMan { get; set; }
        public string LinkPhone { get; set; }
        public string LinkAddress { get; set; }
        public string Fax { get; set; }
        public string Detial { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public Nullable<bool> DelFlag { get; set; }
        public int AddressId { get; set; }
    
        public virtual Address Address { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bill> Bill { get; set; }
    }
}
