using Microsoft.ML.Data;
using System;

namespace StockPredictorApp.Models
{
    internal class StockData
    {
        [LoadColumn(0)]
        public DateTime Date { get; set; }

        [LoadColumn(4)]
        public float Stock { get; set; }
    }
}