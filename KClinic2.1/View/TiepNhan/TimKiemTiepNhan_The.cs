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

namespace KClinic2._1.View.TiepNhan
{
    public partial class TimKiemTiepNhan_The : DevExpress.XtraEditors.XtraForm
    {
        TiepNhanTheThanhVien tn;

        public TimKiemTiepNhan_The(TiepNhanTheThanhVien tn)
        {
            InitializeComponent();
            this.tn = tn;
        }

        private void TimKiemTiepNhan_The_Load(object sender, EventArgs e)
        {
            txtSoThe.Focus();

            DataTable Search_TiepNhan = Model.db.Search_TiepNhan_The(txtSoTiepNhan.Text, dtmTuNgay.Value, dtmDenNgay.Value, txtMaYTe.Text, txtTenBN.Text, txtNamSinh.Text, txtSDT.Text, txtSoThe.Text);
            gridDS.DataSource = Search_TiepNhan;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            DataTable Search_TiepNhan = Model.db.Search_TiepNhan_The(txtSoTiepNhan.Text, dtmTuNgay.Value, dtmDenNgay.Value, txtMaYTe.Text, txtTenBN.Text, txtNamSinh.Text, txtSDT.Text, txtSoThe.Text);
            gridDS.DataSource = Search_TiepNhan;
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                DataTable Search_TiepNhan = Model.db.Search_TiepNhan_The(txtSoTiepNhan.Text, dtmTuNgay.Value, dtmDenNgay.Value, txtMaYTe.Text, txtTenBN.Text, txtNamSinh.Text, txtSDT.Text, txtSoThe.Text);
                gridDS.DataSource = Search_TiepNhan;
            }
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            int n = e.RowHandle;
            if (gridView1.RowCount > 0)
            {
                tn.TiepNhan_Id = gridView1.GetRowCellValue(n, "TiepNhan_Id").ToString();
                tn.LoadThongTinBenhNhanDaTiepNhanButton();
                tn.LoadThongTinBenhNhanDaTiepNhan_The();
                this.Hide();
            }
        }

        private void TimKiemTiepNhan_The_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}