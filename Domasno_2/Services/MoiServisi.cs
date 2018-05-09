using Domasno_2.Controllers;
using Domasno_2.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Domasno_2.Services
{
    public class MoiServisi
    {
        public int Soberi(int a,int b)
        {
            return a + b;
        }

        public async Task<int> Pomnozi(int a,int b)
        {
            return a * b;
        }

        public async Task<decimal> GetStockPriceAsync(string symbol)
        {
            string dataApi = "";
            decimal ret = 0;

            using (var webClient = new WebClient())
            {
                string url = "https://api.iextrading.com/1.0";
                url += String.Format("/stock/{0}/quote", symbol);
                try
                {
                    dataApi = await webClient.DownloadStringTaskAsync(url);
                }
                catch (Exception ex)
                {
                    //_logger.LogError(ex, "Get stock data failed");

                }
            }
            

            if (dataApi.Length > 0)
            {
                try
                {
                    var dataJson = JObject.Parse(dataApi);
                    //decimal priceClose = dataJson.SelectToken("latestPrice").Value<decimal>();
                    //objMarket.PriceClose = dataJson.SelectToken("latestPrice").Value<decimal>();
                    ret = dataJson.SelectToken("latestPrice").Value<decimal>();
                }
                catch (Exception ex)
                {
                    //_logger.LogError(ex, "Get stock data failed! symbol={0}", stockSymbol);
                }
            }

            return ret;
        }

        
    }
}
