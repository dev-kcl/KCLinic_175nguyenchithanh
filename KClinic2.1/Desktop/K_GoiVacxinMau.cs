﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace KClinic2._1.Desktop
{
    public partial class K_GoiVacxinMau
    {
        public K_GoiVacxinMau()
        {
            K_MapGoiVacxinMauVoiDuoc = new HashSet<K_MapGoiVacxinMauVoiDuoc>();
        }

        [Key]
        public int GoiVacxinMau_Id { get; set; }
        [StringLength(150)]
        public string MaGoiVacxinMau { get; set; }
        [StringLength(500)]
        public string TenGoiVacxinMau { get; set; }
        public int? TamNgung { get; set; }
        public int? NguoiTao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgayTao { get; set; }
        public int? NguoiCapNhat { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgayCapNhat { get; set; }
        public int? Huy { get; set; }

        [InverseProperty("GoiVacxinMau")]
        public virtual ICollection<K_MapGoiVacxinMauVoiDuoc> K_MapGoiVacxinMauVoiDuoc { get; set; }
    }
}