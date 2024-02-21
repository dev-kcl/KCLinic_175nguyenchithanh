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

namespace KClinic2._1.View.DanhMuc
{
    public partial class DM_DonViTinh : DevExpress.XtraEditors.XtraForm
    {
        public string DM_Id;
        public string ThaoTac;
        public DM_DonViTinh()
        {
            InitializeComponent();
        }
        DataTable CBBLoaiDuoc;
        private void DM_DonViTinh_Load(object sender, EventArgs e)
        {
            DataTable SelectDonViTinh = Model.dbDanhMuc.SelectDonViTinh();
            gridDichVu.DataSource = SelectDonViTinh;
            CBBLoaiDuoc = Model.dbDanhMuc.CBBLoaiDuoc();
            cbbLoaiDuoc.DataSource = CBBLoaiDuoc;
            cbbLoaiDuoc.ValueMember = "FieldCode";
            cbbLoaiDuoc.DisplayMember = "FieldName";
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            btnXoa.Enabled = false;
            An();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            btnXoa.Enabled = false;
            Hien();
            ThaoTac = "Them";
            DM_Id = "";
            Reset();
            txtMaDonViTinh.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            btnXoa.Enabled = false;
            Hien();
            ThaoTac = "Sua";
            txtMaDonViTinh.Focus();
            //
            LoadThongTinForm();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaDonViTinh.Text == "")
            {
                alertControl1.Show(this, "Thông báo", "Mã đơn vị tính không được để trống! ", "");
            }
            else if (txtTenDonViTinh.Text == "")
            {
                alertControl1.Show(this, "Thông báo", "Tên đơn vị tính không được để trống! ", "");
            }
            else
            {
                string MaDonViTinh = "N'" + txtMaDonViTinh.Text.Replace("'", "''") + "'";
                string TenDonViTinh = "N'" + txtTenDonViTinh.Text.Replace("'", "''") + "'";
                string TamNgung = "0";
                if (cbTamNgung.Checked == false) { TamNgung = "0"; } else { TamNgung = "1"; }
                string LoaiDuoc = "null";
                if (cbbLoaiDuoc.SelectedItem != null) { LoaiDuoc = "N'" + cbbLoaiDuoc.Value.ToString().Replace("'", "''") + "'"; }
                string GiaTriQuyDoi = "null";
                if (txtGiaTriQuyDoi.Text != "") { GiaTriQuyDoi = "N'" + txtGiaTriQuyDoi.Text.Replace("'", "''") + "'"; }
                if (ThaoTac == "Them")
                {
                    DataTable Insert = Model.dbDanhMuc.InsertDonViTinh(
                        MaDonViTinh
                        , TenDonViTinh
                        , LoaiDuoc
                        , GiaTriQuyDoi
                        , TamNgung
                        , "0"
                        , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                        , Login.User_Id
                        , "null"
                        , "null"
                        );
                    if (Insert.Rows.Count > 0)
                    {
                        DM_Id = Insert.Rows[0]["DonViTinh_Id"].ToString();
                        alertControl1.Show(this, "Thông báo", "Đã thêm thành công! " + Insert.Rows[0]["TenDonViTinh"].ToString(), "");
                    }
                }
                if (ThaoTac == "Sua")
                {
                    DataTable Update = Model.dbDanhMuc.UpdateDonViTinh(
                          DM_Id
                        , MaDonViTinh
                        , TenDonViTinh
                        , LoaiDuoc
                        , GiaTriQuyDoi
                        , TamNgung
                        , "0"
                        , "null"
                        , "null"
                        , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                        , Login.User_Id
                        );
                    if (Update.Rows.Count > 0)
                    {
                        DM_Id = Update.Rows[0]["DonViTinh_Id"].ToString();
                        alertControl1.Show(this, "Thông báo", "Đã sửa thành công! " + Update.Rows[0]["TenDonViTinh"].ToString(), "");
                    }
                }
                //
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnLuu.Enabled = false;
                btnHuy.Enabled = false;
                btnXoa.Enabled = true;
                An();
                DataTable SelectDonViTinh = Model.dbDanhMuc.SelectDonViTinh();
                gridDichVu.DataSource = SelectDonViTinh;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            An();
            if (ThaoTac == "Them")
            {
                btnThem.Enabled = true;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                DM_Id = "";
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
                    An();
                    //
                    DataTable Delete = Model.dbDanhMuc.DeleteDonViTinh(DM_Id, nguoicapnhat);
                    Reset();
                    DM_Id = "";
                    DataTable SelectDonViTinh = Model.dbDanhMuc.SelectDonViTinh();
                    gridDichVu.DataSource = SelectDonViTinh;
                    alertControl1.Show(this, "Thông báo", "Đã xóa thành công! " + Delete.Rows[0]["TenDonViTinh"].ToString(), "");
                    break;
                case DialogResult.No:
                    break;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            int n = e.RowHandle;
            if (gridView1.RowCount > 0)
            {
                DM_Id = gridView1.GetRowCellValue(n, "DonViTinh_Id").ToString();
                DataTable SelectDonViTinhTheoID = Model.dbDanhMuc.SelectDonViTinhTheoID(DM_Id);
                {
                    if (SelectDonViTinhTheoID != null)
                    {
                        if (SelectDonViTinhTheoID.Rows.Count > 0)
                        {
                            txtMaDonViTinh.Text = SelectDonViTinhTheoID.Rows[0]["MaDonViTinh"].ToString();
                            txtTenDonViTinh.Text = SelectDonViTinhTheoID.Rows[0]["TenDonViTinh"].ToString();
                            string TamNgungTam = SelectDonViTinhTheoID.Rows[0]["TamNgung"].ToString();
                            if (TamNgungTam == "0") { cbTamNgung.Checked = false; } else { cbTamNgung.Checked = true; }
                            string LoaiThuoc = SelectDonViTinhTheoID.Rows[0]["LoaiThuoc"].ToString();
                            if (!String.IsNullOrEmpty(LoaiThuoc))
                            {
                                cbbLoaiDuoc.Value = LoaiThuoc;
                            }
                            txtGiaTriQuyDoi.Text = SelectDonViTinhTheoID.Rows[0]["GiaTriQuyDoi"].ToString();
                            btnThem.Enabled = false;
                            btnSua.Enabled = false;
                            btnLuu.Enabled = true;
                            btnHuy.Enabled = true;
                            btnXoa.Enabled = true;
                            Hien();
                            ThaoTac = "Sua";
                            txtMaDonViTinh.Focus();
                        }
                    }
                }
            }
        }
        public void LoadThongTinForm()
        {
            DataTable SelectDonViTinhTheoID = Model.dbDanhMuc.SelectDonViTinhTheoID(DM_Id);
            {
                if (SelectDonViTinhTheoID != null)
                {
                    if (SelectDonViTinhTheoID.Rows.Count > 0)
                    {
                        txtMaDonViTinh.Text = SelectDonViTinhTheoID.Rows[0]["MaDonViTinh"].ToString();
                        txtTenDonViTinh.Text = SelectDonViTinhTheoID.Rows[0]["TenDonViTinh"].ToString();
                        string TamNgungTam = SelectDonViTinhTheoID.Rows[0]["TamNgung"].ToString();
                        if (TamNgungTam == "0") { cbTamNgung.Checked = false; } else { cbTamNgung.Checked = true; }
                        string LoaiThuoc = SelectDonViTinhTheoID.Rows[0]["LoaiThuoc"].ToString();
                        if (!String.IsNullOrEmpty(LoaiThuoc))
                        {
                            cbbLoaiDuoc.Value = LoaiThuoc;
                        }
                        txtGiaTriQuyDoi.Text = SelectDonViTinhTheoID.Rows[0]["GiaTriQuyDoi"].ToString();
                    }
                }
            }
        }
        public void Hien()
        {
            txtMaDonViTinh.Enabled = true;
            txtTenDonViTinh.Enabled = true;
            cbTamNgung.Enabled = true;
            cbbLoaiDuoc.Enabled = true;
            txtGiaTriQuyDoi.Enabled = true;
        }
        public void An()
        {
            txtMaDonViTinh.Enabled = false;
            txtTenDonViTinh.Enabled = false;
            cbTamNgung.Enabled = false;
            cbbLoaiDuoc.Enabled = false;
            txtGiaTriQuyDoi.Enabled = false;
        }
        public void Reset()
        {
            txtMaDonViTinh.Text = "";
            txtTenDonViTinh.Text = "";
            cbTamNgung.Checked = false;
            txtGiaTriQuyDoi.Text = "";
        }

        private void cbbLoaiDuoc_KeyDown(object sender, KeyEventArgs e)
        {
            string text = cbbLoaiDuoc.Text;
            DataRow[] resultRow = CBBLoaiDuoc.Select("FieldName LIKE '%" + text + "%' or FieldCode LIKE '%" + text + "%'");
            if (resultRow.Count() > 0)
            {
                DataTable dtResult = CBBLoaiDuoc.Select("FieldName LIKE '%" + text + "%'or FieldCode LIKE '%" + text + "%'").CopyToDataTable();
                cbbLoaiDuoc.DataSource = dtResult;
                cbbLoaiDuoc.DroppedDown = true;
            }
            else
            {
                cbbLoaiDuoc.DataSource = null;
                cbbLoaiDuoc.DroppedDown = true;
            }
            if (e.KeyCode == Keys.Tab && e.Shift)
            {
                MoveFocusToPreviousTextbox();
                e.SuppressKeyPress = true;
            }
        }

        private void txtGiaTriQuyDoi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
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