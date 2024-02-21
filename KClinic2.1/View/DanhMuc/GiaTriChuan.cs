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
    public partial class GiaTriChuan : DevExpress.XtraEditors.XtraForm
    {
        public string DM_Id;
        public string ThaoTac;
        public GiaTriChuan()
        {
            InitializeComponent();
        }

        private void GiaTriChuan_Load(object sender, EventArgs e)
        {
            DataTable SelectDichVu = Model.dbDanhMuc.SelectDichVuGiaTriChuan();
            gridDichVu.DataSource = SelectDichVu;
            DataTable CBBDichVu = Model.dbDanhMuc.CBBDichVu();
            cbbDichVu.DataSource = CBBDichVu;
            cbbDichVu.ValueMember = "FieldCode";
            cbbDichVu.DisplayMember = "FieldName";
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
            txtNamMax.Focus();
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
            txtNamMax.Focus();
            //
            LoadThongTinForm();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string GiaTriDungChung = "N'" + txtGiaTriDungChung.Text.Replace("'", "''") + "'";
            string NamMax = "N'" + txtNamMax.Text.Replace("'", "''") + "'";
            string NamMin = "N'" + txtNamMin.Text.Replace("'", "''") + "'";
            string NuMax = "N'" + txtNuMax.Text.Replace("'", "''") + "'";
            string NuMin = "N'" + txtNuMin.Text.Replace("'", "''") + "'";
            string TreEmMax = "N'" + txtTreEmMax.Text.Replace("'", "''") + "'";
            string TreEmMin = "N'" + txtTreEmMin.Text.Replace("'", "''") + "'";
            string TamNgung = "0";
            if (cbTamNgung.Checked == false) { TamNgung = "0"; } else { TamNgung = "1"; }
            string DichVu_Id = "null";
            if (cbbDichVu.SelectedItem != null) { DichVu_Id = cbbDichVu.SelectedValue.ToString(); }

            if (ThaoTac == "Them")
            {
                DataTable CheckDichVuGiaTriChuan = Model.dbDanhMuc.CheckDichVuGiaTriChuan(DichVu_Id);
                if (CheckDichVuGiaTriChuan.Rows.Count > 0)
                {
                    if (CheckDichVuGiaTriChuan.Rows[0]["SoLuong"].ToString() == "0")
                    {
                        DataTable Insert = Model.dbDanhMuc.InsertDichVuGiaTriChuan(
                        DichVu_Id
                        , GiaTriDungChung
                        , NamMax
                        , NamMin
                        , NuMax
                        , NuMin
                        , TreEmMax
                        , TreEmMin
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
                        //
                        btnThem.Enabled = true;
                        btnSua.Enabled = true;
                        btnLuu.Enabled = false;
                        btnHuy.Enabled = false;
                        btnXoa.Enabled = true;
                        An();
                        DataTable SelectDichVu = Model.dbDanhMuc.SelectDichVuGiaTriChuan();
                        gridDichVu.DataSource = SelectDichVu;
                        DataTable CBBDichVu = Model.dbDanhMuc.CBBDichVu();
                        cbbDichVu.DataSource = CBBDichVu;
                        cbbDichVu.ValueMember = "FieldCode";
                        cbbDichVu.DisplayMember = "FieldName";
                    }
                    else
                    {
                        alertControl1.Show(this, "Thông báo", "Dịch vụ này đã có giá trị chuẩn. Vui lòng kiểm tra lại!", "");
                    }
                }


            }
            if (ThaoTac == "Sua")
            {
                DataTable Update = Model.dbDanhMuc.UpdateDichVuGiaTriChuan(
                      DichVu_Id
                    , GiaTriDungChung
                    , NamMax
                    , NamMin
                    , NuMax
                    , NuMin
                    , TreEmMax
                    , TreEmMin
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
                //
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnLuu.Enabled = false;
                btnHuy.Enabled = false;
                btnXoa.Enabled = true;
                An();
                DataTable SelectDichVu = Model.dbDanhMuc.SelectDichVuGiaTriChuan();
                gridDichVu.DataSource = SelectDichVu;
                DataTable CBBDichVu = Model.dbDanhMuc.CBBDichVu();
                cbbDichVu.DataSource = CBBDichVu;
                cbbDichVu.ValueMember = "FieldCode";
                cbbDichVu.DisplayMember = "FieldName";
            }
            //
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
                    DataTable Delete = Model.dbDanhMuc.DeleteDichVuGiaTriChuan(DM_Id, nguoicapnhat);
                    Reset();
                    DM_Id = "";
                    DataTable SelectDichVu = Model.dbDanhMuc.SelectDichVuGiaTriChuan();
                    gridDichVu.DataSource = SelectDichVu;
                    DataTable CBBDichVu = Model.dbDanhMuc.CBBDichVu();
                    cbbDichVu.DataSource = CBBDichVu;
                    cbbDichVu.ValueMember = "FieldCode";
                    cbbDichVu.DisplayMember = "FieldName";
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
                DM_Id = gridView1.GetRowCellValue(n, "GiaTriChuan_Id").ToString();
                DataTable SelectDichVuGiaTriChuanTheoID = Model.dbDanhMuc.SelectDichVuGiaTriChuanTheoID(DM_Id);
                {
                    if (SelectDichVuGiaTriChuanTheoID != null)
                    {
                        if (SelectDichVuGiaTriChuanTheoID.Rows.Count > 0)
                        {
                            txtGiaTriDungChung.Text = SelectDichVuGiaTriChuanTheoID.Rows[0]["GiaTriDungChung"].ToString();
                            txtNamMax.Text = SelectDichVuGiaTriChuanTheoID.Rows[0]["NamMax"].ToString();
                            txtNamMin.Text = SelectDichVuGiaTriChuanTheoID.Rows[0]["NamMin"].ToString();
                            txtNuMax.Text = SelectDichVuGiaTriChuanTheoID.Rows[0]["NuMax"].ToString();
                            txtNuMin.Text = SelectDichVuGiaTriChuanTheoID.Rows[0]["NuMin"].ToString();
                            txtTreEmMax.Text = SelectDichVuGiaTriChuanTheoID.Rows[0]["TreEmMax"].ToString();
                            txtTreEmMin.Text = SelectDichVuGiaTriChuanTheoID.Rows[0]["TreEmMin"].ToString();
                            string TamNgungTam = SelectDichVuGiaTriChuanTheoID.Rows[0]["TamNgung"].ToString();
                            if (TamNgungTam == "0") { cbTamNgung.Checked = false; } else { cbTamNgung.Checked = true; }
                            string DichVu_Id = SelectDichVuGiaTriChuanTheoID.Rows[0]["DichVu_Id"].ToString();
                            if (!String.IsNullOrEmpty(DichVu_Id))
                            {
                                cbbDichVu.SelectedValue = Int32.Parse(DichVu_Id);
                            }
                            btnThem.Enabled = false;
                            btnSua.Enabled = false;
                            btnLuu.Enabled = true;
                            btnHuy.Enabled = true;
                            btnXoa.Enabled = true;
                            Hien();
                            ThaoTac = "Sua";
                            txtNamMax.Focus();
                        }
                    }
                }
            }
        }
        public void LoadThongTinForm()
        {
            DataTable SelectDichVuGiaTriChuanTheoID = Model.dbDanhMuc.SelectDichVuGiaTriChuanTheoID(DM_Id);
            {
                if (SelectDichVuGiaTriChuanTheoID != null)
                {
                    if (SelectDichVuGiaTriChuanTheoID.Rows.Count > 0)
                    {
                        txtGiaTriDungChung.Text = SelectDichVuGiaTriChuanTheoID.Rows[0]["GiaTriDungChung"].ToString();
                        txtNamMax.Text = SelectDichVuGiaTriChuanTheoID.Rows[0]["NamMax"].ToString();
                        txtNamMin.Text = SelectDichVuGiaTriChuanTheoID.Rows[0]["NamMin"].ToString();
                        txtNuMax.Text = SelectDichVuGiaTriChuanTheoID.Rows[0]["NuMax"].ToString();
                        txtNuMin.Text = SelectDichVuGiaTriChuanTheoID.Rows[0]["NuMin"].ToString();
                        txtTreEmMax.Text = SelectDichVuGiaTriChuanTheoID.Rows[0]["TreEmMax"].ToString();
                        txtTreEmMin.Text = SelectDichVuGiaTriChuanTheoID.Rows[0]["TreEmMin"].ToString();
                        string TamNgungTam = SelectDichVuGiaTriChuanTheoID.Rows[0]["TamNgung"].ToString();
                        if (TamNgungTam == "0") { cbTamNgung.Checked = false; } else { cbTamNgung.Checked = true; }
                        string DichVu_Id = SelectDichVuGiaTriChuanTheoID.Rows[0]["DichVu_Id"].ToString();
                        if (!String.IsNullOrEmpty(DichVu_Id))
                        {
                            cbbDichVu.SelectedValue = Int32.Parse(DichVu_Id);
                        }
                    }
                }
            }
        }
        public void Hien()
        {
            txtGiaTriDungChung.Enabled = true;
            txtNamMax.Enabled = true;
            txtNamMin.Enabled = true;
            txtNuMax.Enabled = true;
            txtNuMin.Enabled = true;
            txtTreEmMax.Enabled = true;
            txtTreEmMin.Enabled = true;
            cbTamNgung.Enabled = true;
            cbbDichVu.Enabled = true;
        }
        public void An()
        {
            txtGiaTriDungChung.Enabled = false;
            txtNamMax.Enabled = false;
            txtNamMin.Enabled = false;
            txtNuMax.Enabled = false;
            txtNuMin.Enabled = false;
            txtTreEmMax.Enabled = false;
            txtTreEmMin.Enabled = false;
            cbTamNgung.Enabled = false;
            cbbDichVu.Enabled = false;
        }
        public void Reset()
        {
            txtGiaTriDungChung.Text = "";
            txtNamMax.Text = "";
            txtNamMin.Text = "";
            txtNuMax.Text = "";
            txtNuMin.Text = "";
            txtTreEmMax.Text = "";
            txtTreEmMin.Text = "";
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