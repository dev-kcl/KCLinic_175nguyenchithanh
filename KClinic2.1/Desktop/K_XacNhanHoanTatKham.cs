﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace KClinic2._1.Desktop
{
    public partial class K_XacNhanHoanTatKham
    {
        [Key]
        public int XacNhanKham_Id { get; set; }
        public int? TiepNhan_Id { get; set; }
        public int? KhamBenh_Id { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgayTao { get; set; }
        public int? NguoiTao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgayCapNhat { get; set; }
        public int? NguoiCapNhat { get; set; }
        public int? Huy { get; set; }

        [ForeignKey("KhamBenh_Id")]
        [InverseProperty("K_XacNhanHoanTatKham")]
        public virtual K_KhamBenh KhamBenh { get; set; }
        [ForeignKey("TiepNhan_Id")]
        [InverseProperty("K_XacNhanHoanTatKham")]
        public virtual K_TiepNhan TiepNhan { get; set; }
    }
}