//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sunny.ShopCNM.UITest.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class County
    {
        public int Id { get; set; }
        public string CountyName { get; set; }
        public int CityId { get; set; }
        public int AddressId { get; set; }
    
        public virtual City City { get; set; }
        public virtual Address Address { get; set; }
    }
}