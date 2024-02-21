using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KClinic2._1.Model
{
    class dbGPB
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
                cmd_Show.CommandText = "exec SP_008_GPB @Action=N'BacSiKetLuan'"
                    ;
                con.Open();
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
                cmd_Show.CommandText = "exec SP_008_GPB @Action=N'CheckDaCoKetQuaTheoSoPhieuYeuCau',"
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
                cmd_Show.CommandText = "exec SP_008_GPB @Action=N'LayThongTinSoPhieuYeuCau',"
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
                cmd_Show.CommandText = "exec SP_008_GPB @Action=N'LoadThongTinBenhNhanTheoSoPhieuYeuCau',"
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
                  string _KhongCoTonThuong
                , string _Trichomononas
                , string _Candida
                , string _TapKhan
                , string _Actinomyces
                , string _Herpes
                , string _Cytomegalo
                , string _ChuyenSanGai
                , string _ThayDoiSung
                , string _ChuyenSanTuyen
                , string _Teo
                , string _ThayDoiLienQuanThaiky
                , string _DoViem
                , string _DoXaTri
                , string _DoVongTranhThai
                , string _TinhTrangTeBaoKhac
                , string _BatThuongTeBao
                , string _TeBaoGaiKhongDienHinh
                , string _YNghia
                , string _ChuaLoaiTru
                , string _TonThuongThap
                , string _TonThuongCao
                , string _CarcinomaTeBaoGai
                , string _TeBaoTuyenKhongDienHinh
                , string _TeBaoTuyenCoTrong
                , string _TeBaoNoiMo
                , string _TeBaoTuyen
                , string _TeBaoTuyenCoTrongHuongDenU
                , string _TeBaoTuyenHuongDenU
                , string _CarcinomaTeBaoTuyenCoTron
                , string _CarcinomaTeBaoTuyen
                , string _TuyenCoTrong
                , string _TuyenNoiMac
                , string _TuyenNgoaiTuCung
                , string _TuyenKhongDacHieu
                , string _UAcTinhKhac
                , string _KetLuan
                , string _LoiDan
                , string _BacSiThucHien
                , string _KTVThucHien
                , string _Huy
                , string _NgayTao
                , string _NguoiTao
                , string _NgayCapNhat
                , string _NguoiCapNhat
                , string _CLSYeuCau_Id
                , string _NgayThucHien
                , string _ThoiGianThucHien
                , string _TiepNhan_Id
                , string _BenhNhan_Id
                , string _ChanDoan
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_008_GPB @Action = N'Insert',"
                    + "@KhongCoTonThuong = " + _KhongCoTonThuong + ","
                    + "@Trichomononas = " + _Trichomononas + ","
                    + "@Candida = " + _Candida + ","
                    + "@TapKhan = " + _TapKhan + ","
                    + "@Actinomyces = " + _Actinomyces + ","
                    + "@Herpes = " + _Herpes + ","
                    + "@Cytomegalo = " + _Cytomegalo + ","
                    + "@ChuyenSanGai = " + _ChuyenSanGai + ","
                    + "@ThayDoiSung = " + _ThayDoiSung + ","
                    + "@ChuyenSanTuyen = " + _ChuyenSanTuyen + ","
                    + "@Teo = " + _Teo + ","
                    + "@ThayDoiLienQuanThaiky = " + _ThayDoiLienQuanThaiky + ","
                    + "@DoViem = " + _DoViem + ","
                    + "@DoXaTri = " + _DoXaTri + ","
                    + "@DoVongTranhThai = " + _DoVongTranhThai + ","
                    + "@TinhTrangTeBaoKhac = " + _TinhTrangTeBaoKhac + ","
                    + "@BatThuongTeBao = " + _BatThuongTeBao + ","
                    + "@TeBaoGaiKhongDienHinh = " + _TeBaoGaiKhongDienHinh + ","
                    + "@YNghia = " + _YNghia + ","
                    + "@ChuaLoaiTru = " + _ChuaLoaiTru + ","
                    + "@TonThuongThap = " + _TonThuongThap + ","
                    + "@TonThuongCao = " + _TonThuongCao + ","
                    + "@CarcinomaTeBaoGai = " + _CarcinomaTeBaoGai + ","
                    + "@TeBaoTuyenKhongDienHinh = " + _TeBaoTuyenKhongDienHinh + ","
                    + "@TeBaoTuyenCoTrong = " + _TeBaoTuyenCoTrong + ","
                    + "@TeBaoNoiMo = " + _TeBaoNoiMo + ","
                    + "@TeBaoTuyen = " + _TeBaoTuyen + ","
                    + "@TeBaoTuyenCoTrongHuongDenU = " + _TeBaoTuyenCoTrongHuongDenU + ","
                    + "@TeBaoTuyenHuongDenU = " + _TeBaoTuyenHuongDenU + ","
                    + "@CarcinomaTeBaoTuyenCoTron = " + _CarcinomaTeBaoTuyenCoTron + ","
                    + "@CarcinomaTeBaoTuyen = " + _CarcinomaTeBaoTuyen + ","
                    + "@TuyenCoTrong = " + _TuyenCoTrong + ","
                    + "@TuyenNoiMac = " + _TuyenNoiMac + ","
                    + "@TuyenNgoaiTuCung = " + _TuyenNgoaiTuCung + ","
                    + "@TuyenKhongDacHieu = " + _TuyenKhongDacHieu + ","
                    + "@UAcTinhKhac = " + _UAcTinhKhac + ","
                    + "@KetLuan = " + _KetLuan + ","
                    + "@LoiDan = " + _LoiDan + ","
                    + "@BacSiThucHien = " + _BacSiThucHien + ","
                    + "@KTVThucHien = " + _KTVThucHien + ","
                    + "@Huy = " + _Huy + ","
                    + "@NgayTao = " + _NgayTao + ","
                    + "@NguoiTao = " + _NguoiTao + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ","
                    + "@NguoiCapNhat = " + _NguoiCapNhat + ","
                    + "@CLSYeuCau_Id = " + _CLSYeuCau_Id + ","
                    + "@NgayThucHien = " + _NgayThucHien + ","
                    + "@ThoiGianThucHien = " + _ThoiGianThucHien + ","
                    + "@TiepNhan_Id = " + _TiepNhan_Id + ","
                    + "@BenhNhan_Id = " + _BenhNhan_Id + ","
                    + "@ChanDoan = " + _ChanDoan
                    ;
                con.Open();
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
                  string _KhongCoTonThuong
                , string _Trichomononas
                , string _Candida
                , string _TapKhan
                , string _Actinomyces
                , string _Herpes
                , string _Cytomegalo
                , string _ChuyenSanGai
                , string _ThayDoiSung
                , string _ChuyenSanTuyen
                , string _Teo
                , string _ThayDoiLienQuanThaiky
                , string _DoViem
                , string _DoXaTri
                , string _DoVongTranhThai
                , string _TinhTrangTeBaoKhac
                , string _BatThuongTeBao
                , string _TeBaoGaiKhongDienHinh
                , string _YNghia
                , string _ChuaLoaiTru
                , string _TonThuongThap
                , string _TonThuongCao
                , string _CarcinomaTeBaoGai
                , string _TeBaoTuyenKhongDienHinh
                , string _TeBaoTuyenCoTrong
                , string _TeBaoNoiMo
                , string _TeBaoTuyen
                , string _TeBaoTuyenCoTrongHuongDenU
                , string _TeBaoTuyenHuongDenU
                , string _CarcinomaTeBaoTuyenCoTron
                , string _CarcinomaTeBaoTuyen
                , string _TuyenCoTrong
                , string _TuyenNoiMac
                , string _TuyenNgoaiTuCung
                , string _TuyenKhongDacHieu
                , string _UAcTinhKhac
                , string _KetLuan
                , string _LoiDan
                , string _BacSiThucHien
                , string _KTVThucHien
                , string _Huy
                , string _NgayTao
                , string _NguoiTao
                , string _NgayCapNhat
                , string _NguoiCapNhat
                , string _CLSYeuCau_Id
                , string _NgayThucHien
                , string _ThoiGianThucHien
                , string _TiepNhan_Id
                , string _BenhNhan_Id
                , string _CLSKetQua_Id
                , string _ChanDoan
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_008_GPB @Action = N'Update',"
                    + "@KhongCoTonThuong = " + _KhongCoTonThuong + ","
                    + "@Trichomononas = " + _Trichomononas + ","
                    + "@Candida = " + _Candida + ","
                    + "@TapKhan = " + _TapKhan + ","
                    + "@Actinomyces = " + _Actinomyces + ","
                    + "@Herpes = " + _Herpes + ","
                    + "@Cytomegalo = " + _Cytomegalo + ","
                    + "@ChuyenSanGai = " + _ChuyenSanGai + ","
                    + "@ThayDoiSung = " + _ThayDoiSung + ","
                    + "@ChuyenSanTuyen = " + _ChuyenSanTuyen + ","
                    + "@Teo = " + _Teo + ","
                    + "@ThayDoiLienQuanThaiky = " + _ThayDoiLienQuanThaiky + ","
                    + "@DoViem = " + _DoViem + ","
                    + "@DoXaTri = " + _DoXaTri + ","
                    + "@DoVongTranhThai = " + _DoVongTranhThai + ","
                    + "@TinhTrangTeBaoKhac = " + _TinhTrangTeBaoKhac + ","
                    + "@BatThuongTeBao = " + _BatThuongTeBao + ","
                    + "@TeBaoGaiKhongDienHinh = " + _TeBaoGaiKhongDienHinh + ","
                    + "@YNghia = " + _YNghia + ","
                    + "@ChuaLoaiTru = " + _ChuaLoaiTru + ","
                    + "@TonThuongThap = " + _TonThuongThap + ","
                    + "@TonThuongCao = " + _TonThuongCao + ","
                    + "@CarcinomaTeBaoGai = " + _CarcinomaTeBaoGai + ","
                    + "@TeBaoTuyenKhongDienHinh = " + _TeBaoTuyenKhongDienHinh + ","
                    + "@TeBaoTuyenCoTrong = " + _TeBaoTuyenCoTrong + ","
                    + "@TeBaoNoiMo = " + _TeBaoNoiMo + ","
                    + "@TeBaoTuyen = " + _TeBaoTuyen + ","
                    + "@TeBaoTuyenCoTrongHuongDenU = " + _TeBaoTuyenCoTrongHuongDenU + ","
                    + "@TeBaoTuyenHuongDenU = " + _TeBaoTuyenHuongDenU + ","
                    + "@CarcinomaTeBaoTuyenCoTron = " + _CarcinomaTeBaoTuyenCoTron + ","
                    + "@CarcinomaTeBaoTuyen = " + _CarcinomaTeBaoTuyen + ","
                    + "@TuyenCoTrong = " + _TuyenCoTrong + ","
                    + "@TuyenNoiMac = " + _TuyenNoiMac + ","
                    + "@TuyenNgoaiTuCung = " + _TuyenNgoaiTuCung + ","
                    + "@TuyenKhongDacHieu = " + _TuyenKhongDacHieu + ","
                    + "@UAcTinhKhac = " + _UAcTinhKhac + ","
                    + "@KetLuan = " + _KetLuan + ","
                    + "@LoiDan = " + _LoiDan + ","
                    + "@BacSiThucHien = " + _BacSiThucHien + ","
                    + "@KTVThucHien = " + _KTVThucHien + ","
                    + "@Huy = " + _Huy + ","
                    + "@NgayTao = " + _NgayTao + ","
                    + "@NguoiTao = " + _NguoiTao + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ","
                    + "@NguoiCapNhat = " + _NguoiCapNhat + ","
                    + "@CLSYeuCau_Id = " + _CLSYeuCau_Id + ","
                    + "@NgayThucHien = " + _NgayThucHien + ","
                    + "@ThoiGianThucHien = " + _ThoiGianThucHien + ","
                    + "@TiepNhan_Id = " + _TiepNhan_Id + ","
                    + "@BenhNhan_Id = " + _BenhNhan_Id + ","
                    + "@CLSKetQuaGPB_Id = " + _CLSKetQua_Id + ","
                    + "@ChanDoan = " + _ChanDoan
                    ;
                con.Open();
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
                cmd_Show.CommandText = "exec SP_008_GPB @Action=N'Delete',"
                    + "@CLSKetQuaGPB_Id = " + _CLSKetQua_Id + ","
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
                cmd_Show.CommandText = "exec SP_008_GPB @Action=N'SuaLoadThongTinBenhNhan',"
                    + "@CLSKetQuaGPB_Id = " + _CLSKetQua_Id
                    ;
                con.Open();
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
                cmd_Show.CommandText = "exec SP_008_GPB @Action=N'SuaLoadThongTinBenhNhanTheoSoPhieuYeuCau',"
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
                cmd_Show.CommandText = "exec SP_008_GPB @Action=N'UpdateTrangThaiCLSYeuCau',"
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
                cmd_Show.CommandText = "exec SP_008_GPB @Action=N'DeleteHinhAnh',"
                    + "@CLSKetQuaGPB_Id = " + _CLSKetQua_Id
                    ;
                con.Open();
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
                cmd_Show.CommandText = "exec SP_008_GPB @Action=N'InsertHinhAnh',"
                    + "@CLSKetQuaGPB_Id = " + _CLSKetQua_Id + ","
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
                cmd_Show.CommandText = "exec SP_008_GPB @Action=N'selectHinhAnh',"
                    + "@CLSKetQuaGPB_Id = " + _CLSKetQua_Id
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable SP_BaoCao_013_PhieuKetQuaGPB(string _CLSKetQua_Id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_BaoCao_013_PhieuKetQuaGPB "
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
        
        public static DataTable selectZalo_IdfromCLSKetQua_Id(string _Idx)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_008_GPB "
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
                cmd_Show.CommandText = "exec SP_008_GPB "
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
