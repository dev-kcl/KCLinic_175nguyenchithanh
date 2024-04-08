using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KClinic2._1.View.TheThanhVien
{
    public partial class ThongTinThe : DevExpress.XtraEditors.XtraForm
    {
        public string The_Id = "";
        public string SoTheThanhVien = "";
        public string The_DichVu_Id = "";
        public string DichVu_Id = "";
        public string BenhNhan_Id = "";
        public string TenBenhNhan = "";
        public string MaYTe = "";
        public string SoVaoVien = "";

        DataTable Dm_DichVu;
        DataTable Dm_NhomDichVu;

        public ThongTinThe()
        {
            InitializeComponent();
        }

        private void ThongTinThe_Load(object sender, EventArgs e)
        {
            txtHieuLuc.Text = DateTime.Today.ToString("dd/MM/yyyy");
            getdata();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtSoThe.Text == "")
            {
                XtraMessageBox.Show("Số thẻ không được để trống!", "Thông Báo");
                txtSoThe.Focus();
                return;
            }

            if (txtHieuLuc.Text == "")
            {
                XtraMessageBox.Show("Thời gian hiệu lực không được để trống!", "Thông Báo");
                txtHieuLuc.Focus();
                return;
            }


            //dang ky thong tin
            string SoThe = "N'" + txtSoThe.Text.Replace("'", "''") + "'";

            int checkThe = CheckExistThongTinThe(SoThe);

            if (checkThe == 0)
            {
                InsertThongTinThe();
            }
            else
            {
                UpdateThongTinThe();
            }

            getLayDanhSachTheThanhVien();
            
            txtSoThe.Text = "";
            txtLoaiThe.Text = "";
            //end dang ky thong tin
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (The_Id == "")
            {
                XtraMessageBox.Show("Bạn chưa chọn Thẻ!", "Thông Báo");
                return;
            }

            string nguoicapnhat = Login.User_Id;
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn xóa thẻ không?", "Thông Báo!", MessageBoxButtons.YesNo);
            switch (dr)
            {
                case DialogResult.Yes:
                    DataTable Delete = Model.dbDanhMuc.DeleteThe(The_Id, nguoicapnhat);
                    alertControl1.Show(this, "Thông báo", "Đã xóa thành công thẻ " + txtSoThe.Text, "");
                    Reset();
                    The_Id = "";
                    MaYTe = "";
                    SoVaoVien = "";
                    BenhNhan_Id = "";
                    TenBenhNhan = "";

                    getdata();
                    break;
                case DialogResult.No:
                    break;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (The_Id == "")
            {
                XtraMessageBox.Show("Bạn chưa chọn Thẻ!", "Thông Báo");
                return;
            }
            else
            {
                LoadThongTinTrongTheTheoId(The_Id);
                DataTable ThemTheVaoPhienDangNhap = Model.dbDanhMuc.ThemTheVaoPhienDangNhap(Login.PhienDangNhap_Id, The_Id);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChonDichVu_Click(object sender, EventArgs e)
        {
            if (cbbDV.SelectedItem != null)
            {
                DataRowView typeItem = (DataRowView)cbbDV.SelectedItem;
                string DichVuId = typeItem.Row[0].ToString();

                DataTable Dm_DichVu_DonGia = Model.DbTiepNhan.Dm_DichVu_DonGia(DichVuId);
                string GiaDichVu = Dm_DichVu_DonGia.Rows[0]["GiaDichVu"].ToString();

                //
                InsertThePhienDangNhap(DichVuId);

                //
                DataTable SelectClsyeucauPhienDangNhap = Model.dbDanhMuc.SelectThe_PhienDangNhap(Login.PhienDangNhap_Id);
                gridDichVu.DataSource = SelectClsyeucauPhienDangNhap;
            }
            else
            {
                XtraMessageBox.Show("Chưa chọn Dịch vụ!", "Thông Báo");
            }
        }

        private void btnThemNhomBenh_Click(object sender, EventArgs e)
        {
            if (cbbNhomBenh.SelectedItem != null)
            {
                DataRowView typeItem = (DataRowView)cbbNhomBenh.SelectedItem;
                string NhomBenhId = typeItem.Row[0].ToString();

                DataTable CheckNhomBenh_DichVu = Model.DbTiepNhan.CheckNhomBenh_DichVu(NhomBenhId);
                if (CheckNhomBenh_DichVu != null)
                {
                    if (CheckNhomBenh_DichVu.Rows.Count > 0)
                    {

                        for (int i = 0; i < CheckNhomBenh_DichVu.Rows.Count; i++)
                        {
                            InsertThePhienDangNhap(CheckNhomBenh_DichVu.Rows[i]["Dich_Id"].ToString()); 
                        }

                        //
                        DataTable SelectClsyeucauPhienDangNhap = Model.dbDanhMuc.SelectThe_PhienDangNhap(Login.PhienDangNhap_Id);
                        gridDichVu.DataSource = SelectClsyeucauPhienDangNhap;
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("Chưa chọn Nhóm bệnh!", "Thông Báo");
            }
        }

        private void btnXoaDichVu_Click(object sender, EventArgs e)
        {
            if (The_Id != "" && DichVu_Id != "")
            {
                DataTable Delete = Model.dbDanhMuc.Delete_The_PhienDangNhap(The_Id, DichVu_Id, Login.User_Id);

                DataTable SelectClsyeucauPhienDangNhap = Model.dbDanhMuc.SelectThe_PhienDangNhap(Login.PhienDangNhap_Id);
                gridDichVu.DataSource = SelectClsyeucauPhienDangNhap;
                DichVu_Id = "";
            }
            else
            {
                alertControl1.Show(this, "Thông báo", "Chưa chọn dịch vụ cần xóa!", "");
            }
        }

        private void btnUpdateDV_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn cập nhật thông tin thẻ?", "Thông Báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (The_Id == "")
                {
                    XtraMessageBox.Show("Chưa chọn Thẻ thành viên cần cập nhật!", "Thông Báo");
                    return;
                }
                else
                {
                    //check khach hang trong the 
                    if (txtHoTen.Text.Trim() != "")
                    {
                        if (txtNamSinh.Text.Trim() == "")
                        {
                            XtraMessageBox.Show("Năm sinh không được để trống!", "Thông Báo");
                            return;
                        }

                        if (cbbGioiTinh.SelectedItem == null || cbbGioiTinh.Value.ToString() == "")
                        {
                            XtraMessageBox.Show("Giới tính không được để trống!", "Thông Báo");
                            return;
                        }

                        if (txtMaYTe.Text == "")
                        {
                            AutoTinhMaYTe();
                            LoadThongTinBenhNhanTheoMaYTe();
                            InsertUpdateBenhNhan();
                        }
                        else
                        {
                            InsertUpdateBenhNhan();
                        }
                    }


                    //check dich vu trong the
                    int checkThe = CheckExistThongTinTheThanhVienTheoID(The_Id);

                    if (checkThe == 0)
                    {
                        InsertDichVuTrongThe();

                        DataTable HoanTatClsYeuCauPhienDangNhap = Model.dbDanhMuc.HoanTatThePhienDangNhap(Login.PhienDangNhap_Id);

                        LoadThongTinTrongTheTheoId(The_Id);
                    }
                    else
                    {
                        UpdateDichVuTrongThe();

                        DataTable HoanTatClsYeuCauPhienDangNhap = Model.dbDanhMuc.HoanTatThePhienDangNhap(Login.PhienDangNhap_Id);

                        LoadThongTinTrongTheTheoId(The_Id);
                    }

                    alertControl1.Show(this, "Thông báo", "Đã cập nhật thông tin thành công thẻ " + txtSoThe.Text, "");
                }

                DataTable ThemTheVaoPhienDangNhap = Model.dbDanhMuc.ThemTheVaoPhienDangNhap(Login.PhienDangNhap_Id, The_Id);
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }

        private void getdata()
        {
            Dm_DichVu = Model.DbTiepNhan.Dm_DichVu();
            cbbDV.DataSource = Dm_DichVu;
            cbbDV.ValueMember = "Dich_Id";
            cbbDV.DisplayMember = "TenDichVu";

            Dm_NhomDichVu = Model.DbTiepNhan.Dm_NhomBenh();
            cbbNhomBenh.DataSource = Dm_NhomDichVu;
            cbbNhomBenh.ValueMember = "NhomBenh_Id";
            cbbNhomBenh.DisplayMember = "TenNhomBenh";

            DataTable GioiTinh = Model.DbTiepNhan.GioiTinh();
            cbbGioiTinh.DataSource = GioiTinh;
            cbbGioiTinh.DisplayMember = "GioiTinh";
            cbbGioiTinh.ValueMember = "GioiTinh_id";

            //load thong tin the
            getLayDanhSachTheThanhVien();

            //load dich vu theo the
            if (gridView1.RowCount > 0)
            {
                The_Id = gridView1.GetRowCellValue(0, "The_Id").ToString();
                gridView1.FocusedRowHandle = 0;
                gridView1.SelectRow(0);
                LoadThongTinTrongTheTheoId(The_Id);
            }

            txtSoThe.Focus();
        }

        private void getLayDanhSachTheThanhVien(string search = "")
        {
            string reSearch = "N'" + search.Replace("'", "''") + "'";

            DataTable SelectDanhSachTheThanhVien = Model.dbDanhMuc.SelectDanhSachTheThanhVien(reSearch);
            gridTheThanhVien.DataSource = SelectDanhSachTheThanhVien;
        }

        private void AutoTinhMaYTe()
        {
            DataTable AutoTinhMaYTe = Model.DbTiepNhan.AutoTinhMaYTe(Login.MaBenhVien, Login.PhienDangNhap_Id, Login.User_Id);
            if (AutoTinhMaYTe != null)
            {
                if (AutoTinhMaYTe.Rows.Count > 0)
                {
                    MaYTe = AutoTinhMaYTe.Rows[0]["MaYTe"].ToString();
                    txtMaYTe.Text = AutoTinhMaYTe.Rows[0]["MaYTe"].ToString();
                    SoVaoVien = AutoTinhMaYTe.Rows[0]["SoVaoVien"].ToString();
                }
            }
        }

        private int CheckExistThongTinThe(string SoThe)
        {
            int count = 0;

            DataTable CheckExistThongTinThe = Model.dbDanhMuc.CheckExistThongTinThe(SoThe);
            if (CheckExistThongTinThe.Rows.Count > 0)
            {
                if (int.Parse(CheckExistThongTinThe.Rows[0]["count_the"].ToString()) > 0)
                {
                    count = int.Parse(CheckExistThongTinThe.Rows[0]["count_the"].ToString());
                }                
            }

            return count;
        }

        private int CheckExistThongTinTheThanhVienTheoID(string _The_Id)
        {
            int count = 0;

            DataTable CheckExistTheThanhVienTheoID = Model.dbDanhMuc.CheckExistThongTinTheThanhVienTheoID(_The_Id);
            if (CheckExistTheThanhVienTheoID.Rows.Count > 0)
            {
                if (int.Parse(CheckExistTheThanhVienTheoID.Rows[0]["count_the"].ToString()) > 0)
                {
                    count = int.Parse(CheckExistTheThanhVienTheoID.Rows[0]["count_the"].ToString());
                }
            }

            return count;
        }

        public void LoadThongTinBenhNhanTheoMaYTe()
        {
            DataTable LoadThongTinBenhNhan = Model.DbTiepNhan.LoadThongTinBenhNhanTheoMaYTe(MaYTe);
            if (LoadThongTinBenhNhan.Rows.Count > 0)
            {
                txtMaYTe.Text = LoadThongTinBenhNhan.Rows[0]["MaYTe"].ToString();
                MaYTe = LoadThongTinBenhNhan.Rows[0]["MaYTe"].ToString();
                SoVaoVien = LoadThongTinBenhNhan.Rows[0]["SoVaoVien"].ToString();
                txtHoTen.Text = LoadThongTinBenhNhan.Rows[0]["TenBenhNhan"].ToString();

                string GioiTinh = LoadThongTinBenhNhan.Rows[0]["GioiTinh"].ToString();
                if (!String.IsNullOrEmpty(GioiTinh))
                {
                    cbbGioiTinh.Value = Int32.Parse(GioiTinh);
                }

                txtNamSinh.Text = LoadThongTinBenhNhan.Rows[0]["NamSinh"].ToString();
                txtSoDienThoai.Text = LoadThongTinBenhNhan.Rows[0]["SoDienThoai"].ToString();
                BenhNhan_Id = LoadThongTinBenhNhan.Rows[0]["BenhNhan_Id"].ToString();
            }
        }

        private void LoadThongTinTrongTheTheoId(string _The_Id)
        {
            //load the
            DataTable SelectDanhSachTheThanhVienTheoId = Model.dbDanhMuc.SelectDanhSachTheThanhVienTheoId(_The_Id);

            txtSoThe.Text = SelectDanhSachTheThanhVienTheoId.Rows[0]["SoThe"].ToString();
            txtLoaiThe.Text = SelectDanhSachTheThanhVienTheoId.Rows[0]["LoaiThe"].ToString();
            string NgayHieuLuc = SelectDanhSachTheThanhVienTheoId.Rows[0]["NgayHieuLuc"].ToString();
            if (!String.IsNullOrEmpty(NgayHieuLuc))
            {
                DateTime enteredDate = DateTime.Parse(NgayHieuLuc);
                txtHieuLuc.Value = enteredDate;
            }

            //load thong tin trong the
            DataTable LoadThongTinTrongTheTheoId = Model.dbDanhMuc.LoadThongTinTrongTheTheoId(_The_Id);
            if (LoadThongTinTrongTheTheoId.Rows.Count > 0)
            {
                //load benh nhan
                txtMaYTe.Text = LoadThongTinTrongTheTheoId.Rows[0]["MaYTe"].ToString();
                MaYTe = LoadThongTinTrongTheTheoId.Rows[0]["MaYTe"].ToString();
                txtHoTen.Text = LoadThongTinTrongTheTheoId.Rows[0]["TenBenhNhan"].ToString();
                string GioiTinh = LoadThongTinTrongTheTheoId.Rows[0]["GioiTinh"].ToString();
                if (!String.IsNullOrEmpty(GioiTinh))
                {
                    cbbGioiTinh.Value = Int32.Parse(LoadThongTinTrongTheTheoId.Rows[0]["GioiTinh"].ToString());
                }
                txtNamSinh.Text = LoadThongTinTrongTheTheoId.Rows[0]["NamSinh"].ToString();
                txtSoDienThoai.Text = LoadThongTinTrongTheTheoId.Rows[0]["SoDienThoai"].ToString();

                The_Id = LoadThongTinTrongTheTheoId.Rows[0]["The_Id"].ToString();
                The_DichVu_Id = LoadThongTinTrongTheTheoId.Rows[0]["The_DichVu_Id"].ToString();
                BenhNhan_Id = LoadThongTinTrongTheTheoId.Rows[0]["BenhNhan_Id"].ToString();
            }

            //load dich vu
            gridDichVu.DataSource = LoadThongTinTrongTheTheoId;

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, "The_Id").ToString() == The_Id)
                {
                    gridView1.FocusedRowHandle = i;
                    gridView1.SelectRow(i);

                    break;
                }
                else
                {
                    continue;
                }
            }
        }

        private void InsertUpdateBenhNhan()
        {          
            string Hoten = "N'" + txtHoTen.Text.Replace("'", "''") + "'";
            string GioiTinh = "null";
            if (cbbGioiTinh.SelectedItem != null) { GioiTinh = cbbGioiTinh.Value.ToString(); }
            string NamSinh = "'" + txtNamSinh.Text + "'";
            string SoDienThoai = "N'" + txtSoDienThoai.Text.Replace("'", "''") + "'";

            if (BenhNhan_Id != "")
            {
                DataTable UpdateBenhNhan = Model.dbDanhMuc.UpdateBenhNhan(
                      BenhNhan_Id
                    , Hoten
                    , GioiTinh
                    , NamSinh
                    , SoDienThoai
                    , Login.User_Id
                    , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                    );
                if (UpdateBenhNhan.Rows.Count > 0)
                {
                    BenhNhan_Id = UpdateBenhNhan.Rows[0]["BenhNhan_Id"].ToString();
                    TenBenhNhan = UpdateBenhNhan.Rows[0]["TenBenhNhan"].ToString();
                }

                alertControl1.Show(this, "Thông báo", "Đã cập nhật thành công Bệnh nhân " + TenBenhNhan, "");
            }
            else
            {
                DataTable InsertBenhNhan = Model.DbTiepNhan.InsertBenhNhan(
                     MaYTe
                    , SoVaoVien
                    , Hoten
                    , GioiTinh
                    , "null" //NgaySinh
                    , NamSinh
                    , SoDienThoai
                    , "null" //CMND
                    , "null" //DiaChi
                    , "null"
                    , "null"
                    , "null"
                    , Login.User_Id
                    , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                    , "null"
                    , "null"
                    , "0"
                    , "null" //Zalo_Id
                    , "null" //BHYT
                    );
                if (InsertBenhNhan.Rows.Count > 0)
                {
                    BenhNhan_Id = InsertBenhNhan.Rows[0]["BenhNhan_Id"].ToString();
                    TenBenhNhan = InsertBenhNhan.Rows[0]["TenBenhNhan"].ToString();
                }
            }
        }

        private void InsertThongTinThe()
        {
            string SoThe = "N'" + txtSoThe.Text.Replace("'", "''") + "'";
            string LoaiThe = "N'" + txtLoaiThe.Text.Replace("'", "''") + "'";
            string NgayHieuLuc = "null";
            if (!string.IsNullOrEmpty(txtHieuLuc.Text)) { NgayHieuLuc = "'" + txtHieuLuc.Value.ToString("yyyyMMdd") + "'"; }

            DataTable Insert_ThongTinThe = Model.dbDanhMuc.Insert_ThongTinThe(
                  SoThe
                , LoaiThe
                , NgayHieuLuc
                , Login.User_Id
                , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                , "0"
                );

            if (Insert_ThongTinThe.Rows.Count > 0)
            {
                The_Id = Insert_ThongTinThe.Rows[0]["The_Id"].ToString();
            }

            alertControl1.Show(this, "Thông báo", "Đã thêm thành công Thẻ thành viên " + txtSoThe.Text.Trim(), "");
        }

        private void UpdateThongTinThe()
        {
            string SoThe = "N'" + txtSoThe.Text.Replace("'", "''") + "'";
            string LoaiThe = "N'" + txtLoaiThe.Text.Replace("'", "''") + "'";
            string NgayHieuLuc = "null";
            if (!string.IsNullOrEmpty(txtHieuLuc.Text)) { NgayHieuLuc = "'" + txtHieuLuc.Value.ToString("yyyyMMdd") + "'"; }

            DataTable Update_ThongTinThe = Model.dbDanhMuc.Update_ThongTinThe(
                  SoThe
                , LoaiThe
                , NgayHieuLuc
                , Login.User_Id
                , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                );

            if (Update_ThongTinThe.Rows.Count > 0)
            {
                The_Id = Update_ThongTinThe.Rows[0]["The_Id"].ToString();
            }

            alertControl1.Show(this, "Thông báo", "Đã cập nhật thành công Thẻ thành viên " + txtSoThe.Text.Trim(), "");
        }

        private void InsertDichVuTrongThe()
        {
            string reBenhNhan_Id = "null";
            if (BenhNhan_Id != "") { reBenhNhan_Id = "N'" + BenhNhan_Id + "'"; }

            string reSoLuong;
            string reDichVu_Id;

            DataTable gridDichVuDaTa = gridDichVu.DataSource as DataTable;
            foreach (DataRow row in gridDichVuDaTa.Rows)
            {
                reSoLuong = "null";
                reDichVu_Id = "null";

                if (row["SoLuong"].ToString() != "") { reSoLuong = "N'" + row["SoLuong"].ToString() + "'"; }
                if (row["DichVu_Id"].ToString() != "") { reDichVu_Id = "N'" + row["DichVu_Id"].ToString() + "'"; }

                DataTable InsertDichVuTrongThe = Model.dbDanhMuc.InsertDichVuTrongThe(
                       The_Id
                       , reBenhNhan_Id
                       , reDichVu_Id
                       , reSoLuong
                       , Login.User_Id
                       , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                       , "0"
                       );
            }
        }

        private void UpdateDichVuTrongThe()
        {
            string reBenhNhan_Id = "null";
            if (BenhNhan_Id != "") { reBenhNhan_Id = "N'" + BenhNhan_Id + "'"; }

            string reSoLuong;
            string reDichVu_Id;

            DataTable DelDichVuTrongThe = Model.dbDanhMuc.DeleteDichVuTrongThe(
                       The_Id
                       , Login.User_Id
                       , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                       );

            DataTable gridDichVuDaTa = gridDichVu.DataSource as DataTable;
            foreach (DataRow row in gridDichVuDaTa.Rows)
            {
                reSoLuong = "null";
                reDichVu_Id = "null";

                if (row["SoLuong"].ToString() != "") { reSoLuong = "N'" + row["SoLuong"].ToString() + "'"; }
                if (row["DichVu_Id"].ToString() != "") { reDichVu_Id = "N'" + row["DichVu_Id"].ToString() + "'"; }

                DataTable UpdateDichVuTrongThe = Model.dbDanhMuc.UpdateDichVuTrongThe(
                       The_Id
                       , reBenhNhan_Id
                       , reDichVu_Id
                       , reSoLuong
                       , Login.User_Id
                       , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                       , "0"
                       );
            }
        }

        private void InsertThePhienDangNhap(string _DichVu_Id)
        {
            DataTable InsertThe_PhienDangNhap = Model.dbDanhMuc.InsertThe_PhienDangNhap(
                    Login.PhienDangNhap_Id
                    , The_Id
                    , _DichVu_Id
                    , "null"
                    , "N'" + "Them" + "'"
                    );

            ////thêm phiếu yêu cầu cho dịch vụ cấp dưới
            //DataTable CheckDichVuCapDuoi = Model.DbTiepNhan.CheckDichVuCapDuoi(_DichVu_Id);
            //if (CheckDichVuCapDuoi != null)
            //{
            //    if (CheckDichVuCapDuoi.Rows.Count > 0)
            //    {
            //        for (int j = 0; j < CheckDichVuCapDuoi.Rows.Count; j++)
            //        {
            //            DataTable InsertCLSYeuCau_PhieuDangNhapCapDuoi = Model.dbDanhMuc.InsertThe_PhienDangNhap(
            //                Login.PhienDangNhap_Id
            //                , The_Id
            //                , CheckDichVuCapDuoi.Rows[j]["Dich_Id"].ToString()
            //                , "null"
            //                , "N'" + "Them" + "'"
            //                );
            //        }
            //    }
            //}
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            int n = e.RowHandle;
            if (gridView1.RowCount > 0)
            {
                The_Id = gridView1.GetRowCellValue(n, "The_Id").ToString();

                txtSoThe.Text = "";
                txtLoaiThe.Text = "";
                txtHieuLuc.Text = DateTime.Today.ToString("dd/MM/yyyy");

                txtMaYTe.Text = "";
                txtHoTen.Text = "";
                cbbGioiTinh.Text = "";
                txtNamSinh.Text = "";
                txtSoDienThoai.Text = "";

                LoadThongTinTrongTheTheoId(The_Id);

                DataTable ThemTheVaoPhienDangNhap = Model.dbDanhMuc.ThemTheVaoPhienDangNhap(Login.PhienDangNhap_Id, The_Id);
            }
        }

        private void gridView2_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            int n = e.RowHandle;
            if (n >= 0)
            {
                DichVu_Id = gridView2.GetRowCellValue(n, "DichVu_Id").ToString();
            }
        }

        private void cbbDV_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Tab && e.KeyData != Keys.Enter && e.KeyData != Keys.Up && e.KeyData != Keys.Down && e.KeyData != Keys.Right && e.KeyData != Keys.Left)
            {
                string text = cbbDV.Text;
                DataRow[] resultRow = Dm_DichVu.Select("TenDichVu LIKE '%" + text + "%' or MaDichVu LIKE '%" + text + "%'");
                if (resultRow.Count() > 0)
                {
                    DataTable dtResult = Dm_DichVu.Select("TenDichVu LIKE '%" + text + "%' or MaDichVu LIKE '%" + text + "%'").CopyToDataTable();
                    cbbDV.DataSource = dtResult;
                    cbbDV.DroppedDown = true;
                }
                else
                {
                    cbbDV.DataSource = null;
                    cbbDV.DroppedDown = true;
                }
            }
        }

        private void cbbNhomBenh_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Tab && e.KeyData != Keys.Enter && e.KeyData != Keys.Up && e.KeyData != Keys.Down && e.KeyData != Keys.Right && e.KeyData != Keys.Left)
            {
                string text = cbbNhomBenh.Text;
                DataRow[] resultRow = Dm_NhomDichVu.Select("TenNhomBenh LIKE '%" + text + "%'");
                if (resultRow.Count() > 0)
                {
                    DataTable dtResult = Dm_NhomDichVu.Select("TenNhomBenh LIKE '%" + text + "%'").CopyToDataTable();
                    cbbNhomBenh.DataSource = dtResult;
                    cbbNhomBenh.DroppedDown = true;
                }
                else
                {
                    cbbNhomBenh.DataSource = null;
                    cbbNhomBenh.DroppedDown = true;
                }
            }
        }

        public void Reset()
        {
            txtSoThe.Text = "";
            txtLoaiThe.Text = "";
            txtHieuLuc.Text = DateTime.Today.ToString("dd/MM/yyyy");

            txtMaYTe.Text = "";
            txtHoTen.Text = "";
            cbbGioiTinh.Text = "";
            txtNamSinh.Text = "";
            txtSoDienThoai.Text = "";

            cbbNhomBenh.Text = "";
            cbbDV.Text = "";
            gridDichVu.DataSource = null;

            The_Id = "";
            MaYTe = "";
            SoVaoVien = "";

            DataTable HoanTatClsYeuCauPhienDangNhap = Model.DbTiepNhan.HoanTatClsYeuCauPhienDangNhap(Login.PhienDangNhap_Id);
        }

        private void btnSearch_BN_Click(object sender, EventArgs e)
        {
            View.TheThanhVien.TimKiemBenhNhan tc = new View.TheThanhVien.TimKiemBenhNhan(this);
            tc.ShowDialog();
        }

    }
}