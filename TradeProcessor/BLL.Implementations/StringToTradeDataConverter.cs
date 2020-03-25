using System;
using BLL.Contract;
using Entities;

namespace BLL.Implementations
{
    public class StringToTradeDataConverter : IConverter<DataTransfer, string>
    {
        private const int AmountOfParameters = 3;
        private const int CodeLength = 6;
        private readonly IValidator<DataTransfer> validator;

        public StringToTradeDataConverter(IValidator<DataTransfer> validator)
        {
            this.validator = validator;
        }

        public DataTransfer Convert(string source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source), "Source must be not null.");
            }

            var parameters = source.Split(',');
            if (parameters.Length != AmountOfParameters)
            {
                throw new FormatException("Invalid data format.");
            }

            if (parameters[0].Length != CodeLength)
            {
                throw new FormatException("Invalid data format.");
            }

            string countryCode = parameters[0].Substring(0, 3);
            string currencyCode = parameters[0].Substring(3, 3);
            if (!int.TryParse(parameters[1], out int amountOfTrades))
            {
                throw new FormatException("Invalid data format.");
            }

            if (!decimal.TryParse(parameters[2], out decimal cost))
            {
                throw new FormatException("Invalid data format");
            }

            DataTransfer dataTransfer = new TradeData(countryCode, currencyCode, amountOfTrades, cost);
            this.validator.Validate(dataTransfer);
            return dataTransfer;
        }
    }
}
