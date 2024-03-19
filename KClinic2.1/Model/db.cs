using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace KClinic2._1.Model
{
    class db
    {
        public static int timeout_connecttion = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["timeout_connecttion"]);

        public static string sql = Crypt.Decrypt(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"], "CongtyKCL"); 

        public static SqlConnection con = new SqlConnection(sql);

        public static DataTable checklogin(string _username)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_001_Users @UserCode = N'" + _username + "',@Action = N'CheckLogin'";
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable PhienDangNhap(string _user_id, string _BatDau, string _KetThuc, string _Ip, string _Mac, string _PhongBan_Id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_001_Users @Action = N'PhienDangNhap',"
                    + "@User_Id =" + _user_id + ","
                    + "@ThoiGianDangNhap =" + _BatDau + ","
                    + "@ThoiGianKetThuc =" + _KetThuc + ","
                    + "@Ip =" + _Ip + ","
                    + "@Mac =" + _Mac + ","
                    + "@PhongBan_Id =" + _PhongBan_Id 
                   
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable LoaiTimKiem()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_001_Users @Action = N'LoaiTimKiem'";
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable LoaiTimKiemBenhNhan()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_001_Users @Action = N'LoaiTimKiemBenhNhan'";
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable LoaiTimKiemDangKyKham()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_001_Users @Action = N'LoaiTimKiemDangKyKham'";
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable LoadDanhSachDangKyKhamOnLine(string _Loai, string _text)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_001_Users @Action = N'LoadDanhSachDangKyKhamOnLine',"
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
        public static DataTable Search_BenhNhan(
              string _MaYTe = null
            , string _TenBenhNhan = null
            , string _NamSinh = null
            , string _SDT = null
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_001_Users @Action = N'Search_BenhNhan',"
                    + "@MaYTe = N'" + _MaYTe + "',"
                    + "@TenBenhNhan = N'" + _TenBenhNhan + "',"
                    + "@NamSinh = N'" + _NamSinh + "',"
                    + "@SDT = N'" + _SDT +"'"
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable Search_TiepNhan(
            string _SoTiepNhan
            , DateTime _TuNgay
            , DateTime _DenNgay
            , string _MaYTe
            , string _TenBenhNhan 
            , string _NamSinh 
            , string _SDT 
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_001_Users @Action = N'Search_TiepNhan',"
                    + "@SoTiepNhan = N'" + _SoTiepNhan + "',"
                    + "@TuNgay = '" + _TuNgay.ToString("yyyy-MM-dd") + "',"
                    + "@DenNgay = '" + _DenNgay.ToString("yyyy-MM-dd") + " 23:59:59',"
                    + "@MaYTe = N'" + _MaYTe + "',"
                    + "@TenBenhNhan = N'" + _TenBenhNhan + "',"
                    + "@NamSinh = N'" + _NamSinh + "',"
                    + "@SDT = N'" + _SDT +"'"
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable Search_CDHA_All(string _text)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_001_Users @Action = N'Search_CDHA_All',"
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
        public static DataTable Search_BNVienPhi(string _Loai, string _text)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_001_Users @Action = N'Search_BNVienPhi',"
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

        public static DataTable LayBNVienPhi(string _text = "")
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_001_Users @Action = N'LayBNVienPhi',"
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
        public static DataTable Search_HoaDon(string _Loai, string _text)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_001_Users @Action = N'Search_HoaDon',"
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
        public static DataTable LoaiTimKiemVienPhi()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_001_Users @Action = N'LoaiTimKiemVienPhi'"
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable LoaiTimKiemBNVP()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_001_Users @Action = N'LoaiTimKiemBNVP'"
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable ShowDuongDan()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_001_Users @Action=N'DuongDanBaoCao'"
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable DuongDanHinhAnh()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_001_Users @Action=N'DuongDanHinhAnh'"
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable DuongDanFile()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_001_Users @Action=N'DuongDanFile'"
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable CheckChangePassword(string _User_Id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_001_Users @Action=N'CheckChangePassword',"
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
        public static DataTable ChangePassword(string _User_Id, string _Password)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_001_Users @Action=N'ChangePassword',"
                    + "@User_Id =" + _User_Id + ","
                    + "@Password =N'" + _Password + "'"
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable LoaiTimKiemKhamBenh()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_001_Users @Action = N'LoaiTimKiemKhamBenh'"
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable Search_KhamBenh(string _Loai, string _text)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_001_Users @Action = N'Search_KhamBenh',"
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
        public static DataTable LoaiTimKiemTiepNhan()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_001_Users @Action = N'LoaiTimKiemTiepNhan'"
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable Search_TiepNhanCLS_ChuaThucHien(string _Loai, string _text, string _PhongBan_Id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_001_Users @Action = N'Search_TiepNhanCLS_ChuaThucHien',"
                    + "@Idx =" + _Loai + ","
                    + "@text = N'" + _text + "',"
                    + "@PhongBan_Id = N'" + _PhongBan_Id +"'"
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable LoaiTimKiemKetQuaXetNghiem()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_001_Users @Action = N'LoaiTimKiemKetQuaXetNghiem'"
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable Search_TiepNhanCLS_DaThucHien(string _Loai, string _text,string _PhongBan_Id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_001_Users @Action = N'Search_TiepNhanCLS_DaThucHien',"
                    + "@Idx =" + _Loai + ","
                    + "@text = N'" + _text + "',"
                    + "@PhongBan_Id = N'" + _PhongBan_Id + "'"
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable LoaiTimKiemCLSYeuCau()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_001_Users @Action = N'LoaiTimKiemCLSYeuCau'"
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable Search_CLS_ChuaThucHien(string _Loai, string _text,string _PhongBan_Id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_001_Users @Action = N'Search_CLS_ChuaThucHien',"
                    + "@Idx =" + _Loai + ","
                    + "@text = N'" + _text + "',"
                    + "@PhongBan_Id = N'" + _PhongBan_Id +"'"
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable LoaiTimKiemCLSKetQuaCDHA()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_001_Users @Action = N'LoaiTimKiemCLSKetQuaCDHA'"
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable Search_CLSKetQuaCDHA_DaThucHien(string _Loai, string _text,string _PhongBan_Id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_001_Users @Action = N'Search_CLSKetQuaCDHA_DaThucHien',"
                    + "@Idx =" + _Loai + ","
                    + "@text = N'" + _text + "',"
                    + "@PhongBan_Id = N'" + _PhongBan_Id + "'"
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable Search_BNChuaPhatThuoc(string _Loai, string _text)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_001_Users @Action = N'Search_BNChuaPhatThuoc',"
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
        public static DataTable Search_BNChuaThuTien(string _Loai, string _text)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_001_Users @Action = N'Search_BNChuaThuTien',"
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
        public static DataTable SelectBenhVien()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'SelectBenhVien' "
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable SelectBenhVienTheoID(string _Idx)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'SelectBenhVienTheoID', "
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
        public static DataTable InsertBenhVien(
              string _MaBenhVien
            , string _TenBenhVien
            , string _DiaChi1
            , string _DiaChi2
            , string _DiaChi3
            , string _SoDienThoai1
            , string _SoDienThoai2
            , string _SoDienThoai3
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
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'InsertBenhVien', "
                    + "@MaBenhVien = " + _MaBenhVien + ","
                    + "@TenBenhVien = " + _TenBenhVien + ","
                    + "@DiaChi1 = " + _DiaChi1 + ","
                    + "@DiaChi2 = " + _DiaChi2 + ","
                    + "@DiaChi3 = " + _DiaChi3 + ","
                    + "@SoDienThoai1 = " + _SoDienThoai1 + ","
                    + "@SoDienThoai2 = " + _SoDienThoai2 + ","
                    + "@SoDienThoai3 = " + _SoDienThoai3 + ","
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
        public static DataTable UpdateBenhVien(
              string _MaBenhVien
            , string _TenBenhVien
            , string _DiaChi1
            , string _DiaChi2
            , string _DiaChi3
            , string _SoDienThoai1
            , string _SoDienThoai2
            , string _SoDienThoai3
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
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'UpdateBenhVien', "
                   + "@MaBenhVien = " + _MaBenhVien + ","
                    + "@TenBenhVien = " + _TenBenhVien + ","
                    + "@DiaChi1 = " + _DiaChi1 + ","
                    + "@DiaChi2 = " + _DiaChi2 + ","
                    + "@DiaChi3 = " + _DiaChi3 + ","
                    + "@SoDienThoai1 = " + _SoDienThoai1 + ","
                    + "@SoDienThoai2 = " + _SoDienThoai2 + ","
                    + "@SoDienThoai3 = " + _SoDienThoai3 + ","
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
        public static DataTable DeleteBenhVien(string _Idx, string _NguoiCapNhat)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'DeleteBenhVien', "
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
        public static DataTable CBBBenhVien()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'CBBBenhVien' "
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable SelectUser()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_001_Users @Action = N'SelectUser' "
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable SelectUserTheoID(string _Idx)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_001_Users @Action = N'SelectUserTheoID', "
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
        public static DataTable InsertUser(
              string _UserCode
            , string _UserName
            , string _Password
            , string _BenhVien_Id
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
                cmd_Show.CommandText = "exec SP_001_Users @Action = N'InsertUser', "
                    + "@UserCode = " + _UserCode + ","
                    + "@UserName = " + _UserName + ","
                    + "@Password = " + _Password + ","
                    + "@BenhVien_Id = " + _BenhVien_Id + ","
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
        public static DataTable UpdateUser(
              string _UserCode
            , string _UserName
            , string _Password
            , string _BenhVien_Id
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
                cmd_Show.CommandText = "exec SP_001_Users @Action = N'UpdateUser', "
                  + "@UserCode = " + _UserCode + ","
                    + "@UserName = " + _UserName + ","
                    + "@Password = " + _Password + ","
                    + "@BenhVien_Id = " + _BenhVien_Id + ","
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
        public static DataTable DeleteUser(string _Idx, string _NguoiCapNhat)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_001_Users @Action = N'DeleteUser', "
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
        public static DataTable CBBMenu()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_001_Users @Action = N'CBBMenu' "
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable SelectMenu()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_001_Users @Action = N'SelectMenu' "
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable SelectMenuTheoID(string _Idx)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_001_Users @Action = N'SelectMenuTheoID', "
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
        public static DataTable InsertMenu(
              string _MenuCode
            , string _MenuName
            , string _ParentMenu
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
                cmd_Show.CommandText = "exec SP_001_Users @Action = N'InsertMenu', "
                    + "@MenuCode = " + _MenuCode + ","
                    + "@MenuName = " + _MenuName + ","
                    + "@ParentMenu = " + _ParentMenu + ","
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
        public static DataTable UpdateMenu(
              string _MenuCode
            , string _MenuName
            , string _ParentMenu
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
                cmd_Show.CommandText = "exec SP_001_Users @Action = N'UpdateMenu', "
                    + "@MenuCode = " + _MenuCode + ","
                    + "@MenuName = " + _MenuName + ","
                    + "@ParentMenu = " + _ParentMenu + ","
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
        public static DataTable DeleteMenu(string _Idx, string _NguoiCapNhat)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_001_Users @Action = N'DeleteMenu', "
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
        public static DataTable SelectMenuPermission()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_001_Users @Action = N'SelectMenuPermission' "
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable SelectMenuPermissionParent(string _Text)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_001_Users @Action = N'SelectMenuPermissionParent', "
                    + "@Text = N'" + _Text + "'"
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable SelectMenuPermissionUserId(string _Idx)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_001_Users @Action = N'SelectMenuPermissionUserId', "
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
        public static DataTable DeletePermissionUserId(string _Idx)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_001_Users @Action = N'DeletePermissionUserId', "
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
        public static DataTable InsertPermissionUserId(string _User_Id, string _Menu_Id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_001_Users @Action = N'InsertPermissionUserId', "
                    + "@User_Id = " + _User_Id + ","
                    + "@Menu_Id = " + _Menu_Id
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable SelectUserPermission()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_001_Users @Action = N'SelectUserPermission'"
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable CheckUserPermission(string _User_Id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_001_Users @Action = N'CheckUserPermission', "
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
        public static DataTable SelectSetting()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_001_Users @Action = N'SelectSetting' "
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable SelectSettingTheoID(string _Idx)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_001_Users @Action = N'SelectSettingTheoID', "
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
        public static DataTable InsertSetting(
              string _SettingCode
            , string _SettingName
            , string _NoiDung
            , string _Mota
            , string _Date1
            , string _Date2
            , string _Num1
            , string _Num2
            , string _String1
            , string _String2
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
                cmd_Show.CommandText = "exec SP_001_Users @Action = N'InsertSetting', "
                    + "@SettingCode = " + _SettingCode + ","
                    + "@SettingName = " + _SettingName + ","
                    + "@NoiDung = " + _NoiDung + ","
                    + "@Mota = " + _Mota + ","
                    + "@Date1 = " + _Date1 + ","
                    + "@Date2 = " + _Date2 + ","
                    + "@Num1 = " + _Num1 + ","
                    + "@Num2 = " + _Num2 + ","
                    + "@String1 = " + _String1 + ","
                    + "@String2 = " + _String2 + ","
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
        public static DataTable UpdateSetting(
              string _SettingCode
            , string _SettingName
            , string _NoiDung
            , string _Mota
            , string _Date1
            , string _Date2
            , string _Num1
            , string _Num2
            , string _String1
            , string _String2
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
                cmd_Show.CommandText = "exec SP_001_Users @Action = N'UpdateSetting', "
                    + "@SettingCode = " + _SettingCode + ","
                    + "@SettingName = " + _SettingName + ","
                    + "@NoiDung = " + _NoiDung + ","
                    + "@Mota = " + _Mota + ","
                    + "@Date1 = " + _Date1 + ","
                    + "@Date2 = " + _Date2 + ","
                    + "@Num1 = " + _Num1 + ","
                    + "@Num2 = " + _Num2 + ","
                    + "@String1 = " + _String1 + ","
                    + "@String2 = " + _String2 + ","
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
        public static DataTable DeleteSetting(string _Idx, string _NguoiCapNhat)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_001_Users @Action = N'DeleteSetting', "
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
        public static DataTable SelectSettingTheoSettingCode(string _Text)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_001_Users @Action = N'SelectSettingTheoSettingCode', "
                    + "@Text = N'" + _Text + "'"
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable BenhVien(string _Text)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_001_Users @Action = N'BenhVien', "
                    + "@Text = N'" + _Text + "'"
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable InsertNoiDungEmail(
              string _TieuDe
            , string _NoiDung
            , string _NoiDung_text
            , string _NgayGui
            , string _NguoiGui
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_001_Users @Action = N'InsertNoiDungEmail', "
                    + "@TieuDe = " + _TieuDe + ","
                    + "@NoiDung = " + _NoiDung + ","
                    + "@NoiDung_text = " + _NoiDung_text + ","
                    + "@NgayGui = " + _NgayGui + ","
                    + "@NguoiGui = " + _NguoiGui
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable InsertHinhAnhMail(
              string _NoiDungMail_Id
            , string _HinhAnhDuongDan
            , string _HinhAnhName
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_001_Users @Action = N'InsertHinhAnhMail', "
                    + "@NoiDungMail_Id = " + _NoiDungMail_Id + ","
                    + "@HinhAnhName = " + _HinhAnhName + ","
                    + "@HinhAnhDuongDan = " + _HinhAnhDuongDan
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable DeleteHinhAnhMail(
              string _NoiDungMail_Id

            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_001_Users @Action = N'DeleteHinhAnhMail', "
                    + "@NoiDungMail_Id = " + _NoiDungMail_Id
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable Email()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_001_Users @Action = N'Email'"
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable SelectAccessTokenZalo()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_001_Users @Action=N'SelectAccessTokenZalo'"
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable InsertZaloFile(string _DuongDan
            , string _ToKenFile
            , string _NgayTao
            , string _NguoiTao
            , string _CLSKetQua_Id
            , string _CLSKetQuaCDHA_Id
            , string _KhamBenh_Id
            , string _XetNghiemFile_Id
            , string _HoaDon_Id
            , string _PhieuKham_Id
            , string _CLSKetQuaGPB_Id
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "insert into ZaloFile(DuongDan,TokenFile,NgayTao,NguoiTao,CLSKetQua_Id,CLSKetQuaCDHA_Id,KhamBenh_Id, XetNghiemFile_Id, HoaDon_Id, PhieuKham_Id, CLSKetQuaGPB_Id) select "
                    + _DuongDan + ","
                    + _ToKenFile + ","
                    + _NgayTao + ","
                    + _NguoiTao + ","
                    + _CLSKetQua_Id + ","
                    + _CLSKetQuaCDHA_Id + ","
                    + _KhamBenh_Id + ","
                    + _XetNghiemFile_Id + ","
                    + _HoaDon_Id + ","
                    + _PhieuKham_Id + ","
                    + _CLSKetQuaGPB_Id
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable InsertXetnghiemFile(string _TiepNhan_Id
            , string _BenhNhan_id
            , string _DuongDan
            , string _NgayTao
            , string _NguoiTao
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "insert into XetNghiemFile(TiepNhan_Id,BenhNhan_Id,DuongDan,NgayTao,NguoiTao) select "
                    + _TiepNhan_Id + ","
                    + _BenhNhan_id + ","
                    + _DuongDan + ","
                    + _NgayTao + ","
                    + _NguoiTao
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable SelectZaloFileCLSKetQua_Id(string _IDx)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "select DuongDan,TokenFile from ZaloFile where CLSKetQua_Id = " + _IDx
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable SelectZaloFileCLSKetQuaCDHA_Id(string _IDx)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "select DuongDan,TokenFile from ZaloFile where CLSKetQuaCDHA_Id = " + _IDx
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable SelectZaloFileCLSCLSKetQuaGPB_Id(string _IDx)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "select DuongDan,TokenFile from ZaloFile where CLSKetQuaGPB_Id = " + _IDx
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable SelectZaloFileKhamBenh_Id(string _IDx)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "select DuongDan,TokenFile from ZaloFile where KhamBenh_Id = " + _IDx
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable SelectZaloFileXetNghiemFile_Id(string _IDx)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "select DuongDan,TokenFile from ZaloFile where XetNghiemFile_Id = " + _IDx
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable SelectZaloFileHoaDon_Id(string _IDx)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "select DuongDan,TokenFile from ZaloFile where HoaDon_Id = " + _IDx
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable SelectZaloFilePhieuKham_Id(string _IDx)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "select DuongDan,TokenFile from ZaloFile where PhieuKham_Id = " + _IDx
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable selectBenhSu(string _BenhNhan_Id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_001_Users @Action=N'selectBenhSu', @Idx = " + _BenhNhan_Id
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable selectBenhSuToanBo(string _BenhNhan_Id, string _TuNgay, string _DenNgay)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_001_Users @Action=N'selectBenhSuToanBo', "
                    + "@Idx = " + _BenhNhan_Id + ","
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
        public static DataTable SelectFileXetNghiem_Id(string _Idx)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_001_Users @Action=N'SelectFileXetNghiem_Id', @Idx = " + _Idx
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable ZaloOAId()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_001_Users @Action=N'ZaloOAId'"
                     ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable AccessTokenZalo()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_001_Users @Action=N'AccessTokenZalo'"
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable RefreshTokenZalo()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_001_Users @Action=N'RefreshTokenZalo'"
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable ZaloOAsecret()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_001_Users @Action=N'ZaloOAsecret'"
                     ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable TimeZaloOA()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_001_Users @Action=N'TimeZaloOA'"
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable updateAccessTokenZalo(string _text)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_001_Users @Action=N'updateAccessTokenZalo', @NoiDung = " + _text
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable updateRefreshTokenZalo(string _text)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_001_Users @Action=N'updateRefreshTokenZalo', @NoiDung = " + _text
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable updateTimeZaloOA()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_001_Users @Action=N'updateTimeZaloOA'"
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable selectBenhNhantheoID(string _text)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_001_Users @Action=N'selectBenhNhantheoID', @Text = " + _text
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable Search_CLS_ChuaThucHien_GPB(string _Loai, string _text)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_001_Users @Action = N'Search_CLS_ChuaThucHien_GPB',"
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
        public static DataTable Search_CLSKetQuaGPB_DaThucHien(string _Loai, string _text)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_001_Users @Action = N'Search_CLSKetQuaGPB_DaThucHien',"
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
        public static DataTable Search_GPB_All(string _text)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_001_Users @Action = N'Search_GPB_All',"
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
        public static DataTable SelectPhongBanTheoIdUser(string _user_id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText =
                    "  exec SP_001_Users @Action = 'SelectPhongBanTheoIdUser',"
                    + "@User_Id = " + _user_id;

                ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }

        public static DataTable DelelePhanQuyenPhongBanTheoIdUser(string _user_id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText =
                    "  exec SP_001_Users @Action = 'DelelePhanQuyenPhongBanTheoIdUser',"
                    + "@User_Id = " + _user_id;

                ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }


        public static DataTable InsertPhanQuyenIdUserPhongBan(string _user_id, string _phongBan_Id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText =
                    "  exec SP_001_Users @Action = 'InsertPhanQuyenIdUserPhongBan',"
                    + "@User_Id = " + _user_id + ","
                    + " @PhongBan_Id = " + _phongBan_Id;

                ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable SelectPhongBan_User(string _IDx)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_001_Users @Idx = " + _IDx + ",@Action = N'SelectPhongBan_User'";
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable UpdatePhienDangNhap(string _Idx, string _PhongBan_Id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_001_Users @Action = N'UpdatePhienDangNhap',"
                    + "@Idx =" + _Idx + ","
                    + "@PhongBan_Id =" + _PhongBan_Id 
                   
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }

        

        public static DataTable CheckPhienDangNhapCuoi(string _User_Id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_001_Users @User_Id = " + _User_Id + ",@Action = N'CheckPhienDangNhapCuoi'";
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable SelectPhienDangNhap(string _IDx)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_001_Users @Idx = " + _IDx + ",@Action = N'SelectPhienDangNhap'";
                con.Open();
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
