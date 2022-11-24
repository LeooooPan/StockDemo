using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockDemo.Models
{
    public class FakeData
    {
        public static List<BasicStockClass> FakeDataList = new List<BasicStockClass>();
    }

    public class BasicStockClass
    {
        private double _tradingVolume;
        private double _openingPrice;

        public string Name { get; set; }

        public double TradingVolume { get => _tradingVolume; set => _tradingVolume = Math.Round(value, 2); }
               
        public double OpeningPrice { get => _openingPrice; set => _openingPrice = Math.Round(value, 2); }

    }
}
