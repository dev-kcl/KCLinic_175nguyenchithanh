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
    public partial class DanhMucLoaiThe : DevExpress.XtraEditors.XtraForm
    {
        public string LoaiThe_Id = "";
        public string MaLoaiThe = "";
        public string LoaiThe_DichVu_Id = "";
        public string NhomDichVu_Id = "";

        DataTable Dm_NhomDichVu;

        public DanhMucLoaiThe()
        {
            InitializeComponent();
        }

        private void DanhMucLoaiThe_Load(object sender, EventArgs e)
        {
            getdata();
            Reset();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaLoaiThe.Text == "")
            {
                XtraMessageBox.Show("Mã loại thẻ không được để trống!", "Thông Báo");
                txtMaLoaiThe.Focus();
                return;
            }


            //dang ky thong tin
            string MaLoaiThe = "N'" + txtMaLoaiThe.Text.Replace("'", "''") + "'";

            int checkLoaiThe = CheckExistThongTinLoaiThe(MaLoaiThe);

            if (checkLoaiThe == 0)
            {
                InsertThongTinLoaiThe();
            }
            else
            {
                UpdateThongTinLoaiThe();
            }

            getLayDanhSachLoaiThe();

            txtMaLoaiThe.Text = "";
            txtTenLoaiThe.Text = "";
            txtGhiChu.Text = "";
            //end dang ky thong tin
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (LoaiThe_Id == "")
            {
                XtraMessageBox.Show("Bạn chưa chọn Loại thẻ!", "Thông Báo");
                return;
            }

            string nguoicapnhat = Login.User_Id;
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn xóa thẻ không?", "Thông Báo!", MessageBoxButtons.YesNo);
            switch (dr)
            {
                case DialogResult.Yes:
                    DataTable Delete = Model.dbTheThanhVien.DeleteLoaiThe(LoaiThe_Id, nguoicapnhat);
                    alertControl1.Show(this, "Thông báo", "Đã xóa thành công loại thẻ " + txtMaLoaiThe.Text, "");
                    Reset();
                    LoaiThe_Id = "";

                    getdata();
                    break;
                case DialogResult.No:
                    break;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (LoaiThe_Id == "")
            {
                XtraMessageBox.Show("Bạn chưa chọn Loại thẻ!", "Thông Báo");
                return;
            }
            else
            {
                LoadThongTinLoaiTheTheoId(LoaiThe_Id);
                DataTable ThemLoaiTheVaoPhienDangNhap = Model.dbTheThanhVien.ThemLoaiTheVaoPhienDangNhap(Login.PhienDangNhap_Id, LoaiThe_Id);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChonDichVu_Click(object sender, EventArgs e)
        {

        }

        private void btnThemNhomBenh_Click(object sender, EventArgs e)
        {
            if (LoaiThe_Id == "" || string.IsNullOrEmpty(LoaiThe_Id))
            {
                XtraMessageBox.Show("Bạn chưa chọn Loại thẻ!", "Thông Báo");
                return;
            }

            if (txtSoLuong.Text.Trim() == "")
            {
                XtraMessageBox.Show("Bạn chưa nhập Số lượng cho Nhóm dịch vụ!", "Thông Báo");
                return;
            }

            if (cbbNhomBenh.SelectedItem != null)
            {
                DataRowView typeItem = (DataRowView)cbbNhomBenh.SelectedItem;
                string NhomBenh_Id = typeItem.Row[0].ToString();
                string NhomBenh_Name = typeItem.Row[1].ToString();
                string SoLuong = txtSoLuong.Text.Trim();

                InsertLoaiThePhienDangNhap(NhomBenh_Id, SoLuong);

                //
                DataTable SelectClsyeucauPhienDangNhap = Model.dbTheThanhVien.SelectLoaiThe_PhienDangNhap(Login.PhienDangNhap_Id);
                gridDichVu.DataSource = SelectClsyeucauPhienDangNhap;
            }
            else
            {
                XtraMessageBox.Show("Chưa chọn Nhóm bệnh!", "Thông Báo");
            }
        }

        private void btnXoaDichVu_Click(object sender, EventArgs e)
        {
            if (LoaiThe_Id != "" && NhomDichVu_Id != "")
            {
                DataTable Delete = Model.dbTheThanhVien.Delete_LoaiThe_PhienDangNhap(LoaiThe_Id, NhomDichVu_Id, Login.User_Id);

                DataTable SelectClsyeucauPhienDangNhap = Model.dbTheThanhVien.SelectLoaiThe_PhienDangNhap(Login.PhienDangNhap_Id);
                gridDichVu.DataSource = SelectClsyeucauPhienDangNhap;
                NhomDichVu_Id = "";
            }
            else
            {
                alertControl1.Show(this, "Thông báo", "Chưa chọn dịch vụ cần xóa!", "");
            }
        }

        private void btnUpdateDV_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn cập nhật thông tin loại thẻ?", "Thông Báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (LoaiThe_Id == "")
                {
                    XtraMessageBox.Show("Chưa chọn Loại thẻ cần cập nhật!", "Thông Báo");
                    return;
                }
                else
                {
                    //check dich vu trong the
                    int checkThe = CheckExistThongTinLoaiTheTheoID(LoaiThe_Id);

                    if (checkThe == 0)
                    {
                        InsertDichVuTrongLoaiThe();

                        DataTable HoanTatClsYeuCauPhienDangNhap = Model.dbTheThanhVien.HoanTatLoaiThePhienDangNhap(Login.PhienDangNhap_Id);

                        LoadThongTinLoaiTheTheoId(LoaiThe_Id);
                    }
                    else
                    {
                        UpdateDichVuTrongThe();

                        DataTable HoanTatClsYeuCauPhienDangNhap = Model.dbTheThanhVien.HoanTatLoaiThePhienDangNhap(Login.PhienDangNhap_Id);

                        LoadThongTinLoaiTheTheoId(LoaiThe_Id);
                    }

                    alertControl1.Show(this, "Thông báo", "Đã cập nhật thông tin thành công loại thẻ " + txtMaLoaiThe.Text, "");
                }

                DataTable ThemLoaiTheVaoPhienDangNhap = Model.dbTheThanhVien.ThemLoaiTheVaoPhienDangNhap(Login.PhienDangNhap_Id, LoaiThe_Id);
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }

        private void getdata()
        {
            Dm_NhomDichVu = Model.DbTiepNhan.Dm_NhomBenh();
            cbbNhomBenh.DataSource = Dm_NhomDichVu;
            cbbNhomBenh.ValueMember = "NhomBenh_Id";
            cbbNhomBenh.DisplayMember = "TenNhomBenh";

            //load thong tin the
            getLayDanhSachLoaiThe();

            //load dich vu theo the
            if (gridView1.RowCount > 0)
            {
                LoaiThe_Id = gridView1.GetRowCellValue(0, "LoaiThe_Id").ToString();
                gridView1.FocusedRowHandle = 0;
                gridView1.SelectRow(0);
                LoadThongTinLoaiTheTheoId(LoaiThe_Id);
            }

            txtMaLoaiThe.Focus();
        }

        private void getLayDanhSachLoaiThe(string search = "")
        {
            string reSearch = "N'" + search.Replace("'", "''") + "'";

            DataTable SelectDanhSachLoaiThe = Model.dbTheThanhVien.SelectDanhSachLoaiThe(reSearch);
            gridTheThanhVien.DataSource = SelectDanhSachLoaiThe;
        }

        private int CheckExistThongTinLoaiThe(string MaLoaiThe)
        {
            int count = 0;

            DataTable CheckExistThongTinLoaiThe = Model.dbTheThanhVien.CheckExistThongTinLoaiThe(MaLoaiThe);
            if (CheckExistThongTinLoaiThe.Rows.Count > 0)
            {
                if (int.Parse(CheckExistThongTinLoaiThe.Rows[0]["count_the"].ToString()) > 0)
                {
                    count = int.Parse(CheckExistThongTinLoaiThe.Rows[0]["count_the"].ToString());
                }
            }

            return count;
        }

        private int CheckExistThongTinLoaiTheTheoID(string _LoaiThe_Id)
        {
            int count = 0;

            DataTable CheckExistLoaiTheTheoID = Model.dbTheThanhVien.CheckExistThongTinLoaiTheTheoID(_LoaiThe_Id);
            if (CheckExistLoaiTheTheoID.Rows.Count > 0)
            {
                if (int.Parse(CheckExistLoaiTheTheoID.Rows[0]["count_the"].ToString()) > 0)
                {
                    count = int.Parse(CheckExistLoaiTheTheoID.Rows[0]["count_the"].ToString());
                }
            }

            return count;
        }

        private void LoadThongTinLoaiTheTheoId(string _LoaiThe_Id)
        {
            //load the
            DataTable SelectDanhMucLoaiTheTheoId = Model.dbTheThanhVien.SelectDanhMucLoaiTheTheoId(_LoaiThe_Id);

            txtMaLoaiThe.Text = SelectDanhMucLoaiTheTheoId.Rows[0]["MaLoaiThe"].ToString();
            txtTenLoaiThe.Text = SelectDanhMucLoaiTheTheoId.Rows[0]["TenLoaiThe"].ToString();
            txtGhiChu.Text = SelectDanhMucLoaiTheTheoId.Rows[0]["GhiChu"].ToString();

            //load thong tin trong the
            DataTable LoadThongTinTrongLoaiTheTheoId = Model.dbTheThanhVien.LoadThongTinTrongLoaiTheTheoId(_LoaiThe_Id);
            if (LoadThongTinTrongLoaiTheTheoId != null)
            {
                if (LoadThongTinTrongLoaiTheTheoId.Rows.Count > 0)
                {
                    LoaiThe_Id = LoadThongTinTrongLoaiTheTheoId.Rows[0]["LoaiThe_Id"].ToString();
                    LoaiThe_DichVu_Id = LoadThongTinTrongLoaiTheTheoId.Rows[0]["LoaiThe_DichVu_Id"].ToString();
                }
            }

            //load dich vu
            gridDichVu.DataSource = LoadThongTinTrongLoaiTheTheoId;

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, "LoaiThe_Id").ToString() == LoaiThe_Id)
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

        private void InsertThongTinLoaiThe()
        {
            string MaLoaiThe = "N'" + txtMaLoaiThe.Text.Replace("'", "''") + "'";
            string TenLoaiThe = "N'" + txtTenLoaiThe.Text.Replace("'", "''") + "'";
            string GhiChu = "N'" + txtGhiChu.Text.Replace("'", "''") + "'";

            DataTable Insert_ThongTinThe = Model.dbTheThanhVien.Insert_ThongTinLoaiThe(
                  MaLoaiThe
                , TenLoaiThe
                , GhiChu
                , Login.User_Id
                , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                , "0"
                );

            if (Insert_ThongTinThe.Rows.Count > 0)
            {
                LoaiThe_Id = Insert_ThongTinThe.Rows[0]["LoaiThe_Id"].ToString();
            }

            alertControl1.Show(this, "Thông báo", "Đã thêm thành công Loại thẻ " + txtMaLoaiThe.Text.Trim(), "");
        }

        private void UpdateThongTinLoaiThe()
        {
            string MaLoaiThe = "N'" + txtMaLoaiThe.Text.Replace("'", "''") + "'";
            string TenLoaiThe = "N'" + txtTenLoaiThe.Text.Replace("'", "''") + "'";
            string GhiChu = "N'" + txtGhiChu.Text.Replace("'", "''") + "'";

            DataTable Update_ThongTinLoaiThe = Model.dbTheThanhVien.Update_ThongTinLoaiThe(
                  MaLoaiThe
                , TenLoaiThe
                , GhiChu
                , Login.User_Id
                , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                );

            if (Update_ThongTinLoaiThe.Rows.Count > 0)
            {
                LoaiThe_Id = Update_ThongTinLoaiThe.Rows[0]["LoaiThe_Id"].ToString();
            }

            alertControl1.Show(this, "Thông báo", "Đã cập nhật thành công Loại thẻ " + txtMaLoaiThe.Text.Trim(), "");
        }

        private void InsertDichVuTrongLoaiThe()
        {
            string reSoLuong;
            string reNhomDichVu_Id;

            DataTable gridDichVuDaTa = gridDichVu.DataSource as DataTable;
            foreach (DataRow row in gridDichVuDaTa.Rows)
            {
                reSoLuong = "null";
                reNhomDichVu_Id = "null";

                if (row["SoLuong"].ToString() != "") { reSoLuong = "N'" + row["SoLuong"].ToString() + "'"; }
                if (row["NhomDichVu_Id"].ToString() != "") { reNhomDichVu_Id = "N'" + row["NhomDichVu_Id"].ToString() + "'"; }

                DataTable InsertDichVuTrongThe = Model.dbTheThanhVien.InsertDichVuTrongLoaiThe(
                       LoaiThe_Id
                       , reNhomDichVu_Id
                       , reSoLuong
                       , Login.User_Id
                       , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                       , "0"
                       );
            }
        }

        private void UpdateDichVuTrongThe()
        {
            string reSoLuong;
            string reNhomDichVu_Id;

            DataTable DelDichVuTrongLoaiThe = Model.dbTheThanhVien.DeleteDichVuTrongLoaiThe(
                       LoaiThe_Id
                       , Login.User_Id
                       , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                       );

            DataTable gridDichVuDaTa = gridDichVu.DataSource as DataTable;
            foreach (DataRow row in gridDichVuDaTa.Rows)
            {
                reSoLuong = "null";
                reNhomDichVu_Id = "null";

                if (row["SoLuong"].ToString() != "") { reSoLuong = "N'" + row["SoLuong"].ToString() + "'"; }
                if (row["NhomDichVu_Id"].ToString() != "") { reNhomDichVu_Id = "N'" + row["NhomDichVu_Id"].ToString() + "'"; }

                DataTable UpdateDichVuTrongLoaiThe = Model.dbTheThanhVien.UpdateDichVuTrongLoaiThe(
                       LoaiThe_Id
                       , reNhomDichVu_Id
                       , reSoLuong
                       , Login.User_Id
                       , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                       , "0"
                       );
            }
        }

        private void InsertThePhienDangNhap(string _DichVu_Id)
        {
            DataTable InsertThe_PhienDangNhap = Model.dbTheThanhVien.InsertThe_PhienDangNhap(
                    Login.PhienDangNhap_Id
                    , LoaiThe_Id
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
            //            DataTable InsertCLSYeuCau_PhieuDangNhapCapDuoi = Model.dbTheThanhVien.InsertThe_PhienDangNhap(
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

        private void InsertLoaiThePhienDangNhap(string _NhomDichVu_Id, string _SoLuong)
        {
            DataTable InsertThe_PhienDangNhap = Model.dbTheThanhVien.InsertLoaiThe_PhienDangNhap(
                    Login.PhienDangNhap_Id
                    , LoaiThe_Id
                    , _NhomDichVu_Id
                    , _SoLuong
                    , "N'" + "Them" + "'"
                    );
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            int n = e.RowHandle;
            if (gridView1.RowCount > 0)
            {
                LoaiThe_Id = gridView1.GetRowCellValue(n, "LoaiThe_Id").ToString();

                txtMaLoaiThe.Text = "";
                txtTenLoaiThe.Text = "";
                txtGhiChu.Text = "";

                LoadThongTinLoaiTheTheoId(LoaiThe_Id);
                
                DataTable ThemLoaiTheVaoPhienDangNhap = Model.dbTheThanhVien.ThemLoaiTheVaoPhienDangNhap(Login.PhienDangNhap_Id, LoaiThe_Id);
            }
        }

        private void gridView2_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            int n = e.RowHandle;
            if (n >= 0)
            {
                NhomDichVu_Id = gridView2.GetRowCellValue(n, "NhomDichVu_Id").ToString();
            }
        }

        private void cbbDV_KeyUp(object sender, KeyEventArgs e)
        {

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
            cbbNhomBenh.Text = "";
            gridDichVu.DataSource = null;

            LoaiThe_Id = "";

            DataTable HoanTatLoaiThePhienDangNhap = Model.dbTheThanhVien.HoanTatLoaiThePhienDangNhap(Login.PhienDangNhap_Id);
        }
    }
}