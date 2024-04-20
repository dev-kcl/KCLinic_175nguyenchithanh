using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QRCoder;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
using DevExpress.XtraGrid.Views.Grid;

namespace KClinic2._1.View.TiepNhan
{
    public partial class TiepNhanTheThanhVien : DevExpress.XtraEditors.XtraForm
    {
        public string autoClickDichVu = System.Configuration.ConfigurationManager.AppSettings["autoClickDichVu_TiepNhan"];

        public string The_Id = "";
        public string BenhNhan_Id;
        public string TenBenhNhan;
        public string TiepNhan_Id;
        public string ThaoTac;
        public string CLSYeuCau_Id;
        public string CLSYeuCauCha_Id;

        public string DangKy_Id;

        public string MaYTe = "";
        public string SoVaoVien = "";

        string CMND = "";
        string BHYT = "";

        DataTable Dm_DichVu;
        DataTable Dm_NhomBenh;
        DataTable BacSiChiDinh;
        DataTable DoiTuong;
        DataTable PhongBan;
        DataTable PhongTuVan;
        DataTable DM_NVGioiThieu;

        public TiepNhanTheThanhVien()
        {
            InitializeComponent();
        }

        private void TiepNhanTheThanhVien_Load(object sender, EventArgs e)
        {
            TiepNhan_Id = "";
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
            this.KeyPreview = true;
        }

        void getdata()
        {
            DataTable GioiTinh = Model.DbTiepNhan.GioiTinh();
            cbbGioiTinh.DataSource = GioiTinh;
            cbbGioiTinh.DisplayMember = "GioiTinh";
            cbbGioiTinh.ValueMember = "GioiTinh_id";

            BacSiChiDinh = Model.DbTiepNhan.BacSiChiDinh();
            cbbNhanVien.DataSource = BacSiChiDinh;
            cbbNhanVien.DisplayMember = "FieldName";
            cbbNhanVien.ValueMember = "FieldCode";

            Dm_DichVu = Model.DbTiepNhan.Dm_DichVu();
            cbbDV.DataSource = Dm_DichVu;
            cbbDV.ValueMember = "Dich_Id";
            cbbDV.DisplayMember = "TenDichVu";

            Dm_NhomBenh = Model.DbTiepNhan.Dm_NhomBenh();
            cbbNhomBenh.DataSource = Dm_NhomBenh;
            cbbNhomBenh.ValueMember = "NhomBenh_Id";
            cbbNhomBenh.DisplayMember = "TenNhomBenh";

            DoiTuong = Model.DbTiepNhan.LayDMDoiTuong();
            cbbDoiTuong.DataSource = DoiTuong;
            cbbDoiTuong.ValueMember = "FieldCode";
            cbbDoiTuong.DisplayMember = "FieldName";
            cbbDoiTuong.Value = 1;

            PhongTuVan = Model.DbTiepNhan.CbbPhongTuVan();
            CbbPTuVan.DataSource = PhongTuVan;
            CbbPTuVan.ValueMember = "FieldCode";
            CbbPTuVan.DisplayMember = "FieldName";
            CbbPTuVan.Value = 4;

            DM_NVGioiThieu = Model.dbXetNghiem.KTVThucHien();
            cbbNVGioiThieu.DataSource = DM_NVGioiThieu;
            cbbNVGioiThieu.ValueMember = "FieldCode";
            cbbNVGioiThieu.DisplayMember = "FieldName";
        }

        private void TiepNhanTheThanhVien_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Rectangle rect = new Rectangle(cbbDV.Location.X, cbbDV.Location.Y, cbbDV.ClientSize.Width, cbbDV.ClientSize.Height);
            rect.Inflate(10, 10); // border thickness
            System.Windows.Forms.ControlPaint.DrawBorder(e.Graphics, rect, Color.Red, ButtonBorderStyle.Solid);
        }

        public void LoadThongTinBenhNhanDaTiepNhanButton()
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

        public void LoadThongTinBenhNhanDaTiepNhan_The()
        {
            DataTable LoadThongTinBenhNhanDaTiepNhan_The = Model.DbTiepNhan.LoadThongTinBenhNhanDaTiepNhan_The(TiepNhan_Id);
            if (LoadThongTinBenhNhanDaTiepNhan_The.Rows.Count > 0)
            {
                txtMaYTe.Text = LoadThongTinBenhNhanDaTiepNhan_The.Rows[0]["MaYTe"].ToString();
                MaYTe = LoadThongTinBenhNhanDaTiepNhan_The.Rows[0]["MaYTe"].ToString();
                SoVaoVien = LoadThongTinBenhNhanDaTiepNhan_The.Rows[0]["SoVaoVien"].ToString();
                txtHoTen.Text = LoadThongTinBenhNhanDaTiepNhan_The.Rows[0]["TenBenhNhan"].ToString();
                string GioiTinh = LoadThongTinBenhNhanDaTiepNhan_The.Rows[0]["GioiTinh"].ToString();
                if (!String.IsNullOrEmpty(GioiTinh))
                {
                    cbbGioiTinh.Value = Int32.Parse(GioiTinh);
                }
                txtNamSinh.Text = LoadThongTinBenhNhanDaTiepNhan_The.Rows[0]["NamSinh"].ToString();
                txtSoDienThoai.Text = LoadThongTinBenhNhanDaTiepNhan_The.Rows[0]["SoDienThoai"].ToString();
                txtDiaChi.Text = LoadThongTinBenhNhanDaTiepNhan_The.Rows[0]["DiaChiChiTiet"].ToString();
                string NgaySinh = LoadThongTinBenhNhanDaTiepNhan_The.Rows[0]["NgaySinh"].ToString();
                if (!String.IsNullOrEmpty(NgaySinh))
                {
                    DateTime enteredDate = DateTime.Parse(NgaySinh);
                    txtNgaySinh.Value = enteredDate;
                }
                string DoiTuong_Id = LoadThongTinBenhNhanDaTiepNhan_The.Rows[0]["DoiTuong_Id"].ToString();
                if (!String.IsNullOrEmpty(DoiTuong_Id))
                {
                    cbbDoiTuong.Value = Int32.Parse(DoiTuong_Id);
                }

                string NguoiTiepNhan = LoadThongTinBenhNhanDaTiepNhan_The.Rows[0]["NguoiTiepNhan_Id"].ToString();
                if (!String.IsNullOrEmpty(NguoiTiepNhan))
                {
                    cbbNhanVien.Value = Int32.Parse(NguoiTiepNhan);
                }
                BenhNhan_Id = LoadThongTinBenhNhanDaTiepNhan_The.Rows[0]["BenhNhan_Id"].ToString();
                TiepNhan_Id = LoadThongTinBenhNhanDaTiepNhan_The.Rows[0]["TiepNhan_Id"].ToString();
                string ThoiGianTiepNhan = LoadThongTinBenhNhanDaTiepNhan_The.Rows[0]["ThoiGianTiepNhan"].ToString();
                if (!String.IsNullOrEmpty(ThoiGianTiepNhan))
                {
                    DateTime enteredDate = DateTime.Parse(ThoiGianTiepNhan);
                    txtThoiGianTiepNhan.Value = enteredDate;
                }
                txtZaloID.Text = LoadThongTinBenhNhanDaTiepNhan_The.Rows[0]["Zalo_Id"].ToString();
                CMND = LoadThongTinBenhNhanDaTiepNhan_The.Rows[0]["CMND"].ToString();
                BHYT = LoadThongTinBenhNhanDaTiepNhan_The.Rows[0]["BHYT"].ToString();

                string NVGioiThieu = LoadThongTinBenhNhanDaTiepNhan_The.Rows[0]["NhanVienGioiThieu_Id"].ToString();
                if (!String.IsNullOrEmpty(NVGioiThieu))
                {
                    cbbNVGioiThieu.Value = Int32.Parse(NVGioiThieu);
                }
                else
                {
                    cbbNVGioiThieu.Text = "";
                }

                The_Id = LoadThongTinBenhNhanDaTiepNhan_The.Rows[0]["The_Id"].ToString();
                txtSoThe.Text = LoadThongTinBenhNhanDaTiepNhan_The.Rows[0]["SoThe"].ToString();

                if (!string.IsNullOrEmpty(The_Id) || The_Id != "")
                {
                    LoadThongTinTrongTheTheoId(The_Id);
                }
            }

            DataTable ThemClsYeuCauVaoPhieuDangNhap = Model.DbTiepNhan.ThemClsYeuCauVaoPhieuDangNhap(Login.PhienDangNhap_Id, TiepNhan_Id);
            DataTable SelectClsyeucauPhienDangNhap = Model.DbTiepNhan.SelectClsyeucauPhienDangNhap(Login.PhienDangNhap_Id);
            gridDichVu.DataSource = SelectClsyeucauPhienDangNhap;

            gettongtien();
        }
        public void RefreshForm()
        {
            DataTable LoadThongTinBenhNhan_The = Model.DbTiepNhan.LoadThongTinBenhNhan_The(BenhNhan_Id);
            if (LoadThongTinBenhNhan_The.Rows.Count > 0)
            {
                txtMaYTe.Text = LoadThongTinBenhNhan_The.Rows[0]["MaYTe"].ToString();
                MaYTe = LoadThongTinBenhNhan_The.Rows[0]["MaYTe"].ToString();
                SoVaoVien = LoadThongTinBenhNhan_The.Rows[0]["SoVaoVien"].ToString();
                txtHoTen.Text = LoadThongTinBenhNhan_The.Rows[0]["TenBenhNhan"].ToString();
                string GioiTinh = LoadThongTinBenhNhan_The.Rows[0]["GioiTinh"].ToString();
                if (!String.IsNullOrEmpty(GioiTinh))
                {
                    cbbGioiTinh.Value = Int32.Parse(LoadThongTinBenhNhan_The.Rows[0]["GioiTinh"].ToString());
                }

                string NgaySinh = LoadThongTinBenhNhan_The.Rows[0]["NgaySinh"].ToString();
                if (!String.IsNullOrEmpty(NgaySinh))
                {
                    DateTime enteredDate = DateTime.Parse(NgaySinh);
                    txtNgaySinh.Value = enteredDate;
                }

                txtNamSinh.Text = LoadThongTinBenhNhan_The.Rows[0]["NamSinh"].ToString();
                txtSoDienThoai.Text = LoadThongTinBenhNhan_The.Rows[0]["SoDienThoai"].ToString();
                txtDiaChi.Text = LoadThongTinBenhNhan_The.Rows[0]["DiaChiChiTiet"].ToString();
                BenhNhan_Id = LoadThongTinBenhNhan_The.Rows[0]["BenhNhan_Id"].ToString();
                txtZaloID.Text = LoadThongTinBenhNhan_The.Rows[0]["Zalo_Id"].ToString();
                CMND = LoadThongTinBenhNhan_The.Rows[0]["CMND"].ToString();
                BHYT = LoadThongTinBenhNhan_The.Rows[0]["BHYT"].ToString();

                The_Id = LoadThongTinBenhNhan_The.Rows[0]["The_Id"].ToString();
                txtSoThe.Text = LoadThongTinBenhNhan_The.Rows[0]["SoThe"].ToString();

                string NgayHieuLuc = LoadThongTinBenhNhan_The.Rows[0]["NgayHieuLuc"].ToString();
                if (!String.IsNullOrEmpty(NgayHieuLuc))
                {
                    DateTime enteredDate = DateTime.Parse(NgayHieuLuc);
                    txtHieuLuc.Value = enteredDate;
                }

                //string NguoiGioiThieu = LoadThongTinBenhNhan_The.Rows[0]["NhanVienGioiThieu_Id"].ToString();
                //if (!String.IsNullOrEmpty(NguoiGioiThieu))
                //{
                //    cbbNVGioiThieu.Value = Int32.Parse(LoadThongTinBenhNhan_The.Rows[0]["NhanVienGioiThieu_Id"].ToString());
                //}

                if (!string.IsNullOrEmpty(The_Id) || The_Id != "")
                {
                    LoadThongTinTrongTheTheoId(The_Id);
                }

            }

            txtHoTen.Focus();
        }      

        public void Hien()
        {
            txtMaYTe.Enabled = true;
            txtHoTen.Enabled = true;
            pnGioiTinh.Enabled = true;
            txtNamSinh.Enabled = true;
            txtSoDienThoai.Enabled = true;
            txtDiaChi.Enabled = true;
            pnNhomBenh.Enabled = true;
            pnNhanVien.Enabled = true;
            pnThoiGianTiepNhan.Enabled = true;
            txtThoiGianTiepNhan.Enabled = true;
            pnDichVu.Enabled = true;
            btn_S.Enabled = true;
            btnThemNhomBenh.Enabled = true;
            btnChonDichVu.Enabled = true;
            btnXoaDichVu.Enabled = true;
            txtZaloID.Enabled = true;
            txtNgaySinh.Enabled = true;
            cbbDoiTuong.Enabled = true;
            CbbPTuVan.Enabled = true;

            cbbNVGioiThieu.Enabled = true;
            txtChietKhau.Enabled = true;
            cbbphongban.Enabled = true;
            gridDichVu_The.Enabled = true;
            txtSoThe.Enabled = true;
            txtHieuLuc.Enabled = false;
        }

        public void An()
        {
            txtMaYTe.Enabled = false;
            txtHoTen.Enabled = false;
            pnGioiTinh.Enabled = false;
            txtNamSinh.Enabled = false;
            txtSoDienThoai.Enabled = false;
            txtDiaChi.Enabled = false;
            pnNhomBenh.Enabled = false;
            pnDichVu.Enabled = false;
            pnNhanVien.Enabled = false;
            btn_S.Enabled = false;
            btnThemNhomBenh.Enabled = false;
            btnChonDichVu.Enabled = false;
            btnXoaDichVu.Enabled = false;
            txtZaloID.Enabled = false;
            txtNgaySinh.Enabled = false;
            cbbDoiTuong.Enabled = false;
            CbbPTuVan.Enabled = false;

            txtThoiGianTiepNhan.Enabled = false;
            cbbNVGioiThieu.Enabled = false;
            txtChietKhau.Enabled = false;
            cbbphongban.Enabled = false;
            gridDichVu_The.Enabled = false;
            txtSoThe.Enabled = false;
            txtHieuLuc.Enabled = false;
        }

        public void Reset()
        {
            txtMaYTe.Text = "";
            txtHoTen.Text = "";
            cbbGioiTinh.Text = "";
            txtNamSinh.Text = "";
            txtSoDienThoai.Text = "";
            txtDiaChi.Text = "";
            cbbNhomBenh.Text = "";
            cbbDV.Text = "";
            cbbNhanVien.Text = "";
            cbbNhomBenh.Text = "";
            txtZaloID.Text = "";
            CbbPTuVan.Text = "";
            txtThoiGianTiepNhan.Value = DateTime.Now;
            
            txtSoThe.Text = "";
            cbbNVGioiThieu.Text = "";

            DataTable HoanTatClsYeuCauPhienDangNhap = Model.DbTiepNhan.HoanTatClsYeuCauPhienDangNhap(Login.PhienDangNhap_Id);
            gridDichVu.DataSource = null;
            gridDichVu_The.DataSource = null;

            gettongtien();
        }

        private void cbbNhanVien_KeyDown(object sender, KeyEventArgs e)
        {
            string text = cbbNhanVien.Text;
            DataRow[] resultRow = BacSiChiDinh.Select("FieldName LIKE '%" + text + "%'");
            if (resultRow.Count() > 0)
            {
                DataTable dtResult = BacSiChiDinh.Select("FieldName LIKE '%" + text + "%'").CopyToDataTable();
                cbbNhanVien.DataSource = dtResult;
                cbbNhanVien.DroppedDown = true;
            }
            else
            {
                cbbNhanVien.DataSource = null;
                cbbNhanVien.DroppedDown = true;
            }
            MoveFocusToPreviousTextbox();
            e.SuppressKeyPress = true;
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
            BenhNhan_Id = "";
            DangKy_Id = "";
            TenBenhNhan = "";
            TiepNhan_Id = "";
            CLSYeuCau_Id = "";
            Reset();
            MaYTe = ""; SoVaoVien = ""; CMND = ""; BHYT = "";

            txtSoThe.Focus();
        }

        void AutoTinhMaYTe()
        {
            DataTable AutoTinhMaYTe = Model.DbTiepNhan.AutoTinhMaYTe(Login.MaBenhVien, Login.PhienDangNhap_Id, Login.User_Id);
            if (AutoTinhMaYTe != null)
            {
                if (AutoTinhMaYTe.Rows.Count > 0)
                {
                    txtMaYTe.Text = AutoTinhMaYTe.Rows[0]["MaYTe"].ToString();
                    MaYTe = AutoTinhMaYTe.Rows[0]["MaYTe"].ToString();
                    SoVaoVien = AutoTinhMaYTe.Rows[0]["SoVaoVien"].ToString();
                }
            }
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
            CLSYeuCau_Id = "";
            txtHoTen.Focus();
            //
            LoadThongTinBenhNhanDaTiepNhan_The();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtSoThe.Text.Trim() == "")
            {
                XtraMessageBox.Show("Thẻ thành viên không được để trống!", "Thông Báo");
                txtSoThe.Focus();
                return;
            }

            if (txtHoTen.Text == "")
            {
                XtraMessageBox.Show("Họ Tên không được để trống!", "Thông Báo");
                txtHoTen.Focus();
                return;
            }
            else if (txtNamSinh.Text == "")
            {
                XtraMessageBox.Show("Năm sinh không được để trống!", "Thông Báo");
                txtNamSinh.Focus();
                return;
            }
            if (cbbGioiTinh.SelectedItem == null)
            {
                XtraMessageBox.Show("Giới tính không được để trống!", "Thông Báo");
                cbbGioiTinh.Focus();
                return;
            }
            else
            {
                string Hoten = "N'" + txtHoTen.Text.Replace("'", "''") + "'";
                string GioiTinh = "null";
                if (cbbGioiTinh.SelectedItem != null) { GioiTinh = cbbGioiTinh.Value.ToString(); }
                string NamSinh = "'" + txtNamSinh.Text + "'";
                string SoDienThoai = "N'" + txtSoDienThoai.Text.Replace("'", "''") + "'";
                string DiaChi = "N'" + txtDiaChi.Text.Replace("'", "''") + "'";
                string NguoiTiepNhan = "null";
                if (cbbNhanVien.SelectedItem != null) { NguoiTiepNhan = cbbNhanVien.Value.ToString(); }
                string ThoiGianTiepNhan = "'" + txtThoiGianTiepNhan.Value.ToString("yyyyMMdd HH:mm:ss") + "'";
                string NgayTiepNhan = "'" + txtThoiGianTiepNhan.Value.ToString("yyyyMMdd") + "'";
                string ThangTiepNhan = "'" + txtThoiGianTiepNhan.Value.ToString("MM") + "'";
                string NamTiepNhan = "'" + txtThoiGianTiepNhan.Value.ToString("yyyy") + "'";
                string NgaySinh = "null";
                if (!string.IsNullOrEmpty(txtNgaySinh.Text)) { NgaySinh = "'" + txtNgaySinh.Value.ToString("yyyyMMdd") + "'"; }

                string DoiTuong_Id = "null";
                if (cbbDoiTuong.SelectedItem != null)
                {
                    DoiTuong_Id = cbbDoiTuong.Value.ToString();

                }

                string HopDong_Id = "null";

                string PhongTuVan_Id = "null";
                if (CbbPTuVan.SelectedItem != null)
                {
                    PhongTuVan_Id = CbbPTuVan.Value.ToString();
                }

                string NoiLamViec = "null";
                if (!String.IsNullOrEmpty(Login.PhongBan_Id))
                {
                    if (Login.PhongBan_Id != "0")
                    {
                        NoiLamViec = Login.PhongBan_Id;
                    }
                }

                string NguoiGioiThieu = "null";
                if (cbbNVGioiThieu.SelectedItem != null) { NguoiGioiThieu = cbbNVGioiThieu.Value.ToString(); }

                string Zalo_Id = "null";
                if (txtZaloID.Text != "") { Zalo_Id = "N'" + txtZaloID.Text.Replace("'", "''") + "'"; }

                string cMND = "null";
                if (!String.IsNullOrEmpty(CMND)) { cMND = CMND; }
                string bHYT = "null";
                if (!String.IsNullOrEmpty(BHYT)) { bHYT = BHYT; }

                AutoTinhMaYTe();

                if (ThaoTac == "Them")
                {
                    if (BenhNhan_Id != "")
                    {
                        DataTable UpdateBenhNhan = Model.DbTiepNhan.UpdateBenhNhan(
                              BenhNhan_Id
                            , MaYTe
                            , SoVaoVien
                            , Hoten
                            , GioiTinh
                            , NgaySinh
                            , NamSinh
                            , SoDienThoai
                            , cMND
                            , DiaChi
                            , "null"
                            , "null"
                            , "null"
                            , "null"
                            , "null"
                            , Login.User_Id
                            , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                            , "0"
                            , Zalo_Id
                            , bHYT
                            );
                        if (UpdateBenhNhan.Rows.Count > 0)
                        {
                            BenhNhan_Id = UpdateBenhNhan.Rows[0]["BenhNhan_Id"].ToString();
                            TenBenhNhan = UpdateBenhNhan.Rows[0]["TenBenhNhan"].ToString();
                        }
                        DataTable Insert_TiepNhan = Model.DbTiepNhan.Insert_TiepNhan(
                              "null"
                            , "null"
                            , "null"
                            , BenhNhan_Id
                            , NoiLamViec
                            , NguoiTiepNhan
                            , NgayTiepNhan
                            , ThoiGianTiepNhan
                            , NamTiepNhan
                            , ThangTiepNhan
                            , DiaChi
                            , "null"//GhiChu
                            , "null"
                            , Login.User_Id
                            , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                            , "null"
                            , "null"
                            , "0"
                            , DoiTuong_Id
                            , HopDong_Id
                            , PhongTuVan_Id
                            , The_Id
                            , NguoiGioiThieu
                            );
                        if (Insert_TiepNhan.Rows.Count > 0)
                        {
                            TiepNhan_Id = Insert_TiepNhan.Rows[0][0].ToString();

                            //
                            DataTable CheckClsYeuCauPhienDangNhap = Model.DbTiepNhan.CheckClsYeuCauPhienDangNhap(Login.PhienDangNhap_Id);
                            if (CheckClsYeuCauPhienDangNhap != null)
                            {
                                if (CheckClsYeuCauPhienDangNhap.Rows.Count > 0)
                                {
                                    int i1;
                                    for (i1 = 0; i1 < CheckClsYeuCauPhienDangNhap.Rows.Count; i1++)
                                    {
                                        if (CheckClsYeuCauPhienDangNhap.Rows[i1]["ThaoTac"].ToString() == "Them")
                                        {
                                            DataTable UpdateCLSYeuCau = Model.DbTiepNhan.UpdateCLSYeuCau(
                                                CheckClsYeuCauPhienDangNhap.Rows[i1]["CLSYeuCau_Id"].ToString()
                                                , TiepNhan_Id
                                                , BenhNhan_Id
                                                );
                                        }
                                        else
                                        {
                                            DataTable DeleteCLSYeuCau = Model.DbTiepNhan.DeleteCLSYeuCau(
                                                CheckClsYeuCauPhienDangNhap.Rows[i1]["CLSYeuCau_Id"].ToString()
                                                , Login.User_Id
                                                );
                                        }
                                    }
                                }
                            }
                            DataTable HoanTatClsYeuCauPhienDangNhap = Model.DbTiepNhan.HoanTatClsYeuCauPhienDangNhap(Login.PhienDangNhap_Id);
                            //
                            LoadThongTinBenhNhanDaTiepNhan_The();
                        }

                        //
                        alertControl1.Show(this, "Thông báo", "Đã thêm thành công bệnh nhân " + TenBenhNhan, "");
                    }
                    else
                    {
                        DataTable InsertBenhNhan = Model.DbTiepNhan.InsertBenhNhan(
                             MaYTe
                            , SoVaoVien
                            , Hoten
                            , GioiTinh
                            , NgaySinh
                            , NamSinh
                            , SoDienThoai
                            , cMND
                            , DiaChi
                            , "null"
                            , "null"
                            , "null"
                            , Login.User_Id
                            , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                            , "null"
                            , "null"
                            , "0"
                            , Zalo_Id
                            , bHYT
                            );
                        if (InsertBenhNhan.Rows.Count > 0)
                        {
                            BenhNhan_Id = InsertBenhNhan.Rows[0]["BenhNhan_Id"].ToString();
                            TenBenhNhan = InsertBenhNhan.Rows[0]["TenBenhNhan"].ToString();
                        }
                        DataTable Insert_TiepNhan = Model.DbTiepNhan.Insert_TiepNhan(
                              "null"
                            , "null"
                            , "null"
                            , BenhNhan_Id
                            , NoiLamViec
                            , NguoiTiepNhan
                            , NgayTiepNhan
                            , ThoiGianTiepNhan
                            , NamTiepNhan
                            , ThangTiepNhan
                            , DiaChi
                            , "null" //GhiChu
                            , "null"
                            , Login.User_Id
                            , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                            , "null"
                            , "null"
                            , "0"
                            , DoiTuong_Id
                            , HopDong_Id
                            , PhongTuVan_Id
                            , The_Id
                            , NguoiGioiThieu
                            );
                        if (Insert_TiepNhan.Rows.Count > 0)
                        {
                            TiepNhan_Id = Insert_TiepNhan.Rows[0][0].ToString();
                            //
                            //insert clsyeucau
                            DataTable CheckClsYeuCauPhienDangNhap = Model.DbTiepNhan.CheckClsYeuCauPhienDangNhap(Login.PhienDangNhap_Id);
                            if (CheckClsYeuCauPhienDangNhap != null)
                            {
                                if (CheckClsYeuCauPhienDangNhap.Rows.Count > 0)
                                {
                                    int i1;
                                    for (i1 = 0; i1 < CheckClsYeuCauPhienDangNhap.Rows.Count; i1++)
                                    {
                                        if (CheckClsYeuCauPhienDangNhap.Rows[i1]["ThaoTac"].ToString() == "Them")
                                        {
                                            DataTable UpdateCLSYeuCau = Model.DbTiepNhan.UpdateCLSYeuCau(
                                                CheckClsYeuCauPhienDangNhap.Rows[i1]["CLSYeuCau_Id"].ToString()
                                                , TiepNhan_Id
                                                , BenhNhan_Id
                                                );
                                        }
                                        else
                                        {
                                            DataTable DeleteCLSYeuCau = Model.DbTiepNhan.DeleteCLSYeuCau(
                                                CheckClsYeuCauPhienDangNhap.Rows[i1]["CLSYeuCau_Id"].ToString()
                                                , Login.User_Id
                                                );
                                        }
                                    }
                                }
                            }
                            DataTable HoanTatClsYeuCauPhienDangNhap = Model.DbTiepNhan.HoanTatClsYeuCauPhienDangNhap(Login.PhienDangNhap_Id);
                            //
                            LoadThongTinBenhNhanDaTiepNhan_The();
                        }

                        //
                        alertControl1.Show(this, "Thông báo", "Đã thêm thành công bệnh nhân " + TenBenhNhan, "");
                    }
                    //Chèn vào bảng đăng ký online
                    if (DangKy_Id != "")
                    {
                        DataTable UpdateThongTinDangKy = Model.DbTiepNhan.UpdateThongTinDangKy(
                            DangKy_Id
                            , TiepNhan_Id
                            );
                    }
                }
                if (ThaoTac == "Sua")
                {
                    DataTable UpdateBenhNhan = Model.DbTiepNhan.UpdateBenhNhan(
                              BenhNhan_Id
                            , MaYTe
                            , SoVaoVien
                            , Hoten
                            , GioiTinh
                            , NgaySinh //NgaySinh
                            , NamSinh
                            , SoDienThoai
                            , cMND
                            , DiaChi
                            , "null"
                            , "null"
                            , "null"
                            , "null"
                            , "null"
                            , Login.User_Id
                            , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                            , "0"
                            , Zalo_Id
                            , bHYT
                            );
                    if (UpdateBenhNhan.Rows.Count > 0)
                    {
                        BenhNhan_Id = UpdateBenhNhan.Rows[0]["BenhNhan_Id"].ToString();
                        TenBenhNhan = UpdateBenhNhan.Rows[0]["TenBenhNhan"].ToString();
                    }
                    DataTable Update_TiepNhan = Model.DbTiepNhan.Update_TiepNhan(
                             TiepNhan_Id
                            , "null"
                            , "null"
                            , "null"
                            , BenhNhan_Id
                            , NoiLamViec
                            , NguoiTiepNhan
                            , NgayTiepNhan
                            , ThoiGianTiepNhan
                            , NamTiepNhan
                            , ThangTiepNhan
                            , DiaChi
                            , "null" //GhiChu
                            , "null"
                            , "null"
                            , "null"
                            , Login.User_Id
                            , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                            , "0"
                            , DoiTuong_Id
                            , HopDong_Id
                            , PhongTuVan_Id
                            , The_Id
                            , NguoiGioiThieu
                            );
                    if (Update_TiepNhan.Rows.Count > 0)
                    {
                        TiepNhan_Id = Update_TiepNhan.Rows[0][0].ToString();
                        //
                        //update clsyeucau
                        DataTable CheckClsYeuCauPhienDangNhap = Model.DbTiepNhan.CheckClsYeuCauPhienDangNhap(Login.PhienDangNhap_Id);
                        if (CheckClsYeuCauPhienDangNhap != null)
                        {
                            if (CheckClsYeuCauPhienDangNhap.Rows.Count > 0)
                            {
                                int i1;
                                for (i1 = 0; i1 < CheckClsYeuCauPhienDangNhap.Rows.Count; i1++)
                                {
                                    if (CheckClsYeuCauPhienDangNhap.Rows[i1]["ThaoTac"].ToString() == "Them")
                                    {
                                        DataTable UpdateCLSYeuCau = Model.DbTiepNhan.UpdateCLSYeuCau(
                                            CheckClsYeuCauPhienDangNhap.Rows[i1]["CLSYeuCau_Id"].ToString()
                                            , TiepNhan_Id
                                            , BenhNhan_Id
                                            );
                                    }
                                    else
                                    {
                                        DataTable DeleteCLSYeuCau = Model.DbTiepNhan.DeleteCLSYeuCau(
                                            CheckClsYeuCauPhienDangNhap.Rows[i1]["CLSYeuCau_Id"].ToString()
                                            , Login.User_Id
                                            );
                                    }
                                }
                            }
                        }
                        DataTable HoanTatClsYeuCauPhienDangNhap = Model.DbTiepNhan.HoanTatClsYeuCauPhienDangNhap(Login.PhienDangNhap_Id);
                        //
                        LoadThongTinBenhNhanDaTiepNhan_The();
                    }
                    //
                    alertControl1.Show(this, "Thông báo", "Đã sửa thành công bệnh nhân " + TenBenhNhan, "");
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
            DataTable HoanTatClsYeuCauPhienDangNhap = Model.DbTiepNhan.HoanTatClsYeuCauPhienDangNhap(Login.PhienDangNhap_Id);
            An();
            if (ThaoTac == "Them")
            {
                btnThem.Enabled = true;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                BenhNhan_Id = "";
                TiepNhan_Id = "";
                DangKy_Id = "";
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
                    DataTable CheckDaChiDinhDichVu = Model.DbTiepNhan.CheckDaChiDinhDichVu(TiepNhan_Id);
                    if (CheckDaChiDinhDichVu != null)
                    {
                        if (Int32.Parse(CheckDaChiDinhDichVu.Rows[0]["SoLuong"].ToString()) == 0)
                        {
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
                            DataTable Delete = Model.DbTiepNhan.DeleteTiepNhan(TiepNhan_Id, nguoicapnhat);
                            alertControl1.Show(this, "Thông báo", "Đã xóa thành công tiếp nhận bệnh nhân " + Delete.Rows[0]["TenBenhNhan"].ToString(), "");
                            Reset();
                            TiepNhan_Id = "";
                            TenBenhNhan = "";
                            BenhNhan_Id = "";
                            DangKy_Id = "";
                        }
                        else
                        {
                            alertControl1.Show(this, "Thông báo", "Bệnh nhân này đã chỉ định dịch vu, không thể xóa! Vui lòng kiểm tra lại", "");
                        }
                    }
                    else
                    {
                        alertControl1.Show(this, "Thông báo", "Bệnh nhân này đã chỉ định dịch vu, không thể xóa! Vui lòng kiểm tra lại", "");
                    }
                    break;
                case DialogResult.No:
                    break;
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (TiepNhan_Id == "")
            {
                MessageBox.Show("Bạn chưa chọn Bệnh Nhân!");
            }
            else
            {
                DataTable table1 = Model.DbTiepNhan.PhieuChiDinhDichVu(TiepNhan_Id);
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

                            if (File.Exists(HinhAnhBarcode))
                            {
                                FileStream fs = new FileStream(HinhAnhBarcode, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                                Image = new byte[fs.Length];
                                fs.Read(Image, 0, Convert.ToInt32(fs.Length));
                                fs.Close();
                            }

                            DataTable SelectSettingTheoSettingCode2 = Model.db.SelectSettingTheoSettingCode("logo");
                            if (SelectSettingTheoSettingCode2 != null)
                            {
                                if (SelectSettingTheoSettingCode2.Rows.Count > 0)
                                {
                                    string Logo = SelectSettingTheoSettingCode2.Rows[0]["NoiDung"].ToString();

                                    if (File.Exists(Logo))
                                    {
                                        FileStream fsLogo = new FileStream(Logo, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                                        ImageLogo = new byte[fsLogo.Length];
                                        fsLogo.Read(ImageLogo, 0, Convert.ToInt32(fsLogo.Length));
                                        fsLogo.Close();
                                    }
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
                string DuongDan = @"" + ShowDuongDan.Rows[0][0].ToString() + @"BC001_PhieuChiDinhDichVu.rpt";
                rptDoca.Load(DuongDan);
                rptDoca.SetDataSource(table1);
                rptDoca.PrintToPrinter(1, false, 0, 0);
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (TiepNhan_Id == "")
            {
                MessageBox.Show("Bạn chưa chọn Bệnh Nhân!");
            }
            else
            {
                View.HeThongBaoCao.PhieuChiDinh_The bc = new View.HeThongBaoCao.PhieuChiDinh_The(this);
                bc.Show();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            View.TiepNhan.TimKiemTiepNhan_The tc = new View.TiepNhan.TimKiemTiepNhan_The(this);
            tc.ShowDialog();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (TiepNhan_Id == "")
            {
                MessageBox.Show("Bạn chưa chọn Bệnh Nhân!");
            }
            else
            {
                LoadThongTinBenhNhanDaTiepNhanButton();
                LoadThongTinBenhNhanDaTiepNhan_The();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Reset();
            this.Close();
        }

        private void btn_S_Click(object sender, EventArgs e)
        {
            View.TiepNhan.TimKiemBenhNhan_The tc = new View.TiepNhan.TimKiemBenhNhan_The(this);
            tc.ShowDialog();
        }

        private void btnXoaDichVu_Click(object sender, EventArgs e)
        {
            DataTable CheckDichVuDaThucHien = Model.DbTiepNhan.CheckDichVuDaThucHien(CLSYeuCau_Id);
            if (CheckDichVuDaThucHien != null)
            {
                if (CheckDichVuDaThucHien.Rows[0]["TrangThai"].ToString() == "ChuaThucHien")
                {
                    DataTable Delete = Model.DbTiepNhan.Delete_ClsYeuCau_PhienDangNhap(CLSYeuCau_Id, Login.User_Id);

                    DataTable SelectClsyeucauPhienDangNhap = Model.DbTiepNhan.SelectClsyeucauPhienDangNhap(Login.PhienDangNhap_Id);
                    gridDichVu.DataSource = SelectClsyeucauPhienDangNhap;
                    gettongtien();
                    CLSYeuCau_Id = "";
                }
                else
                {
                    alertControl1.Show(this, "Thông báo", "Chưa chọn phiếu cần xóa!", "");
                }
            }
            else
            {
                alertControl1.Show(this, "Thông báo", "Chưa chọn phiếu cần xóa!", "");
            }
        }

        private void btnThemNhomBenh_Click(object sender, EventArgs e)
        {
            if (cbbNhomBenh.SelectedItem != null)
            {
                DataRowView typeItem = (DataRowView)cbbNhomBenh.SelectedItem;
                string NhomBenhId = typeItem.Row[0].ToString();

                DataTable CheckNhomBenh_DichVu = Model.DbTiepNhan.CheckNhomBenh_DichVu(NhomBenhId);
                if (CheckNhomBenh_DichVu != null)
                {
                    if (CheckNhomBenh_DichVu.Rows.Count > 0)
                    {
                        string ChietKhauPhanTram = "null";
                        string GiaTriChietKhau = "null";

                        for (int i = 0; i < CheckNhomBenh_DichVu.Rows.Count; i++)
                        {
                            if (txtChietKhau.Text.Trim() != "")
                            {
                                if (cbTiLe.Checked == true)
                                {
                                    ChietKhauPhanTram = txtChietKhau.Text.ToString().Replace(".", "").Replace(",", "");
                                    GiaTriChietKhau = ((Decimal.Parse(CheckNhomBenh_DichVu.Rows[i]["GiaDichVu"].ToString()) * Decimal.Parse(ChietKhauPhanTram)) / 100).ToString();
                                }
                                else
                                {
                                    GiaTriChietKhau = txtChietKhau.Text.ToString().Replace(".", "").Replace(",", "");
                                }
                            }

                            DataTable InsertCLSYeuCau = Model.DbTiepNhan.InsertCLSYeuCau(
                                  "null"
                                , "'" + DateTime.Now.ToString("yyyyMMdd") + "'"
                                , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                                , "null"
                                , "null"
                                , CheckNhomBenh_DichVu.Rows[i]["Dich_Id"].ToString()
                                , "1"
                                , CheckNhomBenh_DichVu.Rows[i]["GiaDichVu"].ToString()
                                , ChietKhauPhanTram //ty le chiet khau
                                , GiaTriChietKhau //tien chiet khau
                                , "null"
                                , "1" //DuocPhepThucHien
                                , "ChuaThucHien"
                                , Login.User_Id
                                , Login.User_Id
                                , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                                , "null"
                                , "null"
                                , "0"
                                , "null"
                                , CheckNhomBenh_DichVu.Rows[i]["PhongBan_Id"].ToString()
                                );
                            if (InsertCLSYeuCau.Rows.Count > 0)
                            {
                                CLSYeuCau_Id = InsertCLSYeuCau.Rows[0][0].ToString();
                                CLSYeuCauCha_Id = InsertCLSYeuCau.Rows[0][0].ToString();
                            }
                            DataTable InsertCLSYeuCau_PhieuDangNhap = Model.DbTiepNhan.InsertCLSYeuCau_PhieuDangNhap(
                                Login.PhienDangNhap_Id
                                , CLSYeuCau_Id
                                , CheckNhomBenh_DichVu.Rows[i]["Dich_Id"].ToString()
                                , "N'" + "Them" + "'"
                                );
                            //thêm phiếu yêu cầu cho dịch vụ cấp dưới
                            DataTable CheckDichVuCapDuoi = Model.DbTiepNhan.CheckDichVuCapDuoi(CheckNhomBenh_DichVu.Rows[i]["Dich_Id"].ToString());
                            if (CheckDichVuCapDuoi != null)
                            {
                                if (CheckDichVuCapDuoi.Rows.Count > 0)
                                {
                                    for (int j = 0; j < CheckDichVuCapDuoi.Rows.Count; j++)
                                    {
                                        DataTable InsertCLSYeuCauCapDuoi = Model.DbTiepNhan.InsertCLSYeuCau(
                                              "null"
                                            , "'" + DateTime.Now.ToString("yyyyMMdd") + "'"
                                            , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                                            , "null"
                                            , "null"
                                            , CheckDichVuCapDuoi.Rows[j]["Dich_Id"].ToString()
                                            , "1"
                                            , "0" //set gia dịch vụ = 0
                                            , "null" //ty le chiet khau
                                            , "null" //tien chiet khau
                                            , "null"
                                            , "1"
                                            , "ChuaThucHien"
                                            , Login.User_Id
                                            , Login.User_Id
                                            , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                                            , "null"
                                            , "null"
                                            , "0"
                                            , CLSYeuCauCha_Id
                                            , CheckNhomBenh_DichVu.Rows[i]["PhongBan_Id"].ToString()
                                            );
                                        if (InsertCLSYeuCauCapDuoi.Rows.Count > 0)
                                        {
                                            CLSYeuCau_Id = InsertCLSYeuCauCapDuoi.Rows[0][0].ToString();
                                        }
                                        DataTable InsertCLSYeuCau_PhieuDangNhapCapDuoi = Model.DbTiepNhan.InsertCLSYeuCau_PhieuDangNhap(
                                            Login.PhienDangNhap_Id
                                            , CLSYeuCau_Id
                                            , CheckDichVuCapDuoi.Rows[j]["Dich_Id"].ToString()
                                            , "N'" + "Them" + "'"
                                            );
                                    }
                                }
                            }
                        }
                        DataTable SelectClsyeucauPhienDangNhap = Model.DbTiepNhan.SelectClsyeucauPhienDangNhap(Login.PhienDangNhap_Id);
                        gridDichVu.DataSource = SelectClsyeucauPhienDangNhap;
                        gettongtien();
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("Chưa chọn Nhóm bệnh!");
            }
        }

        private void btnChonDichVu_Click(object sender, EventArgs e)
        {
            if (cbbDV.SelectedItem != null)
            {
                DataRowView typeItem = (DataRowView)cbbDV.SelectedItem;
                string DichVuId = typeItem.Row[0].ToString();

                string Phongban_id = Login.PhongBan_Id;
                DataRowView typeItem1 = (DataRowView)cbbphongban.SelectedItem;
                if (typeItem1 != null)
                {
                    Phongban_id = typeItem1.Row[0].ToString();
                }

                DataTable Dm_DichVu_DonGia = Model.DbTiepNhan.Dm_DichVu_DonGia(DichVuId);
                string GiaDichVu = Dm_DichVu_DonGia.Rows[0]["GiaDichVu"].ToString();

                string ChietKhauPhanTram = "null";
                string GiaTriChietKhau = "null";

                if (txtChietKhau.Text.Trim() != "")
                {
                    if (cbTiLe.Checked == true)
                    {
                        ChietKhauPhanTram = txtChietKhau.Text.ToString().Replace(".", "").Replace(",", "");
                        GiaTriChietKhau = ((Decimal.Parse(GiaDichVu) * Decimal.Parse(ChietKhauPhanTram)) / 100).ToString();
                    }
                    else
                    {
                        GiaTriChietKhau = txtChietKhau.Text.ToString().Replace(".", "").Replace(",", "");
                    }
                }

                //
                DataTable InsertCLSYeuCau = Model.DbTiepNhan.InsertCLSYeuCau(
                                  "null"
                                , "'" + DateTime.Now.ToString("yyyyMMdd") + "'"
                                , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                                , "null"
                                , "null"
                                , DichVuId
                                , "1"
                                , GiaDichVu
                                , ChietKhauPhanTram
                                , GiaTriChietKhau
                                , "null"
                                , "1" //DuocPhepThucHien
                                , "ChuaThucHien"
                                , Login.User_Id
                                , Login.User_Id
                                , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                                , "null"
                                , "null"
                                , "0"
                                , "null"
                                , Phongban_id
                                );
                if (InsertCLSYeuCau.Rows.Count > 0)
                {
                    CLSYeuCau_Id = InsertCLSYeuCau.Rows[0][0].ToString();
                    CLSYeuCauCha_Id = InsertCLSYeuCau.Rows[0][0].ToString();
                }
                DataTable InsertCLSYeuCau_PhieuDangNhap = Model.DbTiepNhan.InsertCLSYeuCau_PhieuDangNhap(
                    Login.PhienDangNhap_Id
                    , CLSYeuCau_Id
                    , DichVuId
                    , "N'" + "Them" + "'"
                    );
                //thêm phiếu yêu cầu cho dịch vụ cấp dưới
                DataTable CheckDichVuCapDuoi = Model.DbTiepNhan.CheckDichVuCapDuoi(DichVuId);
                if (CheckDichVuCapDuoi != null)
                {
                    if (CheckDichVuCapDuoi.Rows.Count > 0)
                    {
                        for (int j = 0; j < CheckDichVuCapDuoi.Rows.Count; j++)
                        {
                            DataTable InsertCLSYeuCauCapDuoi = Model.DbTiepNhan.InsertCLSYeuCau(
                                  "null"
                                , "'" + DateTime.Now.ToString("yyyyMMdd") + "'"
                                , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                                , "null"
                                , "null"
                                , CheckDichVuCapDuoi.Rows[j]["Dich_Id"].ToString()
                                , "1"
                                , "0" //set giá dịch vụ = 0
                                , "null" //ty le chiet khau
                                , "null" //tien chiet khau
                                , "null"
                                , "1" //DuocPhepThucHien
                                , "ChuaThucHien"
                                , Login.User_Id
                                , Login.User_Id
                                , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                                , "null"
                                , "null"
                                , "0"
                                , CLSYeuCauCha_Id
                                , Phongban_id
                                );
                            if (InsertCLSYeuCauCapDuoi.Rows.Count > 0)
                            {
                                CLSYeuCau_Id = InsertCLSYeuCauCapDuoi.Rows[0][0].ToString();
                            }
                            DataTable InsertCLSYeuCau_PhieuDangNhapCapDuoi = Model.DbTiepNhan.InsertCLSYeuCau_PhieuDangNhap(
                                Login.PhienDangNhap_Id
                                , CLSYeuCau_Id
                                , CheckDichVuCapDuoi.Rows[j]["Dich_Id"].ToString()
                                , "N'" + "Them" + "'"
                                );
                        }
                    }
                }
                //
                DataTable SelectClsyeucauPhienDangNhap = Model.DbTiepNhan.SelectClsyeucauPhienDangNhap(Login.PhienDangNhap_Id);
                gridDichVu.DataSource = SelectClsyeucauPhienDangNhap;
                gettongtien();
            }
            else
            {
                XtraMessageBox.Show("Chưa chọn Dịch vụ!", "Thông Báo");
            }
        }

        private void repositoryItemButtonEdit1_Click(object sender, EventArgs e)
        {
            string strNgayHieuLuc = txtHieuLuc.Value.ToString("yyyyMMdd");
            string strNgayHienTai = DateTime.Now.ToString("yyyyMMdd");

            if (strNgayHieuLuc.CompareTo(strNgayHienTai) < 0)
            {
                XtraMessageBox.Show("Thẻ đã hết hạn sử dụng. Vui lòng liên hệ nhân viên để được hỗ trợ!", "Thông Báo");
                return;
            }

            int SoLuongConLai = int.Parse(gridView2.GetFocusedRowCellValue("SoLuongConLai").ToString());
            
            if (SoLuongConLai <= 0)
            {
                XtraMessageBox.Show("Số lần sử dụng dịch vụ này của thẻ đã hết!", "Thông Báo");
                return;
            }

            
            string LoaiTheId = gridView2.GetFocusedRowCellValue("LoaiThe_Id").ToString();
            string _LoaiTheId = "null";
            if (LoaiTheId != "") { _LoaiTheId = "N'" + LoaiTheId.Replace("'", "''") + "'"; }

            string NhomBenhId = gridView2.GetFocusedRowCellValue("NhomBenh_Id").ToString();
            string _NhomBenhId = "null";
            if (NhomBenhId != "") { _NhomBenhId = "N'" + NhomBenhId.Replace("'", "''") + "'"; }

            DataTable CheckNhomBenh_DichVu = Model.DbTiepNhan.CheckNhomBenh_DichVu(NhomBenhId);
            if (CheckNhomBenh_DichVu != null)
            {
                if (CheckNhomBenh_DichVu.Rows.Count > 0)
                {
                    string ChietKhauPhanTram = "100";
                    string GiaTriChietKhau = "null";

                    for (int i = 0; i < CheckNhomBenh_DichVu.Rows.Count; i++)
                    {
                        GiaTriChietKhau = ((Decimal.Parse(CheckNhomBenh_DichVu.Rows[i]["GiaDichVu"].ToString()) * Decimal.Parse(ChietKhauPhanTram)) / 100).ToString();

                        DataTable InsertCLSYeuCau = Model.DbTiepNhan.InsertCLSYeuCau(
                              "null"
                            , "'" + DateTime.Now.ToString("yyyyMMdd") + "'"
                            , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                            , "null"
                            , "null"
                            , CheckNhomBenh_DichVu.Rows[i]["Dich_Id"].ToString()
                            , "1"
                            , CheckNhomBenh_DichVu.Rows[i]["GiaDichVu"].ToString()
                            , ChietKhauPhanTram //ty le chiet khau
                            , GiaTriChietKhau //tien chiet khau
                            , "null"
                            , "1" //DuocPhepThucHien
                            , "ChuaThucHien"
                            , Login.User_Id
                            , Login.User_Id
                            , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                            , "null"
                            , "null"
                            , "0"
                            , "null"
                            , CheckNhomBenh_DichVu.Rows[i]["PhongBan_Id"].ToString()
                            , The_Id
                            , _LoaiTheId
                            , _NhomBenhId
                            );
                        if (InsertCLSYeuCau.Rows.Count > 0)
                        {
                            CLSYeuCau_Id = InsertCLSYeuCau.Rows[0][0].ToString();
                            CLSYeuCauCha_Id = InsertCLSYeuCau.Rows[0][0].ToString();
                        }
                        DataTable InsertCLSYeuCau_PhieuDangNhap = Model.DbTiepNhan.InsertCLSYeuCau_PhieuDangNhap(
                            Login.PhienDangNhap_Id
                            , CLSYeuCau_Id
                            , CheckNhomBenh_DichVu.Rows[i]["Dich_Id"].ToString()
                            , "N'" + "Them" + "'"
                            );
                        //thêm phiếu yêu cầu cho dịch vụ cấp dưới
                        DataTable CheckDichVuCapDuoi = Model.DbTiepNhan.CheckDichVuCapDuoi(CheckNhomBenh_DichVu.Rows[i]["Dich_Id"].ToString());
                        if (CheckDichVuCapDuoi != null)
                        {
                            if (CheckDichVuCapDuoi.Rows.Count > 0)
                            {
                                for (int j = 0; j < CheckDichVuCapDuoi.Rows.Count; j++)
                                {
                                    DataTable InsertCLSYeuCauCapDuoi = Model.DbTiepNhan.InsertCLSYeuCau(
                                          "null"
                                        , "'" + DateTime.Now.ToString("yyyyMMdd") + "'"
                                        , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                                        , "null"
                                        , "null"
                                        , CheckDichVuCapDuoi.Rows[j]["Dich_Id"].ToString()
                                        , "1"
                                        , "0" //set gia dịch vụ = 0
                                        , "null" //ty le chiet khau
                                        , "null" //tien chiet khau
                                        , "null"
                                        , "1"
                                        , "ChuaThucHien"
                                        , Login.User_Id
                                        , Login.User_Id
                                        , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                                        , "null"
                                        , "null"
                                        , "0"
                                        , CLSYeuCauCha_Id
                                        , CheckNhomBenh_DichVu.Rows[i]["PhongBan_Id"].ToString()
                                        , The_Id
                                        , _LoaiTheId
                                        , _NhomBenhId
                                        );
                                    if (InsertCLSYeuCauCapDuoi.Rows.Count > 0)
                                    {
                                        CLSYeuCau_Id = InsertCLSYeuCauCapDuoi.Rows[0][0].ToString();
                                    }
                                    DataTable InsertCLSYeuCau_PhieuDangNhapCapDuoi = Model.DbTiepNhan.InsertCLSYeuCau_PhieuDangNhap(
                                        Login.PhienDangNhap_Id
                                        , CLSYeuCau_Id
                                        , CheckDichVuCapDuoi.Rows[j]["Dich_Id"].ToString()
                                        , "N'" + "Them" + "'"
                                        );
                                }
                            }
                        }
                    }
                    DataTable SelectClsyeucauPhienDangNhap = Model.DbTiepNhan.SelectClsyeucauPhienDangNhap(Login.PhienDangNhap_Id);
                    gridDichVu.DataSource = SelectClsyeucauPhienDangNhap;
                    gettongtien();
                }
            }
        }

        private void LoadThongTinTrongTheTheoId(string _The_Id)
        {
            //load the
            DataTable SelectDanhSachTheThanhVienTheoId = Model.dbTheThanhVien.SelectDanhSachTheThanhVienTheoId(_The_Id);

            if (SelectDanhSachTheThanhVienTheoId.Rows.Count == 0)
            {
                return;
            }

            txtSoThe.Text = SelectDanhSachTheThanhVienTheoId.Rows[0]["SoThe"].ToString();

            string _BenhNhan_Id = "null";
            if (BenhNhan_Id != "") { _BenhNhan_Id = "N'" + BenhNhan_Id.Replace("'", "''") + "'"; }

            //load thong tin trong the
            DataTable LoadThongTinTrongTheTheoId_TiepNhan = Model.DbTiepNhan.LoadThongTinTrongTheTheoId_TiepNhan(_The_Id, _BenhNhan_Id);
            if (LoadThongTinTrongTheTheoId_TiepNhan.Rows.Count > 0)
            {
                //load benh nhan
                txtMaYTe.Text = LoadThongTinTrongTheTheoId_TiepNhan.Rows[0]["MaYTe"].ToString();
                txtHoTen.Text = LoadThongTinTrongTheTheoId_TiepNhan.Rows[0]["TenBenhNhan"].ToString();
                string GioiTinh = LoadThongTinTrongTheTheoId_TiepNhan.Rows[0]["GioiTinh"].ToString();
                if (!String.IsNullOrEmpty(GioiTinh))
                {
                    cbbGioiTinh.Value = Int32.Parse(LoadThongTinTrongTheTheoId_TiepNhan.Rows[0]["GioiTinh"].ToString());
                }
                txtNamSinh.Text = LoadThongTinTrongTheTheoId_TiepNhan.Rows[0]["NamSinh"].ToString();
                txtSoDienThoai.Text = LoadThongTinTrongTheTheoId_TiepNhan.Rows[0]["SoDienThoai"].ToString();

                The_Id = LoadThongTinTrongTheTheoId_TiepNhan.Rows[0]["The_Id"].ToString();
                BenhNhan_Id = LoadThongTinTrongTheTheoId_TiepNhan.Rows[0]["BenhNhan_Id"].ToString();
            }

            //load dich vu
            gridDichVu_The.DataSource = LoadThongTinTrongTheTheoId_TiepNhan;

            for (int i = 0; i < gridView2.RowCount; i++)
            {
                if (gridView2.GetRowCellValue(i, "The_Id").ToString() == The_Id)
                {
                    gridView2.FocusedRowHandle = i;
                    gridView2.SelectRow(i);

                    break;
                }
                else
                {
                    continue;
                }
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

        private void txtMaYTe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                LoadThongTinBenhNhanTheoMaYTe_The();

                if (e.KeyCode == Keys.Tab && e.Shift)
                {
                    MoveFocusToPreviousTextbox();
                    e.SuppressKeyPress = true;
                }
            }
        }

        private void LoadThongTinBenhNhanTheoMaYTe_The()
        {
            if (txtMaYTe.Text == "")
            {
                XtraMessageBox.Show("Mã Y Tế Không tồn tại! Vui lòng kiểm tra lại.");
                return;
            }

            DataTable LoadThongTinBenhNhan_The = Model.DbTiepNhan.LoadThongTinBenhNhanTheoMaYTe_The(txtMaYTe.Text);
            if (LoadThongTinBenhNhan_The.Rows.Count > 0)
            {
                txtMaYTe.Text = LoadThongTinBenhNhan_The.Rows[0]["MaYTe"].ToString();
                MaYTe = LoadThongTinBenhNhan_The.Rows[0]["MaYTe"].ToString();
                SoVaoVien = LoadThongTinBenhNhan_The.Rows[0]["SoVaoVien"].ToString();
                txtHoTen.Text = LoadThongTinBenhNhan_The.Rows[0]["TenBenhNhan"].ToString();
                cbbGioiTinh.Value = Int32.Parse(LoadThongTinBenhNhan_The.Rows[0]["GioiTinh"].ToString());
                txtNamSinh.Text = LoadThongTinBenhNhan_The.Rows[0]["NamSinh"].ToString();
                txtSoDienThoai.Text = LoadThongTinBenhNhan_The.Rows[0]["SoDienThoai"].ToString();
                txtDiaChi.Text = LoadThongTinBenhNhan_The.Rows[0]["DiaChiChiTiet"].ToString();
                BenhNhan_Id = LoadThongTinBenhNhan_The.Rows[0]["BenhNhan_Id"].ToString();
                txtZaloID.Text = LoadThongTinBenhNhan_The.Rows[0]["Zalo_Id"].ToString();
                CMND = LoadThongTinBenhNhan_The.Rows[0]["CMND"].ToString();
                BHYT = LoadThongTinBenhNhan_The.Rows[0]["BHYT"].ToString();

                The_Id = LoadThongTinBenhNhan_The.Rows[0]["The_Id"].ToString();
                txtSoThe.Text = LoadThongTinBenhNhan_The.Rows[0]["SoThe"].ToString();

                string NgayHieuLuc = LoadThongTinBenhNhan_The.Rows[0]["NgayHieuLuc"].ToString();
                if (!String.IsNullOrEmpty(NgayHieuLuc))
                {
                    DateTime enteredDate = DateTime.Parse(NgayHieuLuc);
                    txtHieuLuc.Value = enteredDate;
                }

                if (!string.IsNullOrEmpty(The_Id) || The_Id != "")
                {
                    LoadThongTinTrongTheTheoId(The_Id);
                }
            }
            else
            {
                MessageBox.Show("Mã Y Tế Không tồn tại! Vui lòng kiểm tra lại.");
            }
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            int n = e.RowHandle;
            if (gridView1.RowCount > 0)
            {
                CLSYeuCau_Id = gridView1.GetRowCellValue(n, "CLSYeuCau_Id").ToString();
            }
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;

            if (e.Column.FieldName == "TrangThai")
            {
                string status = View.GetRowCellDisplayText(e.RowHandle, View.Columns["TrangThai"]);
                if (status != "Chưa thực hiện")
                {
                    e.Appearance.BackColor = Color.FromArgb(52, 152, 219);
                    e.Appearance.FontStyleDelta = FontStyle.Bold;
                    e.Appearance.ForeColor = Color.FromArgb(236, 240, 241);
                }
            }

            if (e.Column.FieldName == "TenDichVu")
            {
                string status = View.GetRowCellDisplayText(e.RowHandle, View.Columns["DaThanhToan"]);
                if (status == "0")
                {
                    e.Appearance.BackColor = Color.FromArgb(52, 152, 219);
                    e.Appearance.FontStyleDelta = FontStyle.Bold;
                    e.Appearance.ForeColor = Color.FromArgb(236, 240, 241);
                }
            }
        }

        private void txtSoDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar) || e.KeyChar == '-' || e.KeyChar == '.'))
            {
                e.Handled = true;
            }
        }

        private void txtNamSinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar) || e.KeyChar == '-' || e.KeyChar == '.'))
            {
                e.Handled = true;
            }
        }

        private void cbbDV_Click(object sender, EventArgs e)
        {
            cbbDV.DataSource = Dm_DichVu;
            cbbDV.DroppedDown = true;
        }

        private void TiepNhanTheThanhVien_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.S)
            {
                if (btnLuu.Enabled == true)
                {
                    btnLuu.PerformClick();
                }
                else
                {
                    alertControl1.Show(this, "Thông báo", "Chưa đủ điều kiện khởi chạy phím Lưu!", "");
                }
            }
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.N)
            {
                if (btnThem.Enabled == true)
                {
                    btnThem.PerformClick();
                }
                else
                {
                    alertControl1.Show(this, "Thông báo", "Chưa đủ điều kiện khởi chạy phím Thêm!", "");
                }
            }
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.E)
            {
                if (btnSua.Enabled == true)
                {
                    btnSua.PerformClick();
                }
                else
                {
                    alertControl1.Show(this, "Thông báo", "Chưa đủ điều kiện khởi chạy phím Sửa!", "");
                }
            }
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.W)
            {
                if (btnHuy.Enabled == true)
                {
                    btnHuy.PerformClick();
                }
                else
                {
                    alertControl1.Show(this, "Thông báo", "Chưa đủ điều kiện khởi chạy phím Huỷ!", "");
                }
            }
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.D)
            {
                if (btnXoa.Enabled == true)
                {
                    btnXoa.PerformClick();
                }
                else
                {
                    alertControl1.Show(this, "Thông báo", "Chưa đủ điều kiện khởi chạy phím Xoá!", "");
                }
            }
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.F)
            {
                if (btnTimKiem.Enabled == true)
                {
                    btnTimKiem.PerformClick();
                }
                else
                {
                    alertControl1.Show(this, "Thông báo", "Chưa đủ điều kiện khởi chạy phím Tìm kiếm!", "");
                }
            }
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.P)
            {
                if (btnIn.Enabled == true)
                {
                    btnIn.PerformClick();
                }
                else
                {
                    alertControl1.Show(this, "Thông báo", "Chưa đủ điều kiện khởi chạy phím In!", "");
                }
            }
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.R)
            {
                if (btnXem.Enabled == true)
                {
                    btnXem.PerformClick();
                }
                else
                {
                    alertControl1.Show(this, "Thông báo", "Chưa đủ điều kiện khởi chạy phím Xem!", "");
                }
            }
        }

        private void cbbDV_ValueChanged(object sender, EventArgs e)
        {
            string t = "";
            if (cbbDV.Value != null)
            {
                t = cbbDV.Value.ToString();
                PhongBan = Model.DbTiepNhan.CBBPhongBan(t);
                if (PhongBan != null)
                {
                    if (PhongBan.Rows.Count > 0)
                    {
                        cbbphongban.DataSource = PhongBan;

                        cbbphongban.ValueMember = "PhongBan_Id";
                        cbbphongban.DisplayMember = "TenPhongBan";
                        //cbbphongban.Value = "48";
                        //cbbphongban.Value = cbbphongban.ValueMember.ToString().Min(); 
                        int firstRowValue = (int)PhongBan.Rows[0]["PhongBan_Id"];
                        cbbphongban.Value = firstRowValue.ToString();
                    }
                }

                if (autoClickDichVu == "1")
                {
                    if (cbbDV.SelectedIndex != -1)
                    {
                        btnChonDichVu_Click(btnChonDichVu, EventArgs.Empty);
                    }
                }
            }
            else
            {
                cbbphongban.DataSource = null; cbbphongban.DataSource = null;
            }
        }

        private void cbbDV_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Tab && e.KeyData != Keys.Enter && e.KeyData != Keys.Up && e.KeyData != Keys.Down && e.KeyData != Keys.Right && e.KeyData != Keys.Left)
            {
                string text = cbbDV.Text;
                DataRow[] resultRow = Dm_DichVu.Select("TenDichVu LIKE '%" + text + "%' or MaDichVu LIKE '%" + text + "%'");
                if (resultRow.Count() > 0)
                {
                    DataTable dtResult = Dm_DichVu.Select("TenDichVu LIKE '%" + text + "%' or MaDichVu LIKE '%" + text + "%'").CopyToDataTable();
                    cbbDV.DataSource = dtResult;
                    cbbDV.DroppedDown = true;
                }
                else
                {
                    cbbDV.DataSource = null;
                    cbbDV.DroppedDown = true;
                }
            }
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (txtHoTen.Text.Contains("|"))
                {
                    string[] arrListStr = txtHoTen.Text.Split('|');
                    string a = arrListStr[0].ToString();
                    if (arrListStr[0].Length == 15)
                    {
                        BHYT = arrListStr[0];
                        txtHoTen.Text = Model.Crypt.ConvertHexStrToUnicode(arrListStr[1]).ToUpper();
                        if (arrListStr[3] == "1") { cbbGioiTinh.Value = Int32.Parse("1"); } else { cbbGioiTinh.Value = Int32.Parse("2"); }

                        int NgaySinh = Int32.Parse(arrListStr[2].Substring(0, 2));
                        int ThangSinh = Int32.Parse(arrListStr[2].Substring(3, 2));
                        int NamSinh = Int32.Parse(arrListStr[2].Substring(arrListStr[2].Length - 4, 4));

                        if (!String.IsNullOrEmpty(arrListStr[2]))
                        {
                            DateTime dateValue = new DateTime(NamSinh, ThangSinh, NgaySinh);
                            txtNgaySinh.Value = dateValue;
                        }
                        else { txtNgaySinh.Text = ""; }

                        txtNamSinh.Text = arrListStr[2].Substring(arrListStr[2].Length - 4, 4);
                        if (arrListStr[4].Length > 2)
                        {
                            txtDiaChi.Text = Model.Crypt.ConvertHexStrToUnicode(arrListStr[4]);
                        }
                        else { txtDiaChi.Text = ""; }
                    }
                    if (arrListStr[0].Length == 12)
                    {
                        CMND = arrListStr[0];
                        BHYT = arrListStr[0];
                        txtHoTen.Text = arrListStr[2].ToUpper();
                        string GT = arrListStr[4];
                        if (GT == "Nam" || GT == "NAM") { cbbGioiTinh.Value = Int32.Parse("1"); } else { cbbGioiTinh.Value = Int32.Parse("2"); }

                        int NgaySinh = Int32.Parse(arrListStr[3].Substring(0, 2));
                        int ThangSinh = Int32.Parse(arrListStr[3].Substring(2, 2));
                        int NamSinh = Int32.Parse(arrListStr[3].Substring(arrListStr[3].Length - 4, 4));

                        if (!String.IsNullOrEmpty(arrListStr[3]))
                        {
                            DateTime dateValue = new DateTime(NamSinh, ThangSinh, NgaySinh);
                            txtNgaySinh.Value = dateValue;
                        }
                        else { txtNgaySinh.Text = ""; }

                        txtNamSinh.Text = arrListStr[3].Substring(arrListStr[3].Length - 4, 4);
                        txtDiaChi.Text = arrListStr[5];
                    }
                    if (arrListStr[0].Length == 10)
                    {
                        BHYT = arrListStr[0];
                        txtHoTen.Text = Model.Crypt.ConvertHexStrToUnicode(arrListStr[1]).ToUpper();
                        if (arrListStr[3] == "1") { cbbGioiTinh.Value = Int32.Parse("1"); } else { cbbGioiTinh.Value = Int32.Parse("2"); }

                        int NgaySinh = Int32.Parse(arrListStr[2].Substring(0, 2));
                        int ThangSinh = Int32.Parse(arrListStr[2].Substring(3, 2));
                        int NamSinh = Int32.Parse(arrListStr[2].Substring(arrListStr[2].Length - 4, 4));

                        if (!String.IsNullOrEmpty(arrListStr[2]))
                        {
                            DateTime dateValue = new DateTime(NamSinh, ThangSinh, NgaySinh);
                            txtNgaySinh.Value = dateValue;
                        }
                        else { txtNgaySinh.Text = ""; }

                        txtNamSinh.Text = arrListStr[2].Substring(arrListStr[2].Length - 4, 4);
                        if (arrListStr[4].Length > 2)
                        {
                            txtDiaChi.Text = Model.Crypt.ConvertHexStrToUnicode(arrListStr[4]);
                        }
                        else { txtDiaChi.Text = ""; }
                    }
                    //
                    DataTable LoadThongTinBenhNhan = Model.DbTiepNhan.LoadThongTinBenhNhanTheoCMNDHoacBHYT(BHYT);
                    if (LoadThongTinBenhNhan != null)
                    {
                        if (LoadThongTinBenhNhan.Rows.Count > 0)
                        {
                            txtMaYTe.Text = LoadThongTinBenhNhan.Rows[0]["MaYTe"].ToString();
                            MaYTe = LoadThongTinBenhNhan.Rows[0]["MaYTe"].ToString();
                            SoVaoVien = LoadThongTinBenhNhan.Rows[0]["SoVaoVien"].ToString();
                            BenhNhan_Id = LoadThongTinBenhNhan.Rows[0]["BenhNhan_Id"].ToString();
                        }
                    }

                }
            }
            if (e.KeyCode == Keys.Tab && e.Shift)
            {
                MoveFocusToPreviousTextbox();
                e.SuppressKeyPress = true;
            }
        }

        private void txtNgaySinh_Validated(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNgaySinh.Text)) 
            { 
                txtNamSinh.Text = txtNgaySinh.Value.Year.ToString(); 
            }         
        }

        private void txtChietKhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar) || e.KeyChar == '-' || e.KeyChar == '.'))
            {
                e.Handled = true;
            }
        }

        private void cbbNhomBenh_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Tab && e.KeyData != Keys.Enter && e.KeyData != Keys.Up && e.KeyData != Keys.Down && e.KeyData != Keys.Right && e.KeyData != Keys.Left)
            {
                string text = cbbNhomBenh.Text;
                DataRow[] resultRow = Dm_NhomBenh.Select("TenNhomBenh LIKE '%" + text + "%'");
                if (resultRow.Count() > 0)
                {
                    DataTable dtResult = Dm_NhomBenh.Select("TenNhomBenh LIKE '%" + text + "%'").CopyToDataTable();
                    cbbNhomBenh.DataSource = dtResult;
                    cbbNhomBenh.DroppedDown = true;
                }
                else
                {
                    cbbNhomBenh.DataSource = null;
                    cbbNhomBenh.DroppedDown = true;
                }
            }
        }

        void gettongtien()
        {
            float Tong = 0;
            // Lặp qua từng hàng trong cột
            for (int j = 0; j < gridView1.DataRowCount; j++)
            {
                // Lấy giá trị tại ô (j, i)
                string cellValue = gridView1.GetRowCellValue(j, "DaThanhToan").ToString();
                if (cellValue == "0")
                {
                    float thanhTienDichVu;
                    if (float.TryParse(gridView1.GetRowCellValue(j, "ThanhTienDichVu").ToString(), out thanhTienDichVu))
                    {
                        Tong += thanhTienDichVu;
                    }
                }
            }
            txtThanhTien.Text = "";
            txtThanhTien.Text = Tong.ToString("#,##0") + " VNĐ";
        }

        private void txtSoThe_Validated(object sender, EventArgs e)
        {
            if (txtSoThe.Text.Trim() != "")
            {
                //load the
                string SoThe = "N'" + txtSoThe.Text.Trim().Replace("'", "''") + "'";

                DataTable SelectTheThanhVienIdTheoSoThe = Model.DbTiepNhan.SelectTheThanhVienIdTheoSoThe(SoThe);

                txtMaYTe.Text = "";

                if (SelectTheThanhVienIdTheoSoThe != null)
                {
                    if (SelectTheThanhVienIdTheoSoThe.Rows.Count > 0)
                    {
                        The_Id = SelectTheThanhVienIdTheoSoThe.Rows[0]["The_Id"].ToString();
                        BenhNhan_Id = SelectTheThanhVienIdTheoSoThe.Rows[0]["BenhNhan_Id"].ToString();
                        MaYTe = SelectTheThanhVienIdTheoSoThe.Rows[0]["MaYTe"].ToString();
                        txtMaYTe.Text = SelectTheThanhVienIdTheoSoThe.Rows[0]["MaYTe"].ToString(); ;
                    }
                    else
                    {
                        XtraMessageBox.Show("Thẻ thành viên không tồn tại!", "Thông Báo");
                        return;
                    }
                }
                else
                {
                    XtraMessageBox.Show("Thẻ thành viên không tồn tại!", "Thông Báo");
                    return;
                }

                LoadThongTinBenhNhanTheoMaYTe_The();
            }
            else
            {
                Reset();
            }
        }

        private void txtSoThe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                
            }
        }

        private void txtHieuLuc_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}