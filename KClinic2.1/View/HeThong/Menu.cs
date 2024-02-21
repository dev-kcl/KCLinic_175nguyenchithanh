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
    public partial class Menu : DevExpress.XtraEditors.XtraForm
    {
        public string DM_Id;
        public string ThaoTac;
        DataTable CBBMenu;
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            loadcbb();
            DataTable SelectMenu = Model.db.SelectMenu();
            gridDichVu.DataSource = SelectMenu;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            btnXoa.Enabled = false;
            An();
        }
        void loadcbb()
        {
            CBBMenu = Model.db.CBBMenu();
            cbbMenu.DataSource = CBBMenu;
            cbbMenu.ValueMember = "FieldCode";
            cbbMenu.DisplayMember = "FieldName";
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
            loadcbb();
            DM_Id = "";
            Reset();
            txtMenuCode.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            btnXoa.Enabled = false;
            Hien();
            loadcbb();
            ThaoTac = "Sua";
            txtMenuCode.Focus();
            //
            LoadThongTinForm();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMenuCode.Text == "")
            {
                alertControl1.Show(this, "Thông báo", "MenuCode không được để trống! ", "");
            }
            else if (txtMenuName.Text == "")
            {
                alertControl1.Show(this, "Thông báo", "MenuName không được để trống! ", "");
            }
            else
            {
                string MenuCode = "N'" + txtMenuCode.Text.Replace("'", "''") + "'";
                string MenuName = "N'" + txtMenuName.Text.Replace("'", "''") + "'";

                string ParentMenu = "null";
                if (cbbMenu.SelectedItem != null)
                {
                    ParentMenu = "N'" + cbbMenu.Value.ToString().Replace("'", "''") + "'";
                }

                string TamNgung = "0";
                if (cbTamNgung.Checked == false) { TamNgung = "0"; } else { TamNgung = "1"; }

                if (ThaoTac == "Them")
                {
                    DataTable Insert = Model.db.InsertMenu(
                        MenuCode
                        , MenuName
                        , ParentMenu
                        , TamNgung
                        , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                        , Login.User_Id
                        , "null"
                        , "null"
                        , "0"
                        );
                    if (Insert.Rows.Count > 0)
                    {
                        DM_Id = Insert.Rows[0]["Menu_Id"].ToString();
                        alertControl1.Show(this, "Thông báo", "Đã thêm thành công! " + Insert.Rows[0]["MenuCode"].ToString(), "");
                    }
                }
                if (ThaoTac == "Sua")
                {
                    DataTable Update = Model.db.UpdateMenu(
                           MenuCode
                        , MenuName
                        , ParentMenu
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
                        DM_Id = Update.Rows[0]["Menu_Id"].ToString();
                        alertControl1.Show(this, "Thông báo", "Đã sửa thành công! " + Update.Rows[0]["MenuCode"].ToString(), "");
                    }
                }
                //
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnLuu.Enabled = false;
                btnHuy.Enabled = false;
                btnXoa.Enabled = true;
                An();
                DataTable SelectMenu = Model.db.SelectMenu();
                gridDichVu.DataSource = SelectMenu;
                loadcbb();
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
                    DataTable Delete = Model.db.DeleteMenu(DM_Id, nguoicapnhat);
                    Reset();
                    DM_Id = "";
                    DataTable SelectMenu = Model.db.SelectMenu();
                    gridDichVu.DataSource = SelectMenu;
                    alertControl1.Show(this, "Thông báo", "Đã xóa thành công! " + Delete.Rows[0]["MenuCode"].ToString(), "");
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
                DM_Id = gridView1.GetRowCellValue(n, "Menu_Id").ToString();
                DataTable SelectMenuTheoID = Model.db.SelectMenuTheoID(DM_Id);
                {
                    if (SelectMenuTheoID != null)
                    {
                        if (SelectMenuTheoID.Rows.Count > 0)
                        {
                            txtMenuCode.Text = SelectMenuTheoID.Rows[0]["MenuCode"].ToString();
                            txtMenuName.Text = SelectMenuTheoID.Rows[0]["MenuName"].ToString();
                            string ParentMenu = SelectMenuTheoID.Rows[0]["ParentMenu"].ToString();
                            if (!String.IsNullOrEmpty(ParentMenu))
                            {
                                cbbMenu.Value = ParentMenu;
                            }

                            string TamNgungTam = SelectMenuTheoID.Rows[0]["TamNgung"].ToString();
                            if (TamNgungTam == "0") { cbTamNgung.Checked = false; } else { cbTamNgung.Checked = true; }

                            btnThem.Enabled = false;
                            btnSua.Enabled = false;
                            btnLuu.Enabled = true;
                            btnHuy.Enabled = true;
                            btnXoa.Enabled = true;
                            Hien();
                            ThaoTac = "Sua";
                            txtMenuCode.Focus();
                        }
                    }
                }
            }
        }
        public void LoadThongTinForm()
        {
            DataTable SelectMenuTheoID = Model.db.SelectMenuTheoID(DM_Id);
            {
                if (SelectMenuTheoID != null)
                {
                    if (SelectMenuTheoID.Rows.Count > 0)
                    {
                        txtMenuCode.Text = SelectMenuTheoID.Rows[0]["MenuCode"].ToString();
                        txtMenuName.Text = SelectMenuTheoID.Rows[0]["MenuName"].ToString();
                        string ParentMenu = SelectMenuTheoID.Rows[0]["ParentMenu"].ToString();
                        if (!String.IsNullOrEmpty(ParentMenu))
                        {
                            cbbMenu.Value = ParentMenu;
                        }

                        string TamNgungTam = SelectMenuTheoID.Rows[0]["TamNgung"].ToString();
                        if (TamNgungTam == "0") { cbTamNgung.Checked = false; } else { cbTamNgung.Checked = true; }
                    }
                }
            }
        }
        public void Hien()
        {
            txtMenuCode.Enabled = true;
            txtMenuName.Enabled = true;
            cbbMenu.Enabled = true;
            cbTamNgung.Enabled = true;
        }
        public void An()
        {
            txtMenuCode.Enabled = false;
            txtMenuName.Enabled = false;
            cbbMenu.Enabled = false;
            cbTamNgung.Enabled = false;
        }
        public void Reset()
        {
            txtMenuCode.Text = "";
            txtMenuName.Text = "";
            cbbMenu.Text = "";
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