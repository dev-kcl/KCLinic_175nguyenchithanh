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
    public partial class TuDienKetLuan : DevExpress.XtraEditors.XtraForm
    {
        public string DM_Id;
        public string ThaoTac;
        public TuDienKetLuan()
        {
            InitializeComponent();
        }
        DataTable CBBDichVuTuDienKetLuan;
        private void TuDienKetLuan_Load(object sender, EventArgs e)
        {
            CBBDichVuTuDienKetLuan = Model.dbDanhMuc.CBBDichVuTuDienKetLuan();
            cbbDichVu.DataSource = CBBDichVuTuDienKetLuan;
            cbbDichVu.ValueMember = "FieldCode";
            cbbDichVu.DisplayMember = "FieldName";
            DataTable SelectTuDienKetLuan = Model.dbDanhMuc.SelectTuDienKetLuan();
            gridDichVu.DataSource = SelectTuDienKetLuan;
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
                string MoTa = "null"; if (txtMoTa.Document.Text != "") { MoTa = "N'" + txtMoTa.Document.RtfText.Replace("'", "''") + "'"; }
                string MoTaText = "null"; if (txtMoTa.Document.Text != "") { MoTaText = "N'" + txtMoTa.Document.Text.Replace("'", "''") + "'"; }
                string KetLuan = "null"; if (txtKetLuan.Text != "") { KetLuan = "N'" + txtKetLuan.Text.Replace("'", "''") + "'"; }
                string LoiDan = "null"; if (txtLoiDan.Text != "") { LoiDan = "N'" + txtLoiDan.Text.Replace("'", "''") + "'"; }

                string GioiTinh = "null";
                //if (cbbDichVu.SelectedValue != null)
                //{
                //    GioiTinh = "N'" + cbbDichVu.SelectedValue.ToString().Replace("'", "''") + "'";
                //}

                string DichVu_Id = "null";
                if (cbbDichVu.Value != null)
                {
                    DichVu_Id = "N'" + cbbDichVu.Value.ToString() + "'";
                }

                string TamNgung = "0";
                if (cbTamNgung.Checked == false) { TamNgung = "0"; } else { TamNgung = "1"; }

                string TinhNgayDuSinh = "0";
                //if (cbTinhNgayDuSinh.Checked == false) { TinhNgayDuSinh = "0"; } else { TinhNgayDuSinh = "1"; }

                if (ThaoTac == "Them")
                {
                    DataTable Insert = Model.dbDanhMuc.InsertTuDienKetLuan(
                        MaMau
                        , TenMau
                        , STT
                        , TieuDe
                        , GioiTinh
                        , ChanDoan
                        , TinhNgayDuSinh
                        , KetLuan
                        , MoTa
                        , MoTaText
                        , "null"
                        , LoiDan
                        , TamNgung
                        , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                        , Login.User_Id
                        , "null"
                        , "null"
                        , "0"
                        , DichVu_Id
                        );
                    if (Insert.Rows.Count > 0)
                    {
                        DM_Id = Insert.Rows[0]["TuDienKetLuan_Id"].ToString();
                        alertControl1.Show(this, "Thông báo", "Đã thêm thành công! " + Insert.Rows[0]["TenTuDien"].ToString(), "");
                    }
                }
                if (ThaoTac == "Sua")
                {
                    DataTable Update = Model.dbDanhMuc.UpdateTuDienKetLuan(
                           MaMau
                        , TenMau
                        , STT
                        , TieuDe
                        , GioiTinh
                        , ChanDoan
                        , TinhNgayDuSinh
                        , KetLuan
                        , MoTa
                        , MoTaText
                        , "null"
                        , LoiDan
                        , TamNgung
                        , "null"
                        , "null"
                        , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                        , Login.User_Id
                        , "0"
                        , DichVu_Id
                        , DM_Id
                        );
                    if (Update.Rows.Count > 0)
                    {
                        DM_Id = Update.Rows[0]["TuDienKetLuan_Id"].ToString();
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
                DataTable SelectTuDienKetLuan = Model.dbDanhMuc.SelectTuDienKetLuan();
                gridDichVu.DataSource = SelectTuDienKetLuan;
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
                    DataTable Delete = Model.dbDanhMuc.DeleteTuDienKetLuan(DM_Id, nguoicapnhat);
                    Reset();
                    DM_Id = "";
                    DataTable SelectTuDienKetLuan = Model.dbDanhMuc.SelectTuDienKetLuan();
                    gridDichVu.DataSource = SelectTuDienKetLuan;
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
                DM_Id = gridView1.GetRowCellValue(n, "TuDienKetLuan_Id").ToString();
                DataTable SelectTuDienKetLuanTheoID = Model.dbDanhMuc.SelectTuDienKetLuanTheoID(DM_Id);
                {
                    if (SelectTuDienKetLuanTheoID != null)
                    {
                        if (SelectTuDienKetLuanTheoID.Rows.Count > 0)
                        {
                            txtMaMau.Text = SelectTuDienKetLuanTheoID.Rows[0]["MaTuDien"].ToString();
                            txtTenMau.Text = SelectTuDienKetLuanTheoID.Rows[0]["TenTuDien"].ToString();
                            txtSTT.Text = SelectTuDienKetLuanTheoID.Rows[0]["STT"].ToString();
                            txtTieuDe.Text = SelectTuDienKetLuanTheoID.Rows[0]["TieuDe"].ToString();
                            txtChanDoan.Text = SelectTuDienKetLuanTheoID.Rows[0]["ChanDoan"].ToString();
                            txtMoTa.Document.RtfText = SelectTuDienKetLuanTheoID.Rows[0]["MoTa"].ToString();
                            txtKetLuan.Text = SelectTuDienKetLuanTheoID.Rows[0]["KetLuan"].ToString();
                            txtLoiDan.Text = SelectTuDienKetLuanTheoID.Rows[0]["LoiDan"].ToString();

                            //string GioiTinh = SelectTuDienKetLuanTheoID.Rows[0]["GioiTinh"].ToString();
                            string DichVu_Id = SelectTuDienKetLuanTheoID.Rows[0]["DichVu_Id"].ToString();
                            if (!String.IsNullOrEmpty(DichVu_Id))
                            {
                                cbbDichVu.Value = Int32.Parse(DichVu_Id);
                            }
                            else { cbbDichVu.Text = ""; }

                            string TamNgungTam = SelectTuDienKetLuanTheoID.Rows[0]["TamNgung"].ToString();
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
            DataTable SelectTuDienKetLuanTheoID = Model.dbDanhMuc.SelectTuDienKetLuanTheoID(DM_Id);
            {
                if (SelectTuDienKetLuanTheoID != null)
                {
                    if (SelectTuDienKetLuanTheoID.Rows.Count > 0)
                    {
                        txtMaMau.Text = SelectTuDienKetLuanTheoID.Rows[0]["MaTuDien"].ToString();
                        txtTenMau.Text = SelectTuDienKetLuanTheoID.Rows[0]["TenTuDien"].ToString();
                        txtSTT.Text = SelectTuDienKetLuanTheoID.Rows[0]["STT"].ToString();
                        txtTieuDe.Text = SelectTuDienKetLuanTheoID.Rows[0]["TieuDe"].ToString();
                        txtChanDoan.Text = SelectTuDienKetLuanTheoID.Rows[0]["ChanDoan"].ToString();
                        txtMoTa.Document.RtfText = SelectTuDienKetLuanTheoID.Rows[0]["MoTa"].ToString();
                        txtKetLuan.Text = SelectTuDienKetLuanTheoID.Rows[0]["KetLuan"].ToString();
                        txtLoiDan.Text = SelectTuDienKetLuanTheoID.Rows[0]["LoiDan"].ToString();

                        string DichVu_Id = SelectTuDienKetLuanTheoID.Rows[0]["DichVu_Id"].ToString();
                        if (!String.IsNullOrEmpty(DichVu_Id))
                        {
                            cbbDichVu.Value = Int32.Parse(DichVu_Id);
                        }
                        else { cbbDichVu.Text = ""; }
                        //string GioiTinh = SelectTuDienKetLuanTheoID.Rows[0]["GioiTinh"].ToString();
                        //if (!String.IsNullOrEmpty(GioiTinh))
                        //{
                        //    cbbDichVu.SelectedValue = GioiTinh;
                        //}

                        string TamNgungTam = SelectTuDienKetLuanTheoID.Rows[0]["TamNgung"].ToString();
                        if (TamNgungTam == "0") { cbTamNgung.Checked = false; } else { cbTamNgung.Checked = true; }

                        //string TinhNgayDuSinh = SelectTuDienKetLuanTheoID.Rows[0]["TinhNgayDuSinh"].ToString();
                        //if (TinhNgayDuSinh == "0") { cbTinhNgayDuSinh.Checked = false; } else { cbTinhNgayDuSinh.Checked = true; }
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
            cbbDichVu.Enabled = true;
            cbTamNgung.Enabled = true;
            //cbTinhNgayDuSinh.Enabled = true;
            txtMoTa.Enabled = true;
            txtKetLuan.Enabled = true;
            txtLoiDan.Enabled = true;
        }
        public void An()
        {
            txtMaMau.Enabled = false;
            txtTenMau.Enabled = false;
            txtSTT.Enabled = false;
            txtChanDoan.Enabled = false;
            txtTieuDe.Enabled = false;
            cbbDichVu.Enabled = false;
            cbTamNgung.Enabled = false;
            //cbTinhNgayDuSinh.Enabled = false;
            txtMoTa.Enabled = false;
            txtKetLuan.Enabled = false;
            txtLoiDan.Enabled = false;
        }
        public void Reset()
        {
            txtMaMau.Text = "";
            txtTenMau.Text = "";
            txtSTT.Text = "";
            txtChanDoan.Text = "";
            txtTieuDe.Text = "";
            cbbDichVu.Text = "";
            txtMoTa.Document.Text = "";
            txtKetLuan.Text = "";
            txtLoiDan.Text = "";
            cbTamNgung.Checked = false;
            //cbTinhNgayDuSinh.Checked = false;
        }

        private void cbbDichVu_KeyDown(object sender, KeyEventArgs e)
        {
            //string text = cbbDichVu.Text;
            //DataRow[] resultRow = CBBDichVuTuDienKetLuan.Select("FieldName LIKE '" + text + "%' or MaDichVu LIKE '" + text + "%'");
            //if (resultRow.Count() > 0)
            //{
            //    DataTable dtResult = CBBDichVuTuDienKetLuan.Select("FieldName LIKE '" + text + "%' or MaDichVu LIKE '" + text + "%'").CopyToDataTable();
            //    cbbDichVu.DataSource = dtResult;
            //    cbbDichVu.DroppedDown = true;
            //}
            //else
            //{
            //    cbbDichVu.DataSource = null;
            //    cbbDichVu.DroppedDown = true;
            //}
        }

        private void txtMoTa_DocumentLoaded(object sender, EventArgs e)
        {
            // Set the default font, size and forecolor
            txtMoTa.Document.DefaultCharacterProperties.FontName = "Times new roman";
            txtMoTa.Document.DefaultCharacterProperties.FontSize = 14;
        }

        private void cbbDichVu_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Tab && e.KeyData != Keys.Enter && e.KeyData != Keys.Up && e.KeyData != Keys.Down && e.KeyData != Keys.Right && e.KeyData != Keys.Left)
            {
                string text = cbbDichVu.Text;
                DataRow[] resultRow = CBBDichVuTuDienKetLuan.Select("FieldName LIKE '" + text + "%' or MaDichVu LIKE '" + text + "%'");
                if (resultRow.Count() > 0)
                {
                    DataTable dtResult = CBBDichVuTuDienKetLuan.Select("FieldName LIKE '" + text + "%' or MaDichVu LIKE '" + text + "%'").CopyToDataTable();
                    cbbDichVu.DataSource = dtResult;
                    cbbDichVu.DroppedDown = true;
                }
                else
                {
                    cbbDichVu.DataSource = null;
                    cbbDichVu.DroppedDown = true;
                }
            }
        }

        private void cbbDichVu_Click(object sender, EventArgs e)
        {
            cbbDichVu.DataSource = CBBDichVuTuDienKetLuan;
            cbbDichVu.DroppedDown = true;
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