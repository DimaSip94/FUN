using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1WebCLient
{
    class Program
    {
        public delegate void Callback();

        static void Main(string[] args)
        {
            Callback callback = CallbackFunc;
            DownloadAsync(callback);
            Console.ReadKey();            
        }

        public static void CallbackFunc()
        {
            Console.WriteLine("Download have done!");
        }

        public static async Task DownloadAsync(Callback somefunc)
        {
            WebClient webClient = new WebClient();
            await webClient.DownloadFileTaskAsync("https://tu.market/uploads/tu/21387/8e84fc1d-dce1-4e5d-b68a-8f2fae68596b.jpg", "8e84fc1d-dce1-4e5d-b68a-8f2fae68596b.jpg");
            somefunc();
        }
    }
}
