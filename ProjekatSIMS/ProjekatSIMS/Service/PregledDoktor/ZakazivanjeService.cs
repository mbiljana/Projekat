using Controller;
using Model;
using ProjekatSIMS.Model;
using ProjekatSIMS.ViewDoktor;
using ProjekatSIMS.ViewModelDoktor;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace ProjekatSIMS.Service
{
    public abstract class ZakazivanjeService
    {
       
        private ZauzetostTerminaPregledaController zauzetostTerminaPregledaController = new ZauzetostTerminaPregledaController();
        private ManipulacijaPregledomController zakaziPregledController = new ManipulacijaPregledomController();
        public PrikazSlobodnihTerminaController prikazSlobodnihTerminaController = new PrikazSlobodnihTerminaController();
        public DoktorRepository doktorRepository = new DoktorRepository();
        public PregledRepository pregledRepository = new PregledRepository();
       
        public Pregled KreiranjePregleda(IntervalDatuma termin, Prostorija prostorija, Pacijent pacijent,Doktor doktor)
        {
            
            Pregled pregled = new Pregled();
            pregled.Pocetak = termin.PocetnoVrijeme;
            pregled.Trajanje = termin.KrajnjeVrijeme.Subtract(termin.PocetnoVrijeme).Minutes;
            DopujavanjePregleda(pregled);
            pregled.StatusPregleda = StatusPregleda.Zakazan;
            pregled.prostorija = prostorija;
            pregled.doktor = doktor;
            pregled.pacijent = pacijent;
            return pregled;
        }
        
        public abstract void DopujavanjePregleda(Pregled p);
        public abstract void IspisivanjePoruke();


        public List<String> ZauzetiTermini(IntervalDatuma termin,Pregled pregled)
        {

            if (zauzetostTerminaPregledaController.ProvjeraZauzetostiTermina(pregled, termin))
            {
                List<String> termini = new List<String>();
                termini = prikazSlobodnihTerminaController.PrikazTermina(pregled, termin);
                MessageBox.Show("Dati termin je zauzet");
               
               return termini;
            }
            else
            {
                zakaziPregledController.ZakaziPregled(pregled);
                IspisivanjePoruke();
                 return null;

            }
        }

       
       
       

       
    }
}
