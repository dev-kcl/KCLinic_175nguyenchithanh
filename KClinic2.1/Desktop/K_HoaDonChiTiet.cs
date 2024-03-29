﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace KClinic2._1.Desktop
{
    public partial class K_HoaDonChiTiet
    {
        [Key]
        public int HoaDonChiTiet_Id { get; set; }
        public int? HoaDon_Id { get; set; }
        public int? CLSYeuCau_Id { get; set; }
        public int? ToaThuoc_Id { get; set; }
        public int? TiemChung_Id { get; set; }
        [Column(TypeName = "numeric")]
        [DecimalPrecision(18,2)]
        public decimal? SoLuong { get; set; }
        [Column(TypeName = "numeric")]
        [DecimalPrecision(18,2)]
        public decimal? DonGia { get; set; }
        [Column(TypeName = "numeric")]
        [DecimalPrecision(18,2)]
        public decimal? ThanhTien { get; set; }
        public int? DaHoanTra { get; set; }
        [StringLength(50)]
        public string LoaiHoaDon { get; set; }
        public int? Huy { get; set; }

        [ForeignKey("CLSYeuCau_Id")]
        [InverseProperty("K_HoaDonChiTiet")]
        public virtual K_CLSYeuCau CLSYeuCau { get; set; }
        [ForeignKey("HoaDon_Id")]
        [InverseProperty("K_HoaDonChiTiet")]
        public virtual K_HoaDon HoaDon { get; set; }
        [ForeignKey("TiemChung_Id")]
        [InverseProperty("K_HoaDonChiTiet")]
        public virtual K_TiemChung TiemChung { get; set; }
        [ForeignKey("ToaThuoc_Id")]
        [InverseProperty("K_HoaDonChiTiet")]
        public virtual K_ToaThuoc ToaThuoc { get; set; }
    }
}