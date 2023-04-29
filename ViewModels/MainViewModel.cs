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

        private string _wizardLine;
        private string _finalPrediction;

        private List<string> _wizardLines;

        public MainViewModel()
        {
            _predictor = new MLModel();
            _wizardLines = new List<string>
            {
                "I'd get in on that!",
                "Fortune favors the brave!",
                "By my beard!",
                "The ball doesn't lie!",
                "Don't stare too long!",
                "Lunch is on you today!",
                "I'm not surprised!"
            };



            Random rnd = new Random();
            WizardLine = _wizardLines[rnd.Next(0, _wizardLines.Count)];
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

            FinalPrediction = _predictor.Predict(_model)[0].ToString("c2");

            Trace.WriteLine(FinalPrediction.ToString() + "confirmed");

        }

        public void UploadModel()
        {
            _model = _predictor.Load();
        }

        public string FinalPrediction
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

        public string WizardLine
        {
            get
            {
                return _wizardLine;
            }
            set
            {
                _wizardLine = value;
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
