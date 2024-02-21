using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Data;
using System.Net;

namespace KClinic2._1.Model
{
    class API
    {
        public static string _Username = System.Configuration.ConfigurationManager.AppSettings["UsernameBHXH"];
        public static string _Password = System.Configuration.ConfigurationManager.AppSettings["PasswordBHXH"];
        public static string postDeleteCache()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            try
            {
                string _postKBYT = "http://192.168.1.178:3010/api/COM062/execute/DeleteCacheElastic/";

                var client = new RestClient(_postKBYT);
                var request = new RestRequest(Method.POST);
                request.AddHeader("cache-control", "no-cache");
                request.AddHeader("Content-type", "application/json; charset=utf-8");
                request.AddHeader("token", "12345");
                request.AddHeader("username", "admin");
                request.AddHeader("hospital_id", "48017");
                request.AddHeader("buildno", "2147482147");
                request.RequestFormat = DataFormat.Json;

                //    string jsonString = @"
                //    {'CACHE_NAME':'refbenhnhan_tiepnhan_all','SERVICE_NAME':'com030','INDEX_PREFIX':'','HOSPITAL_ID':'48017','BENHVIEN_ID':'48017'}
                //";
                //    request.AddJsonBody(jsonString.Replace("'", "\""));
                //    IRestResponse response = client.Execute(request);

                //dynamic resp = JObject.Parse(response.Content);
                //return resp.Code;
                request.AddJsonBody(new { CACHE_NAME = "refbenhnhan_tiepnhan_all", SERVICE_NAME = "com030", INDEX_PREFIX = "", HOSPITAL_ID = "48017", BENHVIEN_ID = "48017" });
                var response = client.Execute(request).Content;
                return "Delete Cache thành công!";
            }
            catch (InvalidCastException e)
            {
                return "Lỗi delete cache /r/n" + e;
            }
        }
        public static string postRefreshCache()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            try
            {
                string _postKBYT = "http://192.168.1.178:3010/api/COM062/execute/Refresh_Cache_WithServiceName/";

                var client = new RestClient(_postKBYT);
                var request = new RestRequest(Method.POST);
                request.AddHeader("cache-control", "no-cache");
                request.AddHeader("Content-type", "application/json; charset=utf-8");
                request.AddHeader("token", "12345");
                request.AddHeader("username", "admin");
                request.AddHeader("hospital_id", "48017");
                request.AddHeader("buildno", "2147482147");
                request.RequestFormat = DataFormat.Json;
                //    string jsonString = @"
                //    {'CACHE_NAME':'refbenhnhan_tiepnhan_all','SERVICE_NAME':'com030','INDEX_PREFIX':'','HOSPITAL_ID':'48017','BENHVIEN_ID':'48017'}
                //";
                //request.AddJsonBody(jsonString.Replace("'", "\""));
                //IRestResponse response = client.Execute(request);

                request.AddJsonBody(new { CACHE_NAME = "refbenhnhan_tiepnhan_all", SERVICE_NAME = "com030", INDEX_PREFIX = "", HOSPITAL_ID = "48017", BENHVIEN_ID = "48017" });
                var response = client.Execute(request).Content;


                return "Refresh cache thành công!";
            }
            catch (InvalidCastException e)
            {
                return "Lỗi refresh cache /r/n" + e;
            }
        }
        public static dynamic postTokenBHYT()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            try
            {
                string _postKBYT = "https://egw.baohiemxahoi.gov.vn/api/token/take";

                var client = new RestClient(_postKBYT);
                var request = new RestRequest(Method.POST);
                request.AddHeader("cache-control", "no-cache");
                request.AddHeader("Content-type", "application/json; charset=utf-8");
                request.RequestFormat = DataFormat.Json;

                request.AddJsonBody(new { username = _Username, password = _Password });
                IRestResponse response = client.Execute(request);
                dynamic resp = JObject.Parse(response.Content);
                return resp;
            }
            catch (InvalidCastException e)
            {
                return "Lỗi delete cache /r/n" + e;
            }
        }
        public static dynamic postThongTuyenBHYT(string _token, string _id_token, string _maThe, string _hoTen, string _ngaySinh)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            try
            {
                string _postKBYT = "https://egw.baohiemxahoi.gov.vn/api/egw/KQNhanLichSuKCB2019?token="
                    + _token + "&id_token=" + _id_token + "&username=" + _Username + "&password=" + _Password
                    ;

                var client = new RestClient(_postKBYT);
                var request = new RestRequest(Method.POST);
                request.AddHeader("cache-control", "no-cache");
                request.AddHeader("Content-type", "application/json; charset=utf-8");
                request.RequestFormat = DataFormat.Json;

                request.AddJsonBody(new { maThe = _maThe, hoTen = _hoTen, ngaySinh = _ngaySinh });
                IRestResponse response = client.Execute(request);
                dynamic resp = JObject.Parse(response.Content);
                return resp;
            }
            catch (InvalidCastException e)
            {
                return "Lỗi delete cache /r/n" + e;
            }
        }
        public static Byte[] postVoice(string _token, string _Text)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            try
            {
                var client = new RestClient(@"https://viettelai.vn/tts/speech_synthesis");
                var request = new RestRequest(Method.POST);
                request.AddHeader("cache-control", "no-cache");
                request.AddHeader("Content-type", "application/json");
                request.AddHeader("accept", "*/*");
                request.RequestFormat = DataFormat.Json;

                //    string jsonString = @"
                //        {
                //            'speed': 0.8,
                //            'text': '" + _Text + @"',
                //            'token': '" + _token + @"',
                //            'tts_return_option': 2, 
                //            'voice': 'hn-thaochi', 
                //            'without_filter': true 
                //        }
                //";
                request.AddJsonBody(new { speed = 0.8, text = _Text, token = _token, tts_return_option = 2, voice = "hn-thaochi", without_filter = true });
                IRestResponse response = client.Execute(request);

                var data = client.DownloadData(request);
                return data;
            }
            catch
            {
                return null;
            }
        }
    }
}
