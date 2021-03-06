using Model;
using ProjekatSIMS.Controller;
using ProjekatSIMS.Model;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ProjekatSIMS.WindowPacijent
{
    public partial class OceniLekaraPacijent : Page
    {
        public OcenaController ocenaController = new OcenaController();
        public string OcenaLekara { get; set; }

       
        public List<Pregled> pregledi
        {
            get;
            set;
        }
        public OceniLekaraPacijent()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void Oceni(object sender, RoutedEventArgs e)
        {
            String imeLekara = Ime.Text;
            String prezimeLekara = Prezime.Text;
            String ocenaLekara = Ocena.Text;
            String komentar = Komentar.Text;

            if (ocenaController.ProsledjenaOcenaLekara(imeLekara, prezimeLekara, ocenaLekara, komentar) == true)
            {
                MessageBox.Show("Hvala Vam sto ste izdvojili vreme da ocenite lekara!");
                this.NavigationService.GoBack();
            }
            else
            {
                MessageBox.Show("Lekara mozete oceniti samo ako ste prethodno bili na pregledu kod njega. ");
            }
        }

        private void Odustani(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
