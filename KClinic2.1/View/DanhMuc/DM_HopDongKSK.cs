using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KClinic2._1.View.DanhMuc
{
    public partial class DM_HopDongKSK : DevExpress.XtraEditors.XtraForm
    {
        
        DataTable HinhThucThanhToan;
        public string HD_Id;

        public string ThaoTac;
        public DM_HopDongKSK()
        {
            InitializeComponent();

        }

        private void DM_HopDongKSK_Load(object sender, EventArgs e)
        {
            DataTable SelectAllHopDongKSK = Model.dbDanhMuc.SelectAllHopDongKSK();
            gridHopDongKSK.DataSource = SelectAllHopDongKSK;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            btnXoa.Enabled = false;
            
            btnTimKiem.Enabled = true;
            getdata();

        }

        void getdata()
        {
            HinhThucThanhToan = Model.HoaDondb.HinhThucThanhToan();
            cbbHinhThucThanhToan.DataSource = HinhThucThanhToan;
            cbbHinhThucThanhToan.DisplayMember = "FieldName";
            cbbHinhThucThanhToan.ValueMember = "FieldCode";


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
            HD_Id = "";
            txtTenCongTy.Focus();
            Reset();
        }

        public void Hien()
        {
            txtTenCongTy.Enabled = true;
            txtMaHopDong.Enabled = true;
            txtSoHopDong.Enabled = true;

            txtNgayHopDong.Enabled = true;
            txtGiaTriHopDong.Enabled = true;
            txtNgayHieuLucHopDong.Enabled = true;

            txtNgayHetHieuLucHopDong.Enabled = true;
            txtSoLuongBN.Enabled = true;
            cbbHinhThucThanhToan.Enabled = true;

            txtGiaTriTamUng.Enabled = true;
            txtGiaTriPhatSinh.Enabled = true;
            txtDienGiai.Enabled = true;
        }

        public void An()
        {
            txtTenCongTy.Enabled = false;
            txtMaHopDong.Enabled = false;
            txtSoHopDong.Enabled = false;

            txtNgayHopDong.Enabled = false;
            txtGiaTriHopDong.Enabled = false;
            txtNgayHieuLucHopDong.Enabled = false;

            txtNgayHetHieuLucHopDong.Enabled = false;
            txtSoLuongBN.Enabled = false;
            cbbHinhThucThanhToan.Enabled = false;

            txtGiaTriTamUng.Enabled = false;
            txtGiaTriPhatSinh.Enabled = false;
            txtDienGiai.Enabled = false;
        }
        public void Reset()
        {
            txtTenCongTy.Text = "";
            txtMaHopDong.Text = "";
            txtSoHopDong.Text = "";

            txtNgayHopDong.Text = "";
            txtGiaTriHopDong.Text = "";
            txtNgayHieuLucHopDong.Text = "";

            txtNgayHetHieuLucHopDong.Text = "";
            txtSoLuongBN.Text = "";
            HinhThucThanhToan = Model.HoaDondb.HinhThucThanhToan();
            cbbHinhThucThanhToan.DataSource = HinhThucThanhToan;

            txtGiaTriTamUng.Text = "";
            txtGiaTriPhatSinh.Text = "";
            txtDienGiai.Text = "";

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtTenCongTy.Text == "")
            {
                alertControl1.Show(this, "Thông báo", "Tên công ty không được để trống! ", "");
            }
            else if (txtMaHopDong.Text == "")
            {
                alertControl1.Show(this, "Thông báo", "Mã hợp đồng không được để trống! ", "");
            }
            else if (txtSoHopDong.Text == "")
            {
                alertControl1.Show(this, "Thông báo", "Số hợp đồng không được để trống! ", "");
            }
            else
            {
                //txtTenCongTy.Enabled = true;
                //txtMaHopDong.Enabled = true;
                //txtSoHopDong.Enabled = true;

                //txtNgayHopDong.Enabled = true;
                //txtGiaTriHopDong.Enabled = true;
                //txtNgayHieuLucHopDong.Enabled = true;

                //txtNgayHetHieuLucHopDong.Enabled = true;
                //txtSoLuongBN.Enabled = true;
                //cbbHinhThucThanhToan.Enabled = true;

                //txtGiaTriTamUng.Enabled = true;
                //txtGiaTriPhatSinh.Enabled = true;
                //txtDienGiai.Enabled = true;



                string TenCongTy = "N'" + txtTenCongTy.Text.Replace("'", "''") + "'";
                string MaHopDong = "N'" + txtMaHopDong.Text.Replace("'", "''") + "'";
                string SoHopDong = "N'" + txtSoHopDong.Text.Replace("'", "''") + "'";

                string NgayHopDong = "null";
                if (txtNgayHopDong.Value.ToString() != "") { NgayHopDong = "'" + txtNgayHopDong.Value.ToString("yyyyMMdd") + "'"; }

                string GiaTriHopDong = "0";
                if (txtGiaTriHopDong.Text.Length > 0) { GiaTriHopDong = "N'" + txtGiaTriHopDong.Text.Replace("'", "''") + "'"; }
                string NgayHieuLucHopDong = "null";
                if (txtNgayHieuLucHopDong.Value.ToString() != "") { NgayHieuLucHopDong = "'" + txtNgayHieuLucHopDong.Value.ToString("yyyyMMdd") + "'"; }

                string NgayHetHieuLucHopDong = "null";
                if (txtNgayHetHieuLucHopDong.Value.ToString() != "") { NgayHetHieuLucHopDong = "'" + txtNgayHetHieuLucHopDong.Value.ToString("yyyyMMdd") + "'"; }
                string SoLuongBN = "null";
                if (txtSoLuongBN.Text != "") { SoLuongBN = "N'" + txtSoLuongBN.Text + "'"; ; }
                string HinhThucThanhToan = "null";
                if (cbbHinhThucThanhToan.SelectedItem != null) { HinhThucThanhToan = cbbHinhThucThanhToan.SelectedValue.ToString(); }

                string GiaTriTamUng = "0";
                if (txtGiaTriTamUng.Text.Length > 0) { GiaTriTamUng = "N'" + txtGiaTriTamUng.Text.Replace("'", "''") + "'"; }
                string GiaTriPhatSinh = "0";
                if (txtGiaTriPhatSinh.Text.Length > 0) { GiaTriPhatSinh = "N'" + txtGiaTriPhatSinh.Text.Replace("'", "''") + "'"; }
               
                string DienGiai = "N'" + txtDienGiai.Text.Replace("'", "''") + "'";



                if (ThaoTac == "Them")
                {
                    DataTable Insert = Model.dbDanhMuc.InsertHopDongKSK(
                      TenCongTy
                    , MaHopDong
                    , SoHopDong
                    , NgayHopDong
                    , GiaTriHopDong
                    , NgayHieuLucHopDong
                    , NgayHetHieuLucHopDong
                    , SoLuongBN
                    , HinhThucThanhToan
                    , GiaTriTamUng
                    , GiaTriPhatSinh
                    , DienGiai
                    , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                    , Login.User_Id
                    , "null"
                    , "null"
                    , "0"

                    );
                    if (Insert.Rows.Count > 0)
                    {
                        HD_Id = Insert.Rows[0][0].ToString();
                        alertControl1.Show(this, "Thông báo", "Đã thêm thành công! ", "");
                    }
                }
                if (ThaoTac == "Sua")
                {
                    DataTable Update = Model.dbDanhMuc.UpdateHopDongKSK(
                        TenCongTy
                    , MaHopDong
                    , SoHopDong
                     , NgayHopDong
                    , GiaTriHopDong
                    , NgayHieuLucHopDong
                    , NgayHetHieuLucHopDong
                     , SoLuongBN
                     , HinhThucThanhToan
                    , GiaTriTamUng
                    , GiaTriPhatSinh
                    , DienGiai
                    , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                    , Login.User_Id
                    , HD_Id
                    );
                    if (Update.Rows.Count > 0)
                    {
                        HD_Id = Update.Rows[0][0].ToString();
                        alertControl1.Show(this, "Thông báo", "Đã sửa thành công! ", "");
                    }
                }


                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnLuu.Enabled = false;
                btnHuy.Enabled = false;
                btnXoa.Enabled = true;
                An();
                DataTable SelectAllHopDongKSK = Model.dbDanhMuc.SelectAllHopDongKSK();
                gridHopDongKSK.DataSource = SelectAllHopDongKSK;
            }
        }

        private void gridView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            int n = e.RowHandle;
            if (gridView.RowCount > 0)
            {

                HD_Id = gridView.GetRowCellValue(n, "HopDong_ID").ToString();
                DataTable SelectHopDongKSKTheoID = Model.dbDanhMuc.SelectHopDongKSKTheoID(HD_Id);
                {
                    if (SelectHopDongKSKTheoID != null)
                    {
                        if (SelectHopDongKSKTheoID.Rows.Count > 0)
                        {
                            txtTenCongTy.Text = SelectHopDongKSKTheoID.Rows[0]["TenCongTy"].ToString();
                            txtMaHopDong.Text = SelectHopDongKSKTheoID.Rows[0]["MaHopDong"].ToString();
                            txtSoHopDong.Text = SelectHopDongKSKTheoID.Rows[0]["So_HD"].ToString();


                            string Ngay_HD = SelectHopDongKSKTheoID.Rows[0]["Ngay_HD"].ToString();
                            if (!String.IsNullOrEmpty(Ngay_HD))
                            {
                                DateTime enteredDate = DateTime.Parse(Ngay_HD);
                                txtNgayHopDong.Value = enteredDate;
                            }
                            txtGiaTriHopDong.Text = SelectHopDongKSKTheoID.Rows[0]["GiaTri_HD"].ToString();
                            string NgayHieuLuc_HD = SelectHopDongKSKTheoID.Rows[0]["NgayHieuLuc_HD"].ToString();
                            if (!String.IsNullOrEmpty(NgayHieuLuc_HD))
                            {
                                DateTime enteredDate = DateTime.Parse(NgayHieuLuc_HD);
                                txtNgayHieuLucHopDong.Value = enteredDate;
                            }

                            string NgayHetHieuLuc_HD = SelectHopDongKSKTheoID.Rows[0]["NgayHetHieuLuc_HD"].ToString();
                            if (!String.IsNullOrEmpty(Ngay_HD))
                            {
                                DateTime enteredDate = DateTime.Parse(NgayHetHieuLuc_HD);
                                txtNgayHetHieuLucHopDong.Value = enteredDate;
                            }
                            txtSoLuongBN.Text = SelectHopDongKSKTheoID.Rows[0]["Soluong_BN"].ToString();
                            string sHinhThucThanhToan = "null";
                            sHinhThucThanhToan = SelectHopDongKSKTheoID.Rows[0]["HinhThucThanhToan_PhatSinh"].ToString();
                            if (!String.IsNullOrEmpty(sHinhThucThanhToan))
                            {
                                cbbHinhThucThanhToan.SelectedValue = Int32.Parse(sHinhThucThanhToan);
                            }


                            txtGiaTriTamUng.Text = SelectHopDongKSKTheoID.Rows[0]["GiaTri_TamUng"].ToString();
                            txtGiaTriPhatSinh.Text = SelectHopDongKSKTheoID.Rows[0]["GiaTri_PhatSinh"].ToString();
                            txtDienGiai.Text = SelectHopDongKSKTheoID.Rows[0]["DienGiai"].ToString();

                            btnThem.Enabled = false;
                            btnSua.Enabled = false;
                            btnLuu.Enabled = true;
                            btnHuy.Enabled = true;
                            btnXoa.Enabled = true;
                            Hien();
                            ThaoTac = "Sua";
                            txtTenCongTy.Focus();

                        }
                    }
                }
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
                    DataTable Delete = Model.dbDanhMuc.DeleteHopDongKSK("'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'", nguoicapnhat, HD_Id);
                    Reset();
                    HD_Id = "";
                    DataTable SelectAllHopDongKSK = Model.dbDanhMuc.SelectAllHopDongKSK();
                    gridHopDongKSK.DataSource = SelectAllHopDongKSK;
                    alertControl1.Show(this, "Thông báo", "Đã xóa thành công! ");
                    break;
                case DialogResult.No:
                    break;
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