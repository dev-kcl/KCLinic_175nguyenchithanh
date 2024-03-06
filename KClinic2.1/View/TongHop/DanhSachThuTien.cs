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
    public partial class DanhSachThuTien : DevExpress.XtraEditors.XtraForm
    {
        BanThuocTaiQuay tn;
        public DanhSachThuTien(BanThuocTaiQuay tn)
        {
            InitializeComponent();
            this.tn = tn;
        }

        private void DanhSachThuTien_Load(object sender, EventArgs e)
        {
            DataTable LoaiTimKiemVienPhi = Model.db.LoaiTimKiemVienPhi();
            cbbLoai.DataSource = LoaiTimKiemVienPhi;
            cbbLoai.DisplayMember = "Loai";
            cbbLoai.ValueMember = "ID";
            cbbLoai.SelectedValue = "3";
            txtTimKiem.Focus();
            //txtTimKiem.Text = DateTime.Now.ToString("dd/MM/yyyy");
            DataTable Search_HoaDon = Model.db.Search_HoaDon("1", DateTime.Now.ToString("dd/MM/yyyy"));
            gridDS.DataSource = Search_HoaDon;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            DataTable Search_HoaDon = Model.db.Search_HoaDon(cbbLoai.SelectedValue.ToString(), txtTimKiem.Text);
            gridDS.DataSource = Search_HoaDon;
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                DataTable Search_HoaDon = Model.db.Search_HoaDon(cbbLoai.SelectedValue.ToString(), txtTimKiem.Text);
                gridDS.DataSource = Search_HoaDon;
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
                tn.HoaDon_Id = gridView1.GetRowCellValue(n, "HoaDon_Id").ToString();
                tn.LoadHoaDonBenhNhan();
                tn.selectCombobox();
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