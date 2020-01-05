using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FUN
{
    public class SimpleBrowser
    {
        private readonly string _baseURL;
        private int _waitTimeout = 10000;
        public string _headerAuthorizationKey;
        public string _headerAuthorizationValue;

        public SimpleBrowser(string baseUrl, int waitTimeout = 10000, string headerAuthorizationKey = "", string headerAuthorizationValue="")
        {
            _baseURL = baseUrl;
            _waitTimeout = waitTimeout;
            _headerAuthorizationKey = headerAuthorizationKey;
            _headerAuthorizationValue = headerAuthorizationValue;
        }

        public async Task<string> Get(string address, List<KeyValuePair<string, string>> query = null)
        {
            string res = "";

            var formattedAddress = address;
            if (query != null && query.Count > 0)
            {
                if (!formattedAddress.EndsWith("?"))
                    formattedAddress += "?";

                var queryString = FormatGetParameters(query);
                formattedAddress += queryString;
            }

            using (var client = new HttpClient())
            {
                SetAuthorizationHeaders(client);
                client.BaseAddress = new Uri(_baseURL);
                var result = await client.GetAsync(formattedAddress).ConfigureAwait(false);
                var byteArray = await result.Content.ReadAsByteArrayAsync().ConfigureAwait(false);

                res = Encoding.UTF8.GetString(byteArray, 0, byteArray.Length);
            }

            return await Task.FromResult(res);
        }

        public async Task<string> Post(string address, FormUrlEncodedContent content)
        {
            string res = "";

            using (var client = new HttpClient())
            {
                SetAuthorizationHeaders(client);
                client.BaseAddress = new Uri(_baseURL);

                var result = await client.PostAsync(address, content).ConfigureAwait(false);
                var byteArray = await result.Content.ReadAsByteArrayAsync().ConfigureAwait(false);

                res = Encoding.UTF8.GetString(byteArray, 0, byteArray.Length);
            }

            return await Task.FromResult(res);
        }
        public async Task<string> Post(string address, StringContent content)
        {
            string res = "";

            using (var client = new HttpClient())
            {
                SetAuthorizationHeaders(client);
                client.BaseAddress = new Uri(_baseURL);

                var result = await client.PostAsync(address, content).ConfigureAwait(false);
                var byteArray = await result.Content.ReadAsByteArrayAsync().ConfigureAwait(false);

                res = Encoding.UTF8.GetString(byteArray, 0, byteArray.Length);
            }

            return await Task.FromResult(res);
        }

        public async Task<string> Upload(string fileField, string fileName, byte[] file, string address)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseURL);

                using (var content = new MultipartFormDataContent())
                {
                    content.Add(new StreamContent(new MemoryStream(file)), fileField, fileName);

                    var request = await client.PostAsync(address, content);
                    var response = await request.Content.ReadAsStringAsync();
                    return response;
                }
            }
        }

        public static string FormatGetParameters(List<KeyValuePair<string, string>> items)
        {
            var res = "";

            if (items != null && items.Count > 0)
            {
                res += string.Join("", items.Select(x => string.Format("{0}={1}&", x.Key, x.Value)));
                res = res.TrimEnd('&');
            }
            else
            {
                res = "";
            }

            return res;
        }
        public static string FormatGetParameters(Dictionary<string, object> items)
        {
            var res = "";

            if (items != null && items.Count > 0)
            {
                res += string.Join("", items.Select(x => string.Format("{0}={1}&", x.Key, x.Value)));
                res = res.TrimEnd('&');
            }
            else
            {
                res = "";
            }

            return res;
        }
        private void SetAuthorizationHeaders(HttpClient client)
        {
            if(!string.IsNullOrEmpty(_headerAuthorizationKey) && !string.IsNullOrEmpty(_headerAuthorizationValue))
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(_headerAuthorizationKey, _headerAuthorizationValue);
            }
        }
    }
}
