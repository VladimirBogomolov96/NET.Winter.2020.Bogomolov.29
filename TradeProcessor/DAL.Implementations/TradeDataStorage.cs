using System.Collections.Generic;
using DAL.Contract;
using Entities;

namespace DAL.Implementations
{
    public class TradeDataStorage : Storage<string, DataTransfer>
    {
        public TradeDataStorage(IDataProvider<string> dataProvider, IDataSaver<DataTransfer> dataSaver)
            : base(dataProvider, dataSaver)
        {
        }

        public override IEnumerable<string> GetData()
        {
            return this.dataProvider.GetData();
        }

        public override void SaveData(IEnumerable<DataTransfer> values)
        {
            this.dataSaver.SaveData(values);
        }
    }
}
