using StockPredictorApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace StockPredictorApp.Views
{
    /// <summary>
    /// Interaction logic for LoadWindow.xaml
    /// </summary>
    public partial class LoadWindow : Window
    {
        private MainViewModel _viewModel;
        public LoadWindow(MainViewModel viewModel)
        {
            InitializeComponent();

            _viewModel = viewModel;
        }
    }
}
