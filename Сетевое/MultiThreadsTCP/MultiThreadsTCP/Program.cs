using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreadsTCP
{
    class Program
    {
        const int port = 8888;
        const string address = "127.0.0.1";
        static void Main(string[] args)
        {
            Console.Write("Введите свое имя:");
            string userName = Console.ReadLine();
            TcpClient tcpClient = null;
            try
            {
                tcpClient = new TcpClient(address,  port);
                NetworkStream stream = tcpClient.GetStream();

                while (true)
                {
                    Console.WriteLine($"{userName} : ");

                    //отправка
                    string message = Console.ReadLine();
                    message = String.Format("{0}: {1}", userName, message);
                    byte[] data = Encoding.Unicode.GetBytes(message);
                    stream.Write(data, 0, data.Length);

                    //ответ
                    data = new byte[64];
                    StringBuilder sb = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = stream.Read(data, 0, data.Length);
                        sb.Append(Encoding.Unicode.GetString(data, 0, bytes));

                    } while (stream.DataAvailable);

                    message = sb.ToString();
                    Console.WriteLine($"Сервер: {message}");

                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
            finally
            {
                tcpClient.Close();
            }
        }
    }
}
