﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace KClinic2._1.Desktop
{
    public partial class K_LoaiDuoc
    {
        public K_LoaiDuoc()
        {
            K_DM_Duoc = new HashSet<K_DM_Duoc>();
        }

        [Key]
        public int LoaiDuoc_Id { get; set; }
        [StringLength(50)]
        public string MaLoaiDuoc { get; set; }
        [StringLength(500)]
        public string TenLoaiDuoc { get; set; }
        public int? TamNgung { get; set; }
        public int? Huy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgayTao { get; set; }
        public int? NguoiTao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgayCapNhat { get; set; }
        public int? NguoiCapNhat { get; set; }

        [InverseProperty("LoaiDuoc")]
        public virtual ICollection<K_DM_Duoc> K_DM_Duoc { get; set; }
    }
}