using System;
using System.Globalization;
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
            Console.WriteLine("Choose way to use database:\nPrint 0 to use ADO.Net or 1 to use Entity Framework");
            int variant = int.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            IServiceProvider serviceProvider = null;
            try
            {
                serviceProvider = new DependencyResolver().CreateServiceProvider(variant);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Invalid  way to use databse chosen.");
                Environment.Exit(-1);
            }

            var processor = serviceProvider.GetService<ITradeProcessor>();
            Console.WriteLine($"Data base contains {processor.Run()} records.");
        }
    }
}
