using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Contract;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DAL.Implementations
{
    public class EFStatisticReciever : IStatisticReciever<int>
    {
        private readonly IDesignTimeDbContextFactory<AppContext> factory;

        public EFStatisticReciever(IDesignTimeDbContextFactory<AppContext> factory)
        {
            this.factory = factory;
        }

        public void Dispose()
        {
        }

        public int GetStatistic()
        {
            AppContext context = this.factory.CreateDbContext(null);
            return context.TradeDataDbMaps.Count();
        }
    }
}
