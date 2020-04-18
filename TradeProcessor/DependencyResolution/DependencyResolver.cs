using System;
using BLL.Contract;
using BLL.Implementations;
using DAL.Contract;
using DAL.Implementations;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NLog;

namespace DependencyResolution
{
    /// <summary>
    /// Resolves dependencies.
    /// </summary>
    public class DependencyResolver
    {
        /// <summary>
        /// Gets IConfigurationRoot for program configuration.
        /// </summary>
        /// <value>IConfigurationRoot for program configuration.</value>
        public static IConfigurationRoot ConfigurationRoot { get; } = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

        /// <summary>
        /// Creates IServiceProvider for dependecy resolution.
        /// </summary>
        /// <param name="variant">Variant of service to use.</param>
        /// <returns>IServiceProvider.</returns>
        public IServiceProvider CreateServiceProvider(int variant)
        {
            if (variant == 0)
            {
                return new ServiceCollection()
                .AddSingleton<IDataProvider<string>>(s => new StringsFromStreamDataProvider(ConfigurationRoot.GetSection("SourceFilePath").Value))
                .AddSingleton<IDataSaver<DataTransfer>>(s => new DataTransferToDataBaseSaver(ConfigurationRoot.GetConnectionString("DefaultConnection")))
                .AddSingleton<Storage<string, DataTransfer>, TradeDataStorage>()
                .AddSingleton<IStatisticReciever<int>>(s => new DataBaseCountReciever(ConfigurationRoot.GetConnectionString("DefaultConnection")))
                .AddSingleton<ILogger>(s => LogManager.GetCurrentClassLogger())
                .AddSingleton<IValidator<DataTransfer>, DataTransferValidator>()
                .AddSingleton<IConverter<DataTransfer, string>, StringToTradeDataConverter>()
                .AddSingleton<ITradeProcessor, TradeProcessor>()
                .BuildServiceProvider();
            }
            else if (variant == 1)
            {
                return new ServiceCollection()
                .AddSingleton<IDataProvider<string>>(s => new StringsFromStreamDataProvider(ConfigurationRoot.GetSection("SourceFilePath").Value))
                .AddSingleton<IDesignTimeDbContextFactory<DAL.Implementations.AppContext>, AppContextFactory>()
                .AddSingleton<IDataSaver<DataTransfer>, EFSaver>()
                .AddSingleton<Storage<string, DataTransfer>, TradeDataStorage>()
                .AddSingleton<IStatisticReciever<int>, EFStatisticReciever>()
                .AddSingleton<ILogger>(s => LogManager.GetCurrentClassLogger())
                .AddSingleton<IValidator<DataTransfer>, DataTransferValidator>()
                .AddSingleton<IConverter<DataTransfer, string>, StringToTradeDataConverter>()
                .AddSingleton<ITradeProcessor, TradeProcessor>()
                .BuildServiceProvider();
            }
            else
            {
                throw new ArgumentException("Choose 0 to use ADO or 1 to use Entity Framework.", nameof(variant));
            }
        }
    }
}
