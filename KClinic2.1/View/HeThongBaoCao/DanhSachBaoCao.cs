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

namespace KClinic2._1.View.HeThongBaoCao
{
    public partial class DanhSachBaoCao : DevExpress.XtraEditors.XtraForm
    {
        public string Report_Id;
        public string ReportName;
        public DanhSachBaoCao()
        {
            InitializeComponent();
        }

        private void DanhSachBaoCao_Load(object sender, EventArgs e)
        {
            Report_Id = "";
            ReportName = "";
            reloadDanhSach();
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Report_Id = "";
            ReportName = "";
            View.HeThongBaoCao.ThemBaoCao tc = new View.HeThongBaoCao.ThemBaoCao(this);
            tc.ShowDialog();
        }
        public void reloadDanhSach()
        {
            DataTable GetDanhSachBaoCao = Model.dbReport.GetDanhSachBaoCao();
            gridBC.DataSource = GetDanhSachBaoCao;
        }
        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int n = e.RowHandle;
                if (gridView1.RowCount > 0)
                {
                    Report_Id = gridView1.GetRowCellValue(n, "Id").ToString();
                    ReportName = gridView1.GetRowCellValue(n, "TenBaoCao").ToString();
                    popupMenu1.ShowPopup(Cursor.Position);
                }
            }

        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            View.HeThongBaoCao.ThemBaoCao tc = new View.HeThongBaoCao.ThemBaoCao(this);
            tc.ShowDialog();
        }

        private void btnTamNgung_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string nguoicapnhat = Login.User_Id;
            DialogResult dr = MessageBox.Show("Bạn có đồng ý tạm ngưng báo cáo: " + ReportName + "?",
            "Thong Bao!", MessageBoxButtons.YesNo);
            switch (dr)
            {
                case DialogResult.Yes:
                    //
                    DataTable TamNgungBaoCao = Model.dbReport.TamNgungBaoCao(Report_Id, "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'", nguoicapnhat);
                    Report_Id = "";
                    ReportName = "";
                    reloadDanhSach();
                    alertControl1.Show(this, "Thông báo", "Đã tạm ngưng thành công!", "");
                    break;
                case DialogResult.No:
                    break;
            }
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string nguoicapnhat = Login.User_Id;
            DialogResult dr = MessageBox.Show("Bạn có đồng ý XOÁ báo cáo: " + ReportName + "?",
            "Thong Bao!", MessageBoxButtons.YesNo);
            switch (dr)
            {
                case DialogResult.Yes:
                    //
                    DataTable DeleteBaoCao = Model.dbReport.DeleteBaoCao(Report_Id, "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'", nguoicapnhat);
                    Report_Id = "";
                    ReportName = "";
                    reloadDanhSach();
                    alertControl1.Show(this, "Thông báo", "Đã xóa thành công!", "");
                    break;
                case DialogResult.No:
                    break;
            }
        }

        private void btnPhanQuyen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            View.HeThongBaoCao.PhanQuyenBaoCao tc = new View.HeThongBaoCao.PhanQuyenBaoCao(this);
            tc.ShowDialog();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Report_Id = "";
            ReportName = "";
            View.HeThongBaoCao.ThemBaoCao tc = new View.HeThongBaoCao.ThemBaoCao(this);
            tc.ShowDialog();
        }
    }
}