using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KClinic2._1.Model
{
    class dbDuoc
    {
        public static int timeout_connecttion = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["timeout_connecttion"]);

        public static string sql = Crypt.Decrypt(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"], "CongtyKCL");

        public static SqlConnection con = new SqlConnection(sql);

        public static DataTable SelectNhaCungCap()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham  @Action = N'SelectNhaCungCap'"
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable SelectNhaCungCapTheoID(string _Idx)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham  @Action =  N'SelectNhaCungCapTheoID' ,"
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
        public static DataTable InsertNhaCungCap(
                string _MaNhaCungCap
                , string _TenNhaCungCap
                , string _TenNhaCungCap_En
                , string _TenNhaCungCap_Ru
                , string _DiaChi
                , string _DienThoai
                , string _Fax
                , string _Email
                , string _MaSoThue
                , string _GiamDoc
                , string _NguoiLienHe
                , string _NuocNgoai
                , string _NhaNuoc
                , string _TamNgung
                , string _TenKhongDau
                , string _NgayTao
                , string _NguoiTao_Id
                , string _NgayCapNhat
                , string _NguoiCapNhat_Id
                , string _PH_Duoc
                , string _PH_NHM
                , string _PH_TaiSan
                , string _Huy
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = " exec SP_009_DuocPham  @Action = N'InsertNhaCungCap', "
                    + "@MaNhaCungCap = " + _MaNhaCungCap + ","
                    + "@TenNhaCungCap = " + _TenNhaCungCap + ","
                    + "@TenNhaCungCap_En = " + _TenNhaCungCap_En + ","
                    + "@TenNhaCungCap_Ru = " + _TenNhaCungCap_Ru + ","
                    + "@DiaChi = " + _DiaChi + ","
                    + "@DienThoai = " + _DienThoai + ","
                    + "@Fax = " + _Fax + ","
                    + "@Email = " + _Email + ","
                    + "@MaSoThue = " + _MaSoThue + ","
                    + "@GiamDoc = " + _GiamDoc + ","
                    + "@NguoiLienHe = " + _NguoiLienHe + ","
                    + "@NuocNgoai = " + _NuocNgoai + ","
                    + "@NhaNuoc = " + _NhaNuoc + ","
                    + "@TamNgung = " + _TamNgung + ","
                    + "@TenKhongDau = " + _TenKhongDau + ","
                    + "@PH_Duoc = " + _PH_Duoc + ","
                    + "@PH_NHM = " + _PH_NHM + ","
                    + "@PH_TaiSan = " + _PH_TaiSan + ","
                    + "@NgayTao = " + _NgayTao + ","
                    + "@NguoiTao_Id = " + _NguoiTao_Id + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ","
                    + "@NguoiCapNhat_Id = " + _NguoiCapNhat_Id + ","
                    + "@Huy = " + _Huy;


                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable UpdateNhaCungCap(
                   string _MaNhaCungCap
                , string _TenNhaCungCap
                , string _TenNhaCungCap_En
                , string _TenNhaCungCap_Ru
                , string _DiaChi
                , string _DienThoai
                , string _Fax
                , string _Email
                , string _MaSoThue
                , string _GiamDoc
                , string _NguoiLienHe
                , string _NuocNgoai
                , string _NhaNuoc
                , string _TamNgung
                , string _TenKhongDau
                , string _NgayTao
                , string _NguoiTao_Id
                , string _NgayCapNhat
                , string _NguoiCapNhat_Id
                , string _PH_Duoc
                , string _PH_NHM
                , string _PH_TaiSan
                , string _Huy
                , string _Idx
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham  @Action = N'UpdateNhaCungCap', "
                    + "@MaNhaCungCap = " + _MaNhaCungCap + ","
                    + "@TenNhaCungCap = " + _TenNhaCungCap + ","
                    + "@TenNhaCungCap_En = " + _TenNhaCungCap_En + ","
                    + "@TenNhaCungCap_Ru = " + _TenNhaCungCap_Ru + ","
                    + "@DiaChi = " + _DiaChi + ","
                    + "@DienThoai = " + _DienThoai + ","
                    + "@Fax = " + _Fax + ","
                    + "@Email = " + _Email + ","
                    + "@MaSoThue = " + _MaSoThue + ","
                    + "@GiamDoc = " + _GiamDoc + ","
                    + "@NguoiLienHe = " + _NguoiLienHe + ","
                    + "@NuocNgoai = " + _NuocNgoai + ","
                    + "@NhaNuoc = " + _NhaNuoc + ","
                    + "@TamNgung = " + _TamNgung + ","
                    + "@TenKhongDau = " + _TenKhongDau + ","
                    + "@PH_Duoc = " + _PH_Duoc + ","
                    + "@PH_NHM = " + _PH_NHM + ","
                    + "@PH_TaiSan = " + _PH_TaiSan + ","
                      + "@NgayTao = " + _NgayTao + ","
                      + "@NguoiTao_Id = " + _NguoiTao_Id + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ","
                    + "@NguoiCapNhat_Id = " + _NguoiCapNhat_Id + ","
                    + "@Huy = " + _Huy + ","
                    + "@Idx =  " + _Idx;
                ;


                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable DeleteNhaCungCap(string _Idx, string _NguoiCapNhat)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham  @Action = N'DeleteNhaCungCap', "
                    + "@Idx = " + _Idx + ","
                    + "@NguoiCapNhat_Id = " + _NguoiCapNhat;
                ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }

        public static DataTable CBBDM_NhaCungCap()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham  @Action = N'CBBDM_NhaCungCap'"
                ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable CBBDM_DonViGiao()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham  @Action = N'CBBDM_DonViGiao'"
                ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable CBBDM_DonViGiao_ID(string _Idx)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham  @Action = N'CBBDM_DonViGiao_ID', @Idx = " + _Idx
                ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable CBBDM_DonViNhan()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham  @Action = N'CBBDM_DonViNhan'"
                ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable CBBNguoiNhan()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham  @Action = N'CBBNguoiNhan'"
                ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable CBBTrangThaiNCC()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham  @Action = N'CBBTrangThaiNCC'"
                ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable CBBNguonDuocNCC()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham  @Action = N'CBBNguonDuocNCC'"
                ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable CBBMucDichChungTuNCC()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham  @Action = N'CBBMucDichChungTuNCC'"
                ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable SelectChungTuTheoID(string _Idx)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'SelectChungTuTheoID', "
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
        public static DataTable SelectChungTuTheoMaChungTu(string _Idx)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'SelectChungTuTheoMaChungTu', "
                    + "@MaChungTu = " + _Idx
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable InsertChungTu(
              string _MaChungTu
            , string _SoChungTu
            , string _NgayChungTu
            , string _LoaiChungTu
            , string _MucDichChungTu_Id
            , string _KhoXuat_Id
            , string _NguoiGiao_Id
            , string _NguoiGiao
            , string _KhoNhap_Id
            , string _NguoiNhan_Id
            , string _NguoiNhan
            , string _NguoiKiemTra_Id
            , string _NguoiKiemTra
            , string _NguoiDuyet_Id
            , string _NguoiDuyet
            , string _KeToanTruong_Id
            , string _KeToanTruong
            , string _ThuKho_Id
            , string _ThuKho
            , string _SoSeri
            , string _SoHoaDon
            , string _DienGiai
            , string _GiaTri
            , string _GiaTriThanhToan
            , string _TyLeVat
            , string _GiaTriVat
            , string _ThueSuat
            , string _GiaTriThue
            , string _TyleChietKhau
            , string _GiaTriChietKhau
            , string _TienTe_Id
            , string _TyGia
            , string _SoChungTuGoc
            , string _NgayChungTuGoc
            , string _NhaCungCap_Id
            , string _NhaCungCap
            , string _HinhThucThanhToan_Id
            , string _NguonDuoc_Id
            , string _ChungTuLienQuan_Id
            , string _KhamBenh_Id
            , string _ToaThuocNoiTru_Id
            , string _BenhAn_Id
            , string _DaNhanThuoc
            , string _NguoiNhap_Id
            , string _NgayNhap
            , string _TrangThai
            , string _NgayTao
            , string _NguoiTao_Id
            , string _NgayCapNhat
            , string _NguoiCapNhat_Id
            , string _PhieuLinh_Id
            , string _DienGiaiNghiepVuPhatSinh
            , string _DonViGiao_Id
            , string _TyLeVATNhapKhau
            , string _GiaTriVATNhapKhau
            , string _SoSeriNuocNgoai
            , string _SoHoaDonNuocNgoai
            , string _NgayHoaDonNuocNgoai
            , string _KhoSuDung_Id
            , string _LoaiVatTu_Id
            , string _BenhNhan_Id
            , string _TenBenhNhan
            , string _GioiTinh
            , string _NamSinh
            , string _DiaChi
            , string _SoDienThoai
            , string _BacSiGioiThieu_Id
            , string _DoiTuong_Id
            , string _IDChuyen
            , string _ChungTuKeToan
            , string _Status
            , string _Transfer_VienPhi_Id
            , string _PhongBan_Id
            , string _BacSi_Id
            , string _TKNo
            , string _TKCo
            , string _MaChungTuRef
            , string _LoaiChungTuRef
            , string _PhieuLinhCanTru_Id
            , string _KhoThucHien_Id
            , string _KhoDoiUng_Id
            , string _BHYT
            , string _VienPhi
            , string _MauSo
            , string _Huy
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'InsertChungTu', "
                    + "@MaChungTu = " + _MaChungTu + ","
                    + "@SoChungTu = " + _SoChungTu + ","
                    + "@NgayChungTu = " + _NgayChungTu + ","
                    + "@LoaiChungTu = " + _LoaiChungTu + ","
                    + "@MucDichChungTu_Id = " + _MucDichChungTu_Id + ","
                    + "@KhoXuat_Id = " + _KhoXuat_Id + ","
                    + "@NguoiGiao_Id = " + _NguoiGiao_Id + ","
                    + "@NguoiGiao = " + _NguoiGiao + ","
                    + "@KhoNhap_Id = " + _KhoNhap_Id + ","
                    + "@NguoiNhan_Id = " + _NguoiNhan_Id + ","
                    + "@NguoiNhan = " + _NguoiNhan + ","
                    + "@NguoiKiemTra_Id = " + _NguoiKiemTra_Id + ","
                    + "@NguoiKiemTra = " + _NguoiKiemTra + ","
                    + "@NguoiDuyet_Id = " + _NguoiDuyet_Id + ","
                    + "@NguoiDuyet = " + _NguoiDuyet + ","
                    + "@KeToanTruong_Id = " + _KeToanTruong_Id + ","
                    + "@KeToanTruong = " + _KeToanTruong + ","
                    + "@ThuKho_Id = " + _ThuKho_Id + ","
                    + "@ThuKho = " + _ThuKho + ","
                    + "@SoSeri = " + _SoSeri + ","
                    + "@SoHoaDon = " + _SoHoaDon + ","
                    + "@DienGiai = " + _DienGiai + ","
                    + "@GiaTri = " + _GiaTri + ","
                    + "@GiaTriThanhToan = " + _GiaTriThanhToan + ","
                    + "@TyLeVat = " + _TyLeVat + ","
                    + "@GiaTriVat = " + _GiaTriVat + ","
                    + "@ThueSuat = " + _ThueSuat + ","
                    + "@GiaTriThue = " + _GiaTriThue + ","
                    + "@TyleChietKhau = " + _TyleChietKhau + ","
                    + "@GiaTriChietKhau = " + _GiaTriChietKhau + ","
                    + "@TienTe_Id = " + _TienTe_Id + ","
                    + "@TyGia = " + _TyGia + ","
                    + "@SoChungTuGoc = " + _SoChungTuGoc + ","
                    + "@NgayChungTuGoc = " + _NgayChungTuGoc + ","
                    + "@NhaCungCap_Id = " + _NhaCungCap_Id + ","
                    + "@NhaCungCap = " + _NhaCungCap + ","
                    + "@HinhThucThanhToan_Id = " + _HinhThucThanhToan_Id + ","
                    + "@NguonDuoc_Id = " + _NguonDuoc_Id + ","
                    + "@ChungTuLienQuan_Id = " + _ChungTuLienQuan_Id + ","
                    + "@KhamBenh_Id = " + _KhamBenh_Id + ","
                    + "@ToaThuocNoiTru_Id = " + _ToaThuocNoiTru_Id + ","
                    + "@BenhAn_Id = " + _BenhAn_Id + ","
                    + "@DaNhanThuoc = " + _DaNhanThuoc + ","
                    + "@NguoiNhap_Id = " + _NguoiNhap_Id + ","
                    + "@NgayNhap = " + _NgayNhap + ","
                    + "@TrangThai = " + _TrangThai + ","
                    + "@NgayTao = " + _NgayTao + ","
                    + "@NguoiTao_Id = " + _NguoiTao_Id + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ","
                    + "@NguoiCapNhat_Id = " + _NguoiCapNhat_Id + ","
                    + "@PhieuLinh_Id = " + _PhieuLinh_Id + ","
                    + "@DienGiaiNghiepVuPhatSinh = " + _DienGiaiNghiepVuPhatSinh + ","
                    + "@DonViGiao_Id = " + _DonViGiao_Id + ","
                    + "@TyLeVATNhapKhau = " + _TyLeVATNhapKhau + ","
                    + "@GiaTriVATNhapKhau = " + _GiaTriVATNhapKhau + ","
                    + "@SoSeriNuocNgoai = " + _SoSeriNuocNgoai + ","
                    + "@SoHoaDonNuocNgoai = " + _SoHoaDonNuocNgoai + ","
                    + "@NgayHoaDonNuocNgoai = " + _NgayHoaDonNuocNgoai + ","
                    + "@KhoSuDung_Id = " + _KhoSuDung_Id + ","
                    + "@LoaiVatTu_Id = " + _LoaiVatTu_Id + ","
                    + "@BenhNhan_Id = " + _BenhNhan_Id + ","
                    + "@TenBenhNhan = " + _TenBenhNhan + ","
                    + "@GioiTinh = " + _GioiTinh + ","
                    + "@NamSinh = " + _NamSinh + ","
                    + "@DiaChi = " + _DiaChi + ","
                    + "@SoDienThoai = " + _SoDienThoai + ","
                    + "@BacSiGioiThieu_Id = " + _BacSiGioiThieu_Id + ","
                    + "@DoiTuong_Id = " + _DoiTuong_Id + ","
                    + "@IDChuyen = " + _IDChuyen + ","
                    + "@ChungTuKeToan = " + _ChungTuKeToan + ","
                    + "@Status = " + _Status + ","
                    + "@Transfer_VienPhi_Id = " + _Transfer_VienPhi_Id + ","
                    + "@PhongBan_Id = " + _PhongBan_Id + ","
                    + "@BacSi_Id = " + _BacSi_Id + ","
                    + "@TKNo = " + _TKNo + ","
                    + "@TKCo = " + _TKCo + ","
                    + "@MaChungTuRef = " + _MaChungTuRef + ","
                    + "@LoaiChungTuRef = " + _LoaiChungTuRef + ","
                    + "@PhieuLinhCanTru_Id = " + _PhieuLinhCanTru_Id + ","
                    + "@KhoThucHien_Id = " + _KhoThucHien_Id + ","
                    + "@KhoDoiUng_Id = " + _KhoDoiUng_Id + ","
                    + "@BHYT = " + _BHYT + ","
                    + "@VienPhi = " + _VienPhi + ","
                    + "@MauSo = " + _MauSo + ","
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
        public static DataTable UpdateChungTu(
              string _MaChungTu
            , string _SoChungTu
            , string _NgayChungTu
            , string _LoaiChungTu
            , string _MucDichChungTu_Id
            , string _KhoXuat_Id
            , string _NguoiGiao_Id
            , string _NguoiGiao
            , string _KhoNhap_Id
            , string _NguoiNhan_Id
            , string _NguoiNhan
            , string _NguoiKiemTra_Id
            , string _NguoiKiemTra
            , string _NguoiDuyet_Id
            , string _NguoiDuyet
            , string _KeToanTruong_Id
            , string _KeToanTruong
            , string _ThuKho_Id
            , string _ThuKho
            , string _SoSeri
            , string _SoHoaDon
            , string _DienGiai
            , string _GiaTri
            , string _GiaTriThanhToan
            , string _TyLeVat
            , string _GiaTriVat
            , string _ThueSuat
            , string _GiaTriThue
            , string _TyleChietKhau
            , string _GiaTriChietKhau
            , string _TienTe_Id
            , string _TyGia
            , string _SoChungTuGoc
            , string _NgayChungTuGoc
            , string _NhaCungCap_Id
            , string _NhaCungCap
            , string _HinhThucThanhToan_Id
            , string _NguonDuoc_Id
            , string _ChungTuLienQuan_Id
            , string _KhamBenh_Id
            , string _ToaThuocNoiTru_Id
            , string _BenhAn_Id
            , string _DaNhanThuoc
            , string _NguoiNhap_Id
            , string _NgayNhap
            , string _TrangThai
            , string _NgayTao
            , string _NguoiTao_Id
            , string _NgayCapNhat
            , string _NguoiCapNhat_Id
            , string _PhieuLinh_Id
            , string _DienGiaiNghiepVuPhatSinh
            , string _DonViGiao_Id
            , string _TyLeVATNhapKhau
            , string _GiaTriVATNhapKhau
            , string _SoSeriNuocNgoai
            , string _SoHoaDonNuocNgoai
            , string _NgayHoaDonNuocNgoai
            , string _KhoSuDung_Id
            , string _LoaiVatTu_Id
            , string _BenhNhan_Id
            , string _TenBenhNhan
            , string _GioiTinh
            , string _NamSinh
            , string _DiaChi
            , string _SoDienThoai
            , string _BacSiGioiThieu_Id
            , string _DoiTuong_Id
            , string _IDChuyen
            , string _ChungTuKeToan
            , string _Status
            , string _Transfer_VienPhi_Id
            , string _PhongBan_Id
            , string _BacSi_Id
            , string _TKNo
            , string _TKCo
            , string _MaChungTuRef
            , string _LoaiChungTuRef
            , string _PhieuLinhCanTru_Id
            , string _KhoThucHien_Id
            , string _KhoDoiUng_Id
            , string _BHYT
            , string _VienPhi
            , string _MauSo
            , string _Huy
            , string _ChungTu_Id
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'UpdateChungTu', "
                    + "@MaChungTu = " + _MaChungTu + ","
                    + "@SoChungTu = " + _SoChungTu + ","
                    + "@NgayChungTu = " + _NgayChungTu + ","
                    + "@LoaiChungTu = " + _LoaiChungTu + ","
                    + "@MucDichChungTu_Id = " + _MucDichChungTu_Id + ","
                    + "@KhoXuat_Id = " + _KhoXuat_Id + ","
                    + "@NguoiGiao_Id = " + _NguoiGiao_Id + ","
                    + "@NguoiGiao = " + _NguoiGiao + ","
                    + "@KhoNhap_Id = " + _KhoNhap_Id + ","
                    + "@NguoiNhan_Id = " + _NguoiNhan_Id + ","
                    + "@NguoiNhan = " + _NguoiNhan + ","
                    + "@NguoiKiemTra_Id = " + _NguoiKiemTra_Id + ","
                    + "@NguoiKiemTra = " + _NguoiKiemTra + ","
                    + "@NguoiDuyet_Id = " + _NguoiDuyet_Id + ","
                    + "@NguoiDuyet = " + _NguoiDuyet + ","
                    + "@KeToanTruong_Id = " + _KeToanTruong_Id + ","
                    + "@KeToanTruong = " + _KeToanTruong + ","
                    + "@ThuKho_Id = " + _ThuKho_Id + ","
                    + "@ThuKho = " + _ThuKho + ","
                    + "@SoSeri = " + _SoSeri + ","
                    + "@SoHoaDon = " + _SoHoaDon + ","
                    + "@DienGiai = " + _DienGiai + ","
                    + "@GiaTri = " + _GiaTri + ","
                    + "@GiaTriThanhToan = " + _GiaTriThanhToan + ","
                    + "@TyLeVat = " + _TyLeVat + ","
                    + "@GiaTriVat = " + _GiaTriVat + ","
                    + "@ThueSuat = " + _ThueSuat + ","
                    + "@GiaTriThue = " + _GiaTriThue + ","
                    + "@TyleChietKhau = " + _TyleChietKhau + ","
                    + "@GiaTriChietKhau = " + _GiaTriChietKhau + ","
                    + "@TienTe_Id = " + _TienTe_Id + ","
                    + "@TyGia = " + _TyGia + ","
                    + "@SoChungTuGoc = " + _SoChungTuGoc + ","
                    + "@NgayChungTuGoc = " + _NgayChungTuGoc + ","
                    + "@NhaCungCap_Id = " + _NhaCungCap_Id + ","
                    + "@NhaCungCap = " + _NhaCungCap + ","
                    + "@HinhThucThanhToan_Id = " + _HinhThucThanhToan_Id + ","
                    + "@NguonDuoc_Id = " + _NguonDuoc_Id + ","
                    + "@ChungTuLienQuan_Id = " + _ChungTuLienQuan_Id + ","
                    + "@KhamBenh_Id = " + _KhamBenh_Id + ","
                    + "@ToaThuocNoiTru_Id = " + _ToaThuocNoiTru_Id + ","
                    + "@BenhAn_Id = " + _BenhAn_Id + ","
                    + "@DaNhanThuoc = " + _DaNhanThuoc + ","
                    + "@NguoiNhap_Id = " + _NguoiNhap_Id + ","
                    + "@NgayNhap = " + _NgayNhap + ","
                    + "@TrangThai = " + _TrangThai + ","
                    + "@NgayTao = " + _NgayTao + ","
                    + "@NguoiTao_Id = " + _NguoiTao_Id + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ","
                    + "@NguoiCapNhat_Id = " + _NguoiCapNhat_Id + ","
                    + "@PhieuLinh_Id = " + _PhieuLinh_Id + ","
                    + "@DienGiaiNghiepVuPhatSinh = " + _DienGiaiNghiepVuPhatSinh + ","
                    + "@DonViGiao_Id = " + _DonViGiao_Id + ","
                    + "@TyLeVATNhapKhau = " + _TyLeVATNhapKhau + ","
                    + "@GiaTriVATNhapKhau = " + _GiaTriVATNhapKhau + ","
                    + "@SoSeriNuocNgoai = " + _SoSeriNuocNgoai + ","
                    + "@SoHoaDonNuocNgoai = " + _SoHoaDonNuocNgoai + ","
                    + "@NgayHoaDonNuocNgoai = " + _NgayHoaDonNuocNgoai + ","
                    + "@KhoSuDung_Id = " + _KhoSuDung_Id + ","
                    + "@LoaiVatTu_Id = " + _LoaiVatTu_Id + ","
                    + "@BenhNhan_Id = " + _BenhNhan_Id + ","
                    + "@TenBenhNhan = " + _TenBenhNhan + ","
                    + "@GioiTinh = " + _GioiTinh + ","
                    + "@NamSinh = " + _NamSinh + ","
                    + "@DiaChi = " + _DiaChi + ","
                    + "@SoDienThoai = " + _SoDienThoai + ","
                    + "@BacSiGioiThieu_Id = " + _BacSiGioiThieu_Id + ","
                    + "@DoiTuong_Id = " + _DoiTuong_Id + ","
                    + "@IDChuyen = " + _IDChuyen + ","
                    + "@ChungTuKeToan = " + _ChungTuKeToan + ","
                    + "@Status = " + _Status + ","
                    + "@Transfer_VienPhi_Id = " + _Transfer_VienPhi_Id + ","
                    + "@PhongBan_Id = " + _PhongBan_Id + ","
                    + "@BacSi_Id = " + _BacSi_Id + ","
                    + "@TKNo = " + _TKNo + ","
                    + "@TKCo = " + _TKCo + ","
                    + "@MaChungTuRef = " + _MaChungTuRef + ","
                    + "@LoaiChungTuRef = " + _LoaiChungTuRef + ","
                    + "@PhieuLinhCanTru_Id = " + _PhieuLinhCanTru_Id + ","
                    + "@KhoThucHien_Id = " + _KhoThucHien_Id + ","
                    + "@KhoDoiUng_Id = " + _KhoDoiUng_Id + ","
                    + "@BHYT = " + _BHYT + ","
                    + "@VienPhi = " + _VienPhi + ","
                    + "@MauSo = " + _MauSo + ","
                    + "@Huy = " + _Huy + ","
                    + "@Idx = " + _ChungTu_Id
;
                con.Open();
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
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'CBBDM_Duoc' "
                    ;
                con.Open();
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
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'CBBDonViTinh' "
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable CBBDonViTinh_ID(string _IDx)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'CBBDonViTinh_ID' ,"
                     + "@Idx = " + _IDx
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable selectQuocGia_Duoc_Id(string _IDx)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'selectQuocGia_Duoc_Id' ,"
                     + "@Idx = " + _IDx
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable UpdateQuocGia_Duoc_Id(string _IDx, string _Text)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'UpdateQuocGia_Duoc_Id' ,"
                     + "@Text = " + _Text + ","
                     + "@Idx = " + _IDx
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable InsertChungTuChiTiet(
              string _ChungTu_Id
            , string _Duoc_Id
            , string _SoLoNhap_Id
            , string _SoKiemSoat
            , string _SoVisa
            , string _DonViTinh_Id
            , string _SoLuongYeuCau
            , string _SoLuongThucTe
            , string _SoLuongDaXuat
            , string _TienTe_Id
            , string _TyGia
            , string _DonGiaMua
            , string _DonGiaBan
            , string _DonGiaVon
            , string _DonGiaThanhToan
            , string _SoQuyen
            , string _SoHoaDonVAT
            , string _TyLeVAT
            , string _GiaTriVAT
            , string _MienPhi
            , string _LyDoMienPhi_Id
            , string _SoChungTuKeToan
            , string _SoChungTuTienMat
            , string _TrangThai
            , string _DaPhatSinhPhieuXuat
            , string _DaPhatSinhPhieuHoanTra
            , string _KhuyenMai
            , string _DonDatHang_Id
            , string _GhiChuChiTiet
            , string _NgayTao
            , string _NguoiTao_Id
            , string _NgayCapNhat
            , string _NguoiCapNhat_Id
            , string _NguonHang_Id
            , string _DonGiaVonVAT
            , string _ThanhTienMua
            , string _ThanhTienVon
            , string _IsTachLo
            , string _DonViTinhBanDau_Id
            , string _SoLuongBanDau
            , string _Huy
            , string _DuocTonKhoYeuCau_Id
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'InsertChungTuChiTiet', "
                    + "@ChungTu_Id = " + _ChungTu_Id + ","
                    + "@Duoc_Id = " + _Duoc_Id + ","
                    + "@SoLoNhap_Id = " + _SoLoNhap_Id + ","
                    + "@SoKiemSoat = " + _SoKiemSoat + ","
                    + "@SoVisa = " + _SoVisa + ","
                    + "@DonViTinh_Id = " + _DonViTinh_Id + ","
                    + "@SoLuongYeuCau = " + _SoLuongYeuCau + ","
                    + "@SoLuongThucTe = " + _SoLuongThucTe + ","
                    + "@SoLuongDaXuat = " + _SoLuongDaXuat + ","
                    + "@TienTe_Id = " + _TienTe_Id + ","
                    + "@TyGia = " + _TyGia + ","
                    + "@DonGiaMua = " + _DonGiaMua + ","
                    + "@DonGiaBan = " + _DonGiaBan + ","
                    + "@DonGiaVon = " + _DonGiaVon + ","
                    + "@DonGiaThanhToan = " + _DonGiaThanhToan + ","
                    + "@SoQuyen = " + _SoQuyen + ","
                    + "@SoHoaDonVAT = " + _SoHoaDonVAT + ","
                    + "@TyLeVAT = " + _TyLeVAT + ","
                    + "@GiaTriVAT = " + _GiaTriVAT + ","
                    + "@MienPhi = " + _MienPhi + ","
                    + "@LyDoMienPhi_Id = " + _LyDoMienPhi_Id + ","
                    + "@SoChungTuKeToan = " + _SoChungTuKeToan + ","
                    + "@SoChungTuTienMat = " + _SoChungTuTienMat + ","
                    + "@TrangThai = " + _TrangThai + ","
                    + "@DaPhatSinhPhieuXuat = " + _DaPhatSinhPhieuXuat + ","
                    + "@DaPhatSinhPhieuHoanTra = " + _DaPhatSinhPhieuHoanTra + ","
                    + "@KhuyenMai = " + _KhuyenMai + ","
                    + "@DonDatHang_Id = " + _DonDatHang_Id + ","
                    + "@GhiChuChiTiet = " + _GhiChuChiTiet + ","
                    + "@NgayTao = " + _NgayTao + ","
                    + "@NguoiTao_Id = " + _NguoiTao_Id + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ","
                    + "@NguoiCapNhat_Id = " + _NguoiCapNhat_Id + ","
                    + "@NguonHang_Id = " + _NguonHang_Id + ","
                    + "@DonGiaVonVAT = " + _DonGiaVonVAT + ","
                    + "@ThanhTienMua = " + _ThanhTienMua + ","
                    + "@ThanhTienVon = " + _ThanhTienVon + ","
                    + "@IsTachLo = " + _IsTachLo + ","
                    + "@DonViTinhBanDau_Id = " + _DonViTinhBanDau_Id + ","
                    + "@SoLuongBanDau = " + _SoLuongBanDau + ","
                    + "@Huy = " + _Huy + ","
                    + "@DuocTonKhoYeuCau_Id = " + _DuocTonKhoYeuCau_Id
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable UpdateChungTuChiTiet(
              string _ChungTu_Id
            , string _Duoc_Id
            , string _SoLoNhap_Id
            , string _SoKiemSoat
            , string _SoVisa
            , string _DonViTinh_Id
            , string _SoLuongYeuCau
            , string _SoLuongThucTe
            , string _SoLuongDaXuat
            , string _TienTe_Id
            , string _TyGia
            , string _DonGiaMua
            , string _DonGiaBan
            , string _DonGiaVon
            , string _DonGiaThanhToan
            , string _SoQuyen
            , string _SoHoaDonVAT
            , string _TyLeVAT
            , string _GiaTriVAT
            , string _MienPhi
            , string _LyDoMienPhi_Id
            , string _SoChungTuKeToan
            , string _SoChungTuTienMat
            , string _TrangThai
            , string _DaPhatSinhPhieuXuat
            , string _DaPhatSinhPhieuHoanTra
            , string _KhuyenMai
            , string _DonDatHang_Id
            , string _GhiChuChiTiet
            , string _NgayTao
            , string _NguoiTao_Id
            , string _NgayCapNhat
            , string _NguoiCapNhat_Id
            , string _NguonHang_Id
            , string _DonGiaVonVAT
            , string _ThanhTienMua
            , string _ThanhTienVon
            , string _IsTachLo
            , string _DonViTinhBanDau_Id
            , string _SoLuongBanDau
            , string _Huy
            , string _ChungTuChiTiet_Id
            , string _DuocTonKhoYeuCau_Id
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'UpdateChungTuChiTiet', "
                    + "@ChungTu_Id = " + _ChungTu_Id + ","
                    + "@Duoc_Id = " + _Duoc_Id + ","
                    + "@SoLoNhap_Id = " + _SoLoNhap_Id + ","
                    + "@SoKiemSoat = " + _SoKiemSoat + ","
                    + "@SoVisa = " + _SoVisa + ","
                    + "@DonViTinh_Id = " + _DonViTinh_Id + ","
                    + "@SoLuongYeuCau = " + _SoLuongYeuCau + ","
                    + "@SoLuongThucTe = " + _SoLuongThucTe + ","
                    + "@SoLuongDaXuat = " + _SoLuongDaXuat + ","
                    + "@TienTe_Id = " + _TienTe_Id + ","
                    + "@TyGia = " + _TyGia + ","
                    + "@DonGiaMua = " + _DonGiaMua + ","
                    + "@DonGiaBan = " + _DonGiaBan + ","
                    + "@DonGiaVon = " + _DonGiaVon + ","
                    + "@DonGiaThanhToan = " + _DonGiaThanhToan + ","
                    + "@SoQuyen = " + _SoQuyen + ","
                    + "@SoHoaDonVAT = " + _SoHoaDonVAT + ","
                    + "@TyLeVAT = " + _TyLeVAT + ","
                    + "@GiaTriVAT = " + _GiaTriVAT + ","
                    + "@MienPhi = " + _MienPhi + ","
                    + "@LyDoMienPhi_Id = " + _LyDoMienPhi_Id + ","
                    + "@SoChungTuKeToan = " + _SoChungTuKeToan + ","
                    + "@SoChungTuTienMat = " + _SoChungTuTienMat + ","
                    + "@TrangThai = " + _TrangThai + ","
                    + "@DaPhatSinhPhieuXuat = " + _DaPhatSinhPhieuXuat + ","
                    + "@DaPhatSinhPhieuHoanTra = " + _DaPhatSinhPhieuHoanTra + ","
                    + "@KhuyenMai = " + _KhuyenMai + ","
                    + "@DonDatHang_Id = " + _DonDatHang_Id + ","
                    + "@GhiChuChiTiet = " + _GhiChuChiTiet + ","
                    + "@NgayTao = " + _NgayTao + ","
                    + "@NguoiTao_Id = " + _NguoiTao_Id + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ","
                    + "@NguoiCapNhat_Id = " + _NguoiCapNhat_Id + ","
                    + "@NguonHang_Id = " + _NguonHang_Id + ","
                    + "@DonGiaVonVAT = " + _DonGiaVonVAT + ","
                    + "@ThanhTienMua = " + _ThanhTienMua + ","
                    + "@ThanhTienVon = " + _ThanhTienVon + ","
                    + "@IsTachLo = " + _IsTachLo + ","
                    + "@DonViTinhBanDau_Id = " + _DonViTinhBanDau_Id + ","
                    + "@SoLuongBanDau = " + _SoLuongBanDau + ","
                    + "@Huy = " + _Huy + ","
                    + "@Idx = " + _ChungTuChiTiet_Id + ","
                    + "@DuocTonKhoYeuCau_Id = " + _DuocTonKhoYeuCau_Id
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable UpdateChungTuChiTietThem(
              string _ChungTu_Id
            , string _ChungTuChiTiet_Id
            , string _NguonHang_Id
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'UpdateChungTuChiTietThem' ,"
                    + "@ChungTu_Id = " + _ChungTu_Id + ","
                    + "@Idx = " + _ChungTuChiTiet_Id + ","
                    + "@NguonHang_Id = " + _NguonHang_Id
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable DeleteChungTu(
              string _Idx
            , string _NguoiCapNhat_Id
            , string _NgayCapNhat
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'DeleteChungTu' ,"
                    + "@NguoiCapNhat_Id = " + _NguoiCapNhat_Id + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ","
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
        public static DataTable DeleteChungTuChiTiet(
              string _Idx
            , string _NguoiCapNhat_Id
            , string _NgayCapNhat
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'DeleteChungTuChiTiet' ,"
                    + "@NguoiCapNhat_Id = " + _NguoiCapNhat_Id + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ","
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
        public static DataTable HoanTat_Action_ChungTu_PhienDangNhap(
              string _PhienDangNhap_Id
            , string _MaMucDichChungTu
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'HoanTat_Action_ChungTu_PhienDangNhap' ,"
                    + "@PhienDangNhap_Id = " + _PhienDangNhap_Id + ", "
                    + "@MaMucDichChungTu = " + _MaMucDichChungTu
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable SelectAction_ChungTu(
              string _PhienDangNhap_Id
            , string _MaMucDichChungTu
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'SelectAction_ChungTu' ,"
                    + "@PhienDangNhap_Id = " + _PhienDangNhap_Id + ", "
                    + "@MaMucDichChungTu = " + _MaMucDichChungTu
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable InsertAction_ChungTu_PhienDangNhap(
              string _PhienDangNhap_Id
            , string _MaMucDichChungTu
            , string _ChungTu_Id
            , string _ChungTuChiTiet_Id
            , string _Duoc_Id
            , string _SoLoNhap_Id
            , string _SoKiemSoat
            , string _DonViTinh_Id
            , string _SoLuongYeuCau
            , string _SoLuongThucTe
            , string _SoLuongDaXuat
            , string _DonGiaMua
            , string _DonGiaBan
            , string _DonGiaVon
            , string _DonGiaThanhToan
            , string _TyLeVAT
            , string _GiaTriVAT
            , string _MienPhi
            , string _DaPhatSinhPhieuHoanTra
            , string _DaPhatSinhPhieuXuat
            , string _KhuyenMai
            , string _DonGiaVonVAT
            , string _ThanhTienMua
            , string _ThanhTienVon
            , string _SoLuongBanDau
            , string _HanSuDung
            , string _ThaoTac
            , string _TrangThai
            , string _DuocTonKho_Id
            , string _NguonDuoc_Id
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'InsertAction_ChungTu_PhienDangNhap' ,"
                    + "@PhienDangNhap_Id = " + _PhienDangNhap_Id + ","
                    + "@MaMucDichChungTu = " + _MaMucDichChungTu + ","
                    + "@ChungTu_Id = " + _ChungTu_Id + ","
                    + "@ChungTuChiTiet_Id = " + _ChungTuChiTiet_Id + ","
                    + "@Duoc_Id = " + _Duoc_Id + ","
                    + "@SoLoNhap_Id = " + _SoLoNhap_Id + ","
                    + "@SoKiemSoat = " + _SoKiemSoat + ","
                    + "@DonViTinh_Id = " + _DonViTinh_Id + ","
                    + "@SoLuongYeuCau = " + _SoLuongYeuCau + ","
                    + "@SoLuongThucTe = " + _SoLuongThucTe + ","
                    + "@SoLuongDaXuat = " + _SoLuongDaXuat + ","
                    + "@DonGiaMua = " + _DonGiaMua + ","
                    + "@DonGiaBan = " + _DonGiaBan + ","
                    + "@DonGiaVon = " + _DonGiaVon + ","
                    + "@DonGiaThanhToan = " + _DonGiaThanhToan + ","
                    + "@TyLeVAT = " + _TyLeVAT + ","
                    + "@GiaTriVAT = " + _GiaTriVAT + ","
                    + "@MienPhi = " + _MienPhi + ","
                    + "@DaPhatSinhPhieuHoanTra = " + _DaPhatSinhPhieuHoanTra + ","
                    + "@DaPhatSinhPhieuXuat = " + _DaPhatSinhPhieuXuat + ","
                    + "@KhuyenMai = " + _KhuyenMai + ","
                    + "@DonGiaVonVAT = " + _DonGiaVonVAT + ","
                    + "@ThanhTienMua = " + _ThanhTienMua + ","
                    + "@ThanhTienVon = " + _ThanhTienVon + ","
                    + "@SoLuongBanDau = " + _SoLuongBanDau + ","
                    + "@HanSuDung = " + _HanSuDung + ","
                    + "@ThaoTac = " + _ThaoTac + ","
                    + "@TrangThai = " + _TrangThai + ","
                    + "@DuocTonKho_Id = " + _DuocTonKho_Id + ","
                    + "@NguonDuoc_Id = " + _NguonDuoc_Id
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable UpdateAction_ChungTu_PhienDangNhap(
              string _PhienDangNhap_Id
            , string _MaMucDichChungTu
            , string _ChungTu_Id
            , string _ChungTuChiTiet_Id
            , string _Duoc_Id
            , string _SoLoNhap_Id
            , string _SoKiemSoat
            , string _DonViTinh_Id
            , string _SoLuongYeuCau
            , string _SoLuongThucTe
            , string _SoLuongDaXuat
            , string _DonGiaMua
            , string _DonGiaBan
            , string _DonGiaVon
            , string _DonGiaThanhToan
            , string _TyLeVAT
            , string _GiaTriVAT
            , string _MienPhi
            , string _DaPhatSinhPhieuHoanTra
            , string _DaPhatSinhPhieuXuat
            , string _KhuyenMai
            , string _DonGiaVonVAT
            , string _ThanhTienMua
            , string _ThanhTienVon
            , string _SoLuongBanDau
            , string _HanSuDung
            , string _ThaoTac
            , string _TrangThai
            , string _Idx
            , string _DuocTonKho_Id
            , string _NguonDuoc_Id
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'UpdateAction_ChungTu_PhienDangNhap' ,"
                    + "@PhienDangNhap_Id = " + _PhienDangNhap_Id + ","
                    + "@MaMucDichChungTu = " + _MaMucDichChungTu + ","
                    + "@ChungTu_Id = " + _ChungTu_Id + ","
                    + "@ChungTuChiTiet_Id = " + _ChungTuChiTiet_Id + ","
                    + "@Duoc_Id = " + _Duoc_Id + ","
                    + "@SoLoNhap_Id = " + _SoLoNhap_Id + ","
                    + "@SoKiemSoat = " + _SoKiemSoat + ","
                    + "@DonViTinh_Id = " + _DonViTinh_Id + ","
                    + "@SoLuongYeuCau = " + _SoLuongYeuCau + ","
                    + "@SoLuongThucTe = " + _SoLuongThucTe + ","
                    + "@SoLuongDaXuat = " + _SoLuongDaXuat + ","
                    + "@DonGiaMua = " + _DonGiaMua + ","
                    + "@DonGiaBan = " + _DonGiaBan + ","
                    + "@DonGiaVon = " + _DonGiaVon + ","
                    + "@DonGiaThanhToan = " + _DonGiaThanhToan + ","
                    + "@TyLeVAT = " + _TyLeVAT + ","
                    + "@GiaTriVAT = " + _GiaTriVAT + ","
                    + "@MienPhi = " + _MienPhi + ","
                    + "@DaPhatSinhPhieuHoanTra = " + _DaPhatSinhPhieuHoanTra + ","
                    + "@DaPhatSinhPhieuXuat = " + _DaPhatSinhPhieuXuat + ","
                    + "@KhuyenMai = " + _KhuyenMai + ","
                    + "@DonGiaVonVAT = " + _DonGiaVonVAT + ","
                    + "@ThanhTienMua = " + _ThanhTienMua + ","
                    + "@ThanhTienVon = " + _ThanhTienVon + ","
                    + "@SoLuongBanDau = " + _SoLuongBanDau + ","
                    + "@HanSuDung = " + _HanSuDung + ","
                    + "@ThaoTac = " + _ThaoTac + ","
                    + "@TrangThai = " + _TrangThai + ","
                    + "@Idx = " + _Idx + ","
                    + "@DuocTonKho_Id = " + _DuocTonKho_Id + ","
                    + "@NguonDuoc_Id = " + _NguonDuoc_Id

                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable Delete_Action_ChungTu_PhienDangNhap(
              string _Idx
            , string _PhienDangNhap_Id
            , string _MaMucDichChungTu
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'Delete_Action_ChungTu_PhienDangNhap' ,"
                    + "@IDx = " + _Idx + ","
                    + "@PhienDangNhap_Id = " + _PhienDangNhap_Id + ","
                    + "@MaMucDichChungTu = " + _MaMucDichChungTu
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable SelectAction_ChungTuTheoID(
            string _PhienDangNhap_Id
            , string _Idx
            , string _MaMucDichChungTu
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'SelectAction_ChungTuTheoID' ,"
                    + "@PhienDangNhap_Id = " + _PhienDangNhap_Id + ","
                    + "@IDx = " + _Idx + ","
                    + "@MaMucDichChungTu = " + _MaMucDichChungTu
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable CheckAction_ChungTu_PhienDangNhap(
            string _PhienDangNhap_Id
            , string _MaMucDichChungTu
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'CheckAction_ChungTu_PhienDangNhap' ,"
                    + "@PhienDangNhap_Id = " + _PhienDangNhap_Id + ","
                    + "@MaMucDichChungTu = " + _MaMucDichChungTu
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable ThemActionVaoPhieuDangNhap(
            string _PhienDangNhap_Id
            , string _MaMucDichChungTu
            , string _IDx
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'ThemActionVaoPhieuDangNhap' ,"
                    + "@PhienDangNhap_Id = " + _PhienDangNhap_Id + ","
                    + "@MaMucDichChungTu = " + _MaMucDichChungTu + ","
                    + "@Idx = " + _IDx
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable InsertChungTuSoLoNhap(
              string _SoLoNhap
            , string _Duoc_Id
            , string _NgayNhap
            , string _HanSuDung
            , string _NguonDuoc_Id
            , string _DonGiaMua
            , string _DonGiaVon
            , string _TienTe_Id
            , string _TyGia
            , string _Thang
            , string _Nam
            , string _NgayTao
            , string _NguoiTao_Id
            , string _NgayCapNhat
            , string _NguoiCapNhat_Id
            , string _SoKiemSoat
            , string _SoVisa
            , string _NguonHang_Id
            , string _Huy
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'InsertChungTuSoLoNhap' ,"
                    + "@SoLoNhap = " + _SoLoNhap + ","
                    + "@Duoc_Id = " + _Duoc_Id + ","
                    + "@NgayNhap = " + _NgayNhap + ","
                    + "@HanSuDung = " + _HanSuDung + ","
                    + "@NguonDuoc_Id = " + _NguonDuoc_Id + ","
                    + "@DonGiaMua = " + _DonGiaMua + ","
                    + "@DonGiaVon = " + _DonGiaVon + ","
                    + "@TienTe_Id = " + _TienTe_Id + ","
                    + "@TyGia = " + _TyGia + ","
                    + "@Thang = " + _Thang + ","
                    + "@Nam = " + _Nam + ","
                    + "@NgayTao = " + _NgayTao + ","
                    + "@NguoiTao_Id = " + _NguoiTao_Id + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ","
                    + "@NguoiCapNhat_Id = " + _NguoiCapNhat_Id + ","
                    + "@SoKiemSoat = " + _SoKiemSoat + ","
                    + "@SoVisa = " + _SoVisa + ","
                    + "@NguonHang_Id = " + _NguonHang_Id + ","
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
        public static DataTable UpdateChungTuSoLoNhap(
              string _SoLoNhap
            , string _Duoc_Id
            , string _NgayNhap
            , string _HanSuDung
            , string _NguonDuoc_Id
            , string _DonGiaMua
            , string _DonGiaVon
            , string _TienTe_Id
            , string _TyGia
            , string _Thang
            , string _Nam
            , string _NgayTao
            , string _NguoiTao_Id
            , string _NgayCapNhat
            , string _NguoiCapNhat_Id
            , string _SoKiemSoat
            , string _SoVisa
            , string _NguonHang_Id
            , string _Huy
            , string _IDx
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'UpdateChungTuSoLoNhap' ,"
                    + "@SoLoNhap = " + _SoLoNhap + ","
                    + "@Duoc_Id = " + _Duoc_Id + ","
                    + "@NgayNhap = " + _NgayNhap + ","
                    + "@HanSuDung = " + _HanSuDung + ","
                    + "@NguonDuoc_Id = " + _NguonDuoc_Id + ","
                    + "@DonGiaMua = " + _DonGiaMua + ","
                    + "@DonGiaVon = " + _DonGiaVon + ","
                    + "@TienTe_Id = " + _TienTe_Id + ","
                    + "@TyGia = " + _TyGia + ","
                    + "@Thang = " + _Thang + ","
                    + "@Nam = " + _Nam + ","
                    + "@NgayTao = " + _NgayTao + ","
                    + "@NguoiTao_Id = " + _NguoiTao_Id + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ","
                    + "@NguoiCapNhat_Id = " + _NguoiCapNhat_Id + ","
                    + "@SoKiemSoat = " + _SoKiemSoat + ","
                    + "@SoVisa = " + _SoVisa + ","
                    + "@NguonHang_Id = " + _NguonHang_Id + ","
                    + "@Huy = " + _Huy + ","
                    + "@Idx = " + _IDx
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable DeleteChungTuSoLoNhap(
              string _Idx
            , string _NguoiCapNhat_Id
            , string _NgayCapNhat
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'DeleteChungTuSoLoNhap' ,"
                    + "@NguoiCapNhat_Id = " + _NguoiCapNhat_Id + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ","
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
        public static DataTable CheckChungTuDaXuat(
              string _Idx
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'CheckChungTuDaXuat' ,"
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
        public static DataTable CheckChungTuTruocXoa(
              string _Idx
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'CheckChungTuTruocXoa' ,"
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
        public static DataTable UpdateChungTuChiTietThemSoLoNhap(
              string _Idx
            , string _SoloNhap_Id
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'UpdateChungTuChiTietThemSoLoNhap' ,"
                    + "@SoLoNhap_Id = " + _SoloNhap_Id + ", "
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
        public static DataTable SP_BaoCao_020_BienBanKiemNhap(
              string _Idx
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_BaoCao_020_BienBanKiemNhap @ChungTu_Id = " + _Idx
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable sp_BaoCao_041_PhieuNhapKhoNCC(
              string _Idx
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec sp_BaoCao_041_PhieuNhapKhoNCC @ChungTu_Id = " + _Idx
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable CBBLoaiPhieu(
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'CBBLoaiPhieu' "
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable CBBDM_PhieuXuatDuoc(
            string _KhoSuDung_Id
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'CBBDM_PhieuXuatDuoc' ,"
                    + "@KhoSuDung_Id = " + _KhoSuDung_Id
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable CBBDM_PhieuCanHoanTra(
            string _KhoSuDung_Id
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'CBBDM_PhieuCanHoanTra' ,"
                    + "@KhoSuDung_Id = " + _KhoSuDung_Id
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable CBBXuatNoiBo(
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'CBBXuatNoiBo' "
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable CBBXuatSuDung(
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'CBBXuatSuDung' "
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable CBBNhapNoiBo(
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'CBBNhapNoiBo' "
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable CBBHoanTraNoiBo(
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'CBBHoanTraNoiBo' "
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable CBBSoLoNhap(
              string _Idx
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'CBBSoLoNhap' ,"
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
        public static DataTable CBBSoLoNhapTheoID(
              string _Idx
            , string _Duoc_Id
            , string _NguonDuoc_Id
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'CBBSoLoNhapTheoID' ,"
                    + "@Idx = " + _Idx + ", "
                    + "@Duoc_Id = " + _Duoc_Id + ", "
                    + "@NguonHang_Id = " + _NguonDuoc_Id
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable CBBSoLoNhapTheoIDTheoNhapTruocXuatTruoc(
              string _Idx
            , string _Duoc_Id
            , string _NguonDuoc_Id
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'CBBSoLoNhapTheoIDTheoNhapTruocXuatTruoc' ,"
                    + "@Idx = " + _Idx + ", "
                    + "@Duoc_Id = " + _Duoc_Id + ", "
                    + "@NguonHang_Id = " + _NguonDuoc_Id
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable CBBSoLoNhapTheoIDTheoHanDung(
              string _Idx
            , string _Duoc_Id
            , string _NguonDuoc_Id
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'CBBSoLoNhapTheoIDTheoHanDung' ,"
                    + "@Idx = " + _Idx + ", "
                    + "@Duoc_Id = " + _Duoc_Id + ", "
                    + "@NguonHang_Id = " + _NguonDuoc_Id
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable SelectSoLoNhapTheoID(
              string _Idx
            , string _Duoc_Id
            , string _KhoDuoc_Id
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'SelectSoLoNhapTheoID' ,"
                    + "@Idx = " + _Idx + ","
                    + "@Duoc_Id = " + _Duoc_Id + ","
                    + "@KhoDuoc_Id = " + _KhoDuoc_Id
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable InsertDuocTonKho(
              string _KhoDuoc_Id
            , string _Duoc_Id
            , string _NguonNhapHang_Id
            , string _SoLoNhap_Id
            , string _DonGiaMua
            , string _SoLuong
            , string _SoLuongGoc
            , string _NgayTao
            , string _NguoiTao_Id
            , string _NgayCapNhat
            , string _NguoiCapNhat_Id
            , string _Huy
            , string _SuDung
            , string _DuocTonKhoYeuCau_Id
            , string _ChungTuChiTiet_Id
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'InsertDuocTonKho' ,"
                    + "@KhoDuoc_Id = " + _KhoDuoc_Id + ","
                    + "@Duoc_Id = " + _Duoc_Id + ","
                    + "@NguonNhapHang_Id = " + _NguonNhapHang_Id + ","
                    + "@SoLoNhap_Id = " + _SoLoNhap_Id + ","
                    + "@DonGiaMua = " + _DonGiaMua + ","
                    + "@SoLuong = " + _SoLuong + ","
                    + "@SoLuongGoc = " + _SoLuongGoc + ","
                    + "@NgayTao = " + _NgayTao + ","
                    + "@NguoiTao_Id = " + _NguoiTao_Id + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ","
                    + "@NguoiCapNhat_Id = " + _NguoiCapNhat_Id + ","
                    + "@Huy = " + _Huy + ","
                    + "@SuDung = " + _SuDung + ","
                    + "@DuocTonKhoYeuCau_Id = " + _DuocTonKhoYeuCau_Id + ","
                    + "@ChungTuChiTiet_Id = " + _ChungTuChiTiet_Id
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable UpdateDuocTonKho(
              string _KhoDuoc_Id
            , string _Duoc_Id
            , string _NguonNhapHang_Id
            , string _SoLoNhap_Id
            , string _DonGiaMua
            , string _SoLuong
            , string _SoLuongGoc
            , string _NgayTao
            , string _NguoiTao_Id
            , string _NgayCapNhat
            , string _NguoiCapNhat_Id
            , string _Huy
            , string _SuDung
            , string _Idx
            , string _DuocTonKhoYeuCau_Id
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'UpdateDuocTonKho' ,"
                    + "@KhoDuoc_Id = " + _KhoDuoc_Id + ","
                    + "@Duoc_Id = " + _Duoc_Id + ","
                    + "@NguonNhapHang_Id = " + _NguonNhapHang_Id + ","
                    + "@SoLoNhap_Id = " + _SoLoNhap_Id + ","
                    + "@DonGiaMua = " + _DonGiaMua + ","
                    + "@SoLuong = " + _SoLuong + ","
                    + "@SoLuongGoc = " + _SoLuongGoc + ","
                    + "@NgayTao = " + _NgayTao + ","
                    + "@NguoiTao_Id = " + _NguoiTao_Id + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ","
                    + "@NguoiCapNhat_Id = " + _NguoiCapNhat_Id + ","
                    + "@Huy = " + _Huy + ","
                    + "@SuDung = " + _SuDung + ","
                    + "@Idx = " + _Idx + ","
                    + "@DuocTonKhoYeuCau_Id = " + _DuocTonKhoYeuCau_Id
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable UpdateDuocTonKhoThemSoLuong(
              string _KhoDuoc_Id
            , string _Duoc_Id
            , string _NguonNhapHang_Id
            , string _SoLoNhap_Id
            , string _DonGiaMua
            , string _SoLuong
            , string _NgayTao
            , string _NguoiTao_Id
            , string _NgayCapNhat
            , string _NguoiCapNhat_Id
            , string _Huy
            , string _SuDung
            , string _Idx
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'UpdateDuocTonKhoThemSoLuong' ,"
                    + "@KhoDuoc_Id = " + _KhoDuoc_Id + ","
                    + "@Duoc_Id = " + _Duoc_Id + ","
                    + "@NguonNhapHang_Id = " + _NguonNhapHang_Id + ","
                    + "@SoLoNhap_Id = " + _SoLoNhap_Id + ","
                    + "@DonGiaMua = " + _DonGiaMua + ","
                    + "@SoLuong = " + _SoLuong + ","
                    + "@NgayTao = " + _NgayTao + ","
                    + "@NguoiTao_Id = " + _NguoiTao_Id + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ","
                    + "@NguoiCapNhat_Id = " + _NguoiCapNhat_Id + ","
                    + "@Huy = " + _Huy + ","
                    + "@SuDung = " + _SuDung + ","
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
        public static DataTable DeleteDuocTonKho(
              string _Idx
            , string _NguoiCapNhat_Id
            , string _NgayCapNhat
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'DeleteDuocTonKho' ,"
                    + "@NguoiCapNhat_Id = " + _NguoiCapNhat_Id + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ","
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
        public static DataTable DeleteDuocTonKhoTheoChungTuChiTiet_Id(
              string _Idx
            , string _NguoiCapNhat_Id
            , string _NgayCapNhat
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'DeleteDuocTonKhoTheoChungTuChiTiet_Id' ,"
                    + "@NguoiCapNhat_Id = " + _NguoiCapNhat_Id + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ","
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
        public static DataTable setSoLuongDuocTonKho(
              string _Idx
            , string _NguoiCapNhat_Id
            , string _NgayCapNhat
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'setSoLuongDuocTonKho' ,"
                    + "@NguoiCapNhat_Id = " + _NguoiCapNhat_Id + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ","
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
        public static DataTable InsertDuocTonKhoBooking(
              string _PhienDangNhap_Id
            , string _ChungTuChiTiet_Id
            , string _DuocTonKho_Id
            , string _DuocTonKhoYeuCau_Id
            , string _SoLuong
            , string _SoLuongYeuCau
            , string _NgayTao
            , string _ThaoTac
            , string _TrangThai
            , string _NgayHieuLuc
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'InsertDuocTonKhoBooking' ,"
                    + "@PhienDangNhap_Id = " + _PhienDangNhap_Id + ","
                    + "@ChungTuChiTiet_Id = " + _ChungTuChiTiet_Id + ","
                    + "@DuocTonKho_Id = " + _DuocTonKho_Id + ","
                    + "@DuocTonKhoYeuCau_Id = " + _DuocTonKhoYeuCau_Id + ","
                    + "@SoLuong = " + _SoLuong + ","
                    + "@SoLuongYeuCau = " + _SoLuongYeuCau + ","
                    + "@NgayTao = " + _NgayTao + ","
                    + "@ThaoTac = " + _ThaoTac + ","
                    + "@TrangThai = " + _TrangThai + ","
                    + "@NgayHieuLuc = " + _NgayHieuLuc
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable UpdateDuocTonKhoBooking(
              string _PhienDangNhap_Id
            , string _ChungTuChiTiet_Id
            , string _DuocTonKho_Id
            , string _DuocTonKhoYeuCau_Id
            , string _SoLuong
            , string _SoLuongYeuCau
            , string _NgayTao
            , string _ThaoTac
            , string _TrangThai
            , string _NgayHieuLuc
            , string _Idx
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'UpdateDuocTonKhoBooking' ,"
                    + "@PhienDangNhap_Id = " + _PhienDangNhap_Id + ","
                    + "@ChungTuChiTiet_Id = " + _ChungTuChiTiet_Id + ","
                    + "@DuocTonKho_Id = " + _DuocTonKho_Id + ","
                    + "@DuocTonKhoYeuCau_Id = " + _DuocTonKhoYeuCau_Id + ","
                    + "@SoLuong = " + _SoLuong + ","
                    + "@SoLuongYeuCau = " + _SoLuongYeuCau + ","
                    + "@NgayTao = " + _NgayTao + ","
                    + "@ThaoTac = " + _ThaoTac + ","
                    + "@TrangThai = " + _TrangThai + ","
                    + "@NgayHieuLuc = " + _NgayHieuLuc + ","
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
        public static DataTable CheckDuocTonKhoSuDung(
             string _Idx
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'CheckDuocTonKhoSuDung' ,"
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
        public static DataTable DeleteDuocTonKhoBooking(
             string _Idx
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'DeleteDuocTonKhoBooking' ,"
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
        public static DataTable UpdateSuDungDuocTonKho(
             string _Idx
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'UpdateSuDungDuocTonKho' ,"
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
        public static DataTable SP_BaoCao_021_PhieuXuatKho(
              string _Idx
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_BaoCao_021_PhieuXuatKho @ChungTu_Id = " + _Idx
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable XacNhanNhapKho(
              string _Idx
            , string _NguoiCapNhat_Id
            , string _NgayCapNhat
            , string _TrangThai_Id
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'XacNhanNhapKho' ,"
                    + "@TrangThai = " + _TrangThai_Id + ","
                    + "@NguoiCapNhat_Id = " + _NguoiCapNhat_Id + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ","
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
        public static DataTable SelectChungTuChiTietTuChungTu_Id(
              string _Idx
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'SelectChungTuChiTietTuChungTu_Id' ,"
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
        public static DataTable CheckSoLuongTonSauBooking(
              string _Idx
            , string _Duoc_Id
            , string _NguonDuoc_Id
            , string _KhoDuoc_Id
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'CheckSoLuongTonSauBooking' ,"
                    + "@Idx = " + _Idx + ", "
                    + "@Duoc_Id = " + _Duoc_Id + ", "
                    + "@KhoDuoc_Id = " + _KhoDuoc_Id + ", "
                    + "@NguonHang_Id = " + _NguonDuoc_Id
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable CheckTonTaiDuocTonKhoTheoSoLo(
             string _Idx
           , string _Duoc_Id
           , string _NguonDuoc_Id
           , string _KhoDuoc_Id
           )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'CheckTonTaiDuocTonKhoTheoSoLo' ,"
                    + "@Idx = " + _Idx + ", "
                    + "@Duoc_Id = " + _Duoc_Id + ", "
                    + "@KhoDuoc_Id = " + _KhoDuoc_Id + ", "
                    + "@NguonHang_Id = " + _NguonDuoc_Id
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable setDuocTonKhoYeuCauGiam(
              string _DuocTonKho_Id
            , string _SoLuongDaXuat
            , string _NgayCapNhat
            , string _NguoiCapNhat_Id
           )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'setDuocTonKhoYeuCauGiam' ,"
                    + "@DuocTonKho_Id = " + _DuocTonKho_Id + ", "
                    + "@SoLuongDaXuat = " + _SoLuongDaXuat + ", "
                    + "@NgayCapNhat = " + _NgayCapNhat + ", "
                    + "@NguoiCapNhat_Id = " + _NguoiCapNhat_Id
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable setDuocTonKhoYeuCauTang(
              string _DuocTonKho_Id
            , string _SoLuong
            , string _NgayCapNhat
            , string _NguoiCapNhat_Id
           )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'setDuocTonKhoYeuCauTang' ,"
                    + "@DuocTonKho_Id = " + _DuocTonKho_Id + ", "
                    + "@SoLuong = " + _SoLuong + ", "
                    + "@NgayCapNhat = " + _NgayCapNhat + ", "
                    + "@NguoiCapNhat_Id = " + _NguoiCapNhat_Id
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable setDuocTonKhoYeuCauCapNhat(
              string _DuocTonKho_Id
            , string _SoLuong
            , string _SoLuongDaXuat
            , string _NgayCapNhat
            , string _NguoiCapNhat_Id
           )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'setDuocTonKhoYeuCauCapNhat' ,"
                    + "@DuocTonKho_Id = " + _DuocTonKho_Id + ", "
                    + "@SoLuong = " + _SoLuong + ", "
                    + "@SoLuongDaXuat = " + _SoLuongDaXuat + ", "
                    + "@NgayCapNhat = " + _NgayCapNhat + ", "
                    + "@NguoiCapNhat_Id = " + _NguoiCapNhat_Id
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable CheckDuocTonKhoBooking(
              string _PhienDangNhap_Id
            , string _ChungTuChiTiet_Id
           )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'CheckDuocTonKhoBooking' ,"
                    + "@PhienDangNhap_Id = " + _PhienDangNhap_Id + ", "
                    + "@ChungTuChiTiet_Id = " + _ChungTuChiTiet_Id
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable UpdateTrangThaiDuocTonKho(
              string _Idx
           )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'UpdateTrangThaiDuocTonKho' ,"
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

        public static DataTable selectChungTuChiTiet(
              string _Idx
           )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'selectChungTuChiTiet' ,"
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
        public static DataTable UpdateChungTuDaNhan(
              string _Idx
            , string _DaNhanThuoc
           )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'UpdateChungTuDaNhan' ,"
                    + "@Idx = " + _Idx + ", "
                    + "@DaNhanThuoc = " + _DaNhanThuoc
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable UpdateChungTuChiTietDaPhatSinh(
              string _Idx
            , string _DaPhatSinhPhieuXuat
           )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'UpdateChungTuChiTietDaPhatSinh' ,"
                    + "@Idx = " + _Idx + ", "
                    + "@DaPhatSinhPhieuXuat = " + _DaPhatSinhPhieuXuat
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable UpdateChungTuChiTietDaPhatSinhTheoChungTu_Id(
              string _Idx
            , string _DaPhatSinhPhieuXuat
           )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'UpdateChungTuChiTietDaPhatSinhTheoChungTu_Id' ,"
                    + "@Idx = " + _Idx + ", "
                    + "@DaPhatSinhPhieuXuat = " + _DaPhatSinhPhieuXuat
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }

        public static DataTable UpdateChungTuChiTietDaHoanTra(
              string _Idx
            , string _DaPhatSinhPhieuHoanTra
           )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'UpdateChungTuChiTietDaHoanTra' ,"
                    + "@Idx = " + _Idx + ", "
                    + "@DaPhatSinhPhieuHoanTra = " + _DaPhatSinhPhieuHoanTra
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable UpdateChungTuChiTietDaHoanTraTheoChungTu_Id(
              string _Idx
            , string _DaPhatSinhPhieuHoanTra
           )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'UpdateChungTuChiTietDaHoanTraTheoChungTu_Id' ,"
                    + "@Idx = " + _Idx + ", "
                    + "@DaPhatSinhPhieuHoanTra = " + _DaPhatSinhPhieuHoanTra
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }

        public static DataTable HuyChungTuChiTietCu(
              string _Idx
            , string _NguoiCapNhat_Id
            , string _NgayCapNhat
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'HuyChungTuChiTietCu' ,"
                    + "@NguoiCapNhat_Id = " + _NguoiCapNhat_Id + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ","
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
        public static DataTable SelectChungTuLienQuan(
              string _Idx
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'SelectChungTuLienQuan' ,"
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
        public static DataTable sp_BCDP_019_PhieuNhapKho_NhapNoiBo(
              string _Idx
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec sp_BCDP_019_PhieuNhapKho_NhapNoiBo @ChungTu_Id = " + _Idx
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable sp_BCDP_022_PhieuXuatKho_XuatSuDung(
              string _Idx
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec sp_BCDP_022_PhieuXuatKho_XuatSuDung @ChungTu_Id = " + _Idx
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable SelectBenhNhanCoToaThuoc(
              string _Text
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'SelectBenhNhanCoToaThuoc' ,"
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
        public static DataTable SelectToaThuocBenhNhanTop1(
              string _Idx
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'SelectToaThuocBenhNhanTop1' ,"
                    + "@BenhNhan_Id = " + _Idx
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }

        public static DataTable loadToaThuocBenhNhan(
              string _Idx
            , string _Text
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'loadToaThuocBenhNhan' ,"
                    + "@BenhNhan_Id = " + _Idx + ","
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
        public static DataTable loadToaThuocTheoKhamBenh(
              string _Idx
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'loadToaThuocTheoKhamBenh' ,"
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
        public static DataTable checkDuocConTonKho(
              string _Idx
            , string _KhoDuoc_Id
            , string _NguonNhapHang_Id
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'checkDuocConTonKho' ,"
                    + "@Idx = " + _Idx + ","
                    + "@KhoDuoc_Id = " + _KhoDuoc_Id + ","
                    + "@NguonNhapHang_Id = " + _NguonNhapHang_Id
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable CapNhat_DM_Duoc_DonGia(
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'CapNhat_DM_Duoc_DonGia'"
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable SelectDM_Duoc_DonGia(
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'SelectDM_Duoc_DonGia'"
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable UpdateDuoc_DonGia(
              string _Idx
            , string _NgayCapNhat
            , string _NguoiCapNhat_Id
            , string _DonGia
            , string _CongPhuThu
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'UpdateDuoc_DonGia' ,"
                    + "@Idx = " + _Idx + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ","
                    + "@NguoiCapNhat = " + _NguoiCapNhat_Id + ","
                    + "@DonGia = " + _DonGia + ","
                    + "@CongTiem = " + _CongPhuThu
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable PhatHanhGia(
              string _NgayCapNhat
            , string _NguoiCapNhat_Id
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'PhatHanhGia' ,"
                    + "@NgayCapNhat = " + _NgayCapNhat + ","
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
        public static DataTable sp_BCDP_022_PhieuXuatKhoTaiQuay(
              string _Idx
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec sp_BCDP_022_PhieuXuatKhoTaiQuay "
                    + "@ChungTu_Id = " + _Idx
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable SelectKhoDuoc()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'SelectKhoDuoc' "
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable SelectKhoDuocTheoID(string _Idx)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'SelectKhoDuocTheoID', "
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
        public static DataTable InsertKhoDuoc(
                 string _MaKho
               , string _TenKho
               , string _TenKhongDau
               , string _CapTren_Id
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
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'InsertKhoDuoc', "
                    + "@MaKho = " + _MaKho + ","
                    + "@TenKho = " + _TenKho + ","
                    + "@TenKhongDau = " + _TenKhongDau + ","
                    + "@CapTren_Id = " + _CapTren_Id + ","
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
        public static DataTable UpdateKhoDuoc(
                 string _MaKho
               , string _TenKho
               , string _TenKhongDau
               , string _CapTren_Id
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
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'UpdateKhoDuoc', "
                    + "@MaKho = " + _MaKho + ","
                    + "@TenKho = " + _TenKho + ","
                    + "@TenKhongDau = " + _TenKhongDau + ","
                    + "@CapTren_Id = " + _CapTren_Id + ","
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
        public static DataTable DeleteKhoDuoc(string _Idx, string _NguoiCapNhat)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_006_DanhMuc @Action = N'DeleteKhoDuoc', "
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
        public static DataTable selectNguonDuocSetSTT()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'selectNguonDuocSetSTT'"
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable UpdateNguonDuocSetSTT(
              string _Idx
            , string _NgayCapNhat
            , string _NguoiCapNhat_Id
            , string _STT
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'UpdateNguonDuocSetSTT' ,"
                    + "@Idx = " + _Idx + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ","
                    + "@NguoiCapNhat_Id = " + _NguoiCapNhat_Id + ","
                    + "@Text = " + _STT
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable CheckandInsertNCC(
              string _Text
            , string _NgayCapNhat
            , string _NguoiCapNhat_Id
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'CheckandInsertNCC' ,"
                    + "@Text = " + _Text + ","
                    + "@NgayTao = " + _NgayCapNhat + ","
                    + "@NguoiTao_Id = " + _NguoiCapNhat_Id
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable CheckandInsertDVT(
              string _Text
            , string _NgayCapNhat
            , string _NguoiCapNhat_Id
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'CheckandInsertDVT' ,"
                    + "@Text = " + _Text + ","
                    + "@NgayTao = " + _NgayCapNhat + ","
                    + "@NguoiTao_Id = " + _NguoiCapNhat_Id
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable CheckSTTMaChungTuRef(
              string _Idx
            , string _MucDichChungTu_Id
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'CheckSTTMaChungTuRef' ,"
                    + "@NguonDuoc_Id = " + _Idx + ","
                    + "@MucDichChungTu_Id = " + _MucDichChungTu_Id
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable selectK_DSKiemNhapTheoChungTu(string _ChungTu_Id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'selectK_DSKiemNhapTheoChungTu', @ChungTu_Id = " + _ChungTu_Id
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable UpdateK_DSKiemNhapTheoChungTu(
              string _Idx
            , string _ViTri
            , string _NhanVien
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_DuocPham @Action = N'UpdateK_DSKiemNhapTheoChungTu' ,"
                    + "@Idx = " + _Idx + ","
                    + "@TenNhaCungCap = " + _ViTri + ","
                    + "@Text = " + _NhanVien
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));
                con.Close();
                return table1;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable sp_BaoCao_041_PhieuNhapKhoNCC_Sub(
              string _Idx
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "select * from [K_DSKiemNhap] where ChungTu_ID = " + _Idx
                    ;
                con.Open();
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
