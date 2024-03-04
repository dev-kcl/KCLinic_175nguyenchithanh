using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CrystalDecisions.CrystalReports.Engine;
using DevExpress.XtraGrid.Views.Grid;
using System.IO;
using RestSharp;
using Newtonsoft.Json.Linq;
using KClinic2._1.DTOs;
using Newtonsoft.Json;

namespace KClinic2._1.View.XetNghiem
{
    public partial class XetNghiem : DevExpress.XtraEditors.XtraForm
    {
        public string pathDatabaseAPI_Web = System.Configuration.ConfigurationManager.AppSettings["databaseAPI_Web"];
        public string pathAPI_LIS = System.Configuration.ConfigurationManager.AppSettings["pathAPI"];

        public static string TiepNhan_Id = "";
        public string ThaoTac;
        public string CLSYeuCau_Id;
        public string CLSKetQua_Id = "";
        public string BenhNhan_Id = "";
        public string BacSiChiDinh_Id = "";

        public string ListRowPrint = "";

        public XetNghiem()
        {
            InitializeComponent();
        }

        private void XetNghiem_Load(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            btnXoa.Enabled = false;
            btnXem.Enabled = false;
            btnIn.Enabled = false;
            btnTimKiem.Enabled = true;
            An();
            getdata();
            getLayDanhSachBNChuaXNTrongNgay(txtTimKiem.Text);
            if (TiepNhan_Id != "")
            {
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnLuu.Enabled = true;
                btnHuy.Enabled = true;
                btnXoa.Enabled = false;
                btnXem.Enabled = false;
                btnIn.Enabled = false;
                btnTimKiem.Enabled = false;
                Hien();
                ThaoTac = "Them";
                Reset();
                txtSoTiepNhan.Focus();
                DataTable LaySoTiepNhanTuTiepNhan_Id = Model.dbXetNghiem.LaySoTiepNhanTuTiepNhan_Id(TiepNhan_Id);
                checkCLSTheoSoTiepNhan(LaySoTiepNhanTuTiepNhan_Id.Rows[0]["SoTiepNhan"].ToString());
            }
            else { TiepNhan_Id = ""; }
        }
        DataTable KTVThucHien;
        DataTable BacSiKetLuan;
        DataTable LoaiMau;
        DataTable ChatLuongMau;
        DataTable NguoiLayMau;
        DataTable NguoiNhanMau;
        DataTable LayDanhSachBNChuaXNTrongNgay;
        void getdata()
        {
            KTVThucHien = Model.dbXetNghiem.KTVThucHien();
            cbbKTVThucHien.DataSource = KTVThucHien;
            cbbKTVThucHien.ValueMember = "FieldCode";
            cbbKTVThucHien.DisplayMember = "FieldName";
            BacSiKetLuan = Model.dbXetNghiem.BacSiKetLuan();
            cbbBacSiKetLuan.DataSource = BacSiKetLuan;
            cbbBacSiKetLuan.ValueMember = "FieldCode";
            cbbBacSiKetLuan.DisplayMember = "FieldName";
            LoaiMau = Model.dbXetNghiem.LoaiMau();
            cbbLoaiMau.DataSource = LoaiMau;
            cbbLoaiMau.ValueMember = "FieldCode";
            cbbLoaiMau.DisplayMember = "FieldName";
            ChatLuongMau = Model.dbXetNghiem.ChatLuongMau();
            cbbChatLuongMau.DataSource = ChatLuongMau;
            cbbChatLuongMau.ValueMember = "FieldCode";
            cbbChatLuongMau.DisplayMember = "FieldName";

            NguoiLayMau = Model.dbXetNghiem.KTVThucHien();
            cbbNguoiLayMau.DataSource = NguoiLayMau;
            cbbNguoiLayMau.ValueMember = "FieldCode";
            cbbNguoiLayMau.DisplayMember = "FieldName";

            NguoiNhanMau = Model.dbXetNghiem.KTVThucHien();
            cbbNguoiNhanMau.DataSource = NguoiNhanMau;
            cbbNguoiNhanMau.ValueMember = "FieldCode";
            cbbNguoiNhanMau.DisplayMember = "FieldName";
        }

        void getLayDanhSachBNChuaXNTrongNgay(string _text)
        {
            string t = "N'" + _text + "'";
            LayDanhSachBNChuaXNTrongNgay = Model.dbXetNghiem.LayDanhSachBNChuaXNTrongNgay(t, Login.PhongBan_Id);
            gridDSKham.DataSource = LayDanhSachBNChuaXNTrongNgay;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            btnXoa.Enabled = false;
            btnXem.Enabled = false;
            btnIn.Enabled = false;
            btnTimKiem.Enabled = false;
            Hien();
            ThaoTac = "Them";
            TiepNhan_Id = "";
            Reset();
            txtSoTiepNhan.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            btnXoa.Enabled = false;
            btnXem.Enabled = false;
            btnIn.Enabled = false;
            btnTimKiem.Enabled = false;
            Hien();
            ThaoTac = "Sua";
            txtSoTiepNhan.Focus();
            //
            LoadThongTinForm();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtSoTiepNhan.Text == "")
            {
                alertControl1.Show(this, "Thông báo", "Họ Tên không được để trống!", "");
            }
            //if (cbbBacSiKetLuan.SelectedItem == null)
            //{
            //    XtraMessageBox.Show("Chưa chọn bác sĩ kết luận");
            //}
            else
            {
                string KTVThucHien = "null";
                if (cbbKTVThucHien.SelectedItem != null) { KTVThucHien = cbbKTVThucHien.Value.ToString(); }
                //else { XtraMessageBox.Show("Chưa chọn KTV thực hiện"); }

                string LoaiMau = "null";
                if (cbbLoaiMau.SelectedItem != null) { LoaiMau = cbbLoaiMau.Value.ToString(); }

                string ChatLuongMau = "null";
                if (cbbChatLuongMau.SelectedItem != null) { ChatLuongMau = cbbChatLuongMau.Value.ToString(); }

                string NgayThucHien = "'" + txtThoiGianThucHien.Value.ToString("yyyyMMdd") + "'";
                string ThoiGianThucHien = "'" + txtThoiGianThucHien.Value.ToString("yyyyMMdd HH:mm:ss") + "'";

                string NgayLayMau = "'" + txtThoiGianLayMau.Value.ToString("yyyyMMdd") + "'";
                string ThoiGianLayMau = "'" + txtThoiGianLayMau.Value.ToString("yyyyMMdd HH:mm:ss") + "'";
                string NguoiLayMau = "null";
                if (cbbNguoiLayMau.SelectedItem != null) { NguoiLayMau = cbbNguoiLayMau.Value.ToString(); }

                string NgayNhanMau = "'" + txtThoiGianNhanMau.Value.ToString("yyyyMMdd") + "'";
                string ThoiGianNhanMau = "'" + txtThoiGianNhanMau.Value.ToString("yyyyMMdd HH:mm:ss") + "'";
                string NguoiNhanMau = "null";
                if (cbbNguoiNhanMau.SelectedItem != null) { NguoiNhanMau = cbbNguoiNhanMau.Value.ToString(); }

                string GhiChu = "N'" + txtGhiChu.Text.Replace("'", "''") + "'";
                string KetLuan = "N'" + txtKetLuan.Text.Replace("'", "''") + "'";
                string BacSiKetLuan = "null";
                if (cbbBacSiKetLuan.SelectedItem != null) { BacSiKetLuan = cbbBacSiKetLuan.Value.ToString(); }

                string MaVachSID = "N'" + txtMaVachSid.Text.Replace("'", "''") + "'";

                if (ThaoTac == "Them")
                {
                    DataTable Insert = Model.dbXetNghiem.Insert(
                                NgayThucHien
                                , ThoiGianThucHien
                                , TiepNhan_Id
                                , "null"
                                , KTVThucHien
                                , LoaiMau
                                , ChatLuongMau
                                , BacSiKetLuan
                                , KetLuan
                                , "null"
                                , GhiChu
                                , Login.User_Id
                                , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                                , "null"
                                , "null"
                                , "0"
                                , NgayLayMau //ngay lay mau
                                , ThoiGianLayMau //thoi gian lay mau
                                , NguoiLayMau //nguoi lay mau
                                , NgayNhanMau //ngay lay mau
                                , ThoiGianNhanMau //thoi gian nhan mau
                                , NguoiNhanMau //nguoi nhan mau
                                , MaVachSID
                                );
                    if (Insert.Rows.Count > 0)
                    {
                        CLSKetQua_Id = Insert.Rows[0][0].ToString();
                        //update kết quả và trạng thái
                        DataTable gridDichVuDaTa = gridDichVu.DataSource as DataTable;
                        for (int i = 0; i < gridDichVuDaTa.Rows.Count; i++)
                        {
                            string KetQua = gridDichVuDaTa.Rows[i]["KetQua"].ToString();
                            string SId = gridDichVuDaTa.Rows[i]["SID"].ToString();

                            DataTable UpdateKetQuaCLSYeuCau = Model.dbXetNghiem.UpdateKetQuaCLSYeuCau(
                                 gridDichVuDaTa.Rows[i]["CLSYeuCau_Id"].ToString()
                                , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                                , "'" + DateTime.Now.ToString("yyyyMMdd") + "'"
                                , "N'" + KetQua.Replace("'", "''") + "'"
                                , "N'" + SId.Replace("'", "''") + "'"
                                );
                            if (KetQua.Length > 0)
                            {
                                DataTable UpdateTrangThaiCLSYeuCau = Model.dbXetNghiem.UpdateTrangThaiCLSYeuCau(
                                     gridDichVuDaTa.Rows[i]["CLSYeuCau_Id"].ToString()
                                    , "N'CoKetQua'"
                                    );
                            }
                            else
                            {
                                DataTable UpdateTrangThaiCLSYeuCau = Model.dbXetNghiem.UpdateTrangThaiCLSYeuCau(
                                     gridDichVuDaTa.Rows[i]["CLSYeuCau_Id"].ToString()
                                    , "N'ChuaThucHien'"
                                    );
                            }
                        }
                        alertControl1.Show(this, "Thông báo", "Đã thêm thành công!", "");
                        if (TiepNhan_Id != "")
                        {
                            //string NhomDichVu = cbbNhomDichVu.SelectedValue.ToString();
                            DataTable LoadCLSYeuCauTheoTiepNhan_Id = Model.dbXetNghiem.LoadCLSYeuCauTheoTiepNhan_Id(TiepNhan_Id);
                            gridDichVu.DataSource = LoadCLSYeuCauTheoTiepNhan_Id;
                        }
                    }
                }
                if (ThaoTac == "Sua")
                {
                    DataTable Update = Model.dbXetNghiem.Update(
                                NgayThucHien
                                , ThoiGianThucHien
                                , TiepNhan_Id
                                , "null"
                                , KTVThucHien
                                , LoaiMau
                                , ChatLuongMau
                                , BacSiKetLuan
                                , KetLuan
                                , "null"
                                , GhiChu
                                , "null"
                                , "null"
                                , Login.User_Id
                                , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                                , "0"
                                , CLSKetQua_Id
                                , NgayLayMau //ngay lay mau
                                , ThoiGianLayMau //thoi gian lay mau
                                , NguoiLayMau //nguoi lay mau
                                , NgayNhanMau //ngay lay mau
                                , ThoiGianNhanMau //thoi gian nhan mau
                                , NguoiNhanMau //nguoi nhan mau
                                , MaVachSID
                                );
                    if (Update.Rows.Count > 0)
                    {
                        CLSKetQua_Id = Update.Rows[0][0].ToString();
                        //update kết quả và trạng thái
                        DataTable gridDichVuDaTa = gridDichVu.DataSource as DataTable;
                        for (int i = 0; i < gridDichVuDaTa.Rows.Count; i++)
                        {
                            string KetQua = gridDichVuDaTa.Rows[i]["KetQua"].ToString();
                            string SId = gridDichVuDaTa.Rows[i]["SID"].ToString();

                            DataTable UpdateKetQuaCLSYeuCau = Model.dbXetNghiem.UpdateKetQuaCLSYeuCau(
                                 gridDichVuDaTa.Rows[i]["CLSYeuCau_Id"].ToString()
                                , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                                , "'" + DateTime.Now.ToString("yyyyMMdd") + "'"
                                , "N'" + KetQua.Replace("'", "''") + "'"
                                , "N'" + SId.Replace("'", "''") + "'"
                                );
                            if (KetQua.Length > 0)
                            {
                                DataTable UpdateTrangThaiCLSYeuCau = Model.dbXetNghiem.UpdateTrangThaiCLSYeuCau(
                                     gridDichVuDaTa.Rows[i]["CLSYeuCau_Id"].ToString()
                                    , "N'CoKetQua'"
                                    );
                            }
                            else
                            {
                                DataTable UpdateTrangThaiCLSYeuCau = Model.dbXetNghiem.UpdateTrangThaiCLSYeuCau(
                                     gridDichVuDaTa.Rows[i]["CLSYeuCau_Id"].ToString()
                                    , "N'ChuaThucHien'"
                                    );
                            }
                        }
                        alertControl1.Show(this, "Thông báo", "Đã sửa thành công!", "");
                        if (TiepNhan_Id != "")
                        {
                            DataTable LoadCLSYeuCauTheoTiepNhan_Id = Model.dbXetNghiem.LoadCLSYeuCauTheoTiepNhan_Id(TiepNhan_Id);
                            gridDichVu.DataSource = LoadCLSYeuCauTheoTiepNhan_Id;
                        }
                    }
                    //
                }
                //
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnLuu.Enabled = false;
                btnHuy.Enabled = false;
                btnXoa.Enabled = true;
                btnXem.Enabled = true;
                btnIn.Enabled = true;
                btnTimKiem.Enabled = true;
                An();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            btnXem.Enabled = true;
            btnIn.Enabled = true;
            btnTimKiem.Enabled = true;
            An();
            if (ThaoTac == "Them")
            {
                btnThem.Enabled = true;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                TiepNhan_Id = "";
            }
            else if (ThaoTac == "Sua")
            {
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string nguoicapnhat = Login.User_Id;
            DialogResult dr = MessageBox.Show("Bạn có đồng ý xóa?",
            "Thong Bao!", MessageBoxButtons.YesNo);
            switch (dr)
            {
                case DialogResult.Yes:
                    btnThem.Enabled = true;
                    btnSua.Enabled = false;
                    btnLuu.Enabled = false;
                    btnHuy.Enabled = false;
                    btnXoa.Enabled = false;
                    btnXem.Enabled = true;
                    btnIn.Enabled = true;
                    btnTimKiem.Enabled = true;
                    An();
                    //
                    DataTable Delete = Model.dbXetNghiem.Delete(CLSKetQua_Id, nguoicapnhat);
                    alertControl1.Show(this, "Thông báo", "Đã xóa thành công!", "");
                    Reset();
                    CLSKetQua_Id = "";
                    break;
                case DialogResult.No:
                    break;
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (CLSKetQua_Id == "")
            {
                alertControl1.Show(this, "Thông báo", "Bạn chưa chọn Bệnh Nhân!", "");
            }
            else
            {
                DataTable table1 = Model.dbXetNghiem.SP_BaoCao_004_PhieuKetQuaXetNghiem(CLSKetQua_Id);
                if (table1 != null)
                {
                    if (table1.Rows.Count > 0)
                    {
                        table1.Columns.Add("BarcodeMaYTe", System.Type.GetType("System.Byte[]"));
                        table1.Columns.Add("Logo", System.Type.GetType("System.Byte[]"));
                        table1.Columns.Add("TenBenhVien", System.Type.GetType("System.String"));
                        table1.Columns.Add("DiaChiBenhVien", System.Type.GetType("System.String"));
                        table1.Columns.Add("DienThoai", System.Type.GetType("System.String"));
                        byte[] Image = null;
                        byte[] ImageLogo = null;
                        string TenBenhVien = "", DiaChiBenhVien = "", DienThoai = "";
                        if (table1.Rows[0]["MaYTe"].ToString() != "")
                        {
                            DataTable DuongDanHinhAnh = Model.db.DuongDanHinhAnh();
                            string HinhAnhBarcode = DuongDanHinhAnh.Rows[0][0].ToString() + table1.Rows[0]["MaYTe"].ToString() + ".png";
                            FileStream fs = new FileStream(HinhAnhBarcode, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                            Image = new byte[fs.Length];
                            fs.Read(Image, 0, Convert.ToInt32(fs.Length));
                            fs.Close();

                            DataTable SelectSettingTheoSettingCode2 = Model.db.SelectSettingTheoSettingCode("logo");
                            if (SelectSettingTheoSettingCode2 != null)
                            {
                                if (SelectSettingTheoSettingCode2.Rows.Count > 0)
                                {
                                    string Logo = SelectSettingTheoSettingCode2.Rows[0]["NoiDung"].ToString();
                                    FileStream fsLogo = new FileStream(Logo, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                                    ImageLogo = new byte[fsLogo.Length];
                                    fsLogo.Read(ImageLogo, 0, Convert.ToInt32(fsLogo.Length));
                                    fsLogo.Close();
                                }
                            }

                            DataTable BenhVien = Model.db.BenhVien(Login.MaBenhVien);
                            if (BenhVien != null)
                            {
                                if (BenhVien.Rows.Count > 0)
                                {
                                    TenBenhVien = BenhVien.Rows[0]["TenBenhVien"].ToString();
                                    DiaChiBenhVien = BenhVien.Rows[0]["DiaChiBenhVien"].ToString();
                                    DienThoai = BenhVien.Rows[0]["DienThoai"].ToString();
                                }
                            }

                            for (int i = 0; i < table1.Rows.Count; i++)
                            {
                                table1.Rows[i]["BarcodeMaYTe"] = Image;
                                table1.Rows[i]["Logo"] = ImageLogo;
                                table1.Rows[i]["TenBenhVien"] = TenBenhVien;
                                table1.Rows[i]["DiaChiBenhVien"] = DiaChiBenhVien;
                                table1.Rows[i]["DienThoai"] = DienThoai;
                            }
                        }
                    }
                }
                ReportDocument rptDoca = new ReportDocument();
                DataTable ShowDuongDan = Model.db.ShowDuongDan();
                //string DuongDan = @"" + ShowDuongDan.Rows[0][0].ToString() + @"BC002_PhieuTraLoiKetQua.rpt";
                string DuongDan = @"" + ShowDuongDan.Rows[0][0].ToString() + @"BC002_PhieuKetQuaXetNghiem.rpt";
                rptDoca.Load(DuongDan);
                rptDoca.SetDataSource(table1);
                rptDoca.PrintToPrinter(1, false, 0, 0);
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (CLSKetQua_Id == "")
            {
                alertControl1.Show(this, "Thông báo", "Bạn chưa chọn Bệnh Nhân!", "");
            }
            else
            {
                ListRowPrint = "";

                Int32[] selectedRowHandles = gridView1.GetSelectedRows();

                for (int i = 0; i < selectedRowHandles.Length; i++)
                {
                    int selectedRowHandle = selectedRowHandles[i];

                    if (selectedRowHandle >= 0)
                    {
                        ListRowPrint += gridView1.GetRowCellValue(selectedRowHandle, "DichVu_Id").ToString() + ",";
                    }
                }

                View.HeThongBaoCao.PhieuTraLoiKetQuaXN bc = new View.HeThongBaoCao.PhieuTraLoiKetQuaXN(this);
                bc.Show();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            View.XetNghiem.TimKiemCLS tc = new View.XetNghiem.TimKiemCLS(this);
            tc.ShowDialog();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_S_Click(object sender, EventArgs e)
        {
            View.XetNghiem.TimKiemBenhNhan tc = new View.XetNghiem.TimKiemBenhNhan(this);
            tc.ShowDialog();
        }

        private void txtSoTiepNhan_KeyDown(object sender, KeyEventArgs e)
        {
            TiepNhan_Id = "";
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                checkCLSTheoSoTiepNhan(txtSoTiepNhan.Text);
            }
            if (e.KeyCode == Keys.Tab && e.Shift)
            {
                MoveFocusToPreviousTextbox();
                e.SuppressKeyPress = true;
            }
        }
        void checkCLSTheoSoTiepNhan(string SoTiepNhan)
        {

            DataTable CheckDaCoKetQuaTheoSoTiepNhan = Model.dbXetNghiem.CheckDaCoKetQuaTheoSoTiepNhan(SoTiepNhan);
            if (CheckDaCoKetQuaTheoSoTiepNhan != null)
            {
                if (CheckDaCoKetQuaTheoSoTiepNhan.Rows.Count > 0)
                {
                    if (CheckDaCoKetQuaTheoSoTiepNhan.Rows[0]["KetQua"].ToString() == "0")
                    {
                        DataTable CheckDaThanhToanTheoSoTiepNhan = Model.dbXetNghiem.CheckDaThanhToanTheoSoTiepNhan(SoTiepNhan);
                        if (CheckDaThanhToanTheoSoTiepNhan == null || CheckDaThanhToanTheoSoTiepNhan.Rows.Count == 0) { return; }
                        if (CheckDaThanhToanTheoSoTiepNhan.Rows[0]["DaThanhToan"].ToString() == "0")
                        {
                            alertControl1.Show(this, "Thông báo", "Có dịch vụ chưa thanh toán. Vui lòng kiểm tra lại!", "");
                            return;
                        }
                        DataTable LoadThongTinBenhNhan = Model.dbXetNghiem.LoadThongTinBenhNhanTheoSoTiepNhan(SoTiepNhan);
                        if (LoadThongTinBenhNhan.Rows.Count > 0)
                        {
                            txtSoTiepNhan.Text = LoadThongTinBenhNhan.Rows[0]["SoTiepNhan"].ToString();
                            txtMaYTe.Text = LoadThongTinBenhNhan.Rows[0]["MaYTe"].ToString();
                            txtHoTen.Text = LoadThongTinBenhNhan.Rows[0]["TenBenhNhan"].ToString();
                            txtTuoi.Text = LoadThongTinBenhNhan.Rows[0]["Tuoi"].ToString();
                            txtGioiTinh.Text = LoadThongTinBenhNhan.Rows[0]["GioiTinh"].ToString();
                            txtNamSinh.Text = LoadThongTinBenhNhan.Rows[0]["NamSinh"].ToString();
                            txtChanDoan.Text = LoadThongTinBenhNhan.Rows[0]["ChanDoan"].ToString();

                            txtThoiGianThucHien.Value = DateTime.Now;
                            txtThoiGianNhanMau.Value = DateTime.Now;
                            txtThoiGianLayMau.Value = DateTime.Now;

                            txtMaVachSid.Text = LoadThongTinBenhNhan.Rows[0]["SID"].ToString();

                            TiepNhan_Id = LoadThongTinBenhNhan.Rows[0]["TiepNhan_Id"].ToString();
                            //
                            DataTable LoadCLSYeuCauTheoTiepNhan_Id = Model.dbXetNghiem.LoadCLSYeuCauTheoTiepNhan_Id(TiepNhan_Id);
                            gridDichVu.DataSource = LoadCLSYeuCauTheoTiepNhan_Id;
                        }
                        else
                        {
                            alertControl1.Show(this, "Thông báo", "Số tiếp nhận không tồn tại! Vui lòng kiểm tra lại.", "");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Số tiếp nhận đã có kết quả!");
                        btnThem.Enabled = false;
                        btnSua.Enabled = false;
                        btnLuu.Enabled = true;
                        btnHuy.Enabled = true;
                        btnXoa.Enabled = false;
                        btnXem.Enabled = false;
                        btnIn.Enabled = false;
                        btnTimKiem.Enabled = false;
                        Hien();
                        ThaoTac = "Sua";
                        DataTable SuaLoadThongTinBenhNhan = Model.dbXetNghiem.SuaLoadThongTinBenhNhanTheoSoTiepNhan(SoTiepNhan);
                        if (SuaLoadThongTinBenhNhan.Rows.Count > 0)
                        {
                            txtSoTiepNhan.Text = SuaLoadThongTinBenhNhan.Rows[0]["SoTiepNhan"].ToString();
                            txtMaYTe.Text = SuaLoadThongTinBenhNhan.Rows[0]["MaYTe"].ToString();
                            txtHoTen.Text = SuaLoadThongTinBenhNhan.Rows[0]["TenBenhNhan"].ToString();
                            txtTuoi.Text = SuaLoadThongTinBenhNhan.Rows[0]["Tuoi"].ToString();
                            txtGioiTinh.Text = SuaLoadThongTinBenhNhan.Rows[0]["GioiTinh"].ToString();
                            txtNamSinh.Text = SuaLoadThongTinBenhNhan.Rows[0]["NamSinh"].ToString();
                            txtChanDoan.Text = SuaLoadThongTinBenhNhan.Rows[0]["ChanDoan"].ToString();

                            string ThoiGianThucHien = SuaLoadThongTinBenhNhan.Rows[0]["ThoiGianThucHien"].ToString();
                            if (!String.IsNullOrEmpty(ThoiGianThucHien))
                            {
                                DateTime enteredDate = DateTime.Parse(ThoiGianThucHien);
                                txtThoiGianThucHien.Value = enteredDate;
                            }
                            string ThoiGianNhanMau = SuaLoadThongTinBenhNhan.Rows[0]["ThoiGianNhanMau"].ToString();
                            if (!String.IsNullOrEmpty(ThoiGianNhanMau))
                            {
                                DateTime enteredDate = DateTime.Parse(ThoiGianNhanMau);
                                txtThoiGianNhanMau.Value = enteredDate;
                            }
                            string ThoiGianLayMau = SuaLoadThongTinBenhNhan.Rows[0]["ThoiGianLayMau"].ToString();
                            if (!String.IsNullOrEmpty(ThoiGianLayMau))
                            {
                                DateTime enteredDate = DateTime.Parse(ThoiGianLayMau);
                                txtThoiGianLayMau.Value = enteredDate;
                            }
                            txtGhiChu.Text = SuaLoadThongTinBenhNhan.Rows[0]["GhiChu"].ToString();
                            txtKetLuan.Text = SuaLoadThongTinBenhNhan.Rows[0]["KetLuan"].ToString();
                            string BacSiKetLuan_Id = SuaLoadThongTinBenhNhan.Rows[0]["BacSiKetLuan_Id"].ToString();
                            if (!String.IsNullOrEmpty(BacSiKetLuan_Id))
                            {
                                cbbBacSiKetLuan.Value = Int32.Parse(BacSiKetLuan_Id);
                            }
                            string KTVThucHien_Id = SuaLoadThongTinBenhNhan.Rows[0]["KTVThucHien_Id"].ToString();
                            if (!String.IsNullOrEmpty(KTVThucHien_Id))
                            {
                                cbbKTVThucHien.Value = Int32.Parse(KTVThucHien_Id);
                            }
                            //cbbKTVThucHien.SelectedValue = Int32.Parse(SuaLoadThongTinBenhNhan.Rows[0]["KTVThucHien_Id"].ToString());

                            string LoaiMau_Id = SuaLoadThongTinBenhNhan.Rows[0]["LoaiMau"].ToString();
                            if (!String.IsNullOrEmpty(LoaiMau_Id))
                            {
                                cbbLoaiMau.Value = Int32.Parse(LoaiMau_Id);
                            }

                            string ChatLuongMau_Id = SuaLoadThongTinBenhNhan.Rows[0]["ChatLuongMau"].ToString();
                            if (!String.IsNullOrEmpty(ChatLuongMau_Id))
                            {
                                cbbChatLuongMau.Value = Int32.Parse(ChatLuongMau_Id);
                            }

                            string NguoiLayMau_Id = SuaLoadThongTinBenhNhan.Rows[0]["NguoiLayMau_Id"].ToString();
                            if (!String.IsNullOrEmpty(NguoiLayMau_Id))
                            {
                                cbbNguoiLayMau.Value = Int32.Parse(NguoiLayMau_Id);
                            }

                            string NguoiNhanMau_Id = SuaLoadThongTinBenhNhan.Rows[0]["NguoiNhanMau_Id"].ToString();
                            if (!String.IsNullOrEmpty(NguoiNhanMau_Id))
                            {
                                cbbNguoiNhanMau.Value = Int32.Parse(NguoiNhanMau_Id);
                            }

                            txtMaVachSid.Text = SuaLoadThongTinBenhNhan.Rows[0]["SID"].ToString();

                            TiepNhan_Id = SuaLoadThongTinBenhNhan.Rows[0]["TiepNhan_Id"].ToString();
                            CLSKetQua_Id = SuaLoadThongTinBenhNhan.Rows[0]["CLSKetQua_Id"].ToString();

                            DataTable LoadCLSYeuCauTheoTiepNhan_Id = Model.dbXetNghiem.LoadCLSYeuCauTheoTiepNhan_Id(TiepNhan_Id);
                            gridDichVu.DataSource = LoadCLSYeuCauTheoTiepNhan_Id;
                        }
                    }
                }
            }
        }
        public void LoadThongTinFormButton()
        {
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            btnXoa.Enabled = true;
            btnXem.Enabled = true;
            btnIn.Enabled = true;
            btnTimKiem.Enabled = true;
        }
        public void LoadThongTinForm()
        {
            DataTable SuaLoadThongTinBenhNhan = Model.dbXetNghiem.SuaLoadThongTinBenhNhan(CLSKetQua_Id);
            if (SuaLoadThongTinBenhNhan.Rows.Count > 0)
            {
                txtSoTiepNhan.Text = SuaLoadThongTinBenhNhan.Rows[0]["SoTiepNhan"].ToString();
                txtMaYTe.Text = SuaLoadThongTinBenhNhan.Rows[0]["MaYTe"].ToString();
                txtHoTen.Text = SuaLoadThongTinBenhNhan.Rows[0]["TenBenhNhan"].ToString();
                txtTuoi.Text = SuaLoadThongTinBenhNhan.Rows[0]["Tuoi"].ToString();
                txtGioiTinh.Text = SuaLoadThongTinBenhNhan.Rows[0]["GioiTinh"].ToString();
                txtNamSinh.Text = SuaLoadThongTinBenhNhan.Rows[0]["NamSinh"].ToString();
                txtChanDoan.Text = SuaLoadThongTinBenhNhan.Rows[0]["ChanDoan"].ToString();

                string ThoiGianThucHien = SuaLoadThongTinBenhNhan.Rows[0]["ThoiGianThucHien"].ToString();
                if (!String.IsNullOrEmpty(ThoiGianThucHien))
                {
                    DateTime enteredDate = DateTime.Parse(ThoiGianThucHien);
                    txtThoiGianThucHien.Value = enteredDate;
                }
                string ThoiGianNhanMau = SuaLoadThongTinBenhNhan.Rows[0]["ThoiGianNhanMau"].ToString();
                if (!String.IsNullOrEmpty(ThoiGianNhanMau))
                {
                    DateTime enteredDate = DateTime.Parse(ThoiGianNhanMau);
                    txtThoiGianNhanMau.Value = enteredDate;
                }
                string ThoiGianLayMau = SuaLoadThongTinBenhNhan.Rows[0]["ThoiGianLayMau"].ToString();
                if (!String.IsNullOrEmpty(ThoiGianLayMau))
                {
                    DateTime enteredDate = DateTime.Parse(ThoiGianLayMau);
                    txtThoiGianLayMau.Value = enteredDate;
                }
                txtGhiChu.Text = SuaLoadThongTinBenhNhan.Rows[0]["GhiChu"].ToString();
                txtKetLuan.Text = SuaLoadThongTinBenhNhan.Rows[0]["KetLuan"].ToString();
                string BacSiKetLuan_Id = SuaLoadThongTinBenhNhan.Rows[0]["BacSiKetLuan_Id"].ToString();
                if (!String.IsNullOrEmpty(BacSiKetLuan_Id))
                {
                    cbbBacSiKetLuan.Value = Int32.Parse(BacSiKetLuan_Id);
                }

                string KTVThucHien_Id = SuaLoadThongTinBenhNhan.Rows[0]["KTVThucHien_Id"].ToString();
                if (!String.IsNullOrEmpty(KTVThucHien_Id))
                {
                    cbbKTVThucHien.Value = Int32.Parse(KTVThucHien_Id);
                }

                string LoaiMau_Id = SuaLoadThongTinBenhNhan.Rows[0]["LoaiMau"].ToString();
                if (!String.IsNullOrEmpty(LoaiMau_Id))
                {
                    cbbLoaiMau.Value = Int32.Parse(LoaiMau_Id);
                }

                string ChatLuongMau_Id = SuaLoadThongTinBenhNhan.Rows[0]["ChatLuongMau"].ToString();
                if (!String.IsNullOrEmpty(ChatLuongMau_Id))
                {
                    cbbChatLuongMau.Value = Int32.Parse(ChatLuongMau_Id);
                }

                string NguoiLayMau_Id = SuaLoadThongTinBenhNhan.Rows[0]["NguoiLayMau_Id"].ToString();
                if (!String.IsNullOrEmpty(NguoiLayMau_Id))
                {
                    cbbNguoiLayMau.Value = Int32.Parse(NguoiLayMau_Id);
                }

                string NguoiNhanMau_Id = SuaLoadThongTinBenhNhan.Rows[0]["NguoiNhanMau_Id"].ToString();
                if (!String.IsNullOrEmpty(NguoiNhanMau_Id))
                {
                    cbbNguoiNhanMau.Value = Int32.Parse(NguoiNhanMau_Id);
                }

                txtMaVachSid.Text = SuaLoadThongTinBenhNhan.Rows[0]["SID"].ToString();

                TiepNhan_Id = SuaLoadThongTinBenhNhan.Rows[0]["TiepNhan_Id"].ToString();
                CLSKetQua_Id = SuaLoadThongTinBenhNhan.Rows[0]["CLSKetQua_Id"].ToString();

                DataTable LoadCLSYeuCauTheoTiepNhan_Id = Model.dbXetNghiem.LoadCLSYeuCauTheoTiepNhan_Id(TiepNhan_Id);
                gridDichVu.DataSource = LoadCLSYeuCauTheoTiepNhan_Id;
            }
        }

        public void RefreshForm()
        {
            DataTable LayThongTinSoTiepNhan = Model.dbXetNghiem.LayThongTinSoTiepNhan(TiepNhan_Id);
            if (LayThongTinSoTiepNhan.Rows.Count > 0)
            {
                BenhNhan_Id = LayThongTinSoTiepNhan.Rows[0]["BenhNhan_Id"].ToString();
                txtSoTiepNhan.Text = LayThongTinSoTiepNhan.Rows[0]["SoTiepNhan"].ToString();
                txtMaYTe.Text = LayThongTinSoTiepNhan.Rows[0]["MaYTe"].ToString();
                txtHoTen.Text = LayThongTinSoTiepNhan.Rows[0]["TenBenhNhan"].ToString();
                txtTuoi.Text = LayThongTinSoTiepNhan.Rows[0]["Tuoi"].ToString();
                txtGioiTinh.Text = LayThongTinSoTiepNhan.Rows[0]["GioiTinh"].ToString();
                txtNamSinh.Text = LayThongTinSoTiepNhan.Rows[0]["NamSinh"].ToString();
                txtChanDoan.Text = LayThongTinSoTiepNhan.Rows[0]["ChanDoan"].ToString();

                cbbNguoiLayMau.Text = "";
                cbbNguoiNhanMau.Text = "";
                cbbLoaiMau.Text = "";
                cbbChatLuongMau.Text = "";
                cbbBacSiKetLuan.Text = "";

                txtThoiGianThucHien.Value = DateTime.Now;
                txtThoiGianLayMau.Value = DateTime.Now;
                txtThoiGianNhanMau.Value = DateTime.Now;

                txtMaVachSid.Text = LayThongTinSoTiepNhan.Rows[0]["SID"].ToString();

                BacSiChiDinh_Id = LayThongTinSoTiepNhan.Rows[0]["NguoiTiepNhan_Id"].ToString();

                TiepNhan_Id = LayThongTinSoTiepNhan.Rows[0]["TiepNhan_Id"].ToString();
            }

            if (pathDatabaseAPI_Web != "")
            {
                DataTable updateKetQua_Lis = Model.dbXetNghiem.UpdateKetQua_Lis(TiepNhan_Id);
            }

            DataTable LoadCLSYeuCauTheoTiepNhan_Id = Model.dbXetNghiem.LoadCLSYeuCauTheoTiepNhan_Id(TiepNhan_Id);
            gridDichVu.DataSource = LoadCLSYeuCauTheoTiepNhan_Id;

            txtKetLuan.Focus();
        }
        public void Hien()
        {
            txtSoTiepNhan.Enabled = true;
            txtHoTen.Enabled = true;
            txtTuoi.Enabled = true;
            txtMaYTe.Enabled = true;
            txtGioiTinh.Enabled = true;
            txtNamSinh.Enabled = true;
            txtChanDoan.Enabled = true;
            cbbKTVThucHien.Enabled = true;
            cbbBacSiKetLuan.Enabled = true;
            cbbLoaiMau.Enabled = true;
            cbbChatLuongMau.Enabled = true;
            txtGhiChu.Enabled = true;
            txtKetLuan.Enabled = true;
            btn_S.Enabled = true;
            //gridDichVu.Enabled = true;
            txtThoiGianThucHien.Enabled = true;
            //cbbNhomDichVu.Enabled = true;

            cbbNguoiLayMau.Enabled = true;
            txtThoiGianLayMau.Enabled = true;
            cbbNguoiNhanMau.Enabled = true;
            txtThoiGianNhanMau.Enabled = true;

            //txtMaVachSid.Enabled = true;
            //btnLoadSid.Enabled = true;
        }
        public void An()
        {
            txtSoTiepNhan.Enabled = false;
            txtHoTen.Enabled = false;
            txtTuoi.Enabled = false;
            txtMaYTe.Enabled = false;
            txtGioiTinh.Enabled = false;
            txtNamSinh.Enabled = false;
            txtChanDoan.Enabled = false;
            cbbKTVThucHien.Enabled = false;
            cbbBacSiKetLuan.Enabled = false;
            cbbLoaiMau.Enabled = false;
            cbbChatLuongMau.Enabled = false;
            txtGhiChu.Enabled = false;
            txtKetLuan.Enabled = false;
            btn_S.Enabled = false;
            //gridDichVu.Enabled = false;
            txtThoiGianThucHien.Enabled = false;
            //cbbNhomDichVu.Enabled = false;

            cbbNguoiLayMau.Enabled = false;
            txtThoiGianLayMau.Enabled = false;
            cbbNguoiNhanMau.Enabled = false;
            txtThoiGianNhanMau.Enabled = false;

            //txtMaVachSid.Enabled = false;
            //btnLoadSid.Enabled = false;
        }
        public void Reset()
        {
            txtSoTiepNhan.Text = "";
            txtHoTen.Text = "";
            txtTuoi.Text = "";
            txtMaYTe.Text = "";
            txtGioiTinh.Text = "";
            txtNamSinh.Text = "";
            txtChanDoan.Text = "";
            cbbKTVThucHien.Text = "";
            cbbBacSiKetLuan.Text = "";
            cbbLoaiMau.Text = "";
            cbbChatLuongMau.Text = "";
            txtGhiChu.Text = "";
            txtKetLuan.Text = "";
            txtThoiGianThucHien.Text = "";
            gridDichVu.DataSource = null;

            cbbNguoiLayMau.Text = "";
            txtThoiGianLayMau.Text = "";
            cbbNguoiNhanMau.Text = "";
            txtThoiGianNhanMau.Text = "";

            txtMaVachSid.Text = "";
        }

        private void gridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;

            if (e.Column.FieldName == "KetQua")
            {
                string status = View.GetRowCellDisplayText(e.RowHandle, View.Columns["BatThuong"]);
                if (status != "0")
                {
                    e.Appearance.BackColor = Color.FromArgb(231, 76, 60);
                    e.Appearance.FontStyleDelta = FontStyle.Bold;
                    e.Appearance.ForeColor = Color.FromArgb(236, 240, 241);
                }
            }
            if (e.Column.FieldName == "TenDichVu")
            {
                string status = View.GetRowCellDisplayText(e.RowHandle, View.Columns["BatThuong"]);
                if (status != "0")
                {
                    e.Appearance.ForeColor = Color.FromArgb(231, 76, 60);
                    e.Appearance.FontStyleDelta = FontStyle.Bold;
                }
            }
        }

        private void XetNghiem_FormClosing(object sender, FormClosingEventArgs e)
        {
            TiepNhan_Id = "";
        }
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab && e.Shift)
            {
                MoveFocusToPreviousTextbox();
                e.SuppressKeyPress = true;
            }
        }

        private void MoveFocusToPreviousTextbox()
        {
            Control currentControl = this.ActiveControl;

            Control[] controls = this.Controls.Cast<Control>().ToArray();

            int currentIndex = Array.IndexOf(controls, currentControl);
            int previousIndex = (currentIndex - 1 + controls.Length) % controls.Length;

            controls[previousIndex].Focus();
        }

        private void btnLoadSid_Click(object sender, EventArgs e)
        {
            if (TiepNhan_Id == "")
            {
                alertControl1.Show(this, "Thông báo", "Bạn chưa chọn Bệnh Nhân!", "");
                return;
            }


            if (gridView1.RowCount > 0)
            {
                gridView1.BeginDataUpdate();
                DataTable dt = (DataTable)gridDichVu.DataSource;
                foreach (DataRow dr in dt.Rows)
                    dr["SID"] = txtMaVachSid.Text.Trim();
                gridView1.EndDataUpdate();
            }

            DataTable updateMaVachSID = Model.dbXetNghiem.UpdateMaVachSID(
                                 TiepNhan_Id
                                , "N'" + txtMaVachSid.Text.Replace("'", "''") + "'"
                                );
            if (updateMaVachSID.Rows.Count > 0)
            {
                //alertControl1.Show(this, "Thông báo", "Đã cập nhật thành công!", "");
            }
            else
            {
                alertControl1.Show(this, "Thông báo", "Đã cập nhật thất bại!", "");
                return;
            }


            //call api LIS
            if (pathAPI_LIS != "")
            {
                try
                {
                    string _sex = "";
                    if (txtGioiTinh.Text == "Nam")
                    {
                        _sex = "M";
                    }
                    else
                    {
                        _sex = "F";
                    }

                    List<ListTestOrder> listTestOrder = new List<ListTestOrder>();

                    DataTable gridDichVuDaTa = gridDichVu.DataSource as DataTable;
                    foreach (DataRow row in gridDichVuDaTa.Rows)
                    {
                        List<ListSubTest> listSubTest = new List<ListSubTest>();

                        if (row["CLSYeuCau_Cha_Id"].ToString() == "")
                        {
                            DataTable SelectDichVuConTheoID = Model.dbDanhMuc.SelectDichVuConTheoDichVuCha(row["DichVu_Id"].ToString());
                            if (SelectDichVuConTheoID.Rows.Count > 0)
                            {
                                foreach (DataRow rowSub in SelectDichVuConTheoID.Rows)
                                {
                                    ListSubTest orderSub = new ListSubTest
                                    {
                                        TestId = rowSub["Dich_Id"].ToString(),
                                        TestCode = rowSub["MaDichVu"].ToString(),
                                        TestName = rowSub["TenDichVu"].ToString()
                                    };

                                    listSubTest.Add(orderSub);
                                }
                            }

                            // Tạo đối tượng ListTestOrder từ mỗi phần tử trong gridDichVu
                            ListTestOrder order = new ListTestOrder
                            {
                                OrderId = TiepNhan_Id,
                                RequestTime = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss")),
                                TestId = row["DichVu_Id"].ToString(),
                                TestCode = row["MaDichVu"].ToString(),
                                TestName = row["TenDichVu"].ToString(),
                                CategoryId = "",
                                CategoryName = "",
                                SampleInfo = null,
                                ListSubTest = listSubTest,
                                ListAdditionalInfo = null
                            };

                            listTestOrder.Add(order);
                        }
                    }

                    RootObject dataRoot = new RootObject
                    {
                        PatientId = BenhNhan_Id,
                        PatientName = txtHoTen.Text,
                        Sex = _sex,
                        DateOfBirth = DateTime.Parse("2023-11-11"),
                        Age = Int32.Parse(txtTuoi.Text),
                        Address = "PK VSK",
                        Email = "pkvsk@pkvks.com",
                        PhoneNumber = "1111111111",
                        CitizenIdentity = "",
                        Nationality = "VN",
                        Passport = "",
                        InsureNumber = "",
                        MedicalId = txtMaYTe.Text,
                        Bed = "",
                        SampleId = DateTime.Now.ToString("ddMMyy") + "-" + txtMaVachSid.Text,
                        Sequence = txtMaVachSid.Text,
                        RequestTime = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss")),
                        Intime = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss")),
                        HISCode = "KCL",
                        InPatient = false,
                        Urgent = false,
                        ListAdditionalInfo = new List<ListAdditionalInfo> { },
                        ListOrder = new List<ListOrder>
                        {
                            new ListOrder
                            {
                                OrderId = txtMaYTe.Text,
                                ActionCode = null,
                                Diagnostic = "",
                                DoctorID = "VSK",
                                DoctorName = "VSK",
                                LocationID = "PK1",
                                LocationName = "PK1",
                                ObjectID = "KCL",
                                ObjectName = txtHoTen.Text,
                                RequestTime = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss")),
                                ListTestOrder = listTestOrder
                            }
                        }
                    };


                    // Chuyển đối tượng RootObject thành chuỗi JSON
                    string json = JsonConvert.SerializeObject(dataRoot, Formatting.Indented);

                    var client = new RestClient(pathAPI_LIS);
                    var request = new RestRequest(Method.POST);
                    request.AddHeader("cache-control", "no-cache");
                    request.AddHeader("Content-type", "application/json; charset=utf-8");
                    request.RequestFormat = DataFormat.Json;

                    request.AddJsonBody(json);
                    IRestResponse response = client.Execute(request);

                    bool isSuccessful = response.IsSuccessful;

                    if (!isSuccessful)
                    {
                        if (response.Content != "")
                        {
                            dynamic jsonResponse = JsonConvert.DeserializeObject(response.Content);

                            string strError = jsonResponse["Err"].MsgString;

                            if (Microsoft.VisualBasic.Strings.Right(strError, 11) == "đã tồn tại!")
                            {
                                API_LIS();
                            }
                            else
                            {
                                alertControl1.Show(this, "Xảy ra lỗi API LIS", strError, "");
                                return;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    alertControl1.Show(this, "Thông báo", "Lỗi cập nhật API LIS!", "");
                    return;
                }
            }

            alertControl1.Show(this, "Thông báo", "Đã cập nhật thành công!", "");
        }

        private void txtSoTiepNhan_KeyDown_1(object sender, KeyEventArgs e)
        {
            TiepNhan_Id = "";
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                checkCLSTheoSoTiepNhan(txtSoTiepNhan.Text);
            }
        }

        private void btn_S_Click_1(object sender, EventArgs e)
        {
            View.XetNghiem.TimKiemBenhNhan tc = new View.XetNghiem.TimKiemBenhNhan(this);
            tc.ShowDialog();
        }

        private void btnLamTuoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Text = "";
            getLayDanhSachBNChuaXNTrongNgay(txtTimKiem.Text);
        }

        private void gridView2_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            int n = e.RowHandle;
            if (gridView2.RowCount > 0)
            {
                TiepNhan_Id = gridView2.GetRowCellValue(n, "TiepNhan_Id").ToString();
                RefreshForm();
            }
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                getLayDanhSachBNChuaXNTrongNgay(txtTimKiem.Text);
            }
        }

        private void API_LIS()
        {
            try
            {
                string _sex = "";
                if (txtGioiTinh.Text == "Nam")
                {
                    _sex = "M";
                }
                else
                {
                    _sex = "F";
                }

                List<ListTestOrder> listTestOrder = new List<ListTestOrder>();

                DataTable gridDichVuDaTa = gridDichVu.DataSource as DataTable;
                foreach (DataRow row in gridDichVuDaTa.Rows)
                {
                    List<ListSubTest> listSubTest = new List<ListSubTest>();

                    if (row["CLSYeuCau_Cha_Id"].ToString() == "")
                    {
                        DataTable SelectDichVuConTheoID = Model.dbDanhMuc.SelectDichVuConTheoDichVuCha(row["DichVu_Id"].ToString());
                        if (SelectDichVuConTheoID.Rows.Count > 0)
                        {
                            foreach (DataRow rowSub in SelectDichVuConTheoID.Rows)
                            {
                                ListSubTest orderSub = new ListSubTest
                                {
                                    TestId = rowSub["Dich_Id"].ToString(),
                                    TestCode = rowSub["MaDichVu"].ToString(),
                                    TestName = rowSub["TenDichVu"].ToString()
                                };

                                listSubTest.Add(orderSub);
                            }
                        }

                        // Tạo đối tượng ListTestOrder từ mỗi phần tử trong gridDichVu
                        ListTestOrder order = new ListTestOrder
                        {
                            OrderId = TiepNhan_Id,
                            RequestTime = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss")),
                            TestId = row["DichVu_Id"].ToString(),
                            TestCode = row["MaDichVu"].ToString(),
                            TestName = row["TenDichVu"].ToString(),
                            CategoryId = "",
                            CategoryName = "",
                            SampleInfo = null,
                            ListSubTest = listSubTest,
                            ListAdditionalInfo = null
                        };

                        listTestOrder.Add(order);
                    }
                }

                RootObject dataRoot = new RootObject
                {
                    PatientId = BenhNhan_Id,
                    PatientName = txtHoTen.Text,
                    Sex = _sex,
                    DateOfBirth = DateTime.Parse("2023-11-11"),
                    Age = Int32.Parse(txtTuoi.Text),
                    Address = "PK VSK",
                    Email = "pkvsk@pkvks.com",
                    PhoneNumber = "1111111111",
                    CitizenIdentity = "",
                    Nationality = "VN",
                    Passport = "",
                    InsureNumber = "",
                    MedicalId = txtMaYTe.Text,
                    Bed = "",
                    SampleId = DateTime.Now.ToString("ddMMyy") + "-" + txtMaVachSid.Text,
                    Sequence = txtMaVachSid.Text,
                    RequestTime = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss")),
                    Intime = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss")),
                    HISCode = "KCL",
                    InPatient = false,
                    Urgent = false,
                    ListAdditionalInfo = new List<ListAdditionalInfo> { },
                    ListOrder = new List<ListOrder>
                        {
                            new ListOrder
                            {
                                OrderId = txtMaYTe.Text,
                                ActionCode = 1,
                                Diagnostic = "",
                                DoctorID = "VSK",
                                DoctorName = "VSK",
                                LocationID = "PK1",
                                LocationName = "PK1",
                                ObjectID = "KCL",
                                ObjectName = txtHoTen.Text,
                                RequestTime = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss")),
                                ListTestOrder = listTestOrder
                            }
                        }
                };


                // Chuyển đối tượng RootObject thành chuỗi JSON
                string json = JsonConvert.SerializeObject(dataRoot, Formatting.Indented);

                var client = new RestClient(pathAPI_LIS);
                var request = new RestRequest(Method.POST);
                request.AddHeader("cache-control", "no-cache");
                request.AddHeader("Content-type", "application/json; charset=utf-8");
                request.RequestFormat = DataFormat.Json;

                request.AddJsonBody(json);
                IRestResponse response = client.Execute(request);

                bool isSuccessful = response.IsSuccessful;

                if (!isSuccessful)
                {
                    if (response.Content != "")
                    {
                        dynamic jsonResponse = JsonConvert.DeserializeObject(response.Content);

                        string strError = jsonResponse["Err"].MsgString;

                        alertControl1.Show(this, "Xảy ra lỗi API LIS", strError, "");

                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                alertControl1.Show(this, "Thông báo", "Lỗi cập nhật API LIS!", "");
                return;
            }
        }
    }
}