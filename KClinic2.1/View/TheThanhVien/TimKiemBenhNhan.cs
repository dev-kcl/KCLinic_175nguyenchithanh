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

namespace KClinic2._1.View.TheThanhVien
{
    public partial class TimKiemBenhNhan : DevExpress.XtraEditors.XtraForm
    {
        ThongTinThe tn;

        public TimKiemBenhNhan(ThongTinThe tn)
        {
            InitializeComponent();
            this.tn = tn;
        }

        private void TimKiemBenhNhan_Load(object sender, EventArgs e)
        {
            DataTable LoaiTimKiemBenhNhan = Model.db.LoaiTimKiemBenhNhan();
            txtMaYTe.Focus();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            DataTable Search_BenhNhan = Model.db.Search_BenhNhan(txtMaYTe.Text, txtTenBN.Text, txtNamSinh.Text, txtSDT.Text);
            gridDS.DataSource = Search_BenhNhan;
        }

        private void txtMaYTe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                DataTable Search_BenhNhan = Model.db.Search_BenhNhan(txtMaYTe.Text, txtTenBN.Text, txtNamSinh.Text, txtSDT.Text);
                gridDS.DataSource = Search_BenhNhan;
            }
            if (e.KeyCode == Keys.Tab && e.Shift)
            {
                MoveFocusToPreviousTextbox();
                e.SuppressKeyPress = true;
            }
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            int n = e.RowHandle;
            if (gridView1.RowCount > 0)
            {
                tn.BenhNhan_Id = gridView1.GetRowCellValue(n, "BenhNhan_Id").ToString();
                tn.MaYTe = gridView1.GetRowCellValue(n, "MaYTe").ToString();
                this.Hide();
                tn.LoadThongTinBenhNhanTheoMaYTe();
            }
        }

        private void txtTenBN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                DataTable Search_BenhNhan = Model.db.Search_BenhNhan(txtMaYTe.Text, txtTenBN.Text, txtNamSinh.Text, txtSDT.Text);
                gridDS.DataSource = Search_BenhNhan;
            }
            if (e.KeyCode == Keys.Tab && e.Shift)
            {
                MoveFocusToPreviousTextbox();
                e.SuppressKeyPress = true;
            }
        }

        private void txtNamSinh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                DataTable Search_BenhNhan = Model.db.Search_BenhNhan(txtMaYTe.Text, txtTenBN.Text, txtNamSinh.Text, txtSDT.Text);
                gridDS.DataSource = Search_BenhNhan;
            }
            if (e.KeyCode == Keys.Tab && e.Shift)
            {
                MoveFocusToPreviousTextbox();
                e.SuppressKeyPress = true;
            }
        }

        private void txtSDT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                DataTable Search_BenhNhan = Model.db.Search_BenhNhan(txtMaYTe.Text, txtTenBN.Text, txtNamSinh.Text, txtSDT.Text);
                gridDS.DataSource = Search_BenhNhan;
            }
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

        private void TimKiemBenhNhan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}