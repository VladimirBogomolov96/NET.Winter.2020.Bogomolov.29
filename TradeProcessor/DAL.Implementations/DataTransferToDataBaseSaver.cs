using System;
using System.Collections.Generic;
using DAL.Contract;
using Entities;
using Microsoft.Data.SqlClient;

namespace DAL.Implementations
{
    /// <summary>
    /// DataTransfer saver to data base.
    /// </summary>
    public class DataTransferToDataBaseSaver : IDataSaver<DataTransfer>
    {
        private readonly SqlConnection sqlConnection;
        private bool disposedValue = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataTransferToDataBaseSaver"/> class.
        /// </summary>
        /// <param name="connectionString">Connection string to data base.</param>
        public DataTransferToDataBaseSaver(string connectionString)
        {
            this.sqlConnection = new SqlConnection(connectionString);
        }

        /// <summary>
        /// Saves data.
        /// </summary>
        /// <param name="values">Values to save.</param>
        public void SaveData(IEnumerable<DataTransfer> values)
        {
            if (values is null)
            {
                throw new ArgumentNullException(nameof(values), "Values must be not null.");
            }

            this.sqlConnection.Open();
            foreach (DataTransfer dataTransfer in values)
            {
                using var sqlCommand = new SqlCommand($"insert TradeDatas values ('{dataTransfer.CountryCode}','{dataTransfer.CurrencyCode}',{dataTransfer.AmountOfTrades},{dataTransfer.Cost})", this.sqlConnection);
                sqlCommand.ExecuteNonQuery();
            }

            this.sqlConnection.Close();
        }

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
                    this.sqlConnection.Dispose();
                }

                this.disposedValue = true;
            }
        }
    }
}
