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


namespace KClinic2._1.View.KhamBenh
{
    public partial class TimKiemKhamBenh : DevExpress.XtraEditors.XtraForm
    {
        KhamBenh kb;
        public TimKiemKhamBenh(KhamBenh kb)
        {
            InitializeComponent();
            this.kb = kb;
        }

        private void TimKiemKhamBenh_Load(object sender, EventArgs e)
        {
            DataTable LoaiTimKiemKhamBenh = Model.db.LoaiTimKiemKhamBenh();
            cbbLoai.DataSource = LoaiTimKiemKhamBenh;
            cbbLoai.DisplayMember = "Loai";
            cbbLoai.ValueMember = "ID";
            cbbLoai.SelectedValue = "1";
            txtTimKiem.Focus();
            txtTimKiem.Text = DateTime.Now.ToString("dd/MM/yyyy");
            DataTable Search_KhamBenh = Model.db.Search_KhamBenh(cbbLoai.SelectedValue.ToString(), DateTime.Now.ToString("dd/MM/yyyy"));
            gridDS.DataSource = Search_KhamBenh;
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                DataTable Search_KhamBenh = Model.db.Search_KhamBenh(cbbLoai.SelectedValue.ToString(), txtTimKiem.Text);
                gridDS.DataSource = Search_KhamBenh;
            }
            if (e.KeyCode == Keys.Tab && e.Shift)
            {
                MoveFocusToPreviousTextbox();
                e.SuppressKeyPress = true;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            DataTable Search_KhamBenh = Model.db.Search_KhamBenh(cbbLoai.SelectedValue.ToString(), txtTimKiem.Text);
            gridDS.DataSource = Search_KhamBenh;
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            int n = e.RowHandle;
            if (gridView1.RowCount > 0)
            {
                kb.KhamBenh_Id = gridView1.GetRowCellValue(n, "KhamBenh_Id").ToString();
                kb.ThaoTac = "Sua";
                kb.LoadThongTinBenhNhanDaKhamButton();
                kb.LoadThongTinBenhNhanDaKham();
                this.Hide();
            }
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