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
    public partial class TimKiemBenhNhan_The : DevExpress.XtraEditors.XtraForm
    {
        TiepNhanTheThanhVien tn;

        public TimKiemBenhNhan_The(TiepNhanTheThanhVien tn)
        {
            InitializeComponent();
            this.tn = tn;
        }

        private void TimKiemBenhNhan_The_Load(object sender, EventArgs e)
        {
            txtMaYTe.Focus();

            DataTable Search_BenhNhan_The = Model.db.Search_BenhNhan_The(txtMaYTe.Text, txtTenBN.Text, txtNamSinh.Text, txtSDT.Text, txtSoThe.Text);
            gridDS.DataSource = Search_BenhNhan_The;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            DataTable Search_BenhNhan_The = Model.db.Search_BenhNhan_The(txtMaYTe.Text, txtTenBN.Text, txtNamSinh.Text, txtSDT.Text, txtSoThe.Text);
            gridDS.DataSource = Search_BenhNhan_The;
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            int n = e.RowHandle;
            if (gridView1.RowCount > 0)
            {
                tn.BenhNhan_Id = gridView1.GetRowCellValue(n, "BenhNhan_Id").ToString();
                this.Hide();
                tn.RefreshForm();
            }
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                DataTable Search_BenhNhan_The = Model.db.Search_BenhNhan_The(txtMaYTe.Text, txtTenBN.Text, txtNamSinh.Text, txtSDT.Text, txtSoThe.Text);
                gridDS.DataSource = Search_BenhNhan_The;
            }
        }

        private void TimKiemBenhNhan_The_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}