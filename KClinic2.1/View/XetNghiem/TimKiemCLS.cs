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
    public partial class TimKiemCLS : DevExpress.XtraEditors.XtraForm
    {
        XetNghiem tn;
        public TimKiemCLS(XetNghiem tn)
        {
            InitializeComponent();
            this.tn = tn;
        }

        private void TimKiemCLS_Load(object sender, EventArgs e)
        {
            DataTable LoaiTimKiemKetQuaXetNghiem = Model.db.LoaiTimKiemKetQuaXetNghiem();
            cbbLoai.DataSource = LoaiTimKiemKetQuaXetNghiem;
            cbbLoai.DisplayMember = "Loai";
            cbbLoai.ValueMember = "ID";
            cbbLoai.SelectedValue = "2";
            txtTimKiem.Focus();
            DataTable Search_TiepNhanCLS_DaThucHien = Model.db.Search_TiepNhanCLS_DaThucHien(cbbLoai.SelectedValue.ToString(), DateTime.Now.ToString("yyyyMMdd"),Login.PhongBan_Id);
            gridDS.DataSource = Search_TiepNhanCLS_DaThucHien;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            DataTable Search_TiepNhanCLS_DaThucHien = Model.db.Search_TiepNhanCLS_DaThucHien(cbbLoai.SelectedValue.ToString(), txtTimKiem.Text,Login.PhongBan_Id);
            gridDS.DataSource = Search_TiepNhanCLS_DaThucHien;
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                DataTable Search_TiepNhanCLS_DaThucHien = Model.db.Search_TiepNhanCLS_DaThucHien(cbbLoai.SelectedValue.ToString(), txtTimKiem.Text,Login.PhongBan_Id);
                gridDS.DataSource = Search_TiepNhanCLS_DaThucHien;
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
                tn.CLSKetQua_Id = gridView1.GetRowCellValue(n, "CLSKetQua_Id").ToString();
                XetNghiem.TiepNhan_Id = gridView1.GetRowCellValue(n, "TiepNhan_Id").ToString();
                this.Hide();
                tn.LoadThongTinForm();
                tn.LoadThongTinFormButton();
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