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

namespace KClinic2._1.View
{
    public partial class Home : DevExpress.XtraEditors.XtraForm
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            DataTable SelectSettingTheoSettingCode = Model.db.SelectSettingTheoSettingCode("TenPhanMem");
            if (SelectSettingTheoSettingCode != null)
            {
                if (SelectSettingTheoSettingCode.Rows.Count > 0)
                {
                    txtTieuDe.Text = SelectSettingTheoSettingCode.Rows[0]["NoiDung"].ToString();
                }
            }
            DataTable SelectSettingTheoSettingCode2 = Model.db.SelectSettingTheoSettingCode("logo");
            if (SelectSettingTheoSettingCode2 != null)
            {
                if (SelectSettingTheoSettingCode2.Rows.Count > 0)
                {
                    pictureBox1.Image = Image.FromFile(SelectSettingTheoSettingCode2.Rows[0]["NoiDung"].ToString());
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            DataTable SelectSettingTheoSettingCode3 = Model.db.SelectSettingTheoSettingCode("background");
            if (SelectSettingTheoSettingCode3 != null)
            {
                if (SelectSettingTheoSettingCode3.Rows.Count > 0)
                {
                    panelMain.BackgroundImage = System.Drawing.Image.FromFile(SelectSettingTheoSettingCode3.Rows[0]["NoiDung"].ToString());
                }
            }

            txtTieuDe.Location = new Point(
            this.ClientSize.Width / 2 - txtTieuDe.Size.Width / 2,
            this.ClientSize.Height / 2 - txtTieuDe.Size.Height / 2);
            txtTieuDe.Anchor = AnchorStyles.None;
        }
    }
}