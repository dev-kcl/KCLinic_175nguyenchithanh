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
    public partial class TuDienChanDoanKhamBenh : DevExpress.XtraEditors.XtraForm
    {
        public string DM_Id;
        public string ThaoTac;
        public TuDienChanDoanKhamBenh()
        {
            InitializeComponent();
        }

        private void TuDienChanDoanKhamBenh_Load(object sender, EventArgs e)
        {
            DataTable SelectTuDienChanDoanKhamBenh = Model.dbDanhMuc.SelectTuDienChanDoanKhamBenh();
            gridDichVu.DataSource = SelectTuDienChanDoanKhamBenh;
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
            txtMaMau.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            btnXoa.Enabled = false;
            Hien();
            Reset();
            ThaoTac = "Sua";
            txtMaMau.Focus();
            //
            LoadThongTinForm();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaMau.Text == "")
            {
                alertControl1.Show(this, "Thông báo", "Mã từ điển không được để trống! ", "");
            }
            else if (txtTenMau.Text == "")
            {
                alertControl1.Show(this, "Thông báo", "Tên từ điển không được để trống! ", "");
            }
            else
            {
                string MaMau = "null"; if (txtMaMau.Text != "") { MaMau = "N'" + txtMaMau.Text.Replace("'", "''") + "'"; }

                string TenMau = "null"; if (txtTenMau.Text != "") { TenMau = "N'" + txtTenMau.Text.Replace("'", "''") + "'"; }
                string STT = "null"; if (txtSTT.Text != "") { STT = "N'" + txtSTT.Text.Replace("'", "''") + "'"; }
                string TieuDe = "null"; if (txtTieuDe.Text != "") { TieuDe = "N'" + txtTieuDe.Text.Replace("'", "''") + "'"; }
                string ChanDoan = "null"; if (txtChanDoan.Text != "") { ChanDoan = "N'" + txtChanDoan.Text.Replace("'", "''") + "'"; }
                string LoiDan = "null"; if (txtLoiDan.Text != "") { LoiDan = "N'" + txtLoiDan.Text.Replace("'", "''") + "'"; }

                //string GioiTinh = "null";
                //if (cbbDichVu.SelectedValue != null)
                //{
                //    GioiTinh = "N'" + cbbDichVu.SelectedValue.ToString().Replace("'", "''") + "'";
                //}

                string TamNgung = "0";
                if (cbTamNgung.Checked == false) { TamNgung = "0"; } else { TamNgung = "1"; }

                string TinhNgayDuSinh = "0";

                if (ThaoTac == "Them")
                {
                    DataTable Insert = Model.dbDanhMuc.InsertTuDienChanDoanKhamBenh(
                        MaMau
                        , TenMau
                        , STT
                        , TieuDe
                        , ChanDoan
                        , TinhNgayDuSinh
                        , LoiDan
                        , TamNgung
                        , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                        , Login.User_Id
                        , "null"
                        , "null"
                        , "0"
                        );
                    if (Insert.Rows.Count > 0)
                    {
                        DM_Id = Insert.Rows[0]["TuDienChanDoan_Id"].ToString();
                        alertControl1.Show(this, "Thông báo", "Đã thêm thành công! " + Insert.Rows[0]["TenTuDien"].ToString(), "");
                    }
                }
                if (ThaoTac == "Sua")
                {
                    DataTable Update = Model.dbDanhMuc.UpdateTuDienChanDoanKhamBenh(
                           MaMau
                        , TenMau
                        , STT
                        , TieuDe
                        , ChanDoan
                        , TinhNgayDuSinh
                        , LoiDan
                        , TamNgung
                        , "null"
                        , "null"
                        , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                        , Login.User_Id
                        , "0"
                        , DM_Id
                        );
                    if (Update.Rows.Count > 0)
                    {
                        DM_Id = Update.Rows[0]["TuDienChanDoan_Id"].ToString();
                        alertControl1.Show(this, "Thông báo", "Đã sửa thành công! " + Update.Rows[0]["TenTuDien"].ToString(), "");
                    }
                }
                //
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnLuu.Enabled = false;
                btnHuy.Enabled = false;
                btnXoa.Enabled = true;
                An();
                DataTable SelectTuDienChanDoanKhamBenh = Model.dbDanhMuc.SelectTuDienChanDoanKhamBenh();
                gridDichVu.DataSource = SelectTuDienChanDoanKhamBenh;
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
                    DataTable Delete = Model.dbDanhMuc.DeleteTuDienChanDoanKhamBenh(DM_Id, nguoicapnhat);
                    Reset();
                    DM_Id = "";
                    DataTable SelectTuDienChanDoanKhamBenh = Model.dbDanhMuc.SelectTuDienChanDoanKhamBenh();
                    gridDichVu.DataSource = SelectTuDienChanDoanKhamBenh;
                    alertControl1.Show(this, "Thông báo", "Đã xóa thành công! " + Delete.Rows[0]["TenTuDien"].ToString(), "");
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
                DM_Id = gridView1.GetRowCellValue(n, "TuDienChanDoan_Id").ToString();
                DataTable SelectTuDienChanDoanKhamBenhTheoID = Model.dbDanhMuc.SelectTuDienChanDoanKhamBenhTheoID(DM_Id);
                {
                    if (SelectTuDienChanDoanKhamBenhTheoID != null)
                    {
                        if (SelectTuDienChanDoanKhamBenhTheoID.Rows.Count > 0)
                        {
                            txtMaMau.Text = SelectTuDienChanDoanKhamBenhTheoID.Rows[0]["MaTuDien"].ToString();
                            txtTenMau.Text = SelectTuDienChanDoanKhamBenhTheoID.Rows[0]["TenTuDien"].ToString();
                            txtSTT.Text = SelectTuDienChanDoanKhamBenhTheoID.Rows[0]["STT"].ToString();
                            txtTieuDe.Text = SelectTuDienChanDoanKhamBenhTheoID.Rows[0]["TieuDe"].ToString();
                            txtChanDoan.Text = SelectTuDienChanDoanKhamBenhTheoID.Rows[0]["ChanDoan"].ToString();
                            txtLoiDan.Text = SelectTuDienChanDoanKhamBenhTheoID.Rows[0]["LoiDan"].ToString();

                            //string GioiTinh = SelectTuDienKetLuanTheoID.Rows[0]["GioiTinh"].ToString();

                            string TamNgungTam = SelectTuDienChanDoanKhamBenhTheoID.Rows[0]["TamNgung"].ToString();
                            if (TamNgungTam == "0") { cbTamNgung.Checked = false; } else { cbTamNgung.Checked = true; }

                            //string TinhNgayDuSinh = SelectTuDienKetLuanTheoID.Rows[0]["TinhNgayDuSinh"].ToString();
                            //if (TinhNgayDuSinh == "0") { cbTinhNgayDuSinh.Checked = false; } else { cbTinhNgayDuSinh.Checked = true; }

                            btnThem.Enabled = false;
                            btnSua.Enabled = false;
                            btnLuu.Enabled = true;
                            btnHuy.Enabled = true;
                            btnXoa.Enabled = true;
                            Hien();
                            ThaoTac = "Sua";
                            txtMaMau.Focus();
                        }
                    }
                }
            }
        }
        public void LoadThongTinForm()
        {
            DataTable SelectTuDienChanDoanKhamBenhTheoID = Model.dbDanhMuc.SelectTuDienChanDoanKhamBenhTheoID(DM_Id);
            {
                if (SelectTuDienChanDoanKhamBenhTheoID != null)
                {
                    if (SelectTuDienChanDoanKhamBenhTheoID.Rows.Count > 0)
                    {
                        txtMaMau.Text = SelectTuDienChanDoanKhamBenhTheoID.Rows[0]["MaTuDien"].ToString();
                        txtTenMau.Text = SelectTuDienChanDoanKhamBenhTheoID.Rows[0]["TenTuDien"].ToString();
                        txtSTT.Text = SelectTuDienChanDoanKhamBenhTheoID.Rows[0]["STT"].ToString();
                        txtTieuDe.Text = SelectTuDienChanDoanKhamBenhTheoID.Rows[0]["TieuDe"].ToString();
                        txtChanDoan.Text = SelectTuDienChanDoanKhamBenhTheoID.Rows[0]["ChanDoan"].ToString();
                        txtLoiDan.Text = SelectTuDienChanDoanKhamBenhTheoID.Rows[0]["LoiDan"].ToString();


                        string TamNgungTam = SelectTuDienChanDoanKhamBenhTheoID.Rows[0]["TamNgung"].ToString();
                        if (TamNgungTam == "0") { cbTamNgung.Checked = false; } else { cbTamNgung.Checked = true; }

                    }
                }
            }
        }
        public void Hien()
        {
            txtMaMau.Enabled = true;
            txtTenMau.Enabled = true;
            txtSTT.Enabled = true;
            txtChanDoan.Enabled = true;
            txtTieuDe.Enabled = true;
            cbTamNgung.Enabled = true;
            txtLoiDan.Enabled = true;
        }
        public void An()
        {
            txtMaMau.Enabled = false;
            txtTenMau.Enabled = false;
            txtSTT.Enabled = false;
            txtChanDoan.Enabled = false;
            txtTieuDe.Enabled = false;
            cbTamNgung.Enabled = false;
            txtLoiDan.Enabled = false;
        }
        public void Reset()
        {
            txtMaMau.Text = "";
            txtTenMau.Text = "";
            txtSTT.Text = "";
            txtChanDoan.Text = "";
            txtTieuDe.Text = "";
            txtLoiDan.Text = "";
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