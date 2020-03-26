using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    /// <summary>
    /// Contains information about trades.
    /// </summary>
    public class TradeData : DataTransfer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TradeData"/> class.
        /// </summary>
        public TradeData()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TradeData"/> class.
        /// </summary>
        /// <param name="countryCode">Country code.</param>
        /// <param name="currencyCode">Currency code.</param>
        /// <param name="amountOfTrades">Amount of trades.</param>
        /// <param name="cost">Cost.</param>
        public TradeData(string countryCode, string currencyCode, int amountOfTrades, decimal cost)
        {
            this.CountryCode = countryCode;
            this.CurrencyCode = currencyCode;
            this.AmountOfTrades = amountOfTrades;
            this.Cost = cost;
        }
    }
}
