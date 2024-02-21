using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KClinic2._1.Model
{
    class dbCDHA
    {
        public static int timeout_connecttion = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["timeout_connecttion"]);

        public static string sql = Crypt.Decrypt(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"], "CongtyKCL");

        public static SqlConnection con = new SqlConnection(sql);

        public static DataTable BacSiKetLuan()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_005_CDHA @Action=N'BacSiKetLuan'"
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
        public static DataTable TuDienKetLuan()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_005_CDHA @Action=N'TuDienKetLuan'"
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
        public static DataTable CheckDaCoKetQuaTheoSoPhieuYeuCau(string _SoPhieuYeuCau)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_005_CDHA @Action=N'CheckDaCoKetQuaTheoSoPhieuYeuCau',"
                    + "@SoPhieuYeuCau = N'" + _SoPhieuYeuCau + "'"
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
        public static DataTable LayThongTinSoPhieuYeuCau(string _CLSYeuCau_Id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_005_CDHA @Action=N'LayThongTinSoPhieuYeuCau',"
                    + "@CLSYeuCau_Id = N'" + _CLSYeuCau_Id + "'"
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
        public static DataTable LoadThongTinBenhNhanTheoSoPhieuYeuCau(string _SoPhieuYeuCau)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_005_CDHA @Action=N'LoadThongTinBenhNhanTheoSoPhieuYeuCau',"
                    + "@SoPhieuYeuCau = N'" + _SoPhieuYeuCau + "'"
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
        public static DataTable Insert(
                  string _NgayThucHien
                , string _ThoiGianThucHien
                , string _CLSYeuCau_Id
                , string _TiepNhan_Id
                , string _BenhNhan_id
                , string _KTVThucHien_Id
                , string _BacSiKetLuan_Id
                , string _KetLuan
                , string _KetQua
                , string _MoTa
                , string _Mota_text
                , string _GhiChu
                , string _LoiDan
                , string _ChanDoan
                , string _LoaiKetQua_Id
                , string _ThoiGianNhanMau
                , string _LoaiMau
                , string _ChatLuongMau
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
                cmd_Show.CommandText = "exec SP_005_CDHA @Action = N'Insert',"
                    + "@NgayThucHien = " + _NgayThucHien + ","
                    + "@ThoiGianThucHien = " + _ThoiGianThucHien + ","
                    + "@CLSYeuCau_Id = " + _CLSYeuCau_Id + ","
                    + "@TiepNhan_Id = " + _TiepNhan_Id + ","
                    + "@BenhNhan_id = " + _BenhNhan_id + ","
                    + "@KTVThucHien_Id = " + _KTVThucHien_Id + ","
                    + "@BacSiKetLuan_Id = " + _BacSiKetLuan_Id + ","
                    + "@KetLuan = " + _KetLuan + ","
                    + "@KetQua = " + _KetQua + ","
                    + "@MoTa = " + _MoTa + ","
                    + "@Mota_text = " + _Mota_text + ","
                    + "@GhiChu = " + _GhiChu + ","
                    + "@LoiDan = " + _LoiDan + ","
                    + "@ChanDoan = " + _ChanDoan + ","
                    + "@LoaiKetQua_Id = " + _LoaiKetQua_Id + ","
                    + "@ThoiGianNhanMau = " + _ThoiGianNhanMau + ","
                    + "@LoaiMau = " + _LoaiMau + ","
                    + "@ChatLuongMau = " + _ChatLuongMau + ","
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
        public static DataTable Update(
                  string _NgayThucHien
                , string _ThoiGianThucHien
                , string _CLSYeuCau_Id
                , string _TiepNhan_Id
                , string _BenhNhan_id
                , string _KTVThucHien_Id
                , string _BacSiKetLuan_Id
                , string _KetLuan
                , string _KetQua
                , string _MoTa
                , string _Mota_text
                , string _GhiChu
                , string _LoiDan
                , string _ChanDoan
                , string _LoaiKetQua_Id
                , string _ThoiGianNhanMau
                , string _LoaiMau
                , string _ChatLuongMau
                , string _NguoiTao
                , string _NgayTao
                , string _NguoiCapNhat
                , string _NgayCapNhat
                , string _Huy
                , string _CLSKetQua_Id
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_005_CDHA @Action = N'Update',"
                  + "@NgayThucHien = " + _NgayThucHien + ","
                    + "@ThoiGianThucHien = " + _ThoiGianThucHien + ","
                    + "@CLSYeuCau_Id = " + _CLSYeuCau_Id + ","
                    + "@TiepNhan_Id = " + _TiepNhan_Id + ","
                    + "@BenhNhan_id = " + _BenhNhan_id + ","
                    + "@KTVThucHien_Id = " + _KTVThucHien_Id + ","
                    + "@BacSiKetLuan_Id = " + _BacSiKetLuan_Id + ","
                    + "@KetLuan = " + _KetLuan + ","
                    + "@KetQua = " + _KetQua + ","
                    + "@MoTa = " + _MoTa + ","
                    + "@Mota_text = " + _Mota_text + ","
                    + "@GhiChu = " + _GhiChu + ","
                    + "@LoiDan = " + _LoiDan + ","
                    + "@ChanDoan = " + _ChanDoan + ","
                    + "@LoaiKetQua_Id = " + _LoaiKetQua_Id + ","
                    + "@ThoiGianNhanMau = " + _ThoiGianNhanMau + ","
                    + "@LoaiMau = " + _LoaiMau + ","
                    + "@ChatLuongMau = " + _ChatLuongMau + ","
                    + "@NguoiTao = " + _NguoiTao + ","
                    + "@NgayTao = " + _NgayTao + ","
                    + "@NguoiCapNhat = " + _NguoiCapNhat + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ","
                    + "@Huy = " + _Huy + ","
                    + "@CLSKetQua_Id = " + _CLSKetQua_Id
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
        public static DataTable Delete(string _CLSKetQua_Id, string _NguoiCapNhat_Id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_005_CDHA @Action=N'Delete',"
                    + "@CLSKetQua_Id = " + _CLSKetQua_Id + ","
                    + "@NguoiCapNhat = " + _NguoiCapNhat_Id
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
        public static DataTable SuaLoadThongTinBenhNhan(string _CLSKetQua_Id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_005_CDHA @Action=N'SuaLoadThongTinBenhNhan',"
                    + "@CLSKetQua_Id = " + _CLSKetQua_Id
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
        public static DataTable SuaLoadThongTinBenhNhanTheoSoPhieuYeuCau(string _SoPhieuYeuCau)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_005_CDHA @Action=N'SuaLoadThongTinBenhNhanTheoSoPhieuYeuCau',"
                    + "@SoPhieuYeuCau = N'" + _SoPhieuYeuCau + "'"
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
        public static DataTable UpdateTrangThaiCLSYeuCau(string _CLSYeuCau_Id, string _TrangThai)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_005_CDHA @Action=N'UpdateTrangThaiCLSYeuCau',"
                    + "@CLSYeuCau_Id = " + _CLSYeuCau_Id + ","
                    + "@KetLuan = " + _TrangThai
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
        public static DataTable DeleteHinhAnh(string _CLSKetQua_Id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_005_CDHA @Action=N'DeleteHinhAnh',"
                    + "@CLSKetQua_Id = " + _CLSKetQua_Id
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
        public static DataTable InsertHinhAnh(string _CLSKetQua_Id, string _link, string _Name)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_005_CDHA @Action=N'InsertHinhAnh',"
                    + "@CLSKetQua_Id = " + _CLSKetQua_Id + ","
                    + "@Name = " + _Name + ","
                    + "@Link = " + _link
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
        public static DataTable selectHinhAnh(string _CLSKetQua_Id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_005_CDHA @Action=N'selectHinhAnh',"
                    + "@CLSKetQua_Id = " + _CLSKetQua_Id
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
        public static DataTable SP_BaoCao_005_PhieuKetQuaCDHA(string _CLSKetQua_Id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "SP_BaoCao_005_PhieuKetQuaCDHA "
                    + "@CLSKetQua_Id = " + _CLSKetQua_Id
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
        public static DataTable selectTuDienKetLuanTuDichVu_Id(string _Idx)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_005_CDHA "
                    + "@Action = N'selectTuDienKetLuanTuDichVu_Id',"
                    + "@IDx = " + _Idx
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
        public static DataTable selectZalo_IdfromCLSKetQua_Id(string _Idx)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_005_CDHA "
                    + "@Action = N'selectZalo_IdfromCLSKetQua_Id',"
                    + "@IDx = " + _Idx
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
        public static DataTable selectMaYTeSoPhieuYeuCauTuCLSYeuCau_Id(string _Idx)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_005_CDHA "
                    + "@Action = N'selectMaYTeSoPhieuYeuCauTuCLSYeuCau_Id',"
                    + "@IDx = " + _Idx
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
