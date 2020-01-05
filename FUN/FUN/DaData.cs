using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FUN
{
    //https://dadata.ru/api/find-party/
    //3a481f04cc3551d4c9b27e509a83b524a1d6d91e
    //TEST ID 7707083893
    //DaData data = new DaData();
    //data.GetFirmByID("7707083893");
    public class DaData
    {
        public const string token = "3a481f04cc3551d4c9b27e509a83b524a1d6d91e";

        public string  GetFirmByID(string ID)
        {
            string requestURL = "https://suggestions.dadata.ru/suggestions/api/4_1/rs/findById/party";
            SimpleBrowser simpleBrowser = new SimpleBrowser(requestURL, headerAuthorizationKey: "Authorization", headerAuthorizationValue: "Token " + token);
            string content = JsonConvert.SerializeObject(new PostData { query = ID });
            var httpContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = simpleBrowser.Post("", httpContent).Result;
            return response;
        }
    }

    public class PostData
    {
        public string query { get; set; }
    }
}
