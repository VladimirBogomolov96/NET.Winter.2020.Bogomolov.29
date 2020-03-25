using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class TradeData : DataTransfer
    {
        public TradeData()
            : base()
        {
        }

        public TradeData(string countryCode, string currencyCode, int amountOfTrades, decimal cost)
        {
            this.CountryCode = countryCode;
            this.CurrencyCode = currencyCode;
            this.AmountOfTrades = amountOfTrades;
            this.Cost = cost;
        }
    }
}
