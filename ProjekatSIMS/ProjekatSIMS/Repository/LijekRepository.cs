using Model;
using Newtonsoft.Json;
using ProjekatSIMS.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProjekatSIMS.Repository
{
    public class LijekRepository
    {
        
        

        private const String putanja = @"..\..\..\Fajlovi\Lijek.txt";

        public LijekRepository() { }

        
        public List<Lijek> DobaviSve()
        {
            List<Lijek> lekovi = new List<Lijek>();
            using (StreamReader sr = new StreamReader(putanja))
            {
                string json = sr.ReadToEnd();
                lekovi = JsonConvert.DeserializeObject<List<Lijek>>(json);
            }
            return lekovi;
        }

        public void Sacuvaj(List<Lijek> lekovi)
        {
            string json = JsonConvert.SerializeObject(lekovi);
            File.WriteAllText(putanja, json);
        }

        public Boolean ObrisiLek(String nazivLeka)
        {
            List<Lijek> lekovi = new List<Lijek>();
            lekovi = DobaviSve();
            foreach(Lijek l in lekovi)
            {
                if (l.NazivLeka == nazivLeka)
                {
                   
                    lekovi.Remove(l);
                   Sacuvaj(lekovi);
                    return true;
                }
            }
            return false;
        }

        public void AzurirajLijek(Lijek lijek)
        {
            List<Lijek> sviLijekovi = DobaviSve();
            foreach (Lijek l in sviLijekovi)

            {
                if (l.NazivLeka == lijek.NazivLeka)
                {
                    l.Opis = lijek.Opis;
                    l.Alergeni = lijek.Alergeni;
                    l.AlternativniLekovi = lijek.AlternativniLekovi;
                }
            }

            Sacuvaj(sviLijekovi);

        }
           

        
        

        

       




    }
}
