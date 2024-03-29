﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace KClinic2._1.Desktop
{
    public partial class XetNghiemFile
    {
        public XetNghiemFile()
        {
            ZaloFile = new HashSet<ZaloFile>();
        }

        [Key]
        public int FileXetNghiem_Id { get; set; }
        public int? TiepNhan_Id { get; set; }
        public int? BenhNhan_Id { get; set; }
        public string DuongDan { get; set; }
        public int? NguoiTao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgayTao { get; set; }

        [ForeignKey("BenhNhan_Id")]
        [InverseProperty("XetNghiemFile")]
        public virtual K_BenhNhan BenhNhan { get; set; }
        [ForeignKey("TiepNhan_Id")]
        [InverseProperty("XetNghiemFile")]
        public virtual K_TiepNhan TiepNhan { get; set; }
        [InverseProperty("XetNghiemFile")]
        public virtual ICollection<ZaloFile> ZaloFile { get; set; }
    }
}