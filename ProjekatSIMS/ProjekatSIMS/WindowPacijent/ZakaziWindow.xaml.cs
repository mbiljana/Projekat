﻿using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Windows;

namespace ProjekatSIMS.WindowPacijent
{

    public partial class ZakaziWindow : Window
    {
        public ZakaziWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void ZakaziPregled(object sender, RoutedEventArgs e)
        {
            Pregled p = new Pregled();
            String ime = Ime.Text;
            String prezime = Prezime.Text;
            String imeDoktora = ImeDoktora.Text;
            String prezimeDoktora = PrezimeDoktora.Text;
            String jmbg = Jmbg.Text;
            DateTime datum = (DateTime)Date.SelectedDate;
            double sati = Convert.ToDouble(Sati.Text);
            double minuti = Convert.ToDouble(Minuti.Text);
            DateTime datum1 = new DateTime();

            datum1 = datum.AddHours(sati);
            datum1 = datum1.AddMinutes(minuti);
            int trajanje = 30;
            DateTime datum2 = datum1.AddMinutes(trajanje);

            p.Tip = TipPregleda.Standardni;
            p.Pocetak = datum1;
            p.Trajanje = trajanje;
            Pacijent pac = new Pacijent { Jmbg = jmbg, Ime = ime, Prezime = prezime };
            p.pacijent = pac;
            Doktor dr = new Doktor { Ime = imeDoktora, Prezime = prezimeDoktora };
            p.doktor = dr;
            p.StatusPregleda = StatusPregleda.Zakazan;


            PregledRepository fajl = new PregledRepository(@"..\..\Fajlovi\Pregled.txt");
            List<Pregled> pregledi = fajl.DobaviSvePregledePacijent();

            ProstorijaRepository file = new ProstorijaRepository(@"..\..\Fajlovi\Prostorija.txt");
            List<Prostorija> prostorije = file.DobaviSveProstorije();
            foreach (Prostorija pr in prostorije)
            {
                if (pr.slobodna == true)
                {
                    p.prostorija = pr;
                    pr.slobodna = false;
                    break;
                }
            }

            pregledi.Add(p);

            fajl.SacuvajPregledPacijent(pregledi);

            MessageBox.Show("Pregled je uspesno zakazan.");
            this.Close();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}