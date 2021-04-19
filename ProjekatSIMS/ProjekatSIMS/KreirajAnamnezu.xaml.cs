﻿using Model;
using Newtonsoft.Json;
using Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjekatSIMS
{
    /// <summary>
    /// Interaction logic for KreirajAnamnezu.xaml
    /// </summary>
    public partial class KreirajAnamnezu : Page
    {
        public Pacijent pacijent { get; set; }

        public KreirajAnamnezu(Pacijent p)
        {
            InitializeComponent();
            this.DataContext = this;

            Datum.SelectedDate = DateTime.Now;
           
            pacijent = p;
        }

        private void KreiranjeAnamneze(object sender, RoutedEventArgs e)
        {
            AnamnezaRepository anamnezaRepository = new AnamnezaRepository();
          
            Anamneza a = new Anamneza();
            a.OpisAnamneze = Opis.Text;
            a.datum = (DateTime)Datum.SelectedDate;
           
            /* if (anamnezaRepository.DobaviSveAnamneze() == null)
                 lista.Add(a);
             else
             {
                 lista = anamnezaRepository.DobaviSveAnamneze();
                 lista.Add(a);
             }*/

            List<ZdravsteniKarton> kartoni = new List<ZdravsteniKarton>();
            
            using (StreamReader r = new StreamReader(@"..\..\..\Fajlovi\ZdravstveniKarton.txt"))
            {
                string json = r.ReadToEnd();
                kartoni = JsonConvert.DeserializeObject<List<ZdravsteniKarton>>(json);
            }
            foreach(ZdravsteniKarton k in kartoni)
            {
                if (k.pacijent.Jmbg == pacijent.Jmbg)
                {
                    //a.zdravsteniKarton = k;
                    if (k.anamneza == null)
                    {
                        k.anamneza = new List<Anamneza>();
                        k.anamneza.Add(a);
                    }
                        
                    else
                    {
                        k.anamneza.Add(a);
                    }
                  
                }
            }

            string newJson = JsonConvert.SerializeObject(kartoni);
            File.WriteAllText(@"..\..\..\Fajlovi\ZdravstveniKarton.txt", newJson);


            MessageBox.Show("Uspjesno je sacuvana anamneza");
            ZdravstveniKartonDoktor z = new ZdravstveniKartonDoktor(pacijent);

            this.NavigationService.Navigate(z);

        }

        
    }
}