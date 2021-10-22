using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] data = new byte[1024];
            string input;

            Console.Write("Укажите IP-адрес сервера: ");
            string addr = Console.ReadLine();
            if (addr == "") addr = "127.0.0.1";

            UdpClient server = new UdpClient(addr, 15000);

            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);

            while (true)
            {
                data = new byte[1024];

                Console.Write("\r\n>");
                input = Console.ReadLine();

                data = Encoding.UTF8.GetBytes(input);
                
                server.Send(data, data.Length);

                if (input == "exit") break;
            }

            Console.WriteLine("Остановка клиента.");
            
            server.Close();
        }
    }
}
