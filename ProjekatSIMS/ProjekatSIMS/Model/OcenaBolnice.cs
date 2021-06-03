﻿using Model;
using System;

namespace ProjekatSIMS.Model
{
    public class OcenaBolnice
    {
        public String Ocena { get; set; }
        public String Komentar { get; set; }
        public String Pacijent { get; set; }

        public OcenaBolnice()
        {
            this.Ocena = "";
            this.Komentar = "";
        }
        public OcenaBolnice(String ocena, String komentar)
        {
            this.Ocena = ocena;
            this.Komentar = komentar;
        }
    }
}
