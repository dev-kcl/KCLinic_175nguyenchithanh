﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace KClinic2._1.Desktop
{
    public partial class K_DichVu
    {
        public K_DichVu()
        {
            K_Action = new HashSet<K_Action>();
            K_CLSYeuCau = new HashSet<K_CLSYeuCau>();
            K_DichVu_GiaTriChuan = new HashSet<K_DichVu_GiaTriChuan>();
            K_MapNhomBenhDichVu = new HashSet<K_MapNhomBenhDichVu>();
            K_Permission_DichVu = new HashSet<K_Permission_DichVu>();
            K_TuDienKetLuan = new HashSet<K_TuDienKetLuan>();
        }

        [Key]
        public int Dich_Id { get; set; }
        [StringLength(150)]
        public string MaDichVu { get; set; }
        [StringLength(500)]
        public string TenDichVu { get; set; }
        [Column(TypeName = "numeric")]
        [DecimalPrecision(18,2)]
        public decimal? GiaDichVu { get; set; }
        [StringLength(150)]
        public string DVT { get; set; }
        public int? CoGiaTriChuan { get; set; }
        public int? Cap { get; set; }
        public int? IsDichVuCha { get; set; }
        public int? CapTren_Id { get; set; }
        public int? NhomDichVu_Id { get; set; }
        public int? TamNgung { get; set; }
        public int? NguoiTao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgayTao { get; set; }
        public int? NguoiCapNhat { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgayCapNhat { get; set; }
        public int? Huy { get; set; }
        public int? LoaiGia_ID { get; set; }

        [ForeignKey("NhomDichVu_Id")]
        [InverseProperty("K_DichVu")]
        public virtual K_NhomDichVu NhomDichVu { get; set; }
        [InverseProperty("DichVu")]
        public virtual ICollection<K_Action> K_Action { get; set; }
        [InverseProperty("DichVu")]
        public virtual ICollection<K_CLSYeuCau> K_CLSYeuCau { get; set; }
        [InverseProperty("DichVu")]
        public virtual ICollection<K_DichVu_GiaTriChuan> K_DichVu_GiaTriChuan { get; set; }
        [InverseProperty("DichVu")]
        public virtual ICollection<K_MapNhomBenhDichVu> K_MapNhomBenhDichVu { get; set; }
        [InverseProperty("Dich")]
        public virtual ICollection<K_Permission_DichVu> K_Permission_DichVu { get; set; }
        [InverseProperty("DichVu")]
        public virtual ICollection<K_TuDienKetLuan> K_TuDienKetLuan { get; set; }
    }
}