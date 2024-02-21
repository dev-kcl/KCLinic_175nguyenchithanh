using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace KClinic2._1.Model
{
    class HoaDondb
    {
        public static int timeout_connecttion = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["timeout_connecttion"]);

        public static string sql = Crypt.Decrypt(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"], "CongtyKCL");

        public static SqlConnection con = new SqlConnection(sql);

        public static DataTable HinhThucThanhToan()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_007_HoaDon @Action = N'HinhThucThanhToan'";
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
        public static DataTable MaHoaDon()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_007_HoaDon @Action = N'MaHoaDon'";
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
        public static DataTable LoadThongTinBenhNhanVienPhi(string _BenhNhan_Id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_007_HoaDon @Action = N'LoadThongTinBenhNhanVienPhi', @BenhNhan_Id = " + _BenhNhan_Id;
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
        public static DataTable LoadDanhSachDichVuChuaDongTienBenhNhanVienPhi(string _BenhNhan_Id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_007_HoaDon @Action = N'LoadDanhSachDichVuChuaDongTienBenhNhanVienPhi', @BenhNhan_Id = " + _BenhNhan_Id;
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
        public static DataTable InsertHoaDon(
              string _SoHoaDon
            , string _SoHoaDonVAT
            , string _LoaiHoaDon
            , string _TiepNhan_Id
            , string _BenhNhan_Id
            , string _NgayPhatSinh
            , string _ThoiGianPhatSinh
            , string _NguoiLapHoaDon
            , string _GiaTriHoaDon
            , string _HinhThucThanhToan
            , string _HuyHoaDon
            , string _HoanTra
            , string _NgayTra
            , string _ThoiGianTra
            , string _NguoiTao
            , string _NgayTao
            , string _NguoiCapNhat
            , string _NgayCapNhat
            , string _MaSoThue
            , string _TenDonVi
            , string _GiamGia
            , string _GiamGiaTyLe
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_007_HoaDon @Action = N'InsertHoaDon', "
                    + "@SoHoaDon = " + _SoHoaDon + ","
                    + "@SoHoaDonVAT = " + _SoHoaDonVAT + ","
                    + "@LoaiHoaDon = " + _LoaiHoaDon + ","
                    + "@TiepNhan_Id = " + _TiepNhan_Id + ","
                    + "@BenhNhan_Id = " + _BenhNhan_Id + ","
                    + "@NgayPhatSinh = " + _NgayPhatSinh + ","
                    + "@ThoiGianPhatSinh = " + _ThoiGianPhatSinh + ","
                    + "@NguoiLapHoaDon = " + _NguoiLapHoaDon + ","
                    + "@GiaTriHoaDon = " + _GiaTriHoaDon + ","
                    + "@HinhThucThanhToan = " + _HinhThucThanhToan + ","
                    + "@HuyHoaDon = " + _HuyHoaDon + ","
                    + "@HoanTra = " + _HoanTra + ","
                    + "@NgayTra = " + _NgayTra + ","
                    + "@ThoiGianTra = " + _ThoiGianTra + ","
                    + "@NguoiTao = " + _NguoiTao + ","
                    + "@NgayTao = " + _NgayTao + ","
                    + "@NguoiCapNhat = " + _NguoiCapNhat + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ","
                    + "@MaSoThue = " + _MaSoThue + ","
                    + "@TenDonVi = " + _TenDonVi + ","
                    + "@GiamGia = " + _GiamGia + ","
                    + "@GiamGiaTyLe = " + _GiamGiaTyLe
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
        public static DataTable LoadHoaDonBenhNhan(string _BenhNhan_Id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_007_HoaDon @Action = N'LoadHoaDonBenhNhan', @BenhNhan_Id = " + _BenhNhan_Id;
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
        public static DataTable InsertHoaDonChiTiet(
              string _HoaDon_Id
            , string _CLSYeuCau_Id
            , string _ToaThuoc_Id
            , string _SoLuong
            , string _DonGia
            , string _ThanhTien
            , string _DaHoanTra
            , string _LoaiHoaDon
            , string _GiamGia
            , string _GiamGiaTiLe
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_007_HoaDon @Action = N'InsertHoaDonChiTiet', "
                    + "@HoaDon_Id = " + _HoaDon_Id + ","
                    + "@CLSYeuCau_Id = " + _CLSYeuCau_Id + ","
                    + "@ToaThuoc_Id = " + _ToaThuoc_Id + ","
                    + "@SoLuong = " + _SoLuong + ","
                    + "@DonGia = " + _DonGia + ","
                    + "@ThanhTien = " + _ThanhTien + ","
                    + "@DaHoanTra = " + _DaHoanTra + ","
                    + "@LoaiHoaDon = " + _LoaiHoaDon + ","
                    + "@GiamGia = " + _GiamGia + ","
                    + "@GiamGiaTyLe = " + _GiamGiaTiLe
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
        public static DataTable UpdateTrangThaiThanhToanCLSYeuCau(string _CLSYeuCau_Id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_007_HoaDon @Action = N'UpdateTrangThaiThanhToanCLSYeuCau', @CLSYeuCau_Id = " + _CLSYeuCau_Id;
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
        public static DataTable UpdateTrangThaiThanhToanToaThuoc(string _ToaThuoc_Id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_007_HoaDon @Action = N'UpdateTrangThaiThanhToanToaThuoc', @ToaThuoc_Id = " + _ToaThuoc_Id;
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
        public static DataTable UpdateGiaTriHoaDon(string _HoaDon_Id, string _GiaTriHoaDon)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_007_HoaDon @Action = N'UpdateGiaTriHoaDon', @HoaDon_Id = " + _HoaDon_Id + ","
                    + "@GiaTriHoaDon = " + _GiaTriHoaDon
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
        public static DataTable SelectHoaDonTheoID(string _HoaDon_Id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_007_HoaDon @Action = N'SelectHoaDonTheoID', @Idx = " + _HoaDon_Id
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
        public static DataTable LoadDanhSachDichVuTheoHoaDon_Id(string _HoaDon_Id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_007_HoaDon @Action = N'LoadDanhSachDichVuTheoHoaDon_Id', @HoaDon_Id = " + _HoaDon_Id
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
        public static DataTable LoadBenhNhan_Id_MaYTe(string _Text)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_007_HoaDon @Action = N'LoadBenhNhan_Id_MaYTe', @Text = " + _Text
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
        public static DataTable HuyHoaDon(string _Idx, string _NguoiCapNhat)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_007_HoaDon @Action = N'HuyHoaDon', @Idx = " + _Idx + ","
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
        public static DataTable HoanTraHoaDon(string _Idx, string _NguoiCapNhat)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_007_HoaDon @Action = N'HoanTraHoaDon', @Idx = " + _Idx + ","
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
        public static DataTable SP_BaoCao_010_HoaDonBanHang(string _HoaDon_Id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_BaoCao_010_HoaDonBanHang @HoaDon_Id = " + _HoaDon_Id
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
