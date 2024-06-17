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

namespace KClinic2._1.View.HeThongBaoCao
{
    public partial class BaoCaoTiepNhanPhongTuVan : DevExpress.XtraEditors.XtraForm
    {
        public BaoCaoTiepNhanPhongTuVan()
        {
            InitializeComponent();
        }

        private void BaoCaoBNChiDinhDichVu_Load(object sender, EventArgs e)
        {
            panelMain.Location = new Point(
            this.ClientSize.Width / 2 - panelMain.Size.Width / 2,
            this.ClientSize.Height / 2 - panelMain.Size.Height / 2);
            panelMain.Anchor = AnchorStyles.None;


            DataTable PhongTuVan = Model.DbTiepNhan.CbbPhongTuVan();
            cbbPhongTuVan.DataSource = PhongTuVan;
            cbbPhongTuVan.ValueMember = "FieldCode";
            cbbPhongTuVan.DisplayMember = "FieldName";
            cbbPhongTuVan.SelectedValue = "4";

            txtTuNgay.Value = DateTime.Now;
            txtDenNgay.Value = DateTime.Now;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {

            string PhongTuVan_ID = "null";
            if (cbbPhongTuVan.SelectedItem != null) { PhongTuVan_ID = cbbPhongTuVan.SelectedValue.ToString(); }
            View.HeThongBaoCao.Report.MaBaoCao = "BC019";
            string TuNgay = "'" + txtTuNgay.Value.ToString("yyyyMMdd") + "'";
            string DenNgay = "'" + txtDenNgay.Value.ToString("yyyyMMdd") + "'";
            View.HeThongBaoCao.Report.TableBaoCao = Model.dbBaoCao.SP_BaoCao_019_BaoCaoKhachHangPhongTuVan(TuNgay, DenNgay, PhongTuVan_ID, Login.UserName);
            View.HeThongBaoCao.Report bc = new View.HeThongBaoCao.Report();
            bc.Show();
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