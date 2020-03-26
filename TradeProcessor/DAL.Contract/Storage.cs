using System.Collections.Generic;

namespace DAL.Contract
{
    /// <summary>
    /// Storage abstract class.
    /// </summary>
    /// <typeparam name="TProvide">Type of data to get.</typeparam>
    /// <typeparam name="TSave">Type of data to save.</typeparam>
    public abstract class Storage<TProvide, TSave> : IDataSaver<TSave>, IDataProvider<TProvide>
    {
        /// <summary>
        /// Inner data provider.
        /// </summary>
        protected readonly IDataProvider<TProvide> dataProvider;

        /// <summary>
        /// Inner data saver.
        /// </summary>
        protected readonly IDataSaver<TSave> dataSaver;
        private bool disposedValue = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="Storage{TProvide, TSave}"/> class.
        /// </summary>
        /// <param name="dataProvider">Inner data provider.</param>
        /// <param name="dataSaver">Inner data saver.</param>
        public Storage(IDataProvider<TProvide> dataProvider, IDataSaver<TSave> dataSaver)
        {
            this.dataProvider = dataProvider;
            this.dataSaver = dataSaver;
        }

        /// <summary>
        /// Provides data.
        /// </summary>
        /// <returns>Data sequence.</returns>
        public abstract IEnumerable<TProvide> GetData();

        /// <summary>
        /// Saves data.
        /// </summary>
        /// <param name="values">Values to save.</param>
        public abstract void SaveData(IEnumerable<TSave> values);

        /// <summary>
        /// Implementation of dispose patthern.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
        }

        /// <summary>
        /// Implementation of dispose patthern.
        /// </summary>
        /// <param name="disposing">Whether called from Dispose.</param>
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
