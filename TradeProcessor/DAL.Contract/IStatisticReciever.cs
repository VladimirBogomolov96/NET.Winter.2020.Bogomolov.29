using System;

namespace DAL.Contract
{
    /// <summary>
    /// Statistic reciever contract.
    /// </summary>
    /// <typeparam name="T">Type of statistic result.</typeparam>
    public interface IStatisticReciever<T> : IDisposable
    {
        /// <summary>
        /// Gets statistic result.
        /// </summary>
        /// <returns>Statistic result.</returns>
        T GetStatistic();
    }
}
