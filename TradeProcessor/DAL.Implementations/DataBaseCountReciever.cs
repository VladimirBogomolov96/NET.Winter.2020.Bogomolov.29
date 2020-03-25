using DAL.Contract;
using Microsoft.Data.SqlClient;

namespace DAL.Implementations
{
    public class DataBaseCountReciever : IStatisticReciever<int>
    {
        private readonly SqlConnection sqlConnection;
        private bool disposedValue = false;

        public DataBaseCountReciever(string connectionString)
        {
            this.sqlConnection = new SqlConnection(connectionString);
        }

        public int GetStatistic()
        {
            this.sqlConnection.Open();
            using var sqlCommand = new SqlCommand("select count(*) from TradeData", this.sqlConnection);
            int count = (int)sqlCommand.ExecuteScalar();
            this.sqlConnection.Close();
            return count;
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
