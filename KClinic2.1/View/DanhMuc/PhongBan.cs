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
    public partial class PhongBan : DevExpress.XtraEditors.XtraForm
    {
        public string DM_Id;
        public string ThaoTac;
        public PhongBan()
        {
            InitializeComponent();
        }
        DataTable CBBLoaiPhongBan;
        private void PhongBan_Load(object sender, EventArgs e)
        {
            DataTable SelectPhongBan = Model.dbDanhMuc.SelectPhongBan();
            gridDichVu.DataSource = SelectPhongBan;
            CBBLoaiPhongBan = Model.dbDanhMuc.CBBLoaiPhongBan();
            cbbLoaiPhongBan.DataSource = CBBLoaiPhongBan;
            cbbLoaiPhongBan.ValueMember = "FieldCode";
            cbbLoaiPhongBan.DisplayMember = "FieldName";
            cbbLoaiPhongBan.SelectedIndex = 0;
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
            txtMaPhongBan.Focus();
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
            txtMaPhongBan.Focus();
            //
            LoadThongTinForm();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaPhongBan.Text == "")
            {
                alertControl1.Show(this, "Thông báo", "Mã phòng ban không được để trống! ", "");
            }
            else if (txtTenPhongBan.Text == "")
            {
                alertControl1.Show(this, "Thông báo", "Tên phòng ban không được để trống! ", "");
            }
            else
            {
                string MaPhongBan = "N'" + txtMaPhongBan.Text.Replace("'", "''") + "'";
                string TenPhongBan = "N'" + txtTenPhongBan.Text.Replace("'", "''") + "'";
                string TamNgung = "0";
                if (cbTamNgung.Checked == false) { TamNgung = "0"; } else { TamNgung = "1"; }
                string LoaiPhongBan_Id = "null";
                if (cbbLoaiPhongBan.SelectedItem != null) { LoaiPhongBan_Id = cbbLoaiPhongBan.Value.ToString(); }
                if (ThaoTac == "Them")
                {
                    DataTable Insert = Model.dbDanhMuc.InsertPhongBan(
                        MaPhongBan
                        , TenPhongBan
                        , LoaiPhongBan_Id
                        , TamNgung
                        , "0"
                        , Login.User_Id
                        , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                        , "null"
                        , "null"
                        );
                    if (Insert.Rows.Count > 0)
                    {
                        DM_Id = Insert.Rows[0]["PhongBan_Id"].ToString();
                        alertControl1.Show(this, "Thông báo", "Đã thêm thành công! " + Insert.Rows[0]["TenPhongBan"].ToString(), "");
                    }
                }
                if (ThaoTac == "Sua")
                {
                    DataTable Update = Model.dbDanhMuc.UpdatePhongBan(
                          DM_Id
                        , MaPhongBan
                        , TenPhongBan
                        , LoaiPhongBan_Id
                        , TamNgung
                        , "0"
                        , "null"
                        , "null"
                        , Login.User_Id
                        , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                        );
                    if (Update.Rows.Count > 0)
                    {
                        DM_Id = Update.Rows[0]["PhongBan_Id"].ToString();
                        alertControl1.Show(this, "Thông báo", "Đã sửa thành công! " + Update.Rows[0]["TenPhongBan"].ToString(), "");
                    }
                }
                //
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnLuu.Enabled = false;
                btnHuy.Enabled = false;
                btnXoa.Enabled = true;
                An();
                DataTable SelectPhongBan = Model.dbDanhMuc.SelectPhongBan();
                gridDichVu.DataSource = SelectPhongBan;
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
                    DataTable Delete = Model.dbDanhMuc.DeletePhongBan(DM_Id, nguoicapnhat);
                    Reset();
                    DM_Id = "";
                    DataTable SelectLoaiPhongBan = Model.dbDanhMuc.SelectLoaiPhongBan();
                    gridDichVu.DataSource = SelectLoaiPhongBan;
                    alertControl1.Show(this, "Thông báo", "Đã xóa thành công! " + Delete.Rows[0]["TenPhongBan"].ToString(), "");
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
                DM_Id = gridView1.GetRowCellValue(n, "PhongBan_Id").ToString();
                DataTable SelectPhongBanTheoID = Model.dbDanhMuc.SelectPhongBanTheoID(DM_Id);
                {
                    if (SelectPhongBanTheoID != null)
                    {
                        if (SelectPhongBanTheoID.Rows.Count > 0)
                        {
                            txtMaPhongBan.Text = SelectPhongBanTheoID.Rows[0]["MaPhongBan"].ToString();
                            txtTenPhongBan.Text = SelectPhongBanTheoID.Rows[0]["TenPhongBan"].ToString();
                            string TamNgungTam = SelectPhongBanTheoID.Rows[0]["TamNgung"].ToString();
                            if (TamNgungTam == "0") { cbTamNgung.Checked = false; } else { cbTamNgung.Checked = true; }
                            string LoaiPhongBan_Id = SelectPhongBanTheoID.Rows[0]["LoaiPhongBan_Id"].ToString();
                            if (!String.IsNullOrEmpty(LoaiPhongBan_Id))
                            {
                                cbbLoaiPhongBan.Value = Int32.Parse(LoaiPhongBan_Id);
                            }
                            btnThem.Enabled = false;
                            btnSua.Enabled = false;
                            btnLuu.Enabled = true;
                            btnHuy.Enabled = true;
                            btnXoa.Enabled = true;
                            Hien();
                            ThaoTac = "Sua";
                            txtMaPhongBan.Focus();
                        }
                    }
                }
            }
        }
        public void LoadThongTinForm()
        {
            DataTable SelectPhongBanTheoID = Model.dbDanhMuc.SelectPhongBanTheoID(DM_Id);
            {
                if (SelectPhongBanTheoID != null)
                {
                    if (SelectPhongBanTheoID.Rows.Count > 0)
                    {
                        txtMaPhongBan.Text = SelectPhongBanTheoID.Rows[0]["MaPhongBan"].ToString();
                        txtTenPhongBan.Text = SelectPhongBanTheoID.Rows[0]["TenPhongBan"].ToString();
                        string TamNgungTam = SelectPhongBanTheoID.Rows[0]["TamNgung"].ToString();
                        if (TamNgungTam == "0") { cbTamNgung.Checked = false; } else { cbTamNgung.Checked = true; }
                        string LoaiPhongBan_Id = SelectPhongBanTheoID.Rows[0]["LoaiPhongBan_Id"].ToString();
                        if (!String.IsNullOrEmpty(LoaiPhongBan_Id))
                        {
                            cbbLoaiPhongBan.Value = Int32.Parse(LoaiPhongBan_Id);
                        }
                    }
                }
            }
        }
        public void Hien()
        {
            txtMaPhongBan.Enabled = true;
            txtTenPhongBan.Enabled = true;
            cbTamNgung.Enabled = true;
            cbbLoaiPhongBan.Enabled = true;
        }
        public void An()
        {
            txtMaPhongBan.Enabled = false;
            txtTenPhongBan.Enabled = false;
            cbTamNgung.Enabled = false;
            cbbLoaiPhongBan.Enabled = false;
        }
        public void Reset()
        {
            txtMaPhongBan.Text = "";
            txtTenPhongBan.Text = "";
            cbTamNgung.Checked = false;
        }

        private void cbbLoaiPhongBan_KeyDown(object sender, KeyEventArgs e)
        {
            string text = cbbLoaiPhongBan.Text;
            DataRow[] resultRow = CBBLoaiPhongBan.Select("FieldName LIKE '%" + text + "%'");
            if (resultRow.Count() > 0)
            {
                DataTable dtResult = CBBLoaiPhongBan.Select("FieldName LIKE '%" + text + "%'").CopyToDataTable();
                cbbLoaiPhongBan.DataSource = dtResult;
                cbbLoaiPhongBan.DroppedDown = true;
            }
            else
            {
                cbbLoaiPhongBan.DataSource = null;
                cbbLoaiPhongBan.DroppedDown = true;
            }
            if (e.KeyCode == Keys.Tab && e.Shift)
            {
                MoveFocusToPreviousTextbox();
                e.SuppressKeyPress = true;
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