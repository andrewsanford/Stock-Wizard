using Microsoft.ML;
using Microsoft.ML.Trainers;
using Microsoft.ML.Transforms.TimeSeries;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockPredictorApp.Models
{
    public class MLModel
    {
        private MLContext _context;
        public MLModel() 
        {
            _context = new MLContext();
        }

        public ITransformer Train()
        {
            var data = _context.Data.LoadFromTextFile<StockData>("model_data.csv", hasHeader: true, separatorChar: ',');

            var pipeline = _context.Forecasting.ForecastBySsa("Forecast", nameof(StockData.Stock), windowSize: 30, seriesLength: 365, trainSize: 10000, horizon: 1, confidenceLevel: 0.99f);

            var model = pipeline.Fit(data);

            _context.Model.Save(model, data.Schema, DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Year.ToString() + "model.zip");

            return model;
        }

        public ITransformer Load()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.DefaultExt = ".zip"; // Required file extension 
            fileDialog.Filter = "ZIP documents (.zip)|*.zip"; // Optional file extensions

            bool? res = fileDialog.ShowDialog();

            if (res.HasValue && res.Value)
            {
                try
                {
                    File.Delete("active_model.zip");
                }
                catch
                {

                }

                File.Copy(fileDialog.FileName, "active_model.zip");
            }

            return _context.Model.Load("active_model.zip", out var inputSchhema);
        }

        public List<float> Predict(ITransformer model)
        {
            List<float> result = new List<float>();

            var forecastingEngine = model.CreateTimeSeriesEngine<StockData, StockForecast>(_context);

            var forecasts = forecastingEngine.Predict();

            foreach (var forecast in forecasts.Forecast) 
            {
                result.Add(forecast);
            }

            return result;
        }
    }
}
