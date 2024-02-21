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
using System.Net;
using System.Net.Sockets;


namespace KClinic2._1
{
    public partial class Login : DevExpress.XtraEditors.XtraForm
    {
        public Login()
        {
            InitializeComponent();
        }

        public static string MaBenhVien = "";
        public static string User_Id = "";
        public static string UserCode = "";
        public static string UserName = "";
        public static string PhienDangNhap_Id = "";
        public static string TenPhongBan = "";
        public static string PhongBan_Id = "";

        private void Login_Load(object sender, EventArgs e)
        {
            panelMain.Location = new Point(
            this.ClientSize.Width / 2 - panelMain.Size.Width / 2,
            this.ClientSize.Height / 2 - panelMain.Size.Height / 2);
            panelMain.Anchor = AnchorStyles.None;
        }


        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string Password = "";
            if (txtUserName.Text == "")
            {
                XtraMessageBox.Show("Username không được để trống!");
            }
            else if (txtPassword.Text == "")
            {
                XtraMessageBox.Show("Password không được để trống!");
            }
            else
            {
                DataTable table1 = Model.db.checklogin(txtUserName.Text);
                if (table1 != null)
                {
                    if (table1.Rows.Count > 0)
                    {
                        Password = table1.Rows[0]["Password"].ToString();
                        if (txtPassword.Text == Model.Crypt.Decrypt_Password(Password))
                        {
                            User_Id = table1.Rows[0]["User_Id"].ToString();
                            UserCode = table1.Rows[0]["UserCode"].ToString();
                            UserName = table1.Rows[0]["UserName"].ToString();
                            MaBenhVien = table1.Rows[0]["MaBenhVien"].ToString();
                            PhongBan_Id = "0"; 
                            DataTable CheckPhienDangNhapCuoi = Model.db.CheckPhienDangNhapCuoi(User_Id);
                            if (CheckPhienDangNhapCuoi != null)
                            {
                                if (CheckPhienDangNhapCuoi.Rows.Count > 0)
                                {
                                    PhongBan_Id = CheckPhienDangNhapCuoi.Rows[0]["PhongBan_Id"].ToString();
                                   
                                }
                            }
                            //Thêm phiên đăng nhập
                            string host = Dns.GetHostName();
                            string ipadd = "";
                            var hostk = Dns.GetHostEntry(Dns.GetHostName());
                            foreach (var ip in hostk.AddressList)
                            {
                                if (ip.AddressFamily == AddressFamily.InterNetwork)
                                {
                                    ipadd = ip.ToString();
                                }
                            }
                           
                            string _PhongBan_Id = ""; if (PhongBan_Id == "0") { _PhongBan_Id = "null"; } else { _PhongBan_Id = PhongBan_Id; }                          
                            DataTable PhienDangNhap = Model.db.PhienDangNhap(
                                User_Id
                                , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                                , "null"
                                , "N'" + ipadd + "'"
                                , "N'" + host + "'"
                                , _PhongBan_Id
                                
                                );
                            if (PhienDangNhap.Rows.Count > 0)
                            {
                                PhienDangNhap_Id = PhienDangNhap.Rows[0]["PhienDangNhap_Id"].ToString();
                                //lấy tên phòng ban, tên kho dược đang sử dụng
                                DataTable SelectPhienDangNhap = Model.db.SelectPhienDangNhap(PhienDangNhap_Id);
                                if (SelectPhienDangNhap != null)
                                {
                                    if (SelectPhienDangNhap.Rows.Count > 0)
                                    {
                                        TenPhongBan = SelectPhienDangNhap.Rows[0]["TenPhongBan"].ToString();
                                        
                                    }
                                }
                            }
                            //
                            FormMain frm = new FormMain();
                            this.Hide();
                            frm.ShowDialog();
                            this.Close();
                        }
                        else
                        {
                            XtraMessageBox.Show("Đăng nhập thất bại! Tài khoản hoặc mật khẩu không đúng.");
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Đăng nhập thất bại! Tài khoản hoặc mật khẩu không đúng.");
                    }
                }
                else
                {
                    XtraMessageBox.Show("Đăng nhập thất bại! Tài khoản hoặc mật khẩu không đúng.");
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUserName_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDangNhap.PerformClick();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDangNhap.PerformClick();
            }
        }
    }
}