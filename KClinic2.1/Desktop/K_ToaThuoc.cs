﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace KClinic2._1.Desktop
{
    public partial class K_ToaThuoc
    {
        public K_ToaThuoc()
        {
            K_BookingDuoc = new HashSet<K_BookingDuoc>();
            K_HoaDonChiTiet = new HashSet<K_HoaDonChiTiet>();
        }

        [Key]
        public int ToaThuoc_Id { get; set; }
        public int? KhamBenh_Id { get; set; }
        [StringLength(50)]
        public string SoThuTuToa { get; set; }
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
        public int? DaCho { get; set; }
        [Column(TypeName = "numeric")]
        [DecimalPrecision(18,2)]
        public decimal? SoLuongDaCho { get; set; }
        public int? DaThanhToan { get; set; }
        public int? NguoiTao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgayTao { get; set; }
        public int? NguoiCapNhat { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgayCapNhat { get; set; }
        public int? Huy { get; set; }

        [ForeignKey("Duoc_Id")]
        [InverseProperty("K_ToaThuoc")]
        public virtual K_DM_Duoc Duoc { get; set; }
        [ForeignKey("KhamBenh_Id")]
        [InverseProperty("K_ToaThuoc")]
        public virtual K_KhamBenh KhamBenh { get; set; }
        [InverseProperty("ToaThuoc")]
        public virtual ICollection<K_BookingDuoc> K_BookingDuoc { get; set; }
        [InverseProperty("ToaThuoc")]
        public virtual ICollection<K_HoaDonChiTiet> K_HoaDonChiTiet { get; set; }
    }
}