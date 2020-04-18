using System;
using System.Collections.Generic;
using System.Text;
using DAL.Contract;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DAL.Implementations
{
    public class EFSaver : IDataSaver<DataTransfer>
    {
        private readonly IDesignTimeDbContextFactory<AppContext> factory;

        public EFSaver(IDesignTimeDbContextFactory<AppContext> factory)
        {
            this.factory = factory;
        }

        public void Dispose()
        {
        }

        public void SaveData(IEnumerable<DataTransfer> values)
        {
            if (values is null)
            {
                throw new ArgumentNullException(nameof(values), "Values must be not null.");
            }

            DbContext context = this.factory.CreateDbContext(null);
            foreach (DataTransfer dataTransfer in values)
            {
                TradeDataDbMap map = new TradeDataDbMap()
                {
                    AmountOfTrades = dataTransfer.AmountOfTrades,
                    Cost = dataTransfer.Cost,
                    CountryCode = dataTransfer.CountryCode,
                    CurrencyCode = dataTransfer.CurrencyCode,
                };
                context.Add<TradeDataDbMap>(map);
            }

            context.SaveChanges();
            context.Dispose();
        }
    }
}
