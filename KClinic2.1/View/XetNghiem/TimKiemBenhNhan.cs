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

namespace KClinic2._1.View.XetNghiem
{
    public partial class TimKiemBenhNhan : DevExpress.XtraEditors.XtraForm
    {
        XetNghiem tn;
        public TimKiemBenhNhan(XetNghiem tn)
        {
            InitializeComponent();
            this.tn = tn;
        }

        private void TimKiemBenhNhan_Load(object sender, EventArgs e)
        {
            DataTable LoaiTimKiemTiepNhan = Model.db.LoaiTimKiemTiepNhan();
            cbbLoai.DataSource = LoaiTimKiemTiepNhan;
            cbbLoai.DisplayMember = "Loai";
            cbbLoai.ValueMember = "ID";
            cbbLoai.SelectedValue = "3";
            txtTimKiem.Focus();
            DataTable Search_TiepNhanCLS_ChuaThucHien = Model.db.Search_TiepNhanCLS_ChuaThucHien("2", DateTime.Now.ToString("yyyyMMdd"), Login.PhongBan_Id);
            gridDS.DataSource = Search_TiepNhanCLS_ChuaThucHien;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            DataTable Search_TiepNhanCLS_ChuaThucHien = Model.db.Search_TiepNhanCLS_ChuaThucHien(cbbLoai.SelectedValue.ToString(), txtTimKiem.Text, Login.PhongBan_Id);
            gridDS.DataSource = Search_TiepNhanCLS_ChuaThucHien;
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                DataTable Search_TiepNhanCLS_ChuaThucHien = Model.db.Search_TiepNhanCLS_ChuaThucHien(cbbLoai.SelectedValue.ToString(), txtTimKiem.Text, Login.PhongBan_Id);
                gridDS.DataSource = Search_TiepNhanCLS_ChuaThucHien;
            }
            if (e.KeyCode == Keys.Tab && e.Shift)
            {
                MoveFocusToPreviousTextbox();
                e.SuppressKeyPress = true;
            }
        }

        private void gridView1_RowCellClick_1(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            int n = e.RowHandle;
            if (gridView1.RowCount > 0)
            {
                XetNghiem.TiepNhan_Id = gridView1.GetRowCellValue(n, "TiepNhan_Id").ToString();
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