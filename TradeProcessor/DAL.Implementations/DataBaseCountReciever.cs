using DAL.Contract;
using Microsoft.Data.SqlClient;

namespace DAL.Implementations
{
    /// <summary>
    /// Reciever of data vase statistic.
    /// </summary>
    public class DataBaseCountReciever : IStatisticReciever<int>
    {
        private readonly SqlConnection sqlConnection;
        private bool disposedValue = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataBaseCountReciever"/> class.
        /// </summary>
        /// <param name="connectionString">Connection string to data base.</param>
        public DataBaseCountReciever(string connectionString)
        {
            this.sqlConnection = new SqlConnection(connectionString);
        }

        /// <summary>
        /// Gets statistic result.
        /// </summary>
        /// <returns>Statistic result.</returns>
        public int GetStatistic()
        {
            this.sqlConnection.Open();
            using var sqlCommand = new SqlCommand("select count(*) from TradeDatas", this.sqlConnection);
            int count = (int)sqlCommand.ExecuteScalar();
            this.sqlConnection.Close();
            return count;
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
