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
    public partial class ToaThuocMau : DevExpress.XtraEditors.XtraForm
    {
        public string DM_Id;
        public string ThaoTac;
        public ToaThuocMau()
        {
            InitializeComponent();
        }

        private void ToaThuocMau_Load(object sender, EventArgs e)
        {
            DataTable SelectToaThuocMau = Model.dbDanhMuc.SelectToaThuocMau();
            gridDichVu.DataSource = SelectToaThuocMau;
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
            txtMaToaThuocMau.Focus();
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
            txtMaToaThuocMau.Focus();
            //
            LoadThongTinForm();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaToaThuocMau.Text == "")
            {
                alertControl1.Show(this, "Thông báo", "Mã toa thuốc mẫu không được để trống!", "");
            }
            else if (txtTenToaThuocMau.Text == "")
            {
                alertControl1.Show(this, "Thông báo", "Tên toa thuốc mẫu không được để trống!", "");
            }
            else
            {
                string MaToaThuocMau = "N'" + txtMaToaThuocMau.Text.Replace("'", "''") + "'";
                string TenToaThuocMau = "N'" + txtTenToaThuocMau.Text.Replace("'", "''") + "'";
                string TamNgung = "0";
                if (cbTamNgung.Checked == false) { TamNgung = "0"; } else { TamNgung = "1"; }

                if (ThaoTac == "Them")
                {
                    DataTable Insert = Model.dbDanhMuc.InsertToaThuocMau(
                        MaToaThuocMau
                        , TenToaThuocMau
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
                    DataTable Update = Model.dbDanhMuc.UpdateToaThuocMau(
                         MaToaThuocMau
                        , TenToaThuocMau
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
                DataTable SelectToaThuocMau = Model.dbDanhMuc.SelectToaThuocMau();
                gridDichVu.DataSource = SelectToaThuocMau;
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
                    DataTable Delete = Model.dbDanhMuc.DeleteToaThuocMau(DM_Id, nguoicapnhat);
                    Reset();
                    DM_Id = "";
                    DataTable SelectToaThuocMau = Model.dbDanhMuc.SelectToaThuocMau();
                    gridDichVu.DataSource = SelectToaThuocMau;
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
                DM_Id = gridView1.GetRowCellValue(n, "ToaThuocMau_Id").ToString();
                DataTable SelectToaThuocMauTheoID = Model.dbDanhMuc.SelectToaThuocMauTheoID(DM_Id);
                {
                    if (SelectToaThuocMauTheoID != null)
                    {
                        if (SelectToaThuocMauTheoID.Rows.Count > 0)
                        {
                            txtMaToaThuocMau.Text = SelectToaThuocMauTheoID.Rows[0]["MaToaThuocMau"].ToString();
                            txtTenToaThuocMau.Text = SelectToaThuocMauTheoID.Rows[0]["TenToaThuocMau"].ToString();
                            string TamNgungTam = SelectToaThuocMauTheoID.Rows[0]["TamNgung"].ToString();
                            if (TamNgungTam == "0") { cbTamNgung.Checked = false; } else { cbTamNgung.Checked = true; }
                            btnThem.Enabled = false;
                            btnSua.Enabled = false;
                            btnLuu.Enabled = true;
                            btnHuy.Enabled = true;
                            btnXoa.Enabled = true;
                            Hien();
                            ThaoTac = "Sua";
                            txtMaToaThuocMau.Focus();
                        }
                    }
                }
            }
        }
        public void LoadThongTinForm()
        {
            DataTable SelectToaThuocMauTheoID = Model.dbDanhMuc.SelectToaThuocMauTheoID(DM_Id);
            {
                if (SelectToaThuocMauTheoID != null)
                {
                    if (SelectToaThuocMauTheoID.Rows.Count > 0)
                    {
                        txtMaToaThuocMau.Text = SelectToaThuocMauTheoID.Rows[0]["MaToaThuocMau"].ToString();
                        txtTenToaThuocMau.Text = SelectToaThuocMauTheoID.Rows[0]["TenToaThuocMau"].ToString();
                        string TamNgungTam = SelectToaThuocMauTheoID.Rows[0]["TamNgung"].ToString();
                        if (TamNgungTam == "0") { cbTamNgung.Checked = false; } else { cbTamNgung.Checked = true; }
                    }
                }
            }
        }
        public void Hien()
        {
            txtMaToaThuocMau.Enabled = true;
            txtTenToaThuocMau.Enabled = true;
            cbTamNgung.Enabled = true;
        }
        public void An()
        {
            txtMaToaThuocMau.Enabled = false;
            txtTenToaThuocMau.Enabled = false;
            cbTamNgung.Enabled = false;
        }
        public void Reset()
        {
            txtMaToaThuocMau.Text = "";
            txtTenToaThuocMau.Text = "";
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