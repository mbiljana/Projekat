using ProjekatSIMS.ViewModelSekretar;
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
    public partial class ZauzetostProstorijaView : Window
    {
        public ZauzetostProstorijaView(ZauzetostProstorijaViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }
    }
}
