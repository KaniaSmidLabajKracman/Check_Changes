using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
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

        WebClient client;

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Další pokus
            //url = listBox1 - převzít text URL... vytáhnout jednu adresu
            //URL ve formátu např: http://github.com/slozka1/README.md
            string url = listBox1.Text;
            if (!string.IsNullOrEmpty(url))
            {
                Thread thread = new Thread(() =>
                {
                    Uri uri = new Uri(url);
                    string fileName = System.IO.Path.GetFileName(uri.AbsolutePath);
                    client.DownloadFileAsync(uri, Application.StartupPath + "/" + fileName);
                });
                thread.Start();
            }
            
            /*
            //Pokus o stahování dat
            Uri ur = new Uri("https://github.com/KaniaSmidLabajKracman/Check_Changes/README.md");

            using (WebClient client = new WebClient())
            {
                //client.Credentials = new NetworkCredential("username", "password");
                String credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes("uzivatel" + ":" + "heslo"));
                client.Headers[HttpRequestHeader.Authorization] = $"Basic {credentials}";

                client.DownloadProgressChanged += WebClientDownloadProgressChanged;
                client.DownloadDataCompleted += WebClientDownloadCompleted;
                client.DownloadFileAsync(ur, @"C:/Users/uzivatel/Desktop/README.md");
            }*/
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            client = new WebClient();
            client.DownloadFileCompleted += Client_DownloadFileCompleted;
        }

        private void Client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            MessageBox.Show("Stahovani dokonceno !", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
