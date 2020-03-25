using System;
using System.Collections.Generic;
using DAL.Contract;
using Entities;
using Microsoft.Data.SqlClient;

namespace DAL.Implementations
{
    public class DataTransferToDataBaseSaver : IDataSaver<DataTransfer>
    {
        private readonly SqlConnection sqlConnection;
        private bool disposedValue = false;

        public DataTransferToDataBaseSaver(string connectionString)
        {
            this.sqlConnection = new SqlConnection(connectionString);
        }

        public void SaveData(IEnumerable<DataTransfer> values)
        {
            if (values is null)
            {
                throw new ArgumentNullException(nameof(values), "Values must be not null.");
            }

            this.sqlConnection.Open();
            foreach (DataTransfer dataTransfer in values)
            {
                using var sqlCommand = new SqlCommand($"insert TradeData values ('{dataTransfer.CountryCode}','{dataTransfer.CurrencyCode}',{dataTransfer.AmountOfTrades},{dataTransfer.Cost})", this.sqlConnection);
                sqlCommand.ExecuteNonQuery();
            }

            this.sqlConnection.Close();
        }

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
                    this.sqlConnection.Dispose();
                }

                this.disposedValue = true;
            }
        }
    }
}
