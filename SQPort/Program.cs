using System;
using System.IO;
using System.Windows.Forms;

namespace SQPort
{
    class Program
    {
        static void Main(string[] args)
        {
            if (File.Exists(@"SQPort.exe.config") == true)
            {
                CheckPort.Ports();
            }
            if (File.Exists(@"SQPort.exe.config") == false)
            {
                CheckPort.ports = CheckPort.defaultPorts;
            }

            if (MessageBox.Show("Spúšťaš aplikáciu na serveri kde bude SQ nainštalované ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CheckPort.Local();
            }
            else
            {
                Console.WriteLine("Zadaj IP adresu servra a stlač ENTER: ");
                CheckPort.Remote(Console.ReadLine());
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("KONIEC");
            Console.ReadLine();
        }
    }
}
