﻿using Controller;
using Model;
using System;
using System.Windows;

namespace ProjekatSIMS
{

    public partial class DetaljiPregledaDoktor : Window
    {
        private Pregled pregled { get; set; }

        private OtkazivanjePregledaDoktorController otkazivanjePregledaDoktorController = new OtkazivanjePregledaDoktorController();
        private PregledController pregledController;
        public DetaljiPregledaDoktor(Pregled p)
        {
            InitializeComponent();
            this.DataContext = this;
            pregled = p;
            UcitavanjePodatakaZaPrikaz(p);

        }

        private void UcitavanjePodatakaZaPrikaz(Pregled p)
        {
            Pacijent.Text = p.pacijent.Ime + " " + p.pacijent.Prezime;
            Sala.Text = p.prostorija.id;
            Tip.Text = p.Tip.ToString();
            Datum.Text = p.Pocetak.Month.ToString() + "/" + p.Pocetak.Day.ToString() + "/" + p.Pocetak.Year.ToString();
            DateTime kraj = p.Pocetak.AddMinutes(p.Trajanje);
            Vrijeme.Text = p.Pocetak.Hour.ToString() + ":" + p.Pocetak.Minute.ToString() + "-" + kraj.Hour.ToString() + ":" + kraj.Minute.ToString();
        }

        private void OtkaziPregled(object sender, RoutedEventArgs e)
        {

            otkazivanjePregledaDoktorController.OtkazivanjePregleda(pregled);
            MessageBox.Show("Uspjesno ste otkazali pregled");

            //PrikazPregledaDoktor pd = new PrikazPregledaDoktor();
            //  this.NavigationService.Navigate(pd);
            // NavigationService navService = NavigationService.GetNavigationService(this)navService.Navigate = (newSystem.Uri("Page2.xaml", UriKind.RelativeOrAbsolute);

        }

        private void IzmijeniPregled(object sender, RoutedEventArgs e)
        {


            PomjeriPregledDoktor po = new PomjeriPregledDoktor(pregled);
            // this.NavigationService.Navigate(new Uri("PomjeriPregledDoktor.xaml", UriKind.Relative));
            // this.NavigationService.Navigate(po);


        }

        private void PrikazProfila(object sender, RoutedEventArgs e)
        {



            ZdravstveniKartonDoktor z = new ZdravstveniKartonDoktor(pregled.pacijent);
            // this.NavigationService.Navigate(new Uri("PomjeriPregledDoktor.xaml", UriKind.Relative));
            // this.NavigationService.Navigate(z);


        }

        private void ZapocniPregled(object sender, RoutedEventArgs e)
        {

            IzvrsavanjePregledaDoktor i = new IzvrsavanjePregledaDoktor(pregled);
            // this.NavigationService.Navigate(new Uri("PomjeriPregledDoktor.xaml", UriKind.Relative));
            // this.NavigationService.Navigate(i);


        }
    }
}
