using System;
using System.Collections.Generic;
using KClinic2._1.Model;
using KClinic2._1.Desktop;
using System.Data.Entity;

namespace KClinic2._1.Contexts
{
    public partial class KClinicContext : DbContext
    {
        public KClinicContext() : base(Crypt.Decrypt(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"], "CongtyKCL"))
        {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public virtual DbSet<DM_BacSi_PhongKham_User> DM_BacSi_PhongKham_User { get; set; }
        public virtual DbSet<DM_DVHC> DM_DVHC { get; set; }
        public virtual DbSet<DM_ICD> DM_ICD { get; set; }
        public virtual DbSet<DM_ICD_Chuong> DM_ICD_Chuong { get; set; }
        public virtual DbSet<DM_ICD_Common> DM_ICD_Common { get; set; }
        public virtual DbSet<DM_ICD_Nhom> DM_ICD_Nhom { get; set; }
        public virtual DbSet<DM_LoaiGia> DM_LoaiGia { get; set; }
        public virtual DbSet<DM_LoaiKho> DM_LoaiKho { get; set; }
        public virtual DbSet<K_Action> K_Action { get; set; }
        public virtual DbSet<K_Action_ChungTu> K_Action_ChungTu { get; set; }
        public virtual DbSet<K_BacSi> K_BacSi { get; set; }
        public virtual DbSet<K_BenhNhan> K_BenhNhan { get; set; }
        public virtual DbSet<K_BenhVien> K_BenhVien { get; set; }
        public virtual DbSet<K_BookingDuoc> K_BookingDuoc { get; set; }
        public virtual DbSet<K_BookingTiemChung> K_BookingTiemChung { get; set; }
        public virtual DbSet<K_CLSKetQua> K_CLSKetQua { get; set; }
        public virtual DbSet<K_CLSKetQua_CDHA> K_CLSKetQua_CDHA { get; set; }
        public virtual DbSet<K_CLSKetQua_CDHAHinhAnh> K_CLSKetQua_CDHAHinhAnh { get; set; }
        public virtual DbSet<K_CLSYeuCau> K_CLSYeuCau { get; set; }
        public virtual DbSet<K_ChungTu> K_ChungTu { get; set; }
        public virtual DbSet<K_ChungTuChiTiet> K_ChungTuChiTiet { get; set; }
        public virtual DbSet<K_ChungTuSoLoNhap> K_ChungTuSoLoNhap { get; set; }
        public virtual DbSet<K_DM_Duoc> K_DM_Duoc { get; set; }
        public virtual DbSet<K_DM_Duoc_DonGia> K_DM_Duoc_DonGia { get; set; }
        public virtual DbSet<K_DM_Duoc_DonGia_His> K_DM_Duoc_DonGia_His { get; set; }
        public virtual DbSet<K_DM_NhaCungCap> K_DM_NhaCungCap { get; set; }
        public virtual DbSet<K_DM_PhacDo> K_DM_PhacDo { get; set; }
        public virtual DbSet<K_DichVu> K_DichVu { get; set; }
        public virtual DbSet<K_DichVu_GiaTriChuan> K_DichVu_GiaTriChuan { get; set; }
        public virtual DbSet<K_Dictionary> K_Dictionary { get; set; }
        public virtual DbSet<K_Dm_LoaiVacXin> K_Dm_LoaiVacXin { get; set; }
        public virtual DbSet<K_DonViTinh> K_DonViTinh { get; set; }
        public virtual DbSet<K_DuocTonKho> K_DuocTonKho { get; set; }
        public virtual DbSet<K_DuocTonKhoBooking> K_DuocTonKhoBooking { get; set; }
        public virtual DbSet<K_Email> K_Email { get; set; }
        public virtual DbSet<K_GoiVacxinMau> K_GoiVacxinMau { get; set; }
        public virtual DbSet<K_HoaDon> K_HoaDon { get; set; }
        public virtual DbSet<K_HoaDonChiTiet> K_HoaDonChiTiet { get; set; }
        public virtual DbSet<K_KTV> K_KTV { get; set; }
        public virtual DbSet<K_KetQuaGiaiPhauBenh> K_KetQuaGiaiPhauBenh { get; set; }
        public virtual DbSet<K_KhamBenh> K_KhamBenh { get; set; }
        public virtual DbSet<K_KhamSangLoc> K_KhamSangLoc { get; set; }
        public virtual DbSet<K_KhoDuoc> K_KhoDuoc { get; set; }
        public virtual DbSet<K_LoaiDuoc> K_LoaiDuoc { get; set; }
        public virtual DbSet<K_LoaiMauXetNghiem> K_LoaiMauXetNghiem { get; set; }
        public virtual DbSet<K_LoaiPhongBan> K_LoaiPhongBan { get; set; }
        public virtual DbSet<K_MapGoiVacxinMauVoiDuoc> K_MapGoiVacxinMauVoiDuoc { get; set; }
        public virtual DbSet<K_MapNhomBenhDichVu> K_MapNhomBenhDichVu { get; set; }
        public virtual DbSet<K_MapToaThuocMauVoiDuoc> K_MapToaThuocMauVoiDuoc { get; set; }
        public virtual DbSet<K_Menu> K_Menu { get; set; }
        public virtual DbSet<K_MucDichChungTu> K_MucDichChungTu { get; set; }
        public virtual DbSet<K_NhomBenh> K_NhomBenh { get; set; }
        public virtual DbSet<K_NhomDichVu> K_NhomDichVu { get; set; }
        public virtual DbSet<K_NoiDungMail> K_NoiDungMail { get; set; }
        public virtual DbSet<K_NoiDungMailHinhAnh> K_NoiDungMailHinhAnh { get; set; }
        public virtual DbSet<K_Permission> K_Permission { get; set; }
        public virtual DbSet<K_Permission_DichVu> K_Permission_DichVu { get; set; }
        public virtual DbSet<K_Permission_Report> K_Permission_Report { get; set; }
        public virtual DbSet<K_PhienDangNhap> K_PhienDangNhap { get; set; }
        public virtual DbSet<K_PhongBan> K_PhongBan { get; set; }
        public virtual DbSet<K_QuocGia> K_QuocGia { get; set; }
        public virtual DbSet<K_Setting> K_Setting { get; set; }
        public virtual DbSet<K_SoTiemChung> K_SoTiemChung { get; set; }
        public virtual DbSet<K_ThongTinDai> K_ThongTinDai { get; set; }
        public virtual DbSet<K_TiemChung> K_TiemChung { get; set; }
        public virtual DbSet<K_TiepNhan> K_TiepNhan { get; set; }
        public virtual DbSet<K_ToaThuoc> K_ToaThuoc { get; set; }
        public virtual DbSet<K_ToaThuocMau> K_ToaThuocMau { get; set; }
        public virtual DbSet<K_TuDienChanDoanKhamBenh> K_TuDienChanDoanKhamBenh { get; set; }
        public virtual DbSet<K_TuDienKetLuan> K_TuDienKetLuan { get; set; }
        public virtual DbSet<K_Users> K_Users { get; set; }
        public virtual DbSet<K_Users_KhoDuoc> K_Users_KhoDuoc { get; set; }
        public virtual DbSet<K_Users_PhongBan> K_Users_PhongBan { get; set; }
        public virtual DbSet<K_XacNhanHoanTatKham> K_XacNhanHoanTatKham { get; set; }
        public virtual DbSet<XetNghiemFile> XetNghiemFile { get; set; }
        public virtual DbSet<ZaloFile> ZaloFile { get; set; }
        public virtual DbSet<Desktop.ItemSelect> itemSelect { get; set; }
        public virtual DbSet<ProcedureBaoCao> ProcedureBaoCao { get; set; }
        public virtual DbSet<Desktop.ProcedureParameter> ProcedureParameter { get; set; }
        public virtual DbSet<Desktop.TypeOfControlInput> TypeOfControlInput { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add(new DecimalPrecisionAttributeConvention());
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(DbModelBuilder modelBuilder);
    }
}