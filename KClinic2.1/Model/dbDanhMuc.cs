using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KClinic2._1.Model
{
    class dbDanhMuc
    {
        public static int timeout_connecttion = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["timeout_connecttion"]);

        public static string sql = Crypt.Decrypt(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"], "CongtyKCL");

        public static SqlConnection con = new SqlConnection(sql);

        public static DataTable SelectNhomDichVu()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'SelectNhomDichVu' "
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
        public static DataTable SelectNhomDichVuTheoID(string _Idx)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'SelectNhomDichVuTheoID', "
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
        public static DataTable InsertNhomDichVu(
                string _MaNhomDichVu
                , string _TenNhomDichVu
                , string _TamNgung
                , string _NguoiTao
                , string _NgayTao
                , string _NguoiCapNhat
                , string _NgayCapNhat
                , string _Huy
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'InsertNhomDichVu', "
                    + "@MaNhomDichVu = " + _MaNhomDichVu + ","
                    + "@TenNhomDichVu = " + _TenNhomDichVu + ","
                    + "@TamNgung = " + _TamNgung + ","
                    + "@NguoiTao = " + _NguoiTao + ","
                    + "@NgayTao = " + _NgayTao + ","
                    + "@NguoiCapNhat = " + _NguoiCapNhat + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ","
                    + "@Huy = " + _Huy
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
        public static DataTable UpdateNhomDichVu(
                string _MaNhomDichVu
                , string _TenNhomDichVu
                , string _TamNgung
                , string _NguoiTao
                , string _NgayTao
                , string _NguoiCapNhat
                , string _NgayCapNhat
                , string _Huy
                , string _Idx
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'UpdateNhomDichVu', "
                    + "@MaNhomDichVu = " + _MaNhomDichVu + ","
                    + "@TenNhomDichVu = " + _TenNhomDichVu + ","
                    + "@TamNgung = " + _TamNgung + ","
                    + "@NguoiTao = " + _NguoiTao + ","
                    + "@NgayTao = " + _NgayTao + ","
                    + "@NguoiCapNhat = " + _NguoiCapNhat + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ","
                    + "@Huy = " + _Huy + ","
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
        public static DataTable DeleteNhomDichVu(string _Idx, string _NguoiCapNhat)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'DeleteNhomDichVu', "
                    + "@Idx = " + _Idx + ","
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
        public static DataTable CBBNhomDichVu()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'CBBNhomDichVu' "
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
        public static DataTable SelectDichVu()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'SelectDichVu' "
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
        public static DataTable SelectDichVuTheoID(string _Idx)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'SelectDichVuTheoID', "
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
        public static DataTable InsertDichVu(
                  string _MaDichVu
                , string _TenDichVu
                , string _GiaDichVu
                , string _DVT
                , string _CoGiaTriChuan
                , string _Cap
                , string _IsDichVuCha
                , string _CapTren_Id
                , string _NhomDichVu_Id
                , string _TamNgung
                , string _NguoiTao
                , string _NgayTao
                , string _NguoiCapNhat
                , string _NgayCapNhat
                , string _Huy
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'InsertDichVu', "
                    + "@MaDichVu = " + _MaDichVu + ","
                    + "@TenDichVu = " + _TenDichVu + ","
                    + "@GiaDichVu = " + _GiaDichVu + ","
                    + "@DVT = " + _DVT + ","
                    + "@CoGiaTriChuan = " + _CoGiaTriChuan + ","
                    + "@Cap = " + _Cap + ","
                    + "@IsDichVuCha = " + _IsDichVuCha + ","
                    + "@CapTren_Id = " + _CapTren_Id + ","
                    + "@NhomDichVu_Id = " + _NhomDichVu_Id + ","
                    + "@TamNgung = " + _TamNgung + ","
                    + "@NguoiTao = " + _NguoiTao + ","
                    + "@NgayTao = " + _NgayTao + ","
                    + "@NguoiCapNhat = " + _NguoiCapNhat + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ","
                    + "@Huy = " + _Huy
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
        public static DataTable UpdateDichVu(
                  string _MaDichVu
                , string _TenDichVu
                , string _GiaDichVu
                , string _DVT
                , string _CoGiaTriChuan
                , string _Cap
                , string _IsDichVuCha
                , string _CapTren_Id
                , string _NhomDichVu_Id
                , string _TamNgung
                , string _NguoiTao
                , string _NgayTao
                , string _NguoiCapNhat
                , string _NgayCapNhat
                , string _Huy
                , string _Idx
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'UpdateDichVu', "
                    + "@MaDichVu = " + _MaDichVu + ","
                    + "@TenDichVu = " + _TenDichVu + ","
                    + "@GiaDichVu = " + _GiaDichVu + ","
                    + "@DVT = " + _DVT + ","
                    + "@CoGiaTriChuan = " + _CoGiaTriChuan + ","
                    + "@Cap = " + _Cap + ","
                    + "@IsDichVuCha = " + _IsDichVuCha + ","
                    + "@CapTren_Id = " + _CapTren_Id + ","
                    + "@NhomDichVu_Id = " + _NhomDichVu_Id + ","
                    + "@TamNgung = " + _TamNgung + ","
                    + "@NguoiTao = " + _NguoiTao + ","
                    + "@NgayTao = " + _NgayTao + ","
                    + "@NguoiCapNhat = " + _NguoiCapNhat + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ","
                    + "@Huy = " + _Huy + ","
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
        public static DataTable DeleteDichVu(string _Idx, string _NguoiCapNhat)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'DeleteDichVu', "
                    + "@Idx = " + _Idx + ","
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
        public static DataTable CBBDichVuCha()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'CBBDichVuCha' "
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
        public static DataTable SelectDichVuCon()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'SelectDichVuCon' "
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
        public static DataTable SelectDichVuConTheoID(string _Idx)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'SelectDichVuConTheoID', "
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

        public static DataTable SelectDichVuConTheoDichVuCha(string _Idx)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'SelectDichVuConTheoDichVuCha', "
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

        public static DataTable InsertDichVuCon(
                  string _MaDichVu
                , string _TenDichVu
                , string _GiaDichVu
                , string _DVT
                , string _CoGiaTriChuan
                , string _Cap
                , string _IsDichVuCha
                , string _CapTren_Id
                , string _NhomDichVu_Id
                , string _TamNgung
                , string _NguoiTao
                , string _NgayTao
                , string _NguoiCapNhat
                , string _NgayCapNhat
                , string _Huy
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'InsertDichVuCon', "
                    + "@MaDichVu = " + _MaDichVu + ","
                    + "@TenDichVu = " + _TenDichVu + ","
                    + "@GiaDichVu = " + _GiaDichVu + ","
                    + "@DVT = " + _DVT + ","
                    + "@CoGiaTriChuan = " + _CoGiaTriChuan + ","
                    + "@Cap = " + _Cap + ","
                    + "@IsDichVuCha = " + _IsDichVuCha + ","
                    + "@CapTren_Id = " + _CapTren_Id + ","
                    + "@NhomDichVu_Id = " + _NhomDichVu_Id + ","
                    + "@TamNgung = " + _TamNgung + ","
                    + "@NguoiTao = " + _NguoiTao + ","
                    + "@NgayTao = " + _NgayTao + ","
                    + "@NguoiCapNhat = " + _NguoiCapNhat + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ","
                    + "@Huy = " + _Huy
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
        public static DataTable UpdateDichVuCon(
                  string _MaDichVu
                , string _TenDichVu
                , string _GiaDichVu
                , string _DVT
                , string _CoGiaTriChuan
                , string _Cap
                , string _IsDichVuCha
                , string _CapTren_Id
                , string _NhomDichVu_Id
                , string _TamNgung
                , string _NguoiTao
                , string _NgayTao
                , string _NguoiCapNhat
                , string _NgayCapNhat
                , string _Huy
                , string _Idx
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'UpdateDichVuCon', "
                    + "@MaDichVu = " + _MaDichVu + ","
                    + "@TenDichVu = " + _TenDichVu + ","
                    + "@GiaDichVu = " + _GiaDichVu + ","
                    + "@DVT = " + _DVT + ","
                    + "@CoGiaTriChuan = " + _CoGiaTriChuan + ","
                    + "@Cap = " + _Cap + ","
                    + "@IsDichVuCha = " + _IsDichVuCha + ","
                    + "@CapTren_Id = " + _CapTren_Id + ","
                    + "@NhomDichVu_Id = " + _NhomDichVu_Id + ","
                    + "@TamNgung = " + _TamNgung + ","
                    + "@NguoiTao = " + _NguoiTao + ","
                    + "@NgayTao = " + _NgayTao + ","
                    + "@NguoiCapNhat = " + _NguoiCapNhat + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ","
                    + "@Huy = " + _Huy + ","
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
        public static DataTable DeleteDichVuCon(string _Idx, string _NguoiCapNhat)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'DeleteDichVuCon', "
                    + "@Idx = " + _Idx + ","
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
        public static DataTable CBBDichVu()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'CBBDichVu' "
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
        public static DataTable SelectDichVuGiaTriChuan()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'SelectDichVuGiaTriChuan' "
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
        public static DataTable SelectDichVuGiaTriChuanTheoID(string _Idx)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'SelectDichVuGiaTriChuanTheoID', "
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
        public static DataTable InsertDichVuGiaTriChuan(
              string _DichVu_Id
            , string _GiaTriDungChung
            , string _NamMax
            , string _NamMin
            , string _NuMax
            , string _NuMin
            , string _TreEmMax
            , string _TreEmMin
            , string _TamNgung
            , string _NguoiTao
            , string _NgayTao
            , string _NguoiCapNhat
            , string _NgayCapNhat
            , string _Huy
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'InsertDichVuGiaTriChuan', "
                    + "@DichVu_Id = " + _DichVu_Id + ","
                    + "@GiaTriDungChung = " + _GiaTriDungChung + ","
                    + "@NamMax = " + _NamMax + ","
                    + "@NamMin = " + _NamMin + ","
                    + "@NuMax = " + _NuMax + ","
                    + "@NuMin = " + _NuMin + ","
                    + "@TreEmMax = " + _TreEmMax + ","
                    + "@TreEmMin = " + _TreEmMin + ","
                    + "@TamNgung = " + _TamNgung + ","
                    + "@NguoiTao = " + _NguoiTao + ","
                    + "@NgayTao = " + _NgayTao + ","
                    + "@NguoiCapNhat = " + _NguoiCapNhat + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ","
                    + "@Huy = " + _Huy
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
        public static DataTable UpdateDichVuGiaTriChuan(
              string _DichVu_Id
            , string _GiaTriDungChung
            , string _NamMax
            , string _NamMin
            , string _NuMax
            , string _NuMin
            , string _TreEmMax
            , string _TreEmMin
            , string _TamNgung
            , string _NguoiTao
            , string _NgayTao
            , string _NguoiCapNhat
            , string _NgayCapNhat
            , string _Huy
            , string _Idx
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'UpdateDichVuGiaTriChuan', "
                    + "@DichVu_Id = " + _DichVu_Id + ","
                    + "@GiaTriDungChung = " + _GiaTriDungChung + ","
                    + "@NamMax = " + _NamMax + ","
                    + "@NamMin = " + _NamMin + ","
                    + "@NuMax = " + _NuMax + ","
                    + "@NuMin = " + _NuMin + ","
                    + "@TreEmMax = " + _TreEmMax + ","
                    + "@TreEmMin = " + _TreEmMin + ","
                    + "@TamNgung = " + _TamNgung + ","
                    + "@NguoiTao = " + _NguoiTao + ","
                    + "@NgayTao = " + _NgayTao + ","
                    + "@NguoiCapNhat = " + _NguoiCapNhat + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ","
                    + "@Huy = " + _Huy + ","
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
        public static DataTable DeleteDichVuGiaTriChuan(string _Idx, string _NguoiCapNhat)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'DeleteDichVuGiaTriChuan', "
                    + "@Idx = " + _Idx + ","
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
        public static DataTable CheckDichVuGiaTriChuan(string _DichVu_Id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'CheckDichVuGiaTriChuan', "
                    + "@DichVu_Id = " + _DichVu_Id
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
        public static DataTable SelectNhomBenh()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'SelectNhomBenh' "
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
        public static DataTable SelectNhomBenhTheoID(string _Idx)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'SelectNhomBenhTheoID', "
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
        public static DataTable InsertNhomBenh(
              string _MaNhomBenh
            , string _TenNhomBenh
            , string _TamNgung
            , string _NguoiTao
            , string _NgayTao
            , string _NguoiCapNhat
            , string _NgayCapNhat
            , string _Huy
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'InsertNhomBenh', "
                    + "@MaNhomBenh = " + _MaNhomBenh + ","
                    + "@TenNhomBenh = " + _TenNhomBenh + ","
                    + "@TamNgung = " + _TamNgung + ","
                    + "@NguoiTao = " + _NguoiTao + ","
                    + "@NgayTao = " + _NgayTao + ","
                    + "@NguoiCapNhat = " + _NguoiCapNhat + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ","
                    + "@Huy = " + _Huy
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
        public static DataTable UpdateNhomBenh(
              string _MaNhomBenh
            , string _TenNhomBenh
            , string _TamNgung
            , string _NguoiTao
            , string _NgayTao
            , string _NguoiCapNhat
            , string _NgayCapNhat
            , string _Huy
            , string _Idx
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'UpdateNhomBenh', "
                   + "@MaNhomBenh = " + _MaNhomBenh + ","
                    + "@TenNhomBenh = " + _TenNhomBenh + ","
                    + "@TamNgung = " + _TamNgung + ","
                    + "@NguoiTao = " + _NguoiTao + ","
                    + "@NgayTao = " + _NgayTao + ","
                    + "@NguoiCapNhat = " + _NguoiCapNhat + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ","
                    + "@Huy = " + _Huy + ","
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
        public static DataTable DeleteNhomBenh(string _Idx, string _NguoiCapNhat)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'DeleteNhomBenh', "
                    + "@Idx = " + _Idx + ","
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
        public static DataTable CBBNhomBenh()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'CBBNhomBenh' "
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
        public static DataTable CBBDichVuNoiDungNhomBenh()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'CBBDichVuNoiDungNhomBenh' "
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
        public static DataTable SelectNoiDungNhomBenh()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'SelectNoiDungNhomBenh' "
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
        public static DataTable SelectNoiDungNhomBenhTheoID(string _Idx)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'SelectNoiDungNhomBenhTheoID', "
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
        public static DataTable InsertNoiDungNhomBenh(
              string _NhomBenh_Id
            , string _DichVu_Id
            , string _NguoiTao
            , string _NgayTao
            , string _NguoiCapNhat
            , string _NgayCapNhat
            , string _Huy
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'InsertNoiDungNhomBenh', "
                    + "@NhomBenh_Id = " + _NhomBenh_Id + ","
                    + "@DichVu_Id = " + _DichVu_Id + ","
                    + "@NguoiTao = " + _NguoiTao + ","
                    + "@NgayTao = " + _NgayTao + ","
                    + "@NguoiCapNhat = " + _NguoiCapNhat + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ","
                    + "@Huy = " + _Huy
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
        public static DataTable UpdateNoiDungNhomBenh(
              string _NhomBenh_Id
            , string _DichVu_Id
            , string _NguoiTao
            , string _NgayTao
            , string _NguoiCapNhat
            , string _NgayCapNhat
            , string _Huy
            , string _Idx
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'UpdateNoiDungNhomBenh', "
                   + "@NhomBenh_Id = " + _NhomBenh_Id + ","
                    + "@DichVu_Id = " + _DichVu_Id + ","
                    + "@NguoiTao = " + _NguoiTao + ","
                    + "@NgayTao = " + _NgayTao + ","
                    + "@NguoiCapNhat = " + _NguoiCapNhat + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ","
                    + "@Huy = " + _Huy + ","
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
        public static DataTable DeleteNoiDungNhomBenh(string _Idx, string _NguoiCapNhat)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'DeleteNoiDungNhomBenh', "
                    + "@Idx = " + _Idx + ","
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
        public static DataTable CheckDichVuNoiDungNhomBenh(string _DichVu_Id, string _NhomBenh_Id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'CheckDichVuNoiDungNhomBenh', "
                    + "@DichVu_Id = " + _DichVu_Id + ","
                    + "@NhomBenh_id = " + _NhomBenh_Id
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
        public static DataTable SelectKTV()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'SelectKTV' "
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
        public static DataTable SelectKTVTheoID(string _Idx)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'SelectKTVTheoID', "
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
        public static DataTable InsertKTV(
              string _TenKTV
            , string _TamNgung
            , string _NguoiTao
            , string _NgayTao
            , string _NguoiCapNhat
            , string _NgayCapNhat
            , string _Huy
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'InsertKTV', "
                    + "@TenKTV = " + _TenKTV + ","
                    + "@TamNgung = " + _TamNgung + ","
                    + "@NguoiTao = " + _NguoiTao + ","
                    + "@NgayTao = " + _NgayTao + ","
                    + "@NguoiCapNhat = " + _NguoiCapNhat + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ","
                    + "@Huy = " + _Huy
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
        public static DataTable UpdateKTV(
              string _TenKTV
            , string _TamNgung
            , string _NguoiTao
            , string _NgayTao
            , string _NguoiCapNhat
            , string _NgayCapNhat
            , string _Huy
            , string _Idx
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'UpdateKTV', "
                   + "@TenKTV = " + _TenKTV + ","
                    + "@TamNgung = " + _TamNgung + ","
                    + "@NguoiTao = " + _NguoiTao + ","
                    + "@NgayTao = " + _NgayTao + ","
                    + "@NguoiCapNhat = " + _NguoiCapNhat + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ","
                    + "@Huy = " + _Huy + ","
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
        public static DataTable DeleteKTV(string _Idx, string _NguoiCapNhat)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'DeleteKTV', "
                    + "@Idx = " + _Idx + ","
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
        public static DataTable SelectBacSi()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'SelectBacSi' "
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
        public static DataTable SelectBacSiTheoID(string _Idx)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'SelectBacSiTheoID', "
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
        public static DataTable InsertBacSi(
              string _TenBacSi
            , string _TamNgung
            , string _NguoiTao
            , string _NgayTao
            , string _NguoiCapNhat
            , string _NgayCapNhat
            , string _Huy
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'InsertBacSi', "
                    + "@TenBacSi = " + _TenBacSi + ","
                    + "@TamNgung = " + _TamNgung + ","
                    + "@NguoiTao = " + _NguoiTao + ","
                    + "@NgayTao = " + _NgayTao + ","
                    + "@NguoiCapNhat = " + _NguoiCapNhat + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ","
                    + "@Huy = " + _Huy
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
        public static DataTable UpdateBacSi(
              string _TenBacSi
            , string _TamNgung
            , string _NguoiTao
            , string _NgayTao
            , string _NguoiCapNhat
            , string _NgayCapNhat
            , string _Huy
            , string _Idx
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'UpdateBacSi', "
                   + "@TenBacSi = " + _TenBacSi + ","
                    + "@TamNgung = " + _TamNgung + ","
                    + "@NguoiTao = " + _NguoiTao + ","
                    + "@NgayTao = " + _NgayTao + ","
                    + "@NguoiCapNhat = " + _NguoiCapNhat + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ","
                    + "@Huy = " + _Huy + ","
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
        public static DataTable DeleteBacSi(string _Idx, string _NguoiCapNhat)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'DeleteBacSi', "
                    + "@Idx = " + _Idx + ","
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
        public static DataTable SelectLoaiPhongBan()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'SelectLoaiPhongBan' "
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
        public static DataTable SelectLoaiPhongBanTheoID(string _Idx)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'SelectLoaiPhongBanTheoID', "
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
        public static DataTable InserLoaiPhongBan(
                  string _MaLoaiPhongBan
                , string _TenLoaiPhongBan
                , string _TamNgung
                , string _Huy
                , string _NguoiTao
                , string _NgayTao
                , string _NguoiCapNhat
                , string _NgayCapNhat
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'InserLoaiPhongBan', "
                    + "@MaLoaiPhongBan = " + _MaLoaiPhongBan + ","
                    + "@TenLoaiPhongBan = " + _TenLoaiPhongBan + ","
                    + "@TamNgung = " + _TamNgung + ","
                    + "@Huy = " + _Huy + ","
                    + "@NguoiTao = " + _NguoiTao + ","
                    + "@NgayTao = " + _NgayTao + ","
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
        public static DataTable UpdateLoaiPhongBan(
                  string _Idx
                , string _MaLoaiPhongBan
                , string _TenLoaiPhongBan
                , string _TamNgung
                , string _Huy
                , string _NguoiTao
                , string _NgayTao
                , string _NguoiCapNhat
                , string _NgayCapNhat
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'UpdateLoaiPhongBan', "
                    + "@Idx = " + _Idx + ","
                    + "@MaLoaiPhongBan = " + _MaLoaiPhongBan + ","
                    + "@TenLoaiPhongBan = " + _TenLoaiPhongBan + ","
                    + "@TamNgung = " + _TamNgung + ","
                    + "@Huy = " + _Huy + ","
                    + "@NguoiTao = " + _NguoiTao + ","
                    + "@NgayTao = " + _NgayTao + ","
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
        public static DataTable DeleteLoaiPhongBan(string _Idx, string _NguoiCapNhat)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'DeleteLoaiPhongBan', "
                    + "@Idx = " + _Idx + ","
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
        public static DataTable CBBLoaiPhongBan()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'CBBLoaiPhongBan' "
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
        public static DataTable SelectPhongBan()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'SelectPhongBan' "
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
        public static DataTable SelectPhongBanTheoID(string _Idx)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'SelectPhongBanTheoID', "
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
        public static DataTable InsertPhongBan(
                  string _MaPhongBan
                , string _TenPhongBan
                , string _LoaiPhongBan_Id
                , string _TamNgung
                , string _Huy
                , string _NguoiTao
                , string _NgayTao
                , string _NguoiCapNhat
                , string _NgayCapNhat
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'InsertPhongBan', "
                    + "@MaPhongBan = " + _MaPhongBan + ","
                    + "@TenPhongBan = " + _TenPhongBan + ","
                    + "@LoaiPhongBan_Id = " + _LoaiPhongBan_Id + ","
                    + "@TamNgung = " + _TamNgung + ","
                    + "@Huy = " + _Huy + ","
                    + "@NguoiTao = " + _NguoiTao + ","
                    + "@NgayTao = " + _NgayTao + ","
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
        public static DataTable UpdatePhongBan(
                  string _Idx
                , string _MaPhongBan
                , string _TenPhongBan
                , string _LoaiPhongBan_Id
                , string _TamNgung
                , string _Huy
                , string _NguoiTao
                , string _NgayTao
                , string _NguoiCapNhat
                , string _NgayCapNhat
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'UpdatePhongBan', "
                    + "@Idx = " + _Idx + ","
                    + "@MaPhongBan = " + _MaPhongBan + ","
                    + "@TenPhongBan = " + _TenPhongBan + ","
                    + "@LoaiPhongBan_Id = " + _LoaiPhongBan_Id + ","
                    + "@TamNgung = " + _TamNgung + ","
                    + "@Huy = " + _Huy + ","
                    + "@NguoiTao = " + _NguoiTao + ","
                    + "@NgayTao = " + _NgayTao + ","
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
        public static DataTable DeletePhongBan(string _Idx, string _NguoiCapNhat)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'DeletePhongBan', "
                    + "@Idx = " + _Idx + ","
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
        public static DataTable SelectQuocGia()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'SelectQuocGia' "
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
        public static DataTable SelectQuocGiaTheoID(string _Idx)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'SelectQuocGiaTheoID', "
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
        public static DataTable InsertQuocGia(
                  string _MaQuocGia
                , string _TenQuocGia
                , string _TenTiengAnh
                , string _TenLaTin
                , string _TenTat
                , string _TamNgung
                , string _Huy
                , string _NgayTao
                , string _NguoiTao
                , string _NgayCapNhat
                , string _NguoiCapNhat
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'InsertQuocGia', "
                    + "@MaQuocGia = " + _MaQuocGia + ","
                    + "@TenQuocGia = " + _TenQuocGia + ","
                    + "@TenTiengAnh = " + _TenTiengAnh + ","
                    + "@TenLaTin = " + _TenLaTin + ","
                    + "@TenTat = " + _TenTat + ","
                    + "@TamNgung = " + _TamNgung + ","
                    + "@Huy = " + _Huy + ","
                    + "@NgayTao = " + _NgayTao + ","
                    + "@NguoiTao = " + _NguoiTao + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ","
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
        public static DataTable UpdateQuocGia(
                  string _Idx
                , string _MaQuocGia
                , string _TenQuocGia
                , string _TenTiengAnh
                , string _TenLaTin
                , string _TenTat
                , string _TamNgung
                , string _Huy
                , string _NgayTao
                , string _NguoiTao
                , string _NgayCapNhat
                , string _NguoiCapNhat
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'UpdateQuocGia', "
                    + "@Idx = " + _Idx + ","
                    + "@MaQuocGia = " + _MaQuocGia + ","
                    + "@TenQuocGia = " + _TenQuocGia + ","
                    + "@TenTiengAnh = " + _TenTiengAnh + ","
                    + "@TenLaTin = " + _TenLaTin + ","
                    + "@TenTat = " + _TenTat + ","
                    + "@TamNgung = " + _TamNgung + ","
                    + "@Huy = " + _Huy + ","
                    + "@NgayTao = " + _NgayTao + ","
                    + "@NguoiTao = " + _NguoiTao + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ","
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
        public static DataTable DeleteQuocGia(string _Idx, string _NguoiCapNhat)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'DeleteQuocGia', "
                    + "@Idx = " + _Idx + ","
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
        public static DataTable CBBQuocGia()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'CBBQuocGia' "
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
        public static DataTable SelectDonViTinh()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'SelectDonViTinh' "
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
        public static DataTable SelectDonViTinhTheoID(string _Idx)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'SelectDonViTinhTheoID', "
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
        public static DataTable InsertDonViTinh(
                  string _MaDonViTinh
                , string _TenDonViTinh
                , string _LoaiThuoc
                , string _GiaTriQuyDoi
                , string _TamNgung
                , string _Huy
                , string _NgayTao
                , string _NguoiTao
                , string _NgayCapNhat
                , string _NguoiCapNhat
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'InsertDonViTinh', "
                    + "@MaDonViTinh = " + _MaDonViTinh + ","
                    + "@TenDonViTinh = " + _TenDonViTinh + ","
                    + "@LoaiThuoc = " + _LoaiThuoc + ","
                    + "@GiaTriQuyDoi = " + _GiaTriQuyDoi + ","
                    + "@TamNgung = " + _TamNgung + ","
                    + "@Huy = " + _Huy + ","
                    + "@NgayTao = " + _NgayTao + ","
                    + "@NguoiTao = " + _NguoiTao + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ","
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
        public static DataTable UpdateDonViTinh(
                  string _Idx
                , string _MaDonViTinh
                , string _TenDonViTinh
                , string _LoaiThuoc
                , string _GiaTriQuyDoi
                , string _TamNgung
                , string _Huy
                , string _NgayTao
                , string _NguoiTao
                , string _NgayCapNhat
                , string _NguoiCapNhat
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'UpdateDonViTinh', "
                    + "@Idx = " + _Idx + ","
                    + "@MaDonViTinh = " + _MaDonViTinh + ","
                    + "@TenDonViTinh = " + _TenDonViTinh + ","
                    + "@LoaiThuoc = " + _LoaiThuoc + ","
                    + "@GiaTriQuyDoi = " + _GiaTriQuyDoi + ","
                    + "@TamNgung = " + _TamNgung + ","
                    + "@Huy = " + _Huy + ","
                    + "@NgayTao = " + _NgayTao + ","
                    + "@NguoiTao = " + _NguoiTao + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ","
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
        public static DataTable DeleteDonViTinh(string _Idx, string _NguoiCapNhat)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'DeleteDonViTinh', "
                    + "@Idx = " + _Idx + ","
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
        public static DataTable CBBDonViTinh()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'CBBDonViTinh'"
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
        
        public static DataTable SelectLoaiDuoc()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'SelectLoaiDuoc' "
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
        public static DataTable SelectLoaiDuocTheoID(string _Idx)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'SelectLoaiDuocTheoID', "
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
        public static DataTable InsertLoaiDuoc(
                   string _MaLoaiDuoc
                , string _TenLoaiDuoc
                , string _TamNgung
                , string _Huy
                , string _NgayTao
                , string _NguoiTao
                , string _NgayCapNhat
                , string _NguoiCapNhat
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'InsertLoaiDuoc', "
                    + "@MaLoaiDuoc = " + _MaLoaiDuoc + ","
                    + "@TenLoaiDuoc = " + _TenLoaiDuoc + ","
                    + "@TamNgung = " + _TamNgung + ","
                    + "@Huy = " + _Huy + ","
                    + "@NgayTao = " + _NgayTao + ","
                    + "@NguoiTao = " + _NguoiTao + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ","
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
        public static DataTable UpdateLoaiDuoc(
                  string _Idx
                , string _MaLoaiDuoc
                , string _TenLoaiDuoc
                , string _TamNgung
                , string _Huy
                , string _NgayTao
                , string _NguoiTao
                , string _NgayCapNhat
                , string _NguoiCapNhat
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'UpdateLoaiDuoc', "
                    + "@Idx = " + _Idx + ","
                    + "@MaLoaiDuoc = " + _MaLoaiDuoc + ","
                    + "@TenLoaiDuoc = " + _TenLoaiDuoc + ","
                    + "@TamNgung = " + _TamNgung + ","
                    + "@Huy = " + _Huy + ","
                    + "@NgayTao = " + _NgayTao + ","
                    + "@NguoiTao = " + _NguoiTao + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ","
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
        public static DataTable DeleteLoaiDuoc(string _Idx, string _NguoiCapNhat)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'DeleteLoaiDuoc', "
                    + "@Idx = " + _Idx + ","
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
        public static DataTable CBBLoaiDuoc()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'CBBLoaiDuoc'"
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
        public static DataTable SelectDM_Duoc()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'SelectDM_Duoc' "
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
        public static DataTable SelectDM_DuocTheoID(string _Idx)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'SelectDM_DuocTheoID', "
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
        public static DataTable InsertDM_Duoc(
                  string _MaDuoc
                , string _TenDuoc
                , string _DonViTinh
                , string _DonViTinh_Id
                , string _HangSanXuat
                , string _HangSanXuat_Id
                , string _QuocGia
                , string _QuocGia_Id
                , string _TenDuocDayDu
                , string _TenKhongDau
                , string _TenHoatChat
                , string _CachSuDung
                , string _HamLuong
                , string _CongDung
                , string _LoaiDuoc_Id
                , string _PhanLoaiDuoc
                , string _DuongDung
                , string _TamNgung
                , string _NgayTao
                , string _NguoiTao
                , string _NgayCapNhat
                , string _NguoiCapNhat
                , string _Huy
                , string _DateStart
                , string _DateEnd
                , string _SoLuongNhapVao
                , string _SoLuongTon
                , string _DonGiaVon
                , string _DonGia
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'InsertDM_Duoc', "
                    + "@MaDuoc = " + _MaDuoc + ","
                    + "@TenDuoc = " + _TenDuoc + ","
                    + "@DonViTinh = " + _DonViTinh + ","
                    + "@DonViTinh_Id = " + _DonViTinh_Id + ","
                    + "@HangSanXuat = " + _HangSanXuat + ","
                    + "@HangSanXuat_Id = " + _HangSanXuat_Id + ","
                    + "@QuocGia = " + _QuocGia + ","
                    + "@QuocGia_Id = " + _QuocGia_Id + ","
                    + "@TenDuocDayDu = " + _TenDuocDayDu + ","
                    + "@TenKhongDau = " + _TenKhongDau + ","
                    + "@TenHoatChat = " + _TenHoatChat + ","
                    + "@CachSuDung = " + _CachSuDung + ","
                    + "@HamLuong = " + _HamLuong + ","
                    + "@CongDung = " + _CongDung + ","
                    + "@LoaiDuoc_Id = " + _LoaiDuoc_Id + ","
                    + "@PhanLoaiDuoc = " + _PhanLoaiDuoc + ","
                    + "@DuongDung = " + _DuongDung + ","
                    + "@TamNgung = " + _TamNgung + ","
                    + "@NgayTao = " + _NgayTao + ","
                    + "@NguoiTao = " + _NguoiTao + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ","
                    + "@NguoiCapNhat = " + _NguoiCapNhat + ","
                    + "@Huy = " + _Huy + ","
                    + "@DateStart = " + _DateStart + ","
                    + "@DateEnd = " + _DateEnd + ","
                    + "@SoLuongNhapVao = " + _SoLuongNhapVao + ","
                    + "@SoLuongTon = " + _SoLuongTon + ","
                    + "@DonGiaVon = " + _DonGiaVon + ","
                    + "@DonGia = " + _DonGia
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
        public static DataTable UpdateDM_Duoc(
                  string _Idx
                , string _MaDuoc
                , string _TenDuoc
                , string _DonViTinh
                , string _DonViTinh_Id
                , string _HangSanXuat
                , string _HangSanXuat_Id
                , string _QuocGia
                , string _QuocGia_Id
                , string _TenDuocDayDu
                , string _TenKhongDau
                , string _TenHoatChat
                , string _CachSuDung
                , string _HamLuong
                , string _CongDung
                , string _LoaiDuoc_Id
                , string _PhanLoaiDuoc
                , string _DuongDung
                , string _TamNgung
                , string _NgayTao
                , string _NguoiTao
                , string _NgayCapNhat
                , string _NguoiCapNhat
                , string _Huy
                , string _DateStart
                , string _DateEnd
                , string _SoLuongNhapVao
                , string _SoLuongTon
                , string _DonGiaVon
                , string _DonGia
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'UpdateDM_Duoc', "
                    + "@Idx = " + _Idx + ","
                    + "@MaDuoc = " + _MaDuoc + ","
                    + "@TenDuoc = " + _TenDuoc + ","
                    + "@DonViTinh = " + _DonViTinh + ","
                    + "@DonViTinh_Id = " + _DonViTinh_Id + ","
                    + "@HangSanXuat = " + _HangSanXuat + ","
                    + "@HangSanXuat_Id = " + _HangSanXuat_Id + ","
                    + "@QuocGia = " + _QuocGia + ","
                    + "@QuocGia_Id = " + _QuocGia_Id + ","
                    + "@TenDuocDayDu = " + _TenDuocDayDu + ","
                    + "@TenKhongDau = " + _TenKhongDau + ","
                    + "@TenHoatChat = " + _TenHoatChat + ","
                    + "@CachSuDung = " + _CachSuDung + ","
                    + "@HamLuong = " + _HamLuong + ","
                    + "@CongDung = " + _CongDung + ","
                    + "@LoaiDuoc_Id = " + _LoaiDuoc_Id + ","
                    + "@PhanLoaiDuoc = " + _PhanLoaiDuoc + ","
                    + "@DuongDung = " + _DuongDung + ","
                    + "@TamNgung = " + _TamNgung + ","
                    + "@NgayTao = " + _NgayTao + ","
                    + "@NguoiTao = " + _NguoiTao + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ","
                    + "@NguoiCapNhat = " + _NguoiCapNhat + ","
                    + "@Huy = " + _Huy + ","
                    + "@DateStart = " + _DateStart + ","
                    + "@DateEnd = " + _DateEnd + ","
                    + "@SoLuongNhapVao = " + _SoLuongNhapVao + ","
                    + "@SoLuongTon = " + _SoLuongTon + ","
                    + "@DonGiaVon = " + _DonGiaVon + ","
                    + "@DonGia = " + _DonGia
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
        public static DataTable DeleteDM_Duoc(string _Idx, string _NguoiCapNhat)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'DeleteDM_Duoc', "
                    + "@Idx = " + _Idx + ","
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
        public static DataTable CBBDM_Duoc()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'CBBDM_Duoc'"
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
        public static DataTable SelectDM_DuocTonKho()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'SelectDM_DuocTonKho'"
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
        public static DataTable SelectDM_DuocTonKho_CheckDate()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'SelectDM_DuocTonKho_CheckDate'"
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
        public static DataTable SelectDM_DuocTonKho_CheckTonKho()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'SelectDM_DuocTonKho_CheckTonKho'"
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
        public static DataTable SelectDM_BacSi_PhongKham_User()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'SelectDM_BacSi_PhongKham_User' "
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
        public static DataTable SelecDM_BacSi_PhongKham_UserTheoID(string _Idx)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'SelecDM_BacSi_PhongKham_UserTheoID', "
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
        public static DataTable InsertDM_BacSi_PhongKham_User(
                  string _User_Id
                , string _BacSi_Id
                , string _PhongBan_Id
                , string _Huy
                , string _NgayTao
                , string _NguoiTao
                , string _NgayCapNhat
                , string _NguoiCapNhat
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'InsertDM_BacSi_PhongKham_User', "
                    + "@User_Id = " + _User_Id + ","
                    + "@BacSi_Id = " + _BacSi_Id + ","
                    + "@PhongBan_Id = " + _PhongBan_Id + ","
                    + "@Huy = " + _Huy + ","
                    + "@NgayTao = " + _NgayTao + ","
                    + "@NguoiTao = " + _NguoiTao + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ","
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
        public static DataTable UpdateDM_BacSi_PhongKham_User(
                  string _Idx
                , string _User_Id
                , string _BacSi_Id
                , string _PhongBan_Id
                , string _Huy
                , string _NgayTao
                , string _NguoiTao
                , string _NgayCapNhat
                , string _NguoiCapNhat
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'UpdateDM_BacSi_PhongKham_User', "
                    + "@Idx = " + _Idx + ","
                    + "@User_Id = " + _User_Id + ","
                    + "@BacSi_Id = " + _BacSi_Id + ","
                    + "@PhongBan_Id = " + _PhongBan_Id + ","
                    + "@Huy = " + _Huy + ","
                    + "@NgayTao = " + _NgayTao + ","
                    + "@NguoiTao = " + _NguoiTao + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ","
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
        public static DataTable DeleteDM_BacSi_PhongKham_User(string _Idx, string _NguoiCapNhat)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'DeleteDM_BacSi_PhongKham_User', "
                    + "@Idx = " + _Idx + ","
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
        public static DataTable CBBPhongBan_PhongKham()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'CBBPhongBan_PhongKham' "
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
        public static DataTable CBBBacSi_PhongKham()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'CBBBacSi_PhongKham' "
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
        public static DataTable CBBUser_PhongKham()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'CBBUser_PhongKham' "
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
        public static DataTable SelectToaThuocMau()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'SelectToaThuocMau' "
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
        public static DataTable SelectToaThuocMauTheoID(string _Idx)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'SelectToaThuocMauTheoID', "
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
        public static DataTable InsertToaThuocMau(
              string _MaToaThuocMau
            , string _TenToaThuocMau
            , string _TamNgung
            , string _NguoiTao
            , string _NgayTao
            , string _NguoiCapNhat
            , string _NgayCapNhat
            , string _Huy
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'InsertToaThuocMau', "
                    + "@MaToaThuocMau = " + _MaToaThuocMau + ","
                    + "@TenToaThuocMau = " + _TenToaThuocMau + ","
                    + "@TamNgung = " + _TamNgung + ","
                    + "@NguoiTao = " + _NguoiTao + ","
                    + "@NgayTao = " + _NgayTao + ","
                    + "@NguoiCapNhat = " + _NguoiCapNhat + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ","
                    + "@Huy = " + _Huy
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
        public static DataTable UpdateToaThuocMau(
              string _MaToaThuocMau
            , string _TenToaThuocMau
            , string _TamNgung
            , string _NguoiTao
            , string _NgayTao
            , string _NguoiCapNhat
            , string _NgayCapNhat
            , string _Huy
            , string _Idx
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'UpdateToaThuocMau', "
                    + "@MaToaThuocMau = " + _MaToaThuocMau + ","
                    + "@TenToaThuocMau = " + _TenToaThuocMau + ","
                    + "@TamNgung = " + _TamNgung + ","
                    + "@NguoiTao = " + _NguoiTao + ","
                    + "@NgayTao = " + _NgayTao + ","
                    + "@NguoiCapNhat = " + _NguoiCapNhat + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ","
                    + "@Huy = " + _Huy + ","
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
        public static DataTable DeleteToaThuocMau(string _Idx, string _NguoiCapNhat)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'DeleteToaThuocMau', "
                    + "@Idx = " + _Idx + ","
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
        public static DataTable CBBToaThuocMau()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'CBBToaThuocMau' "
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
        public static DataTable CBBDuocNoiDungToaThuocMau()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'CBBDuocNoiDungToaThuocMau' "
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
        public static DataTable SelectNoiDungToaThuocMau()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'SelectNoiDungToaThuocMau' "
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
        public static DataTable SelectNoiDungToaThuocMauTheoID(string _Idx)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'SelectNoiDungToaThuocMauTheoID', "
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
        public static DataTable InsertNoiDungToaThuocMau(
              string _ToaThuocMau_Id
            , string _Duoc_Id
            , string _SoLuong
            , string _SoNgay
            , string _Sang
            , string _Trua
            , string _Chieu
            , string _Toi
            , string _NguoiTao
            , string _NgayTao
            , string _NguoiCapNhat
            , string _NgayCapNhat
            , string _Huy

            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'InsertNoiDungToaThuocMau', "
                    + "@ToaThuocMau_Id = " + _ToaThuocMau_Id + ","
                    + "@Duoc_Id = " + _Duoc_Id + ","
                    + "@SoLuong = " + _SoLuong + ","
                    + "@SoNgay = " + _SoNgay + ","
                    + "@Sang = " + _Sang + ","
                    + "@Trua = " + _Trua + ","
                    + "@Chieu = " + _Chieu + ","
                    + "@Toi = " + _Toi + ","
                    + "@NguoiTao = " + _NguoiTao + ","
                    + "@NgayTao = " + _NgayTao + ","
                    + "@NguoiCapNhat = " + _NguoiCapNhat + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ","
                    + "@Huy = " + _Huy 
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
        public static DataTable UpdateNoiDungToaThuocMau(
              string _ToaThuocMau_Id
            , string _Duoc_Id
            , string _SoLuong
            , string _SoNgay
            , string _Sang
            , string _Trua
            , string _Chieu
            , string _Toi
            , string _NguoiTao
            , string _NgayTao
            , string _NguoiCapNhat
            , string _NgayCapNhat
            , string _Huy
            , string _Idx
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'UpdateNoiDungToaThuocMau', "
                    + "@ToaThuocMau_Id = " + _ToaThuocMau_Id + ","
                    + "@Duoc_Id = " + _Duoc_Id + ","
                    + "@SoLuong = " + _SoLuong + ","
                    + "@SoNgay = " + _SoNgay + ","
                    + "@Sang = " + _Sang + ","
                    + "@Trua = " + _Trua + ","
                    + "@Chieu = " + _Chieu + ","
                    + "@Toi = " + _Toi + ","
                    + "@NguoiTao = " + _NguoiTao + ","
                    + "@NgayTao = " + _NgayTao + ","
                    + "@NguoiCapNhat = " + _NguoiCapNhat + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ","
                    + "@Huy = " + _Huy + ","
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
        public static DataTable DeleteNoiDungToaThuocMau(string _Idx, string _NguoiCapNhat)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'DeleteNoiDungToaThuocMau', "
                    + "@Idx = " + _Idx + ","
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
        public static DataTable CheckDuocNoiDungToaThuocMau(string _Duoc_Id, string _ToaThuocMau_Id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'CheckDuocNoiDungToaThuocMau', "
                    + "@Duoc_Id = " + _Duoc_Id + ","
                    + "@ToaThuocMau_Id = " + _ToaThuocMau_Id
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
        public static DataTable SelectLoaiMau()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'SelectLoaiMau' "
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
        public static DataTable SelectLoaiMauTheoID(string _Idx)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'SelectLoaiMauTheoID', "
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
        public static DataTable InsertLoaiMau(
                string _MaLoaiMau
                , string _TenLoaiMau
                , string _TamNgung
                , string _NguoiTao
                , string _NgayTao
                , string _NguoiCapNhat
                , string _NgayCapNhat
                , string _Huy
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'InsertLoaiMau', "
                    + "@MaLoaiMau = " + _MaLoaiMau + ","
                    + "@TenLoaiMau = " + _TenLoaiMau + ","
                    + "@TamNgung = " + _TamNgung + ","
                    + "@NguoiTao = " + _NguoiTao + ","
                    + "@NgayTao = " + _NgayTao + ","
                    + "@NguoiCapNhat = " + _NguoiCapNhat + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ","
                    + "@Huy = " + _Huy
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
        public static DataTable UpdateNLoaiMau(
                string _MaLoaiMau
                , string _TenLoaiMau
                , string _TamNgung
                , string _NguoiTao
                , string _NgayTao
                , string _NguoiCapNhat
                , string _NgayCapNhat
                , string _Huy
                , string _Idx
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'UpdateNLoaiMau', "
                    + "@MaLoaiMau = " + _MaLoaiMau + ","
                    + "@TenLoaiMau = " + _TenLoaiMau + ","
                    + "@TamNgung = " + _TamNgung + ","
                    + "@NguoiTao = " + _NguoiTao + ","
                    + "@NgayTao = " + _NgayTao + ","
                    + "@NguoiCapNhat = " + _NguoiCapNhat + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ","
                    + "@Huy = " + _Huy + ","
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
        public static DataTable DeleteLoaiMau(string _Idx, string _NguoiCapNhat)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'DeleteLoaiMau', "
                    + "@Idx = " + _Idx + ","
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
        public static DataTable SelectTuDienKetLuan()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'SelectTuDienKetLuan' "
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
        public static DataTable SelectTuDienKetLuanTheoID(string _Idx)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'SelectTuDienKetLuanTheoID', "
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
        public static DataTable InsertTuDienKetLuan(
                  string _MaTuDien
                , string _TenTuDien
                , string _STT
                , string _TieuDe
                , string _GioiTinh
                , string _ChanDoan
                , string _TinhNgayDuSinh
                , string _KetLuan
                , string _MoTa
                , string _MoTa_Text
                , string _GhiChu
                , string _LoiDan
                , string _TamNgung
                , string _NgayTao
                , string _NguoiTao
                , string _NgayCapNhat
                , string _NguoiCapNhat
                , string _Huy
                , string _DichVu_Id
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'InsertTuDienKetLuan', "
                    + "@MaTuDien = " + _MaTuDien + ","
                    + "@TenTuDien = " + _TenTuDien + ","
                    + "@STT = " + _STT + ","
                    + "@TieuDe = " + _TieuDe + ","
                    + "@GioiTinh = " + _GioiTinh + ","
                    + "@ChanDoan = " + _ChanDoan + ","
                    + "@TinhNgayDuSinh = " + _TinhNgayDuSinh + ","
                    + "@KetLuan = " + _KetLuan + ","
                    + "@MoTa = " + _MoTa + ","
                    + "@MoTa_Text = " + _MoTa_Text + ","
                    + "@GhiChu = " + _GhiChu + ","
                    + "@LoiDan = " + _LoiDan + ","
                    + "@TamNgung = " + _TamNgung + ","
                    + "@NgayTao = " + _NgayTao + ","
                    + "@NguoiTao = " + _NguoiTao + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ","
                    + "@NguoiCapNhat = " + _NguoiCapNhat + ","
                    + "@Huy = " + _Huy + ","
                    + "@DichVu_Id = " + _DichVu_Id
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
        public static DataTable UpdateTuDienKetLuan(
                  string _MaTuDien
                , string _TenTuDien
                , string _STT
                , string _TieuDe
                , string _GioiTinh
                , string _ChanDoan
                , string _TinhNgayDuSinh
                , string _KetLuan
                , string _MoTa
                , string _MoTa_Text
                , string _GhiChu
                , string _LoiDan
                , string _TamNgung
                , string _NgayTao
                , string _NguoiTao
                , string _NgayCapNhat
                , string _NguoiCapNhat
                , string _Huy
                , string _DichVu_Id
                , string _Idx
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'UpdateTuDienKetLuan', "
                    + "@MaTuDien = " + _MaTuDien + ","
                    + "@TenTuDien = " + _TenTuDien + ","
                    + "@STT = " + _STT + ","
                    + "@TieuDe = " + _TieuDe + ","
                    + "@GioiTinh = " + _GioiTinh + ","
                    + "@ChanDoan = " + _ChanDoan + ","
                    + "@TinhNgayDuSinh = " + _TinhNgayDuSinh + ","
                    + "@KetLuan = " + _KetLuan + ","
                    + "@MoTa = " + _MoTa + ","
                    + "@MoTa_Text = " + _MoTa_Text + ","
                    + "@GhiChu = " + _GhiChu + ","
                    + "@LoiDan = " + _LoiDan + ","
                    + "@TamNgung = " + _TamNgung + ","
                    + "@NgayTao = " + _NgayTao + ","
                    + "@NguoiTao = " + _NguoiTao + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ","
                    + "@NguoiCapNhat = " + _NguoiCapNhat + ","
                    + "@Huy = " + _Huy + ","
                    + "@DichVu_Id = " + _DichVu_Id + ","
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
        public static DataTable DeleteTuDienKetLuan(string _Idx, string _NguoiCapNhat)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'DeleteTuDienKetLuan', "
                    + "@Idx = " + _Idx + ","
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
        public static DataTable GioiTinh()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'GioiTinh'"
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
        public static DataTable CBBDichVuTuDienKetLuan()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'CBBDichVuTuDienKetLuan'"
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
        public static DataTable SelectTuDienChanDoanKhamBenh()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'SelectTuDienChanDoanKhamBenh' "
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
        public static DataTable SelectTuDienChanDoanKhamBenhTheoID(string _Idx)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'SelectTuDienChanDoanKhamBenhTheoID', "
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
        public static DataTable InsertTuDienChanDoanKhamBenh(
                  string _MaTuDien
                , string _TenTuDien
                , string _STT
                , string _TieuDe
                , string _ChanDoan
                , string _TinhNgayDuSinh
                , string _LoiDan
                , string _TamNgung
                , string _NgayTao
                , string _NguoiTao
                , string _NgayCapNhat
                , string _NguoiCapNhat
                , string _Huy
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'InsertTuDienChanDoanKhamBenh', "
                    + "@MaTuDien = " + _MaTuDien + ","
                    + "@TenTuDien = " + _TenTuDien + ","
                    + "@STT = " + _STT + ","
                    + "@TieuDe = " + _TieuDe + ","
                    + "@ChanDoan = " + _ChanDoan + ","
                    + "@TinhNgayDuSinh = " + _TinhNgayDuSinh + ","
                    + "@LoiDan = " + _LoiDan + ","
                    + "@TamNgung = " + _TamNgung + ","
                    + "@NgayTao = " + _NgayTao + ","
                    + "@NguoiTao = " + _NguoiTao + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ","
                    + "@NguoiCapNhat = " + _NguoiCapNhat + ","
                    + "@Huy = " + _Huy
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
        public static DataTable UpdateTuDienChanDoanKhamBenh(
                  string _MaTuDien
                , string _TenTuDien
                , string _STT
                , string _TieuDe
                , string _ChanDoan
                , string _TinhNgayDuSinh
                , string _LoiDan
                , string _TamNgung
                , string _NgayTao
                , string _NguoiTao
                , string _NgayCapNhat
                , string _NguoiCapNhat
                , string _Huy
                , string _Idx
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'UpdateTuDienChanDoanKhamBenh', "
                    + "@MaTuDien = " + _MaTuDien + ","
                    + "@TenTuDien = " + _TenTuDien + ","
                    + "@STT = " + _STT + ","
                    + "@TieuDe = " + _TieuDe + ","
                    + "@ChanDoan = " + _ChanDoan + ","
                    + "@TinhNgayDuSinh = " + _TinhNgayDuSinh + ","
                    + "@LoiDan = " + _LoiDan + ","
                    + "@TamNgung = " + _TamNgung + ","
                    + "@NgayTao = " + _NgayTao + ","
                    + "@NguoiTao = " + _NguoiTao + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ","
                    + "@NguoiCapNhat = " + _NguoiCapNhat + ","
                    + "@Huy = " + _Huy + ","
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
        public static DataTable DeleteTuDienChanDoanKhamBenh(string _Idx, string _NguoiCapNhat)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'DeleteTuDienChanDoanKhamBenh', "
                    + "@Idx = " + _Idx + ","
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
        public static DataTable CBBTuDienChanDoanKhamBenh()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action=N'CBBTuDienChanDoanKhamBenh'"
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
        public static DataTable SelectK_Dictionary()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'SelectK_Dictionary' "
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
        public static DataTable SelecK_DictionaryTheoID(string _Idx)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'SelecK_DictionaryTheoID', "
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
        public static DataTable InsertK_Dictionary(
              string _Dictionary_Code
            , string _Dictionary_Name_Id
            , string _Dictionary_Name
            , string _DienGiai1
            , string _DienGiai2
            , string _DienGiai3
            , string _DienGiai4
            , string _DienGiai5
            , string _TamNgung
            , string _Huy
            , string _NgayTao
            , string _NguoiTao
            , string _NgayCapNhat
            , string _NguoiCapNhat
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'InsertK_Dictionary', "
                    + "@Dictionary_Code = " + _Dictionary_Code + ","
                    + "@Dictionary_Name_Id = " + _Dictionary_Name_Id + ","
                    + "@Dictionary_Name = " + _Dictionary_Name + ","
                    + "@DienGiai1 = " + _DienGiai1 + ","
                    + "@DienGiai2 = " + _DienGiai2 + ","
                    + "@DienGiai3 = " + _DienGiai3 + ","
                    + "@DienGiai4 = " + _DienGiai4 + ","
                    + "@DienGiai5 = " + _DienGiai5 + ","
                    + "@TamNgung = " + _TamNgung + ","
                    + "@Huy = " + _Huy + ","
                    + "@NgayTao = " + _NgayTao + ","
                    + "@NguoiTao = " + _NguoiTao + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ","
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
        public static DataTable UpdateK_Dictionary(
              string _Dictionary_Code
            , string _Dictionary_Name_Id
            , string _Dictionary_Name
            , string _DienGiai1
            , string _DienGiai2
            , string _DienGiai3
            , string _DienGiai4
            , string _DienGiai5
            , string _TamNgung
            , string _Huy
            , string _NgayTao
            , string _NguoiTao
            , string _NgayCapNhat
            , string _NguoiCapNhat
            , string _Idx
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'UpdateK_Dictionary', "
                    + "@Dictionary_Code = " + _Dictionary_Code + ","
                    + "@Dictionary_Name_Id = " + _Dictionary_Name_Id + ","
                    + "@Dictionary_Name = " + _Dictionary_Name + ","
                    + "@DienGiai1 = " + _DienGiai1 + ","
                    + "@DienGiai2 = " + _DienGiai2 + ","
                    + "@DienGiai3 = " + _DienGiai3 + ","
                    + "@DienGiai4 = " + _DienGiai4 + ","
                    + "@DienGiai5 = " + _DienGiai5 + ","
                    + "@TamNgung = " + _TamNgung + ","
                    + "@Huy = " + _Huy + ","
                    + "@NgayTao = " + _NgayTao + ","
                    + "@NguoiTao = " + _NguoiTao + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ","
                    + "@NguoiCapNhat = " + _NguoiCapNhat + ","
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
        public static DataTable DeleteK_Dictionary(string _Idx, string _NguoiCapNhat)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'DeleteK_Dictionary', "
                    + "@Idx = " + _Idx + ","
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
        public static DataTable SelectAllHopDongKSK()
        {

            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "select HopDong_ID,TenCongTy, MaHopDong,So_HD,  convert(nvarchar(50),Ngay_HD,103) as Ngay_HD, GiaTri_HD, Dictionary_Name as HinhThuc," +
                    "convert(nvarchar(50), NgayHieuLuc_HD, 103) as NgayHieuLuc_HD, convert(nvarchar(50), NgayHetHieuLuc_HD, 103) as NgayHetHieuLuc_HD ," +
                    "REPLACE(CAST(Soluong_BN AS varchar(20)), '.00', '') as Soluong_BN,  HinhThucThanhToan_PhatSinh," +
                    "GiaTri_TamUng, GiaTri_PhatSinh,DienGiai from K_KSK_HopDong hd left join K_Dictionary d on d.Dictionary_Id = hd.HinhThucThanhToan_PhatSinh " +
                    "where hd.Huy = 0 ";




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

        public static DataTable InsertHopDongKSK(string _TenCongTy, string _MaHopDong,
            string _So_HD, string _Ngay_HD, string _GiaTri_HD, string _NgayHieuLuc_HD,
                   string _NgayHetHieuLuc_HD, string _Soluong_BN, string _HinhThucThanhToan_PhatSinh,
                   string _GiaTri_TamUng, string _GiaTri_PhatSinh, string _DienGiai,
                   string _NgayTao, string _NguoiTao_Id, string _NgayCapNhat, string _NguoiCapNhat_Id,
                   string _Huy)
        {

            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "declare @Idx int " +
                    "insert into K_KSK_HopDong(TenCongTy, MaHopDong, So_HD, Ngay_HD, GiaTri_HD, NgayHieuLuc_HD, " +
                    "NgayHetHieuLuc_HD, Soluong_BN, HinhThucThanhToan_PhatSinh,GiaTri_TamUng,GiaTri_PhatSinh,DienGiai," +
                    "NgayTao, NguoiTao_Id, NgayCapNhat,NguoiCapNhat_Id, Huy )" +
                    " select " + _TenCongTy + "," + _MaHopDong + "," + _So_HD + "," + _Ngay_HD + "," + _GiaTri_HD + "," + _NgayHieuLuc_HD +
                    "," + _NgayHetHieuLuc_HD + "," + _Soluong_BN + "," + _HinhThucThanhToan_PhatSinh + "," + _GiaTri_TamUng + "," + _GiaTri_PhatSinh +
                     "," + _DienGiai + "," + _NgayTao + "," + _NguoiTao_Id + "," + _NgayCapNhat + "," + _NguoiCapNhat_Id + "," + _Huy +
                     " set @Idx = @@IDENTITY  select HopDong_ID from  K_KSK_HopDong where HopDong_ID = @Idx";

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



        public static DataTable SelectHopDongKSKTheoID(string _HopDong_Id)
        {

            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "select * from KSK_HopDong where HopDong_Id =" + _HopDong_Id;
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

        public static DataTable UpdateHopDongKSK(string _TenCongTy, string _MaHopDong,
           string _So_HD, string _Ngay_HD, string _GiaTri_HD, string _NgayHieuLuc_HD,
                  string _NgayHetHieuLuc_HD, string _Soluong_BN, string _HinhThucThanhToan_PhatSinh,
                  string _GiaTri_TamUng, string _GiaTri_PhatSinh, string _DienGiai,
                string _NgayCapNhat, string _NguoiCapNhat_Id,
                  string _Idx)
        {

            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "UPDATE KSK_HopDong SET TenCongTy = " + _TenCongTy + ", MaHopDong = " + _MaHopDong + ", So_HD = " + _So_HD
                    + ", Ngay_HD =" + _Ngay_HD + ", GiaTri_HD =" + _GiaTri_HD + ", NgayHieuLuc_HD =" + _NgayHieuLuc_HD + ", NgayHetHieuLuc_HD =" + _NgayHetHieuLuc_HD
                     + ", Soluong_BN =" + _Soluong_BN + ", HinhThucThanhToan_PhatSinh =" + _HinhThucThanhToan_PhatSinh
                    + ",GiaTri_TamUng =" + _GiaTri_TamUng + ", GiaTri_PhatSinh = " + _GiaTri_PhatSinh + ", DienGiai =" + _DienGiai
                      + ", NgayCapNhat =" + _NgayCapNhat + ", NguoiCapNhat_Id = " + _NguoiCapNhat_Id + "   WHERE HopDong_ID = " + _Idx
                      + " select HopDong_ID , TenCongTy from KSK_HopDong where  HopDong_ID =  " + _Idx
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

        public static DataTable DeleteHopDongKSK(string _NgayCapNhat, string _NguoiCapNhat_Id, string _Idx)
        {

            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "UPDATE KSK_HopDong SET Huy = 1, "
                      + " NgayCapNhat =" + _NgayCapNhat + ", NguoiCapNhat_Id = " + _NguoiCapNhat_Id + "   WHERE HopDong_ID = " + _Idx
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
        public static DataTable SelectDanhMucDoiTuong()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc  @Action =  N'SelectDanhMucDoiTuong' ";
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
        public static DataTable SelectDanhMucDoiTuongTheoID(string _Idx)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc  @Action =  N'SelectDanhMucDoiTuongTheoID' ,"
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
        public static DataTable InsertDanhMucDoiTuong(
                 string _MaDoiTuong
               , string _TenDoiTuong
               , string _TenDoiTuong_En
               , string _TenDoiTuong_Ru
               , string _MienPhi
               , string _TamNgung
               , string _GhiChu
               , string _TenKhongDau
               , string _Huy
               , string _NguoiTao_Id
               , string _NgayTao
               , string _NguoiCapNhat_Id
               , string _NgayCapNhat
           )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = " exec SP_006_DanhMuc  @Action = N'InsertDanhMucDoiTuong', "
                + "@MaDoiTuong = " + _MaDoiTuong + ","
                + "@TenDoiTuong = " + _TenDoiTuong + ","
                + "@TenDoiTuong_En = " + _TenDoiTuong_En + ","
                + "@TenDoiTuong_Ru = " + _TenDoiTuong_Ru + ","
                + "@MienPhi = " + _MienPhi + ","
                + "@TamNgung = " + _TamNgung + ","
                + "@GhiChu = " + _GhiChu + ","
                + "@TenKhongDau = " + _TenKhongDau + ","
                + "@Huy = " + _Huy + ","
                + "@NguoiTao_Id = " + _NguoiTao_Id + ","
                + "@NgayTao = " + _NgayTao + ","
                + "@NguoiCapNhat_Id = " + _NguoiCapNhat_Id + ","
                + "@NgayCapNhat = " + _NgayCapNhat;
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
        public static DataTable UpdateDanhMucDoiTuong(
                string _MaDoiTuong
               , string _TenDoiTuong
               , string _TenDoiTuong_En
               , string _TenDoiTuong_Ru
               , string _MienPhi
               , string _TamNgung
               , string _GhiChu
               , string _TenKhongDau
               , string _Huy
               , string _NguoiTao_Id
               , string _NgayTao
               , string _NguoiCapNhat_Id
               , string _NgayCapNhat
               , string _Idx
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = " exec SP_006_DanhMuc  @Action = N'UpdateDanhMucDoiTuong', "
                + "@MaDoiTuong = " + _MaDoiTuong + ","
                + "@TenDoiTuong = " + _TenDoiTuong + ","
                + "@TenDoiTuong_En = " + _TenDoiTuong_En + ","
                + "@TenDoiTuong_Ru = " + _TenDoiTuong_Ru + ","
                + "@MienPhi = " + _MienPhi + ","
                + "@TamNgung = " + _TamNgung + ","
                + "@GhiChu = " + _GhiChu + ","
                + "@TenKhongDau = " + _TenKhongDau + ","
                + "@Huy = " + _Huy + ","
                + "@NguoiTao_Id = " + _NguoiTao_Id + ","
                + "@NgayTao = " + _NgayTao + ","
                + "@NguoiCapNhat_Id = " + _NguoiCapNhat_Id + ","
                + "@NgayCapNhat = " + _NgayCapNhat + ","
                + "@Idx = " + _Idx;
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
        public static DataTable DeleteDanhMucDoiTuong(string _Idx, string _NguoiCapNhat_Id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc  @Action = N'DeleteDanhMucDoiTuong', "
                    + "@Idx = " + _Idx + ","
                    + "@NguoiCapNhat_Id = " + _NguoiCapNhat_Id;
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
        public static DataTable SelectDichVuPhongBanParent(string _Idx)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'SelectDichVuPhanQuyenParent', "
                    + "@Text = " + _Idx
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
        public static DataTable SelectPermissionPhongBanId(string _Idx)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'SelectPermissionPhongBanId', "
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

        public static DataTable DeletePermissionPhongBanId(string _Idx)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'DeletePermissionPhongBanId', "
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
        public static DataTable InsertPermissionPhongBanId(string _PhongBan_Id, string _Dich_Id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'InsertPermissionPhongBanId', "
                    + "@PhongBan_Id = " + _PhongBan_Id + ","
                    + "@Dich_Id = " + _Dich_Id
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
        public static DataTable CBBPhongBan()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_002_TiepNhan @Action = N'CBBPhongBan'"


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
        public static DataTable SelectDichVuPhongBan()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'SelectDichVuPhanQuyen' "
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
