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
    public partial class DM_DichVu : DevExpress.XtraEditors.XtraForm
    {
        public string DM_Id;
        public string ThaoTac;
        public DM_DichVu()
        {
            InitializeComponent();
        }

        private void DM_DichVu_Load(object sender, EventArgs e)
        {
            DataTable SelectDichVu = Model.dbDanhMuc.SelectDichVu();
            gridDichVu.DataSource = SelectDichVu;
            getDataNDV();
            cbbNhomDichVu.SelectedIndex = 0;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            btnXoa.Enabled = false;
            An();
        }
        DataTable Dm_NhomDichVu;
        void getDataNDV()
        {
            Dm_NhomDichVu = Model.dbDanhMuc.CBBNhomDichVu();
            cbbNhomDichVu.DataSource = Dm_NhomDichVu;
            cbbNhomDichVu.DisplayMember = "FieldName";
            cbbNhomDichVu.ValueMember = "FieldCode";
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            int n = e.RowHandle;
            if (gridView1.RowCount > 0)
            {
                DM_Id = gridView1.GetRowCellValue(n, "Dich_Id").ToString();
                DataTable SelectDichVuTheoID = Model.dbDanhMuc.SelectDichVuTheoID(DM_Id);
                {
                    if (SelectDichVuTheoID != null)
                    {
                        if (SelectDichVuTheoID.Rows.Count > 0)
                        {
                            txtMaDichVu.Text = SelectDichVuTheoID.Rows[0]["MaDichVu"].ToString();
                            txtTenDichVu.Text = SelectDichVuTheoID.Rows[0]["TenDichVu"].ToString();
                            string TamNgungTam = SelectDichVuTheoID.Rows[0]["TamNgung"].ToString();
                            if (TamNgungTam == "0") { cbTamNgung.Checked = false; } else { cbTamNgung.Checked = true; }
                            string IsDichVuCha = SelectDichVuTheoID.Rows[0]["IsDichVuCha"].ToString();
                            if (IsDichVuCha == "0") { cbIsDichVuCha.Checked = false; } else { cbIsDichVuCha.Checked = true; }
                            string CoGiaTriChuan = SelectDichVuTheoID.Rows[0]["CoGiaTriChuan"].ToString();
                            if (CoGiaTriChuan == "0") { cbCoGiaTriChuan.Checked = false; } else { cbCoGiaTriChuan.Checked = true; }
                            string NhomDichVu_Id = SelectDichVuTheoID.Rows[0]["NhomDichVu_Id"].ToString();
                            if (!String.IsNullOrEmpty(NhomDichVu_Id))
                            {
                                cbbNhomDichVu.Value = Int32.Parse(NhomDichVu_Id);
                            }
                            txtGiaDichVu.Text = SelectDichVuTheoID.Rows[0]["GiaDichVu"].ToString();
                            txtDVT.Text = SelectDichVuTheoID.Rows[0]["DVT"].ToString();
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
                string IsDichVuCha = "0";
                if (cbIsDichVuCha.Checked == false) { IsDichVuCha = "0"; } else { IsDichVuCha = "1"; }
                string CoGiaTriChuan = "0";
                if (cbCoGiaTriChuan.Checked == false) { CoGiaTriChuan = "0"; } else { CoGiaTriChuan = "1"; }
                string NhomDichVu_Id = "null";
                if (cbbNhomDichVu.SelectedItem != null) { NhomDichVu_Id = cbbNhomDichVu.Value.ToString(); }
                string GiaDichVu = "0";
                if (txtGiaDichVu.Text.Length > 0) { GiaDichVu = "N'" + txtGiaDichVu.Text.Replace("'", "''") + "'"; }
                string DVT = "N'" + txtDVT.Text.Replace("'", "''") + "'";
                if (ThaoTac == "Them")
                {
                    DataTable Insert = Model.dbDanhMuc.InsertDichVu(
                        MaDichVu
                        , TenDichVu
                        , GiaDichVu
                        , DVT
                        , CoGiaTriChuan
                        , "1"
                        , IsDichVuCha
                        , "null"
                        , NhomDichVu_Id
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
                    DataTable Update = Model.dbDanhMuc.UpdateDichVu(
                         MaDichVu
                        , TenDichVu
                        , GiaDichVu
                        , DVT
                        , CoGiaTriChuan
                        , "1"
                        , IsDichVuCha
                        , "null"
                        , NhomDichVu_Id
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
                DataTable SelectDichVu = Model.dbDanhMuc.SelectDichVu();
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
                    DataTable Delete = Model.dbDanhMuc.DeleteDichVu(DM_Id, nguoicapnhat);
                    Reset();
                    DM_Id = "";
                    DataTable SelectDichVu = Model.dbDanhMuc.SelectDichVu();
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
        public void LoadThongTinForm()
        {
            DataTable SelectDichVuTheoID = Model.dbDanhMuc.SelectDichVuTheoID(DM_Id);
            {
                if (SelectDichVuTheoID != null)
                {
                    if (SelectDichVuTheoID.Rows.Count > 0)
                    {
                        txtMaDichVu.Text = SelectDichVuTheoID.Rows[0]["MaDichVu"].ToString();
                        txtTenDichVu.Text = SelectDichVuTheoID.Rows[0]["TenDichVu"].ToString();
                        string TamNgungTam = SelectDichVuTheoID.Rows[0]["TamNgung"].ToString();
                        if (TamNgungTam == "0") { cbTamNgung.Checked = false; } else { cbTamNgung.Checked = true; }
                        string IsDichVuCha = SelectDichVuTheoID.Rows[0]["IsDichVuCha"].ToString();
                        if (IsDichVuCha == "0") { cbIsDichVuCha.Checked = false; } else { cbIsDichVuCha.Checked = true; }
                        string CoGiaTriChuan = SelectDichVuTheoID.Rows[0]["CoGiaTriChuan"].ToString();
                        if (CoGiaTriChuan == "0") { cbCoGiaTriChuan.Checked = false; } else { cbCoGiaTriChuan.Checked = true; }
                        string NhomDichVu_Id = SelectDichVuTheoID.Rows[0]["NhomDichVu_Id"].ToString();
                        if (!String.IsNullOrEmpty(NhomDichVu_Id))
                        {
                            cbbNhomDichVu.Value = Int32.Parse(NhomDichVu_Id);
                        }
                        txtGiaDichVu.Text = SelectDichVuTheoID.Rows[0]["GiaDichVu"].ToString();
                        txtDVT.Text = SelectDichVuTheoID.Rows[0]["DVT"].ToString();
                    }
                }
                cbbNhomDichVu.DataSource = Dm_NhomDichVu;
                cbbNhomDichVu.DroppedDown = true;
            }
        }
        public void Hien()
        {
            txtMaDichVu.Enabled = true;
            txtTenDichVu.Enabled = true;
            cbTamNgung.Enabled = true;
            cbIsDichVuCha.Enabled = true;
            cbCoGiaTriChuan.Enabled = true;
            cbbNhomDichVu.Enabled = true;
            txtGiaDichVu.Enabled = true;
            txtDVT.Enabled = true;
        }
        public void An()
        {
            txtMaDichVu.Enabled = false;
            txtTenDichVu.Enabled = false;
            cbTamNgung.Enabled = false;
            cbIsDichVuCha.Enabled = false;
            cbCoGiaTriChuan.Enabled = false;
            cbbNhomDichVu.Enabled = false;
            txtGiaDichVu.Enabled = false;
            txtDVT.Enabled = false;
        }
        public void Reset()
        {
            txtMaDichVu.Text = "";
            txtTenDichVu.Text = "";
            cbTamNgung.Checked = false;
            cbIsDichVuCha.Checked = false;
            cbCoGiaTriChuan.Checked = false;
            txtGiaDichVu.Text = "";
            txtDVT.Text = "";
        }
       
        private void cbbNhomDichVu_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Tab && e.KeyData != Keys.Enter && e.KeyData != Keys.Up && e.KeyData != Keys.Down && e.KeyData != Keys.Right && e.KeyData != Keys.Left)
            {
                string text = cbbNhomDichVu.Text;
                if (text == "")
                {
                    DataTable dtResult = Dm_NhomDichVu.Select("FieldName LIKE '%" + text + "%'").CopyToDataTable();
                    cbbNhomDichVu.DataSource = dtResult;
                    cbbNhomDichVu.DroppedDown = true;
                }
                else
                {
                    DataRow[] resultRow = Dm_NhomDichVu.Select("FieldName LIKE '%" + text + "%'");
                    if (resultRow.Count() > 0)
                    {
                        DataTable dtResult = Dm_NhomDichVu.Select("FieldName LIKE '%" + text + "%'").CopyToDataTable();
                        cbbNhomDichVu.DataSource = dtResult;
                        cbbNhomDichVu.DroppedDown = true;
                    }
                    else
                    {
                        cbbNhomDichVu.DataSource = null;
                        cbbNhomDichVu.DroppedDown = true;
                    }
                }
            }
        }
        private void cbbNhomDichVu_Click(object sender, EventArgs e)
        {
            cbbNhomDichVu.DataSource = Dm_NhomDichVu;
            cbbNhomDichVu.DroppedDown = true;
        }
        private void txtGiaDichVu_KeyPress(object sender, KeyPressEventArgs e)
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

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "GiaDichVu")
            {
                if (e.Value != null && e.Value != DBNull.Value)
                {
                    double number;
                    if (double.TryParse(e.Value.ToString(), out number))
                    {
                        e.DisplayText = string.Format("{0:#,##0}", number);
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