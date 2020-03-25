using System;

namespace DAL.Contract
{
    public interface IStatisticReciever<T> : IDisposable
    {
        T GetStatistic();
    }
}
