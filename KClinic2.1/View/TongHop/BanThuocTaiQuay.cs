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
using DevExpress.XtraGrid.Views.Grid;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using System.Collections;

namespace KClinic2._1.View.TongHop
{
    public partial class BanThuocTaiQuay : DevExpress.XtraEditors.XtraForm
    {
        public static string TiepNhan_Id = "";
        public string ThaoTac;
        public string BenhNhan_Id = "";
        public string TenBenhNhan;
        public string MaYTe = "";
        public string SoVaoVien = "";
        public string HoaDon_Id;
        public string HoaDonChiTiet_Id;

        DataTable HinhThucThanhToan;
        DataTable MaHoaDon;
        DataTable SoHoaDon;

        public BanThuocTaiQuay()
        {
            InitializeComponent();
        }

        private void BanThuocTaiQuay_Load(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            btnBoQua.Enabled = false;
            btnLuu.Enabled = false;
            btnHuyHoaDon.Enabled = false;
            btnHoanTra.Enabled = false;
            btnXem.Enabled = false;
            btnIn.Enabled = false;
            btnTimKiem.Enabled = true;
            An();
            getdata();
            BenhNhan_Id = "";
            HoaDon_Id = "";
            //pnTrangThai.Enabled = false;
        }

        void getdata()
        {
            HinhThucThanhToan = Model.HoaDondb.HinhThucThanhToan();
            cbbHinhThucThanhToan.DataSource = HinhThucThanhToan;
            cbbHinhThucThanhToan.DisplayMember = "FieldName";
            cbbHinhThucThanhToan.ValueMember = "FieldCode";
            MaHoaDon = Model.HoaDondb.MaHoaDon();
            cbbMaHoaDon.DataSource = MaHoaDon;
            cbbMaHoaDon.DisplayMember = "FieldName";
            cbbMaHoaDon.ValueMember = "FieldCode";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (BenhNhan_Id != "")
            {
                btnThem.Enabled = false;
                btnLuu.Enabled = true;
                btnBoQua.Enabled = true;
                btnHuyHoaDon.Enabled = false;
                btnHoanTra.Enabled = false;
                btnXem.Enabled = false;
                btnIn.Enabled = false;
                btnTimKiem.Enabled = false;
                btn_S.Enabled = false;
                txtMaYTe.Enabled = false;
                pnSoHoaDon.Enabled = false;
                Hien();
                ThaoTac = "Them";
                //BenhNhan_Id = "";
                //TenBenhNhan = "";
                //TiepNhan_Id = "";
                MaYTe = ""; SoVaoVien = "";
                HoaDon_Id = "";
                Reset();
                cbbHinhThucThanhToan.SelectedIndex = 0;
                cbbMaHoaDon.SelectedIndex = 0;
                RefreshForm();
            }
            else
            {
                alertControl1.Show(this, "Thông báo", "Chưa có dữ liệu bệnh nhân!", "");
            }
            
            txtMaYTe.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount == 0)
            {
                alertControl1.Show(this, "Thông báo", "Chưa chọn dịch vụ thanh toán viện phí!", "");
            }
            else if (cbbHinhThucThanhToan.SelectedItem == null)
            {
                alertControl1.Show(this, "Thông báo", "Chưa chọn hình thức thanh toán!", "");
            }
            else if (cbbMaHoaDon.SelectedItem == null)
            {
                alertControl1.Show(this, "Thông báo", "Chưa chọn mã hoá đơn thanh toán!", "");
            }
            else
            {
                string MaSoThue = "null";
                if (txtMaSoThue.Text != "") { MaSoThue = "N'" + txtMaSoThue.Text.Replace("'", "''") + "'"; }
                string TenDonVi = "null";
                if (txtTenDonVi.Text != "") { TenDonVi = "N'" + txtTenDonVi.Text.Replace("'", "''") + "'"; }
                string HinhThucThanhToan = "null";
                if (cbbHinhThucThanhToan.SelectedItem != null) { HinhThucThanhToan = cbbHinhThucThanhToan.Value.ToString(); }
                string MaHoaDon = "null";
                if (cbbMaHoaDon.SelectedItem != null) { MaHoaDon = "N'" + cbbMaHoaDon.Text.Replace("'", "''") + "'"; }
                string ThoiGianPhatSinh = "'" + txtThoiGianPhatSinh.Value.ToString("yyyyMMdd HH:mm:ss") + "'";
                string NgayPhatSinh = "'" + txtThoiGianPhatSinh.Value.ToString("yyyyMMdd") + "'";

                string GiamGia = "0";
                if (txtGiamGia.Text != "") { GiamGia = "N'" + txtGiamGia.Text.Replace("'", "''") + "'"; }
                string GiamGiaTyLe = "0";
                if (cbTiLe.Checked == true) { GiamGiaTyLe = "1"; }

                if (ThaoTac == "Them")
                {
                    if (BenhNhan_Id != "")
                    {
                        DataTable InsertHoaDon = Model.HoaDondb.InsertHoaDon(
                              MaHoaDon
                              , "null" //SoHoaDonVAT
                              , "null"
                              , "null"
                            , BenhNhan_Id
                            , NgayPhatSinh
                            , ThoiGianPhatSinh
                            , Login.User_Id
                            , "null" //GiaTriHoaDon
                            , HinhThucThanhToan
                            , "null" //HuyHoaDon
                            , "null"
                            , "null"
                            , "null"
                            , Login.User_Id
                            , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                            , "null"
                            , "null"
                            , MaSoThue
                            , TenDonVi
                            , GiamGia
                            , GiamGiaTyLe
                            );
                        if (InsertHoaDon.Rows.Count > 0)
                        {
                            HoaDon_Id = InsertHoaDon.Rows[0]["HoaDon_Id"].ToString();
                            alertControl1.Show(this, "Thông báo", "Đã thêm thành công hoá đơn " + InsertHoaDon.Rows[0]["SoHoaDon"].ToString(), "");

                            Int32[] selectedRowHandles = gridView1.GetSelectedRows();
                            //for (int i = 0; i < selectedRowHandles.Length; i++)
                            //{
                            //    int selectedRowHandle = selectedRowHandles[i];
                            //    if (selectedRowHandle >= 0)
                            //        rows.Add(gridView1.GetDataRow(selectedRowHandle));
                            //}
                            decimal GiaTriHoaDon = 0;

                            for (int i = 0; i < selectedRowHandles.Length; i++)
                            {
                                int selectedRowHandle = selectedRowHandles[i];
                                Decimal _ThanhTienChitiet = 0;
                                if (selectedRowHandle >= 0)
                                {
                                    if (gridView1.GetRowCellValue(selectedRowHandle, "Loai_Id").ToString() == "1")
                                    {
                                        Decimal _SoLuong = Decimal.Parse(gridView1.GetRowCellValue(selectedRowHandle, "SoLuong").ToString(), System.Globalization.CultureInfo.InvariantCulture);
                                        Decimal _DonGiaDichVu = Decimal.Parse(gridView1.GetRowCellValue(selectedRowHandle, "DonGiaDichVu").ToString(), System.Globalization.CultureInfo.InvariantCulture);
                                        Decimal _GiamGiaTiLe = 0;
                                        Decimal _GiamGia = 0;

                                        if (gridView1.GetRowCellValue(selectedRowHandle, "GiamGiaTiLe").ToString() != "")
                                        {
                                            _GiamGiaTiLe = Decimal.Parse(gridView1.GetRowCellValue(selectedRowHandle, "GiamGiaTiLe").ToString(), System.Globalization.CultureInfo.InvariantCulture);
                                        }

                                        if (gridView1.GetRowCellValue(selectedRowHandle, "GiamGia").ToString() != "")
                                        {
                                            _GiamGia = Decimal.Parse(gridView1.GetRowCellValue(selectedRowHandle, "GiamGia").ToString(), System.Globalization.CultureInfo.InvariantCulture);
                                        }

                                        //if (gridView1.GetRowCellValue(selectedRowHandle, "GiamGiaTiLe").ToString() == "1")
                                        //{
                                        //    _ThanhTienChitiet = (_SoLuong * _DonGiaDichVu) - ((_SoLuong * _DonGiaDichVu) / _GiamGia * 100);
                                        //}
                                        //else
                                        //{
                                        //    _ThanhTienChitiet = (_SoLuong * _DonGiaDichVu) - _GiamGia;
                                        //}
                                        _ThanhTienChitiet = (_SoLuong * _DonGiaDichVu) - _GiamGia;
                                        DataTable InsertHoaDonChiTiet = Model.HoaDondb.InsertHoaDonChiTiet(
                                             HoaDon_Id
                                             , gridView1.GetRowCellValue(selectedRowHandle, "IDx").ToString()
                                             , "null"
                                             , gridView1.GetRowCellValue(selectedRowHandle, "SoLuong").ToString()
                                             , gridView1.GetRowCellValue(selectedRowHandle, "DonGiaDichVu").ToString()
                                             , _ThanhTienChitiet.ToString("0.00")
                                             //, gridView1.GetRowCellValue(selectedRowHandle, "ThanhTienDichVu").ToString()
                                             , "null" //DaHoanTra
                                             , gridView1.GetRowCellValue(selectedRowHandle, "Loai_Id").ToString()
                                             , _GiamGia.ToString()
                                             , _GiamGiaTiLe.ToString()
                                           );
                                        DataTable UpdateTrangThaiThanhToanCLSYeuCau = Model.HoaDondb.UpdateTrangThaiThanhToanCLSYeuCau(gridView1.GetRowCellValue(selectedRowHandle, "IDx").ToString());
                                    }
                                    else if (gridView1.GetRowCellValue(selectedRowHandle, "Loai_Id").ToString() == "2")
                                    {
                                        Decimal _SoLuong = Decimal.Parse(gridView1.GetRowCellValue(selectedRowHandle, "SoLuong").ToString(), System.Globalization.CultureInfo.InvariantCulture);
                                        Decimal _DonGiaDichVu = Decimal.Parse(gridView1.GetRowCellValue(selectedRowHandle, "DonGiaDichVu").ToString(), System.Globalization.CultureInfo.InvariantCulture);
                                        Decimal _GiamGiaTiLe = 0;
                                        Decimal _GiamGia = 0;

                                        if (gridView1.GetRowCellValue(selectedRowHandle, "GiamGiaTiLe").ToString() != "")
                                        {
                                            _GiamGiaTiLe = Decimal.Parse(gridView1.GetRowCellValue(selectedRowHandle, "GiamGiaTiLe").ToString(), System.Globalization.CultureInfo.InvariantCulture);
                                        }

                                        if (gridView1.GetRowCellValue(selectedRowHandle, "GiamGia").ToString() != "")
                                        {
                                            _GiamGia = Decimal.Parse(gridView1.GetRowCellValue(selectedRowHandle, "GiamGia").ToString(), System.Globalization.CultureInfo.InvariantCulture);
                                        }
                                        //Decimal _GiamGia = Decimal.Parse(gridView1.GetRowCellValue(selectedRowHandle, "GiamGia").ToString(), System.Globalization.CultureInfo.InvariantCulture);
                                        //if (gridView1.GetRowCellValue(selectedRowHandle, "GiamGiaTiLe").ToString() == "1")
                                        //{
                                        //    _ThanhTienChitiet = (_SoLuong * _DonGiaDichVu) - ((_SoLuong * _DonGiaDichVu) / _GiamGia * 100);
                                        //}
                                        //else
                                        //{
                                        //    _ThanhTienChitiet = (_SoLuong * _DonGiaDichVu) - _GiamGia;
                                        //}
                                        _ThanhTienChitiet = (_SoLuong * _DonGiaDichVu) - _GiamGia;
                                        DataTable InsertHoaDonChiTiet = Model.HoaDondb.InsertHoaDonChiTiet(
                                             HoaDon_Id
                                             , "null"
                                             , gridView1.GetRowCellValue(selectedRowHandle, "IDx").ToString()
                                             , gridView1.GetRowCellValue(selectedRowHandle, "SoLuong").ToString()
                                             , gridView1.GetRowCellValue(selectedRowHandle, "DonGiaDichVu").ToString()
                                             , gridView1.GetRowCellValue(selectedRowHandle, "ThanhTienDichVu").ToString()
                                             , "null" //DaHoanTra
                                             , gridView1.GetRowCellValue(selectedRowHandle, "Loai_Id").ToString()
                                             , _GiamGia.ToString() //gridView1.GetRowCellValue(selectedRowHandle, "GiamGia").ToString()
                                             , _GiamGiaTiLe.ToString() //gridView1.GetRowCellValue(selectedRowHandle, "GiamGiaTiLe").ToString()
                                           );
                                        DataTable UpdateTrangThaiThanhToanToaThuoc = Model.HoaDondb.UpdateTrangThaiThanhToanToaThuoc(gridView1.GetRowCellValue(selectedRowHandle, "IDx").ToString());
                                    }

                                    GiaTriHoaDon += _ThanhTienChitiet;//Decimal.Parse(gridView1.GetRowCellValue(selectedRowHandle, "ThanhTienDichVu").ToString(), System.Globalization.CultureInfo.InvariantCulture);
                                }
                                    

                                //txtGiaTriHoaDon.Text += gridView1.GetRowCellValue(selectedRowHandle, "IDx").ToString() + "; ";
                            }
                            //update giatrihoadon
                            string GiaTriHoaDonstr = "'" + GiaTriHoaDon.ToString("0.00") + "'";
                            DataTable UpdateGiaTriHoaDon = Model.HoaDondb.UpdateGiaTriHoaDon(HoaDon_Id, GiaTriHoaDonstr);
                            //select hoadon đã lưu
                            LoadHoaDonBenhNhan();
                            if (!String.IsNullOrEmpty(HoaDon_Id))
                            {
                                cbbSoHoaDon.Value = Int32.Parse(HoaDon_Id);
                            }
                            SelectHoaDonTheoHoaDonID(HoaDon_Id);
                        }
                        //
                    }
                }
                //
                //
                btnThem.Enabled = true;
                btnHuyHoaDon.Enabled = true;
                btnLuu.Enabled = false;
                btnBoQua.Enabled = false;
                btnHoanTra.Enabled = false;
                btnXem.Enabled = true;
                btnIn.Enabled = true;
                btnTimKiem.Enabled = true;
                btn_S.Enabled = true;
                txtMaYTe.Enabled = true;
                pnSoHoaDon.Enabled = true;
                An();
            }
            
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            btnXem.Enabled = false;
            btnIn.Enabled = false;
            btnTimKiem.Enabled = true;
            An();
            txtMaYTe.Enabled = true;
            btn_S.Enabled = true;
            pnSoHoaDon.Enabled = true;
            HoaDon_Id = "";
            if (ThaoTac == "Them")
            {
                btnThem.Enabled = true;
                btnHuyHoaDon.Enabled = false;
                btnHoanTra.Enabled = false;
                //BenhNhan_Id = "";
                //TiepNhan_Id = "";
            }
            else if (ThaoTac == "Sua")
            {
                btnThem.Enabled = true;
                btnHuyHoaDon.Enabled = true;
                btnHoanTra.Enabled = true;
            }
        }

        private void btnHuyHoaDon_Click(object sender, EventArgs e)
        {
            if (BenhNhan_Id != "")
            {
                if (HoaDon_Id != "0")
                {
                    string nguoicapnhat = Login.User_Id;
                    DialogResult dr = MessageBox.Show("Bạn có đồng ý huỷ hoá đơn này?",
                    "Thong Bao!", MessageBoxButtons.YesNo);
                    switch (dr)
                    {
                        case DialogResult.Yes:
                            btnThem.Enabled = true;
                            btnBoQua.Enabled = false;
                            btnLuu.Enabled = false;
                            btnHuyHoaDon.Enabled = false;
                            btnHoanTra.Enabled = false;
                            btnXem.Enabled = false;
                            btnIn.Enabled = false;
                            btnTimKiem.Enabled = true;

                            //
                            DataTable Delete = Model.HoaDondb.HuyHoaDon(HoaDon_Id, nguoicapnhat);
                            alertControl1.Show(this, "Thông báo", "Đã huỷ hoá đơn thành công!", "");
                            HoaDon_Id = "";
                            An();
                            Reset();
                            txtMaYTe.Focus();
                            RefreshForm();

                            break;
                        case DialogResult.No:
                            break;
                    }
                }
                else { alertControl1.Show(this, "Thông báo", "Chưa chọn hoá đơn!", ""); }
            }
            else { alertControl1.Show(this, "Thông báo", "Chưa chọn hoá đơn!", ""); }
        }

        private void btnHoanTra_Click(object sender, EventArgs e)
        {
            if (BenhNhan_Id != "")
            {
                if (HoaDon_Id != "0")
                {
                    string nguoicapnhat = Login.User_Id;
                    DialogResult dr = MessageBox.Show("Bạn có đồng ý hoàn trả hoá đơn này?",
                    "Thong Bao!", MessageBoxButtons.YesNo);
                    switch (dr)
                    {
                        case DialogResult.Yes:
                            btnThem.Enabled = true;
                            btnBoQua.Enabled = false;
                            btnLuu.Enabled = false;
                            btnHuyHoaDon.Enabled = false;
                            btnHoanTra.Enabled = false;
                            btnXem.Enabled = false;
                            btnIn.Enabled = false;
                            btnTimKiem.Enabled = true;

                            //
                            DataTable HoanTraHoaDon = Model.HoaDondb.HoanTraHoaDon(HoaDon_Id, nguoicapnhat);
                            alertControl1.Show(this, "Thông báo", "Đã hoàn trả hoá đơn thành công!", "");
                            HoaDon_Id = "";
                            An();
                            Reset();
                            txtMaYTe.Focus();
                            RefreshForm();

                            break;
                        case DialogResult.No:
                            break;
                    }
                }
                else { alertControl1.Show(this, "Thông báo", "Chưa chọn hoá đơn!", ""); }
            }
            else { alertControl1.Show(this, "Thông báo", "Chưa chọn hoá đơn!", ""); }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (HoaDon_Id == "")
            {
                MessageBox.Show("Bạn chưa chọn Hoá đơn!");
            }
            else
            {
                DataTable table1 = Model.HoaDondb.SP_BaoCao_010_HoaDonBanHang(HoaDon_Id);
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
                            //DataTable DuongDanHinhAnh = Model.db.DuongDanHinhAnh();
                            //string HinhAnhBarcode = DuongDanHinhAnh.Rows[0][0].ToString() + table1.Rows[0]["MaYTe"].ToString() + ".png";
                            //FileStream fs = new FileStream(HinhAnhBarcode, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                            //Image = new byte[fs.Length];
                            //fs.Read(Image, 0, Convert.ToInt32(fs.Length));
                            //fs.Close();

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
                //string DuongDan = @"" + ShowDuongDan.Rows[0][0].ToString() + @"BC014_HoaDonBanHang.rpt";
                string DuongDan = @"" + ShowDuongDan.Rows[0][0].ToString() + @"BC014_BangKePhiDichVu.rpt"; 
                rptDoca.Load(DuongDan);
                rptDoca.SetDataSource(table1);
                rptDoca.PrintToPrinter(1, false, 0, 0);
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (HoaDon_Id == "")
            {
                MessageBox.Show("Bạn chưa chọn Hoá đơn!");
            }
            else
            {
                View.HeThongBaoCao.HoaDonBanHang bc = new View.HeThongBaoCao.HoaDonBanHang(this);
                bc.Show();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            View.TongHop.DanhSachThuTien tc = new View.TongHop.DanhSachThuTien(this);
            tc.ShowDialog();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Reset();
            this.Close();
        }

        private void btn_S_Click(object sender, EventArgs e)
        {
            View.TongHop.TimKiemBNChuaBanThuoc tc = new View.TongHop.TimKiemBNChuaBanThuoc(this);
            tc.ShowDialog();
        }

        private void cbbKTVThucHien_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Tab && e.KeyData != Keys.Enter && e.KeyData != Keys.Up && e.KeyData != Keys.Down && e.KeyData != Keys.Right && e.KeyData != Keys.Left)
            {
                string text = cbbSoHoaDon.Text;
                DataRow[] resultRow = SoHoaDon.Select("TenDichVu LIKE '%" + text + "%' or MaDichVu LIKE '%" + text + "%'");
                if (resultRow.Count() > 0)
                {
                    DataTable dtResult = SoHoaDon.Select("TenDichVu LIKE '%" + text + "%' or MaDichVu LIKE '%" + text + "%'").CopyToDataTable();
                    cbbSoHoaDon.DataSource = dtResult;
                    cbbSoHoaDon.DroppedDown = true;
                }
                else
                {
                    cbbSoHoaDon.DataSource = null;
                    cbbSoHoaDon.DroppedDown = true;
                }
            }
        }
        public void SelectHoaDonTheoHoaDonID(string _HoaDon_Id)
        {
            DataTable SelectHoaDonTheoID = Model.HoaDondb.SelectHoaDonTheoID(_HoaDon_Id);
            if (SelectHoaDonTheoID.Rows.Count > 0)
            {
                txtMaYTe.Text = SelectHoaDonTheoID.Rows[0]["MaYTe"].ToString();
                MaYTe = SelectHoaDonTheoID.Rows[0]["MaYTe"].ToString();
                SoVaoVien = SelectHoaDonTheoID.Rows[0]["SoVaoVien"].ToString();
                txtHoTen.Text = SelectHoaDonTheoID.Rows[0]["TenBenhNhan"].ToString();
                txtTuoi.Text = SelectHoaDonTheoID.Rows[0]["Tuoi"].ToString();
                txtNamSinh.Text = SelectHoaDonTheoID.Rows[0]["NamSinh"].ToString();
                txtGioiTinh.Text = SelectHoaDonTheoID.Rows[0]["GioiTinh"].ToString();
                txtSoDienThoai.Text = SelectHoaDonTheoID.Rows[0]["SoDienThoai"].ToString();
                txtMaSoThue.Text = SelectHoaDonTheoID.Rows[0]["MaSoThue"].ToString();
                txtTenDonVi.Text = SelectHoaDonTheoID.Rows[0]["TenDonVi"].ToString();
                decimal decimalgthd = Decimal.Parse(SelectHoaDonTheoID.Rows[0]["GiaTriHoaDon"].ToString(), System.Globalization.CultureInfo.InvariantCulture);
                decimal decimalgg = Decimal.Parse(SelectHoaDonTheoID.Rows[0]["GiamGia"].ToString(), System.Globalization.CultureInfo.InvariantCulture);
                txtGiaTriHoaDon.Text = decimalgthd.ToString("0,0.00");
                txtGiamGia.Text = decimalgg.ToString("0,0.00");
                if(SelectHoaDonTheoID.Rows[0]["GiamGiaTiLe"].ToString() == "1") { cbTiLe.Checked = true; } else { cbTiLe.Checked = false; }
                BenhNhan_Id = SelectHoaDonTheoID.Rows[0]["BenhNhan_Id"].ToString();
                HoaDon_Id = SelectHoaDonTheoID.Rows[0]["HoaDon_Id"].ToString();
                string ThoiGianPhatSinh = SelectHoaDonTheoID.Rows[0]["ThoiGianPhatSinh"].ToString();
                if (!String.IsNullOrEmpty(ThoiGianPhatSinh))
                {
                    DateTime enteredDate = DateTime.Parse(ThoiGianPhatSinh);
                    txtThoiGianPhatSinh.Value = enteredDate;
                }
            }
            DataTable LoadDanhSachDichVuTheoHoaDon_Id = Model.HoaDondb.LoadDanhSachDichVuTheoHoaDon_Id(HoaDon_Id);
            gridDichVu.DataSource = LoadDanhSachDichVuTheoHoaDon_Id;
        }

        public void LoadHoaDonBenhNhan()
        {
            SoHoaDon = Model.HoaDondb.LoadHoaDonBenhNhan(BenhNhan_Id);
            cbbSoHoaDon.DataSource = SoHoaDon;
            cbbSoHoaDon.DisplayMember = "SoHoaDon";
            cbbSoHoaDon.ValueMember = "HoaDon_Id";
            cbbSoHoaDon.Enabled = true;
        }
        public void selectCombobox()
        {
            if (!String.IsNullOrEmpty(HoaDon_Id))
            {
                cbbSoHoaDon.Value = Int32.Parse(HoaDon_Id);
            }
            SelectHoaDonTheoHoaDonID(HoaDon_Id);
        }
        public void RefreshForm()
        {
            DataTable LoadThongTinBenhNhanVienPhi = Model.HoaDondb.LoadThongTinBenhNhanVienPhi(BenhNhan_Id);
            if (LoadThongTinBenhNhanVienPhi.Rows.Count > 0)
            {
                txtMaYTe.Text = LoadThongTinBenhNhanVienPhi.Rows[0]["MaYTe"].ToString();
                MaYTe = LoadThongTinBenhNhanVienPhi.Rows[0]["MaYTe"].ToString();
                SoVaoVien = LoadThongTinBenhNhanVienPhi.Rows[0]["SoVaoVien"].ToString();
                txtHoTen.Text = LoadThongTinBenhNhanVienPhi.Rows[0]["TenBenhNhan"].ToString();
                txtTuoi.Text = LoadThongTinBenhNhanVienPhi.Rows[0]["Tuoi"].ToString();
                txtNamSinh.Text = LoadThongTinBenhNhanVienPhi.Rows[0]["NamSinh"].ToString();
                txtGioiTinh.Text = LoadThongTinBenhNhanVienPhi.Rows[0]["GioiTinh"].ToString();
                txtSoDienThoai.Text = LoadThongTinBenhNhanVienPhi.Rows[0]["SoDienThoai"].ToString();
                txtNgayHoanTatKham.Text = LoadThongTinBenhNhanVienPhi.Rows[0]["NgayHoanTatKham"].ToString();
                BenhNhan_Id = LoadThongTinBenhNhanVienPhi.Rows[0]["BenhNhan_Id"].ToString();
            }
            LoadHoaDonBenhNhan();
            txtMaYTe.Focus();
            DataTable LoadDanhSachDichVuChuaDongTienBenhNhanVienPhi = Model.HoaDondb.LoadDanhSachDichVuChuaDongTienBenhNhanVienPhi(BenhNhan_Id);
            gridDichVu.DataSource = LoadDanhSachDichVuChuaDongTienBenhNhanVienPhi;
        }
        public void Hien()
        {
            //txtMaYTe.Enabled = true;
            txtHoTen.Enabled = true;
            txtGioiTinh.Enabled = true;
            txtNamSinh.Enabled = true;
            txtTuoi.Enabled = true;
            txtSoDienThoai.Enabled = true;
            txtNgayHoanTatKham.Enabled = true;
            pnHinhThucThanhToan.Enabled = true;
            pnMaHoaDon.Enabled = true;
            pnThoiGianPhatSinh.Enabled = true;
            //pnSoHoaDon.Enabled = true;
            btn_S.Enabled = true;
            txtGiaTriHoaDon.Enabled = true;
            txtMaSoThue.Enabled = true;
            txtTenDonVi.Enabled = true;
            txtGiamGia.Enabled = true;
            cbTiLe.Enabled = true;
        }
        public void An()
        {
            //txtMaYTe.Enabled = false;
            txtHoTen.Enabled = false;
            txtGioiTinh.Enabled = false;
            txtNamSinh.Enabled = false;
            txtTuoi.Enabled = false;
            txtSoDienThoai.Enabled = false;
            txtNgayHoanTatKham.Enabled = false;
            txtMaSoThue.Enabled = false;
            txtTenDonVi.Enabled = false;
            pnHinhThucThanhToan.Enabled = false;
            pnMaHoaDon.Enabled = false;
            pnThoiGianPhatSinh.Enabled = false;
            //pnSoHoaDon.Enabled = false;
            txtGiaTriHoaDon.Enabled = false;
            txtGiamGia.Enabled = false;
            cbTiLe.Enabled = false;
        }
        public void Reset()
        {
            txtMaYTe.Text = "";
            txtHoTen.Text = "";
            txtGioiTinh.Text = "";
            txtNamSinh.Text = "";
            txtTuoi.Text = "";
            txtSoDienThoai.Text = "";
            txtNgayHoanTatKham.Text = "";
            txtGiaTriHoaDon.Text = "";
            txtMaSoThue.Text = "";
            txtTenDonVi.Text = "";
            cbbHinhThucThanhToan.Text = "";
            cbbMaHoaDon.Text = "";
            cbbSoHoaDon.Text = "";
            txtThoiGianPhatSinh.Value = DateTime.Now;
            gridDichVu.DataSource = null;
            cbPhieuThu.Checked = false;
            cbHuyHoaDon.Checked = false;
            cbHoanTra.Checked = false;
            txtGiamGia.Text = "";
            cbTiLe.Checked = false;
        }

        private void cbbSoHoaDon_ValueChanged(object sender, EventArgs e)
        {
            if (cbbSoHoaDon.Text != "")
            {
                SelectHoaDonTheoHoaDonID(cbbSoHoaDon.Value.ToString());
                DataTable dtResult = SoHoaDon.Select("HoaDon_Id = " + cbbSoHoaDon.Value.ToString()).CopyToDataTable();
                DateTime enteredDate = DateTime.Parse(dtResult.Rows[0]["NgayPhatSinh"].ToString());
                if (enteredDate.Date == DateTime.Now.Date)
                {
                    if (dtResult.Rows[0]["HuyHoaDon"].ToString() == "0")
                    {
                        btnHuyHoaDon.Enabled = true;
                    }
                    else { btnHuyHoaDon.Enabled = false; }
                    btnHoanTra.Enabled = false;
                }
                else
                {
                    btnHuyHoaDon.Enabled = false;
                    if (dtResult.Rows[0]["HoanTra"].ToString() == "0")
                    {
                        btnHoanTra.Enabled = true;
                    }
                    else { btnHoanTra.Enabled = false; }
                }
                //
                if (dtResult.Rows[0]["HuyHoaDon"].ToString() == "0" && dtResult.Rows[0]["HoanTra"].ToString() == "0")
                {
                    cbPhieuThu.Checked = true;
                    cbHuyHoaDon.Checked = false;
                    cbHoanTra.Checked = false;
                }
                else if (dtResult.Rows[0]["HuyHoaDon"].ToString() == "1" && dtResult.Rows[0]["HoanTra"].ToString() == "0")
                {
                    cbPhieuThu.Checked = false;
                    cbHuyHoaDon.Checked = true;
                    cbHoanTra.Checked = false;
                }
                else
                {
                    cbPhieuThu.Checked = false;
                    cbHuyHoaDon.Checked = false;
                    cbHoanTra.Checked = true;
                }
                btnIn.Enabled = true;
                btnXem.Enabled = true;
            }
        }

        private void txtMaYTe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (txtMaYTe.Text != "")
                {
                    MaYTe = "N'" + txtMaYTe.Text + "'";
                    DataTable LoadBenhNhan_Id_MaYTe = Model.HoaDondb.LoadBenhNhan_Id_MaYTe(MaYTe);
                    if (LoadBenhNhan_Id_MaYTe != null)
                    {
                        if(LoadBenhNhan_Id_MaYTe.Rows.Count > 0)
                        {
                            btnThem.Enabled = true;
                            btnBoQua.Enabled = false;
                            btnLuu.Enabled = false;
                            btnHuyHoaDon.Enabled = false;
                            btnHoanTra.Enabled = false;
                            btnXem.Enabled = false;
                            btnIn.Enabled = false;
                            btnTimKiem.Enabled = true;
                            An();
                            BenhNhan_Id = "";
                            TenBenhNhan = "";
                            TiepNhan_Id = "";
                            Reset();
                            MaYTe = ""; SoVaoVien = "";
                            txtMaYTe.Focus();
                            BenhNhan_Id = LoadBenhNhan_Id_MaYTe.Rows[0]["BenhNhan_Id"].ToString();
                            RefreshForm();
                        }
                        else
                        {
                            BenhNhan_Id = "";
                            alertControl1.Show(this, "Thông báo", "Chưa nhập mã y tế hoặc mã y tế không tồn tại!", "");
                        }
                    }
                    else
                    {
                        BenhNhan_Id = "";
                        alertControl1.Show(this, "Thông báo", "Chưa nhập mã y tế hoặc mã y tế không tồn tại!", "");
                    }
                }
                else
                {
                    BenhNhan_Id = "";
                    alertControl1.Show(this, "Thông báo", "Chưa nhập mã y tế hoặc mã y tế không tồn tại!", "");
                }
                if (e.KeyCode == Keys.Tab && e.Shift)
                {
                    MoveFocusToPreviousTextbox();
                    e.SuppressKeyPress = true;
                }
            }
        }

        private void guna2TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar) || e.KeyChar == '-' || e.KeyChar == '.'))
            {
                e.Handled = true;
            }
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
    }
}