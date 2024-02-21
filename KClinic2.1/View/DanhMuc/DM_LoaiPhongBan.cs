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
    public partial class DM_LoaiPhongBan : DevExpress.XtraEditors.XtraForm
    {
        public string DM_Id;
        public string ThaoTac;
        public DM_LoaiPhongBan()
        {
            InitializeComponent();
        }

        private void DM_LoaiPhongBan_Load(object sender, EventArgs e)
        {
            DataTable SelectLoaiPhongBan = Model.dbDanhMuc.SelectLoaiPhongBan();
            gridDichVu.DataSource = SelectLoaiPhongBan;
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
            txtMaLoaiPhongBan.Focus();
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
            txtMaLoaiPhongBan.Focus();
            //
            LoadThongTinForm();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaLoaiPhongBan.Text == "")
            {
                alertControl1.Show(this, "Thông báo", "Mã loại phòng ban không được để trống! ", "");
            }
            else if (txtTenLoaiPhongBan.Text == "")
            {
                alertControl1.Show(this, "Thông báo", "Tên loại phòng ban không được để trống! ", "");
            }
            else
            {
                string MaLoaiPhongBan = "N'" + txtMaLoaiPhongBan.Text.Replace("'", "''") + "'";
                string TenLoaiPhongBan = "N'" + txtTenLoaiPhongBan.Text.Replace("'", "''") + "'";
                string TamNgung = "0";
                if (cbTamNgung.Checked == false) { TamNgung = "0"; } else { TamNgung = "1"; }
                if (ThaoTac == "Them")
                {
                    DataTable Insert = Model.dbDanhMuc.InserLoaiPhongBan(
                        MaLoaiPhongBan
                        , TenLoaiPhongBan
                        , TamNgung
                        , "0"
                        , Login.User_Id
                        , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                        , "null"
                        , "null"
                        );
                    if (Insert.Rows.Count > 0)
                    {
                        DM_Id = Insert.Rows[0]["LoaiPhongBan_Id"].ToString();
                        alertControl1.Show(this, "Thông báo", "Đã thêm thành công! " + Insert.Rows[0]["TenLoaiPhongBan"].ToString(), "");
                    }
                }
                if (ThaoTac == "Sua")
                {
                    DataTable Update = Model.dbDanhMuc.UpdateLoaiPhongBan(
                          DM_Id
                        , MaLoaiPhongBan
                        , TenLoaiPhongBan
                        , TamNgung
                        , "0"
                        , "null"
                        , "null"
                        , Login.User_Id
                        , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                        );
                    if (Update.Rows.Count > 0)
                    {
                        DM_Id = Update.Rows[0]["LoaiPhongBan_Id"].ToString();
                        alertControl1.Show(this, "Thông báo", "Đã sửa thành công! " + Update.Rows[0]["TenLoaiPhongBan"].ToString(), "");
                    }
                }
                //
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnLuu.Enabled = false;
                btnHuy.Enabled = false;
                btnXoa.Enabled = true;
                An();
                DataTable SelectLoaiPhongBan = Model.dbDanhMuc.SelectLoaiPhongBan();
                gridDichVu.DataSource = SelectLoaiPhongBan;
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
                    DataTable Delete = Model.dbDanhMuc.DeleteLoaiPhongBan(DM_Id, nguoicapnhat);
                    Reset();
                    DM_Id = "";
                    DataTable SelectLoaiPhongBan = Model.dbDanhMuc.SelectLoaiPhongBan();
                    gridDichVu.DataSource = SelectLoaiPhongBan;
                    alertControl1.Show(this, "Thông báo", "Đã xóa thành công! " + Delete.Rows[0]["TenLoaiPhongBan"].ToString(), "");
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
                DM_Id = gridView1.GetRowCellValue(n, "LoaiPhongBan_Id").ToString();
                DataTable SelectLoaiPhongBanTheoID = Model.dbDanhMuc.SelectLoaiPhongBanTheoID(DM_Id);
                {
                    if (SelectLoaiPhongBanTheoID != null)
                    {
                        if (SelectLoaiPhongBanTheoID.Rows.Count > 0)
                        {
                            txtMaLoaiPhongBan.Text = SelectLoaiPhongBanTheoID.Rows[0]["MaLoaiPhongBan"].ToString();
                            txtTenLoaiPhongBan.Text = SelectLoaiPhongBanTheoID.Rows[0]["TenLoaiPhongBan"].ToString();
                            string TamNgungTam = SelectLoaiPhongBanTheoID.Rows[0]["TamNgung"].ToString();
                            if (TamNgungTam == "0") { cbTamNgung.Checked = false; } else { cbTamNgung.Checked = true; }
                            btnThem.Enabled = false;
                            btnSua.Enabled = false;
                            btnLuu.Enabled = true;
                            btnHuy.Enabled = true;
                            btnXoa.Enabled = true;
                            Hien();
                            ThaoTac = "Sua";
                            txtMaLoaiPhongBan.Focus();
                        }
                    }
                }
            }
        }
        public void LoadThongTinForm()
        {
            DataTable SelectLoaiPhongBanTheoID = Model.dbDanhMuc.SelectLoaiPhongBanTheoID(DM_Id);
            {
                if (SelectLoaiPhongBanTheoID != null)
                {
                    if (SelectLoaiPhongBanTheoID.Rows.Count > 0)
                    {
                        txtMaLoaiPhongBan.Text = SelectLoaiPhongBanTheoID.Rows[0]["MaLoaiPhongBan"].ToString();
                        txtTenLoaiPhongBan.Text = SelectLoaiPhongBanTheoID.Rows[0]["TenLoaiPhongBan"].ToString();
                        string TamNgungTam = SelectLoaiPhongBanTheoID.Rows[0]["TamNgung"].ToString();
                        if (TamNgungTam == "0") { cbTamNgung.Checked = false; } else { cbTamNgung.Checked = true; }
                    }
                }
            }
        }
        public void Hien()
        {
            txtMaLoaiPhongBan.Enabled = true;
            txtTenLoaiPhongBan.Enabled = true;
            cbTamNgung.Enabled = true;
        }
        public void An()
        {
            txtMaLoaiPhongBan.Enabled = false;
            txtTenLoaiPhongBan.Enabled = false;
            cbTamNgung.Enabled = false;
        }
        public void Reset()
        {
            txtMaLoaiPhongBan.Text = "";
            txtTenLoaiPhongBan.Text = "";
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