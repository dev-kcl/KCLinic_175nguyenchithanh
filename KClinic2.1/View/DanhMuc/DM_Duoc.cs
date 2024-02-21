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
    public partial class DM_Duoc : DevExpress.XtraEditors.XtraForm
    {
        public string DM_Id;
        public string ThaoTac;
        public DM_Duoc()
        {
            InitializeComponent();
        }
        DataTable CBBLoaiDuoc;
        DataTable CBBDonViTinh;
        DataTable CBBQuocGia;
        private void DM_Duoc_Load(object sender, EventArgs e)
        {
            DataTable SelectDM_Duoc = Model.dbDanhMuc.SelectDM_Duoc();
            gridDichVu.DataSource = SelectDM_Duoc;
            CBBLoaiDuoc = Model.dbDanhMuc.CBBLoaiDuoc();
            cbbLoaiDuoc.DataSource = CBBLoaiDuoc;
            cbbLoaiDuoc.ValueMember = "FieldCode";
            cbbLoaiDuoc.DisplayMember = "FieldName";
            cbbLoaiDuoc.Value = 1;

            LayDsDVT();
            LayDsQuocGia();

            //CBBQuocGia = Model.dbDanhMuc.CBBQuocGia();
            //cbbQuocGia.DataSource = CBBQuocGia;
            //cbbQuocGia.ValueMember = "FieldCode";
            //cbbQuocGia.DisplayMember = "FieldName";

            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            btnXoa.Enabled = false;
            An();
        }

        void LayDsDVT()
        {
            CBBDonViTinh = Model.dbDanhMuc.CBBDonViTinh();
            cbbDonViTinh.DataSource = CBBDonViTinh;
            cbbDonViTinh.ValueMember = "FieldCode";
            cbbDonViTinh.DisplayMember = "FieldName";


            string[] arrray = CBBDonViTinh.Rows.OfType<DataRow>().Select(k => k["FieldName"].ToString()).ToArray();
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            collection.AddRange(arrray);
            txtDonViTinh.MaskBox.AutoCompleteCustomSource = collection;
            txtDonViTinh.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtDonViTinh.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;


            //DataRow[] resultRow = CBBLoaiDuoc.Select("FieldCode = '" + cbbLoaiDuoc.Value.ToString() + "'");
            //if (resultRow.Count() > 0)
            //{
            //    DataTable dtResult = CBBLoaiDuoc.Select("FieldCode = '" + cbbLoaiDuoc.Value.ToString() + "'").CopyToDataTable();
            //    CBBDonViTinh = Model.dbDanhMuc.CBBDonViTinh(dtResult.Rows[0]["MaLoaiDuoc"].ToString());
            //    cbbDonViTinh.DataSource = CBBDonViTinh;
            //    cbbDonViTinh.ValueMember = "FieldCode";
            //    cbbDonViTinh.DisplayMember = "FieldName";
            //}
            //else
            //{
            //    CBBDonViTinh = Model.dbDanhMuc.CBBDonViTinh("1");
            //    cbbDonViTinh.DataSource = CBBDonViTinh;
            //    cbbDonViTinh.ValueMember = "FieldCode";
            //    cbbDonViTinh.DisplayMember = "FieldName";
            //}
        }
        void LayDsQuocGia()
        {
            CBBQuocGia = Model.dbDanhMuc.CBBQuocGia();
            cbbQuocGia.DataSource = CBBQuocGia;
            cbbQuocGia.ValueMember = "FieldCode";
            cbbQuocGia.DisplayMember = "FieldName";

            string[] arrray = CBBQuocGia.Rows.OfType<DataRow>().Select(k => k["FieldName"].ToString()).ToArray();
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            collection.AddRange(arrray);
            txtQuocGia.MaskBox.AutoCompleteCustomSource = collection;
            txtQuocGia.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtQuocGia.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }

        private void BtnThem_Click(object sender, EventArgs e)
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
            txtMaDuoc.Focus();
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
            txtMaDuoc.Focus();
            //
            LoadThongTinForm();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaDuoc.Text == "")
            {
                alertControl1.Show(this, "Thông báo", "Mã dược không được để trống! ", "");
            }
            else if (txtTenDuoc.Text == "")
            {
                alertControl1.Show(this, "Thông báo", "Tên dược không được để trống! ", "");
            }
            //else if (txtHanSuDung.Text == "")
            //{
            //    alertControl1.Show(this, "Thông báo", "Hạn sử dụng không được để trống! ", "");
            //}
            //else if (txtDonGiaBan.Text == "")
            //{
            //    alertControl1.Show(this, "Thông báo", "Đơn giá bán không được để trống! ", "");
            //}
            else
            {
                string MaDuoc = "N'" + txtMaDuoc.Text.Replace("'", "''") + "'";
                string TenDuoc = "N'" + txtTenDuoc.Text.Replace("'", "''") + "'";

                string DonViTinh_Id = "null";
                string DonViTinh = "null";
                //if (cbbDonViTinh.SelectedItem != null)
                //{
                //    DonViTinh_Id = "N'" + cbbDonViTinh.Value.ToString().Replace("'", "''") + "'";
                //    DataRow[] resultRow = CBBDonViTinh.Select("FieldCode = '" + cbbDonViTinh.Value.ToString() + "'");
                //    if (resultRow.Count() > 0)
                //    {
                //        DataTable dtResult = CBBDonViTinh.Select("FieldCode = '" + cbbDonViTinh.Value.ToString() + "'").CopyToDataTable();
                //        DonViTinh = "N'" + dtResult.Rows[0]["FieldName"].ToString().Replace("'", "''") + "'";
                //    }
                //}

                DonViTinh = "N'" + txtDonViTinh.Text.Replace("'", "''") + "'";
                DataTable CheckandInsertDVT = Model.dbDuoc.CheckandInsertDVT(DonViTinh, "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'", Login.User_Id);
                if (CheckandInsertDVT != null)
                {
                    if (CheckandInsertDVT.Rows.Count > 0)
                    {
                        DonViTinh_Id = CheckandInsertDVT.Rows[0]["DonViTinh_Id"].ToString();
                        LayDsDVT();
                    }
                }

                string HangSanXuat = "null";
                if (txtHangSanXuat.Text != "") { HangSanXuat = "N'" + txtHangSanXuat.Text.Replace("'", "''") + "'"; }

                string QuocGia_Id = "null";
                string QuocGia = "null";
                if (cbbQuocGia.SelectedItem != null)
                {
                    QuocGia_Id = "N'" + cbbQuocGia.Value.ToString().Replace("'", "''") + "'";
                    DataRow[] resultRow2 = CBBQuocGia.Select("FieldCode = '" + cbbQuocGia.Value.ToString() + "'");
                    if (resultRow2.Count() > 0)
                    {
                        DataTable dtResult = CBBQuocGia.Select("FieldCode = '" + cbbQuocGia.Value.ToString() + "'").CopyToDataTable();
                        //QuocGia = "N'" + dtResult.Rows[0]["FieldName"].ToString().Replace("'", "''") + "'";
                    }
                }
                if (txtQuocGia.Text != "") { QuocGia = "N'" + txtQuocGia.Text.Replace("'", "''") + "'"; }


                string TenHoatChat = "null";
                if (txtTenHoatChat.Text != "") { TenHoatChat = "N'" + txtTenHoatChat.Text.Replace("'", "''") + "'"; }
                string CachSuDung = "null";
                if (txtCachSuDung.Text != "") { CachSuDung = "N'" + txtCachSuDung.Text.Replace("'", "''") + "'"; }
                string HamLuong = "null";//"N'" + txtHamLuong.Text.Replace("'", "''") + "'";
                if (txtHamLuong.Text != "") { HamLuong = "N'" + txtHamLuong.Text.Replace("'", "''") + "'"; }
                string CongDung = "null";//"N'" + txtCongDung.Text.Replace("'", "''") + "'";
                if (txtCongDung.Text != "") { CongDung = "N'" + txtCongDung.Text.Replace("'", "''") + "'"; }

                string LoaiDuoc_Id = "null";
                string PhanLoaiDuoc = "null";
                if (cbbLoaiDuoc.SelectedItem != null)
                {
                    LoaiDuoc_Id = "N'" + cbbLoaiDuoc.Value.ToString().Replace("'", "''") + "'";
                    DataRow[] resultRow3 = CBBLoaiDuoc.Select("FieldCode = '" + cbbLoaiDuoc.Value.ToString() + "'");
                    if (resultRow3.Count() > 0)
                    {
                        DataTable dtResult = CBBLoaiDuoc.Select("FieldCode = '" + cbbLoaiDuoc.Value.ToString() + "'").CopyToDataTable();
                        PhanLoaiDuoc = "N'" + dtResult.Rows[0]["MaLoaiDuoc"].ToString().Replace("'", "''") + "'";
                    }
                }


                string DuongDung = "null";//"N'" + txtDuongDung.Text.Replace("'", "''") + "'";
                if (txtDuongDung.Text != "") { DuongDung = "N'" + txtDuongDung.Text.Replace("'", "''") + "'"; }

                string TamNgung = "0";
                if (cbTamNgung.Checked == false) { TamNgung = "0"; } else { TamNgung = "1"; }

                string NgaySanXuat = "null";
                //if (txtNgaySanXuat.Value.ToString() != "")
                //{
                //    NgaySanXuat = "'" + txtNgaySanXuat.Value.ToString("yyyyMMdd") + "'";
                //}

                string HanSuDung = "null";// = "'" + txtHanSuDung.Value.ToString("yyyyMMdd") + "'";

                string SoLuongNhapVao = "0";
                //if (txtSoLuongNhapVao.Text != "") { SoLuongNhapVao = "N'" + txtSoLuongNhapVao.Text.Replace("'", "''") + "'"; }

                string DonGiaVon = "0";
                //if (txtDonGiaVon.Text != "") { DonGiaVon = "N'" + txtDonGiaVon.Text.Replace("'", "''") + "'"; }

                string DonGiaBan = "0";
                //if (txtDonGiaBan.Text != "") { DonGiaBan = "N'" + txtDonGiaBan.Text.Replace("'", "''") + "'"; }



                if (ThaoTac == "Them")
                {
                    DataTable Insert = Model.dbDanhMuc.InsertDM_Duoc(
                        MaDuoc
                        , TenDuoc
                        , DonViTinh
                        , DonViTinh_Id
                        , HangSanXuat
                        , "null"
                        , QuocGia
                        , QuocGia_Id
                        , "null"
                        , "null"
                        , TenHoatChat
                        , CachSuDung
                        , HamLuong
                        , CongDung
                        , LoaiDuoc_Id
                        , PhanLoaiDuoc
                        , DuongDung
                        , TamNgung
                        , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                        , Login.User_Id
                        , "null"
                        , "null"
                        , "0"
                        , NgaySanXuat
                        , HanSuDung
                        , SoLuongNhapVao
                        , "null"
                        , DonGiaVon
                        , DonGiaBan
                        );
                    if (Insert.Rows.Count > 0)
                    {
                        DM_Id = Insert.Rows[0]["Duoc_Id"].ToString();
                        alertControl1.Show(this, "Thông báo", "Đã thêm thành công! " + Insert.Rows[0]["TenDuocDayDu"].ToString(), "");
                    }
                }
                if (ThaoTac == "Sua")
                {
                    DataTable Update = Model.dbDanhMuc.UpdateDM_Duoc(
                          DM_Id
                        , MaDuoc
                        , TenDuoc
                        , DonViTinh
                        , DonViTinh_Id
                        , HangSanXuat
                        , "null"
                        , QuocGia
                        , QuocGia_Id
                        , "null"
                        , "null"
                        , TenHoatChat
                        , CachSuDung
                        , HamLuong
                        , CongDung
                        , LoaiDuoc_Id
                        , PhanLoaiDuoc
                        , DuongDung
                        , TamNgung
                        , "null"
                        , "null"
                        , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                        , Login.User_Id
                        , "0"
                        , NgaySanXuat
                        , HanSuDung
                        , SoLuongNhapVao
                        , "null"
                        , DonGiaVon
                        , DonGiaBan
                        );
                    if (Update.Rows.Count > 0)
                    {
                        DM_Id = Update.Rows[0]["Duoc_Id"].ToString();
                        alertControl1.Show(this, "Thông báo", "Đã sửa thành công! " + Update.Rows[0]["TenDuocDayDu"].ToString(), "");
                    }
                }
                //
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnLuu.Enabled = false;
                btnHuy.Enabled = false;
                btnXoa.Enabled = true;
                An();
                DataTable SelectDM_Duoc = Model.dbDanhMuc.SelectDM_Duoc();
                gridDichVu.DataSource = SelectDM_Duoc;
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
                    DataTable Delete = Model.dbDanhMuc.DeleteDM_Duoc(DM_Id, nguoicapnhat);
                    Reset();
                    DM_Id = "";
                    DataTable SelectDM_Duoc = Model.dbDanhMuc.SelectDM_Duoc();
                    gridDichVu.DataSource = SelectDM_Duoc;
                    alertControl1.Show(this, "Thông báo", "Đã xóa thành công! " + Delete.Rows[0]["TenDuocDayDu"].ToString(), "");
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
                DM_Id = gridView1.GetRowCellValue(n, "Duoc_Id").ToString();
                DataTable SelectDM_DuocTheoID = Model.dbDanhMuc.SelectDM_DuocTheoID(DM_Id);
                {
                    if (SelectDM_DuocTheoID != null)
                    {
                        if (SelectDM_DuocTheoID.Rows.Count > 0)
                        {
                            txtMaDuoc.Text = SelectDM_DuocTheoID.Rows[0]["MaDuoc"].ToString();
                            txtTenDuoc.Text = SelectDM_DuocTheoID.Rows[0]["TenDuoc"].ToString();
                            string LoaiDuoc_Id = SelectDM_DuocTheoID.Rows[0]["LoaiDuoc_Id"].ToString();
                            if (!String.IsNullOrEmpty(LoaiDuoc_Id))
                            {
                                cbbLoaiDuoc.Value = Int32.Parse(LoaiDuoc_Id);
                            }
                            LayDsDVT();
                            string DonViTinh_Id = SelectDM_DuocTheoID.Rows[0]["DonViTinh_Id"].ToString();
                            if (!String.IsNullOrEmpty(DonViTinh_Id))
                            {
                                cbbDonViTinh.Value = Int32.Parse(DonViTinh_Id);
                            }
                            txtDonViTinh.Text = SelectDM_DuocTheoID.Rows[0]["DonViTinh"].ToString();
                            txtHangSanXuat.Text = SelectDM_DuocTheoID.Rows[0]["HangSanXuat"].ToString();
                            string QuocGia_Id = SelectDM_DuocTheoID.Rows[0]["QuocGia_Id"].ToString();
                            if (!String.IsNullOrEmpty(QuocGia_Id))
                            {
                                cbbQuocGia.Value = Int32.Parse(QuocGia_Id);
                            }
                            txtQuocGia.Text = SelectDM_DuocTheoID.Rows[0]["QuocGia"].ToString();
                            txtTenHoatChat.Text = SelectDM_DuocTheoID.Rows[0]["TenHoatChat"].ToString();
                            txtCachSuDung.Text = SelectDM_DuocTheoID.Rows[0]["CachSuDung"].ToString();
                            txtHamLuong.Text = SelectDM_DuocTheoID.Rows[0]["HamLuong"].ToString();
                            txtCongDung.Text = SelectDM_DuocTheoID.Rows[0]["CongDung"].ToString();
                            txtDuongDung.Text = SelectDM_DuocTheoID.Rows[0]["DuongDung"].ToString();

                            string TamNgungTam = SelectDM_DuocTheoID.Rows[0]["TamNgung"].ToString();
                            if (TamNgungTam == "0") { cbTamNgung.Checked = false; } else { cbTamNgung.Checked = true; }

                            //string DateStart = SelectDM_DuocTheoID.Rows[0]["DateStart"].ToString();
                            //if (!String.IsNullOrEmpty(DateStart))
                            //{
                            //    DateTime enteredDate = DateTime.Parse(DateStart);
                            //    txtNgaySanXuat.Value = enteredDate;
                            //}

                            string DateEnd = SelectDM_DuocTheoID.Rows[0]["DateEnd"].ToString();
                            if (!String.IsNullOrEmpty(DateEnd))
                            {
                                DateTime enteredDate = DateTime.Parse(DateEnd);
                                txtHanSuDung.Value = enteredDate;
                            }

                            txtSoLuongNhapVao.Text = SelectDM_DuocTheoID.Rows[0]["SoLuongNhapVao"].ToString();
                            txtDonGiaVon.Text = SelectDM_DuocTheoID.Rows[0]["DonGiaVon"].ToString();
                            txtDonGiaBan.Text = SelectDM_DuocTheoID.Rows[0]["DonGia"].ToString();

                            btnThem.Enabled = false;
                            btnSua.Enabled = false;
                            btnLuu.Enabled = true;
                            btnHuy.Enabled = true;
                            btnXoa.Enabled = true;
                            Hien();
                            ThaoTac = "Sua";
                            txtMaDuoc.Focus();
                        }
                    }
                }
            }
        }
        public void LoadThongTinForm()
        {
            DataTable SelectDM_DuocTheoID = Model.dbDanhMuc.SelectDM_DuocTheoID(DM_Id);
            {
                if (SelectDM_DuocTheoID != null)
                {
                    if (SelectDM_DuocTheoID.Rows.Count > 0)
                    {
                        txtMaDuoc.Text = SelectDM_DuocTheoID.Rows[0]["MaDuoc"].ToString();
                        txtTenDuoc.Text = SelectDM_DuocTheoID.Rows[0]["TenDuoc"].ToString();
                        string LoaiDuoc_Id = SelectDM_DuocTheoID.Rows[0]["LoaiDuoc_Id"].ToString();
                        if (!String.IsNullOrEmpty(LoaiDuoc_Id))
                        {
                            cbbLoaiDuoc.Value = Int32.Parse(LoaiDuoc_Id);
                        }
                        LayDsDVT();
                        string DonViTinh_Id = SelectDM_DuocTheoID.Rows[0]["DonViTinh_Id"].ToString();
                        if (!String.IsNullOrEmpty(DonViTinh_Id))
                        {
                            cbbDonViTinh.Value = Int32.Parse(DonViTinh_Id);
                        }
                        txtDonViTinh.Text = SelectDM_DuocTheoID.Rows[0]["DonViTinh"].ToString();
                        txtHangSanXuat.Text = SelectDM_DuocTheoID.Rows[0]["HangSanXuat"].ToString();
                        string QuocGia_Id = SelectDM_DuocTheoID.Rows[0]["QuocGia_Id"].ToString();
                        if (!String.IsNullOrEmpty(QuocGia_Id))
                        {
                            cbbQuocGia.Value = Int32.Parse(QuocGia_Id);
                        }
                        txtQuocGia.Text = SelectDM_DuocTheoID.Rows[0]["QuocGia"].ToString();
                        txtTenHoatChat.Text = SelectDM_DuocTheoID.Rows[0]["TenHoatChat"].ToString();
                        txtCachSuDung.Text = SelectDM_DuocTheoID.Rows[0]["CachSuDung"].ToString();
                        txtHamLuong.Text = SelectDM_DuocTheoID.Rows[0]["HamLuong"].ToString();
                        txtCongDung.Text = SelectDM_DuocTheoID.Rows[0]["CongDung"].ToString();
                        txtDuongDung.Text = SelectDM_DuocTheoID.Rows[0]["DuongDung"].ToString();

                        string TamNgungTam = SelectDM_DuocTheoID.Rows[0]["TamNgung"].ToString();
                        if (TamNgungTam == "0") { cbTamNgung.Checked = false; } else { cbTamNgung.Checked = true; }

                        //string DateStart = SelectDM_DuocTheoID.Rows[0]["DateStart"].ToString();
                        //if (!String.IsNullOrEmpty(DateStart))
                        //{
                        //    DateTime enteredDate = DateTime.Parse(DateStart);
                        //    txtNgaySanXuat.Value = enteredDate;
                        //}

                        string DateEnd = SelectDM_DuocTheoID.Rows[0]["DateEnd"].ToString();
                        if (!String.IsNullOrEmpty(DateEnd))
                        {
                            DateTime enteredDate = DateTime.Parse(DateEnd);
                            txtHanSuDung.Value = enteredDate;
                        }

                        txtSoLuongNhapVao.Text = SelectDM_DuocTheoID.Rows[0]["SoLuongNhapVao"].ToString();
                        txtDonGiaVon.Text = SelectDM_DuocTheoID.Rows[0]["DonGiaVon"].ToString();
                        txtDonGiaBan.Text = SelectDM_DuocTheoID.Rows[0]["DonGia"].ToString();
                    }
                }
            }
        }
        public void Hien()
        {
            txtMaDuoc.Enabled = true;
            txtTenDuoc.Enabled = true;
            cbbLoaiDuoc.Enabled = true;
            cbbDonViTinh.Enabled = true;
            txtDonViTinh.Enabled = true;
            txtHangSanXuat.Enabled = true;
            cbbQuocGia.Enabled = true;
            txtQuocGia.Enabled = true;
            txtTenHoatChat.Enabled = true;
            txtHangSanXuat.Enabled = true;
            txtCachSuDung.Enabled = true;
            txtHamLuong.Enabled = true;
            txtCongDung.Enabled = true;
            txtDuongDung.Enabled = true;
            //txtNgaySanXuat.Enabled = true;
            txtHanSuDung.Enabled = true;
            txtDonGiaVon.Enabled = true;
            txtDonGiaBan.Enabled = true;
            cbTamNgung.Enabled = true;
        }
        public void An()
        {
            txtMaDuoc.Enabled = false;
            txtTenDuoc.Enabled = false;
            cbbLoaiDuoc.Enabled = false;
            cbbDonViTinh.Enabled = false;
            txtDonViTinh.Enabled = false;
            txtHangSanXuat.Enabled = false;
            cbbQuocGia.Enabled = false;
            txtQuocGia.Enabled = false;
            txtTenHoatChat.Enabled = false;
            txtHangSanXuat.Enabled = false;
            txtCachSuDung.Enabled = false;
            txtHamLuong.Enabled = false;
            txtCongDung.Enabled = false;
            txtDuongDung.Enabled = false;
            //txtNgaySanXuat.Enabled = false;
            txtHanSuDung.Enabled = false;
            txtDonGiaVon.Enabled = false;
            txtDonGiaBan.Enabled = false;
            cbTamNgung.Enabled = false;
        }
        public void Reset()
        {
            txtMaDuoc.Text = "";
            txtTenDuoc.Text = "";
            txtHangSanXuat.Text = "";
            cbbQuocGia.Text = "";
            txtQuocGia.Text = "";
            txtTenHoatChat.Text = "";
            txtHangSanXuat.Text = "";
            txtCachSuDung.Text = "";
            txtHamLuong.Text = "";
            txtCongDung.Text = "";
            txtDuongDung.Text = "";
            //txtNgaySanXuat.Text = "";
            txtHanSuDung.Text = "";
            txtDonGiaVon.Text = "";
            txtDonGiaBan.Text = "";
            cbTamNgung.Checked = false;
        }

        private void cbbLoaiDuoc_KeyDown(object sender, KeyEventArgs e)
        {
            string text = cbbLoaiDuoc.Text;
            DataRow[] resultRow = CBBLoaiDuoc.Select("FieldName LIKE '%" + text + "%'");
            if (resultRow.Count() > 0)
            {
                DataTable dtResult = CBBLoaiDuoc.Select("FieldName LIKE '%" + text + "%'").CopyToDataTable();
                cbbLoaiDuoc.DataSource = dtResult;
                cbbLoaiDuoc.DroppedDown = true;
            }
            else
            {
                cbbLoaiDuoc.DataSource = null;
                cbbLoaiDuoc.DroppedDown = true;
            }
        }

        private void cbbDonViTinh_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void cbbQuocGia_KeyDown(object sender, KeyEventArgs e)
        {
            string text = cbbQuocGia.Text;
            DataRow[] resultRow = CBBQuocGia.Select("FieldName LIKE '%" + text + "%' or TenTat LIKE '%" + text + "%'");
            if (resultRow.Count() > 0)
            {
                DataTable dtResult = CBBQuocGia.Select("FieldName LIKE '%" + text + "%'or TenTat LIKE '%" + text + "%'").CopyToDataTable();
                cbbQuocGia.DataSource = dtResult;
                cbbQuocGia.DroppedDown = true;
            }
            else
            {
                cbbQuocGia.DataSource = null;
                cbbQuocGia.DroppedDown = true;
            }
        }

        private void cbbDonViTinh_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Tab && e.KeyData != Keys.Enter && e.KeyData != Keys.Up && e.KeyData != Keys.Down && e.KeyData != Keys.Right && e.KeyData != Keys.Left)
            {

                string text = cbbDonViTinh.Text;
                if (text == "")
                {
                    DataTable dtResult = CBBDonViTinh.Select("FieldName LIKE '%" + text + "%'").CopyToDataTable();
                    cbbDonViTinh.DataSource = dtResult;
                    cbbDonViTinh.DroppedDown = true;
                }
                else
                {
                    DataRow[] resultRow = CBBDonViTinh.Select("FieldName LIKE '%" + text + "%'");
                    if (resultRow.Count() > 0)
                    {
                        DataTable dtResult = CBBDonViTinh.Select("FieldName LIKE '%" + text + "%'").CopyToDataTable();
                        cbbDonViTinh.DataSource = dtResult;
                        cbbDonViTinh.DroppedDown = true;
                    }
                    else
                    {
                        cbbDonViTinh.DataSource = null;
                        cbbDonViTinh.DroppedDown = true;
                    }
                }
            }

        }

        private void cbbLoaiDuoc_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Tab && e.KeyData != Keys.Enter && e.KeyData != Keys.Up && e.KeyData != Keys.Down && e.KeyData != Keys.Right && e.KeyData != Keys.Left)
            {

                string text = cbbLoaiDuoc.Text;
                if (text == "")
                {
                    DataTable dtResult = CBBLoaiDuoc.Select("FieldName LIKE '%" + text + "%'").CopyToDataTable();
                    cbbLoaiDuoc.DataSource = dtResult;
                    cbbLoaiDuoc.DroppedDown = true;
                }
                else
                {
                    DataRow[] resultRow = CBBLoaiDuoc.Select("FieldName LIKE '%" + text + "%'");
                    if (resultRow.Count() > 0)
                    {
                        DataTable dtResult = CBBLoaiDuoc.Select("FieldName LIKE '%" + text + "%'").CopyToDataTable();
                        cbbLoaiDuoc.DataSource = dtResult;
                        cbbLoaiDuoc.DroppedDown = true;
                    }
                    else
                    {
                        cbbLoaiDuoc.DataSource = null;
                        cbbLoaiDuoc.DroppedDown = true;
                    }
                }
            }

        }

        private void cbbQuocGia_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Tab && e.KeyData != Keys.Enter && e.KeyData != Keys.Up && e.KeyData != Keys.Down && e.KeyData != Keys.Right && e.KeyData != Keys.Left)
            {

                string text = cbbQuocGia.Text;
                if (text == "")
                {
                    DataTable dtResult = CBBQuocGia.Select("FieldName LIKE '%" + text + "%'").CopyToDataTable();
                    cbbQuocGia.DataSource = dtResult;
                    cbbQuocGia.DroppedDown = true;
                }
                else
                {
                    DataRow[] resultRow = CBBQuocGia.Select("FieldName LIKE '%" + text + "%'");
                    if (resultRow.Count() > 0)
                    {
                        DataTable dtResult = CBBQuocGia.Select("FieldName LIKE '%" + text + "%'").CopyToDataTable();
                        cbbQuocGia.DataSource = dtResult;
                        cbbQuocGia.DroppedDown = true;
                    }
                    else
                    {
                        cbbQuocGia.DataSource = null;
                        cbbQuocGia.DroppedDown = true;
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