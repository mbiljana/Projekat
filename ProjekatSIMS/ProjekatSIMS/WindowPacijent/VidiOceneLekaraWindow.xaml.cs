﻿
using ProjekatSIMS.Model;
using ProjekatSIMS.Repository;
using System.Collections.Generic;
using System.Windows;

namespace ProjekatSIMS.WindowPacijent
{
   
    public partial class VidiOceneLekaraWindow : Window
    {
        public List<OcenaLekara> OceneLekara
        {
            get;
            set;
        }
        public VidiOceneLekaraWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            OceneLekara = new List<OcenaLekara>();
            OcenaRepository fajl = new OcenaRepository(@"..\..\..\Fajlovi\OcenaLekara.txt");
            OceneLekara = fajl.DobaviSveOceneLekara();
        }
    }
}