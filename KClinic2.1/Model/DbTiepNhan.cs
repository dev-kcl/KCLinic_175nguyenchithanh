using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KClinic2._1.Model
{
    class DbTiepNhan
    {
        public static int timeout_connecttion = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["timeout_connecttion"]);

        public static string sql = Crypt.Decrypt(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"], "CongtyKCL");

        public static SqlConnection con = new SqlConnection(sql);

        public static DataTable CBBPhongBan(string _Dich_Id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;

                cmd_Show.CommandText = "exec SP_002_TiepNhan @Action=N'CBBPhongBan1', @DichVu_Id = N'" + _Dich_Id + "'";
                ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable AutoTinhMaYTe(string _MaBenhVien, string _PhienDangNhap, string _User_Id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_002_TiepNhan @Action = N'AutoTinhMaYTe', @MaYTe = N'" + _MaBenhVien + "',"
                    + "@PhienDangNhap_Id = " + _PhienDangNhap + ","
                    + "@User_Id = " + _User_Id
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }

        public static DataTable InsertBenhNhan(
            string _MaYTe
            , string _SoVaoVien
            , string _TenBenhNhan
            , string _GioiTinh
            , string _NgaySinh
            , string _NamSinh
            , string _SoDienThoai
            , string _CMND
            , string _DiaChiChiTiet
            , string _XaPhuong
            , string _QuanHuyen
            , string _TinhThanh
            , string _NguoiTao
            , string _NgayTao
            , string _NguoiCapNhat
            , string _NgayCapNhat
            , string _Huy
            , string _Zalo_Id
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_002_TiepNhan @Action = N'Insert_BenhNhan',"
                    + "@MaYTe = " + _MaYTe + ","
                    + "@SoVaoVien = " + _SoVaoVien + ","
                    + "@TenBenhNhan = " + _TenBenhNhan + ","
                    + "@GioiTinh = " + _GioiTinh + ","
                    + "@NgaySinh = " + _NgaySinh + ","
                    + "@NamSinh = " + _NamSinh + ","
                    + "@SoDienThoai = " + _SoDienThoai + ","
                    + "@CMND = " + _CMND + ","
                    + "@DiaChiChiTiet = " + _DiaChiChiTiet + ","
                    + "@XaPhuong = " + _XaPhuong + ","
                    + "@QuanHuyen = " + _QuanHuyen + ","
                    + "@TinhThanh = " + _TinhThanh + ","
                    + "@NguoiTao = " + _NguoiTao + ","
                    + "@NgayTao = " + _NgayTao + ","
                    + "@NguoiCapNhat = " + _NguoiCapNhat + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ","
                    + "@Huy = " + _Huy + ","
                    + "@Zalo_Id = " + _Zalo_Id
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable Insert_TiepNhan(
              string _SoTiepNhan
            , string _SoThuTu
            , string _UuTien
            , string _BenhNhan_Id
            , string _NoiTiepNhan_Id
            , string _NguoiTiepNhan_Id
            , string _NgayTiepNhan
            , string _ThoiGianTiepNhan
            , string _NamTiepNhan
            , string _ThangTiepNhan
            , string _DiaChiLienHe
            , string _GhiChu
            , string _BacSiChiDinh
            , string _NguoiTao
            , string _NgayTao
            , string _NguoiCapNhat
            , string _NgayCapNhat
            , string _Huy
           , string _DoiTuong_Id
            , string _HopDong_Id
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_002_TiepNhan @Action = N'Insert_TiepNhan',"
                    + "@SoTiepNhan = " + _SoTiepNhan + ","
                    + "@SoThuTu = " + _SoThuTu + ","
                    + "@UuTien = " + _UuTien + ","
                    + "@BenhNhan_Id = " + _BenhNhan_Id + ","
                    + "@NoiTiepNhan_Id = " + _NoiTiepNhan_Id + ","
                    + "@NguoiTiepNhan_Id = " + _NguoiTiepNhan_Id + ","
                    + "@NgayTiepNhan = " + _NgayTiepNhan + ","
                    + "@ThoiGianTiepNhan = " + _ThoiGianTiepNhan + ","
                    + "@NamTiepNhan = " + _NamTiepNhan + ","
                    + "@ThangTiepNhan = " + _ThangTiepNhan + ","
                    + "@DiaChiLienHe = " + _DiaChiLienHe + ","
                    + "@GhiChu = " + _GhiChu + ","
                    + "@BacSiChiDinh = " + _BacSiChiDinh + ","
                    + "@NguoiTao = " + _NguoiTao + ","
                    + "@NgayTao = " + _NgayTao + ","
                    + "@NguoiCapNhat = " + _NguoiCapNhat + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ","
                    + "@Huy = " + _Huy + ","
                      + "@DoiTuong_Id = " + _DoiTuong_Id + ","
                    + "@HopDong_Id = " + _HopDong_Id
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable GioiTinh()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_002_TiepNhan @Action = N'GioiTinh'";
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable BacSiChiDinh()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_002_TiepNhan @Action = N'BacSiChiDinh'";
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable LoadThongTinBenhNhan(string _BenhNhan_Id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_002_TiepNhan @Action = N'LoadThongTinBenhNhan', "
                    + "@BenhNhan_Id = " + _BenhNhan_Id
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable LoadThongTinDangKyKhamOnline(string _Idx)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_002_TiepNhan @Action = N'LoadThongTinDangKyKhamOnline', "
                    + "@Idx = " + _Idx
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable LoadThongTinBenhNhanTheoMaYTe(string _SoVaoVien)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_002_TiepNhan @Action = N'LoadThongTinBenhNhanTheoMaYTe', "
                    + "@MaYTe = N'" + _SoVaoVien + "'"
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable LoadThongTinBenhNhanDaTiepNhan(string _TiepNhan_Id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_002_TiepNhan @Action = N'LoadThongTinBenhNhanDaTiepNhan', "
                    + "@IDx = " + _TiepNhan_Id
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable DeleteTiepNhan(string _TiepNhan_Id, string _NguoiCapNhat)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_002_TiepNhan @Action = N'DeleteTiepNhan', "
                    + "@IDx = " + _TiepNhan_Id + ","
                    + "@NguoiCapNhat = " + _NguoiCapNhat
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable XemDanhSachTiepNhan()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_002_TiepNhan @Action = N'XemDanhSachTiepNhan' "
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable XemDanhSachTiepNhan_TimKiem(string _loai, string _Text)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_002_TiepNhan @Action = N'XemDanhSachTiepNhan_TimKiem', "
                    + "@Idx =" + _loai + ","
                    + "@text = N'" + _Text + "'"
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable Update_TiepNhan(
              string _TiepNhan_Id
            , string _SoTiepNhan
            , string _SoThuTu
            , string _UuTien
            , string _BenhNhan_Id
            , string _NoiTiepNhan_Id
            , string _NguoiTiepNhan_Id
            , string _NgayTiepNhan
            , string _ThoiGianTiepNhan
            , string _NamTiepNhan
            , string _ThangTiepNhan
            , string _DiaChiLienHe
            , string _GhiChu
            , string _BacSiChiDinh
            , string _NguoiTao
            , string _NgayTao
            , string _NguoiCapNhat
            , string _NgayCapNhat
            , string _Huy
            ,string _DoiTuong_Id
            ,string _HopDong_Id
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_002_TiepNhan @Action = N'Update_TiepNhan',"
                    + "@TiepNhan_Id = " + _TiepNhan_Id + ","
                    + "@SoTiepNhan = " + _SoTiepNhan + ","
                    + "@SoThuTu = " + _SoThuTu + ","
                    + "@UuTien = " + _UuTien + ","
                    + "@BenhNhan_Id = " + _BenhNhan_Id + ","
                    + "@NoiTiepNhan_Id = " + _NoiTiepNhan_Id + ","
                    + "@NguoiTiepNhan_Id = " + _NguoiTiepNhan_Id + ","
                    + "@NgayTiepNhan = " + _NgayTiepNhan + ","
                    + "@ThoiGianTiepNhan = " + _ThoiGianTiepNhan + ","
                    + "@NamTiepNhan = " + _NamTiepNhan + ","
                    + "@ThangTiepNhan = " + _ThangTiepNhan + ","
                    + "@DiaChiLienHe = " + _DiaChiLienHe + ","
                    + "@GhiChu = " + _GhiChu + ","
                    + "@BacSiChiDinh = " + _BacSiChiDinh + ","
                    + "@NguoiTao = " + _NguoiTao + ","
                    + "@NgayTao = " + _NgayTao + ","
                    + "@NguoiCapNhat = " + _NguoiCapNhat + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ","
                    + "@Huy = " + _Huy + ","
                      + "@DoiTuong_Id = " + _DoiTuong_Id + ","
                    + "@HopDong_Id = " + _HopDong_Id
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable UpdateBenhNhan(
              string _BenhNhan_Id
            , string _MaYTe
            , string _SoVaoVien
            , string _TenBenhNhan
            , string _GioiTinh
            , string _NgaySinh
            , string _NamSinh
            , string _SoDienThoai
            , string _CMND
            , string _DiaChiChiTiet
            , string _XaPhuong
            , string _QuanHuyen
            , string _TinhThanh
            , string _NguoiTao
            , string _NgayTao
            , string _NguoiCapNhat
            , string _NgayCapNhat
            , string _Huy
            , string _Zalo_Id
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_002_TiepNhan @Action = N'UpdateBenhNhan',"
                    + "@BenhNhan_Id = " + _BenhNhan_Id + ","
                    + "@MaYTe = " + _MaYTe + ","
                    + "@SoVaoVien = " + _SoVaoVien + ","
                    + "@TenBenhNhan = " + _TenBenhNhan + ","
                    + "@GioiTinh = " + _GioiTinh + ","
                    + "@NgaySinh = " + _NgaySinh + ","
                    + "@NamSinh = " + _NamSinh + ","
                    + "@SoDienThoai = " + _SoDienThoai + ","
                    + "@CMND = " + _CMND + ","
                    + "@DiaChiChiTiet = " + _DiaChiChiTiet + ","
                    + "@XaPhuong = " + _XaPhuong + ","
                    + "@QuanHuyen = " + _QuanHuyen + ","
                    + "@TinhThanh = " + _TinhThanh + ","
                    + "@NguoiTao = " + _NguoiTao + ","
                    + "@NgayTao = " + _NgayTao + ","
                    + "@NguoiCapNhat = " + _NguoiCapNhat + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ","
                    + "@Huy = " + _Huy + ","
                    + "@Zalo_Id = " + _Zalo_Id
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable Dm_NhomBenh()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_002_TiepNhan @Action = N'Dm_NhomBenh' "
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable Dm_DichVu()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_002_TiepNhan @Action = N'Dm_DichVu' "
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable Dm_DichVu_DonGia(string _DichVu_id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_002_TiepNhan @Action = N'Dm_DichVu_DonGia' ,"
                    + "@DichVu_Id = " + _DichVu_id
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable InsertCLSYeuCau(
            string _SoPhieuYeuCau
            , string _NgayYeuCau
            , string _ThoiGianYeuCau
            , string _TiepNhan_Id
            , string _BenhNhan_id
            , string _DichVu_Id
            , string _SoLuong
            , string _DonGiaDichVu
            , string _ThanhTienDichVu
            , string _DuocPhepThucHien
            , string _TrangThai
            , string _NguoiChiDinh
            , string _NguoiTao
            , string _NgayTao
            , string _NguoiCapNhat
            , string _NgayCapNhat
            , string _Huy
            , string _CLSYeuCau_Cha_Id
            , string _PhongBan_Id
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_002_TiepNhan @Action = N'InsertCLSYeuCau',"
                    + "@SoPhieuYeuCau = " + _SoPhieuYeuCau + ","
                    + "@NgayYeuCau = " + _NgayYeuCau + ","
                    + "@ThoiGianYeuCau = " + _ThoiGianYeuCau + ","
                    + "@TiepNhan_Id = " + _TiepNhan_Id + ","
                    + "@BenhNhan_id = " + _BenhNhan_id + ","
                    + "@DichVu_Id = " + _DichVu_Id + ","
                    + "@SoLuong = " + _SoLuong + ","
                    + "@DonGiaDichVu = " + _DonGiaDichVu + ","
                    + "@ThanhTienDichVu = " + _ThanhTienDichVu + ","
                    + "@DuocPhepThucHien = " + _DuocPhepThucHien + ","
                    + "@TrangThai = " + _TrangThai + ","
                    + "@NguoiChiDinh = " + _NguoiChiDinh + ","
                    + "@NguoiTao = " + _NguoiTao + ","
                    + "@NgayTao = " + _NgayTao + ","
                    + "@NguoiCapNhat = " + _NguoiCapNhat + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ","
                    + "@Huy = " + _Huy + ","
                    + "@CLSYeuCau_Cha_Id = " + _CLSYeuCau_Cha_Id + ","
                    + "@PhongBan_Id = " + _PhongBan_Id 
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable InsertCLSYeuCau_PhieuDangNhap(string _PhienDangNhap, string _clsyeucau, string _DichVu_id, string _ThaoTac)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_002_TiepNhan @Action = N'InsertCLSYeuCau_PhieuDangNhap' ,"
                    + "@PhienDangNhap_Id = " + _PhienDangNhap + ","
                    + "@CLSYeuCau_Id = " + _clsyeucau + ","
                    + "@DichVu_Id = " + _DichVu_id + ","
                    + "@ThaoTac = " + _ThaoTac
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable SelectClsyeucauPhienDangNhap(string _PhienDangNhap)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_002_TiepNhan @Action = N'SelectClsyeucauPhienDangNhap' ,"
                    + "@PhienDangNhap_Id = " + _PhienDangNhap
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable Delete_ClsYeuCau_PhienDangNhap(string _Clsyeucau, string _NguoiCapNhat)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_002_TiepNhan @Action = N'Delete_ClsYeuCau_PhienDangNhap' ,"
                    + "@IDx = " + _Clsyeucau + ","
                    + "@NguoiCapNhat = " + _NguoiCapNhat
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable CheckClsYeuCauPhienDangNhap(string _PhienDangNhap)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_002_TiepNhan @Action = N'CheckClsYeuCauPhienDangNhap' ,"
                    + "@PhienDangNhap_Id = " + _PhienDangNhap
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable UpdateCLSYeuCau(string _clsYeuCau, string _TiepNhan_Id, string BenhNhan_Id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_002_TiepNhan @Action = N'UpdateCLSYeuCau' ,"
                    + "@CLSYeuCau_Id = " + _clsYeuCau + ","
                    + "@TiepNhan_Id = " + _TiepNhan_Id + ","
                    + "@BenhNhan_id = " + BenhNhan_Id
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable DeleteCLSYeuCau(string _Clsyeucau, string _NguoiCapNhat)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_002_TiepNhan @Action = N'DeleteCLSYeuCau' ,"
                    + "@CLSYeuCau_Id = " + _Clsyeucau + ","
                    + "@NguoiCapNhat = " + _NguoiCapNhat
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable HoanTatClsYeuCauPhienDangNhap(string _PhienDangNhap)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_002_TiepNhan @Action = N'HoanTatClsYeuCauPhienDangNhap' ,"
                    + "@PhienDangNhap_Id = " + _PhienDangNhap
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable ThemClsYeuCauVaoPhieuDangNhap(string _PhienDangNhap, string _TiepNhan_Id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_002_TiepNhan @Action = N'ThemClsYeuCauVaoPhieuDangNhap' ,"
                    + "@PhienDangNhap_Id = " + _PhienDangNhap + ","
                    + "@TiepNhan_Id = " + _TiepNhan_Id
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable CheckNhomBenh_DichVu(string _NhomBenh_id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_002_TiepNhan @Action = N'CheckNhomBenh_DichVu' ,"
                    + "@IDx = " + _NhomBenh_id
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable PhieuChiDinhDichVu(string _TiepNhan_Id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_002_TiepNhan @Action = N'PhieuChiDinhDichVu' ,"
                    + "@TiepNhan_Id = " + _TiepNhan_Id
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable InMaVach(string _BenhNhan_Id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_002_TiepNhan @Action = N'InMaVach' ,"
                    + "@BenhNhan_Id = " + _BenhNhan_Id
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable CheckDichVuCapDuoi(string _DichVu_Id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_002_TiepNhan @Action = N'CheckDichVuCapDuoi', "
                    + "@DichVu_Id =" + _DichVu_Id
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable CheckKhamBenhTheoTiepNhan(string _TiepNhan_Id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_002_TiepNhan @Action = N'CheckKhamBenhTheoTiepNhan', "
                    + "@TiepNhan_Id =" + _TiepNhan_Id
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable CheckDichVuDaThucHien(string _Idx)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_002_TiepNhan @Action = N'CheckDichVuDaThucHien', "
                    + "@Idx =" + _Idx
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable CheckDaChiDinhDichVu(string _Idx)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_002_TiepNhan @Action = N'CheckDaChiDinhDichVu', "
                    + "@Idx =" + _Idx
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable UpdateThongTinDangKy(string _Idx, string _TiepNhan_Id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_002_TiepNhan @Action = N'UpdateThongTinDangKy', "
                    + "@BenhNhan_Id = " + _TiepNhan_Id + ","
                    + "@Idx = " + _Idx
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable LayDMDoiTuong()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "select  FieldCode = DoiTuong_Id,  FieldName = TenDoiTuong from K_DM_DoiTuong where Huy = 0 and TamNgung = 0"
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }


        public static DataTable LayDMHopDong()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "select FieldCode = HopDong_Id, TenCongTy, MaHopDong, So_HD  from KSK_HopDong  where Huy = 0"
                       ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
    }
}
