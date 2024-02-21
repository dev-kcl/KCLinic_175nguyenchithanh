using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KClinic2._1.Model
{
    class dbManHinhHangDoi
    {
        public static int timeout_connecttion = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["timeout_connecttion"]);

        public static string sql = Crypt.Decrypt(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"], "CongtyKCL");

        public static SqlConnection con = new SqlConnection(sql);

        public static DataTable DuongDanVideo()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_K_001_Users @Action=N'DuongDanVideo'"
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
        public static DataTable ThemPhienKetNoi(
              string _ManHinh
            , string _IP
            , string _ThoiGianBatDauKetNoi
            , string _ThoiGianKetThucKetNoi
            , string _TrangThai
            , string _Huy
            , string _User_Id
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_008_ManHinhHangDoi @Action=N'ThemPhienKetNoi',"
                    + "@ManHinh = " + _ManHinh + ","
                    + "@IP = " + _IP + ","
                    + "@ThoiGianBatDauKetNoi = " + _ThoiGianBatDauKetNoi + ","
                    + "@ThoiGianKetThucKetNoi = " + _ThoiGianKetThucKetNoi + ","
                    + "@TrangThai = " + _TrangThai + ","
                    + "@Huy = " + _Huy + ","
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
        public static DataTable ShowManHinhHangDoi()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_008_ManHinhHangDoi @Action = N'ShowManHinhHangDoi'";
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
        public static DataTable ShowManHinhHangDoiDangCho()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_008_ManHinhHangDoi @Action = N'ShowManHinhHangDoiDangCho'";
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
        public static DataTable ShowSTTGoiBN(string _HangDoiTiepNhan_Id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_008_ManHinhHangDoi @Action = N'ShowSTTGoiBN',"
                    + "@HangDoiTiepNhan_id = " + _HangDoiTiepNhan_Id
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
        public static DataTable DuongDanAmThanh()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_008_ManHinhHangDoi @Action=N'DuongDanAmThanh'"
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
        public static DataTable ShowManHinhHangDoiDangChoChayChu()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_008_ManHinhHangDoi @Action = N'ShowManHinhHangDoiDangChoChayChu'";
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

        public static DataTable KetThucPhienKetNoi(
              string _ManHinh
            , string _IP
            , string _ThoiGianBatDauKetNoi
            , string _ThoiGianKetThucKetNoi
            , string _TrangThai
            , string _Huy
            , string _User_Id
            , string _PhienKetNoi_Id
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_008_ManHinhHangDoi @Action=N'KetThucPhienKetNoi',"
                    + "@ManHinh = " + _ManHinh + ","
                    + "@IP = " + _IP + ","
                    + "@ThoiGianBatDauKetNoi = " + _ThoiGianBatDauKetNoi + ","
                    + "@ThoiGianKetThucKetNoi = " + _ThoiGianKetThucKetNoi + ","
                    + "@TrangThai = " + _TrangThai + ","
                    + "@Huy = " + _Huy + ","
                    + "@User_Id = " + _User_Id + ","
                    + "@PhienKetNoi_id = " + _PhienKetNoi_Id
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
        public static DataTable Field()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_008_ManHinhHangDoi @Action = N'Field'"
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
        public static DataTable GoiBenhNhan(string _TiepNhan_Id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_008_ManHinhHangDoi @Action = N'GoiBenhNhan',"
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
        public static DataTable Token()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_008_ManHinhHangDoi @Action = N'Token'"
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
        public static DataTable ManHinhChoKham()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_008_ManHinhHangDoi @Action = N'ManHinhChoKham'"

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
        public static DataTable ShowSTTDaKhamLoad(string _PhongBan_Id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_008_ManHinhHangDoi @Action = N'ShowSTTDaKhamLoad',"
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
        public static DataTable CheckUserPhongKham(string _User_Id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_008_ManHinhHangDoi @Action=N'CheckUserPhongKham',"
                    + "@User_Id =" + _User_Id
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
        public static DataTable ShowTenBacSiKham(string _HangDoi_Id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_008_ManHinhHangDoi @Action = N'ShowTenBacSiKham',"
                    + "@HangDoi_Id = " + _HangDoi_Id
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
        public static DataTable ManHinhChoKhamChayChu(string _PhongBan_Id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_008_ManHinhHangDoi @Action = N'ManHinhChoKhamChayChu',"
                    + "@PhongKham_Id = " + _PhongBan_Id
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
        public static DataTable ShowSTTVuaGoiKhamBenh(string _HangDoiPhongKham_Id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_008_ManHinhHangDoi @Action = N'ShowSTTVuaGoiKhamBenh',"
                    + "@HangDoiPhongKham_Id = " + _HangDoiPhongKham_Id
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
