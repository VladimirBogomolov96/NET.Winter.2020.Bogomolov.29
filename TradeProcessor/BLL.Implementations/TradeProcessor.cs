using System;
using System.Collections.Generic;
using BLL.Contract;
using DAL.Contract;
using Entities;
using NLog;

namespace BLL.Implementations
{
    public class TradeProcessor : ITradeProcessor
    {
        private readonly Storage<string, DataTransfer> storage;
        private readonly ILogger logger;
        private readonly IConverter<DataTransfer, string> converter;
        private readonly IStatisticReciever<int> statisticReciever;

        public TradeProcessor(Storage<string, DataTransfer> storage, ILogger logger, IConverter<DataTransfer, string> converter, IStatisticReciever<int> statisticReciever)
        {
            this.storage = storage;
            this.logger = logger;
            this.converter = converter;
            this.statisticReciever = statisticReciever;
        }

        public int Run()
        {
            List<DataTransfer> datas = new List<DataTransfer>();
            foreach (string str in this.storage.GetData())
            {
                try
                {
                    datas.Add(this.converter.Convert(str));
                }
                catch (FormatException)
                {
                    this.logger.Warn($"Wrong data format in '{str}'.");
                }
                catch (ArgumentException)
                {
                    this.logger.Warn($"Wrong data value in '{str}'");
                }
            }

            this.storage.SaveData(datas);
            this.storage.Dispose();
            int result = this.statisticReciever.GetStatistic();
            this.statisticReciever.Dispose();
            return result;
        }
    }
}
