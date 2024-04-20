using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KClinic2._1.View.HeThongBaoCao
{
    public partial class BaoCaoSuDungDichVuThe : DevExpress.XtraEditors.XtraForm
    {
        public BaoCaoSuDungDichVuThe()
        {
            InitializeComponent();
        }

        private void BaoCaoSuDungDichVuThe_Load(object sender, EventArgs e)
        {
            panelMain.Location = new Point(
            this.ClientSize.Width / 2 - panelMain.Size.Width / 2,
            this.ClientSize.Height / 2 - panelMain.Size.Height / 2);
            panelMain.Anchor = AnchorStyles.None;

            txtTuNgay.Value = DateTime.Now;
            txtDenNgay.Value = DateTime.Now;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            View.HeThongBaoCao.Report.MaBaoCao = "BC016";
            string TuNgay = "'" + txtTuNgay.Value.ToString("yyyyMMdd") + "'";
            string DenNgay = "'" + txtDenNgay.Value.ToString("yyyyMMdd") + "'";
            string SoThe = "'" + txtSoThe.Text + "'";

            View.HeThongBaoCao.Report.TableBaoCao = Model.dbBaoCao.SP_BaoCao_016_BaoCaoSuDungDichVuThe(TuNgay, DenNgay, SoThe, Login.UserName);
            View.HeThongBaoCao.Report bc = new View.HeThongBaoCao.Report();
            bc.Show();
        }
    }
}