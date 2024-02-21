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
    public partial class TimThongTinTiepNhan_Id : DevExpress.XtraEditors.XtraForm
    {
        public static string TiepNhan_Id = "";
        ChanDoanHinhAnh tn;
        public TimThongTinTiepNhan_Id(ChanDoanHinhAnh tn)
        {
            InitializeComponent();
            this.tn = tn;
        }

        private void TimThongTinTiepNhan_Id_Load(object sender, EventArgs e)
        {
            DataTable Search_CLSKetQuaCDHA_DaThucHien = Model.db.Search_CDHA_All(TiepNhan_Id);
            gridDS.DataSource = Search_CLSKetQuaCDHA_DaThucHien;
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            int n = e.RowHandle;
            if (gridView1.RowCount > 0)
            {

                tn.CLSKetQua_Id = gridView1.GetRowCellValue(n, "CLSKetQua_Id").ToString();
                ChanDoanHinhAnh.TiepNhan_Id = gridView1.GetRowCellValue(n, "TiepNhan_Id").ToString();
                tn.CLSYeuCau_Id = gridView1.GetRowCellValue(n, "CLSYeuCau_Id").ToString();
                tn.LayThongTinTheoSoPhieuYeuCau(gridView1.GetRowCellValue(n, "SoPhieuYeuCau").ToString());
                this.Hide();
            }
        }
    }
}