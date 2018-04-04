using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Check_Changes
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            TestPingu();
        }


        //Metoda na otestování internetu
        public static bool Ping(string url)
        {
            Ping ping = new Ping();

            PingReply reply = ping.Send(url, 3000);

            if (reply.Status == IPStatus.Success)
                return true;
            return false;
        }

        //Metoda na otestování metody Ping
        public static void TestPingu()
        {
            //cyklus na otestování internetu (ON/OFF)
            while (true)
            {
                if (Ping("www.google.com"))
                {
                    MessageBox.Show("Internet funguje!!!!");
                    break;
                }
                else
                {
                    Console.WriteLine("Internet zatím nefunguje...");
                }
                System.Threading.Thread.Sleep(5000);
            }
        }
    }
}
