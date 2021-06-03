﻿using ProjekatSIMS.ViewModelSekretar;
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
using System.Windows.Shapes;

namespace ProjekatSIMS.ViewSekretar
{
    public partial class PretragaDoktoraView : Window
    {
        public PretragaDoktoraView(PretragaDoktoraViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }
    }
}
