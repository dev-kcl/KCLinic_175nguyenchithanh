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
namespace KClinic2._1.View.HeThong
{
    public partial class BenhVien : DevExpress.XtraEditors.XtraForm
    {
        public string DM_Id;
        public string ThaoTac;
        public BenhVien()
        {
            InitializeComponent();
        }

        private void BenhVien_Load(object sender, EventArgs e)
        {
            DataTable SelectBenhVien = Model.db.SelectBenhVien();
            gridDichVu.DataSource = SelectBenhVien;
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
            txtMaBenhVien.Focus();
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
            txtMaBenhVien.Focus();
            //
            LoadThongTinForm();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaBenhVien.Text == "")
            {
                alertControl1.Show(this, "Thông báo", "Mã bệnh viện không được để trống!", "");
            }
            else if (txtTenBenhVien.Text == "")
            {
                alertControl1.Show(this, "Thông báo", "Tên bệnh viện không được để trống!", "");
            }
            else
            {
                string MaBenhVien = "N'" + txtMaBenhVien.Text.Replace("'", "''") + "'";
                string TenBenhVien = "N'" + txtTenBenhVien.Text.Replace("'", "''") + "'";
                string DiaChi1 = "null";
                if (txtDiaChi1.Text != "") { DiaChi1 = "N'" + txtDiaChi1.Text.Replace("'", "''") + "'"; }
                string DiaChi2 = "null";
                if (txtDiaChi2.Text != "") { DiaChi2 = "N'" + txtDiaChi2.Text.Replace("'", "''") + "'"; }
                string DiaChi3 = "null";
                if (txtDiaChi3.Text != "") { DiaChi3 = "N'" + txtDiaChi3.Text.Replace("'", "''") + "'"; }
                string SoDienThoai1 = "null";
                if (txtSoDienThoai1.Text != "") { SoDienThoai1 = "N'" + txtSoDienThoai1.Text.Replace("'", "''") + "'"; }
                string SoDienThoai2 = "null";
                if (txtSoDienThoai2.Text != "") { SoDienThoai2 = "N'" + txtSoDienThoai2.Text.Replace("'", "''") + "'"; }
                string SoDienThoai3 = "null";
                if (txtSoDienThoai3.Text != "") { SoDienThoai3 = "N'" + txtSoDienThoai3.Text.Replace("'", "''") + "'"; }
                string TamNgung = "0";
                if (cbTamNgung.Checked == false) { TamNgung = "0"; } else { TamNgung = "1"; }

                if (ThaoTac == "Them")
                {
                    DataTable Insert = Model.db.InsertBenhVien(
                        MaBenhVien
                        , TenBenhVien
                        , DiaChi1
                        , DiaChi2
                        , DiaChi3
                        , SoDienThoai1
                        , SoDienThoai2
                        , SoDienThoai3
                        , TamNgung
                        , Login.User_Id
                        , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                        , "null"
                        , "null"
                        , "0"
                        );
                    if (Insert.Rows.Count > 0)
                    {
                        DM_Id = Insert.Rows[0][0].ToString();
                        alertControl1.Show(this, "Thông báo", "Đã thêm thành công!", "");
                    }
                }
                if (ThaoTac == "Sua")
                {
                    DataTable Update = Model.db.UpdateBenhVien(
                          MaBenhVien
                        , TenBenhVien
                        , DiaChi1
                        , DiaChi2
                        , DiaChi3
                        , SoDienThoai1
                        , SoDienThoai2
                        , SoDienThoai3
                        , TamNgung
                        , "null"
                        , "null"
                        , Login.User_Id
                        , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                        , "0"
                        , DM_Id
                        );
                    if (Update.Rows.Count > 0)
                    {
                        DM_Id = Update.Rows[0][0].ToString();
                        alertControl1.Show(this, "Thông báo", "Đã sửa thành công!", "");
                    }
                }
                //
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnLuu.Enabled = false;
                btnHuy.Enabled = false;
                btnXoa.Enabled = true;
                An();
                DataTable SelectBenhVien = Model.db.SelectBenhVien();
                gridDichVu.DataSource = SelectBenhVien;
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
                    DataTable Delete = Model.db.DeleteBenhVien(DM_Id, nguoicapnhat);
                    Reset();
                    DM_Id = "";
                    DataTable SelectBenhVien = Model.db.SelectBenhVien();
                    gridDichVu.DataSource = SelectBenhVien;
                    alertControl1.Show(this, "Thông báo", "Đã xóa thành công!", "");
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
                DM_Id = gridView1.GetRowCellValue(n, "BenhVien_Id").ToString();
                DataTable SelectBenhVienTheoID = Model.db.SelectBenhVienTheoID(DM_Id);
                {
                    if (SelectBenhVienTheoID != null)
                    {
                        if (SelectBenhVienTheoID.Rows.Count > 0)
                        {
                            txtMaBenhVien.Text = SelectBenhVienTheoID.Rows[0]["MaBenhVien"].ToString();
                            txtTenBenhVien.Text = SelectBenhVienTheoID.Rows[0]["TenBenhVien"].ToString();
                            txtDiaChi1.Text = SelectBenhVienTheoID.Rows[0]["DiaChi1"].ToString();
                            txtDiaChi2.Text = SelectBenhVienTheoID.Rows[0]["DiaChi2"].ToString();
                            txtDiaChi3.Text = SelectBenhVienTheoID.Rows[0]["DiaChi3"].ToString();
                            txtSoDienThoai1.Text = SelectBenhVienTheoID.Rows[0]["SoDienThoai1"].ToString();
                            txtSoDienThoai2.Text = SelectBenhVienTheoID.Rows[0]["SoDienThoai2"].ToString();
                            txtSoDienThoai3.Text = SelectBenhVienTheoID.Rows[0]["SoDienThoai3"].ToString();
                            string TamNgungTam = SelectBenhVienTheoID.Rows[0]["TamNgung"].ToString();
                            if (TamNgungTam == "0") { cbTamNgung.Checked = false; } else { cbTamNgung.Checked = true; }
                            btnThem.Enabled = false;
                            btnSua.Enabled = false;
                            btnLuu.Enabled = true;
                            btnHuy.Enabled = true;
                            btnXoa.Enabled = true;
                            Hien();
                            ThaoTac = "Sua";
                            txtMaBenhVien.Focus();
                        }
                    }
                }
            }
        }
        public void LoadThongTinForm()
        {
            DataTable SelectBenhVienTheoID = Model.db.SelectBenhVienTheoID(DM_Id);
            {
                if (SelectBenhVienTheoID != null)
                {
                    if (SelectBenhVienTheoID.Rows.Count > 0)
                    {
                        txtMaBenhVien.Text = SelectBenhVienTheoID.Rows[0]["MaBenhVien"].ToString();
                        txtTenBenhVien.Text = SelectBenhVienTheoID.Rows[0]["TenBenhVien"].ToString();
                        txtDiaChi1.Text = SelectBenhVienTheoID.Rows[0]["DiaChi1"].ToString();
                        txtDiaChi2.Text = SelectBenhVienTheoID.Rows[0]["DiaChi2"].ToString();
                        txtDiaChi3.Text = SelectBenhVienTheoID.Rows[0]["DiaChi3"].ToString();
                        txtSoDienThoai1.Text = SelectBenhVienTheoID.Rows[0]["SoDienThoai1"].ToString();
                        txtSoDienThoai2.Text = SelectBenhVienTheoID.Rows[0]["SoDienThoai2"].ToString();
                        txtSoDienThoai3.Text = SelectBenhVienTheoID.Rows[0]["SoDienThoai3"].ToString();
                        string TamNgungTam = SelectBenhVienTheoID.Rows[0]["TamNgung"].ToString();
                        if (TamNgungTam == "0") { cbTamNgung.Checked = false; } else { cbTamNgung.Checked = true; }
                    }
                }
            }
        }
        public void Hien()
        {
            txtMaBenhVien.Enabled = true;
            txtTenBenhVien.Enabled = true;
            txtDiaChi1.Enabled = true;
            txtDiaChi2.Enabled = true;
            txtDiaChi3.Enabled = true;
            txtSoDienThoai1.Enabled = true;
            txtSoDienThoai2.Enabled = true;
            txtSoDienThoai3.Enabled = true;
            cbTamNgung.Enabled = true;
        }
        public void An()
        {
            txtMaBenhVien.Enabled = false;
            txtTenBenhVien.Enabled = false;
            txtDiaChi1.Enabled = false;
            txtDiaChi2.Enabled = false;
            txtDiaChi3.Enabled = false;
            txtSoDienThoai1.Enabled = false;
            txtSoDienThoai2.Enabled = false;
            txtSoDienThoai3.Enabled = false;
            cbTamNgung.Enabled = false;
        }
        public void Reset()
        {
            txtMaBenhVien.Text = "";
            txtTenBenhVien.Text = "";
            txtDiaChi1.Text = "";
            txtDiaChi2.Text = "";
            txtDiaChi3.Text = "";
            txtSoDienThoai1.Text = "";
            txtSoDienThoai2.Text = "";
            txtSoDienThoai3.Text = "";
            cbTamNgung.Checked = false;
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