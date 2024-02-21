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
    public partial class Dictionary : DevExpress.XtraEditors.XtraForm
    {
        public string DM_Id;
        public string ThaoTac;
        public Dictionary()
        {
            InitializeComponent();
        }

        private void Dictionary_Load(object sender, EventArgs e)
        {
            DataTable SelectK_Dictionary = Model.dbDanhMuc.SelectK_Dictionary();
            gridDichVu.DataSource = SelectK_Dictionary;
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
            txtDictionary_Code.Focus();
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
            txtDictionary_Code.Focus();
            //
            LoadThongTinForm();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtDictionary_Code.Text == "")
            {
                alertControl1.Show(this, "Thông báo", "Dictionary_Code không được để trống!", "");
            }
            else if (txtDictionary_Name.Text == "")
            {
                alertControl1.Show(this, "Thông báo", "Dictionary_Name không được để trống!", "");
            }
            else
            {
                string Dictionary_Code = "N'" + txtDictionary_Code.Text.Replace("'", "''") + "'";
                string Dictionary_Name_Id = "null"; if (txtDictionary_Name_Id.Text != "") { Dictionary_Name_Id = "N'" + txtDictionary_Name_Id.Text.Replace("'", "''") + "'"; }
                string Dictionary_Name = "N'" + txtDictionary_Name.Text.Replace("'", "''") + "'";
                string DienGiai1 = "null"; if (txtDienGiai1.Text != "") { DienGiai1 = "N'" + txtDienGiai1.Text.Replace("'", "''") + "'"; }
                string DienGiai2 = "null"; if (txtDienGiai2.Text != "") { DienGiai2 = "N'" + txtDienGiai2.Text.Replace("'", "''") + "'"; }
                string DienGiai3 = "null"; if (txtDienGiai3.Text != "") { DienGiai3 = "N'" + txtDienGiai3.Text.Replace("'", "''") + "'"; }
                string DienGiai4 = "null"; if (txtDienGiai4.Text != "") { DienGiai4 = "N'" + txtDienGiai4.Text.Replace("'", "''") + "'"; }
                string DienGiai5 = "null"; if (txtDienGiai5.Text != "") { DienGiai5 = "N'" + txtDienGiai5.Text.Replace("'", "''") + "'"; }
                string TamNgung = "0";
                if (cbTamNgung.Checked == false) { TamNgung = "0"; } else { TamNgung = "1"; }

                if (ThaoTac == "Them")
                {
                    DataTable Insert = Model.dbDanhMuc.InsertK_Dictionary(
                        Dictionary_Code
                        , Dictionary_Name_Id
                        , Dictionary_Name
                        , DienGiai1
                        , DienGiai2
                        , DienGiai3
                        , DienGiai4
                        , DienGiai5
                        , TamNgung
                        , "0"
                        , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                        , Login.User_Id
                        , "null"
                        , "null"
                        
                        );
                    if (Insert.Rows.Count > 0)
                    {
                        DM_Id = Insert.Rows[0][0].ToString();
                        alertControl1.Show(this, "Thông báo", "Đã thêm thành công!", "");
                    }
                }
                if (ThaoTac == "Sua")
                {
                    DataTable Update = Model.dbDanhMuc.UpdateK_Dictionary(
                         Dictionary_Code
                        , Dictionary_Name_Id
                        , Dictionary_Name
                        , DienGiai1
                        , DienGiai2
                        , DienGiai3
                        , DienGiai4
                        , DienGiai5
                        , TamNgung
                        , "0"
                        , "null"
                        , "null"
                        , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                        , Login.User_Id
                        , DM_Id
                        );
                    if (Update.Rows.Count > 0)
                    {
                        DM_Id = Update.Rows[0][0].ToString();
                        alertControl1.Show(this, "Thông báo", "Đã sửa thành công!", "");
                    }
                }
                //
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnLuu.Enabled = false;
                btnHuy.Enabled = false;
                btnXoa.Enabled = true;
                An();
                DataTable SelectK_Dictionary = Model.dbDanhMuc.SelectK_Dictionary();
                gridDichVu.DataSource = SelectK_Dictionary;
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
                    DataTable Delete = Model.dbDanhMuc.DeleteK_Dictionary(DM_Id, nguoicapnhat);
                    Reset();
                    DM_Id = "";
                    DataTable SelectK_Dictionary = Model.dbDanhMuc.SelectK_Dictionary();
                    gridDichVu.DataSource = SelectK_Dictionary;
                    alertControl1.Show(this, "Thông báo", "Đã xóa thành công!", "");
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
                DM_Id = gridView1.GetRowCellValue(n, "Dictionary_Id").ToString();
                DataTable SelecK_DictionaryTheoID = Model.dbDanhMuc.SelecK_DictionaryTheoID(DM_Id);
                {
                    if (SelecK_DictionaryTheoID != null)
                    {
                        if (SelecK_DictionaryTheoID.Rows.Count > 0)
                        {
                            txtDictionary_Code.Text = SelecK_DictionaryTheoID.Rows[0]["Dictionary_Code"].ToString();
                            txtDictionary_Name_Id.Text = SelecK_DictionaryTheoID.Rows[0]["Dictionary_Name_Id"].ToString();
                            txtDictionary_Name.Text = SelecK_DictionaryTheoID.Rows[0]["Dictionary_Name"].ToString();
                            txtDienGiai1.Text = SelecK_DictionaryTheoID.Rows[0]["DienGiai1"].ToString();
                            txtDienGiai2.Text = SelecK_DictionaryTheoID.Rows[0]["DienGiai2"].ToString();
                            txtDienGiai3.Text = SelecK_DictionaryTheoID.Rows[0]["DienGiai3"].ToString();
                            txtDienGiai4.Text = SelecK_DictionaryTheoID.Rows[0]["DienGiai4"].ToString();
                            txtDienGiai5.Text = SelecK_DictionaryTheoID.Rows[0]["DienGiai5"].ToString();
                            string TamNgungTam = SelecK_DictionaryTheoID.Rows[0]["TamNgung"].ToString();
                            if (TamNgungTam == "0") { cbTamNgung.Checked = false; } else { cbTamNgung.Checked = true; }
                            btnThem.Enabled = false;
                            btnSua.Enabled = false;
                            btnLuu.Enabled = true;
                            btnHuy.Enabled = true;
                            btnXoa.Enabled = true;
                            Hien();
                            ThaoTac = "Sua";
                            txtDictionary_Code.Focus();
                        }
                    }
                }
            }
        }
        public void LoadThongTinForm()
        {
            DataTable SelecK_DictionaryTheoID = Model.dbDanhMuc.SelecK_DictionaryTheoID(DM_Id);
            {
                if (SelecK_DictionaryTheoID != null)
                {
                    if (SelecK_DictionaryTheoID.Rows.Count > 0)
                    {
                        txtDictionary_Code.Text = SelecK_DictionaryTheoID.Rows[0]["Dictionary_Code"].ToString();
                        txtDictionary_Name_Id.Text = SelecK_DictionaryTheoID.Rows[0]["Dictionary_Name_Id"].ToString();
                        txtDictionary_Name.Text = SelecK_DictionaryTheoID.Rows[0]["Dictionary_Name"].ToString();
                        txtDienGiai1.Text = SelecK_DictionaryTheoID.Rows[0]["DienGiai1"].ToString();
                        txtDienGiai2.Text = SelecK_DictionaryTheoID.Rows[0]["DienGiai2"].ToString();
                        txtDienGiai3.Text = SelecK_DictionaryTheoID.Rows[0]["DienGiai3"].ToString();
                        txtDienGiai4.Text = SelecK_DictionaryTheoID.Rows[0]["DienGiai4"].ToString();
                        txtDienGiai5.Text = SelecK_DictionaryTheoID.Rows[0]["DienGiai5"].ToString();
                        string TamNgungTam = SelecK_DictionaryTheoID.Rows[0]["TamNgung"].ToString();
                        if (TamNgungTam == "0") { cbTamNgung.Checked = false; } else { cbTamNgung.Checked = true; }
                    }
                }
            }
        }
        public void Hien()
        {
            txtDictionary_Code.Enabled = true;
            txtDictionary_Name_Id.Enabled = true;
            txtDictionary_Name.Enabled = true;
            txtDienGiai1.Enabled = true;
            txtDienGiai2.Enabled = true;
            txtDienGiai3.Enabled = true;
            txtDienGiai4.Enabled = true;
            txtDienGiai5.Enabled = true;
            cbTamNgung.Enabled = true;
        }
        public void An()
        {
            txtDictionary_Code.Enabled = false;
            txtDictionary_Name_Id.Enabled = false;
            txtDictionary_Name.Enabled = false;
            txtDienGiai1.Enabled = false;
            txtDienGiai2.Enabled = false;
            txtDienGiai3.Enabled = false;
            txtDienGiai4.Enabled = false;
            txtDienGiai5.Enabled = false;
            cbTamNgung.Enabled = false;
        }
        public void Reset()
        {
            txtDictionary_Code.Text = "";
            txtDictionary_Name_Id.Text = "";
            txtDictionary_Name.Text = "";
            txtDienGiai1.Text = "";
            txtDienGiai2.Text = "";
            txtDienGiai3.Text = "";
            txtDienGiai4.Text = "";
            txtDienGiai5.Text = "";
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