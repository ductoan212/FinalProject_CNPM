//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FinalProject.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PHIEUTHU
    {
        public string SoPhieuThu { get; set; }
        public string SoPhieuDK { get; set; }
        public Nullable<System.DateTime> NgayLap { get; set; }
        public Nullable<decimal> SoTienThu { get; set; }
    
        public virtual PHIEU_DK PHIEU_DK { get; set; }
    }
}
