﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace KClinic2._1.Desktop
{
    public partial class K_BookingDuoc
    {
        [Key]
        public int IDx { get; set; }
        public int? PhienDangNhap_Id { get; set; }
        public int? KhamBenh_Id { get; set; }
        public int? ToaThuoc_Id { get; set; }
        public int? Duoc_Id { get; set; }
        [Column(TypeName = "numeric")]
        [DecimalPrecision(18,2)]
        public decimal? Sang { get; set; }
        [Column(TypeName = "numeric")]
        [DecimalPrecision(18,2)]
        public decimal? Trua { get; set; }
        [Column(TypeName = "numeric")]
        [DecimalPrecision(18,2)]
        public decimal? Chieu { get; set; }
        [Column(TypeName = "numeric")]
        [DecimalPrecision(18,2)]
        public decimal? Toi { get; set; }
        [Column(TypeName = "numeric")]
        [DecimalPrecision(18,2)]
        public decimal? SoNgay { get; set; }
        [Column(TypeName = "numeric")]
        [DecimalPrecision(18,2)]
        public decimal? SoLuong { get; set; }
        [Column(TypeName = "numeric")]
        [DecimalPrecision(18,2)]
        public decimal? DonGia { get; set; }
        [Column(TypeName = "numeric")]
        [DecimalPrecision(18,2)]
        public decimal? ThanhTien { get; set; }
        [StringLength(50)]
        public string ThaoTac { get; set; }
        public int? TrangThai { get; set; }

        [ForeignKey("Duoc_Id")]
        [InverseProperty("K_BookingDuoc")]
        public virtual K_DM_Duoc Duoc { get; set; }
        [ForeignKey("KhamBenh_Id")]
        [InverseProperty("K_BookingDuoc")]
        public virtual K_KhamBenh KhamBenh { get; set; }
        [ForeignKey("PhienDangNhap_Id")]
        [InverseProperty("K_BookingDuoc")]
        public virtual K_PhienDangNhap PhienDangNhap { get; set; }
        [ForeignKey("ToaThuoc_Id")]
        [InverseProperty("K_BookingDuoc")]
        public virtual K_ToaThuoc ToaThuoc { get; set; }
    }
}