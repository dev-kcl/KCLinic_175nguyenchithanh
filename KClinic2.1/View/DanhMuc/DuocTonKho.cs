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
using DevExpress.XtraGrid.Views.Grid;

namespace KClinic2._1.View.DanhMuc
{
    public partial class DuocTonKho : DevExpress.XtraEditors.XtraForm
    {
        public DuocTonKho()
        {
            InitializeComponent();
        }

        private void DuocTonKho_Load(object sender, EventArgs e)
        {
            DataTable SelectDM_DuocTonKho = Model.dbDanhMuc.SelectDM_DuocTonKho();
            gridDichVu.DataSource = SelectDM_DuocTonKho;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DataTable SelectDM_DuocTonKho_CheckTonKho = Model.dbDanhMuc.SelectDM_DuocTonKho_CheckTonKho();
            gridDichVu.DataSource = SelectDM_DuocTonKho_CheckTonKho;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DataTable SelectDM_DuocTonKho_CheckDate = Model.dbDanhMuc.SelectDM_DuocTonKho_CheckDate();
            gridDichVu.DataSource = SelectDM_DuocTonKho_CheckDate;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DataTable SelectDM_DuocTonKho = Model.dbDanhMuc.SelectDM_DuocTonKho();
            gridDichVu.DataSource = SelectDM_DuocTonKho;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.Column.FieldName == "DateEnd")
            {
                string status = View.GetRowCellDisplayText(e.RowHandle, View.Columns["CheckDate"]);
                if (status == "1")
                {
                    e.Appearance.BackColor = Color.FromArgb(150, Color.Salmon);
                    e.Appearance.FontStyleDelta = FontStyle.Bold;
                    e.Appearance.ForeColor = Color.FromArgb(150, Color.Red);
                }
            }
            if (e.Column.FieldName == "SoLuongTon")
            {
                string status = View.GetRowCellDisplayText(e.RowHandle, View.Columns["CheckTonKho"]);
                if (status == "1")
                {
                    e.Appearance.BackColor = Color.FromArgb(150, Color.Salmon);
                    e.Appearance.FontStyleDelta = FontStyle.Bold;
                    e.Appearance.ForeColor = Color.FromArgb(150, Color.Red);
                }
            }
        }
    }
}