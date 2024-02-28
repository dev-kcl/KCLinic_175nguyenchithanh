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
    public partial class BaoCaoDoanhThuPhongKham : DevExpress.XtraEditors.XtraForm
    {
        public BaoCaoDoanhThuPhongKham()
        {
            InitializeComponent();
        }

        private void BaoCaoBNChiDinhDichVu_Load(object sender, EventArgs e)
        {
            panelMain.Location = new Point(
            this.ClientSize.Width / 2 - panelMain.Size.Width / 2,
            this.ClientSize.Height / 2 - panelMain.Size.Height / 2);
            panelMain.Anchor = AnchorStyles.None;
            DataTable DoiTuong = Model.DbTiepNhan.LayDMDoiTuong();
            cbbDoiTuong.DataSource = DoiTuong;
            cbbDoiTuong.ValueMember = "FieldCode";
            cbbDoiTuong.DisplayMember = "FieldName";
            DataTable NhanVien = Model.dbBaoCao.cbbNhanVien();
            cbbNhanVien.DataSource = NhanVien;
            cbbNhanVien.ValueMember = "FieldCode";
            cbbNhanVien.DisplayMember = "FieldName";
            txtTuNgay.Value = DateTime.Now;
            txtDenNgay.Value = DateTime.Now;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            string DoiTuong = "null";
            if (cbbDoiTuong.SelectedItem != null) { DoiTuong = cbbDoiTuong.SelectedValue.ToString(); }
            string NhanVien = "null";
            if (cbbNhanVien.SelectedItem != null) { NhanVien = cbbNhanVien.SelectedValue.ToString(); }
            View.HeThongBaoCao.Report.MaBaoCao = "BC013";
            string TuNgay = "'" + txtTuNgay.Value.ToString("yyyyMMdd") + "'";
            string DenNgay = "'" + txtDenNgay.Value.ToString("yyyyMMdd") + "'";
            View.HeThongBaoCao.Report.TableBaoCao = Model.dbBaoCao.SP_BaoCao_013_BaoCaoDoanhThuPhongKham(TuNgay, DenNgay, DoiTuong, NhanVien,Login.UserName);
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