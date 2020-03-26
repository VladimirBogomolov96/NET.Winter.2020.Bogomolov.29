using System.Collections.Generic;
using System.IO;
using System.Text;
using DAL.Contract;

namespace DAL.Implementations
{
    /// <summary>
    /// String data provider.
    /// </summary>
    public class StringsFromStreamDataProvider : IDataProvider<string>
    {
        private readonly StreamReader reader;
        private bool disposedValue = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="StringsFromStreamDataProvider"/> class.
        /// </summary>
        /// <param name="path">Path to file to get data.</param>
        public StringsFromStreamDataProvider(string path)
        {
            this.reader = new StreamReader(path, Encoding.UTF8);
        }

        /// <summary>
        /// Provides data.
        /// </summary>
        /// <returns>Data sequence.</returns>
        public IEnumerable<string> GetData()
        {
            string line;
            while ((line = this.reader.ReadLine()) != null)
            {
                yield return line;
            }
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
                    this.reader.Dispose();
                }

                this.disposedValue = true;
            }
        }
    }
}