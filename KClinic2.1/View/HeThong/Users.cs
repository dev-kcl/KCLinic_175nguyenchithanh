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

namespace KClinic2._1.View.HeThong
{
    public partial class Users : DevExpress.XtraEditors.XtraForm
    {
        public string DM_Id;
        public string ThaoTac;
        DataTable CBBBenhVien;
        public Users()
        {
            InitializeComponent();
        }

        private void Users_Load(object sender, EventArgs e)
        {
            CBBBenhVien = Model.db.CBBBenhVien();
            cbbBenhVien.DataSource = CBBBenhVien;
            cbbBenhVien.ValueMember = "FieldCode";
            cbbBenhVien.DisplayMember = "FieldName";
            DataTable SelectUser = Model.db.SelectUser();
            gridDichVu.DataSource = SelectUser;
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
            txtUserCode.Focus();
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
            txtUserCode.Focus();
            //
            LoadThongTinForm();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtUserCode.Text == "")
            {
                alertControl1.Show(this, "Thông báo", "UserCode không được để trống! ", "");
            }
            else if (txtUserName.Text == "")
            {
                alertControl1.Show(this, "Thông báo", "UserName không được để trống! ", "");
            }
            else if (txtPassword.Text == "")
            {
                alertControl1.Show(this, "Thông báo", "Pasword không được để trống! ", "");
            }
            else
            {
                string UserCode = "N'" + txtUserCode.Text.Replace("'", "''") + "'";
                string UserName = "N'" + txtUserName.Text.Replace("'", "''") + "'";
                string Password = "N'" + Model.Crypt.Encrypt_Password(txtPassword.Text.Replace("'", "''")) + "'";

                string BenhVien = "null";
                if (cbbBenhVien.SelectedItem != null)
                {
                    BenhVien = "N'" + cbbBenhVien.Value.ToString().Replace("'", "''") + "'";
                }

                string TamNgung = "0";
                if (cbTamNgung.Checked == false) { TamNgung = "0"; } else { TamNgung = "1"; }

                if (ThaoTac == "Them")
                {
                    DataTable Insert = Model.db.InsertUser(
                        UserCode
                        , UserName
                        , Password
                        , BenhVien
                        , TamNgung
                        , Login.User_Id
                        , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                        , "null"
                        , "null"
                        , "0"
                        );
                    if (Insert.Rows.Count > 0)
                    {
                        DM_Id = Insert.Rows[0]["User_Id"].ToString();
                        alertControl1.Show(this, "Thông báo", "Đã thêm thành công! " + Insert.Rows[0]["UserCode"].ToString(), "");
                    }
                }
                if (ThaoTac == "Sua")
                {
                    DataTable Update = Model.db.UpdateUser(
                          UserCode
                        , UserName
                        , Password
                        , BenhVien
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
                        DM_Id = Update.Rows[0]["User_Id"].ToString();
                        alertControl1.Show(this, "Thông báo", "Đã sửa thành công! " + Update.Rows[0]["UserCode"].ToString(), "");
                    }
                }
                //
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnLuu.Enabled = false;
                btnHuy.Enabled = false;
                btnXoa.Enabled = true;
                An();
                DataTable SelectUser = Model.db.SelectUser();
                gridDichVu.DataSource = SelectUser;
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
                    DataTable Delete = Model.db.DeleteUser(DM_Id, nguoicapnhat);
                    Reset();
                    DM_Id = "";
                    DataTable SelectUser = Model.db.SelectUser();
                    gridDichVu.DataSource = SelectUser;
                    alertControl1.Show(this, "Thông báo", "Đã xóa thành công! " + Delete.Rows[0]["UserCode"].ToString(), "");
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
                DM_Id = gridView1.GetRowCellValue(n, "User_Id").ToString();
                DataTable SelectUserTheoID = Model.db.SelectUserTheoID(DM_Id);
                {
                    if (SelectUserTheoID != null)
                    {
                        if (SelectUserTheoID.Rows.Count > 0)
                        {
                            txtUserCode.Text = SelectUserTheoID.Rows[0]["UserCode"].ToString();
                            txtUserName.Text = SelectUserTheoID.Rows[0]["UserName"].ToString();
                            txtPassword.Text = Model.Crypt.Decrypt_Password(SelectUserTheoID.Rows[0]["Password"].ToString());
                            string BenhVien_Id = SelectUserTheoID.Rows[0]["BenhVien_Id"].ToString();
                            if (!String.IsNullOrEmpty(BenhVien_Id))
                            {
                                cbbBenhVien.Value = BenhVien_Id;
                            }

                            string TamNgungTam = SelectUserTheoID.Rows[0]["TamNgung"].ToString();
                            if (TamNgungTam == "0") { cbTamNgung.Checked = false; } else { cbTamNgung.Checked = true; }

                            btnThem.Enabled = false;
                            btnSua.Enabled = false;
                            btnLuu.Enabled = true;
                            btnHuy.Enabled = true;
                            btnXoa.Enabled = true;
                            Hien();
                            ThaoTac = "Sua";
                            txtUserCode.Focus();
                        }
                    }
                }
            }
        }
        public void LoadThongTinForm()
        {
            DataTable SelectUserTheoID = Model.db.SelectUserTheoID(DM_Id);
            {
                if (SelectUserTheoID != null)
                {
                    if (SelectUserTheoID.Rows.Count > 0)
                    {
                        txtUserCode.Text = SelectUserTheoID.Rows[0]["UserCode"].ToString();
                        txtUserName.Text = SelectUserTheoID.Rows[0]["UserName"].ToString();
                        txtPassword.Text = Model.Crypt.Decrypt_Password(SelectUserTheoID.Rows[0]["Password"].ToString());
                        string BenhVien_Id = SelectUserTheoID.Rows[0]["BenhVien_Id"].ToString();
                        if (!String.IsNullOrEmpty(BenhVien_Id))
                        {
                            cbbBenhVien.Value = BenhVien_Id;
                        }

                        string TamNgungTam = SelectUserTheoID.Rows[0]["TamNgung"].ToString();
                        if (TamNgungTam == "0") { cbTamNgung.Checked = false; } else { cbTamNgung.Checked = true; }
                    }
                }
            }
        }
        public void Hien()
        {
            txtUserCode.Enabled = true;
            txtUserName.Enabled = true;
            cbbBenhVien.Enabled = true;
            txtPassword.Enabled = true;
            cbTamNgung.Enabled = true;
        }
        public void An()
        {
            txtUserCode.Enabled = false;
            txtUserName.Enabled = false;
            cbbBenhVien.Enabled = false;
            txtPassword.Enabled = false;
            cbTamNgung.Enabled = false;
        }
        public void Reset()
        {
            txtUserCode.Text = "";
            txtUserName.Text = "";
            txtPassword.Text = "";
            //cbbBenhVien.Text = "";
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