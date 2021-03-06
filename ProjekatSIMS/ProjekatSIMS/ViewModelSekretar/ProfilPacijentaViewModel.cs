using System;
using System.Collections.Generic;
using System.Text;
using Model;
using System.Windows;

namespace ProjekatSIMS.ViewModelSekretar
{
    public class ProfilPacijentaViewModel : BindableBase
    {
        private Pacijent pacijent;
        private Window thisWindow;
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Jmbg { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string Telefon { get; set; }
        public string Mail { get; set; }
        public string Adresa { get; set; }
        public ProfilPacijentaViewModel()
        {

        }
        public ProfilPacijentaViewModel(Pacijent pacijent,Window thisWindow)
        {
            this.pacijent = pacijent;
            this.thisWindow = thisWindow;
            PrikaziPodatke();
        }

        private void PrikaziPodatke()
        {
            Ime = pacijent.Ime;
            Prezime = pacijent.Prezime;
            Telefon = pacijent.BrojTelefona;
            Adresa = pacijent.Adresa;
            Jmbg = pacijent.Jmbg;
            DatumRodjenja = pacijent.DatumRodjenja;
            Mail = pacijent.Email;
        }
    }
}
