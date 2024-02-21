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
    public partial class KTV : DevExpress.XtraEditors.XtraForm
    {
        public string DM_Id;
        public string ThaoTac;
        public KTV()
        {
            InitializeComponent();
        }

        private void KTV_Load(object sender, EventArgs e)
        {
            DataTable SelectKTV = Model.dbDanhMuc.SelectKTV();
            gridDichVu.DataSource = SelectKTV;
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
            txtTenKTV.Focus();
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
            txtTenKTV.Focus();
            //
            LoadThongTinForm();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtTenKTV.Text == "")
            {
                alertControl1.Show(this, "Thông báo", "Tên KTV không được để trống!", "");
            }
            else
            {
                string TenKTV = "N'" + txtTenKTV.Text.Replace("'", "''") + "'";
                string TamNgung = "0";
                if (cbTamNgung.Checked == false) { TamNgung = "0"; } else { TamNgung = "1"; }

                if (ThaoTac == "Them")
                {
                    DataTable Insert = Model.dbDanhMuc.InsertKTV(
                        TenKTV
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
                    DataTable Update = Model.dbDanhMuc.UpdateKTV(
                         TenKTV
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
                DataTable SelectKTV = Model.dbDanhMuc.SelectKTV();
                gridDichVu.DataSource = SelectKTV;
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
                    DataTable Delete = Model.dbDanhMuc.DeleteKTV(DM_Id, nguoicapnhat);
                    Reset();
                    DM_Id = "";
                    DataTable SelectKTV = Model.dbDanhMuc.SelectKTV();
                    gridDichVu.DataSource = SelectKTV;
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
                DM_Id = gridView1.GetRowCellValue(n, "KTV_Id").ToString();
                DataTable SelectKTVTheoID = Model.dbDanhMuc.SelectKTVTheoID(DM_Id);
                {
                    if (SelectKTVTheoID != null)
                    {
                        if (SelectKTVTheoID.Rows.Count > 0)
                        {
                            txtTenKTV.Text = SelectKTVTheoID.Rows[0]["TenKTV"].ToString();
                            string TamNgungTam = SelectKTVTheoID.Rows[0]["TamNgung"].ToString();
                            if (TamNgungTam == "0") { cbTamNgung.Checked = false; } else { cbTamNgung.Checked = true; }
                            btnThem.Enabled = false;
                            btnSua.Enabled = false;
                            btnLuu.Enabled = true;
                            btnHuy.Enabled = true;
                            btnXoa.Enabled = true;
                            Hien();
                            ThaoTac = "Sua";
                            txtTenKTV.Focus();
                        }
                    }
                }
            }
        }
        public void LoadThongTinForm()
        {
            DataTable SelectKTVTheoID = Model.dbDanhMuc.SelectKTVTheoID(DM_Id);
            {
                if (SelectKTVTheoID != null)
                {
                    if (SelectKTVTheoID.Rows.Count > 0)
                    {
                        txtTenKTV.Text = SelectKTVTheoID.Rows[0]["TenKTV"].ToString();
                        string TamNgungTam = SelectKTVTheoID.Rows[0]["TamNgung"].ToString();
                        if (TamNgungTam == "0") { cbTamNgung.Checked = false; } else { cbTamNgung.Checked = true; }
                    }
                }
            }
        }
        public void Hien()
        {
            txtTenKTV.Enabled = true;
            cbTamNgung.Enabled = true;
        }
        public void An()
        {
            txtTenKTV.Enabled = false;
            cbTamNgung.Enabled = false;
        }
        public void Reset()
        {
            txtTenKTV.Text = "";
            cbTamNgung.Checked = false;
        }
    }
}