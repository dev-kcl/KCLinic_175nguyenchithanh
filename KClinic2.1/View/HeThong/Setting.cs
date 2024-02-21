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
    public partial class Setting : DevExpress.XtraEditors.XtraForm
    {
        public string DM_Id;
        public string ThaoTac;
        public Setting()
        {
            InitializeComponent();
        }

        private void Setting_Load(object sender, EventArgs e)
        {
            DataTable SelectSetting = Model.db.SelectSetting();
            gridDichVu.DataSource = SelectSetting;
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
            txtSettingCode.Focus();
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
            txtSettingCode.Focus();
            //
            LoadThongTinForm();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtSettingCode.Text == "")
            {
                alertControl1.Show(this, "Thông báo", "Setting code không được để trống! ", "");
            }
            else if (txtSettingName.Text == "")
            {
                alertControl1.Show(this, "Thông báo", "Setting name không được để trống! ", "");
            }
            else
            {
                string SettingCode = "N'" + txtSettingCode.Text.Replace("'", "''") + "'";
                string SettingName = "N'" + txtSettingName.Text.Replace("'", "''") + "'";

                string NoiDung = "null";
                if (txtNoiDung.Text != "")
                {
                    NoiDung = "N'" + txtNoiDung.Text.Replace("'", "''") + "'";
                }

                string MoTa = "null";
                if (txtMoTa.Text != "")
                {
                    MoTa = "N'" + txtMoTa.Text.Replace("'", "''") + "'";
                }

                string String1 = "null";
                if (txtString1.Text != "")
                {
                    String1 = "N'" + txtString1.Text.Replace("'", "''") + "'";
                }

                string String2 = "null";
                if (txtString2.Text != "")
                {
                    String2 = "N'" + txtString2.Text.Replace("'", "''") + "'";
                }

                string Num1 = "null";
                if (txtNum1.Text != "")
                {
                    Num1 = "N'" + txtNum1.Text.Replace("'", "''") + "'";
                }

                string Num2 = "null";
                if (txtNum2.Text != "")
                {
                    Num2 = "N'" + txtNum2.Text.Replace("'", "''") + "'";
                }

                string Date1 = "null";
                if (txtDate1.Text != "")
                {
                    Date1 = "'" + txtDate1.Value.ToString("yyyyMMdd HH:mm:ss") + "'";
                }

                string Date2 = "null";
                if (txtDate2.Text != "")
                {
                    Date2 = "'" + txtDate2.Value.ToString("yyyyMMdd HH:mm:ss") + "'";
                }

                string TamNgung = "0";
                if (cbTamNgung.Checked == false) { TamNgung = "0"; } else { TamNgung = "1"; }

                if (ThaoTac == "Them")
                {
                    DataTable Insert = Model.db.InsertSetting(
                        SettingCode
                        , SettingName
                        , NoiDung
                        , MoTa
                        , Date1
                        , Date2
                        , Num1
                        , Num2
                        , String1
                        , String2
                        , TamNgung
                        , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                        , Login.User_Id
                        , "null"
                        , "null"
                        , "0"
                        );
                    if (Insert.Rows.Count > 0)
                    {
                        DM_Id = Insert.Rows[0]["Setting_Id"].ToString();
                        alertControl1.Show(this, "Thông báo", "Đã thêm thành công! " + Insert.Rows[0]["SettingCode"].ToString(), "");
                    }
                }
                if (ThaoTac == "Sua")
                {
                    DataTable Update = Model.db.UpdateSetting(
                          SettingCode
                        , SettingName
                        , NoiDung
                        , MoTa
                        , Date1
                        , Date2
                        , Num1
                        , Num2
                        , String1
                        , String2
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
                        DM_Id = Update.Rows[0]["Setting_Id"].ToString();
                        alertControl1.Show(this, "Thông báo", "Đã sửa thành công! " + Update.Rows[0]["SettingCode"].ToString(), "");
                    }
                }
                //
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnLuu.Enabled = false;
                btnHuy.Enabled = false;
                btnXoa.Enabled = true;
                An();
                DataTable SelectSetting = Model.db.SelectSetting();
                gridDichVu.DataSource = SelectSetting;
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
                    DataTable Delete = Model.db.DeleteSetting(DM_Id, nguoicapnhat);
                    Reset();
                    DM_Id = "";
                    DataTable SelectSetting = Model.db.SelectSetting();
                    gridDichVu.DataSource = SelectSetting;
                    alertControl1.Show(this, "Thông báo", "Đã xóa thành công! " + Delete.Rows[0]["SettingCode"].ToString(), "");
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
                DM_Id = gridView1.GetRowCellValue(n, "Setting_Id").ToString();
                DataTable SelectSettingTheoID = Model.db.SelectSettingTheoID(DM_Id);
                {
                    if (SelectSettingTheoID != null)
                    {
                        if (SelectSettingTheoID.Rows.Count > 0)
                        {
                            txtSettingCode.Text = SelectSettingTheoID.Rows[0]["SettingCode"].ToString();
                            txtSettingName.Text = SelectSettingTheoID.Rows[0]["SettingName"].ToString();
                            txtNoiDung.Text = SelectSettingTheoID.Rows[0]["NoiDung"].ToString();
                            txtMoTa.Text = SelectSettingTheoID.Rows[0]["MoTa"].ToString();
                            txtNum1.Text = SelectSettingTheoID.Rows[0]["Num1"].ToString();
                            txtNum2.Text = SelectSettingTheoID.Rows[0]["Num2"].ToString();
                            txtString1.Text = SelectSettingTheoID.Rows[0]["String1"].ToString();
                            txtString2.Text = SelectSettingTheoID.Rows[0]["String2"].ToString();
                            string Date1 = SelectSettingTheoID.Rows[0]["Date1"].ToString();
                            if (!String.IsNullOrEmpty(Date1))
                            {
                                DateTime enteredDate = DateTime.Parse(Date1);
                                txtDate1.Value = enteredDate;
                            }
                            string Date2 = SelectSettingTheoID.Rows[0]["Date2"].ToString();
                            if (!String.IsNullOrEmpty(Date2))
                            {
                                DateTime enteredDate = DateTime.Parse(Date2);
                                txtDate2.Value = enteredDate;
                            }
                            string TamNgungTam = SelectSettingTheoID.Rows[0]["TamNgung"].ToString();
                            if (TamNgungTam == "0") { cbTamNgung.Checked = false; } else { cbTamNgung.Checked = true; }

                            btnThem.Enabled = false;
                            btnSua.Enabled = false;
                            btnLuu.Enabled = true;
                            btnHuy.Enabled = true;
                            btnXoa.Enabled = true;
                            Hien();
                            ThaoTac = "Sua";
                            txtSettingCode.Focus();
                        }
                    }
                }
            }
        }
        public void LoadThongTinForm()
        {
            DataTable SelectSettingTheoID = Model.db.SelectSettingTheoID(DM_Id);
            {
                if (SelectSettingTheoID != null)
                {
                    if (SelectSettingTheoID.Rows.Count > 0)
                    {
                        txtSettingCode.Text = SelectSettingTheoID.Rows[0]["SettingCode"].ToString();
                        txtSettingName.Text = SelectSettingTheoID.Rows[0]["SettingName"].ToString();
                        txtNoiDung.Text = SelectSettingTheoID.Rows[0]["NoiDung"].ToString();
                        txtMoTa.Text = SelectSettingTheoID.Rows[0]["MoTa"].ToString();
                        txtNum1.Text = SelectSettingTheoID.Rows[0]["Num1"].ToString();
                        txtNum2.Text = SelectSettingTheoID.Rows[0]["Num2"].ToString();
                        txtString1.Text = SelectSettingTheoID.Rows[0]["String1"].ToString();
                        txtString2.Text = SelectSettingTheoID.Rows[0]["String2"].ToString();
                        string Date1 = SelectSettingTheoID.Rows[0]["Date1"].ToString();
                        if (!String.IsNullOrEmpty(Date1))
                        {
                            DateTime enteredDate = DateTime.Parse(Date1);
                            txtDate1.Value = enteredDate;
                        }
                        string Date2 = SelectSettingTheoID.Rows[0]["Date2"].ToString();
                        if (!String.IsNullOrEmpty(Date2))
                        {
                            DateTime enteredDate = DateTime.Parse(Date2);
                            txtDate2.Value = enteredDate;
                        }
                        string TamNgungTam = SelectSettingTheoID.Rows[0]["TamNgung"].ToString();
                        if (TamNgungTam == "0") { cbTamNgung.Checked = false; } else { cbTamNgung.Checked = true; }
                    }
                }
            }
        }
        public void Hien()
        {
            txtSettingCode.Enabled = true;
            txtSettingName.Enabled = true;
            txtNoiDung.Enabled = true;
            txtMoTa.Enabled = true;
            txtNum1.Enabled = true;
            txtNum2.Enabled = true;
            txtString1.Enabled = true;
            txtString2.Enabled = true;
            txtDate1.Enabled = true;
            txtDate2.Enabled = true;
            cbTamNgung.Enabled = true;
        }
        public void An()
        {
            txtSettingCode.Enabled = false;
            txtSettingName.Enabled = false;
            txtNoiDung.Enabled = false;
            txtMoTa.Enabled = false;
            txtNum1.Enabled = false;
            txtNum2.Enabled = false;
            txtString1.Enabled = false;
            txtString2.Enabled = false;
            txtDate1.Enabled = false;
            txtDate2.Enabled = false;
            cbTamNgung.Enabled = false;
        }
        public void Reset()
        {
            txtSettingCode.Text = "";
            txtSettingName.Text = "";
            txtNoiDung.Text = "";
            txtMoTa.Text = "";
            txtNum1.Text = "";
            txtNum2.Text = "";
            txtString1.Text = "";
            txtString2.Text = "";
            txtDate1.Text = "";
            txtDate2.Text = "";
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