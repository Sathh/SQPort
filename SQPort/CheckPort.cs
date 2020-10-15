using System;
using System.Configuration;
using System.Net.Sockets;

namespace SQPort
{
    public static class CheckPort
    {
        public static int[] ports;
        public static int[] defaultPorts = { 20, 21, 25, 80, 161, 389, 443, 515, 636, 1433, 4096, 4099, 5010, 5011, 5012, 5013, 5014, 5015, 5016, 5017, 5018, 5019, 5020, 5021, 5432, 5433, 5555, 5556, 5557, 5558, 5559, 6020, 6100, 7348, 7800, 9090, 9100, 9443, 50001, 50003 };
        public static void Ports()
        {
            string arrayValue = ConfigurationManager.AppSettings["list"];
            string[] str_array = arrayValue.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            int[] portsArray = new int[str_array.Length];
            for (int i = 0; i < str_array.Length; i++)
            {
                int output;
                if (int.TryParse(str_array[i], out output))
                {
                    portsArray[i] = output;
                }
                else
                {
                    portsArray[i] = -1;
                }
            }
            ports = portsArray;
        }
        public static void Local()
        {
            foreach (int i in ports)
            {
                using (TcpClient tcpClient = new TcpClient())
                {
                    try
                    {
                        tcpClient.Connect("127.0.0.1", i);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Port " + i + " otvorený");
                    }
                    catch (Exception)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Port " + i + " zatvorený");
                    }
                }
            }
        }
        public static void Remote(string ipAddress)
        {
            foreach (int i in ports)
            {
                using (TcpClient tcpClient = new TcpClient())
                {
                    try
                    {
                        tcpClient.Connect(ipAddress, i);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Port " + i + " otvorený");
                    }
                    catch (Exception)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Port " + i + " zatvorený");
                    }
                }
            }
        }
    }
}
