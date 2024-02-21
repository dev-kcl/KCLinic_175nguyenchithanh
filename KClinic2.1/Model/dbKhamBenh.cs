using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KClinic2._1.Model
{
    class dbKhamBenh
    {
        public static int timeout_connecttion = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["timeout_connecttion"]);

        public static string sql = Crypt.Decrypt(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"], "CongtyKCL");

        public static SqlConnection con = new SqlConnection(sql);

        public static DataTable CheckBenhNhanKhamBenh()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec sp_KhamBenh @Action = N'CheckBenhNhanKhamBenh'";
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
        public static DataTable HangDoiBenhNhanKhamBenh()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec sp_KhamBenh @Action = N'HangDoiBenhNhanKhamBenh'";
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
        public static DataTable CheckBenhNhanKhamBenhTheoTiepNhan_Id(string _Idx)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec sp_KhamBenh @Action = N'CheckBenhNhanKhamBenhTheoTiepNhan_Id', @IDx = " + _Idx;
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
        public static DataTable CheckUserPhongKham(string _User_Id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec sp_KhamBenh @Action = N'CheckUserPhongKham', @User_Id = " + _User_Id;
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
        public static DataTable CheckUserBacSiPhongKham(string _User_Id, string _PhongBan_Id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec sp_KhamBenh @Action = N'CheckUserBacSiPhongKham', @User_Id = " + _User_Id + ","
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
        public static DataTable LoadThongTinBenhNhanDaTiepNhanKhamBenh(string _TiepNhan_Id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec sp_KhamBenh @Action = N'LoadThongTinBenhNhanDaTiepNhanKhamBenh', @TiepNhan_Id = " + _TiepNhan_Id
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
        public static DataTable LoadThongTinBenhNhanDaTiepNhanKhamBenhCLSYeuCau(string _IDx)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec sp_KhamBenh @Action = N'LoadThongTinBenhNhanDaTiepNhanKhamBenhCLSYeuCau', @IDx = " + _IDx
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
        public static DataTable InsertKhamBenh(
              string _TiepNhan_Id
            , string _BenhNhan_Id
            , string _NgayKham
            , string _ThoiGianKham
            , string _PhongKham_Id
            , string _BacSiKham
            , string _Mach
            , string _NhietDo
            , string _CanNang
            , string _ChieuCao
            , string _HuyetApCao
            , string _HuyetApThap
            , string _NhipTho
            , string _BMI
            , string _TrieuChung
            , string _ICD_Id
            , string _ChanDoan
            , string _KetLuan
            , string _LoiDan
            , string _CLSYeuCau_Id
            , string _NgayTao
            , string _NguoiTao
            , string _NgayCapNhat
            , string _NguoiCapNhat
            , string _Huy
            , string _HenTaiKham
            , string _TienSu
            , string _Kham
            , string _LyDoKham
            , string _TomTatCLS
            , string _DieuTri
            , string _GhiChu
            , string _NoiDungHenTaiKham
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec sp_KhamBenh @Action = N'InsertKhamBenh',"
                    + "@TiepNhan_Id = " + _TiepNhan_Id + ","
                    + "@BenhNhan_Id = " + _BenhNhan_Id + ","
                    + "@NgayKham = " + _NgayKham + ","
                    + "@ThoiGianKham = " + _ThoiGianKham + ","
                    + "@PhongKham_Id = " + _PhongKham_Id + ","
                    + "@BacSiKham = " + _BacSiKham + ","
                    + "@Mach = " + _Mach + ","
                    + "@NhietDo = " + _NhietDo + ","
                    + "@CanNang = " + _CanNang + ","
                    + "@ChieuCao = " + _ChieuCao + ","
                    + "@HuyetApCao = " + _HuyetApCao + ","
                    + "@HuyetApThap = " + _HuyetApThap + ","
                    + "@NhipTho = " + _NhipTho + ","
                    + "@BMI = " + _BMI + ","
                    + "@TrieuChung = " + _TrieuChung + ","
                    + "@ICD_Id = " + _ICD_Id + ","
                    + "@ChanDoan = " + _ChanDoan + ","
                    + "@KetLuan = " + _KetLuan + ","
                    + "@LoiDan = " + _LoiDan + ","
                    + "@CLSYeuCau_Id = " + _CLSYeuCau_Id + ","
                    + "@NgayTao = " + _NgayTao + ","
                    + "@NguoiTao = " + _NguoiTao + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ","
                    + "@NguoiCapNhat = " + _NguoiCapNhat + ","
                    + "@Huy = " + _Huy + ","
                    + "@HenTaiKham = " + _HenTaiKham + ","
                    + "@TienSu = " + _TienSu + ","
                    + "@Kham = " + _Kham + ","
                    + "@LyDoKham = " + _LyDoKham + ","
                    + "@TomTatCLS = " + _TomTatCLS + ","
                    + "@DieuTri = " + _DieuTri + ","
                    + "@GhiChu = " + _GhiChu + ","
                    + "@NoiDungHenTaiKham = " + _NoiDungHenTaiKham
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
        public static DataTable LoadThongTinBenhNhanDaKhamBenh(string _IDx)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec sp_KhamBenh @Action = N'LoadThongTinBenhNhanDaKhamBenh', @IDx = " + _IDx
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
        public static DataTable UpdateKhamBenh(
              string _Idx
            , string _TiepNhan_Id
            , string _BenhNhan_Id
            , string _NgayKham
            , string _ThoiGianKham
            , string _PhongKham_Id
            , string _BacSiKham
            , string _Mach
            , string _NhietDo
            , string _CanNang
            , string _ChieuCao
            , string _HuyetApCao
            , string _HuyetApThap
            , string _NhipTho
            , string _BMI
            , string _TrieuChung
            , string _ICD_Id
            , string _ChanDoan
            , string _KetLuan
            , string _LoiDan
            , string _CLSYeuCau_Id
            , string _NgayTao
            , string _NguoiTao
            , string _NgayCapNhat
            , string _NguoiCapNhat
            , string _Huy
            , string _HenTaiKham
            , string _TienSu
            , string _Kham
            , string _LyDoKham
            , string _TomTatCLS
            , string _DieuTri
            , string _GhiChu
            , string _NoiDungHenTaiKham
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec sp_KhamBenh @Action = N'UpdateKhamBenh',"
                    + "@Idx = " + _Idx + ","
                    + "@TiepNhan_Id = " + _TiepNhan_Id + ","
                    + "@BenhNhan_Id = " + _BenhNhan_Id + ","
                    + "@NgayKham = " + _NgayKham + ","
                    + "@ThoiGianKham = " + _ThoiGianKham + ","
                    + "@PhongKham_Id = " + _PhongKham_Id + ","
                    + "@BacSiKham = " + _BacSiKham + ","
                    + "@Mach = " + _Mach + ","
                    + "@NhietDo = " + _NhietDo + ","
                    + "@CanNang = " + _CanNang + ","
                    + "@ChieuCao = " + _ChieuCao + ","
                    + "@HuyetApCao = " + _HuyetApCao + ","
                    + "@HuyetApThap = " + _HuyetApThap + ","
                    + "@NhipTho = " + _NhipTho + ","
                    + "@BMI = " + _BMI + ","
                    + "@TrieuChung = " + _TrieuChung + ","
                    + "@ICD_Id = " + _ICD_Id + ","
                    + "@ChanDoan = " + _ChanDoan + ","
                    + "@KetLuan = " + _KetLuan + ","
                    + "@LoiDan = " + _LoiDan + ","
                    + "@CLSYeuCau_Id = " + _CLSYeuCau_Id + ","
                    + "@NgayTao = " + _NgayTao + ","
                    + "@NguoiTao = " + _NguoiTao + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ","
                    + "@NguoiCapNhat = " + _NguoiCapNhat + ","
                    + "@Huy = " + _Huy + ","
                    + "@HenTaiKham = " + _HenTaiKham + ","
                    + "@TienSu = " + _TienSu + ","
                    + "@Kham = " + _Kham + ","
                    + "@LyDoKham = " + _LyDoKham + ","
                    + "@TomTatCLS = " + _TomTatCLS + ","
                    + "@DieuTri = " + _DieuTri + ","
                    + "@GhiChu = " + _GhiChu + ","
                    + "@NoiDungHenTaiKham = " + _NoiDungHenTaiKham
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
        public static DataTable DeleteKhamBenh(string _KhamBenh_Id, string _NguoiCapNhat)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec sp_KhamBenh @Action = N'DeleteKhamBenh', "
                    + "@IDx = " + _KhamBenh_Id + ","
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
        public static DataTable CheckDaChiDinhDichVuTruKhamBenh(string _Idx)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec sp_KhamBenh @Action = N'CheckDaChiDinhDichVuTruKhamBenh', "
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
        public static DataTable CBBToaThuocMau()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec sp_KhamBenh @Action = N'CBBToaThuocMau' "
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
        public static DataTable CBBDuoc()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec sp_KhamBenh @Action = N'CBBDuoc' "
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
        public static DataTable Dm_Duoc_DonGia(
            string _Duoc_Id
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec sp_KhamBenh @Action = N'Dm_Duoc_DonGia', "
                    + "@Duoc_Id = " + _Duoc_Id
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
        public static DataTable InsertToaThuoc(
              string _KhamBenh_Id
            , string _SoThuTuToa
            , string _Duoc_Id
            , string _Sang
            , string _Trua
            , string _Chieu
            , string _Toi
            , string _SoNgay
            , string _SoLuong
            , string _DonGia
            , string _ThanhTien
            , string _DaCho
            , string _SoLuongDaCho
            , string _DaThanhToan
            , string _NguoiTao
            , string _NgayTao
            , string _NguoiCapNhat
            , string _NgayCapNhat
            , string _Huy
            , string _GhiChu
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec sp_KhamBenh @Action = N'InsertToaThuoc', "
                    + "@KhamBenh_Id = " + _KhamBenh_Id + ","
                    + "@SoThuTuToa = " + _SoThuTuToa + ","
                    + "@Duoc_Id = " + _Duoc_Id + ","
                    + "@Sang = " + _Sang + ","
                    + "@Trua = " + _Trua + ","
                    + "@Chieu = " + _Chieu + ","
                    + "@Toi = " + _Toi + ","
                    + "@SoNgay = " + _SoNgay + ","
                    + "@SoLuong = " + _SoLuong + ","
                    + "@DonGia = " + _DonGia + ","
                    + "@ThanhTien = " + _ThanhTien + ","
                    + "@DaCho = " + _DaCho + ","
                    + "@SoLuongDaCho = " + _SoLuongDaCho + ","
                    + "@DaThanhToan = " + _DaThanhToan + ","
                    + "@NguoiTao = " + _NguoiTao + ","
                    + "@NgayTao = " + _NgayTao + ","
                    + "@NguoiCapNhat = " + _NguoiCapNhat + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ","
                    + "@Huy = " + _Huy + ","
                    + "@GhiChu = " + _GhiChu
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
        public static DataTable InsertToaThuoc_PhieuDangNhap(
              string _PhienDangNhap_Id
            , string _KhamBenh_Id
            , string _ToaThuoc_Id
            , string _Duoc_Id
            , string _Sang
            , string _Trua
            , string _Chieu
            , string _Toi
            , string _SoNgay
            , string _SoLuong
            , string _DonGia
            , string _ThaoTac
            , string _GhiChu
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec sp_KhamBenh @Action = N'InsertToaThuoc_PhieuDangNhap', "
                    + "@PhienDangNhap_Id = " + _PhienDangNhap_Id + ","
                    + "@KhamBenh_Id = " + _KhamBenh_Id + ","
                    + "@ToaThuoc_Id = " + _ToaThuoc_Id + ","
                    + "@Duoc_Id = " + _Duoc_Id + ","
                    + "@Sang = " + _Sang + ","
                    + "@Trua = " + _Trua + ","
                    + "@Chieu = " + _Chieu + ","
                    + "@Toi = " + _Toi + ","
                    + "@SoNgay = " + _SoNgay + ","
                    + "@SoLuong = " + _SoLuong + ","
                    + "@DonGia = " + _DonGia + ","
                    + "@ThaoTac = " + _ThaoTac + ","
                    + "@GhiChu = " + _GhiChu
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
        public static DataTable SelectDuocBooking(
            string _PhienDangNhap_Id
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec sp_KhamBenh @Action = N'SelectDuocBooking', "
                    + "@PhienDangNhap_Id = " + _PhienDangNhap_Id
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
        public static DataTable CheckThuocDaBan(
            string _IDx
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec sp_KhamBenh @Action = N'CheckThuocDaBan', "
                    + "@IDx = " + _IDx
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
        public static DataTable Delete_BookingDuoc_PhienDangNhap(
            string _IDx
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec sp_KhamBenh @Action = N'Delete_BookingDuoc_PhienDangNhap', "
                    + "@IDx = " + _IDx
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
        public static DataTable SelectDuocBookingTheoID(
            string _PhienDangNhap_Id
            ,string _ToaThuoc_Id
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec sp_KhamBenh @Action = N'SelectDuocBookingTheoID', "
                    + "@PhienDangNhap_Id = " + _PhienDangNhap_Id + ","
                    + "@ToaThuoc_Id = " + _ToaThuoc_Id
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
        public static DataTable UpdateToaThuoc_PhieuDangNhap(
              string _PhienDangNhap_Id
            , string _KhamBenh_Id
            , string _ToaThuoc_Id
            , string _Duoc_Id
            , string _Sang
            , string _Trua
            , string _Chieu
            , string _Toi
            , string _SoNgay
            , string _SoLuong
            , string _DonGia
            , string _ThaoTac
            , string _GhiChu
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec sp_KhamBenh @Action = N'UpdateToaThuoc_PhieuDangNhap', "
                    + "@PhienDangNhap_Id = " + _PhienDangNhap_Id + ","
                    + "@KhamBenh_Id = " + _KhamBenh_Id + ","
                    + "@ToaThuoc_Id = " + _ToaThuoc_Id + ","
                    + "@Duoc_Id = " + _Duoc_Id + ","
                    + "@Sang = " + _Sang + ","
                    + "@Trua = " + _Trua + ","
                    + "@Chieu = " + _Chieu + ","
                    + "@Toi = " + _Toi + ","
                    + "@SoNgay = " + _SoNgay + ","
                    + "@SoLuong = " + _SoLuong + ","
                    + "@DonGia = " + _DonGia + ","
                    + "@ThaoTac = " + _ThaoTac + ","
                    + "@GhiChu = " + _GhiChu
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
        public static DataTable CheckToaThuocPhienDangNhap(
            string _PhienDangNhap_Id
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec sp_KhamBenh @Action = N'CheckToaThuocPhienDangNhap', "
                    + "@PhienDangNhap_Id = " + _PhienDangNhap_Id
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
        public static DataTable UpdateToaThuocThem(
              string _KhamBenh_Id
            , string _ToaThuoc_Id
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec sp_KhamBenh @Action = N'UpdateToaThuocThem', "
                    + "@KhamBenh_Id = " + _KhamBenh_Id + ","
                    + "@ToaThuoc_Id = " + _ToaThuoc_Id
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
        public static DataTable DeleteToaThuoc(
              string _ToaThuoc_Id
            , string _NguoiCapNhat
            , string _NgayCapNhat
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec sp_KhamBenh @Action = N'DeleteToaThuoc', "
                    + "@ToaThuoc_Id = " + _ToaThuoc_Id + ","
                    + "@NguoiCapNhat = " + _NguoiCapNhat + ","
                    + "@NgayCapNhat = " + _NgayCapNhat
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
        public static DataTable UpdateToaThuocSua(
              string _KhamBenh_Id
            , string _ToaThuoc_Id
            , string _Duoc_Id
            , string _Sang
            , string _Trua
            , string _Chieu
            , string _Toi
            , string _SoNgay
            , string _SoLuong
            , string _DonGia
            , string _NguoiCapNhat
            , string _NgayCapNhat
            , string _GhiChu
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec sp_KhamBenh @Action = N'UpdateToaThuocSua', "
                    + "@KhamBenh_Id = " + _KhamBenh_Id + ","
                    + "@ToaThuoc_Id = " + _ToaThuoc_Id + ","
                    + "@Duoc_Id = " + _Duoc_Id + ","
                    + "@Sang = " + _Sang + ","
                    + "@Trua = " + _Trua + ","
                    + "@Chieu = " + _Chieu + ","
                    + "@Toi = " + _Toi + ","
                    + "@SoNgay = " + _SoNgay + ","
                    + "@SoLuong = " + _SoLuong + ","
                    + "@DonGia = " + _DonGia + ","
                    + "@NguoiCapNhat = " + _NguoiCapNhat + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ","
                    + "@GhiChu = " + _GhiChu
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
        public static DataTable HoanTatBookingPhienDangNhap(
              string _PhienDangNhap_Id
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec sp_KhamBenh @Action = N'HoanTatBookingPhienDangNhap', "
                    + "@PhienDangNhap_Id = " + _PhienDangNhap_Id
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
        public static DataTable ThemBookingVaoPhieuDangNhap(
              string _PhienDangNhap_Id
            , string _KhamBenh_Id
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec sp_KhamBenh @Action = N'ThemBookingVaoPhieuDangNhap', "
                    + "@PhienDangNhap_Id = " + _PhienDangNhap_Id + ","
                    + "@KhamBenh_Id = " + _KhamBenh_Id
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
        public static DataTable CheckToaThuocMau_Duoc(
              string _IDx
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec sp_KhamBenh @Action = N'CheckToaThuocMau_Duoc', "
                    + "@IDx = " + _IDx
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
        public static DataTable SP_BaoCao_001_ToaThuoc(
              string _IDx
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_BaoCao_001_ToaThuoc "
                    + "@KhamBenh_Id = " + _IDx
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
        public static DataTable SP_BaoCao_002_Phieukham(
              string _IDx
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_BaoCao_002_Phieukham "
                    + "@KhamBenh_Id = " + _IDx
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
        public static DataTable SP_BaoCao_003_PhieuChiDinhDichVuTruKham(
              string _IDx
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_BaoCao_003_PhieuChiDinhDichVuTruKham "
                    + "@KhamBenh_Id = " + _IDx
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
        public static DataTable CheckNhomDichVuDaChiDinhTheoTiepNhan(
              string _IDx
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec sp_KhamBenh @Action = N'CheckNhomDichVuDaChiDinhTheoTiepNhan', "
                    + "@TiepNhan_Id = " + _IDx
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
        public static DataTable InsertXacNhanHoanTatKham(string _TiepNhan_Id
            , string _KhamBenh_Id
            , string _NgayTao
            , string _NguoiTao
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "insert into K_XacNhanHoanTatKham(TiepNhan_Id,KhamBenh_Id,NgayTao,NguoiTao, Huy) select "
                    + _TiepNhan_Id + ","
                    + _KhamBenh_Id + ","
                    + _NgayTao + ","
                    + _NguoiTao + ",0"
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
        public static DataTable UpdateXacNhanHoanTatKham(string _KhamBenh_Id
            , string _NgayCapNhat
            , string _NguoiCapNhat
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "update K_XacNhanHoanTatKham set Huy = 1, NgayCapNhat = " + _NgayCapNhat +  ", NguoiCapNhat = " + _NguoiCapNhat + " where KhamBenh_Id = "
                    + _KhamBenh_Id
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
        public static DataTable SelectXacNhanHoanTatKham(
            string _KhamBenh_Id
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "select KhamBenh_Id from  K_XacNhanHoanTatKham where Huy = 0 and KhamBenh_Id = "
                    + _KhamBenh_Id
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
        public static DataTable SelectLichHen(string _Loai, string _text)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec sp_KhamBenh @Action = N'SelectLichHen',"
                    + "@Idx =" + _Loai + ","
                    + "@text = N'" + _text + "'"
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
        public static DataTable InsertLichHen(
              string _KhamBenh_Id
            , string _TiepNhan_Id
            , string _BenhNhan_Id
            , string _ThoiGianHen
            , string _ThoiGianGui
)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec sp_KhamBenh @Action = N'InsertLichHen',"
                    + "@KhamBenh_Id = " + _KhamBenh_Id + ","
                    + "@TiepNhan_Id = " + _TiepNhan_Id + ","
                    + "@BenhNhan_Id = " + _BenhNhan_Id + ","
                    + "@ThoiGianHen = " + _ThoiGianHen + ","
                    + "@ThoiGianGui = " + _ThoiGianGui
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
        public static DataTable GoiBenhNhanKhamBenh(string _HangDoiPhongKham_Id, string _NgayGioKhamBenh, string _NgayGioHoanTatKham)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_K_006_HangDoiKhamBenh @Action = N'GoiBenhNhanKhamBenh',"
                    + "@HangDoiPhongKham_Id = " + _HangDoiPhongKham_Id + ","
                    + "@NgayGioKhamBenh = " + _NgayGioKhamBenh + ","
                    + "@NgayGioHoanTatKham = " + _NgayGioHoanTatKham
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
        public static DataTable SelectDanhSachHangDoiKhamBenh(string _PhongBan_Id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_008_ManHinhHangDoi @Action = N'SelectDanhSachHangDoiKhamBenh',"
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
        public static DataTable STTPhongKhamTiepTheo(string _PhongBan_Id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_K_006_HangDoiKhamBenh @Action = N'STTPhongKhamTiepTheo',"
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
    }
}
