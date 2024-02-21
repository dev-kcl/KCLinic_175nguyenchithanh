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
using CrystalDecisions.CrystalReports.Engine;
using System.IO;

namespace KClinic2._1.View.HeThongBaoCao
{
    public partial class InMaVach : DevExpress.XtraEditors.XtraForm
    {
        View.TiepNhan.TiepNhan tn;
        public InMaVach(View.TiepNhan.TiepNhan tn)
        {
            InitializeComponent();
            this.tn = tn;
        }

        private void InMaVach_Load(object sender, EventArgs e)
        {
            DataTable table1 = Model.DbTiepNhan.InMaVach(tn.BenhNhan_Id);
            if (table1 != null)
            {
                if (table1.Rows.Count > 0)
                {
                    table1.Columns.Add("BarcodeMaYTe", System.Type.GetType("System.Byte[]"));
                    if (table1.Rows[0]["MaYTe"].ToString() != "")
                    {
                        DataTable DuongDanHinhAnh = Model.db.DuongDanHinhAnh();
                        string HinhAnhBarcode = DuongDanHinhAnh.Rows[0][0].ToString() + table1.Rows[0]["MaYTe"].ToString() + ".png";
                        FileStream fs = new FileStream(HinhAnhBarcode, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                        byte[] Image = new byte[fs.Length];
                        fs.Read(Image, 0, Convert.ToInt32(fs.Length));
                        fs.Close();
                        table1.Rows[0]["BarcodeMaYTe"] = Image;
                    }
                }
            }
            ReportDocument rptDoca = new ReportDocument();
            DataTable ShowDuongDan = Model.db.ShowDuongDan();
            string DuongDan = @"" + ShowDuongDan.Rows[0][0].ToString() + @"BC007_InMaVach.rpt";
            rptDoca.Load(DuongDan);
            rptDoca.SetDataSource(table1);
            crystalReportViewer1.ReportSource = rptDoca;
        }
    }
}