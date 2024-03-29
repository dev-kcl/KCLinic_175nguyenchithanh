﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace KClinic2._1.Desktop
{
    public partial class K_ThongTinDai
    {
        [Key]
        public int ThongTaiDai_Id { get; set; }
        public int? TiepNhan_Id { get; set; }
        [StringLength(50)]
        public string CanNang { get; set; }
        public int? LoaiSucVatCanId { get; set; }
        [StringLength(500)]
        public string LoaiSucVatCanString { get; set; }
        public int? TinhTrangSucVatHienTaiId { get; set; }
        public int? ViTriCanDauMatCo { get; set; }
        public int? ViTriCanTay { get; set; }
        public int? ViTriCanChan { get; set; }
        public int? ViTriCanThan { get; set; }
        public int? ViTriCanKhac { get; set; }
        public int? TiemPhongTruocCan { get; set; }
        public int? MucDoVetThuongId { get; set; }
        public int? PhanUngPhuTaiChoId { get; set; }
        public int? PhanUngPhuToanThanId { get; set; }
        public int? KhachHangTuVongId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgayBiCan { get; set; }
        [StringLength(500)]
        public string GhiChuTienSu { get; set; }
        public int? Huy { get; set; }

        [ForeignKey("TiepNhan_Id")]
        [InverseProperty("K_ThongTinDai")]
        public virtual K_TiepNhan TiepNhan { get; set; }
    }
}