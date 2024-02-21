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

namespace KClinic2._1.View.ChanDoanHinhAnh
{
    public partial class TimKiemBenhNhan : DevExpress.XtraEditors.XtraForm
    {
        ChanDoanHinhAnh tn;
        public static string SoTiepNhan = "";
        public TimKiemBenhNhan(ChanDoanHinhAnh tn)
        {
            InitializeComponent();
            this.tn = tn;
        }

        private void TimKiemBenhNhan_Load(object sender, EventArgs e)
        {
            DataTable LoaiTimKiemCLSYeuCau = Model.db.LoaiTimKiemCLSYeuCau();
            cbbLoai.DataSource = LoaiTimKiemCLSYeuCau;
            cbbLoai.DisplayMember = "Loai";
            cbbLoai.ValueMember = "ID";
            cbbLoai.SelectedValue = "2";
            txtTimKiem.Focus();
            txtTimKiem.Text = DateTime.Now.ToString("dd/MM/yyyy");
            if (SoTiepNhan != "")
            {
                DataTable Search_CLS_ChuaThucHien = Model.db.Search_CLS_ChuaThucHien("6", SoTiepNhan,Login.PhongBan_Id);
                gridDS.DataSource = Search_CLS_ChuaThucHien;
            }
            else
            {
                SoTiepNhan = "";
                DataTable Search_CLS_ChuaThucHien = Model.db.Search_CLS_ChuaThucHien(cbbLoai.SelectedValue.ToString(), DateTime.Now.ToString("dd/MM/yyyy"), Login.PhongBan_Id);
                gridDS.DataSource = Search_CLS_ChuaThucHien;
            }
            
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            DataTable Search_CLS_ChuaThucHien = Model.db.Search_CLS_ChuaThucHien(cbbLoai.SelectedValue.ToString(), txtTimKiem.Text, Login.PhongBan_Id);
            gridDS.DataSource = Search_CLS_ChuaThucHien;
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                DataTable Search_CLS_ChuaThucHien = Model.db.Search_CLS_ChuaThucHien(cbbLoai.SelectedValue.ToString(), txtTimKiem.Text, Login.PhongBan_Id);
                gridDS.DataSource = Search_CLS_ChuaThucHien;
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
                tn.CLSYeuCau_Id = gridView1.GetRowCellValue(n, "CLSYeuCau_Id").ToString();
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