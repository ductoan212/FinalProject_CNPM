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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CNPMEntities : DbContext
    {
        public CNPMEntities()
            : base("name=CNPMEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BAOCAO_SV_NOHP> BAOCAO_SV_NOHP { get; set; }
        public virtual DbSet<CT_NGANH> CT_NGANH { get; set; }
        public virtual DbSet<CT_PHIEUDK> CT_PHIEUDK { get; set; }
        public virtual DbSet<DOITUONG> DOITUONGs { get; set; }
        public virtual DbSet<DS_MONHOC_MO> DS_MONHOC_MO { get; set; }
        public virtual DbSet<HKNH> HKNHs { get; set; }
        public virtual DbSet<HUYEN> HUYENs { get; set; }
        public virtual DbSet<KHOA> KHOAs { get; set; }
        public virtual DbSet<LOAIMON> LOAIMONs { get; set; }
        public virtual DbSet<MONHOC> MONHOCs { get; set; }
        public virtual DbSet<NGANH> NGANHs { get; set; }
        public virtual DbSet<NGUOIDUNG> NGUOIDUNGs { get; set; }
        public virtual DbSet<NHOMNGUOIDUNG> NHOMNGUOIDUNGs { get; set; }
        public virtual DbSet<PHANQUYEN> PHANQUYENs { get; set; }
        public virtual DbSet<PHIEU_DK> PHIEU_DK { get; set; }
        public virtual DbSet<PHIEUTHU> PHIEUTHUs { get; set; }
        public virtual DbSet<SINHVIEN> SINHVIENs { get; set; }
        public virtual DbSet<TINH> TINHs { get; set; }
    }
}
