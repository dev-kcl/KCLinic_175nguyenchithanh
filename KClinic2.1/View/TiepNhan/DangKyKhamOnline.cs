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

namespace KClinic2._1.View.TiepNhan
{
    public partial class DangKyKhamOnline : DevExpress.XtraEditors.XtraForm
    {
        TiepNhan tn;
        public DangKyKhamOnline(TiepNhan tn)
        {
            InitializeComponent();
            this.tn = tn;
        }

        private void DangKyKhamOnline_Load(object sender, EventArgs e)
        {
            DataTable LoaiTimKiemDangKyKham = Model.db.LoaiTimKiemDangKyKham();
            cbbLoai.DataSource = LoaiTimKiemDangKyKham;
            cbbLoai.DisplayMember = "Loai";
            cbbLoai.ValueMember = "ID";
            cbbLoai.SelectedValue = "1";
            txtTimKiem.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtTimKiem.Focus();
            DataTable LoadDanhSachDangKyKhamOnLine = Model.db.LoadDanhSachDangKyKhamOnLine(cbbLoai.SelectedValue.ToString(), txtTimKiem.Text);
            gridDS.DataSource = LoadDanhSachDangKyKhamOnLine;
            btnXacNhan.Enabled = false;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            DataTable LoadDanhSachDangKyKhamOnLine = Model.db.LoadDanhSachDangKyKhamOnLine(cbbLoai.SelectedValue.ToString(), txtTimKiem.Text);
            gridDS.DataSource = LoadDanhSachDangKyKhamOnLine;
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            int n = e.RowHandle;
            if (gridView1.RowCount > 0)
            {
                BenhNhan_Id = gridView1.GetRowCellValue(n, "BenhNhan_Id").ToString();
                DangKy_Id = gridView1.GetRowCellValue(n, "DangKy_Id").ToString();
                txtThongTin.Text = "Đang chọn: " + gridView1.GetRowCellValue(n, "TenBenhNhan").ToString();
            }
            btnXacNhan.Enabled = true;
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                DataTable LoadDanhSachDangKyKhamOnLine = Model.db.LoadDanhSachDangKyKhamOnLine(cbbLoai.SelectedValue.ToString(), txtTimKiem.Text);
                gridDS.DataSource = LoadDanhSachDangKyKhamOnLine;
            }
        }

        string BenhNhan_Id = "";
        string DangKy_Id = "";
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (BenhNhan_Id != "0")
            {
                tn.RefreshFormThongDangKy();
                tn.BenhNhan_Id = BenhNhan_Id;
                tn.DangKy_Id = DangKy_Id;
                this.Hide();
                tn.RefreshForm();
            }
            else
            {
                tn.RefreshFormThongDangKy();
                this.Hide();
                tn.RefreshThongDangKy(DangKy_Id);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            BenhNhan_Id = ""; DangKy_Id = "";
            this.Hide();
        }
    }
}