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

namespace KClinic2._1.View.TongHop
{
    public partial class TimKiemBNChuaBanThuoc : DevExpress.XtraEditors.XtraForm
    {
        BanThuocTaiQuay tn;
        public TimKiemBNChuaBanThuoc(BanThuocTaiQuay tn)
        {
            InitializeComponent();
            this.tn = tn;
        }

        private void TimKiemBNChuaBanThuoc_Load(object sender, EventArgs e)
        {
            DataTable LoaiTimKiemBNVP = Model.db.LoaiTimKiemBNVP();
            cbbLoai.DataSource = LoaiTimKiemBNVP;
            cbbLoai.DisplayMember = "Loai";
            cbbLoai.ValueMember = "ID";
            cbbLoai.SelectedValue = "2";
            txtTimKiem.Focus();
            txtTimKiem.Text = DateTime.Now.ToString("dd/MM/yyyy");
            DataTable Search_BNVienPhi = Model.db.Search_BNVienPhi("2", DateTime.Now.ToString("dd/MM/yyyy"));
            gridDS.DataSource = Search_BNVienPhi;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            DataTable Search_BNVienPhi = Model.db.Search_BNVienPhi(cbbLoai.SelectedValue.ToString(), txtTimKiem.Text);
            gridDS.DataSource = Search_BNVienPhi;
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                DataTable Search_BNVienPhi = Model.db.Search_BNVienPhi(cbbLoai.SelectedValue.ToString(), txtTimKiem.Text);
                gridDS.DataSource = Search_BNVienPhi;
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
                tn.TiepNhan_Id = gridView1.GetRowCellValue(n, "TiepNhan_Id").ToString();
                this.Hide();
                tn.RefreshForm();
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