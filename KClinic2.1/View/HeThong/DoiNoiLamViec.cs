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
    public partial class DoiNoiLamViec : DevExpress.XtraEditors.XtraForm
    {
        FormMain f;
        public DoiNoiLamViec(FormMain f)
        {
            InitializeComponent();
            this.f = f;
        }
        DataTable CBBPhongBan;
       
        private void DoiNoiLamViec_Load(object sender, EventArgs e)
        {
            panelControl2.Location = new Point(
            this.ClientSize.Width / 2 - panelControl2.Size.Width / 2,
            this.ClientSize.Height / 2 - panelControl2.Size.Height / 2);
            panelControl2.Anchor = AnchorStyles.None;
            loadcbb();
        }

        void loadcbb()
        {
            CBBPhongBan = Model.db.SelectPhongBan_User(Login.User_Id);
            cbbNoilamViec.DataSource = CBBPhongBan;
            cbbNoilamViec.ValueMember = "FieldCode";
            cbbNoilamViec.DisplayMember = "FieldName";
            cbbNoilamViec.Value = Int32.Parse(Login.PhongBan_Id);
           
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (cbbNoilamViec.Text == "")
            {
                XtraMessageBox.Show("Chưa chọn nơi làm việc!");
            }
            else
            {
                string PhongBan = "null";
                if (cbbNoilamViec.SelectedItem != null)
                {
                    PhongBan = "N'" + cbbNoilamViec.Value.ToString().Replace("'", "''") + "'";
                }
                

                DataTable UpdatePhienDangNhap = Model.db.UpdatePhienDangNhap(Login.PhienDangNhap_Id, PhongBan);
                if (UpdatePhienDangNhap != null)
                {
                    if (UpdatePhienDangNhap.Rows.Count > 0)
                    {
                        Login.PhongBan_Id = UpdatePhienDangNhap.Rows[0]["PhongBan_Id"].ToString();
                        
                        Login.TenPhongBan = UpdatePhienDangNhap.Rows[0]["TenPhongBan"].ToString();
                       
                        f.ChangeStatus();
                        XtraMessageBox.Show("Đổi nơi làm việc thành công!");
                        this.Close();
                    }
                }
            }
        }
        
        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}