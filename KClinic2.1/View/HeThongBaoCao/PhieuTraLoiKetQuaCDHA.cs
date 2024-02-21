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
    public partial class PhieuTraLoiKetQuaCDHA : DevExpress.XtraEditors.XtraForm
    {
        View.ChanDoanHinhAnh.ChanDoanHinhAnh tn;
        public PhieuTraLoiKetQuaCDHA(View.ChanDoanHinhAnh.ChanDoanHinhAnh tn)
        {
            InitializeComponent();
            this.tn = tn;
        }

        private void PhieuTraLoiKetQuaCDHA_Load(object sender, EventArgs e)
        {
            DataTable table1 = Model.dbCDHA.SP_BaoCao_005_PhieuKetQuaCDHA(tn.CLSKetQua_Id);
            if (table1 != null)
            {
                if(table1.Rows.Count > 0)
                {
                    table1.Columns.Add("BarcodeMaYTe", System.Type.GetType("System.Byte[]"));
                    table1.Columns.Add("Logo", System.Type.GetType("System.Byte[]"));
                    table1.Columns.Add("TenBenhVien", System.Type.GetType("System.String"));
                    table1.Columns.Add("DiaChiBenhVien", System.Type.GetType("System.String"));
                    table1.Columns.Add("DienThoai", System.Type.GetType("System.String"));
                    string TenBenhVien = "", DiaChiBenhVien = "", DienThoai = "";
                    if (table1.Rows[0]["MaYTe"].ToString() != "")
                    {
                        byte[] Image = null;
                        byte[] ImageLogo = null;
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
                            table1.Rows[i]["TenBenhVien"] = TenBenhVien;
                            table1.Rows[i]["DiaChiBenhVien"] = DiaChiBenhVien;
                            table1.Rows[i]["DienThoai"] = DienThoai;
                        }
                    }

                    table1.Columns.Add("Hinh1a", System.Type.GetType("System.Byte[]"));
                    table1.Columns.Add("Hinh2a", System.Type.GetType("System.Byte[]"));
                    table1.Columns.Add("Hinh3a", System.Type.GetType("System.Byte[]"));
                    table1.Columns.Add("Hinh4a", System.Type.GetType("System.Byte[]"));
                    table1.Columns.Add("Hinh5a", System.Type.GetType("System.Byte[]"));
                    table1.Columns.Add("Hinh6a", System.Type.GetType("System.Byte[]"));
                    table1.Columns.Add("Hinh7a", System.Type.GetType("System.Byte[]"));
                    table1.Columns.Add("Hinh8a", System.Type.GetType("System.Byte[]"));
                    table1.Columns.Add("Hinh9a", System.Type.GetType("System.Byte[]"));

                    if (table1.Rows[0]["Hinh1"].ToString() != "")
                    {
                        FileStream fs = new FileStream(table1.Rows[0]["Hinh1"].ToString(), System.IO.FileMode.Open, System.IO.FileAccess.Read);
                        byte[] Image = new byte[fs.Length];
                        fs.Read(Image, 0, Convert.ToInt32(fs.Length));
                        fs.Close();
                        table1.Rows[0]["Hinh1a"] = Image;
                    }


                    if (table1.Rows[0]["Hinh2"].ToString() != "")
                    {
                        FileStream fs2 = new FileStream(table1.Rows[0]["Hinh2"].ToString(), System.IO.FileMode.Open, System.IO.FileAccess.Read);
                        byte[] Image2 = new byte[fs2.Length];
                        fs2.Read(Image2, 0, Convert.ToInt32(fs2.Length));
                        fs2.Close();
                        table1.Rows[0]["Hinh2a"] = Image2;
                    }


                    if (table1.Rows[0]["Hinh3"].ToString() != "")
                    {
                        FileStream fs3 = new FileStream(table1.Rows[0]["Hinh3"].ToString(), System.IO.FileMode.Open, System.IO.FileAccess.Read);
                        byte[] Image3 = new byte[fs3.Length];
                        fs3.Read(Image3, 0, Convert.ToInt32(fs3.Length));
                        fs3.Close();
                        table1.Rows[0]["Hinh3a"] = Image3;
                    }

                    if (table1.Rows[0]["Hinh4"].ToString() != "")
                    {
                        FileStream fs4 = new FileStream(table1.Rows[0]["Hinh4"].ToString(), System.IO.FileMode.Open, System.IO.FileAccess.Read);
                        byte[] Image4 = new byte[fs4.Length];
                        fs4.Read(Image4, 0, Convert.ToInt32(fs4.Length));
                        fs4.Close();
                        table1.Rows[0]["Hinh4a"] = Image4;
                    }

                    if (table1.Rows[0]["Hinh5"].ToString() != "")
                    {
                        FileStream fs4 = new FileStream(table1.Rows[0]["Hinh5"].ToString(), System.IO.FileMode.Open, System.IO.FileAccess.Read);
                        byte[] Image4 = new byte[fs4.Length];
                        fs4.Read(Image4, 0, Convert.ToInt32(fs4.Length));
                        fs4.Close();
                        table1.Rows[0]["Hinh5a"] = Image4;
                    }

                    if (table1.Rows[0]["Hinh6"].ToString() != "")
                    {
                        FileStream fs4 = new FileStream(table1.Rows[0]["Hinh6"].ToString(), System.IO.FileMode.Open, System.IO.FileAccess.Read);
                        byte[] Image4 = new byte[fs4.Length];
                        fs4.Read(Image4, 0, Convert.ToInt32(fs4.Length));
                        fs4.Close();
                        table1.Rows[0]["Hinh6a"] = Image4;
                    }

                    if (table1.Rows[0]["Hinh7"].ToString() != "")
                    {
                        FileStream fs4 = new FileStream(table1.Rows[0]["Hinh7"].ToString(), System.IO.FileMode.Open, System.IO.FileAccess.Read);
                        byte[] Image4 = new byte[fs4.Length];
                        fs4.Read(Image4, 0, Convert.ToInt32(fs4.Length));
                        fs4.Close();
                        table1.Rows[0]["Hinh7a"] = Image4;
                    }

                    if (table1.Rows[0]["Hinh8"].ToString() != "")
                    {
                        FileStream fs4 = new FileStream(table1.Rows[0]["Hinh8"].ToString(), System.IO.FileMode.Open, System.IO.FileAccess.Read);
                        byte[] Image4 = new byte[fs4.Length];
                        fs4.Read(Image4, 0, Convert.ToInt32(fs4.Length));
                        fs4.Close();
                        table1.Rows[0]["Hinh8a"] = Image4;
                    }

                    if (table1.Rows[0]["Hinh9"].ToString() != "")
                    {
                        FileStream fs4 = new FileStream(table1.Rows[0]["Hinh9"].ToString(), System.IO.FileMode.Open, System.IO.FileAccess.Read);
                        byte[] Image4 = new byte[fs4.Length];
                        fs4.Read(Image4, 0, Convert.ToInt32(fs4.Length));
                        fs4.Close();
                        table1.Rows[0]["Hinh9a"] = Image4;
                    }
                }
            }

            ReportDocument rptDoca = new ReportDocument();
            DataTable ShowDuongDan = Model.db.ShowDuongDan();
            string DuongDan;
            if (tn.InCDHA == "Doc")
            {
                //DuongDan = @"" + ShowDuongDan.Rows[0][0].ToString() + @"BC010_PhieuTraLoiKetQuaCDHA.rpt";
                if (table1.Rows[0]["MaNhomDichVu"].ToString() == "GPB")
                {
                    DuongDan = @"" + ShowDuongDan.Rows[0][0].ToString() + @"BC012_PhieuTraLoiKetQuaGPB.rpt";
                }
                else if (table1.Rows[0]["MaNhomDichVu"].ToString() == "SCTC")
                {
                    DuongDan = @"" + ShowDuongDan.Rows[0][0].ToString() + @"BC013_PhieuTraLoiKetQuaSCTC.rpt";
                }
                else
                {
                    DuongDan = @"" + ShowDuongDan.Rows[0][0].ToString() + @"BC010_PhieuTraLoiKetQuaCDHA.rpt";
                }

            }
            else
            {
                DuongDan = @"" + ShowDuongDan.Rows[0][0].ToString() + @"BC010_PhieuTraLoiKetQuaCDHA_Ngang.rpt";
            }
            //string DuongDan = @"C:\Users\Admin\source\repos\KClinic2.1\KClinic2.1\ReportImage\" + @"BC010_PhieuTraLoiKetQuaCDHA.rpt";
            rptDoca.Load(DuongDan);
            rptDoca.SetDataSource(table1);
            crystalReportViewer1.ReportSource = rptDoca;
        }
    }
}