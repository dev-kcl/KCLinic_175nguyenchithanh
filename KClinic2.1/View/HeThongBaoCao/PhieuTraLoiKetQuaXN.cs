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
    public partial class PhieuTraLoiKetQuaXN : DevExpress.XtraEditors.XtraForm
    {
        View.XetNghiem.XetNghiem tn;
        public PhieuTraLoiKetQuaXN(View.XetNghiem.XetNghiem tn)
        {
            InitializeComponent();
            this.tn = tn;
        }

        private void PhieuTraLoiKetQuaXN_Load(object sender, EventArgs e)
        {
            DataTable table1 = Model.dbXetNghiem.SP_BaoCao_004_PhieuKetQuaXetNghiem(tn.CLSKetQua_Id, tn.ListRowPrint);
            if (table1 != null)
            {
                if (table1.Rows.Count > 0)
                {
                    table1.Columns.Add("BarcodeMaYTe", System.Type.GetType("System.Byte[]"));
                    table1.Columns.Add("Logo", System.Type.GetType("System.Byte[]"));
                    table1.Columns.Add("ChuKy", System.Type.GetType("System.Byte[]"));
                    table1.Columns.Add("TenBenhVien", System.Type.GetType("System.String"));
                    table1.Columns.Add("DiaChiBenhVien", System.Type.GetType("System.String"));
                    table1.Columns.Add("DienThoai", System.Type.GetType("System.String"));
                    byte[] Image = null;
                    byte[] ImageLogo = null;
                    byte[] ImageChuKy = null;
                    string TenBenhVien = "", DiaChiBenhVien = "", DienThoai = "";
                    if (table1.Rows[0]["MaYTe"].ToString() != "")
                    {
                        DataTable DuongDanHinhAnh = Model.db.DuongDanHinhAnh();
                        string HinhAnhBarcode = DuongDanHinhAnh.Rows[0][0].ToString() + table1.Rows[0]["MaYTe"].ToString() + ".png";
                        FileStream fs = new FileStream(HinhAnhBarcode, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                        Image = new byte[fs.Length];
                        fs.Read(Image, 0, Convert.ToInt32(fs.Length));
                        fs.Close();

                        DataTable SelectSettingTheoSettingCode2 = Model.db.SelectSettingTheoSettingCode("logo");
                        if (SelectSettingTheoSettingCode2 != null)
                        {
                            if (SelectSettingTheoSettingCode2.Rows.Count > 0)
                            {
                                string Logo = SelectSettingTheoSettingCode2.Rows[0]["NoiDung"].ToString();
                                FileStream fsLogo = new FileStream(Logo, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                                ImageLogo = new byte[fsLogo.Length];
                                fsLogo.Read(ImageLogo, 0, Convert.ToInt32(fsLogo.Length));
                                fsLogo.Close();
                            }
                        }

                        DataTable SelectSettingTheoSettingCode3 = Model.db.SelectSettingTheoSettingCode("chuky");
                        if (SelectSettingTheoSettingCode3 != null)
                        {
                            if (SelectSettingTheoSettingCode3.Rows.Count > 0)
                            {
                                string ChuKy = SelectSettingTheoSettingCode3.Rows[0]["NoiDung"].ToString();
                                FileStream fsChuKy = new FileStream(ChuKy, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                                ImageChuKy = new byte[fsChuKy.Length];
                                fsChuKy.Read(ImageChuKy, 0, Convert.ToInt32(fsChuKy.Length));
                                fsChuKy.Close();
                            }
                        }

                        DataTable BenhVien = Model.db.BenhVien(Login.MaBenhVien);
                        if (BenhVien != null)
                        {
                            if (BenhVien.Rows.Count > 0)
                            {
                                TenBenhVien = BenhVien.Rows[0]["TenBenhVien"].ToString();
                                DiaChiBenhVien = BenhVien.Rows[0]["DiaChiBenhVien"].ToString();
                                DienThoai = BenhVien.Rows[0]["DienThoai"].ToString();
                            }
                        }

                        for (int i = 0; i < table1.Rows.Count; i++)
                        {
                            table1.Rows[i]["BarcodeMaYTe"] = Image;
                            table1.Rows[i]["Logo"] = ImageLogo;
                            table1.Rows[i]["ChuKy"] = ImageChuKy;
                            table1.Rows[i]["TenBenhVien"] = TenBenhVien;
                            table1.Rows[i]["DiaChiBenhVien"] = DiaChiBenhVien;
                            table1.Rows[i]["DienThoai"] = DienThoai;
                        }
                    }

                    tn.LoadBatThuong(table1);
                }
            }


            ReportDocument rptDoca = new ReportDocument();
            DataTable ShowDuongDan = Model.db.ShowDuongDan();
            string DuongDan = @"" + ShowDuongDan.Rows[0][0].ToString() + @"BC002_PhieuKetQuaXetNghiem.rpt";
            rptDoca.Load(DuongDan);
            rptDoca.SetDataSource(table1);
            crystalReportViewer1.ReportSource = rptDoca;
        }
    }
}