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
    public partial class DM_LoaiDuoc : DevExpress.XtraEditors.XtraForm
    {
        public string DM_Id;
        public string ThaoTac;
        public DM_LoaiDuoc()
        {
            InitializeComponent();
        }

        private void DM_LoaiDuoc_Load(object sender, EventArgs e)
        {
            DataTable SelectLoaiDuoc = Model.dbDanhMuc.SelectLoaiDuoc();
            gridDichVu.DataSource = SelectLoaiDuoc;
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
            txtMaLoaiDuoc.Focus();
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
            txtMaLoaiDuoc.Focus();
            //
            LoadThongTinForm();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaLoaiDuoc.Text == "")
            {
                alertControl1.Show(this, "Thông báo", "Mã loại dược không được để trống! ", "");
            }
            else if (txtTenLoaiDuoc.Text == "")
            {
                alertControl1.Show(this, "Thông báo", "Tên loại dược không được để trống! ", "");
            }
            else
            {
                string MaLoaiDuoc = "N'" + txtMaLoaiDuoc.Text.Replace("'", "''") + "'";
                string TenLoaiDuoc = "N'" + txtTenLoaiDuoc.Text.Replace("'", "''") + "'";
                string TamNgung = "0";
                if (cbTamNgung.Checked == false) { TamNgung = "0"; } else { TamNgung = "1"; }
                if (ThaoTac == "Them")
                {
                    DataTable Insert = Model.dbDanhMuc.InsertLoaiDuoc(
                        MaLoaiDuoc
                        , TenLoaiDuoc
                        , TamNgung
                        , "0"
                        , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                        , Login.User_Id
                        , "null"
                        , "null"
                        );
                    if (Insert.Rows.Count > 0)
                    {
                        DM_Id = Insert.Rows[0]["LoaiDuoc_Id"].ToString();
                        alertControl1.Show(this, "Thông báo", "Đã thêm thành công! " + Insert.Rows[0]["TenLoaiDuoc"].ToString(), "");
                    }
                }
                if (ThaoTac == "Sua")
                {
                    DataTable Update = Model.dbDanhMuc.UpdateLoaiDuoc(
                          DM_Id
                        , MaLoaiDuoc
                        , TenLoaiDuoc
                        , TamNgung
                        , "0"
                        , "null"
                        , "null"
                        , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                        , Login.User_Id
                        );
                    if (Update.Rows.Count > 0)
                    {
                        DM_Id = Update.Rows[0]["LoaiDuoc_Id"].ToString();
                        alertControl1.Show(this, "Thông báo", "Đã sửa thành công! " + Update.Rows[0]["TenLoaiDuoc"].ToString(), "");
                    }
                }
                //
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnLuu.Enabled = false;
                btnHuy.Enabled = false;
                btnXoa.Enabled = true;
                An();
                DataTable SelectLoaiDuoc = Model.dbDanhMuc.SelectLoaiDuoc();
                gridDichVu.DataSource = SelectLoaiDuoc;
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
                    DataTable Delete = Model.dbDanhMuc.DeleteLoaiDuoc(DM_Id, nguoicapnhat);
                    Reset();
                    DM_Id = "";
                    DataTable SelectLoaiDuoc = Model.dbDanhMuc.SelectLoaiDuoc();
                    gridDichVu.DataSource = SelectLoaiDuoc;
                    alertControl1.Show(this, "Thông báo", "Đã xóa thành công! " + Delete.Rows[0]["TenLoaiDuoc"].ToString(), "");
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
                DM_Id = gridView1.GetRowCellValue(n, "LoaiDuoc_Id").ToString();
                DataTable SelectLoaiDuocTheoID = Model.dbDanhMuc.SelectLoaiDuocTheoID(DM_Id);
                {
                    if (SelectLoaiDuocTheoID != null)
                    {
                        if (SelectLoaiDuocTheoID.Rows.Count > 0)
                        {
                            txtMaLoaiDuoc.Text = SelectLoaiDuocTheoID.Rows[0]["MaLoaiDuoc"].ToString();
                            txtTenLoaiDuoc.Text = SelectLoaiDuocTheoID.Rows[0]["TenLoaiDuoc"].ToString();
                            string TamNgungTam = SelectLoaiDuocTheoID.Rows[0]["TamNgung"].ToString();
                            if (TamNgungTam == "0") { cbTamNgung.Checked = false; } else { cbTamNgung.Checked = true; }
                            btnThem.Enabled = false;
                            btnSua.Enabled = false;
                            btnLuu.Enabled = true;
                            btnHuy.Enabled = true;
                            btnXoa.Enabled = true;
                            Hien();
                            ThaoTac = "Sua";
                            txtMaLoaiDuoc.Focus();
                        }
                    }
                }
            }
        }
        public void LoadThongTinForm()
        {
            DataTable SelectLoaiDuocTheoID = Model.dbDanhMuc.SelectLoaiDuocTheoID(DM_Id);
            {
                if (SelectLoaiDuocTheoID != null)
                {
                    if (SelectLoaiDuocTheoID.Rows.Count > 0)
                    {
                        txtMaLoaiDuoc.Text = SelectLoaiDuocTheoID.Rows[0]["MaLoaiDuoc"].ToString();
                        txtTenLoaiDuoc.Text = SelectLoaiDuocTheoID.Rows[0]["TenLoaiDuoc"].ToString();
                        string TamNgungTam = SelectLoaiDuocTheoID.Rows[0]["TamNgung"].ToString();
                        if (TamNgungTam == "0") { cbTamNgung.Checked = false; } else { cbTamNgung.Checked = true; }
                    }
                }
            }
        }
        public void Hien()
        {
            txtMaLoaiDuoc.Enabled = true;
            txtTenLoaiDuoc.Enabled = true;
            cbTamNgung.Enabled = true;
        }
        public void An()
        {
            txtMaLoaiDuoc.Enabled = false;
            txtTenLoaiDuoc.Enabled = false;
            cbTamNgung.Enabled = false;
        }
        public void Reset()
        {
            txtMaLoaiDuoc.Text = "";
            txtTenLoaiDuoc.Text = "";
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