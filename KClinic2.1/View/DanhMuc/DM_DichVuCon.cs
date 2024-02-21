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
    public partial class DM_DichVuCon : DevExpress.XtraEditors.XtraForm
    {
        public string DM_Id;
        public string ThaoTac;
        public DM_DichVuCon()
        {
            InitializeComponent();
        }

        private void DM_DichVuCon_Load(object sender, EventArgs e)
        {
            DataTable SelectDichVu = Model.dbDanhMuc.SelectDichVuCon();
            gridDichVu.DataSource = SelectDichVu;
            getDataDVC();
            cbbDichVuCha.SelectedIndex = 0;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            btnXoa.Enabled = false;
            An();
        }
        DataTable Dm_DichVuCha;
        void getDataDVC()
        {
            Dm_DichVuCha = Model.dbDanhMuc.CBBDichVuCha();
            cbbDichVuCha.DataSource = Dm_DichVuCha;
            cbbDichVuCha.ValueMember = "FieldCode";
            cbbDichVuCha.DisplayMember = "FieldName";
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
            txtMaDichVu.Focus();
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
            txtMaDichVu.Focus();
            //
            LoadThongTinForm();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaDichVu.Text == "")
            {
                alertControl1.Show(this, "Thông báo", "Mã dịch vụ không được để trống! ", "");
            }
            else if (txtTenDichVu.Text == "")
            {
                alertControl1.Show(this, "Thông báo", "Tên dịch vụ không được để trống! ", "");
            }
            else
            {
                string MaDichVu = "N'" + txtMaDichVu.Text.Replace("'", "''") + "'";
                string TenDichVu = "N'" + txtTenDichVu.Text.Replace("'", "''") + "'";
                string TamNgung = "0";
                if (cbTamNgung.Checked == false) { TamNgung = "0"; } else { TamNgung = "1"; }
                string CoGiaTriChuan = "0";
                if (cbCoGiaTriChuan.Checked == false) { CoGiaTriChuan = "0"; } else { CoGiaTriChuan = "1"; }
                string CapTren_Id = "null";
                if (cbbDichVuCha.SelectedItem != null) { CapTren_Id = cbbDichVuCha.Value.ToString(); }
                string DVT = "N'" + txtDVT.Text.Replace("'", "''") + "'";
                if (ThaoTac == "Them")
                {
                    DataTable Insert = Model.dbDanhMuc.InsertDichVuCon(
                        MaDichVu
                        , TenDichVu
                        , "null"
                        , DVT
                        , CoGiaTriChuan
                        , "2"
                        , "0"
                        , CapTren_Id
                        , "null"
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
                    DataTable Update = Model.dbDanhMuc.UpdateDichVuCon(
                         MaDichVu
                        , TenDichVu
                        , "null"
                        , DVT
                        , CoGiaTriChuan
                        , "2"
                        , "0"
                        , CapTren_Id
                        , "null"
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
                DataTable SelectDichVu = Model.dbDanhMuc.SelectDichVuCon();
                gridDichVu.DataSource = SelectDichVu;
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
                    DataTable Delete = Model.dbDanhMuc.DeleteDichVuCon(DM_Id, nguoicapnhat);
                    Reset();
                    DM_Id = "";
                    DataTable SelectDichVu = Model.dbDanhMuc.SelectDichVuCon();
                    gridDichVu.DataSource = SelectDichVu;
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

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            int n = e.RowHandle;
            if (gridView1.RowCount > 0)
            {
                DM_Id = gridView1.GetRowCellValue(n, "Dich_Id").ToString();
                DataTable SelectDichVuConTheoID = Model.dbDanhMuc.SelectDichVuConTheoID(DM_Id);
                {
                    if (SelectDichVuConTheoID != null)
                    {
                        if (SelectDichVuConTheoID.Rows.Count > 0)
                        {
                            txtMaDichVu.Text = SelectDichVuConTheoID.Rows[0]["MaDichVu"].ToString();
                            txtTenDichVu.Text = SelectDichVuConTheoID.Rows[0]["TenDichVu"].ToString();
                            string TamNgungTam = SelectDichVuConTheoID.Rows[0]["TamNgung"].ToString();
                            if (TamNgungTam == "0") { cbTamNgung.Checked = false; } else { cbTamNgung.Checked = true; }
                            string CoGiaTriChuan = SelectDichVuConTheoID.Rows[0]["CoGiaTriChuan"].ToString();
                            if (CoGiaTriChuan == "0") { cbCoGiaTriChuan.Checked = false; } else { cbCoGiaTriChuan.Checked = true; }
                            string DichVuCha = SelectDichVuConTheoID.Rows[0]["CapTren_Id"].ToString();
                            if (!String.IsNullOrEmpty(DichVuCha))
                            {
                                cbbDichVuCha.Value = Int32.Parse(DichVuCha);
                            }
                            txtDVT.Text = SelectDichVuConTheoID.Rows[0]["DVT"].ToString();
                            btnThem.Enabled = false;
                            btnSua.Enabled = false;
                            btnLuu.Enabled = true;
                            btnHuy.Enabled = true;
                            btnXoa.Enabled = true;
                            Hien();
                            ThaoTac = "Sua";
                            txtMaDichVu.Focus();
                        }
                    }
                }
            }
        }
        private void cbbDichVuCha_Click(object sender, EventArgs e)
        {
            cbbDichVuCha.DataSource = Dm_DichVuCha;

            
            cbbDichVuCha.ValueMember = "FieldCode";
            cbbDichVuCha.DisplayMember = "FieldName";
            cbbDichVuCha.DroppedDown = true;
        }
        public void LoadThongTinForm()
        {
            DataTable SelectDichVuConTheoID = Model.dbDanhMuc.SelectDichVuConTheoID(DM_Id);
            {
                if (SelectDichVuConTheoID != null)
                {
                    if (SelectDichVuConTheoID.Rows.Count > 0)
                    {
                        txtMaDichVu.Text = SelectDichVuConTheoID.Rows[0]["MaDichVu"].ToString();
                        txtTenDichVu.Text = SelectDichVuConTheoID.Rows[0]["TenDichVu"].ToString();
                        string TamNgungTam = SelectDichVuConTheoID.Rows[0]["TamNgung"].ToString();
                        if (TamNgungTam == "0") { cbTamNgung.Checked = false; } else { cbTamNgung.Checked = true; }
                        string CoGiaTriChuan = SelectDichVuConTheoID.Rows[0]["CoGiaTriChuan"].ToString();
                        if (CoGiaTriChuan == "0") { cbCoGiaTriChuan.Checked = false; } else { cbCoGiaTriChuan.Checked = true; }
                        string DichVuCha = SelectDichVuConTheoID.Rows[0]["CapTren_Id"].ToString();
                        if (!String.IsNullOrEmpty(DichVuCha))
                        {
                            cbbDichVuCha.Value = Int32.Parse(DichVuCha);
                        }
                        txtDVT.Text = SelectDichVuConTheoID.Rows[0]["DVT"].ToString();
                    }
                    cbbDichVuCha.DataSource = Dm_DichVuCha;
                    cbbDichVuCha.DroppedDown = true;
                }
            }
        }
        public void Hien()
        {
            txtMaDichVu.Enabled = true;
            txtTenDichVu.Enabled = true;
            cbTamNgung.Enabled = true;
            cbCoGiaTriChuan.Enabled = true;
            cbbDichVuCha.Enabled = true;
            txtDVT.Enabled = true;
        }
        public void An()
        {
            txtMaDichVu.Enabled = false;
            txtTenDichVu.Enabled = false;
            cbTamNgung.Enabled = false;
            cbCoGiaTriChuan.Enabled = false;
            cbbDichVuCha.Enabled = false;
            txtDVT.Enabled = false;
        }
        public void Reset()
        {
            txtMaDichVu.Text = "";
            txtTenDichVu.Text = "";
            cbTamNgung.Checked = false;
            cbCoGiaTriChuan.Checked = false;
            txtDVT.Text = "";
        }
        private void cbbDichVuCha_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Tab && e.KeyData != Keys.Enter && e.KeyData != Keys.Up && e.KeyData != Keys.Down && e.KeyData != Keys.Right && e.KeyData != Keys.Left)
            {
                string text = cbbDichVuCha.Text;
                if (text == "")
                {
                    DataTable dtResult = Dm_DichVuCha.Select("FieldName LIKE '%" + text + "%'").CopyToDataTable();
                    cbbDichVuCha.DataSource = dtResult;
                    cbbDichVuCha.DroppedDown = true;
                }
                else
                {
                    DataRow[] resultRow = Dm_DichVuCha.Select("FieldName LIKE '%" + text + "%'");
                    if (resultRow.Count() > 0)
                    {
                        DataTable dtResult = Dm_DichVuCha.Select("FieldName LIKE '%" + text + "%'").CopyToDataTable();
                        cbbDichVuCha.DataSource = dtResult;
                        cbbDichVuCha.DroppedDown = true;
                    }
                    else
                    {
                        cbbDichVuCha.DataSource = null;
                        cbbDichVuCha.DroppedDown = true;
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