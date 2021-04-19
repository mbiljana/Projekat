﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjekatSIMS
{
    
    public partial class UpravnikWindow : Window
    {
        public UpravnikWindow()
        {
            InitializeComponent();
        }

        private void dinamicka(object sender, RoutedEventArgs e)
        {
            DinamickaOpremaWindow d = new DinamickaOpremaWindow();
            d.Show();
        }

        private void staticka(object sender, RoutedEventArgs e)
        {
            StatickaOpremaWindow s = new StatickaOpremaWindow();
            s.Show();
        }

        private void prostorije(object sender, RoutedEventArgs e)
        {
            ProstorijeWindow p = new ProstorijeWindow();
            p.Show();
        }
    }
}
