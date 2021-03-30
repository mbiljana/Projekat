
using Model.DoktorModel;
using System;

namespace Model
{
   public class Pacijent
   {
      public void PregledProfila()
      {
         // TODO: implement
      }
      
      public Pacijent KreirajProfil()
      {
         // TODO: implement
         return null;
      }
      
      public Boolean IzmeniInformacije()
      {
            // TODO: implement
            return true;
        }
      
      public Boolean ObrisiPacijent(int id)
      {
            // TODO: implement
            return true; 
      }
   
      public String jmbg { get; set; }
        public String ime { get; set; }
        public String prezime { get; set; }
        public String brojTelefona { get; set; }
        public String email { get; set; }
        public DateTime datumRodjenja { get; set; }
        public String adresa { get; set; }

        public RegistrovaniKorisnik registrovaniKorisnik;
      public System.Collections.ArrayList pregled;
      
      /// <pdGenerated>default getter</pdGenerated>
      public System.Collections.ArrayList GetPregled()
      {
         if (pregled == null)
            pregled = new System.Collections.ArrayList();
         return pregled;
      }
      
      /// <pdGenerated>default setter</pdGenerated>
      public void SetPregled(System.Collections.ArrayList newPregled)
      {
         RemoveAllPregled();
         foreach (Pregled oPregled in newPregled)
            AddPregled(oPregled);
      }
      
      /// <pdGenerated>default Add</pdGenerated>
      public void AddPregled(Pregled newPregled)
      {
         if (newPregled == null)
            return;
         if (this.pregled == null)
            this.pregled = new System.Collections.ArrayList();
         if (!this.pregled.Contains(newPregled))
         {
            this.pregled.Add(newPregled);
            newPregled.SetPacijent(this);      
         }
      }
      
      /// <pdGenerated>default Remove</pdGenerated>
      public void RemovePregled(Pregled oldPregled)
      {
         if (oldPregled == null)
            return;
         if (this.pregled != null)
            if (this.pregled.Contains(oldPregled))
            {
               this.pregled.Remove(oldPregled);
               oldPregled.SetPacijent((Model.Pacijent)null);
            }
      }
      
      /// <pdGenerated>default removeAll</pdGenerated>
      public void RemoveAllPregled()
      {
         if (pregled != null)
         {
            System.Collections.ArrayList tmpPregled = new System.Collections.ArrayList();
            foreach (Pregled oldPregled in pregled)
               tmpPregled.Add(oldPregled);
            pregled.Clear();
            foreach (Pregled oldPregled in tmpPregled)
               oldPregled.SetPacijent((Model.Pacijent)null);
            tmpPregled.Clear();
         }
      }
   
   }
}