using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjektSTI
{
    public partial class LoginForm : Form
    {
        string Repozitar;
        string Uzivatel;
        String tokenText = "3a83251c7641ad3b56c11c9ca3a20d82a810a42f";

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            NactiConfig();
            uzivatelBox.Text = "https://github.com/" + Uzivatel + "/" + Repozitar;
            
            
            uzivatelBox.GotFocus += new EventHandler(this.uzivatelBox_GotFocus);
            uzivatelBox.LostFocus += new EventHandler(this.uzivatelBox_LostFocus);
        }

        private void NactiConfig()
        {
            string config_path = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())) + "\\config.json";
            if (System.IO.File.Exists(config_path))
            {
                var txt = System.IO.File.ReadAllText(config_path);
                Nastaveni n = JsonConvert.DeserializeObject<Nastaveni>(txt);
                Repozitar = n.Repozitar;
                Uzivatel = n.Uzivatel;

            } else
            {
                Repozitar = "Název repozitáře";
                Uzivatel = "Uživatelské jméno";
            }
            
        }



        private void uzivatelBox_LostFocus(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "")
            {
                tb.Text = Uzivatel;
                tb.ForeColor = Color.LightGray;
            }
        }

        private void uzivatelBox_GotFocus(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == Uzivatel)
            {
                tb.Text = "";
                tb.ForeColor = Color.Black;
            }
        }
        private void repozitarBox_LostFocus(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "")
            {
                tb.Text = Repozitar;
                tb.ForeColor = Color.LightGray;
            }
        }

        private void repozitarBox_GotFocus(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == Repozitar)
            {
                tb.Text = "";
                tb.ForeColor = Color.Black;
            }
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            //string uzivatel = uzivatelBox.Text;
            //string repozitar = repozitarBox.Text;


            if (ZkouskaInternetovehoPripojeni())
            {
                try
                {

                    Uri url;
                    bool validUrl = Uri.TryCreate(uzivatelBox.Text, UriKind.Absolute, out url) && (url.Scheme == Uri.UriSchemeHttp || url.Scheme == Uri.UriSchemeHttps) && (url.PathAndQuery.Split('/').Length > 2);

                    if (validUrl)
                    {
                        //this.Hide();
                        string[] path = url.PathAndQuery.Split('/');
                        string uzivatel = path[1];
                        string repozitar = path[2];

                        this.Hide();
                        Sluzba s = new Sluzba();
                        s.NastavDataMiner(repozitar, uzivatel, tokenText);
                        //DateTime cas = s.nastavCas2(repozitar);
                        DateTime cas = nastavCas2(repozitar);
                        MainForm mf = new MainForm(cas, repozitar);
                        //mf.posledniKontrola = DateTime.Now();
                        mf.Text = uzivatel + "/" + repozitar;
                        mf.StartPosition = FormStartPosition.CenterParent;
                        mf.ShowDialog();
                        this.Close();
                    }
                    else {

                        label1.Font = new Font("Arial", 11);
                        label1.ForeColor = Color.Red;
                        label1.Text = "Špatná data";

                    }
                }
                catch (Exception)
                {

                    label1.Font = new Font("Arial", 11);
                    label1.ForeColor = Color.Red;
                    label1.Text = "Špatná data";

                }
            }
            else {
                label1.Font = new Font("Arial", 11);
                label1.ForeColor = Color.Red;
                label1.Text = "Bez připojení k internetu!!";
            }

        }

        public DateTime nastavCas2(string Repozitar) // nacita z jednotlivych souboru pro kazdy repozitar
        {
            DateTime cas;
            try
            {
                var json = System.IO.File.ReadAllText(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())) + "\\" + Repozitar + ".json");
                cas = JsonConvert.DeserializeObject<DateTime>(json);
                Console.WriteLine(cas);
                return cas;

            }
            catch (Exception ex)
            {
                new Logger(ex.Message).Loguj();
                return DateTime.Now;
                // RETHROW - nepodarilo se nacist nastaveni z configu - bud chybi config, nebo tam neni nastaveni
                throw new Exception("Chyba! Nepodařilo se získat nastavení z konfiguračního souboru");
            }
            
        }
        private void uzivatelBox_TextChanged(object sender, EventArgs e)
        {

        }

        private Boolean ZkouskaInternetovehoPripojeni()
        {
            try
            {
                using (var client = new System.Net.WebClient())
                {
                    using (client.OpenRead("http://clients3.google.com/generate_204"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        public string UdelejRequestGitHub(string url, Dictionary<string, string> parametry = null)
        {
            //https://stackoverflow.com/questions/2859790/the-request-was-aborted-could-not-create-ssl-tls-secure-channel
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var txt = System.IO.File.ReadAllText(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())) + "\\config.json");
            Nastaveni n = JsonConvert.DeserializeObject<Nastaveni>(txt);
            // github api si nekdy doplni nejakej parametr sam, potrebuju zjistit, jestli uz nejakej parametr existuje, abych mohl navazat
            string znak = url.Contains("?") ? "&" : "?";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url + znak + "access_token=" + n.githubToken + "&" + PrevedSlovnikParametruNaString(parametry));
            request.CachePolicy = new RequestCachePolicy(RequestCacheLevel.Reload);
            request.ContentType = "application/vnd.github.v3+json";
            request.Method = "GET";
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:60.0) Gecko/20100101 Firefox/60.0";
            //request.Headers["Time-Zone"] = "Europe/Prague";

            while (!ZkouskaInternetovehoPripojeni()) { }

            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            response.Close();
            return responseFromServer;
        }

        private string PrevedSlovnikParametruNaString(Dictionary<string, string> parametry)
        {
            if (parametry == null)
            {
                return "";
            }
            string text = "";
            foreach (var param in parametry)
            {
                text += param.Key + "=" + param.Value + "&";
            }
            return text;
        }

        public bool NastavDataMiner(string repozitar, string uzivatel, string access_token)
        {
            Nastaveni n = new Nastaveni() { Repozitar = repozitar, Uzivatel = uzivatel, githubToken = access_token };
            var txt = JsonConvert.SerializeObject(n);
            string cesta = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())) + "\\config.json";
            try
            {
                if (System.IO.File.Exists(cesta))
                {
                    System.IO.File.WriteAllText(cesta, txt);
                }
                else
                {
                    System.IO.File.WriteAllText(cesta, txt);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void uzivatelBox_TextChanged_1(object sender, EventArgs e)
        {

        }
    }

}
