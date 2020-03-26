using System;
using System.Collections.Generic;

namespace DAL.Contract
{
    /// <summary>
    /// Data saver contract.
    /// </summary>
    /// <typeparam name="T">Type of data.</typeparam>
    public interface IDataSaver<T> : IDisposable
    {
        /// <summary>
        /// Saves data.
        /// </summary>
        /// <param name="values">Values to save.</param>
        void SaveData(IEnumerable<T> values);
    }
}
