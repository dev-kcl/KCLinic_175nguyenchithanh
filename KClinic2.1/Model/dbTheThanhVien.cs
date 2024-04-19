using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KClinic2._1.Model
{
    class dbTheThanhVien
    {
        public static int timeout_connecttion = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["timeout_connecttion"]);

        public static string sql = Crypt.Decrypt(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"], "CongtyKCL");

        public static SqlConnection con = new SqlConnection(sql);
      
        public static DataTable SelectDanhSachTheThanhVien(string _Search)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_TheThanhVien @Action = N'SelectDanhSachTheThanhVien', "
                    + "@Text = " + _Search
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

        public static DataTable SelectDanhSachLoaiThe(string _Search)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_TheThanhVien @Action = N'SelectDanhSachLoaiThe', "
                    + "@Text = " + _Search
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));

                return table1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public static DataTable SelectDanhSachTheThanhVienTheoId(string _The_Id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_TheThanhVien @Action = N'SelectDanhSachTheThanhVienTheoId', "
                    + "@The_Id = " + _The_Id
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));

                return table1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public static DataTable SelectDanhMucLoaiTheTheoId(string _LoaiThe_Id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_TheThanhVien @Action = N'SelectDanhMucLoaiTheTheoId', "
                    + "@LoaiThe_Id = " + _LoaiThe_Id
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));

                return table1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public static DataTable LoadThongTinTrongTheTheoId(string _The_Id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_TheThanhVien @Action = N'LoadThongTinTrongTheTheoId', "
                    + "@The_Id = " + _The_Id
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));

                return table1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public static DataTable LoadThongTinTrongLoaiTheTheoId(string _LoaiThe_Id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_TheThanhVien @Action = N'LoadThongTinTrongLoaiTheTheoId', "
                    + "@LoaiThe_Id = " + _LoaiThe_Id
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));

                return table1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public static DataTable CheckExistThongTinThe(string _SoThe)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_TheThanhVien @Action = N'CheckExistThongTinThe', "
                    + "@SoTheThanhVien = " + _SoThe + ""
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));

                return table1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public static DataTable CheckExistThongTinLoaiThe(string _MaLoaiThe)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_TheThanhVien @Action = N'CheckExistThongTinLoaiThe', "
                    + "@MaLoaiThe = " + _MaLoaiThe + ""
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));

                return table1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }


        public static DataTable CheckExistThongTinTheThanhVienTheoID(string _The_Id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_TheThanhVien @Action = N'CheckExistThongTinTheThanhVienTheoID', "
                    + "@The_Id = " + _The_Id + ""
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));

                return table1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public static DataTable CheckExistThongTinLoaiTheTheoID(string _LoaiThe_Id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_TheThanhVien @Action = N'CheckExistThongTinLoaiTheTheoID', "
                    + "@LoaiThe_Id = " + _LoaiThe_Id + ""
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));

                return table1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public static DataTable Insert_ThongTinThe(
              string _SoThe
            , string _TenThe
            , string _SoThangHieuLuc
            , string _NgayHieuLuc
            , string _NguoiTao
            , string _NgayTao
            , string _Huy
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_TheThanhVien @Action = N'Insert_ThongTinThe',"
                    + "@SoTheThanhVien = " + _SoThe + ","
                    + "@TenThe = " + _TenThe + ","
                    + "@SoThangHieuLuc = " + _SoThangHieuLuc + ","
                    + "@NgayHieuLuc = " + _NgayHieuLuc + ","
                    + "@NguoiTao = " + _NguoiTao + ","
                    + "@NgayTao = " + _NgayTao + ","
                    + "@Huy = " + _Huy + ""
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));

                return table1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public static DataTable Insert_ThongTinLoaiThe(
              string _MaLoaiThe
            , string _TenLoaiThe
            , string _GhiChu
            , string _NguoiTao
            , string _NgayTao
            , string _Huy
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_TheThanhVien @Action = N'Insert_ThongTinLoaiThe',"
                    + "@MaLoaiThe = " + _MaLoaiThe + ","
                    + "@TenLoaiThe = " + _TenLoaiThe + ","
                    + "@GhiChu = " + _GhiChu + ","
                    + "@NguoiTao = " + _NguoiTao + ","
                    + "@NgayTao = " + _NgayTao + ","
                    + "@Huy = " + _Huy + ""
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));

                return table1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public static DataTable Update_ThongTinThe(
              string _SoThe
            , string _TenThe
            , string _SoThangHieuLuc
            , string _NgayHieuLuc
            , string _NguoiCapNhat
            , string _NgayCapNhat
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_TheThanhVien @Action = N'Update_ThongTinThe',"
                    + "@SoTheThanhVien = " + _SoThe + ","
                    + "@TenThe = " + _TenThe + ","
                    + "@SoThangHieuLuc = " + _SoThangHieuLuc + ","
                    + "@NgayHieuLuc = " + _NgayHieuLuc + ","
                    + "@NguoiCapNhat = " + _NguoiCapNhat + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ""
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));

                return table1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public static DataTable Update_ThongTinLoaiThe(
              string _MaLoaiThe
            , string _TenLoaiThe
            , string _GhiChu
            , string _NguoiCapNhat
            , string _NgayCapNhat
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_TheThanhVien @Action = N'Update_ThongTinLoaiThe',"
                    + "@MaLoaiThe = " + _MaLoaiThe + ","
                    + "@TenLoaiThe = " + _TenLoaiThe + ","
                    + "@GhiChu = " + _GhiChu + ","
                    + "@NguoiCapNhat = " + _NguoiCapNhat + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ""
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));

                return table1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public static DataTable InsertThe_PhienDangNhap(string _PhienDangNhap, string _The_Id, string _DichVu_id, string _SoLuong, string _ThaoTac)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_TheThanhVien @Action = N'InsertThe_PhienDangNhap' ,"
                    + "@PhienDangNhap_Id = " + _PhienDangNhap + ","
                    + "@The_Id = " + _The_Id + ","
                    + "@DichVu_Id = " + _DichVu_id + ","
                    + "@SoLuong = " + _SoLuong + ","
                    + "@ThaoTac = " + _ThaoTac
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));

                return table1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public static DataTable InsertLoaiThe_PhienDangNhap(string _PhienDangNhap, string _LoaiThe_Id, string _NhomDichVu_id, string _SoLuong, string _ThaoTac)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_TheThanhVien @Action = N'InsertLoaiThe_PhienDangNhap' ,"
                    + "@PhienDangNhap_Id = " + _PhienDangNhap + ","
                    + "@LoaiThe_Id = " + _LoaiThe_Id + ","
                    + "@NhomDichVu_Id = " + _NhomDichVu_id + ","
                    + "@SoLuong = " + _SoLuong + ","
                    + "@ThaoTac = " + _ThaoTac
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));

                return table1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public static DataTable SelectThe_PhienDangNhap(string _PhienDangNhap)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_TheThanhVien @Action = N'SelectThe_PhienDangNhap' ,"
                    + "@PhienDangNhap_Id = " + _PhienDangNhap
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));

                return table1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public static DataTable SelectLoaiThe_PhienDangNhap(string _PhienDangNhap)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_TheThanhVien @Action = N'SelectLoaiThe_PhienDangNhap' ,"
                    + "@PhienDangNhap_Id = " + _PhienDangNhap
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));

                return table1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public static DataTable Delete_The_PhienDangNhap(string _The_Id, string _DichVu_Id, string _NguoiCapNhat)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_TheThanhVien @Action = N'Delete_The_PhienDangNhap' ,"
                    + "@The_Id = " + _The_Id + ","
                    + "@DichVu_Id = " + _DichVu_Id + ","
                    + "@NguoiCapNhat = " + _NguoiCapNhat
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));

                return table1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public static DataTable Delete_LoaiThe_PhienDangNhap(string _LoaiThe_Id, string _NhomDichVu_Id, string _NguoiCapNhat)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_TheThanhVien @Action = N'Delete_LoaiThe_PhienDangNhap' ,"
                    + "@LoaiThe_Id = " + _LoaiThe_Id + ","
                    + "@NhomDichVu_Id = " + _NhomDichVu_Id + ","
                    + "@NguoiCapNhat = " + _NguoiCapNhat
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));

                return table1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public static DataTable Insert_DichVuTrongThe(string _PhienDangNhap, string _The_Id, string _DichVu_id, string _SoLuong, string _ThaoTac)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_TheThanhVien @Action = N'InsertThe_PhienDangNhap' ,"
                    + "@PhienDangNhap_Id = " + _PhienDangNhap + ","
                    + "@The_Id = " + _The_Id + ","
                    + "@DichVu_Id = " + _DichVu_id + ","
                    + "@SoLuong = " + _SoLuong + ","
                    + "@ThaoTac = " + _ThaoTac
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));

                return table1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public static DataTable CheckThePhienDangNhap(string _PhienDangNhap)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_TheThanhVien @Action = N'CheckThePhienDangNhap' ,"
                    + "@PhienDangNhap_Id = " + _PhienDangNhap
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));

                return table1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public static DataTable InsertDichVuTrongThe(string _The_Id, string _BenhNhan_Id, string _LoaiThe_Id, string _NguoiTao, string _NgayTao, string _Huy)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_TheThanhVien @Action = N'Insert_DichVuTrongThe' ,"
                    + "@The_Id = " + _The_Id + ","
                    + "@BenhNhan_Id = " + _BenhNhan_Id + ","
                    + "@LoaiThe_Id = " + _LoaiThe_Id + ","
                    + "@NguoiTao = " + _NguoiTao + ","
                    + "@NgayTao = " + _NgayTao + ","
                    + "@Huy = " + _Huy
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

        public static DataTable InsertDichVuTrongLoaiThe(string _LoaiThe_Id, string _NhomDichVu_Id, string _SoLuong
            , string _NguoiTao, string _NgayTao, string _Huy)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_TheThanhVien @Action = N'Insert_DichVuTrongLoaiThe' ,"
                    + "@LoaiThe_Id = " + _LoaiThe_Id + ","
                    + "@NhomDichVu_Id = " + _NhomDichVu_Id + ","
                    + "@SoLuong = " + _SoLuong + ","
                    + "@NguoiTao = " + _NguoiTao + ","
                    + "@NgayTao = " + _NgayTao + ","
                    + "@Huy = " + _Huy
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));

                return table1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public static DataTable UpdateDichVuTrongThe(string _The_Id, string _BenhNhan_Id, string _LoaiThe_Id, string _NguoiTao, string _NgayTao, string _Huy)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_TheThanhVien @Action = N'Update_DichVuTrongThe' ,"
                    + "@The_Id = " + _The_Id + ","
                    + "@BenhNhan_Id = " + _BenhNhan_Id + ","
                    + "@LoaiThe_Id = " + _LoaiThe_Id + ","
                    + "@NguoiTao = " + _NguoiTao + ","
                    + "@NgayTao = " + _NgayTao + ","
                    + "@Huy = " + _Huy
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));

                return table1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public static DataTable UpdateDichVuTrongLoaiThe(string _LoaiThe_Id, string _NhomDichVu_Id, string _SoLuong
            , string _NguoiTao, string _NgayTao, string _Huy)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_TheThanhVien @Action = N'Update_DichVuTrongLoaiThe' ,"
                    + "@LoaiThe_Id = " + _LoaiThe_Id + ","
                    + "@NhomDichVu_Id = " + _NhomDichVu_Id + ","
                    + "@SoLuong = " + _SoLuong + ","
                    + "@NguoiTao = " + _NguoiTao + ","
                    + "@NgayTao = " + _NgayTao + ","
                    + "@Huy = " + _Huy
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));

                return table1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }


        public static DataTable DeleteDichVuTrongThe(string _The_Id, string _NguoiCapNhat, string _NgayCapNhat)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_TheThanhVien @Action = N'Delete_DichVuTrongThe' ,"
                    + "@The_Id = " + _The_Id + ","
                    + "@NguoiCapNhat = " + _NguoiCapNhat + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ""
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));

                return table1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public static DataTable DeleteDichVuTrongLoaiThe(string _LoaiThe_Id, string _NguoiCapNhat, string _NgayCapNhat)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_TheThanhVien @Action = N'Delete_DichVuTrongLoaiThe' ,"
                    + "@LoaiThe_Id = " + _LoaiThe_Id + ","
                    + "@NguoiCapNhat = " + _NguoiCapNhat + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ""
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));

                return table1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }


        public static DataTable HoanTatLoaiThePhienDangNhap(string _PhienDangNhap)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_TheThanhVien @Action = N'HoanTatLoaiThePhienDangNhap' ,"
                    + "@PhienDangNhap_Id = " + _PhienDangNhap
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));

                return table1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public static DataTable ThemLoaiTheVaoPhienDangNhap(string _PhienDangNhap, string _LoaiThe_Id)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_TheThanhVien @Action = N'ThemLoaiTheVaoPhienDangNhap' ,"
                    + "@PhienDangNhap_Id = " + _PhienDangNhap + ","
                    + "@LoaiThe_Id = " + _LoaiThe_Id
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));

                return table1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }


        public static DataTable DeleteThe(string _The_Id, string _NguoiCapNhat)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_TheThanhVien @Action = N'DeleteThe', "
                    + "@The_Id = " + _The_Id + ","
                    + "@NguoiCapNhat = " + _NguoiCapNhat
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));

                return table1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public static DataTable DeleteLoaiThe(string _LoaiThe_Id, string _NguoiCapNhat)
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_TheThanhVien @Action = N'DeleteLoaiThe', "
                    + "@LoaiThe_Id = " + _LoaiThe_Id + ","
                    + "@NguoiCapNhat = " + _NguoiCapNhat
                    ;
                con.Open();
                table1.Load(cmd_Show.ExecuteReader(CommandBehavior.CloseConnection));

                return table1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public static DataTable UpdateBenhNhan(
              string _BenhNhan_Id
            , string _TenBenhNhan
            , string _GioiTinh
            , string _NamSinh
            , string _SoDienThoai
            , string _NguoiCapNhat
            , string _NgayCapNhat
            )
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_002_TiepNhan @Action = N'UpdateBenhNhan',"
                    + "@BenhNhan_Id = " + _BenhNhan_Id + ","
                    + "@TenBenhNhan = " + _TenBenhNhan + ","
                    + "@GioiTinh = " + _GioiTinh + ","
                    + "@NamSinh = " + _NamSinh + ","
                    + "@SoDienThoai = " + _SoDienThoai + ","
                    + "@NguoiCapNhat = " + _NguoiCapNhat + ","
                    + "@NgayCapNhat = " + _NgayCapNhat + ""
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

        public static DataTable SoThangHieuLucThe()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_TheThanhVien @Action = N'SoThangHieuLuc'"
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

        public static DataTable CbbLoaiThe()
        {
            try
            {
                DataTable table1 = new DataTable();
                SqlCommand cmd_Show = con.CreateCommand();
                cmd_Show.CommandTimeout = timeout_connecttion;
                cmd_Show.CommandText = "exec SP_009_TheThanhVien @Action = N'CbbLoaiThe'"
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
    }
}
