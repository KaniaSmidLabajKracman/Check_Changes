using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Check_Changes
{
    public partial class Form1 : Form
    {
        public DownloadProgressChangedEventHandler WebClientDownloadProgressChanged { get; private set; }
        public DownloadDataCompletedEventHandler WebClientDownloadCompleted { get; private set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //další pokus
            Uri ur = new Uri("https://github.com/KaniaSmidLabajKracman/Check_Changes/README.md");

            using (WebClient client = new WebClient())
            {
                //client.Credentials = new NetworkCredential("username", "password");
                String credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes("uzivatel" + ":" + "heslo"));
                client.Headers[HttpRequestHeader.Authorization] = $"Basic {credentials}";

                client.DownloadProgressChanged += WebClientDownloadProgressChanged;
                client.DownloadDataCompleted += WebClientDownloadCompleted;
                client.DownloadFileAsync(ur, @"C:/Users/uzivatel/Desktop/README.md");
            }


            
            //1. pokus
            /*string remoteUri = "https://github.com/KaniaSmidLabajKracman/Check_Changes/";
            string fileName = "README.md", myStringWebResource = null;
            // Create a new WebClient instance.
            WebClient myWebClient = new WebClient();
            myWebClient.Credentials = new NetworkCredential("jmeno", "heslo");
            // Concatenate the domain with the Web resource filename.
            myStringWebResource = remoteUri + fileName;
            Console.WriteLine("Stahuji data \"{0}\" from \"{1}\" .......\n\n", fileName, myStringWebResource);
            // Download the Web resource and save it into the current filesystem folder.
            myWebClient.DownloadFile(myStringWebResource, fileName);
            Console.WriteLine("Úspěšně stažená data \"{0}\" from \"{1}\"", fileName, myStringWebResource);
            Console.WriteLine("\nDownloaded file saved in the following file system folder:\n\t" + Application.StartupPath);
            */

            //2. pokus
            /*Uri uri = new Uri(@"https://github.com/KaniaSmidLabajKracman/Check_Changes/README.md");
            WebClient webClient = new WebClient();
            webClient.Credentials = new NetworkCredential("jmeno", "heslo");
            String adresa = "C:/Users/uzivatel/Desktop/README.md";
            webClient.DownloadFile(adresa, "README.md");
            */


            //3. pokus
            /*WebClient client = new WebClient();
            //nacteme URI
            string uri = "https://github.com/KaniaSmidLabajKracman/Check_Changes/README.md";
            //nacteme kam se ma soubor ulozit
            string fileName = "C:/Users/uzivatel/Desktop/README.md";
            try
            {
                //stahneme soubor
                client.DownloadFile(uri, fileName);
                Console.WriteLine("Soubor byl uspesne stazen.");
            }
            catch (WebException ex)
            {
                Console.WriteLine("Pri stahovani souboru doslo k vyjimce : {0}", ex.ToString());
            }*/
        }
    }
}
