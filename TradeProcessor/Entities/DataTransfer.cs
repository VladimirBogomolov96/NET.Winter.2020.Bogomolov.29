using System;

namespace Entities
{
    /// <summary>
    /// Data transfer abstraction.
    /// </summary>
    public abstract class DataTransfer
    {
        /// <summary>
        /// Gets or sets country code.
        /// </summary>
        /// <value>Country code value.</value>
        public string CountryCode { get; set; }

        /// <summary>
        /// Gets or sets currency code.
        /// </summary>
        /// <value>Currency code value.</value>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Gets or sets amount of trades.
        /// </summary>
        /// <value>Amount of trades.</value>
        public int AmountOfTrades { get; set; }

        /// <summary>
        /// Gets or sets cost.
        /// </summary>
        /// <value>Cost.</value>
        public decimal Cost { get; set; }
    }
}
