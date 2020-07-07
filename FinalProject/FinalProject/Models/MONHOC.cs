﻿//------------------------------------------------------------------------------
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
    using System.ComponentModel.DataAnnotations;

    public partial class MONHOC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MONHOC()
        {
            this.CT_NGANH = new HashSet<CT_NGANH>();
            this.DS_MONHOC_MO = new HashSet<DS_MONHOC_MO>();
        }
        [Required(ErrorMessage = "Cần nhập mã môn học")]
        public string MaMonHoc { get; set; }

        [Required(ErrorMessage = "Cần nhập tên môn học")]
        public string TenMonHoc { get; set; }
        public string MaLoaiMon { get; set; }

        [Required(ErrorMessage = "Cần nhập số tiết")]
        public Nullable<int> SoTiet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_NGANH> CT_NGANH { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DS_MONHOC_MO> DS_MONHOC_MO { get; set; }
        public virtual LOAIMON LOAIMON { get; set; }
    }
}
