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
    public partial class DM_BacSiPhongKham : DevExpress.XtraEditors.XtraForm
    {
        public string DM_Id;
        public string ThaoTac;
        public DM_BacSiPhongKham()
        {
            InitializeComponent();
        }
        DataTable CBBPhongBan_PhongKham;
        DataTable CBBUser_PhongKham;
        DataTable CBBBacSi_PhongKham;
        private void DM_BacSiPhongKham_Load(object sender, EventArgs e)
        {
            DataTable SelectDM_BacSi_PhongKham_User = Model.dbDanhMuc.SelectDM_BacSi_PhongKham_User();
            gridDichVu.DataSource = SelectDM_BacSi_PhongKham_User;
            CBBPhongBan_PhongKham = Model.dbDanhMuc.CBBPhongBan_PhongKham();
            cbbPhongKham.DataSource = CBBPhongBan_PhongKham;
            cbbPhongKham.ValueMember = "FieldCode";
            cbbPhongKham.DisplayMember = "FieldName";
            CBBUser_PhongKham = Model.dbDanhMuc.CBBUser_PhongKham();
            cbbUser.DataSource = CBBUser_PhongKham;
            cbbUser.ValueMember = "FieldCode";
            cbbUser.DisplayMember = "FieldName";
            CBBBacSi_PhongKham = Model.dbDanhMuc.CBBBacSi_PhongKham();
            cbbBacSi.DataSource = CBBBacSi_PhongKham;
            cbbBacSi.ValueMember = "FieldCode";
            cbbBacSi.DisplayMember = "FieldName";
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
            cbbUser.Focus();
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
            cbbUser.Focus();
            //
            LoadThongTinForm();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (cbbUser.Text == "")
            {
                alertControl1.Show(this, "Thông báo", "Chưa chọn User! ", "");
            }
            else if (cbbPhongKham.Text == "")
            {
                alertControl1.Show(this, "Thông báo", "Chưa chọn Phòng khám! ", "");
            }
            else if (cbbBacSi.Text == "")
            {
                alertControl1.Show(this, "Thông báo", "Chưa chọn Bác sĩ! ", "");
            }
            else
            {
                
                string User = "null";
                if (cbbUser.SelectedItem != null) { User = "N'" + cbbUser.Value.ToString().Replace("'", "''") + "'"; }
                string PhongKham = "null";
                if (cbbPhongKham.SelectedItem != null) { PhongKham = "N'" + cbbPhongKham.Value.ToString().Replace("'", "''") + "'"; }
                string BacSi = "null";
                if (cbbBacSi.SelectedItem != null) { BacSi = "N'" + cbbBacSi.Value.ToString().Replace("'", "''") + "'"; }
                if (ThaoTac == "Them")
                {
                    DataTable Insert = Model.dbDanhMuc.InsertDM_BacSi_PhongKham_User(
                        User
                        , BacSi
                        , PhongKham
                        , "0"
                        , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                        , Login.User_Id
                        , "null"
                        , "null"
                        );
                    if (Insert.Rows.Count > 0)
                    {
                        DM_Id = Insert.Rows[0]["MapKhamBenh_Id"].ToString();
                        alertControl1.Show(this, "Thông báo", "Đã thêm thành công! ", "");
                    }
                }
                if (ThaoTac == "Sua")
                {
                    DataTable Update = Model.dbDanhMuc.UpdateDM_BacSi_PhongKham_User(
                          DM_Id
                        , User
                        , BacSi
                        , PhongKham
                        , "0"
                        , "null"
                        , "null"
                        , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                        , Login.User_Id
                        );
                    if (Update.Rows.Count > 0)
                    {
                        DM_Id = Update.Rows[0]["MapKhamBenh_Id"].ToString();
                        alertControl1.Show(this, "Thông báo", "Đã sửa thành công! ", "");
                    }
                }
                //
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnLuu.Enabled = false;
                btnHuy.Enabled = false;
                btnXoa.Enabled = true;
                An();
                DataTable SelectDM_BacSi_PhongKham_User = Model.dbDanhMuc.SelectDM_BacSi_PhongKham_User();
                gridDichVu.DataSource = SelectDM_BacSi_PhongKham_User;
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
                    DataTable Delete = Model.dbDanhMuc.DeleteDM_BacSi_PhongKham_User(DM_Id, nguoicapnhat);
                    Reset();
                    DM_Id = "";
                    DataTable SelectDM_BacSi_PhongKham_User = Model.dbDanhMuc.SelectDM_BacSi_PhongKham_User();
                    gridDichVu.DataSource = SelectDM_BacSi_PhongKham_User;
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
                DM_Id = gridView1.GetRowCellValue(n, "MapKhamBenh_Id").ToString();
                DataTable SelecDM_BacSi_PhongKham_UserTheoID = Model.dbDanhMuc.SelecDM_BacSi_PhongKham_UserTheoID(DM_Id);
                {
                    if (SelecDM_BacSi_PhongKham_UserTheoID != null)
                    {
                        if (SelecDM_BacSi_PhongKham_UserTheoID.Rows.Count > 0)
                        {
                            string User_Id = SelecDM_BacSi_PhongKham_UserTheoID.Rows[0]["User_Id"].ToString();
                            if (!String.IsNullOrEmpty(User_Id))
                            {
                                cbbUser.Value = User_Id;
                            }
                            string BacSi_Id = SelecDM_BacSi_PhongKham_UserTheoID.Rows[0]["BacSi_Id"].ToString();
                            if (!String.IsNullOrEmpty(BacSi_Id))
                            {
                                cbbBacSi.Value = BacSi_Id;
                            }
                            string PhongBan_Id = SelecDM_BacSi_PhongKham_UserTheoID.Rows[0]["PhongBan_Id"].ToString();
                            if (!String.IsNullOrEmpty(PhongBan_Id))
                            {
                                cbbPhongKham.Value = PhongBan_Id;
                            }
                            btnThem.Enabled = false;
                            btnSua.Enabled = false;
                            btnLuu.Enabled = true;
                            btnHuy.Enabled = true;
                            btnXoa.Enabled = true;
                            Hien();
                            ThaoTac = "Sua";
                            cbbUser.Focus();
                        }
                    }
                }
            }
        }
        public void LoadThongTinForm()
        {
            DataTable SelecDM_BacSi_PhongKham_UserTheoID = Model.dbDanhMuc.SelecDM_BacSi_PhongKham_UserTheoID(DM_Id);
            {
                if (SelecDM_BacSi_PhongKham_UserTheoID != null)
                {
                    if (SelecDM_BacSi_PhongKham_UserTheoID.Rows.Count > 0)
                    {
                        string User_Id = SelecDM_BacSi_PhongKham_UserTheoID.Rows[0]["User_Id"].ToString();
                        if (!String.IsNullOrEmpty(User_Id))
                        {
                            cbbUser.Value = User_Id;
                        }
                        string BacSi_Id = SelecDM_BacSi_PhongKham_UserTheoID.Rows[0]["BacSi_Id"].ToString();
                        if (!String.IsNullOrEmpty(BacSi_Id))
                        {
                            cbbBacSi.Value = BacSi_Id;
                        }
                        string PhongBan_Id = SelecDM_BacSi_PhongKham_UserTheoID.Rows[0]["PhongBan_Id"].ToString();
                        if (!String.IsNullOrEmpty(PhongBan_Id))
                        {
                            cbbPhongKham.Value = PhongBan_Id;
                        }
                    }
                }
            }
        }
        public void Hien()
        {
            cbbUser.Enabled = true;
            cbbBacSi.Enabled = true;
            cbbPhongKham.Enabled = true;
        }
        public void An()
        {
            cbbUser.Enabled = false;
            cbbBacSi.Enabled = false;
            cbbPhongKham.Enabled = false;
        }
        public void Reset()
        {
            cbbUser.Text = "";
            cbbBacSi.Text = "";
            cbbPhongKham.Text = "";
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