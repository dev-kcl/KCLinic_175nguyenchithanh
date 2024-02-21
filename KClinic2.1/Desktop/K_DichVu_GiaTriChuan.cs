﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace KClinic2._1.Desktop
{
    public partial class K_DichVu_GiaTriChuan
    {
        [Key]
        public int GiaTriChuan_Id { get; set; }
        public int? DichVu_Id { get; set; }
        [StringLength(500)]
        public string GiaTriDungChung { get; set; }
        [StringLength(150)]
        public string NamMax { get; set; }
        [StringLength(150)]
        public string NamMin { get; set; }
        [StringLength(150)]
        public string NuMax { get; set; }
        [StringLength(150)]
        public string NuMin { get; set; }
        [StringLength(150)]
        public string TreEmMax { get; set; }
        [StringLength(150)]
        public string TreEmMin { get; set; }
        public int? TamNgung { get; set; }
        public int? NguoiTao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgayTao { get; set; }
        public int? NguoiCapNhat { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgayCapNhat { get; set; }
        public int? Huy { get; set; }
        public int? NhoHonBangMin { get; set; }
        public int? LonHonBangMax { get; set; }

        [ForeignKey("DichVu_Id")]
        [InverseProperty("K_DichVu_GiaTriChuan")]
        public virtual K_DichVu DichVu { get; set; }
    }
}