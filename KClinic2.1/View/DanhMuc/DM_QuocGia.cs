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
    public partial class DM_QuocGia : DevExpress.XtraEditors.XtraForm
    {
        public string DM_Id;
        public string ThaoTac;
        public DM_QuocGia()
        {
            InitializeComponent();
        }

        private void DM_QuocGia_Load(object sender, EventArgs e)
        {
            DataTable SelectQuocGia = Model.dbDanhMuc.SelectQuocGia();
            gridDichVu.DataSource = SelectQuocGia;
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
            txtMaQuocGia.Focus();
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
            txtMaQuocGia.Focus();
            //
            LoadThongTinForm();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaQuocGia.Text == "")
            {
                alertControl1.Show(this, "Thông báo", "Mã quốc gia không được để trống! ", "");
            }
            else if (txtTenQuocGia.Text == "")
            {
                alertControl1.Show(this, "Thông báo", "Tên quốc gia không được để trống! ", "");
            }
            else
            {
                string MaQuocGia = "N'" + txtMaQuocGia.Text.Replace("'", "''") + "'";
                string TenQuocGia = "N'" + txtTenQuocGia.Text.Replace("'", "''") + "'";
                string TamNgung = "0";
                if (cbTamNgung.Checked == false) { TamNgung = "0"; } else { TamNgung = "1"; }
                string TenTiengAnh = "N'" + txtTenTiengAnh.Text.Replace("'", "''") + "'";
                string TenTiengLaTin = "N'" + txtTenTiengLaTin.Text.Replace("'", "''") + "'";
                string MaQuocTe = "N'" + txtMaQuocTe.Text.Replace("'", "''") + "'";

                if (ThaoTac == "Them")
                {
                    DataTable Insert = Model.dbDanhMuc.InsertQuocGia(
                        MaQuocGia
                        , TenQuocGia
                        , TenTiengAnh
                        , TenTiengLaTin
                        , MaQuocTe
                        , TamNgung
                        , "0"
                        , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                        , Login.User_Id
                        , "null"
                        , "null"
                        );
                    if (Insert.Rows.Count > 0)
                    {
                        DM_Id = Insert.Rows[0]["QuocGia_Id"].ToString();
                        alertControl1.Show(this, "Thông báo", "Đã thêm thành công! " + Insert.Rows[0]["TenQuocGia"].ToString(), "");
                    }
                }
                if (ThaoTac == "Sua")
                {
                    DataTable Update = Model.dbDanhMuc.UpdateQuocGia(
                          DM_Id
                        , MaQuocGia
                        , TenQuocGia
                        , TenTiengAnh
                        , TenTiengLaTin
                        , MaQuocTe
                        , TamNgung
                        , "0"
                        , "null"
                        , "null"
                        , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                        , Login.User_Id
                        );
                    if (Update.Rows.Count > 0)
                    {
                        DM_Id = Update.Rows[0]["QuocGia_Id"].ToString();
                        alertControl1.Show(this, "Thông báo", "Đã sửa thành công! " + Update.Rows[0]["TenQuocGia"].ToString(), "");
                    }
                }
                //
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnLuu.Enabled = false;
                btnHuy.Enabled = false;
                btnXoa.Enabled = true;
                An();
                DataTable SelectQuocGia = Model.dbDanhMuc.SelectQuocGia();
                gridDichVu.DataSource = SelectQuocGia;
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
                    DataTable Delete = Model.dbDanhMuc.DeleteQuocGia(DM_Id, nguoicapnhat);
                    Reset();
                    DM_Id = "";
                    DataTable SelectQuocGia = Model.dbDanhMuc.SelectQuocGia();
                    gridDichVu.DataSource = SelectQuocGia;
                    alertControl1.Show(this, "Thông báo", "Đã xóa thành công! " + Delete.Rows[0]["TenQuocGia"].ToString(), "");
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
                DM_Id = gridView1.GetRowCellValue(n, "QuocGia_Id").ToString();
                DataTable SelectQuocGiaTheoID = Model.dbDanhMuc.SelectQuocGiaTheoID(DM_Id);
                {
                    if (SelectQuocGiaTheoID != null)
                    {
                        if (SelectQuocGiaTheoID.Rows.Count > 0)
                        {
                            txtMaQuocGia.Text = SelectQuocGiaTheoID.Rows[0]["MaQuocGia"].ToString();
                            txtTenQuocGia.Text = SelectQuocGiaTheoID.Rows[0]["TenQuocGia"].ToString();
                            string TamNgungTam = SelectQuocGiaTheoID.Rows[0]["TamNgung"].ToString();
                            if (TamNgungTam == "0") { cbTamNgung.Checked = false; } else { cbTamNgung.Checked = true; }
                            txtTenTiengAnh.Text = SelectQuocGiaTheoID.Rows[0]["TenTiengAnh"].ToString();
                            txtTenTiengLaTin.Text = SelectQuocGiaTheoID.Rows[0]["TenLaTin"].ToString();
                            txtMaQuocTe.Text = SelectQuocGiaTheoID.Rows[0]["TenTat"].ToString();
                            btnThem.Enabled = false;
                            btnSua.Enabled = false;
                            btnLuu.Enabled = true;
                            btnHuy.Enabled = true;
                            btnXoa.Enabled = true;
                            Hien();
                            ThaoTac = "Sua";
                            txtMaQuocGia.Focus();
                        }
                    }
                }
            }
        }
        public void LoadThongTinForm()
        {
            DataTable SelectQuocGiaTheoID = Model.dbDanhMuc.SelectQuocGiaTheoID(DM_Id);
            {
                if (SelectQuocGiaTheoID != null)
                {
                    if (SelectQuocGiaTheoID.Rows.Count > 0)
                    {
                        txtMaQuocGia.Text = SelectQuocGiaTheoID.Rows[0]["MaQuocGia"].ToString();
                        txtTenQuocGia.Text = SelectQuocGiaTheoID.Rows[0]["TenQuocGia"].ToString();
                        string TamNgungTam = SelectQuocGiaTheoID.Rows[0]["TamNgung"].ToString();
                        if (TamNgungTam == "0") { cbTamNgung.Checked = false; } else { cbTamNgung.Checked = true; }
                        txtTenTiengAnh.Text = SelectQuocGiaTheoID.Rows[0]["TenTiengAnh"].ToString();
                        txtTenTiengLaTin.Text = SelectQuocGiaTheoID.Rows[0]["TenLaTin"].ToString();
                        txtMaQuocTe.Text = SelectQuocGiaTheoID.Rows[0]["TenTat"].ToString();
                    }
                }
            }
        }
        public void Hien()
        {
            txtMaQuocGia.Enabled = true;
            txtTenQuocGia.Enabled = true;
            cbTamNgung.Enabled = true;
            txtTenTiengAnh.Enabled = true;
            txtTenTiengLaTin.Enabled = true;
            txtMaQuocTe.Enabled = true;
        }
        public void An()
        {
            txtMaQuocGia.Enabled = false;
            txtTenQuocGia.Enabled = false;
            cbTamNgung.Enabled = false;
            txtTenTiengAnh.Enabled = false;
            txtTenTiengLaTin.Enabled = false;
            txtMaQuocTe.Enabled = false;
        }
        public void Reset()
        {
            txtMaQuocGia.Text = "";
            txtTenQuocGia.Text = "";
            cbTamNgung.Checked = false;
            txtTenTiengAnh.Text = "";
            txtTenTiengLaTin.Text = "";
            txtMaQuocTe.Text = "";
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