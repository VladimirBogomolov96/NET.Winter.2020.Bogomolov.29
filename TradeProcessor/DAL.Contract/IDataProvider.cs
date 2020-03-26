using System;
using System.Collections.Generic;

namespace DAL.Contract
{
    /// <summary>
    /// Data provider contract.
    /// </summary>
    /// <typeparam name="T">Type of data.</typeparam>
    public interface IDataProvider<T> : IDisposable
    {
        /// <summary>
        /// Provides data.
        /// </summary>
        /// <returns>Data sequence.</returns>
        IEnumerable<T> GetData();
    }
}
