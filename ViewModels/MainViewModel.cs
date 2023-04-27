using Microsoft.ML;
using Microsoft.Win32;
using StockPredictorApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace StockPredictorApp.ViewModels
{
    public class MainViewModel:INotifyPropertyChanged
    {
        private ITransformer? _model;
        private MLModel _predictor;

        private float _finalPrediction;

        public MainViewModel()
        {
            _predictor = new MLModel();
        }

        public void UploadDataFile()
        {
            string readResult = "";

            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.DefaultExt = ".csv"; // Required file extension 
            fileDialog.Filter = "CSV documents (.csv)|*.csv"; // Optional file extensions

            bool? res = fileDialog.ShowDialog(); 
            
            if (res.HasValue && res.Value) 
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(fileDialog.FileName);
                readResult = sr.ReadToEnd();
                sr.Close();

                try
                {
                    File.Delete("model_data.csv");
                }
                catch
                {

                }

                File.AppendAllText("model_data.csv", readResult);
            }          
        }

        public void MakePrediction()
        {
            if(_model == null)
            {
                _model = _predictor.Train();
            }

            FinalPrediction = _predictor.Predict(_model)[0];

            Trace.WriteLine(FinalPrediction.ToString() + "confirmed");

        }

        public float FinalPrediction
        {
            get
            {
                return _finalPrediction;
            }
            set
            {
                _finalPrediction = value;
                OnPropertyChanged();
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }

    
}
