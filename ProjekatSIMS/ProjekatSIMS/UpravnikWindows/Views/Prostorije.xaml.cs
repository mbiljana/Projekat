﻿using ProjekatSIMS.UpravnikWindows.ViewModelUpravnik;
using System;
using System.Collections.Generic;
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

namespace ProjekatSIMS.UpravnikWindows.Views
{
    /// <summary>
    /// Interaction logic for Prostorije.xaml
    /// </summary>
    public partial class Prostorije : Page
    {
        public Prostorije()
        {
            InitializeComponent();
            this.DataContext = new ProstorijeViewModel();
        }
    }
}
