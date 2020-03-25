using System;
using System.Collections.Generic;

namespace DAL.Contract
{
    public interface IDataSaver<T> : IDisposable
    {
        void SaveData(IEnumerable<T> values);
    }
}
