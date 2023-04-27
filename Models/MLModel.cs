using Microsoft.ML;
using Microsoft.ML.Trainers;
using Microsoft.ML.Transforms.TimeSeries;
using System;
using System.Collections.Generic;
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

            var pipeline = _context.Forecasting.ForecastBySsa("Forecast", nameof(StockData.Stock), windowSize: 7, seriesLength: 30, trainSize: 10000, horizon: 1);

            return pipeline.Fit(data);  
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
