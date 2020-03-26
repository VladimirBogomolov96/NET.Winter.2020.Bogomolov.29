using System.Collections.Generic;
using DAL.Contract;
using Entities;

namespace DAL.Implementations
{
    /// <summary>
    /// Trade data concrete storage.
    /// </summary>
    public class TradeDataStorage : Storage<string, DataTransfer>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TradeDataStorage"/> class.
        /// </summary>
        /// <param name="dataProvider">Inner data provider.</param>
        /// <param name="dataSaver">Inner data saver.</param>
        public TradeDataStorage(IDataProvider<string> dataProvider, IDataSaver<DataTransfer> dataSaver)
            : base(dataProvider, dataSaver)
        {
        }

        /// <summary>
        /// Provides data.
        /// </summary>
        /// <returns>Data sequence.</returns>
        public override IEnumerable<string> GetData()
        {
            return this.dataProvider.GetData();
        }

        /// <summary>
        /// Saves data.
        /// </summary>
        /// <param name="values">Values to save.</param>
        public override void SaveData(IEnumerable<DataTransfer> values)
        {
            this.dataSaver.SaveData(values);
        }
    }
}
