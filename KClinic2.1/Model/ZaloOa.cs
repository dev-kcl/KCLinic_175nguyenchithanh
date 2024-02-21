using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Data;
using System.Net;
using System.Configuration;
using System.Data.SqlClient;
using System.Net.Http;
using Newtonsoft.Json;
using System.IO;
using ZaloDotNetSDK;

namespace KClinic2._1.Model
{
    class ZaloOa
    {
        public static dynamic GetToken()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            try
            {
                DataTable ZaloOAsecret = Model.db.ZaloOAsecret();
                DataTable selectZaloOAID = Model.db.ZaloOAId();
                DataTable RefreshTokenZalo = Model.db.RefreshTokenZalo();
                string _secret_key = ZaloOAsecret.Rows[0]["NoiDung"].ToString();
                string _app_id = selectZaloOAID.Rows[0]["NoiDung"].ToString();
                string refresh_token = RefreshTokenZalo.Rows[0]["NoiDung"].ToString();

                var client = new RestClient(@"https://oauth.zaloapp.com/v4/oa/access_token");
                var request = new RestRequest(Method.POST);
                request.AddHeader("secret_key", _secret_key);
                request.AddHeader("content-type", "application/x-www-form-urlencoded");
                request.AddParameter("application/x-www-form-urlencoded", "&app_id=" + _app_id + "&grant_type=refresh_token" + "&refresh_token=" + refresh_token, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);

                dynamic resp = JObject.Parse(response.Content);
                return resp;
            }
            catch
            {
                return "KhongGetDuocToKen";
            }
        }
        public static string GetAccessToken()
        {
                    string access_token;
                    int expires_in;

                    DataTable AccessTokenZalo = Model.db.AccessTokenZalo();
                    access_token = AccessTokenZalo.Rows[0]["NoiDung"].ToString();

                    DataTable TimeZaloOA = Model.db.TimeZaloOA();
                    

                    if (!String.IsNullOrEmpty(TimeZaloOA.Rows[0]["NoiDung"].ToString()))
                    {
                        if (!String.IsNullOrEmpty(TimeZaloOA.Rows[0]["Date1"].ToString()))
                        {
                            expires_in = Int32.Parse(TimeZaloOA.Rows[0]["NoiDung"].ToString());
                            DateTime _time_expires_in = DateTime.Parse(TimeZaloOA.Rows[0]["Date1"].ToString());
                            DateTime _time_now = DateTime.Now;
                            DateTime d1 = _time_expires_in.AddSeconds(expires_in);
                            if (_time_now > d1)
                            {
                                dynamic _getToken = GetToken();
                                access_token = _getToken.access_token;
                                string refresh_token = _getToken.refresh_token;
                                DataTable updateAccessTokenZalo = Model.db.updateAccessTokenZalo("N'" + access_token + "'");
                                DataTable updateRefreshTokenZalo = Model.db.updateRefreshTokenZalo("N'" + refresh_token + "'");
                                DataTable updateTimeZaloOA = Model.db.updateTimeZaloOA();
                                return access_token;
                            }
                            else { return access_token; }
                        }
                        return access_token;
                    }
                    else { return access_token; }
        }
        public static DataTable DanhSachNguoiQuanTam()
        {
            string AccessToken = GetAccessToken();
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
    }
}
