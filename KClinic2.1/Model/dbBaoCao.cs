﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KClinic2._1.Model
{
    class dbBaoCao
    {
        public static int timeout_connecttion = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["timeout_connecttion"]);

        public static string sql = Crypt.Decrypt(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"], "CongtyKCL");

        public static SqlConnection con = new SqlConnection(sql);

        public static DataTable SP_BaoCao_006_BaoCaoThongKeThuTien(string _TuNgay, string _DenNgay)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_BaoCao_006_BaoCaoThongKeThuTien "
                    + "@TuNgay = " + _TuNgay + ","
                    + "@DenNgay = " + _DenNgay
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
        public static DataTable SP_BaoCao_014_BaoCaoThongKeBNPhongTuVan(string _TuNgay, string _DenNgay)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "SP_BaoCao_014_BaoCaoThongKeBNPhongTuVan "
                    + "@TuNgay = " + _TuNgay + ","
                    + "@DenNgay = " + _DenNgay
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
        public static DataTable SP_BaoCao_007_BaoCaoThongKeSoLuongChiDinh(string _TuNgay, string _DenNgay, string _NhomDichVu, string _BacSiChiDInh)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_BaoCao_007_BaoCaoThongKeSoLuongChiDinh "
                    + "@TuNgay = " + _TuNgay + ","
                    + "@DenNgay = " + _DenNgay + ","
                    + "@NhomDichVu_Id = " + _NhomDichVu + ","
                    + "@BacSi_Id = " + _BacSiChiDInh
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
        public static DataTable SP_BaoCao_011_BaoCaoThongKeThuTienTheoDichVu(string _TuNgay, string _DenNgay, string _NhomDichVu, string _BacSiChiDInh)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_BaoCao_011_BaoCaoThongKeThuTienTheoDichVu "
                    + "@TuNgay = " + _TuNgay + ","
                    + "@DenNgay = " + _DenNgay + ","
                    + "@NhomDichVu_Id = " + _NhomDichVu + ","
                    + "@BacSi_Id = " + _BacSiChiDInh
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
        public static DataTable SP_BaoCao_008_BaoCaoBNChiDinhDichVu(string _TuNgay, string _DenNgay, string _NhomDichVu, string _BacSiChiDInh)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_BaoCao_008_BaoCaoBNChiDinhDichVu "
                    + "@TuNgay = " + _TuNgay + ","
                    + "@DenNgay = " + _DenNgay + ","
                    + "@NhomDichVu_Id = " + _NhomDichVu + ","
                    + "@BacSi_Id = " + _BacSiChiDInh
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
        public static DataTable SP_BaoCao_013_BaoCaoDoanhThuPhongKham(string _TuNgay, string _DenNgay, string _DoiTuong, string _NhanVien,string _NguoiBaoCao)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_BaoCao_013_BaoCaoDoanhThuPhongKham "
                    + "@TuNgay = " + _TuNgay + ","
                    + "@DenNgay = " + _DenNgay + ","
                    + "@DoiTuong = " + _DoiTuong + ","
                    + "@NhanVien = " + _NhanVien + ","
                    + "@NguoiBaoCao = N'" + _NguoiBaoCao +"'"
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
        public static DataTable SP_BaoCao_009_BaoCaoThongKeDonThuoc(string _TuNgay, string _DenNgay, string _BacSiChiDInh, string _Duoc_Id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_BaoCao_009_BaoCaoThongKeDonThuoc "
                    + "@TuNgay = " + _TuNgay + ","
                    + "@DenNgay = " + _DenNgay + ","
                    + "@Duoc_Id = " + _Duoc_Id + ","
                    + "@BacSi_Id = " + _BacSiChiDInh
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
        public static DataTable SP_BaoCao_011_BaoCaoThongKeThuTienTheoToaThuoc(string _TuNgay, string _DenNgay, string _BacSiChiDInh, string _Duoc_Id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_BaoCao_011_BaoCaoThongKeThuTienTheoToaThuoc "
                    + "@TuNgay = " + _TuNgay + ","
                    + "@DenNgay = " + _DenNgay + ","
                    + "@Duoc_Id = " + _Duoc_Id + ","
                    + "@BacSi_Id = " + _BacSiChiDInh
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
        public static DataTable SP_BaoCao_012_BaoCaoBSThucHienDichVu(string _TuNgay, string _DenNgay, string _NhomDichVu, string _BacSiChiDInh)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_BaoCao_012_BaoCaoBSThucHienDichVu "
                    + "@TuNgay = " + _TuNgay + ","
                    + "@DenNgay = " + _DenNgay + ","
                    + "@NhomDichVu_Id = " + _NhomDichVu + ","
                    + "@BacSi_Id = " + _BacSiChiDInh
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
        public static DataTable cbbNhanVien()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_001_Users @Action = N'cbbNhanVien'";
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

        public static DataTable SP_BaoCao_016_BaoCaoSuDungDichVuThe(string _TuNgay, string _DenNgay, string _SoThe, string _NguoiBaoCao)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_BaoCao_016_BaoCaoSuDungDichVuThe "
                    + "@TuNgay = " + _TuNgay + ","
                    + "@DenNgay = " + _DenNgay + ","
                    + "@SoThe = " + _SoThe + ","
                    + "@NguoiBaoCao = N'" + _NguoiBaoCao + "'"
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                
                return table1;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public static DataTable SP_BaoCao_018_BaoCaoKhachHang(string _TuNgay, string _DenNgay, string _NguoiBaoCao)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_BaoCao_018_BaoCaoKhachHang "
                    + "@TuNgay = " + _TuNgay + ","
                    + "@DenNgay = " + _DenNgay + ","
                    + "@NguoiBaoCao = N'" + _NguoiBaoCao + "'"
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

        public static DataTable SP_BaoCao_019_BaoCaoKhachHangPhongTuVan(string _TuNgay, string _DenNgay, string _PhongTuVan_Id, string _NguoiBaoCao)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_BaoCao_019_BaoCaoThongKeTiepNhanPhongTuVan "
                    + "@TuNgay = " + _TuNgay + ","
                    + "@DenNgay = " + _DenNgay + ","
                       + "@PhongTuVan_Id = " + _PhongTuVan_Id + ","
                    + "@NguoiBaoCao = N'" + _NguoiBaoCao + "'"
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
        public static DataTable SP_BaoCaoXetNghiem(
            string _TuNgay,
            string _DenNgay,
            string _PhongTuVan_Id,
            string _Dich_Id,
            string _TenBenhNhan,
            string _MaYTe,
            string _SoTiepNhan
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_BaoCaoXetNghiem "
                    + "@TuNgay = " + _TuNgay + ","
                    + "@DenNgay = " + _DenNgay +","
                    + "@PhongTuVan_Id = " + _PhongTuVan_Id + ","
                    + "@Dich_Id = " + _Dich_Id + ","
                    + "@TenBenhNhan = '" + _TenBenhNhan + "',"
                    + "@MaYTe = '" + _MaYTe + "',"
                    + "@SoTiepNhan = '" + _SoTiepNhan+"'"
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
