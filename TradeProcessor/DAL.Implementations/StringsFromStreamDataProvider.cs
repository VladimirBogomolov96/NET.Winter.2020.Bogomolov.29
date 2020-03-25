using System.Collections.Generic;
using System.IO;
using System.Text;
using DAL.Contract;

namespace DAL.Implementations
{
    public class StringsFromStreamDataProvider : IDataProvider<string>
    {
        private readonly StreamReader reader;
        private bool disposedValue = false;

        public StringsFromStreamDataProvider(string path)
        {
            this.reader = new StreamReader(path, Encoding.UTF8);
        }

        public IEnumerable<string> GetData()
        {
            string line;
            while ((line = this.reader.ReadLine()) != null)
            {
                yield return line;
            }
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
                    this.reader.Dispose();
                }

                this.disposedValue = true;
            }
        }
    }
}