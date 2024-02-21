﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace KClinic2._1.Desktop
{
    public partial class K_CLSKetQua
    {
        public K_CLSKetQua()
        {
            K_CLSKetQua_CDHAHinhAnh = new HashSet<K_CLSKetQua_CDHAHinhAnh>();
            K_KetQuaGiaiPhauBenh = new HashSet<K_KetQuaGiaiPhauBenh>();
            ZaloFile = new HashSet<ZaloFile>();
        }

        [Key]
        public int CLSKetQua_Id { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgayThucHien { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ThoiGianThucHien { get; set; }
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
        public string NhanXetKhac { get; set; }
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
        public int? checkbox1 { get; set; }
        public int? checkbox2 { get; set; }
        public int? checkbox3 { get; set; }
        public int? checkbox4 { get; set; }
        public int? checkbox5 { get; set; }
        public int? checkbox6 { get; set; }
        public int? checkbox7 { get; set; }
        public int? checkbox8 { get; set; }
        public int? checkbox9 { get; set; }
        public int? checkbox10 { get; set; }
        public int? checkbox11 { get; set; }
        public int? checkbox12 { get; set; }
        public int? checkbox13 { get; set; }
        public int? checkbox14 { get; set; }
        public int? checkbox15 { get; set; }
        public int? checkbox16 { get; set; }
        public int? checkbox17 { get; set; }
        public int? checkbox18 { get; set; }
        public int? checkbox19 { get; set; }
        public int? checkbox20 { get; set; }
        public int? checkbox21 { get; set; }
        public int? checkbox22 { get; set; }
        public int? checkbox23 { get; set; }
        public int? checkbox24 { get; set; }
        public int? checkbox25 { get; set; }
        public int? checkbox26 { get; set; }
        public int? checkbox27 { get; set; }
        public int? checkbox28 { get; set; }
        public int? checkbox29 { get; set; }
        public int? checkbox30 { get; set; }
        public int? checkbox31 { get; set; }
        public int? checkbox32 { get; set; }
        public int? checkbox33 { get; set; }
        public int? checkbox34 { get; set; }
        public int? checkbox35 { get; set; }
        public int? checkbox36 { get; set; }
        public int? checkbox37 { get; set; }
        public int? checkbox38 { get; set; }
        public int? DaThucHienTDD { get; set; }

        [ForeignKey("BacSiKetLuan_Id")]
        [InverseProperty("K_CLSKetQua")]
        public virtual K_BacSi BacSiKetLuan { get; set; }
        [ForeignKey("BenhNhan_id")]
        [InverseProperty("K_CLSKetQua")]
        public virtual K_BenhNhan BenhNhan { get; set; }
        [ForeignKey("KTVThucHien_Id")]
        [InverseProperty("K_CLSKetQua")]
        public virtual K_KTV KTVThucHien { get; set; }
        [ForeignKey("TiepNhan_Id")]
        [InverseProperty("K_CLSKetQua")]
        public virtual K_TiepNhan TiepNhan { get; set; }
        [InverseProperty("CLSKetQua")]
        public virtual ICollection<K_CLSKetQua_CDHAHinhAnh> K_CLSKetQua_CDHAHinhAnh { get; set; }
        [InverseProperty("CLSKetQua")]
        public virtual ICollection<K_KetQuaGiaiPhauBenh> K_KetQuaGiaiPhauBenh { get; set; }
        [InverseProperty("CLSKetQua")]
        public virtual ICollection<ZaloFile> ZaloFile { get; set; }
    }
}