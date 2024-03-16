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

namespace KClinic2._1.View.BenhNhan
{
    public partial class BenhSu : DevExpress.XtraEditors.XtraForm
    {
        public static string BNKham_Id = "";
        public string BenhNhan_Id;

        public string symbol_OnlyMin = "≥";
        public string symbol_OnlyMax = "≤";
        public string symbol_FromTo = "→";

        public BenhSu()
        {
            InitializeComponent();
        }

        private void btn_S_Click(object sender, EventArgs e)
        {
            View.BenhNhan.TimKiemBenhNhan tc = new View.BenhNhan.TimKiemBenhNhan(this);
            tc.ShowDialog();
        }

        private void BenhSu_Load(object sender, EventArgs e)
        {
            BenhNhan_Id = "";
            Idx = "";
            Loai_Id = "";
            crystalReportViewer1.Visible = false;
            pdfViewer1.Visible = false;
            if (BNKham_Id != "")
            {
                BenhNhan_Id = BNKham_Id;
                RefreshForm();
            }
        }
        public void RefreshForm()
        {
            DataTable LoadThongTinBenhNhan = Model.DbTiepNhan.LoadThongTinBenhNhan(BenhNhan_Id);
            if (LoadThongTinBenhNhan.Rows.Count > 0)
            {
                txtMaYTe.Text = LoadThongTinBenhNhan.Rows[0]["MaYTe"].ToString();
                txtTenBenhNhan.Text = LoadThongTinBenhNhan.Rows[0]["TenBenhNhan"].ToString();
                txtSoDienThoai.Text = LoadThongTinBenhNhan.Rows[0]["SoDienThoai"].ToString();
                BenhNhan_Id = LoadThongTinBenhNhan.Rows[0]["BenhNhan_Id"].ToString();
                txtZaloId.Text = LoadThongTinBenhNhan.Rows[0]["Zalo_Id"].ToString();
            }
            txtTenBenhNhan.Focus();
            DataTable selectBenhSu = Model.db.selectBenhSu(BenhNhan_Id);
            gridDichVu.DataSource = selectBenhSu;
            Idx = "";
            Loai_Id = "";
            crystalReportViewer1.Visible = false;
            pdfViewer1.Visible = false;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (BenhNhan_Id != "")
            {
                RefreshForm();
            }
        }
        string Idx = ""; string Loai_Id = "";

        private void gridView1_RowCellClick_1(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            int n = e.RowHandle;
            if (gridView1.RowCount > 0)
            {
                Idx = gridView1.GetRowCellValue(n, "Idx").ToString();
                Loai_Id = gridView1.GetRowCellValue(n, "Loai_Id").ToString();
                if (Loai_Id == "1")
                {
                    crystalReportViewer1.Visible = true;
                    pdfViewer1.Visible = false;
                    DataTable table1 = Model.dbCDHA.SP_BaoCao_005_PhieuKetQuaCDHA(Idx);
                    if (table1 != null)
                    {
                        if (table1.Rows.Count > 0)
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
                    DuongDan = @"" + ShowDuongDan.Rows[0][0].ToString() + @"BC010_PhieuTraLoiKetQuaCDHA.rpt";
                    //if (table1.Rows[0]["MaNhomDichVu"].ToString() == "GPB")
                    //{
                    //    DuongDan = @"" + ShowDuongDan.Rows[0][0].ToString() + @"BC012_PhieuTraLoiKetQuaGPB.rpt";
                    //}
                    //else if (table1.Rows[0]["MaNhomDichVu"].ToString() == "SCTC")
                    //{
                    //    DuongDan = @"" + ShowDuongDan.Rows[0][0].ToString() + @"BC013_PhieuTraLoiKetQuaSCTC.rpt";
                    //}
                    //else
                    //{
                    //    DuongDan = @"" + ShowDuongDan.Rows[0][0].ToString() + @"BC010_PhieuTraLoiKetQuaCDHA.rpt";
                    //}
                    //string DuongDan = @"C:\Users\Admin\source\repos\KClinic2.1\KClinic2.1\ReportImage\" + @"BC010_PhieuTraLoiKetQuaCDHA.rpt";
                    rptDoca.Load(DuongDan);
                    rptDoca.SetDataSource(table1);
                    crystalReportViewer1.ReportSource = rptDoca;
                }
                if (Loai_Id == "2")
                {
                    crystalReportViewer1.Visible = true;
                    pdfViewer1.Visible = false;
                    DataTable table1 = Model.dbXetNghiem.SP_BaoCao_004_PhieuKetQuaXetNghiem(Idx);
                    if (table1 != null)
                    {
                        if (table1.Rows.Count > 0)
                        {
                            table1.Columns.Add("BarcodeMaYTe", System.Type.GetType("System.Byte[]"));
                            table1.Columns.Add("Logo", System.Type.GetType("System.Byte[]"));
                            table1.Columns.Add("TenBenhVien", System.Type.GetType("System.String"));
                            table1.Columns.Add("DiaChiBenhVien", System.Type.GetType("System.String"));
                            table1.Columns.Add("DienThoai", System.Type.GetType("System.String"));
                            byte[] Image = null;
                            byte[] ImageLogo = null;
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

                            LoadBatThuong(table1);
                        }
                    }
                    ReportDocument rptDoca = new ReportDocument();
                    DataTable ShowDuongDan = Model.db.ShowDuongDan();
                    //string DuongDan = @"" + ShowDuongDan.Rows[0][0].ToString() + @"BC002_PhieuTraLoiKetQua.rpt";
                    string DuongDan = @"" + ShowDuongDan.Rows[0][0].ToString() + @"BC002_PhieuKetQuaXetNghiem.rpt";
                    rptDoca.Load(DuongDan);
                    rptDoca.SetDataSource(table1);
                    crystalReportViewer1.ReportSource = rptDoca;
                }
                if (Loai_Id == "3")
                {
                    crystalReportViewer1.Visible = false;
                    pdfViewer1.Visible = true;
                    DataTable DuongDanFile = Model.db.DuongDanFile();
                    DataTable SelectFileXetNghiem_Id = Model.db.SelectFileXetNghiem_Id(Idx);
                    if (SelectFileXetNghiem_Id != null)
                    {
                        if (SelectFileXetNghiem_Id.Rows.Count > 0)
                        {
                            string file = DuongDanFile.Rows[0][0].ToString() + SelectFileXetNghiem_Id.Rows[0]["DuongDan"].ToString();
                            pdfViewer1.LoadDocument(file);
                        }
                    }
                }
                if (Loai_Id == "4")
                {
                    crystalReportViewer1.Visible = true;
                    pdfViewer1.Visible = false;
                    DataTable table1 = Model.dbKhamBenh.SP_BaoCao_001_ToaThuoc(Idx);
                    if (table1 != null)
                    {
                        if (table1.Rows.Count > 0)
                        {
                            table1.Columns.Add("BarcodeMaYTe", System.Type.GetType("System.Byte[]"));
                            table1.Columns.Add("Logo", System.Type.GetType("System.Byte[]"));
                            table1.Columns.Add("TenBenhVien", System.Type.GetType("System.String"));
                            table1.Columns.Add("DiaChiBenhVien", System.Type.GetType("System.String"));
                            table1.Columns.Add("DienThoai", System.Type.GetType("System.String"));
                            byte[] Image = null;
                            byte[] ImageLogo = null;
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
                        }
                    }
                    ReportDocument rptDoca = new ReportDocument();
                    DataTable ShowDuongDan = Model.db.ShowDuongDan();
                    string DuongDan = @"" + ShowDuongDan.Rows[0][0].ToString() + @"BC008_ToaThuoc.rpt";
                    rptDoca.Load(DuongDan);
                    rptDoca.Subreports["ThongTinBenhVien"].SetDataSource(table1);
                    rptDoca.Subreports["ThongTinToaThuoc"].SetDataSource(table1);
                    rptDoca.SetDataSource(table1);
                    crystalReportViewer1.ReportSource = rptDoca;
                }
                if (Loai_Id == "5")
                {
                    crystalReportViewer1.Visible = true;
                    pdfViewer1.Visible = false;
                    DataTable table1 = Model.HoaDondb.SP_BaoCao_010_HoaDonBanHang(Idx);
                    if (table1 != null)
                    {
                        if (table1.Rows.Count > 0)
                        {
                            table1.Columns.Add("BarcodeMaYTe", System.Type.GetType("System.Byte[]"));
                            table1.Columns.Add("Logo", System.Type.GetType("System.Byte[]"));
                            table1.Columns.Add("TenBenhVien", System.Type.GetType("System.String"));
                            table1.Columns.Add("DiaChiBenhVien", System.Type.GetType("System.String"));
                            table1.Columns.Add("DienThoai", System.Type.GetType("System.String"));
                            byte[] Image = null;
                            byte[] ImageLogo = null;
                            string TenBenhVien = "", DiaChiBenhVien = "", DienThoai = "";
                            if (table1.Rows[0]["MaYTe"].ToString() != "")
                            {
                                DataTable DuongDanHinhAnh = Model.db.DuongDanHinhAnh();
                                //string HinhAnhBarcode = DuongDanHinhAnh.Rows[0][0].ToString() + table1.Rows[0]["MaYTe"].ToString() + ".png";
                                //FileStream fs = new FileStream(HinhAnhBarcode, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                                //Image = new byte[fs.Length];
                                //fs.Read(Image, 0, Convert.ToInt32(fs.Length));
                                //fs.Close();

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
                        }
                    }
                    ReportDocument rptDoca = new ReportDocument();
                    DataTable ShowDuongDan = Model.db.ShowDuongDan();
                    string DuongDan = @"" + ShowDuongDan.Rows[0][0].ToString() + @"BC014_HoaDonBanHang.rpt";
                    rptDoca.Load(DuongDan);
                    rptDoca.SetDataSource(table1);
                    crystalReportViewer1.ReportSource = rptDoca;
                }

                if (Loai_Id == "6")
                {
                    crystalReportViewer1.Visible = true;
                    pdfViewer1.Visible = false;
                    DataTable table1 = Model.dbKhamBenh.SP_BaoCao_002_Phieukham(Idx);
                    if (table1 != null)
                    {
                        if (table1.Rows.Count > 0)
                        {
                            table1.Columns.Add("BarcodeMaYTe", System.Type.GetType("System.Byte[]"));
                            table1.Columns.Add("Logo", System.Type.GetType("System.Byte[]"));
                            table1.Columns.Add("TenBenhVien", System.Type.GetType("System.String"));
                            table1.Columns.Add("DiaChiBenhVien", System.Type.GetType("System.String"));
                            table1.Columns.Add("DienThoai", System.Type.GetType("System.String"));
                            byte[] Image = null;
                            byte[] ImageLogo = null;
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
                        }
                    }
                    ReportDocument rptDoca = new ReportDocument();
                    DataTable ShowDuongDan = Model.db.ShowDuongDan();
                    string DuongDan = @"" + ShowDuongDan.Rows[0][0].ToString() + @"BC009_PhieuKham.rpt";
                    rptDoca.Load(DuongDan);
                    rptDoca.SetDataSource(table1);
                    crystalReportViewer1.ReportSource = rptDoca;
                }
                //
            }
        }
        public DataTable getTableSendZaLo;
        public DataTable TableSendZaLo()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Loai_Id", System.Type.GetType("System.String"));
            table.Columns.Add("Idx", System.Type.GetType("System.String"));

            Int32[] selectedRowHandles = gridView1.GetSelectedRows();
            for (int i = 0; i < selectedRowHandles.Length; i++)
            {
                int selectedRowHandle = selectedRowHandles[i];
                if (selectedRowHandle >= 0)
                {
                    DataRow dr = table.NewRow();

                    dr[0] = gridView1.GetRowCellValue(selectedRowHandle, "Loai_Id").ToString();
                    dr[1] = gridView1.GetRowCellValue(selectedRowHandle, "Idx").ToString();

                    table.Rows.Add(dr);
                }

                //txtGiaTriHoaDon.Text += gridView1.GetRowCellValue(selectedRowHandle, "IDx").ToString() + "; ";
            }
            return table;
        }
        private void btnSendZalo_Click(object sender, EventArgs e)
        {
            if (BenhNhan_Id == "")
            {
                alertControl1.Show(this, "Thông báo", "Chưa chọn bệnh nhân!", "");
            }
            else
            {
                getTableSendZaLo = TableSendZaLo();
                View.Zalo.sendBenhSu tc = new View.Zalo.sendBenhSu(this);
                tc.ShowDialog();
            }
            
        }
        public void SendThongBaoZalo()
        {
            alertControl1.Show(this, "Thông báo", "Kết quả đã được gửi thành công qua zalo!", "");
        }

        private void txtMaYTe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                string MaYTe = "null";
                if (txtMaYTe.Text != "") { MaYTe = "N'" + txtMaYTe.Text.Replace("'", "''") + "'"; }
                DataTable selectBenhNhantheoID = Model.db.selectBenhNhantheoID(MaYTe);
                if (selectBenhNhantheoID != null)
                {
                    if (selectBenhNhantheoID.Rows.Count > 0)
                    {
                        BenhNhan_Id = selectBenhNhantheoID.Rows[0]["BenhNhan_Id"].ToString();
                        RefreshForm();
                    }
                    else
                    {
                        alertControl1.Show(this, "Thông báo", "Không tìm thấy bệnh nhân!", "");
                    }
                }
                else
                {
                    alertControl1.Show(this, "Thông báo", "Không tìm thấy bệnh nhân!", "");
                }

            }
            if (e.KeyCode == Keys.Tab && e.Shift)
            {
                MoveFocusToPreviousTextbox();
                e.SuppressKeyPress = true;
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

        public void LoadBatThuong(DataTable tb_KetQuaXetNghiem)
        {
            tb_KetQuaXetNghiem.Columns["BatThuong"].ReadOnly = false;
            foreach (DataRow row in tb_KetQuaXetNghiem.Rows)
            {
                if (row["GiaTriChuan"] == DBNull.Value || row["KetQua"] == DBNull.Value)
                {
                    continue;
                }
                if (row["GiaTriChuan"].ToString() == "" || row["KetQua"].ToString() == "")
                {
                    continue;
                }

                string giatrichuan = row["GiaTriChuan"].ToString();

                if (giatrichuan.Contains(symbol_FromTo))
                {
                    int symbolIndex = giatrichuan.IndexOf(symbol_FromTo);
                    string leftSubstring = (symbolIndex >= 0) ? giatrichuan.Substring(0, symbolIndex) : giatrichuan;
                    string rightSubstring = (symbolIndex >= 0) ? giatrichuan.Substring(symbolIndex + 1) : string.Empty;

                    decimal FromValue = Decimal.Parse(leftSubstring.Trim());
                    decimal ToValue = Decimal.Parse(rightSubstring.Trim());

                    string str_ketqua = row["KetQua"].ToString().Trim();
                    if (str_ketqua.Contains(","))
                    {
                        str_ketqua = str_ketqua.Replace(",", ".");
                    }

                    decimal Result = Decimal.Parse(str_ketqua);

                    if (FromValue <= Result && Result <= ToValue)
                    {
                        continue;
                    }
                    else
                    {
                        if (Result < FromValue)
                        {
                            row["BatThuong"] = "2";
                        }
                        else
                        {
                            row["BatThuong"] = "1";
                        }
                    }
                }
                else if (giatrichuan.Contains(symbol_OnlyMin))
                {
                    int symbolIndex = giatrichuan.IndexOf(symbol_OnlyMin);
                    string rightSubstring = (symbolIndex >= 0) ? giatrichuan.Substring(symbolIndex + 1) : string.Empty;

                    decimal minValue = Decimal.Parse(rightSubstring.Trim());

                    string str_ketqua = row["KetQua"].ToString().Trim();
                    if (str_ketqua.Contains(","))
                    {
                        str_ketqua = str_ketqua.Replace(",", ".");
                    }

                    decimal Result = Decimal.Parse(str_ketqua);

                    if (Result >= minValue)
                    {
                        continue;
                    }
                    else
                    {
                        row["BatThuong"] = "2";
                    }
                }
                else if (giatrichuan.Contains(symbol_OnlyMax))
                {
                    int symbolIndex = giatrichuan.IndexOf(symbol_OnlyMax);
                    string rightSubstring = (symbolIndex >= 0) ? giatrichuan.Substring(symbolIndex + 1) : string.Empty;

                    decimal maxValue = Decimal.Parse(rightSubstring.Trim());

                    string str_ketqua = row["KetQua"].ToString().Trim();
                    if (str_ketqua.Contains(","))
                    {
                        str_ketqua = str_ketqua.Replace(",", ".");
                    }

                    decimal Result = Decimal.Parse(str_ketqua);

                    if (Result <= maxValue)
                    {
                        continue;
                    }
                    else
                    {
                        row["BatThuong"] = "1";
                    }
                }
                else
                {
                    if (row["KetQua"].ToString().Trim() == row["GiaTriChuan"].ToString().Trim())
                    {
                        continue;
                    }
                    else
                    {
                        row["BatThuong"] = "3";
                    }
                }
            }
        }

    }
}