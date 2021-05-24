﻿using Newtonsoft.Json;
using ProjekatSIMS.Model;
using ProjekatSIMS.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace ProjekatSIMS.WindowPacijent
{
    
    public partial class PregledPodsetnika : Page
    {
        public List<Podsetnik> Podsetnici
        {
            get;
            set;
        }
        public PregledPodsetnika()
        {
            InitializeComponent();
            this.DataContext = this;
            Podsetnici = new List<Podsetnik>();
            PodsetnikRepository fajl = new PodsetnikRepository(@"..\..\..\Fajlovi\Podsetnik.txt");
            Podsetnici = fajl.DobaviSvePodsetnike();

        }

        private void Obrisi(object sender, RoutedEventArgs e)
        {
            
            Podsetnik odabrani = (Podsetnik)dataGridPodsetnik.SelectedItems[0];

            string naziv = odabrani.nazivPodsetika;
            string opis = odabrani.opisPodsetnika;
            DateTime datumPocetka = odabrani.datumPocetkaObavestenja;
            DateTime datumZavrsetka = odabrani.datumZavrsetkaObavestenja;
            using (StreamReader file = new StreamReader(@"..\..\..\Fajlovi\Podsetnik.txt"))
            {
                Podsetnici.Remove(odabrani);
            }
            string newJson = JsonConvert.SerializeObject(Podsetnici);
            File.WriteAllText(@"..\..\..\Fajlovi\Podsetnik.txt", newJson);
            MessageBox.Show("Podsetnik je obrisan");
            
        }
    }
}
