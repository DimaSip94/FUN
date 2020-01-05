using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static int port = 8005; // порт для приема входящих запросов
        static string IPAd = "127.0.0.1";

        static void Main(string[] args)
        {
            try
            {
                IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);

                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(IPAddress.Parse(IPAd), port);

                //отправка данных
                Console.Write("Введите сообщение:");
                string message = Console.ReadLine();
                byte[] data = Encoding.Unicode.GetBytes(message);
                socket.Send(data);

                //получение сообщений
                data = new byte[256];
                StringBuilder stringBuilder = new StringBuilder();
                int bytes = 0;

                do
                {
                    bytes = socket.Receive(data, data.Length, 0);
                    stringBuilder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                } while (socket.Available > 0);

                Console.WriteLine("ответ сервера: " + stringBuilder.ToString());

                //закрываем
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
            

            Console.Read();
        }
    }
}
