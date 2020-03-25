using System;
using BLL.Contract;
using DependencyResolution;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleUI
{
    public static class Program
    {
        public static void Main()
        {
            var serviceProvider = new DependencyResolver().CreateServiceProvider();
            var processor = serviceProvider.GetService<ITradeProcessor>();
            Console.WriteLine($"Data base contains {processor.Run()} records.");
        }
    }
}
