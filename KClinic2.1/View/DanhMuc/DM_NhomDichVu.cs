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
    public partial class DM_NhomDichVu : DevExpress.XtraEditors.XtraForm
    {
        public string DM_Id;
        public string ThaoTac;
        public DM_NhomDichVu()
        {
            InitializeComponent();
        }

        private void DM_NhomDichVu_Load(object sender, EventArgs e)
        {
            DataTable SelectNhomDichVu = Model.dbDanhMuc.SelectNhomDichVu();
            gridDichVu.DataSource = SelectNhomDichVu;
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
            txtMaNhomDichVu.Focus();
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
            txtMaNhomDichVu.Focus();
            //
            LoadThongTinForm();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaNhomDichVu.Text == "")
            {
                alertControl1.Show(this, "Thông báo", "Mã nhóm dịch vụ không được để trống! ", "");
            }
            else if (txtTenNhomDichVu.Text == "")
            {
                alertControl1.Show(this, "Thông báo", "Tên nhóm dịch vụ không được để trống! ", "");
            }
            else
            {
                string MaNhomDichVu = "N'" + txtMaNhomDichVu.Text.Replace("'", "''") + "'";
                string TenNhomDichVu = "N'" + txtTenNhomDichVu.Text.Replace("'", "''") + "'";
                string TamNgung = "0";
                if (cbTamNgung.Checked == false) { TamNgung = "0"; } else { TamNgung = "1"; }
                if (ThaoTac == "Them")
                {
                    DataTable Insert = Model.dbDanhMuc.InsertNhomDichVu(
                        MaNhomDichVu
                        , TenNhomDichVu
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
                        alertControl1.Show(this, "Thông báo", "Đã thêm thành công! ", "");
                    }
                }
                if (ThaoTac == "Sua")
                {
                    DataTable Update = Model.dbDanhMuc.UpdateNhomDichVu(
                        MaNhomDichVu
                        , TenNhomDichVu
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
                        alertControl1.Show(this, "Thông báo", "Đã sửa thành công! ", "");
                    }
                }
                //
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnLuu.Enabled = false;
                btnHuy.Enabled = false;
                btnXoa.Enabled = true;
                An();
                DataTable SelectNhomDichVu = Model.dbDanhMuc.SelectNhomDichVu();
                gridDichVu.DataSource = SelectNhomDichVu;
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
                    DataTable Delete = Model.dbDanhMuc.DeleteNhomDichVu(DM_Id, nguoicapnhat);
                    Reset();
                    DM_Id = "";
                    DataTable SelectNhomDichVu = Model.dbDanhMuc.SelectNhomDichVu();
                    gridDichVu.DataSource = SelectNhomDichVu;
                    alertControl1.Show(this, "Thông báo", "Đã xóa thành công! ", "");
                    break;
                case DialogResult.No:
                    break;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void LoadThongTinForm()
        {
            DataTable SelectNhomDichVuTheoID = Model.dbDanhMuc.SelectNhomDichVuTheoID(DM_Id);
            {
                if (SelectNhomDichVuTheoID != null)
                {
                    if (SelectNhomDichVuTheoID.Rows.Count > 0)
                    {
                        txtMaNhomDichVu.Text = SelectNhomDichVuTheoID.Rows[0]["MaNhomDichVu"].ToString();
                        txtTenNhomDichVu.Text = SelectNhomDichVuTheoID.Rows[0]["TenNhomDichVu"].ToString();
                        string TamNgungTam = SelectNhomDichVuTheoID.Rows[0]["TamNgung"].ToString();
                        if (TamNgungTam == "0") { cbTamNgung.Checked = false; } else { cbTamNgung.Checked = true; }
                    }
                }
            }
        }
        public void Hien()
        {
            txtMaNhomDichVu.Enabled = true;
            txtTenNhomDichVu.Enabled = true;
            cbTamNgung.Enabled = true;
        }
        public void An()
        {
            txtMaNhomDichVu.Enabled = false;
            txtTenNhomDichVu.Enabled = false;
            cbTamNgung.Enabled = false;
        }
        public void Reset()
        {
            txtMaNhomDichVu.Text = "";
            txtTenNhomDichVu.Text = "";
            cbTamNgung.Checked = false;
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            int n = e.RowHandle;
            if (gridView1.RowCount > 0)
            {
                DM_Id = gridView1.GetRowCellValue(n, "NhomDichVu_Id").ToString();
                DataTable SelectNhomDichVuTheoID = Model.dbDanhMuc.SelectNhomDichVuTheoID(DM_Id);
                {
                    if (SelectNhomDichVuTheoID != null)
                    {
                        if (SelectNhomDichVuTheoID.Rows.Count > 0)
                        {
                            txtMaNhomDichVu.Text = SelectNhomDichVuTheoID.Rows[0]["MaNhomDichVu"].ToString();
                            txtTenNhomDichVu.Text = SelectNhomDichVuTheoID.Rows[0]["TenNhomDichVu"].ToString();
                            string TamNgungTam = SelectNhomDichVuTheoID.Rows[0]["TamNgung"].ToString();
                            if (TamNgungTam == "0") { cbTamNgung.Checked = false; } else { cbTamNgung.Checked = true; }
                            btnThem.Enabled = false;
                            btnSua.Enabled = false;
                            btnLuu.Enabled = true;
                            btnHuy.Enabled = true;
                            btnXoa.Enabled = true;
                            Hien();
                            ThaoTac = "Sua";
                            txtMaNhomDichVu.Focus();
                        }
                    }
                }
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