﻿using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Repository
{
    class PacijentRepository
    {
        private const string putanja = @"..\..\Fajlovi\Pacijent.txt";
        public List<Pacijent> UcitajSvePacijente()
        {
            List<Pacijent> pacijenti = new List<Pacijent>();
            using (StreamReader r = new StreamReader(@"..\..\Fajlovi\Pacijent.txt"))
            {
                string json = r.ReadToEnd();
                pacijenti = JsonConvert.DeserializeObject<List<Pacijent>>(json);
            }
            return pacijenti;

        }
    }
}