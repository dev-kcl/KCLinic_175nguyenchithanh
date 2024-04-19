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

        DataTable DM_LoaiThe;
        DataTable SoThangHieuLucThe;

        public ThongTinThe()
        {
            InitializeComponent();
        }

        private void ThongTinThe_Load(object sender, EventArgs e)
        {
            getdata();
            Reset();
            //txtHieuLuc.Text = DateTime.Today.ToString("dd/MM/yyyy");
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
            txtTenThe.Text = "";
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
                    DataTable Delete = Model.dbTheThanhVien.DeleteThe(The_Id, nguoicapnhat);
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
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
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

                        LoadThongTinTrongTheTheoId(The_Id);
                    }
                    else
                    {
                        UpdateDichVuTrongThe();

                        LoadThongTinTrongTheTheoId(The_Id);
                    }

                    alertControl1.Show(this, "Thông báo", "Đã cập nhật thông tin thành công thẻ " + txtSoThe.Text, "");
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }

        private void getdata()
        {
            //load combobox gioi tinh
            DataTable GioiTinh = Model.DbTiepNhan.GioiTinh();
            cbbGioiTinh.DataSource = GioiTinh;
            cbbGioiTinh.DisplayMember = "GioiTinh";
            cbbGioiTinh.ValueMember = "GioiTinh_id";

            //load combobox so thang hieu luc
            SoThangHieuLucThe = Model.dbTheThanhVien.SoThangHieuLucThe();
            cbbSoThang.DataSource = SoThangHieuLucThe;
            cbbSoThang.DisplayMember = "SoThangHieuLuc";
            cbbSoThang.ValueMember = "SoThangHieuLuc_id";

            //load combobox loai the
            DM_LoaiThe = Model.dbTheThanhVien.CbbLoaiThe();
            cbbLoaiThe.DataSource = DM_LoaiThe;
            cbbLoaiThe.DisplayMember = "TenLoaiThe";
            cbbLoaiThe.ValueMember = "LoaiThe_Id";

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

            DataTable SelectDanhSachTheThanhVien = Model.dbTheThanhVien.SelectDanhSachTheThanhVien(reSearch);
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

            DataTable CheckExistThongTinThe = Model.dbTheThanhVien.CheckExistThongTinThe(SoThe);
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

            DataTable CheckExistTheThanhVienTheoID = Model.dbTheThanhVien.CheckExistThongTinTheThanhVienTheoID(_The_Id);
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
            DataTable SelectDanhSachTheThanhVienTheoId = Model.dbTheThanhVien.SelectDanhSachTheThanhVienTheoId(_The_Id);

            txtSoThe.Text = SelectDanhSachTheThanhVienTheoId.Rows[0]["SoThe"].ToString();
            txtTenThe.Text = SelectDanhSachTheThanhVienTheoId.Rows[0]["TenThe"].ToString();

            string SoThangHieuLuc = SelectDanhSachTheThanhVienTheoId.Rows[0]["SoThang"].ToString();
            if (!String.IsNullOrEmpty(SoThangHieuLuc))
            {
                cbbSoThang.Value = Int32.Parse(SelectDanhSachTheThanhVienTheoId.Rows[0]["SoThang"].ToString());
            }

            string NgayHieuLuc = SelectDanhSachTheThanhVienTheoId.Rows[0]["NgayHieuLuc"].ToString();
            if (!String.IsNullOrEmpty(NgayHieuLuc))
            {
                DateTime enteredDate = DateTime.Parse(NgayHieuLuc);
                txtHieuLuc.Value = enteredDate;
            }

            //load thong tin trong the
            DataTable LoadThongTinTrongTheTheoId = Model.dbTheThanhVien.LoadThongTinTrongTheTheoId(_The_Id);
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

                string LoaiThe = LoadThongTinTrongTheTheoId.Rows[0]["LoaiThe_Id"].ToString();
                if (!String.IsNullOrEmpty(LoaiThe))
                {
                    cbbLoaiThe.Value = Int32.Parse(LoadThongTinTrongTheTheoId.Rows[0]["LoaiThe_Id"].ToString());
                }

                The_Id = LoadThongTinTrongTheTheoId.Rows[0]["The_Id"].ToString();
                The_DichVu_Id = LoadThongTinTrongTheTheoId.Rows[0]["The_DichVu_Id"].ToString();
                BenhNhan_Id = LoadThongTinTrongTheTheoId.Rows[0]["BenhNhan_Id"].ToString();
            }

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
                DataTable UpdateBenhNhan = Model.dbTheThanhVien.UpdateBenhNhan(
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
            string TenThe = "N'" + txtTenThe.Text.Replace("'", "''") + "'";
            string SoThangHieuLuc = "null";
            if (cbbSoThang.SelectedItem != null) { SoThangHieuLuc = cbbSoThang.Value.ToString(); }

            string NgayHieuLuc = "null";
            if (!string.IsNullOrEmpty(txtHieuLuc.Text)) { NgayHieuLuc = "'" + txtHieuLuc.Value.ToString("yyyyMMdd") + "'"; }

            DataTable Insert_ThongTinThe = Model.dbTheThanhVien.Insert_ThongTinThe(
                  SoThe
                , TenThe
                , SoThangHieuLuc
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
            string TenThe = "N'" + txtTenThe.Text.Replace("'", "''") + "'";
            string SoThangHieuLuc = "null";
            if (cbbSoThang.SelectedItem != null) { SoThangHieuLuc = cbbSoThang.Value.ToString(); }

            string NgayHieuLuc = "null";
            if (!string.IsNullOrEmpty(txtHieuLuc.Text)) { NgayHieuLuc = "'" + txtHieuLuc.Value.ToString("yyyyMMdd") + "'"; }

            DataTable Update_ThongTinThe = Model.dbTheThanhVien.Update_ThongTinThe(
                  SoThe
                , TenThe
                , SoThangHieuLuc
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

            string reLoaiThe_Id = "null";
            if (cbbLoaiThe.SelectedItem != null) { reLoaiThe_Id = cbbLoaiThe.Value.ToString(); }

            DataTable InsertDichVuTrongThe = Model.dbTheThanhVien.InsertDichVuTrongThe(
                   The_Id
                   , reBenhNhan_Id
                   , reLoaiThe_Id
                   , Login.User_Id
                   , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                   , "0"
                   );
        }

        private void UpdateDichVuTrongThe()
        {
            string reBenhNhan_Id = "null";
            if (BenhNhan_Id != "") { reBenhNhan_Id = "N'" + BenhNhan_Id + "'"; }

            string reLoaiThe_Id = "null";
            if (cbbLoaiThe.SelectedItem != null) { reLoaiThe_Id = cbbLoaiThe.Value.ToString(); }

            DataTable DelDichVuTrongThe = Model.dbTheThanhVien.DeleteDichVuTrongThe(
                       The_Id
                       , Login.User_Id
                       , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                       );


            DataTable UpdateDichVuTrongThe = Model.dbTheThanhVien.UpdateDichVuTrongThe(
                   The_Id
                   , reBenhNhan_Id
                   , reLoaiThe_Id
                   , Login.User_Id
                   , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                   , "0"
                   );
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            int n = e.RowHandle;
            if (gridView1.RowCount > 0)
            {
                The_Id = gridView1.GetRowCellValue(n, "The_Id").ToString();

                txtSoThe.Text = "";
                txtTenThe.Text = "";
                cbbSoThang.SelectedIndex = 3;
                //txtHieuLuc.Text = DateTime.Today.ToString("dd/MM/yyyy");

                txtMaYTe.Text = "";
                txtHoTen.Text = "";
                cbbGioiTinh.Text = "";
                txtNamSinh.Text = "";
                txtSoDienThoai.Text = "";
                cbbLoaiThe.Text = "";

                LoadThongTinTrongTheTheoId(The_Id);
            }
        }

        public void Reset()
        {
            txtSoThe.Text = "";
            txtTenThe.Text = "";
            //txtHieuLuc.Text = DateTime.Today.ToString("dd/MM/yyyy");
            cbbSoThang.SelectedIndex = 3;

            txtMaYTe.Text = "";
            txtHoTen.Text = "";
            cbbGioiTinh.Text = "";
            txtNamSinh.Text = "";
            txtSoDienThoai.Text = "";

            The_Id = "";
            MaYTe = "";
            SoVaoVien = "";
        }

        private void btnSearch_BN_Click(object sender, EventArgs e)
        {
            View.TheThanhVien.TimKiemBenhNhan tc = new View.TheThanhVien.TimKiemBenhNhan(this);
            tc.ShowDialog();
        }

        private void cbbSoThang_ValueChanged(object sender, EventArgs e)
        {
            DateTime dateNow = DateTime.Now;
            dateNow = dateNow.AddMonths(int.Parse(cbbSoThang.Text));

            txtHieuLuc.Text = dateNow.ToString("dd/MM/yyyy");
        }

        private void cbbLoaiThe_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Tab && e.KeyData != Keys.Enter && e.KeyData != Keys.Up && e.KeyData != Keys.Down && e.KeyData != Keys.Right && e.KeyData != Keys.Left)
            {
                string text = cbbLoaiThe.Text;
                DataRow[] resultRow = DM_LoaiThe.Select("TenLoaiThe LIKE '%" + text + "%' or MaLoaiThe LIKE '%" + text + "%'");
                if (resultRow.Count() > 0)
                {
                    DataTable dtResult = DM_LoaiThe.Select("TenLoaiThe LIKE '%" + text + "%' or MaLoaiThe LIKE '%" + text + "%'").CopyToDataTable();
                    cbbLoaiThe.DataSource = dtResult;
                    cbbLoaiThe.DroppedDown = true;
                }
                else
                {
                    cbbLoaiThe.DataSource = null;
                    cbbLoaiThe.DroppedDown = true;
                }
            }
        }
    }
}