using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Repository
{
   public class ProstorijaRepository
   {
        private String LokacijaFajla;
        private List<Prostorija> prostorije;
       
        public void SacuvajProstoriju()
      {
         // TODO: implement
      }


        public ProstorijaRepository(String lokacija)
        {
            LokacijaFajla = lokacija;
        }
        public List<Prostorija> DobaviSveProstorije()
        {
            using (StreamReader sr = new StreamReader(LokacijaFajla))
            {
                string json = sr.ReadToEnd();
                prostorije = JsonConvert.DeserializeObject<List<Prostorija>>(json);
            }
            return prostorije;
        }

        public List<Prostorija> DobaviOrdinacije()
        {
            List<Prostorija> sveProstorije = DobaviSveProstorije();
            List<Prostorija> ordinacije = new List<Prostorija>();
            foreach(Prostorija p in sveProstorije)
            {
                if (p.vrsta == VrstaProstorije.Ordinacija)
                    ordinacije.Add(p);
            }

            return ordinacije;
        }
    }
}