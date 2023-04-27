using StockPredictorApp.ViewModels;
using StockPredictorApp.Views;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StockPredictorApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel _viewModel;
        public MainWindow()
        {
            InitializeComponent();

            _viewModel = new MainViewModel();
        }

        private void btnLoadModel_Click(object sender, RoutedEventArgs e)
        {
            LoadWindow newWindow = new LoadWindow(_viewModel);
            newWindow.Show();
            this.Close();  
        }

        private void btnTrainModel_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.UploadDataFile();
            _viewModel.MakePrediction();
        }
    }
}
