﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace KClinic2._1.Desktop
{
    public partial class K_CLSKetQua_CDHA
    {
        public K_CLSKetQua_CDHA()
        {
            ZaloFile = new HashSet<ZaloFile>();
        }

        [Key]
        public int CLSKetQua_Id { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgayThucHien { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ThoiGianThucHien { get; set; }
        public int? CLSYeuCau_Id { get; set; }
        public int? TiepNhan_Id { get; set; }
        public int? BenhNhan_id { get; set; }
        public int? KTVThucHien_Id { get; set; }
        public int? BacSiKetLuan_Id { get; set; }
        [Column(TypeName = "ntext")]
        public string KetLuan { get; set; }
        [StringLength(500)]
        public string KetQua { get; set; }
        [Column(TypeName = "ntext")]
        public string MoTa { get; set; }
        [Column(TypeName = "ntext")]
        public string Mota_text { get; set; }
        [Column(TypeName = "ntext")]
        public string GhiChu { get; set; }
        [Column(TypeName = "ntext")]
        public string LoiDan { get; set; }
        public string ChanDoan { get; set; }
        public int? LoaiKetQua_Id { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ThoiGianNhanMau { get; set; }
        public int? LoaiMau { get; set; }
        public int? ChatLuongMau { get; set; }
        public int? NguoiTao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgayTao { get; set; }
        public int? NguoiCapNhat { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgayCapNhat { get; set; }
        public int? Huy { get; set; }
        [Column(TypeName = "ntext")]
        public string DaiTheGPB { get; set; }
        [Column(TypeName = "ntext")]
        public string ViTheGPB { get; set; }
        [StringLength(500)]
        public string TenVo { get; set; }
        public int? NamSinhVo { get; set; }
        public int? NoiLayMauCSYT { get; set; }
        public int? NoiLayMauNha { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgayNhanMau { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgayLayMau { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ThoiGianLayMau { get; set; }
        [StringLength(500)]
        public string NhanXetKhac { get; set; }
        [StringLength(50)]
        public string ViTriLayMau { get; set; }
        [StringLength(50)]
        public string NguoiNhanMau { get; set; }

        [ForeignKey("BacSiKetLuan_Id")]
        [InverseProperty("K_CLSKetQua_CDHA")]
        public virtual K_BacSi BacSiKetLuan { get; set; }
        [ForeignKey("BenhNhan_id")]
        [InverseProperty("K_CLSKetQua_CDHA")]
        public virtual K_BenhNhan BenhNhan { get; set; }
        [ForeignKey("CLSYeuCau_Id")]
        [InverseProperty("K_CLSKetQua_CDHA")]
        public virtual K_CLSYeuCau CLSYeuCau { get; set; }
        [ForeignKey("KTVThucHien_Id")]
        [InverseProperty("K_CLSKetQua_CDHA")]
        public virtual K_KTV KTVThucHien { get; set; }
        [ForeignKey("TiepNhan_Id")]
        [InverseProperty("K_CLSKetQua_CDHA")]
        public virtual K_TiepNhan TiepNhan { get; set; }
        [InverseProperty("CLSKetQuaCDHA")]
        public virtual ICollection<ZaloFile> ZaloFile { get; set; }
    }
}