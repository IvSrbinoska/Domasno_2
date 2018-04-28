using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domasno_2.Models
{
    public class MarketData
    {
        public string StockSymbol { get; set; }
        //public decimal StockPrice { get; set; }

        public decimal PriceClose { get; set; }
    }
}
