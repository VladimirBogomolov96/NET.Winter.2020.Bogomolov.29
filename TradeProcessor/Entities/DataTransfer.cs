using System;

namespace Entities
{
    public abstract class DataTransfer
    {
        public string CountryCode { get; set; }

        public string CurrencyCode { get; set; }

        public int AmountOfTrades { get; set; }

        public decimal Cost { get; set; }
    }
}
