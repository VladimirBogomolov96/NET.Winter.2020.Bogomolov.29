using System;
using BLL.Contract;
using DependencyResolution;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleUI
{
    /// <summary>
    /// UI class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Start point of program.
        /// </summary>
        public static void Main()
        {
            var serviceProvider = new DependencyResolver().CreateServiceProvider();
            var processor = serviceProvider.GetService<ITradeProcessor>();
            Console.WriteLine($"Data base contains {processor.Run()} records.");
        }
    }
}
