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
    public partial class DoiMatKhau : DevExpress.XtraEditors.XtraForm
    {
        public DoiMatKhau()
        {
            InitializeComponent();
        }

        private void DoiMatKhau_Load(object sender, EventArgs e)
        {
            panelControl2.Location = new Point(
            this.ClientSize.Width / 2 - panelControl2.Size.Width / 2,
            this.ClientSize.Height / 2 - panelControl2.Size.Height / 2);
            panelControl2.Anchor = AnchorStyles.None;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (txtMatKhauCu.Text == "")
            {
                XtraMessageBox.Show("Mật khẩu cũ còn để trống!");
            }
            else if (txtMatKhauMoi.Text == "")
            {
                XtraMessageBox.Show("Mật khẩu mới còn để trống!");
            }
            else if (txtNhapLaiMKMoi.Text == "")
            {
                XtraMessageBox.Show("Nhập lại Mật khẩu còn để trống!");
            }
            else
            {
                DataTable CheckChangePassword = Model.db.CheckChangePassword(Login.User_Id);
                if (CheckChangePassword != null)
                {
                    if (CheckChangePassword.Rows.Count > 0)
                    {
                        if (Model.Crypt.Decrypt_Password(CheckChangePassword.Rows[0]["Password"].ToString()) == txtMatKhauCu.Text)
                        {
                            if (txtMatKhauMoi.Text == txtNhapLaiMKMoi.Text)
                            {
                                DataTable ChangePassword = Model.db.ChangePassword(Login.User_Id, Model.Crypt.Encrypt_Password(txtMatKhauMoi.Text));
                                XtraMessageBox.Show("Đổi mật khẩu thành công!");
                            }
                            else
                            {
                                XtraMessageBox.Show("Nhập lại mật khẩu mới không trùng khớp!");
                            }
                        }
                        else
                        {
                            XtraMessageBox.Show("Mật khẩu cũ không đúng!");
                        }
                    }
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
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