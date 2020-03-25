using System.Collections.Generic;

namespace DAL.Contract
{
    public abstract class Storage<TProvide, TSave> : IDataSaver<TSave>, IDataProvider<TProvide>
    {
        protected readonly IDataProvider<TProvide> dataProvider;
        protected readonly IDataSaver<TSave> dataSaver;
        private bool disposedValue = false;

        public Storage(IDataProvider<TProvide> dataProvider, IDataSaver<TSave> dataSaver)
        {
            this.dataProvider = dataProvider;
            this.dataSaver = dataSaver;
        }

        public abstract IEnumerable<TProvide> GetData();

        public abstract void SaveData(IEnumerable<TSave> values);

        public void Dispose()
        {
            this.Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    this.dataProvider.Dispose();
                    this.dataSaver.Dispose();
                }

                this.disposedValue = true;
            }
        }
    }
}
