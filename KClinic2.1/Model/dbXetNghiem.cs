using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
namespace KClinic2._1.Model
{
    class dbXetNghiem
    {
        public static int timeout_connecttion = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["timeout_connecttion"]);

        public static string sql = Crypt.Decrypt(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"], "CongtyKCL");

        public static SqlConnection con = new SqlConnection(sql);

        public static DataTable LayThongTinSoTiepNhan(string _TiepNhan_Id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_004_XetNghiem @Action=N'LayThongTinSoTiepNhan',"
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
        public static DataTable LaySoTiepNhanTuTiepNhan_Id(string _TiepNhan_Id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_004_XetNghiem @Action=N'LaySoTiepNhanTuTiepNhan_Id',"
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
        public static DataTable KTVThucHien()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_004_XetNghiem @Action=N'KTVThucHien'"
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable BacSiKetLuan()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_004_XetNghiem @Action=N'BacSiKetLuan'"
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable LoaiMau()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_004_XetNghiem @Action=N'LoaiMau'"
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable ChatLuongMau()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_004_XetNghiem @Action=N'ChatLuongMau'"
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable DM_NhomDichVu()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_004_XetNghiem @Action=N'DM_NhomDichVu'"
                    ;
                con.Open();
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
                cmd_Show.CommandText = "exec SP_004_XetNghiem @Action = N'XemDanhSachTiepNhan' "
                    ;
                con.Open();
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
                cmd_Show.CommandText = "exec SP_004_XetNghiem @Action = N'XemDanhSachTiepNhan_TimKiem', "
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
        public static DataTable CheckDaCoKetQuaTheoSoTiepNhan(string _SoTiepNhan)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_004_XetNghiem @Action=N'CheckDaCoKetQuaTheoSoTiepNhan',"
                    + "@SoTiepNhan = N'" + _SoTiepNhan + "'"
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable LoadThongTinBenhNhanTheoSoTiepNhan(string _SoTiepNhan)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_004_XetNghiem @Action=N'LoadThongTinBenhNhanTheoSoTiepNhan',"
                    + "@SoTiepNhan = N'" + _SoTiepNhan + "'"
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable CheckDaThanhToanTheoSoTiepNhan(string _SoTiepNhan)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_004_XetNghiem @Action=N'CheckDaThanhToanTheoSoTiepNhan',"
                    + "@SoTiepNhan = N'" + _SoTiepNhan + "'"
                    ;
                con.Open();
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
            , string _TiepNhan_Id
            , string _BenhNhan_id
            , string _KTVThucHien_Id
            , string _LoaiMau_Id
            , string _ChatLuongMau_Id
            , string _BacSiKetLuan_Id
            , string _KetLuan
            , string _KetQua
            , string _GhiChu
            , string _NguoiTao
            , string _NgayTao
            , string _NguoiCapNhat
            , string _NgayCapNhat
            , string _Huy
            , string _NgayLayMau
            , string _ThoiGianLayMau
            , string _NguoiLayMau_Id
            , string _NgayNhanMau
            , string _ThoiGianNhanMau
            , string _NguoiNhanMau_Id
            , string _MaVachSID
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_004_XetNghiem @Action = N'Insert',"
                    + "@NgayThucHien = " + _NgayThucHien + ","
                    + "@ThoiGianThucHien = " + _ThoiGianThucHien + ","
                    + "@TiepNhan_Id = " + _TiepNhan_Id + ","
                    + "@BenhNhan_id = " + _BenhNhan_id + ","
                    + "@KTVThucHien_Id = " + _KTVThucHien_Id + ","
                    + "@LoaiMau_Id = " + _LoaiMau_Id + ","
                    + "@ChatLuongMau_Id = " + _ChatLuongMau_Id + ","
                    + "@BacSiKetLuan_Id = " + _BacSiKetLuan_Id + ","
                    + "@KetLuan = " + _KetLuan + ","
                    + "@KetQua = " + _KetQua + ","
                    + "@GhiChu = " + _GhiChu + ","
                    + "@NguoiTao = " + _NguoiTao + ","
                    + "@NgayTao = " + _NgayTao + ","
                    + "@NguoiCapNhat = " + _NguoiCapNhat + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ","
                    + "@Huy = " + _Huy + ","
                    + "@NgayLayMau = " + _NgayLayMau + ","
                    + "@ThoiGianLayMau = " + _ThoiGianLayMau + ","
                    + "@NguoiLayMau_Id = " + _NguoiLayMau_Id + ","
                    + "@NgayNhanMau = " + _NgayNhanMau + ","
                    + "@ThoiGianNhanMau = " + _ThoiGianNhanMau + ","
                    + "@NguoiNhanMau_Id = " + _NguoiNhanMau_Id + ","
                    + "@SID = " + _MaVachSID
                    ;
                con.Open();
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
            , string _TiepNhan_Id
            , string _BenhNhan_id
            , string _KTVThucHien_Id
            , string _LoaiMau_Id
            , string _ChatLuongMau_Id
            , string _BacSiKetLuan_Id
            , string _KetLuan
            , string _KetQua
            , string _GhiChu
            , string _NguoiTao
            , string _NgayTao
            , string _NguoiCapNhat
            , string _NgayCapNhat
            , string _Huy
            , string _CLSKetQua_Id
            , string _NgayLayMau
            , string _ThoiGianLayMau
            , string _NguoiLayMau_Id
            , string _NgayNhanMau
            , string _ThoiGianNhanMau
            , string _NguoiNhanMau_Id
            , string _MaVachSID
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_004_XetNghiem @Action = N'Update',"
                    + "@NgayThucHien = " + _NgayThucHien + ","
                    + "@ThoiGianThucHien = " + _ThoiGianThucHien + ","
                    + "@TiepNhan_Id = " + _TiepNhan_Id + ","
                    + "@BenhNhan_id = " + _BenhNhan_id + ","
                    + "@KTVThucHien_Id = " + _KTVThucHien_Id + ","
                    + "@LoaiMau_Id = " + _LoaiMau_Id + ","
                    + "@ChatLuongMau_Id = " + _ChatLuongMau_Id + ","
                    + "@BacSiKetLuan_Id = " + _BacSiKetLuan_Id + ","
                    + "@KetLuan = " + _KetLuan + ","
                    + "@KetQua = " + _KetQua + ","
                    + "@GhiChu = " + _GhiChu + ","
                    + "@NguoiTao = " + _NguoiTao + ","
                    + "@NgayTao = " + _NgayTao + ","
                    + "@NguoiCapNhat = " + _NguoiCapNhat + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ","
                    + "@Huy = " + _Huy + ","
                    + "@CLSKetQua_Id = " + _CLSKetQua_Id + ","
                    + "@NgayLayMau = " + _NgayLayMau + ","
                    + "@ThoiGianLayMau = " + _ThoiGianLayMau + ","
                    + "@NguoiLayMau_Id = " + _NguoiLayMau_Id + ","
                    + "@NgayNhanMau = " + _NgayNhanMau + ","
                    + "@ThoiGianNhanMau = " + _ThoiGianNhanMau + ","
                    + "@NguoiNhanMau_Id = " + _NguoiNhanMau_Id + ","
                    + "@SID = " + _MaVachSID
                    ;
                con.Open();
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
                cmd_Show.CommandText = "exec SP_004_XetNghiem @Action=N'Delete',"
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
                cmd_Show.CommandText = "exec SP_004_XetNghiem @Action=N'SuaLoadThongTinBenhNhan',"
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
        public static DataTable SuaLoadThongTinBenhNhanTheoSoTiepNhan(string _SoTiepNhan)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_004_XetNghiem @Action=N'SuaLoadThongTinBenhNhanTheoSoTiepNhan',"
                    + "@SoTiepNhan = N'" + _SoTiepNhan + "'"
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable LoadCLSYeuCauTheoTiepNhan_Id(string _TiepNhan_Id)
        {            
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_004_XetNghiem @Action=N'LoadCLSYeuCauTheoTiepNhan_Id',"
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

        public static DataTable LoadCLSYeuCauTheoTiepNhan_Id_WebAPI(string _TiepNhan_Id, string _pathDatabase_Web)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_004_XetNghiem @Action=N'LoadCLSYeuCauTheoTiepNhan_Id_WebAPI',"
                    + "@TiepNhan_Id = " + _TiepNhan_Id + ","
                    + "@PathDatabase_Web = " + _pathDatabase_Web
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }

        public static DataTable UpdateKetQuaCLSYeuCau(string _CLSYeuCau_Id, string _ThoiGianThucHien, string _NgayThucHien, string _KetQua, string _SID)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_004_XetNghiem @Action=N'UpdateKetQuaCLSYeuCau',"
                    + "@CLSYeuCau_Id = " + _CLSYeuCau_Id + ","
                    + "@ThoiGianThucHien = " + _ThoiGianThucHien + ","
                    + "@NgayThucHien = " + _NgayThucHien + ","
                    + "@KetQua = " + _KetQua + ","
                    + "@SID = " + _SID
                    ;
                con.Open();
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
                cmd_Show.CommandText = "exec SP_004_XetNghiem @Action=N'UpdateTrangThaiCLSYeuCau',"
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
        public static DataTable XemDanhSachTraLoiKetQua()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_004_XetNghiem @Action = N'XemDanhSachTraLoiKetQua' "
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable XemDanhSachTraLoiKetQua_TimKiem(string _loai, string _Text)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_004_XetNghiem @Action = N'XemDanhSachTraLoiKetQua_TimKiem', "
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
        public static DataTable SP_BaoCao_004_PhieuKetQuaXetNghiem(string _CLSKetQua_Id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_BaoCao_004_PhieuKetQuaXetNghiem "
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
        public static DataTable NhomDichVuViSinh()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_004_XetNghiem @Action = N'NhomDichVuViSinh' "
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }

        public static DataTable LayDanhSachBNChuaXNTrongNgay(string _text, string _PhongBan_Id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_004_XetNghiem @Action=N'LayDanhSachBNChuaXNTrongNgay', " +
                    "@text = " + _text
                    //+ ","+ "@PhongBan_Id = " + _PhongBan_Id
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }

        public static DataTable UpdateMaVachSID(string _TiepNhan_Id, string _SID)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_004_XetNghiem @Action=N'UpdateMaVachSID',"
                    + "@TiepNhan_Id = " + _TiepNhan_Id + ","
                    + "@SID = " + _SID
                    ;
                con.Open();
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
