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
    public partial class DM_DoiTuong : DevExpress.XtraEditors.XtraForm
    {
        public string DM_Id;
        public string ThaoTac;
        public DM_DoiTuong()
        {
            InitializeComponent();
        }
        private void DM_DoiTuong_Load(object sender, EventArgs e)
        {
            DataTable SelectDoiTuong = Model.dbDanhMuc.SelectDanhMucDoiTuong();
            gridDMDoiTuong.DataSource = SelectDoiTuong;
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
            txtMaDoiTuong.Focus();
        }

        

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaDoiTuong.Text == "")
            {
                alertControl1.Show(this, "Thông báo", "Mã đối tượng không được để trống! ", "");
            }
            else if (txtTenDoiTuong.Text == "")
            {
                alertControl1.Show(this, "Thông báo", "Tên đối tượng không được để trống! ", "");
            }
            else
            {
                string MaDoiTuong = "N'" + txtMaDoiTuong.Text.Replace("'", "''") + "'";
                string TenDoiTuong = "N'" + txtTenDoiTuong.Text.Replace("'", "''") + "'";
                string TenDoiTuong_En = "N'" + txtTenDoiTuongE.Text.Replace("'", "''") + "'";
                string TenDoiTuong_Ru = "N'" + txtTenDoiTuongR.Text.Replace("'", "''") + "'";
                string GhiChu = "N'" + txtGhiChu.Text.Replace("'", "''") + "'";
                string TenKhongDau = "N'" + txtTenDoiTuongNoSN.Text.Replace("'", "''") + "'";
                string TamNgung = "0";
                string MienPhi = "0";
                if (cbTamNgung.Checked == false) { TamNgung = "0"; } else { TamNgung = "1"; }
                if (cbMienPhi.Checked == false) { MienPhi = "0"; } else { MienPhi = "1"; }
                if (ThaoTac == "Them")
                {
                    DataTable Insert = Model.dbDanhMuc.InsertDanhMucDoiTuong(
                        MaDoiTuong
                        , TenDoiTuong
                        , TenDoiTuong_En
                        , TenDoiTuong_Ru
                        , MienPhi
                        , TamNgung
                        , GhiChu
                        , TenKhongDau
                        , "0"
                        , Login.User_Id
                        , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                        , "null"
                        , "null"
                        );
                    if (Insert.Rows.Count > 0)
                    {
                        DM_Id = Insert.Rows[0]["DoiTuong_Id"].ToString();
                        alertControl1.Show(this, "Thông báo", "Đã thêm thành công " + Insert.Rows[0]["TenDoiTuong"].ToString(), "");
                    }
                }
                if (ThaoTac == "Sua")
                {
                    DataTable Update = Model.dbDanhMuc.UpdateDanhMucDoiTuong(
                        MaDoiTuong
                        , TenDoiTuong
                        , TenDoiTuong_En
                        , TenDoiTuong_Ru
                        , MienPhi
                        , TamNgung
                        , GhiChu
                        , TenKhongDau
                        , "0"
                        , "null"
                        , "null"
                        , Login.User_Id
                        , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                        , DM_Id
                        );
                    if (Update.Rows.Count > 0)
                    {
                        DM_Id = Update.Rows[0]["DoiTuong_Id"].ToString();
                        alertControl1.Show(this, "Thông báo", "Đã sửa thành công " + Update.Rows[0]["TenDoiTuong"].ToString(), "");
                    }
                }
                //
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnLuu.Enabled = false;
                btnHuy.Enabled = false;
                btnXoa.Enabled = true;
                An();
                DataTable SelectDoiTuong = Model.dbDanhMuc.SelectDanhMucDoiTuong();
                gridDMDoiTuong.DataSource = SelectDoiTuong;
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
                Reset();
            }
            else if (ThaoTac == "Sua")
            {
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                Reset();
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
                    DataTable Delete = Model.dbDanhMuc.DeleteDanhMucDoiTuong(DM_Id, nguoicapnhat);
                    Reset();
                    DM_Id = "";
                    DataTable SelectDoiTuong = Model.dbDanhMuc.SelectDanhMucDoiTuong();
                    gridDMDoiTuong.DataSource = SelectDoiTuong;
                    alertControl1.Show(this, "Thông báo", "Đã xóa thành công " + Delete.Rows[0]["TenDoiTuong"].ToString(), "");
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
            DataTable SelectDanhMucDoiTuongTheoID = Model.dbDanhMuc.SelectDanhMucDoiTuongTheoID(DM_Id);
            {
                if (SelectDanhMucDoiTuongTheoID != null)
                {
                    if (SelectDanhMucDoiTuongTheoID.Rows.Count > 0)
                    {
                        txtMaDoiTuong.Text = SelectDanhMucDoiTuongTheoID.Rows[0]["MaDoiTuong"].ToString();
                        txtTenDoiTuong.Text = SelectDanhMucDoiTuongTheoID.Rows[0]["TenDoiTuong"].ToString();
                        txtTenDoiTuongE.Text = SelectDanhMucDoiTuongTheoID.Rows[0]["TenDoiTuong_En"].ToString();
                        txtTenDoiTuongR.Text = SelectDanhMucDoiTuongTheoID.Rows[0]["TenDoiTuong_Ru"].ToString();
                        txtGhiChu.Text = SelectDanhMucDoiTuongTheoID.Rows[0]["GhiChu"].ToString();
                        txtTenDoiTuongNoSN.Text = SelectDanhMucDoiTuongTheoID.Rows[0]["TenKhongDau"].ToString();
                        string TamNgungTam = SelectDanhMucDoiTuongTheoID.Rows[0]["TamNgung"].ToString();
                        string MienPhi = SelectDanhMucDoiTuongTheoID.Rows[0]["MienPhi"].ToString();
                        if (TamNgungTam == "0") { cbTamNgung.Checked = false; } else { cbTamNgung.Checked = true; }
                        if (MienPhi == "0") { cbMienPhi.Checked = false; } else { cbMienPhi.Checked = true; }
                    }
                }
            }
        }
        public void Hien()
        {
            txtMaDoiTuong.Enabled = true;
            txtTenDoiTuong.Enabled = true;
            txtTenDoiTuongE.Enabled = true;
            txtTenDoiTuongR.Enabled = true;
            txtTenDoiTuongNoSN.Enabled = true;
            txtGhiChu.Enabled = true;
            cbMienPhi.Enabled = true;
            cbTamNgung.Enabled = true;
        }
        public void An()
        {
            txtMaDoiTuong.Enabled = false;
            txtTenDoiTuong.Enabled = false;
            txtTenDoiTuongE.Enabled = false;
            txtTenDoiTuongR.Enabled = false;
            txtTenDoiTuongNoSN.Enabled = false;
            txtGhiChu.Enabled = false;
            cbMienPhi.Enabled = false;
            cbTamNgung.Enabled = false;
        }
        public void Reset()
        {
            txtMaDoiTuong.Text = "";
            txtTenDoiTuong.Text = "";
            txtTenDoiTuongE.Text = "";
            txtTenDoiTuongR.Text = "";
            txtTenDoiTuongNoSN.Text = "";
            txtGhiChu.Text = "";
            cbMienPhi.Checked = false;
            cbTamNgung.Checked = false;
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            int n = e.RowHandle;
            if (gridView1.RowCount > 0)
            {
                DM_Id = gridView1.GetRowCellValue(n, "DoiTuong_Id").ToString();
                DataTable SelectDoiTuongTheoID = Model.dbDanhMuc.SelectDanhMucDoiTuongTheoID(DM_Id);
                if (SelectDoiTuongTheoID.Rows.Count > 0)
                {
                    txtMaDoiTuong.Text = SelectDoiTuongTheoID.Rows[0]["MaDoiTuong"].ToString();
                    txtTenDoiTuong.Text = SelectDoiTuongTheoID.Rows[0]["TenDoiTuong"].ToString();
                    txtTenDoiTuongE.Text = SelectDoiTuongTheoID.Rows[0]["TenDoiTuong_En"].ToString();
                    txtTenDoiTuongR.Text = SelectDoiTuongTheoID.Rows[0]["TenDoiTuong_Ru"].ToString();
                    txtGhiChu.Text = SelectDoiTuongTheoID.Rows[0]["GhiChu"].ToString();
                    txtTenDoiTuongNoSN.Text = SelectDoiTuongTheoID.Rows[0]["TenKhongDau"].ToString();
                    string TamNgungTam = SelectDoiTuongTheoID.Rows[0]["TamNgung"].ToString();
                    string MienPhi = SelectDoiTuongTheoID.Rows[0]["MienPhi"].ToString();
                    if (TamNgungTam == "0") { cbTamNgung.Checked = false; } else { cbTamNgung.Checked = true; }
                    if (MienPhi == "0") { cbMienPhi.Checked = false; } else { cbMienPhi.Checked = true; }
                    btnThem.Enabled = false;
                    btnSua.Enabled = false;
                    btnLuu.Enabled = true;
                    btnHuy.Enabled = true;
                    btnXoa.Enabled = true;
                    Hien();
                    ThaoTac = "Sua";
                    txtMaDoiTuong.Focus();
                }
            }

        }

        private void btnSua_click(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            btnXoa.Enabled = false;
            Hien();
            ThaoTac = "Sua";
            txtMaDoiTuong.Focus();
            //
            LoadThongTinForm();
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