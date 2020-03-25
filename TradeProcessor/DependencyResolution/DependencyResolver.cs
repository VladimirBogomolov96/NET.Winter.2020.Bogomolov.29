using System;
using BLL.Contract;
using BLL.Implementations;
using DAL.Contract;
using DAL.Implementations;
using Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NLog;

namespace DependencyResolution
{
    public class DependencyResolver
    {
        public static IConfigurationRoot ConfigurationRoot { get; } = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

        public IServiceProvider CreateServiceProvider()
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
    }
}
