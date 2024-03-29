﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ZaloDotNetSDK;
using Newtonsoft.Json.Linq;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using CrystalDecisions.Windows.Forms;
using Newtonsoft.Json;

namespace KClinic2._1.View.Zalo
{
    public partial class ChanDoanHinhAnh : DevExpress.XtraEditors.XtraForm
    {
        public string AccessToken;
        View.ChanDoanHinhAnh.ChanDoanHinhAnh tn;
        public ChanDoanHinhAnh(View.ChanDoanHinhAnh.ChanDoanHinhAnh tn)
        {
            InitializeComponent();
            this.tn = tn;
        }

        private void ChanDoanHinhAnh_Load(object sender, EventArgs e)
        {

            //richTextBox1.Text += a;
            //DataTable table = JsonConvert.DeserializeObject<DataTable>(result.ToString());
            //gridControl1.DataSource = table;
            DataTable table = DanhSachNguoiQuanTam();
            //gridControl1.DataSource = table;
            cbbNguoiDung.Properties.ValueMember = "user_id";
            cbbNguoiDung.Properties.DisplayMember = "display_name";
            cbbNguoiDung.Properties.DataSource = table;

            DataTable selectZalo_IdfromCLSKetQua_Id = Model.dbCDHA.selectZalo_IdfromCLSKetQua_Id(tn.CLSKetQua_Id);
            if (selectZalo_IdfromCLSKetQua_Id.Rows[0]["Zalo_Id"].ToString() != "")
            {
                cbbNguoiDung.EditValue = selectZalo_IdfromCLSKetQua_Id.Rows[0]["Zalo_Id"].ToString();
            }
        }
        public DataTable DanhSachNguoiQuanTam()
        {
            AccessToken = Model.ZaloOa.GetAccessToken();
            ZaloClient client = new ZaloClient(AccessToken);
            JObject result = client.getListFollower(0, 50);
            
            int count = Int32.Parse(result["data"]["total"].ToString());

            DataTable table = new DataTable();
            table.Columns.Add("avatar");
            table.Columns.Add("user_id");
            table.Columns.Add("user_id_by_app");
            table.Columns.Add("display_name");
            table.Columns.Add("address");
            table.Columns.Add("city");
            table.Columns.Add("district");
            table.Columns.Add("phone");
            table.Columns.Add("name");

            if (count <= 50)
            {
                for (int i = 0; i < count; i++)
                {
                    string a = result["data"]["followers"][i]["user_id"].ToString();
                    JObject ThongTin = client.getProfileOfFollower(a);
                    var row = table.NewRow();
                    row["avatar"] = ThongTin["data"]["avatar"].ToString();
                    row["user_id"] = ThongTin["data"]["user_id"].ToString();
                    row["user_id_by_app"] = ThongTin["data"]["user_id_by_app"].ToString();
                    row["display_name"] = ThongTin["data"]["display_name"].ToString();
                    if (ThongTin["data"]["shared_info"] != null)
                    {
                        row["address"] = ThongTin["data"]["shared_info"]["address"].ToString();
                        row["city"] = ThongTin["data"]["shared_info"]["city"].ToString();
                        row["district"] = ThongTin["data"]["shared_info"]["district"].ToString();
                        row["phone"] = ThongTin["data"]["shared_info"]["phone"].ToString();
                        row["name"] = ThongTin["data"]["shared_info"]["name"].ToString();
                    }
                    table.Rows.Add(row);
                }
            }
            else
            {
                for (int i = 0; i < 50; i++)
                {
                    string a = result["data"]["followers"][i]["user_id"].ToString();
                    JObject ThongTin = client.getProfileOfFollower(a);
                    var row = table.NewRow();
                    row["avatar"] = ThongTin["data"]["avatar"].ToString();
                    row["user_id"] = ThongTin["data"]["user_id"].ToString();
                    row["user_id_by_app"] = ThongTin["data"]["user_id_by_app"].ToString();
                    row["display_name"] = ThongTin["data"]["display_name"].ToString();
                    if (ThongTin["data"]["shared_info"] != null)
                    {
                        row["address"] = ThongTin["data"]["shared_info"]["address"].ToString();
                        row["city"] = ThongTin["data"]["shared_info"]["city"].ToString();
                        row["district"] = ThongTin["data"]["shared_info"]["district"].ToString();
                        row["phone"] = ThongTin["data"]["shared_info"]["phone"].ToString();
                        row["name"] = ThongTin["data"]["shared_info"]["name"].ToString();
                    }
                    table.Rows.Add(row);
                }
                // 121 50
                int sl = count / 50;
                for (int i = 1; i <= sl + 1; i++)
                {
                    JObject result1 = client.getListFollower((50 * i) + 1, 50);
                    if ((50 * i) + 50 < count)
                    {
                        for (int j = 0; j < 50; j++)
                        {
                            string a = result["data"]["followers"][j]["user_id"].ToString();
                            JObject ThongTin = client.getProfileOfFollower(a);
                            var row = table.NewRow();
                            row["avatar"] = ThongTin["data"]["avatar"].ToString();
                            row["user_id"] = ThongTin["data"]["user_id"].ToString();
                            row["user_id_by_app"] = ThongTin["data"]["user_id_by_app"].ToString();
                            row["display_name"] = ThongTin["data"]["display_name"].ToString();
                            if (ThongTin["data"]["shared_info"] != null)
                            {
                                row["address"] = ThongTin["data"]["shared_info"]["address"].ToString();
                                row["city"] = ThongTin["data"]["shared_info"]["city"].ToString();
                                row["district"] = ThongTin["data"]["shared_info"]["district"].ToString();
                                row["phone"] = ThongTin["data"]["shared_info"]["phone"].ToString();
                                row["name"] = ThongTin["data"]["shared_info"]["name"].ToString();
                            }
                            table.Rows.Add(row);
                        }
                    }
                    else
                    {
                        //150 > 121 => 121 - (50 * i) 150 = 150 
                        for (int j = 0; j < count - (50 * i); j++)
                        {
                            string a = result["data"]["followers"][j]["user_id"].ToString();
                            JObject ThongTin = client.getProfileOfFollower(a);
                            var row = table.NewRow();
                            row["avatar"] = ThongTin["data"]["avatar"].ToString();
                            row["user_id"] = ThongTin["data"]["user_id"].ToString();
                            row["user_id_by_app"] = ThongTin["data"]["user_id_by_app"].ToString();
                            row["display_name"] = ThongTin["data"]["display_name"].ToString();
                            if (ThongTin["data"]["shared_info"] != null)
                            {
                                row["address"] = ThongTin["data"]["shared_info"]["address"].ToString();
                                row["city"] = ThongTin["data"]["shared_info"]["city"].ToString();
                                row["district"] = ThongTin["data"]["shared_info"]["district"].ToString();
                                row["phone"] = ThongTin["data"]["shared_info"]["phone"].ToString();
                                row["name"] = ThongTin["data"]["shared_info"]["name"].ToString();
                            }
                            table.Rows.Add(row);
                        }
                    }
                }
            }

            return table;
        }
        public string KetQuaCDHA()
        {
            DataTable table1 = Model.dbCDHA.SP_BaoCao_005_PhieuKetQuaCDHA(tn.CLSKetQua_Id);
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
            rptDoca.Load(DuongDan);
            rptDoca.SetDataSource(table1);
            CrystalReportViewer cr = new CrystalReportViewer();
            cr.ReportSource = rptDoca;
            cr.Refresh();
            DataTable DuongDanFile = Model.db.DuongDanFile();
            string reg_number = DuongDanFile.Rows[0][0].ToString() + "CDHA_" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".pdf";
            rptDoca.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, reg_number);
            return reg_number;
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            progressBar1.EditValue = 0;
            progressBar1.Properties.Minimum = 0; //Đặt giá trị nhỏ nhất cho ProgressBar
            progressBar1.Properties.Maximum = 6; //Đặt giá trị lớn nhất cho ProgressBar
            AccessToken = Model.ZaloOa.GetAccessToken();
            ZaloClient client = new ZaloClient(AccessToken);

            progressBar1.EditValue = 1;
            DataTable SelectZaloFile = Model.db.SelectZaloFileCLSKetQuaCDHA_Id(tn.CLSKetQua_Id);
            progressBar1.EditValue = 2;
            if (SelectZaloFile != null)
            {
                if(SelectZaloFile.Rows.Count > 0)
                {

                    JObject sentmess = client.sendTextMessageToUserIdV3(cbbNguoiDung.EditValue.ToString(), "Chào bạn! Kết quả khám của bạn đã có.\nClick để xem file dưới đây:");
                    progressBar1.EditValue = 4;

                    JObject result2 = client.sendFileToUserIdV3(cbbNguoiDung.EditValue.ToString(), SelectZaloFile.Rows[0]["TokenFile"].ToString());
                    progressBar1.EditValue = 6;
                }
                else
                {
                    string a = KetQuaCDHA();
                    ZaloFile file = new ZaloFile(a);
                    file.setMediaTypeHeader("application/pdf");
                    JObject result = client.uploadFileForOfficialAccountAPI(file);

                    string FileMaHoa = result["data"]["token"].ToString();
                    progressBar1.EditValue = 3;
                    DataTable InsertZaloFile = Model.db.InsertZaloFile(
                        "N'" + a + "'"
                        , "N'" + FileMaHoa + "'"
                        , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                        , Login.User_Id
                        , "null"
                        , tn.CLSKetQua_Id
                        , "null"
                        , "null"
                        , "null"
                        , "null"
                        , "null"
                        );
                    progressBar1.EditValue = 4;
                    JObject sentmess = client.sendTextMessageToUserIdV3(cbbNguoiDung.EditValue.ToString(), "Chào bạn! Kết quả chẩn đoán hình ảnh của bạn đã có! \n Click để xem file dưới đây:");
                    progressBar1.EditValue = 5;
                    JObject result2 = client.sendFileToUserIdV3(cbbNguoiDung.EditValue.ToString(), FileMaHoa);
                    progressBar1.EditValue = 6;
                }
            }
            else
            {
                string a = KetQuaCDHA();
                ZaloFile file = new ZaloFile(a);
                file.setMediaTypeHeader("application/pdf");
                JObject result = client.uploadFileForOfficialAccountAPI(file);

                string FileMaHoa = result["data"]["token"].ToString();
                progressBar1.EditValue = 3;
                DataTable InsertZaloFile = Model.db.InsertZaloFile(
                    "N'" + a + "'"
                    , "N'" + FileMaHoa + "'"
                    , "'" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "'"
                    , Login.User_Id
                    , "null"
                    , tn.CLSKetQua_Id
                    , "null"
                    , "null"
                    , "null"
                    , "null"
                    , "null"
                    );
                progressBar1.EditValue = 4;
                JObject sentmess = client.sendTextMessageToUserIdV3(cbbNguoiDung.EditValue.ToString(), "Chào bạn! Kết quả chẩn đoán hình ảnh của bạn đã có! \n Click để xem file dưới đây:");
                progressBar1.EditValue = 5;
                JObject result2 = client.sendFileToUserIdV3(cbbNguoiDung.EditValue.ToString(), FileMaHoa);
                progressBar1.EditValue = 6;
            }
            //
            this.Hide();
            tn.SendThongBaoZalo();
        }
    }
}