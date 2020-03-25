using System;
using System.Collections.Generic;

namespace DAL.Contract
{
    public interface IDataProvider<T> : IDisposable
    {
        IEnumerable<T> GetData();
    }
}
