﻿using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using System.IO;

namespace ProjektSTI
{
    public partial class MainForm : Form
    {
        static System.Windows.Forms.Timer casovac = new System.Windows.Forms.Timer();
        static int interval = 7200000 - 1000; // -1 sekunda kvůli správné časové synchronizaci
        //static int interval = 60000 - 1000; // PRO TESTOVANI
        static Cas cas = new Cas(interval);
        static Stopwatch sw = new Stopwatch();

        // vytvořeno speciálně pro nové spuštění aplikace, po prvním vrácení commitů se nastaví na false
        static Boolean noveSpusteni = true;

        // počet všech commitů
        //       static int pocetVsechCommitu = 0;

        // hodnota, která oznamuje, zda je v průběhu nějaká činnost aplikace - pro správné nastavení tlačítek a zobrazení GUI
        static Boolean pracuji = false;

        // čas poslední kontroly - pro správné opětovné hledání commitů
        //static DateTime posledniKontrola = getLastCheckDate();
        //public static DateTime posledniKontrola = JsonConvert.DeserializeObject<DateTime>(System.IO.File.ReadAllText(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())) + "\\datetime.json"));

        //static DateTime posledniKontrola = new DateTime(2007, 10, 1, 0, 0, 0); // 01.10.2007 00:00:00 - První commit na GitHubu

        static DateTime posledniKontrola;
        static string aktualniRepozitar;

        // počet nových commitů během jednoho cyklu hledání - pouze pro vypsání do logu
        static int pocetNovychSouboru = 0;

        static int celkovyPocetSouboru = 0;

        public MainForm(DateTime cas, string repozitar)
        {
            posledniKontrola = cas;
            aktualniRepozitar = repozitar;
            InitializeComponent();
            casovac.Tick += new EventHandler(ZpracovaniCasovace);
            casovac.Interval = 1000;
            casovac.Start();
            posledniRefresh.Font = new Font("Arial", 10);
            sw.Restart();
        }

        private void ZpracovaniCasovace(Object objekt, EventArgs eventargs)
        {
            if (ZkouskaInternetovehoPripojeni())
            {
                if (!pracuji)
                {
                    cas.OdectiSekunduAktualnihoCasu();
                    
                    UkazatelCasu.Text =  cas.VratAktualniCasFormat();

                    if (noveSpusteni == true)
                    {
                        noveSpusteni = false;
                        ZpracujAVypis(posledniKontrola);
                    }
                    if (cas.VratAktualniCasMs() == 0)
                    {
                        DateTime datum = posledniKontrola;
                        //DateTime datum = DateTime.Now.AddYears(-8); // PRO TESTOVANI
                        ZpracujAVypis(datum);
                    }
                }
                else
                {
                    if (cas.VratAktualniCasMs() != 1000)
                    {
                        cas.OdectiSekunduAktualnihoCasu();
                        UkazatelCasu.Text = cas.VratAktualniCasFormat();
                    }
                    else
                    {
                        UkazatelCasu.Text = "Další kontrola po dokončení probíhající práce";
                    }
                }

            }
            else
            {
                    UkazatelCasu.Font = new Font("Arial", 11);
                    UkazatelCasu.ForeColor = Color.Red;
                    UkazatelCasu.Text = "Bez připojení k internetu!!";
                    notifikace.Text = "";
            }
            NastavTlacitkaAKontrolku();

        }

        private async void ZpracujAVypis(DateTime datum)
        {
            while (pracuji)
            {
                await Task.Delay(100);
            }
            pracuji = true;
            posledniKontrola = DateTime.Now;
            NastavTlacitkaAKontrolku();
            Sluzba s = new Sluzba();


            SaveTime(aktualniRepozitar);
            LogniCas();
            notifikace.Text = "Zpracovávám commity...";
            try
            {
                var commity = await s.VratSouboryCommituPoCaseAsync(datum);
                if (commity.Count > 0)
                {
                    VypisCommityDoTabulky(commity);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Application.Restart();
            }
            noveSoubory.Text = "Počet nových souborů po poslední aktualizace: " + pocetNovychSouboru + " souborů";
            celkovyPocetSouboru = celkovyPocetSouboru + pocetNovychSouboru;

            var jazyky = await s.SpocitejPocetRadkuVSouborechUrcitehoTypuAsync("java");
            
            pocetRadku.Text = "Počet řádků Java souborů v projektu: " + jazyky.ToString();
            pocetNovychSouboru = 0;

            pracuji = false;
        }
        public void SaveTime(string repozitar)
        {
            //DateTimes cas = new DateTimes(); 
            string json = JsonConvert.SerializeObject(DateTime.Now);
            string cesta = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())) + "\\" + repozitar + ".json";
            try
            {
                if (System.IO.File.Exists(cesta))
                {
                    System.IO.File.WriteAllText(cesta, json);
                }
                else
                {
                    System.IO.File.WriteAllText(cesta, json);
                }
            }
            catch (Exception)
            {
            }
        }

        private void NastavTlacitkaAKontrolku()
        {
            if (!pracuji && ZkouskaInternetovehoPripojeni())
            {
                RefreshButton.Enabled = true;
                Kontrolka.BackColor = Color.Green;
                notifikace.Text = "";
                if (TabulkaCommitu.Rows.Count != 0)
                {
                    if (TabulkaCommitu.SelectedRows.Count != 0)
                    {
                        if (TabulkaCommitu.SelectedRows[0].Cells[0].Value.ToString().EndsWith(".java"))
                        {
                            GrafButton.Enabled = true;
                        }
                        else
                        {
                            GrafButton.Enabled = false;
                        }
                        UlozitButton.Enabled = true;
                    }
                    else
                    {
                        GrafButton.Enabled = false;
                        UlozitButton.Enabled = false;
                    }
                    ExportButton.Enabled = true;
                }
                else
                {
                    GrafButton.Enabled = false;
                    UlozitButton.Enabled = false;
                    ExportButton.Enabled = false;
                }

            }
            else if (pracuji && ZkouskaInternetovehoPripojeni())
            {
                RefreshButton.Enabled = false;
                Kontrolka.BackColor = Color.Green;
                UlozitButton.Enabled = false;
                GrafButton.Enabled = false;
                UlozitButton.Enabled = false;
                ExportButton.Enabled = false;
            }
            else
            {
                RefreshButton.Enabled = false;
                Kontrolka.BackColor = Color.Red;
                UlozitButton.Enabled = false;
                GrafButton.Enabled = false;
                UlozitButton.Enabled = false;
                ExportButton.Enabled = false;
            }
        }

        private void VypisCommityDoTabulky(List<File> soubory)
        {
            soubory.Reverse();

            foreach (File soubor in soubory)
            {
                pocetNovychSouboru++;
                TabulkaCommitu.Rows.Insert(0, soubor.filename, soubor.datum_commitu.ToString(), soubor.sha.ToString(), soubor.status.ToString());
            }

        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            while (cas.VratAktualniCasMs() != 1000)
            {
                cas.OdectiSekunduAktualnihoCasu();
            }

        }

        private async void GrafButton_Click(object sender, EventArgs e)
        {

            String selected_file = TabulkaCommitu.SelectedCells[0].Value.ToString();

            GrafForm GraphForm = new GrafForm(selected_file);
            GraphForm.Text = "Graf " + selected_file;
            GraphForm.Show();
            GraphForm.chart1.Legends.Clear();
            Sluzba sluzba = new Sluzba();
            try
            {
                var stat = await sluzba.VratStatistikuZmenyRadkuSouboruAsync(selected_file);
                //GraphForm.chart1.Series["Počet přidaných řádků"].Points.Clear();
                stat.Reverse();
                int meziVypocet = 0;
                foreach (var commit in stat)
                {
                    if (meziVypocet == 0)
                    {
                        meziVypocet = (int)(commit.pridane_radky - commit.odebrane_radky);
                    }
                    else
                    {
                        meziVypocet = meziVypocet + (int) (commit.pridane_radky - commit.odebrane_radky);
                    }
                    GraphForm.chart1.Series["Počet přidaných řádků"].Points.AddY(meziVypocet);
                    GraphForm.chart1.Series["Počet přidaných řádků"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                };
            }
            catch (System.NullReferenceException)
            {};
        }

        private async void ExportButton_Click(object sender, EventArgs e)
        {
            while (pracuji)
            {
                await Task.Delay(100);
            }
            pracuji = true;

            Sluzba s = new Sluzba();
            List<Tuple<string, DateTime>> list = new List<Tuple<string, DateTime>>();

            string cesta = VyberMistoUlozeni("export.xlsx");

            try
            {
                if (cesta != null)
                {
                    foreach (DataGridViewRow row in TabulkaCommitu.Rows)
                    {
                        list.Add(new Tuple<string, DateTime>(row.Cells[0].Value.ToString(), DateTime.Parse(row.Cells[1].Value.ToString())));
                    }
                    LogniCas();
                    notifikace.Text = "Exportuji...";
                    var excel = await s.VytvorExcelSeznamCommituAsync(list, cesta);

                    if (excel)
                    {
                        notifikace.Text = "Soubor exportován do: " + cesta;
                        //TabulkaCommitu.ClearSelection();
                        //TabulkaCommitu.Rows.Clear();
                        //TabulkaCommitu.Refresh();
                        Console.WriteLine("excel vytvoren v: " + cesta);
                    }
                    else
                    {
                        notifikace.Text = "Soubor se nepodařilo exportovat";
                        Console.WriteLine("excel nevytvoren");
                    }
                }
                else
                {
                    Console.WriteLine("cesta nevybrana");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
                pracuji = false;
        }

        private async void UlozitButon_Click(object sender, EventArgs e)
        {
            while (pracuji)
            {
                await Task.Delay(100);
            }
            pracuji = true;
            String status = TabulkaCommitu.SelectedRows[0].Cells[3].Value.ToString();
            if (!status.Equals("removed"))
            {
                Sluzba s = new Sluzba();
                String nazev = TabulkaCommitu.SelectedRows[0].Cells[0].Value.ToString();
                String nazev2 = nazev;
                if (nazev.Contains(@"/"))
                {
                    char parser = '/';
                    string[] parsed = nazev.Split(parser);
                    if (parsed != null)
                    {
                        nazev2 = parsed[parsed.Length - 1];
                    }
                    else
                    {
                        nazev2 = "nevim.java";
                    }
                }
                String cesta = VyberMistoUlozeni(nazev2);
                String sha = TabulkaCommitu.SelectedRows[0].Cells[2].Value.ToString();
                try
                {
                    if (cesta != null)
                    {
                        LogniCas();
                        notifikace.Text = "Ukládám soubor...";


                        var uloz = await s.StahniSouborZGituAsync(cesta, nazev, sha);

                        if (uloz)
                        {
                            notifikace.Text = "Soubor uložen do: " + cesta;
                            Console.WriteLine("ulozeno do: " + cesta);
                        }
                        else
                        {
                            notifikace.Text = "Soubor se nepodařilo uložit";
                            Console.WriteLine("neulozeno: " + cesta + " " + nazev + " " + sha);
                        }
                    }
                    else
                    {
                        Console.WriteLine("cesta nevybrana");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else {

                notifikace.Text = "Soubor ve vybrané verzi nelze \n uložit jelikož je vymazán";
                MessageBox.Show("Soubor ve vybrané verzi nelze \n uložit jelikož je vymazán", "Nelze uložit");

            }
                pracuji = false;

        }
        private void TabulkaCommitu_SelectionChanged(object sender, EventArgs e)
        {
            NastavTlacitkaAKontrolku();
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            NastavTlacitkaAKontrolku();
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            NastavTlacitkaAKontrolku();
        }

        private void LogniCas()
        {
            posledniRefresh.Text = "Poslední aktualizace v: " + DateTime.Now.ToString();
        }

        private string VyberMistoUlozeni(string nazev)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            string format = Path.GetExtension(nazev);
            savefile.FileName = nazev;
            savefile.Filter = format.Substring(1, format.Length - 1).ToUpper() + " soubory (*" + format + ")|*" + format + "|Všechny soubory (*.*)|*.*";

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                return savefile.FileName;
            }
            else
            {
                return null;
            }
        }

        private bool ZkouskaInternetovehoPripojeni()
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

        private void LogBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
