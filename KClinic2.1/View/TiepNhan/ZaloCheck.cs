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
using ZaloDotNetSDK;
using Newtonsoft.Json.Linq;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using CrystalDecisions.Windows.Forms;
using Newtonsoft.Json;


namespace KClinic2._1.View.TiepNhan
{
    public partial class ZaloCheck : DevExpress.XtraEditors.XtraForm
    {
        public static string Zalo_Id = "";
        public string AccessToken;
        TiepNhan tn;
        public ZaloCheck(TiepNhan tn)
        {
            InitializeComponent();
            this.tn = tn;
        }

        private void ZaloCheck_Load(object sender, EventArgs e)
        {
            DataTable table = DanhSachNguoiQuanTam();
            cbbNguoiDung.Properties.ValueMember = "user_id";
            cbbNguoiDung.Properties.DisplayMember = "display_name";
            cbbNguoiDung.Properties.DataSource = table;
            if (Zalo_Id != "") { cbbNguoiDung.EditValue = Zalo_Id; }
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

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            this.Hide();
            tn.Zalo_id(cbbNguoiDung.EditValue.ToString());
        }
    }
}