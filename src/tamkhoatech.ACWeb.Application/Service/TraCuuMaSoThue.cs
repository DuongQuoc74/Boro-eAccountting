using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using HtmlAgilityPack;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static tamkhoatech.ACWeb.Service.TraCuuMaSoThue;

namespace tamkhoatech.ACWeb.Service
{
    public class TraCuuMaSoThue
    {
        public readonly int max_retry = 3;
        public readonly int min_retry = 1;
        public readonly string _MaSoThue;
        public readonly bool isThuCong;
        public TraCuuMaSoThue(string MaSoThue)
        {
            _MaSoThue = MaSoThue;
        }

        /// <summary>
        /// return Status, Name, Address
        /// </summary>
        /// <returns></returns>

        public async Task <string[]> TraCuu()
        {
            string[] _result = new string[4];
            if (_MaSoThue == "-")
            {
                // định dạng MST ko hợp lệ, khỏi kiểm tra
                _result[0] = "Lỗi, định dạng MST không hợp lệ!";
                _result[1] = "";
                _result[2] = "";
                _result[3] = "";
                return _result;
            }

            int dem = 0;
            int maxretry = max_retry;
            if (!isThuCong)
                maxretry = min_retry;
            while (dem < maxretry && string.IsNullOrEmpty(_result[1]))
            {
                try
                {
                    dem++;
                    if (dem >= 2)
                        Thread.Sleep(2000);
                    _result[0] = "Lỗi hàm, không chạy kiểm tra được";
                    string link = "https://dangkyquamang.dkkd.gov.vn/egazette/Forms/Egazette/DefaultAnnouncements.aspx";
                    HttpClient http = new HttpClient();              
                    string userArgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/69.0.3497.100 Safari/537.36";
                    var html = await GetDataAsync(link, http, userArgent);
                    if (html == "Tra cứu lỗi")
                    {
                        _result[0] = "Lỗi mạng, vui lòng kiểm tra kết nối mạng và thử lại!";
                        continue;
                    }
                    string mst = string.Empty;
                    if (_MaSoThue.ToString().Trim().Length == 13)
                    {
                        mst = _MaSoThue.Insert(10, "-");
                    }
                    else mst = _MaSoThue;
                    string text = html.Replace("\n", "").Replace("\r", "").Replace("\"", "").Replace("\t", "");
                    string para = GetParameter(text);
                    string postData = "{ \'searchField\' :\'" + mst.Trim() + "\',\'h\' :\'" + para.Trim() + "\'}";
                    string link1 = "https://dangkyquamang.dkkd.gov.vn/auth/Public/Srv.aspx/GetSearch";
                    dynamic? stuff = await PostDataAsync(http, link1, postData, "application/json; charset=UTF-8", userArgent);

                    if (stuff?.d == null)
                    {
                        string link2 = "https://dangkyquamang.dkkd.gov.vn/egazette/Public/Srv.aspx/GetSearch";
                        stuff = await PostDataAsync(http, link2, postData, "application/json; charset=UTF-8", userArgent);
                    }
                        
                    if (stuff?.d == null)
                    {
                        string link3 = "https://dichvuthongtin.dkkd.gov.vn/inf/Public/Srv.aspx/GetSearch";
                        stuff = await PostDataAsync(http, link3, postData, "application/json; charset=UTF-8", userArgent);
                    }
                    var congtty = stuff?.d;
                    int length = congtty?.Count;
                    if (length == 0)
                    {
                        _result[0] = "Lỗi, không tìm thấy mã số thuế hoặc mã số thuế đã ngừng hoạt động!";
                        continue;
                    }
                    if(congtty != null)
                    {
                        foreach (var i in congtty)
                        {
                            if (i.Name == string.Empty)
                            {
                                _result[0] = "Lỗi, vui lòng kiểm tra lại mã số thuế";
                            }
                            string mstTCT = i.Enterprise_Gdt_Code;
                            if (mstTCT.Trim() == mst.Trim())
                            {
                                _result[0] = "Tra cứu thành công, thông tin được cập nhật bên dưới!";
                                _result[1] = i.Name;
                                _result[2] = i.Ho_Address;
                                _result[3] = i.Legal_First_Name;

                                break;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    _result[0] = "Lỗi Exception, " + ex.ToString();
                }
            }
            if (string.IsNullOrEmpty(_result[1]) || _result[1] == "")
            {
                _result = await TraCuu_API_MInvoice();
            }
            return _result;
        }
        public async Task<string[]> TraCuuNNT_2Captcha() // Hàm này không tra cứu đc thông tin, khiên việc tra cứu diễn ra chậm 
        {
            string[] _result = new string[4];
            int dem = 0;
            int maxretry = max_retry;
            if (isThuCong)
                maxretry = min_retry;

            while (dem < maxretry && string.IsNullOrEmpty(_result[1]))
            {
                try
                {
                    dem++;
                    if (dem >= 2)
                        await Task.Delay(500); 

                    _result[0] = "Lỗi hàm, không chạy kiểm tra được";
                    HttpClient http = new HttpClient();
                    string link1 = "http://tracuunnt.gdt.gov.vn/tcnnt/mstdn.jsp";
                    var response = await http.GetAsync(link1);
                    var content = await response.Content.ReadAsStringAsync();
                    HtmlDocument doc = new HtmlDocument();
                    doc.LoadHtml(content);

                    var imgNode = doc.DocumentNode.SelectSingleNode("//img/@src");
                    string linkCaptcha = "http://tracuunnt.gdt.gov.vn/tcnnt/captcha.png?uid=" + imgNode.InnerHtml.Replace("\"", " ").Replace(@"<img height= 45  src= /tcnnt/captcha.png?uid=", "").Replace(">", "").Trim();
                    var captchaResponse = await http.GetByteArrayAsync(linkCaptcha);
                    MemoryStream imgcaptcha = new MemoryStream(captchaResponse);

                    var binImg = imgcaptcha.ToArray();
                    string captcha = await ResloveNormalCaptcha2(Convert.ToBase64String(binImg)); // NO UPPER

                    string data = "action=action&id=&page=1&mst=" + _MaSoThue + "&fullname=&address=&cmt=&captcha=" + captcha;
                    var postContent = new StringContent(data, Encoding.UTF8, "application/x-www-form-urlencoded");
                    string link2 = "http://tracuunnt.gdt.gov.vn/tcnnt/mstdn.jsp";
                    var postResponse = await http.PostAsync(link2, postContent);
                    await postResponse.Content.ReadAsStringAsync();

                    string data2 = "action=action&id=" + _MaSoThue + "&page=1&mst=" + _MaSoThue + "&fullname=&address=&cmt=&captcha=";
                    string link3 = "http://tracuunnt.gdt.gov.vn/tcnnt/mstdn.jsp";
                    var tracuumst = await http.PostAsync(link3, new StringContent(data2, Encoding.UTF8, "application/x-www-form-urlencoded"));
                    var tracuumstContent = await tracuumst.Content.ReadAsStringAsync();
                    string ND = HttpUtility.HtmlDecode(Regex.Replace(tracuumstContent, "<.+?>", string.Empty));
                    string NoiDung = SplitRegex("Tên chính thức", "Nơi đăng ký nộp thuế", ND.Replace("\n", "").Replace("\r", "").Replace("\t", ""));
                    string TenCty = SplitRegex("Tên chính thức", "Tên giao dịch", "Tên chính thức" + NoiDung).Trim();
                    string DiaChi = SplitRegex("Địa chỉ trụ sở", "Nơi đăng ký nộp thuế", NoiDung + "Nơi đăng ký nộp thuế");
                    _result[0] = "Tra cứu thành công, thông tin được cập nhật bên dưới!";
                    _result[1] = TenCty;
                    _result[2] = DiaChi;
                }
                catch (Exception ex)
                {
                    _result[0] = "Lỗi Exception, " + ex.ToString();
                }
            }
            if (string.IsNullOrEmpty(_result[1]) || _result[1] == "")
            {
                _result = await TraCuu_API_MInvoice();
            }
            return _result;
        }  
        
        private async Task<string[]> TraCuu_API_MInvoice()
        {
            string[] _result = new string[4];
            try
            {
                HttpClient httpClient = new HttpClient();
                string link1 = "http://mst.minvoice.com.vn/api/System/SearchTaxCode?tax=";
                string url = link1 + _MaSoThue;

                HttpResponseMessage response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrEmpty(responseBody))
                    {
                        var result = JsonConvert.DeserializeObject<ApiTraCuuMst>(responseBody);
                        if (result != null)
                        {
                            _result[0] = "Tra cứu thành công, thông tin được cập nhật bên dưới!";
                            _result[1] = result.ten_cty ?? "";
                            _result[2] = result.dia_chi ?? "";
                            _result[3] = result.nguoi_dai_dien ?? "";
                        }
                    }
                }
                return _result;
            }
            catch (Exception ex)
            {
                _result[0] = "Lỗi Exception, " + ex.ToString();
                return _result;
            }
        }
        private async Task<string> ResloveNormalCaptcha2(string imgBase)
        {
                return await ResloveNormalCaptcha_trueCaptcha(imgBase);
        }
        private async Task<string> ResloveNormalCaptcha_trueCaptcha(string imgBase)
        {
            string link1 = "https://api.apitruecaptcha.org/one/gettext";

            using (var httpClient = new HttpClient())
            {
                var json = "{\"userid\":\"taikhoantamkhoa\",\"apikey\":\"dMfBQ5AG7UxTNyhQUa9E\",\"data\":\"" + imgBase + "\"";
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(link1, content);

                if (response.IsSuccessStatusCode)
                {
                    var captcha = await response.Content.ReadAsStringAsync();
                    captcha = captcha.Replace("TRUE", "\"TRUE\"").Replace("FALSE", "\"FALSE\"");
                    var mData = Newtonsoft.Json.JsonConvert.DeserializeObject<CaptchaResult>(captcha);
                    if (mData == null)
                    {
                        return string.Empty;
                    }
                    if (mData.RESULT != null)
                    {
                        return mData.RESULT.ToString();
                    }
                    else
                    {
                        return string.Empty;
                    }
                }
                else
                {
                    // Handle the HTTP request failure here
                    return string.Empty;
                }
            }
        }

        public async Task<string> Kiem_tra_cks_mInvoice_extra_info_MST(string nbmst)
        {
            try
            {
                using HttpClientHandler handler = new HttpClientHandler();
                handler.CookieContainer = new CookieContainer();
                string link1 = "https://kiemtrahoadon.vn/";
                Uri target = new Uri(link1);
                handler.CookieContainer.Add(new Cookie("_ga", "GA1.1.944107391.1671501620") { Domain = target.Host });
                handler.CookieContainer.Add(new Cookie("_ga_XZHTT4E8XF", "GS1.1.1671501619.1.0.1671501620.0.0.0") { Domain = target.Host });
                handler.CookieContainer.Add(new Cookie("visitor_id", "63a11730fd731446bb038dc9") { Domain = target.Host });

                handler.ServerCertificateCustomValidationCallback = (sender, certificate, chain, sslPolicyErrors) =>
                {
                    if (sslPolicyErrors == SslPolicyErrors.None)
                    {
                        return true;
                    }
                    else
                    {
                        return false; 
                    }
                };

                using HttpClient client = new HttpClient(handler);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync($"https://kiemtrahoadon.vn/erp/org-by-tax-code/{nbmst}");
                response.EnsureSuccessStatusCode();

                string json = await response.Content.ReadAsStringAsync();

                string tinh_trang = "Không xác định";
                RootMst? obj = JsonConvert.DeserializeObject<RootMst>(json);
                switch (obj?.tthai)
                {
                    case "00":
                        tinh_trang = "Đang hoạt động";
                        break;
                    case "03":
                        tinh_trang = "Ngừng hoạt động";
                        break;
                }
                return tinh_trang;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return "Không xác định";
            }
        }
        public class CaptchaResult
        {
            public string? METHOD { get; set; }
            public string? SUCCESS { get; set; }
            public string? REQUESTID { get; set; }
            public double TIME_TAKEN { get; set; }
            public double CONF { get; set; }
            public string? LAMBDA { get; set; }
            public string? RESULT { get; set; }
        }

        public class ApiTraCuuMst
        {
            public string? ten_cty { get; set; }
            public string? dia_chi { get; set; }
            public string? ma_so_thue { get; set; }
            public string? masothue_id { get; set; }
            public string? cqthuecap_tinh { get; set; }
            public string? cqthue_ql { get; set; }
            public string? nguoi_dai_dien { get; set; }
            public string? ngay_thanh_lap { get; set; }
        }


        private async Task<string> GetDataAsync(string url, HttpClient httpClient, string userAgent = "", string cookie = "")
        {
            try
            {
                if (httpClient == null)
                {
                    httpClient = new HttpClient();
                }

                // Thêm cookie nếu có
                if (!string.IsNullOrEmpty(cookie))
                {
                    httpClient.DefaultRequestHeaders.Add("Cookie", cookie);
                }

                // Thiết lập User-Agent nếu có
                if (!string.IsNullOrEmpty(userAgent))
                {
                    httpClient.DefaultRequestHeaders.Add("User-Agent", userAgent);
                }

                string html = string.Empty;
                try
                {
                    // Thực hiện yêu cầu GET đến URL và đọc nội dung trả về
                    HttpResponseMessage response = await httpClient.GetAsync(url);
                    response.EnsureSuccessStatusCode(); // Ném ngoại lệ nếu có lỗi trong yêu cầu
                    html = await response.Content.ReadAsStringAsync();
                }
                catch (HttpRequestException)
                {
                    // Xử lý nếu có lỗi trong yêu cầu
                    html = "Tra cứu lỗi";
                }

                return html;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return string.Empty;
            }

        }
        private async Task<dynamic?> PostDataAsync(HttpClient httpClient, string url, string data = "", string contentType = "", string userAgent = "", string cookie = "")
        {
            try
            {
                if (httpClient == null)
                {
                    httpClient = new HttpClient();
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                }

                if (!string.IsNullOrEmpty(cookie))
                    httpClient.DefaultRequestHeaders.Add("Cookie", cookie);

                if (!string.IsNullOrEmpty(userAgent))
                    httpClient.DefaultRequestHeaders.Add("User-Agent", userAgent);

                HttpResponseMessage response;
                if (string.IsNullOrEmpty(data))
                {
                    response = await httpClient.PostAsync(url, null);
                }
                else
                {
                    var content = new StringContent(data);
                    if (!string.IsNullOrEmpty(contentType))
                    {
                        content.Headers.ContentType = MediaTypeHeaderValue.Parse(contentType);
                    }
                    response = await httpClient.PostAsync(url, content);
                }

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrEmpty(responseBody))
                    {
                        var deserializedObject = JsonConvert.DeserializeObject<dynamic>(responseBody);
                        return deserializedObject;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex) { 
                Console.WriteLine(ex.ToString());
                return null;
            }
        }


        public string SplitRegex(string dau, string cuoi, string Chuoi)
        {
            string uri = string.Empty;
            string regex = dau + "(.*?)" + cuoi;
            Regex myRegex = new Regex(@regex);
            MatchCollection matches = myRegex.Matches(Chuoi);
            foreach (Match match in matches)
            {
                uri = match.ToString();
            }
            uri = uri.Replace(dau, string.Empty).Replace(cuoi, string.Empty);
            return uri;
        }

        // bắt regex đường link tải về hoặc xem hóa đơn trong nội dung mail
        public string GetLink(string regex, string noidung)
        {
            Regex myRegex = new Regex(regex);
            string link = "";
            MatchCollection matches = myRegex.Matches(noidung);
            foreach (Match match in matches)
            {
                string url1 = match.ToString();
                string url = url1.Substring(0, url1.Length - 1);
                link = url.ToString();
            }
            return link;
        }

        private string GetParameter(string html)
        {
            string token = "";
            var res = Regex.Matches(html, @"(?<=id=ctl00_hdParameter value=).*?(?=\/>)", RegexOptions.Singleline);
            if (res != null && res.Count > 0)
                token = res[0].ToString();
            return token;
        }

        /// <summary>
        /// kiểm tra Người bán hoạt động
        /// </summary>


        public class RootMst
        {
            public string? mst { get; set; }
            public string? macqt { get; set; }
            public string? tencqt { get; set; }
            public string? tennnt { get; set; }
            public string? tthai { get; set; }
            public string? loainnt { get; set; }
            public string? lnnt { get; set; }
            public string? dctsdchi { get; set; }
            public string? dctstinh { get; set; }
            public string? dctsthuyen { get; set; }
            public string? dctstxa { get; set; }
            public string? dctstinhten { get; set; }
            public string? dctshuyenten { get; set; }
            public string? dctsxaten { get; set; }
        }
    }
}
